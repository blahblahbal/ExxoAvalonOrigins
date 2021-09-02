using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs.Bosses
{
    class OblivionPhase1 : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oblivion (WIP)");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            npc.damage = 150;
            npc.boss = true;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 85000;
            npc.defense = 50;
            npc.noGravity = true;
            npc.width = 110;
            npc.aiStyle = -1;
            npc.npcSlots = 6f;
            npc.value = 50000f;
            npc.timeLeft = 750;
            npc.height = 152;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Frostburn] = true;

            AIState = State.Follow;
            AITimer = 0;
        }

        public enum State
        {
            Follow,
            DashFindInitialNode,
            DashGotoNodeSlow,
            DashFindNode,
            DashGotoNode,
            DashGotoNodeCircle,
            LaserPreTransform,
            Transform
        }

        private const int AISlotState = 0;
        private const int AISlotTimer = 1;
        private const int AISlotNodePositionX = 2;
        private const int AISlotNodePositionY = 3;

        public State AIState
        {
            get => (State)npc.ai[AISlotState];
            set => npc.ai[AISlotState] = (float)value;
        }

        public float AITimer
        {
            get => npc.ai[AISlotTimer];
            set => npc.ai[AISlotTimer] = value;
        }

        public Vector2 AINodePosition
        {
            get => new Vector2(npc.ai[AISlotNodePositionX], npc.ai[AISlotNodePositionY]);
            set
            {
                npc.ai[AISlotNodePositionX] = value.X;
                npc.ai[AISlotNodePositionY] = value.Y;
            }
        }

        public int AIStalkRotation { get; set; }
        public int AIRemainingDashes { get; set; }
        public bool AICircleToNextNode { get; set; }
        public bool AINodeRelativeToPlayer { get; set; }
        public Vector2 AITargetedPosition { get; set; }
        private float followDistance = 16f * 15f;
        private float dashNodeRadius = 16f * 45f;
        private float dashNodeActivationRadius = 16f * 5f;

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(AIStalkRotation);
            writer.Write(AIRemainingDashes);
            writer.Write(AICircleToNextNode);
            writer.Write(AINodeRelativeToPlayer);
            writer.WriteVector2(AITargetedPosition);
            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            AIStalkRotation = reader.ReadInt32();
            AIRemainingDashes = reader.ReadInt32();
            AICircleToNextNode = reader.ReadBoolean();
            AINodeRelativeToPlayer = reader.ReadBoolean();
            AITargetedPosition = reader.ReadVector2();
            base.ReceiveExtraAI(reader);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            //Texture2D texture = ExxoAvalonOrigins.mod.GetTexture("NPCs/Bosses/OblivionPhase1Shadow");
            //Vector2 origin = new Vector2(texture.Width / 2, (texture.Height / Main.npcFrameCount[npc.type]) / 2);
            //Player player = Main.player[npc.target];
            //Vector2 vectorToPlayer = player.Center - npc.Center;
            //Vector2 unitVectorToPlayer = vectorToPlayer;
            //unitVectorToPlayer.Normalize();
            //Vector2 position = npc.position - unitVectorToPlayer * 25f;
            //spriteBatch.Draw(texture, position - Main.screenPosition + origin, new Rectangle(0, npc.frame.Y, texture.Width, texture.Height / Main.npcFrameCount[npc.type]), drawColor * 1f, npc.rotation, origin, 1f, SpriteEffects.None, 0f);
            return base.PreDraw(spriteBatch, drawColor);
        }

        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            Player player = Main.player[npc.target];
            AITimer++;

            Vector2 vectorToPlayer = player.Center - npc.Center;
            Vector2 unitVectorToPlayer = vectorToPlayer;
            unitVectorToPlayer.Normalize();

            npc.rotation = (float)Math.Atan2(unitVectorToPlayer.Y, unitVectorToPlayer.X) - (float)(Math.PI / 2);

            switch (AIState)
            {
                case State.Follow:
                    {
                        float speed = 0.05f;

                        // First update
                        if (AITimer == 1)
                        {
                            if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                            {
                                Color tintColor = new Color(80, 0, 120);
                                Filters.Scene.Activate("OblivionDarkenScreen").GetShader().UseColor(tintColor);
                                Main.npcTexture[npc.type] = ExxoAvalonOrigins.mod.GetTexture("NPCs/Bosses/OblivionPhase1Shadow");
                            }
                            AIStalkRotation = (int)MathHelper.ToDegrees((float)Math.Atan2(unitVectorToPlayer.Y, unitVectorToPlayer.X));
                        }

                        // After 250 seconds begin dashing
                        if (AITimer > 250)
                        {
                            AIState = State.DashFindInitialNode;
                            AITimer = 0;
                            if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                            {
                                Filters.Scene["OblivionDarkenScreen"].Deactivate();
                                Main.npcTexture[npc.type] = ExxoAvalonOrigins.mod.GetTexture("NPCs/Bosses/OblivionPhase1");
                            }
                            break;
                        }

                        // Every n seconds, change stalk rotation, ensuring rotation is atleast a 45 degree difference to the current rotation
                        if (AITimer % 45 == 0)
                        {
                            AIStalkRotation += Main.rand.Next(270) + 45;
                            AIStalkRotation %= 360;
                            npc.alpha = 240;
                            npc.position = player.Center + (player.Center - npc.Center).Length() * new Vector2(-1, 0).RotatedBy(MathHelper.ToRadians(AIStalkRotation));
                        }

                        // Fade back alpha
                        if (npc.alpha > 0)
                        {
                            npc.alpha -= 7;
                        }

                        // Go to target position relative to player
                        Vector2 targetPosition = player.Center + new Vector2(-1, 0).RotatedBy(MathHelper.ToRadians(AIStalkRotation)) * followDistance;
                        npc.velocity = player.velocity + (targetPosition - npc.Center) * speed;

                        break;
                    }
                case State.DashFindInitialNode:
                    {
                        Vector2 unitVectorToNode = new Vector2(0, -1);
                        if (npc.Center.Y < player.Center.Y && npc.Center.X > player.Center.X)
                        {
                            unitVectorToNode = unitVectorToNode.RotatedBy(MathHelper.ToRadians(45));
                        }
                        else if (npc.Center.Y > player.Center.Y && npc.Center.X > player.Center.X)
                        {
                            unitVectorToNode = unitVectorToNode.RotatedBy(MathHelper.ToRadians(135));
                        }
                        else if (npc.Center.Y > player.Center.Y && npc.Center.X < player.Center.X)
                        {
                            unitVectorToNode = unitVectorToNode.RotatedBy(MathHelper.ToRadians(225));
                        }
                        else if (npc.Center.Y < player.Center.Y && npc.Center.X < player.Center.X)
                        {
                            unitVectorToNode = unitVectorToNode.RotatedBy(MathHelper.ToRadians(315));
                        }

                        AICircleToNextNode = false;
                        AINodePosition = unitVectorToNode * dashNodeRadius;
                        AINodeRelativeToPlayer = true;
                        AIRemainingDashes = 3;
                        AIState = State.DashGotoNodeSlow;
                        AITimer = 0;

                        break;
                    }
                case State.DashGotoNodeSlow:
                    {
                        float speed = 0.1f;

                        Vector2 vectorToNode;
                        if (AINodeRelativeToPlayer)
                        {
                            vectorToNode = (player.Center + AINodePosition) - npc.Center;
                            npc.velocity = player.velocity + vectorToNode * speed;
                        }
                        else
                        {
                            vectorToNode = (AITargetedPosition + AINodePosition) - npc.Center;
                            npc.velocity = vectorToNode * speed;
                        }

                        if (vectorToNode.Length() < dashNodeActivationRadius)
                        {
                            AITimer = 0;
                            AIState = State.DashFindNode;
                        }

                        break;
                    }
                case State.DashFindNode:
                    {
                        AITimer = 0;

                        if (AICircleToNextNode)
                        {
                            AINodeRelativeToPlayer = true;
                            AINodePosition = new Vector2(-1, 1) * unitVectorToPlayer * dashNodeRadius;
                        }
                        else
                        {
                            AINodeRelativeToPlayer = false;
                            AITargetedPosition = player.Center;
                            AINodePosition = unitVectorToPlayer * dashNodeRadius;
                        }

                        AIState = State.DashGotoNode;
                        break;
                    }
                case State.DashGotoNode:
                    {
                        float speed = 0.1f;
                        float railSpeed = 2.5f;

                        // Allows player to dodge
                        if (!AICircleToNextNode)
                        {
                            if (AITimer < 15)
                            {
                                break;
                            }

                            if (AITimer == 15)
                            {
                                Main.PlaySound(SoundID.ForceRoar, (int)npc.position.X, (int)npc.position.Y, -1);
                            }
                        }

                        Vector2 vectorToNode;
                        if (AINodeRelativeToPlayer)
                        {
                            vectorToNode = (player.Center + AINodePosition) - npc.Center;
                        }
                        else
                        {
                            vectorToNode = (AITargetedPosition + AINodePosition) - npc.Center;
                        }

                        // Go to node
                        if (!AICircleToNextNode)
                        {
                            npc.velocity = vectorToNode * speed;
                        }
                        else
                        {
                            bool clockWise = false;
                            if (AINodePosition.X > 0 && AINodePosition.Y < 0)
                            {
                                clockWise = true;
                            }
                            else if (AINodePosition.X < 0 && AINodePosition.Y > 0)
                            {
                                clockWise = true;
                            }
                            float radians = MathHelper.ToRadians((90 - (railSpeed * AITimer)) * (clockWise ? 1 : -1));

                            npc.velocity = Vector2.Zero;
                            npc.position = (player.Center + AINodePosition.RotatedBy(radians));
                        }

                        // At node
                        if (vectorToNode.Length() < dashNodeActivationRadius || (AICircleToNextNode && railSpeed * AITimer > 90))
                        {
                            AITimer = 0;
                            if (!AICircleToNextNode)
                                AIRemainingDashes--;
                            if (AIRemainingDashes > 0)
                            {
                                AICircleToNextNode = !AICircleToNextNode;
                                if (AICircleToNextNode)
                                {
                                    AINodeRelativeToPlayer = true;
                                    AIState = State.DashGotoNodeSlow;
                                }
                                else
                                {
                                    AIState = State.DashFindNode;
                                }
                            }
                            else
                            {
                                AIState = State.Follow;
                            }
                        }

                        break;
                    }
                case State.LaserPreTransform:
                    {
                        break;
                    }
                case State.Transform:
                    {
                        break;
                    }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter < 7.0)
            {
                npc.frame.Y = 0;
            }
            else if (npc.frameCounter < 14.0)
            {
                npc.frame.Y = frameHeight;
            }
            else if (npc.frameCounter < 21.0)
            {
                npc.frame.Y = frameHeight * 2;
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
            //if (npc.ai[0] > 1f)
            //{
            //	npc.frame.Y = npc.frame.Y + frameHeight * 3;
            //}
        }

        public override void NPCLoot()
        {
            if (Main.netMode != NetmodeID.Server && Filters.Scene["OblivionDarkenScreen"].IsActive()) // This all needs to happen client-side!
            {
                Filters.Scene["OblivionDarkenScreen"].Deactivate();
                Main.npcTexture[npc.type] = ExxoAvalonOrigins.mod.GetTexture("NPCs/Bosses/OblivionPhase1");
            }
        }
    }
}