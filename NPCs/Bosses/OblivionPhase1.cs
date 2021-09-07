using Microsoft.Xna.Framework;
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
            StageDash,
            FlurryDashBegin,
            FlurryDash,
            FlurryDashEnd,
            StalkBegin,
            Stalk,
            StalkEnd,
            XDashBegin,
            XDashToNodeSlow,
            XDashToNode,
            XDashFindNextNode,
            StageLaser,
            StageTransform,
        }

        private const int AISlotTimer = 0;
        private const int AISlotFrameOffset = 1;
        private const int AISlotState = 2;
        private const int AISlotStalkRotation = 3;

        public float AITimer
        {
            get => npc.ai[AISlotTimer];
            set => npc.ai[AISlotTimer] = value;
        }

        public int AIFrameOffset
        {
            get => (int)npc.ai[AISlotFrameOffset];
            set => npc.ai[AISlotFrameOffset] = value;
        }

        public State AIState
        {
            get => (State)npc.ai[AISlotState];
            set
            {
                npc.ai[AISlotState] = (float)value;
                AITimer = 0;
            }
        }

        public float AIStalkRotation
        {
            get => npc.ai[AISlotStalkRotation];
            set => npc.ai[AISlotStalkRotation] = value;
        }

        private BitsByte AINetworkOptimisedBooleans = new BitsByte();
        private const int AIBoolSlotCircleToNextNode = 0;
        private const int AIBoolSlotNodeRelativeToPlayer = 1;

        public bool AICircleToNextNode
        {
            get => AINetworkOptimisedBooleans[AIBoolSlotCircleToNextNode];
            set => AINetworkOptimisedBooleans[AIBoolSlotCircleToNextNode] = value;
        }

        public bool AINodeRelativeToPlayer
        {
            get => AINetworkOptimisedBooleans[AIBoolSlotNodeRelativeToPlayer];
            set => AINetworkOptimisedBooleans[AIBoolSlotNodeRelativeToPlayer] = value;
        }

        public Vector2 AITargetedPosition { get; set; }
        public Vector2 AINodePosition { get; set; }
        public int AIRemainingDashes { get; set; }
        public int AIRemainingFlurryDashes { get; set; }
        public int AIActiveDrones { get; set; }

        private float followDistance = 16f * 15f;
        private float dashNodeRadius = 16f * 45f;
        private float dashNodeActivationRadius = 16f * 1f;

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.WriteVector2(AITargetedPosition);
            writer.WriteVector2(AINodePosition);
            writer.Write(AIRemainingDashes);
            writer.Write(AIRemainingFlurryDashes);
            writer.Write(AIActiveDrones);
            writer.Write(AINetworkOptimisedBooleans);

            base.SendExtraAI(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            AITargetedPosition = reader.ReadVector2();
            AINodePosition = reader.ReadVector2();
            AIRemainingDashes = reader.ReadInt32();
            AIRemainingFlurryDashes = reader.ReadInt32();
            AIActiveDrones = reader.ReadInt32();
            AINetworkOptimisedBooleans = reader.ReadByte();

            base.ReceiveExtraAI(reader);
        }

        public override string[] AltTextures => new string[] { ExxoAvalonOrigins.mod.Name + "/NPCs/Bosses/OblivionPhase1Shadow" };

        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            Player player = Main.player[npc.target];
            AITimer++;

            Vector2 vectorToPlayer = player.Center - npc.Center;
            Vector2 unitVectorToPlayer = vectorToPlayer.SafeNormalize(Vector2.UnitX);

            npc.rotation = (float)Math.Atan2(unitVectorToPlayer.Y, unitVectorToPlayer.X) - (float)(Math.PI / 2);

            switch (AIState)
            {
                case State.Follow:
                    {
                        if (npc.life > npc.lifeMax * 3 / 4)
                        {
                            AIState = State.StageDash;
                        }
                        else if (npc.life > npc.lifeMax / 3)
                        {
                            AIState = State.StageLaser;
                        }
                        else
                        {
                            AIState = State.StageTransform;
                        }

                        break;
                    }
                case State.StageDash:
                    {
                        AIRemainingDashes = 4;
                        AIRemainingFlurryDashes = 5;
                        AIState = State.FlurryDashBegin;
                        break;
                    }
                case State.FlurryDashBegin:
                    {
                        AIRemainingFlurryDashes--;
                        AINodePosition = (unitVectorToPlayer * 12 * 16f).RotatedByRandom(Math.PI / 2);
                        AITargetedPosition = npc.Center;
                        AIState = State.FlurryDash;
                        break;
                    }
                case State.FlurryDash:
                    {
                        float speed = 0.2f;
                        float projectileSpeed = 25f;

                        Vector2 unitVectorToNode = AINodePosition.SafeNormalize(Vector2.UnitX);

                        // Shoot
                        if (Main.netMode != NetmodeID.MultiplayerClient && AIRemainingFlurryDashes <= 0)
                        {
                            if (AIRemainingDashes > 0)
                            {
                                if (AITimer == 1)
                                {
                                    Projectile.NewProjectile(npc.Center + unitVectorToNode * Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2, unitVectorToPlayer * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFireball>(), 25, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                            else
                            {
                                if (AITimer < 5)
                                {
                                    Projectile.NewProjectile(npc.Center + unitVectorToNode * Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2, unitVectorToPlayer * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFlamethrower>(), 30, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                        }

                        Vector2 vectorToNode = AITargetedPosition + AINodePosition - npc.Center;
                        npc.velocity = vectorToNode * speed;

                        if (vectorToNode.Length() < dashNodeActivationRadius)
                        {
                            AIState = State.FlurryDashEnd;
                        }

                        break;
                    }
                case State.FlurryDashEnd:
                    {
                        if (AIRemainingFlurryDashes > 0)
                        {
                            AIState = State.FlurryDashBegin;
                        }
                        else
                        {
                            if (AIRemainingDashes > 0)
                            {
                                AIRemainingDashes--;
                                AIRemainingFlurryDashes = 5;
                                AIState = State.FlurryDashBegin;
                            }
                            else
                            {
                                AIState = State.StalkBegin;
                            }
                        }

                        break;
                    }
                case State.StalkBegin:
                    {
                        if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                        {
                            Color tintColor = new Color(80, 0, 120);
                            Filters.Scene.Activate(Effects.Effects.SceneKeyOblivionDarkenScreen).GetShader().UseColor(tintColor);
                            npc.altTexture = 1;
                        }
                        AIStalkRotation = (float)Math.Atan2(unitVectorToPlayer.Y, unitVectorToPlayer.X);

                        AIState = State.Stalk;
                        break;
                    }
                case State.Stalk:
                    {
                        float speed = 0.05f;

                        // Every n seconds, change stalk rotation, ensuring rotation is atleast a 45 degree difference to the current rotation
                        if (AITimer % 45 == 0)
                        {
                            AIStalkRotation += (float)((Main.rand.NextFloat() * Math.PI * 6 / 4) + Math.PI / 4);
                            AIStalkRotation %= (float)(Math.PI * 2);
                            npc.alpha = 255;
                            npc.position = player.Center + Vector2.UnitY.RotatedBy(AIStalkRotation) * vectorToPlayer.Length();
                        }

                        // Fade back alpha
                        if (npc.alpha > 0)
                        {
                            npc.alpha -= 7;
                        }

                        // Go to target position relative to player
                        Vector2 targetPosition = player.Center + Vector2.UnitY.RotatedBy(AIStalkRotation) * followDistance;
                        npc.velocity = player.velocity + (targetPosition - npc.Center) * speed;

                        if (AITimer > 250)
                        {
                            AIState = State.StalkEnd;
                            break;
                        }

                        break;
                    }
                case State.StalkEnd:
                    {
                        if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                        {
                            Filters.Scene[Effects.Effects.SceneKeyOblivionDarkenScreen].Deactivate();
                            npc.altTexture = 0;
                        }
                        npc.alpha = 0;
                        AIState = State.XDashBegin;
                        break;
                    }
                case State.XDashBegin:
                    {
                        Vector2 unitVectorToNode = (-Vector2.UnitY).RotatedBy(Math.PI / 4);
                        if (npc.Center.Y < player.Center.Y && npc.Center.X > player.Center.X)
                        {
                        }
                        else if (npc.Center.Y > player.Center.Y && npc.Center.X > player.Center.X)
                        {
                            unitVectorToNode = unitVectorToNode.RotatedBy(Math.PI / 2);
                        }
                        else if (npc.Center.Y > player.Center.Y && npc.Center.X < player.Center.X)
                        {
                            unitVectorToNode = unitVectorToNode.RotatedBy(Math.PI);
                        }
                        else if (npc.Center.Y < player.Center.Y && npc.Center.X < player.Center.X)
                        {
                            unitVectorToNode = unitVectorToNode.RotatedBy(-Math.PI / 2);
                        }

                        AICircleToNextNode = false;
                        AINodeRelativeToPlayer = true;
                        AINodePosition = unitVectorToNode * dashNodeRadius;
                        AIRemainingDashes = 3;
                        AIState = State.XDashToNodeSlow;

                        break;
                    }
                case State.XDashToNodeSlow:
                    {
                        float speed = 0.1f;
                        float minSpeed = 8f;

                        Vector2 vectorToNode = AINodePosition - npc.Center;
                        npc.velocity = Vector2.Zero;
                        if (AINodeRelativeToPlayer)
                        {
                            vectorToNode += player.Center;
                            npc.velocity = player.velocity;
                        }
                        else
                        {
                            vectorToNode += AITargetedPosition;
                        }
                        npc.velocity += vectorToNode * speed;

                        Vector2 unit = vectorToNode.SafeNormalize(Vector2.UnitX);
                        npc.velocity += unit * minSpeed;

                        if (vectorToNode.Length() < dashNodeActivationRadius)
                        {
                            AIState = State.XDashFindNextNode;
                        }

                        break;
                    }
                case State.XDashFindNextNode:
                    {
                        if (AICircleToNextNode)
                        {
                            AINodeRelativeToPlayer = true;
                            AINodePosition = new Vector2(-unitVectorToPlayer.X, unitVectorToPlayer.Y) * dashNodeRadius;
                        }
                        else
                        {
                            AINodeRelativeToPlayer = false;
                            AITargetedPosition = player.Center;
                            AINodePosition = unitVectorToPlayer * dashNodeRadius;
                        }

                        AIState = State.XDashToNode;
                        break;
                    }
                case State.XDashToNode:
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

                        Vector2 vectorToNode = AINodePosition - npc.Center;
                        if (AINodeRelativeToPlayer)
                        {
                            vectorToNode += player.Center;
                        }
                        else
                        {
                            vectorToNode += AITargetedPosition;
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
                            if (!AICircleToNextNode)
                                AIRemainingDashes--;
                            if (AIRemainingDashes > 0)
                            {
                                AICircleToNextNode = !AICircleToNextNode;
                                if (AICircleToNextNode)
                                {
                                    AINodeRelativeToPlayer = true;
                                    AIState = State.XDashToNodeSlow;
                                }
                                else
                                {
                                    AIState = State.XDashFindNextNode;
                                }
                            }
                            else
                            {
                                AIState = State.Follow;
                            }
                        }

                        break;
                    }
                case State.StageLaser:
                    {
                        if (AITimer == 1)
                        {
                            AIFrameOffset = 1;
                        }

                        // Move above player head moving slow to follow distance
                        float speed = 0.1f;
                        AINodePosition = -Vector2.UnitY * followDistance;
                        Vector2 vectorToNode = AINodePosition + player.Center - npc.Center;
                        npc.velocity = vectorToNode * speed;

                        // Spawn defence drones
                        if (AITimer == 1 || AITimer % 1800 == 0)
                        {
                            int amountDrones = 8;
                            for (var i = 0; i < amountDrones; i++)
                            {
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.AncientOblivionCannon>(), 0, npc.whoAmI);
                            }
                        }

                        // Sweep laser
                        if (AITimer % 600 == 0)
                        {
                            AITargetedPosition = player.Center;
                        }
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
            npc.frame.Y += frameHeight * 3 * AIFrameOffset;
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