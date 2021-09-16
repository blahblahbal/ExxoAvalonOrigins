using ExxoAvalonOrigins.NPCs.Utils;
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
        }

        private const int AISlotFrameOffset = 0;

        public int AIFrameOffset
        {
            get => (int)npc.ai[AISlotFrameOffset];
            set => npc.ai[AISlotFrameOffset] = value;
        }

        public override string[] AltTextures => new string[] { ExxoAvalonOrigins.mod.Name + "/NPCs/Bosses/OblivionPhase1Shadow" };

        private MainState mainState;

        public override void SendExtraAI(BinaryWriter writer)
        {
            mainState.Write(writer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            if (mainState == null)
            {
                mainState = new MainState();
                mainState.UpdateBaseData(this);
            }
            mainState.Read(reader);
        }

        public override void AI()
        {
            if (mainState == null)
            {
                mainState = new MainState();
            }
            mainState.StartUpdate(this);
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
            mainState?.Unload();
        }

        private class MainState : StateParent
        {
            protected override void Start()
            {
                if (npc.life > npc.lifeMax * 3 / 4)
                {
                    StartTree(treeFirstStage);
                }
            }

            public override bool AutoDestroyOnFinish => false;
            private const int treeFirstStage = 0;

            protected override void InactiveUpdate()
            {
                if (npc.life > npc.lifeMax * 3 / 4)
                {
                    if (FramesInactive == 1)
                    {
                        StartTree(treeFirstStage);
                    }
                }
                else if (npc.life > npc.lifeMax / 3)
                {
                    (ModNPC as OblivionPhase1).AIFrameOffset = 1;
                }
            }

            protected override void HandleAdvanceState()
            {
                switch (TreeID)
                {
                    case treeFirstStage:
                        HandleFirstStageTree();
                        break;
                }
            }

            private void HandleFirstStageTree()
            {
                switch (StatePosition)
                {
                    case 0:
                        SetState(new DashState());
                        break;
                }
            }

            protected override void PreUpdate()
            {
                FindTarget();
                LookAtTarget();
            }

            private void FindTarget()
            {
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
                {
                    npc.TargetClosest(true);
                }
            }

            private void LookAtTarget()
            {
                npc.rotation = (float)Math.Atan2(unitVectorToTarget.Y, unitVectorToTarget.X) - (float)(Math.PI / 2);
            }
        }

        public class DashState : StateParent
        {
            public override bool AutoDestroyOnFinish => true;

            protected override void Start()
            {
                StartTree(0);
            }

            protected override void HandleAdvanceState()
            {
                switch (StatePosition)
                {
                    case 0:
                        SetState(new FlurryDash());
                        break;

                    case 1:
                        SetState(new Stalk());
                        break;

                    case 2:
                        SetState(new XDash());
                        break;
                }
            }
        }

        public class FlurryDash : State
        {
            private const float dashNodeActivationRadius = 16f;
            private const float dashDistance = 12 * 16f;
            private const float speed = 0.2f;
            private const float projectileSpeed = 25f;
            private int remainingDashes;
            private int remainingFlurryDashes;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;

            public FlurryDash() : base()
            {
                remainingDashes = 4;
                remainingFlurryDashes = 5;
            }

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(remainingDashes);
                writer.Write(remainingFlurryDashes);
                writer.WriteVector2(nodePosition);
                writer.WriteVector2(targetedPosition);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                remainingDashes = reader.ReadInt32();
                remainingFlurryDashes = reader.ReadInt32();
                nodePosition = reader.ReadVector2();
                targetedPosition = reader.ReadVector2();
            }

            protected override void Start()
            {
                remainingFlurryDashes--;
                nodePosition = (unitVectorToTarget * dashDistance).RotatedBy((syncedRandom.NextDouble() * Math.PI / 2) - (Math.PI / 4));
                targetedPosition = ModNPC.npc.Center;
            }

            protected override void Update()
            {
                Vector2 unitVectorToNode = nodePosition.SafeNormalize(Vector2.UnitX);

                if (Main.netMode != NetmodeID.MultiplayerClient && remainingFlurryDashes <= 0)
                {
                    if (remainingDashes > 0)
                    {
                        if (CurrentFrame == 1)
                        {
                            Projectile.NewProjectile(npc.Center + unitVectorToNode * npc.height / 2, unitVectorToTarget * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFireball>(), 25, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    else
                    {
                        if (CurrentFrame < 5)
                        {
                            Projectile.NewProjectile(npc.Center + unitVectorToNode * npc.height / 2, unitVectorToTarget * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFlamethrower>(), 30, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }

                Vector2 vectorToNode = targetedPosition + nodePosition - npc.Center;
                npc.velocity = vectorToNode * speed;

                if (vectorToNode.Length() < dashNodeActivationRadius)
                {
                    if (remainingFlurryDashes > 0)
                    {
                        Restart();
                    }
                    else
                    {
                        if (remainingDashes > 0)
                        {
                            Restart();
                            remainingDashes--;
                            remainingFlurryDashes = 5;
                        }
                        else
                        {
                            Destroy();
                        }
                    }
                }
            }
        }

        public class Stalk : State
        {
            private const float followDistance = 16f * 15f;
            private float stalkRotation;

            public Stalk() : base()
            {
                stalkRotation = (float)Math.Atan2(unitVectorToTarget.Y, unitVectorToTarget.X);
            }

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(stalkRotation);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                stalkRotation = reader.ReadSingle();
            }

            public override void Load()
            {
                if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                {
                    Color tintColor = new Color(80, 0, 120);
                    Filters.Scene.Activate(Effects.Effects.SceneKeyOblivionDarkenScreen).GetShader().UseColor(tintColor);
                    ModNPC.npc.altTexture = 1;
                }
            }

            protected override void Update()
            {
                float speed = 0.05f;

                // Every n seconds, change stalk rotation, ensuring rotation is atleast a 45 degree difference to the current rotation
                if (CurrentFrame % 45 == 0)
                {
                    stalkRotation += (float)((syncedRandom.NextDouble() * Math.PI * 6 / 4) + Math.PI / 4);
                    stalkRotation %= (float)(Math.PI * 2);
                    npc.position = target.Center + Vector2.UnitY.RotatedBy(stalkRotation) * vectorToTarget.Length();
                    npc.alpha = 255;
                }

                // Fade back alpha
                if (npc.alpha > 0)
                {
                    npc.alpha -= 7;
                }

                // Go to target position relative to player
                Vector2 targetPosition = target.Center + Vector2.UnitY.RotatedBy(stalkRotation) * followDistance;
                npc.velocity = target.velocity + (targetPosition - npc.Center) * speed;

                if (CurrentFrame > 250)
                {
                    Destroy();
                }
            }

            public override void Unload()
            {
                if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                {
                    Filters.Scene[Effects.Effects.SceneKeyOblivionDarkenScreen].Deactivate();
                    ModNPC.npc.altTexture = 0;
                }
                ModNPC.npc.alpha = 0;
            }
        }

        public class XDash : StateParent
        {
            private const float dashNodeRadius = 16f * 45f;
            private int remainingDashes;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(remainingDashes);
                writer.WriteVector2(nodePosition);
                writer.WriteVector2(targetedPosition);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                remainingDashes = reader.ReadInt32();
                nodePosition = reader.ReadVector2();
                targetedPosition = reader.ReadVector2();
            }

            public override bool AutoDestroyOnFinish => false;
            private const int treeFirstDash = 0;
            private const int treeSuccessorDash = 1;

            protected override void Start()
            {
                remainingDashes = 3;

                StartTree(treeFirstDash);
            }

            protected override void InactiveUpdate()
            {
                if (remainingDashes > 0)
                {
                    StartTree(treeSuccessorDash);
                }
                else
                {
                    Destroy();
                }
            }

            protected override void HandleAdvanceState()
            {
                switch (TreeID)
                {
                    case treeFirstDash:
                        HandleFirstDashTree();
                        break;

                    case treeSuccessorDash:
                        HandleSuccessorDashTree();
                        break;
                }
            }

            private void HandleFirstDashTree()
            {
                switch (StatePosition)
                {
                    case 0:
                        remainingDashes--;
                        FindInitialNode();
                        SetState(new XDashToNodeSlow(nodePosition, targetedPosition, true));
                        break;

                    case 1:
                        FindNextDashNode();
                        SetState(new XDashToNode(nodePosition, targetedPosition, false));
                        break;
                }
            }

            private void HandleSuccessorDashTree()
            {
                switch (StatePosition)
                {
                    case 0:
                        remainingDashes--;
                        SetState(new XDashToNodeSlow(nodePosition, targetedPosition, true));
                        break;

                    case 1:
                        FindNextCircleToNode();
                        SetState(new XDashCircleToNode(nodePosition, targetedPosition, true));
                        break;

                    case 2:
                        FindNextDashNode();
                        SetState(new XDashToNode(nodePosition, targetedPosition, false));
                        break;
                }
            }

            private void FindInitialNode()
            {
                Vector2 unitVectorToNode = (-Vector2.UnitY).RotatedBy(Math.PI / 4);
                if (npc.Center.Y < target.Center.Y && npc.Center.X > target.Center.X)
                {
                }
                else if (npc.Center.Y > target.Center.Y && npc.Center.X > target.Center.X)
                {
                    unitVectorToNode = unitVectorToNode.RotatedBy(Math.PI / 2);
                }
                else if (npc.Center.Y > target.Center.Y && npc.Center.X < target.Center.X)
                {
                    unitVectorToNode = unitVectorToNode.RotatedBy(Math.PI);
                }
                else if (npc.Center.Y < target.Center.Y && npc.Center.X < target.Center.X)
                {
                    unitVectorToNode = unitVectorToNode.RotatedBy(-Math.PI / 2);
                }
                nodePosition = unitVectorToNode * dashNodeRadius;
            }

            private void FindNextDashNode()
            {
                targetedPosition = target.Center;
                nodePosition = unitVectorToTarget * dashNodeRadius;
            }

            private void FindNextCircleToNode()
            {
                nodePosition = new Vector2(-unitVectorToTarget.X, unitVectorToTarget.Y) * dashNodeRadius;
            }
        }

        public class XDashToNodeSlow : State
        {
            private bool relativeToTarget;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;
            private const float speed = 0.1f;
            private const float minSpeed = 8f;
            private const float dashNodeActivationRadius = 16f;

            public XDashToNodeSlow(Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget) : base()
            {
                this.nodePosition = nodePosition;
                this.targetedPosition = targetedPosition;
                this.relativeToTarget = relativeToTarget;
            }

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(relativeToTarget);
                writer.WriteVector2(nodePosition);
                writer.WriteVector2(targetedPosition);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                relativeToTarget = reader.ReadBoolean();
                nodePosition = reader.ReadVector2();
                targetedPosition = reader.ReadVector2();
            }

            protected override void Update()
            {
                NPC npc = ModNPC.npc;

                Vector2 vectorToNode = nodePosition;
                npc.velocity = Vector2.Zero;
                if (relativeToTarget)
                {
                    vectorToNode += target.Center;
                    npc.velocity = target.velocity;
                }
                else
                {
                    vectorToNode += targetedPosition;
                }
                vectorToNode -= npc.Center;
                npc.velocity += (vectorToNode) * speed;

                Vector2 unit = vectorToNode.SafeNormalize(Vector2.UnitX);
                npc.velocity += unit * minSpeed;

                if (vectorToNode.Length() < dashNodeActivationRadius)
                {
                    Destroy();
                }
            }
        }

        public class XDashToNode : State
        {
            private bool relativeToTarget;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;
            private const float speed = 0.1f;
            private const float dashNodeActivationRadius = 16f;

            public XDashToNode(Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget) : base()
            {
                this.nodePosition = nodePosition;
                this.targetedPosition = targetedPosition;
                this.relativeToTarget = relativeToTarget;
            }

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(relativeToTarget);
                writer.WriteVector2(nodePosition);
                writer.WriteVector2(targetedPosition);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                relativeToTarget = reader.ReadBoolean();
                nodePosition = reader.ReadVector2();
                targetedPosition = reader.ReadVector2();
            }

            protected override void Update()
            {
                if (CurrentFrame < 15)
                {
                    return;
                }

                if (CurrentFrame == 15)
                {
                    Main.PlaySound(SoundID.ForceRoar, (int)npc.position.X, (int)npc.position.Y, -1);
                }

                Vector2 vectorToNode = nodePosition - npc.Center;
                if (relativeToTarget)
                {
                    vectorToNode += target.Center;
                }
                else
                {
                    vectorToNode += targetedPosition;
                }

                // Go to node
                npc.velocity = vectorToNode * speed;

                // At node
                if (vectorToNode.Length() < dashNodeActivationRadius)
                {
                    Destroy();
                }
            }
        }

        public class XDashCircleToNode : State
        {
            private bool relativeToTarget;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;
            private const float railSpeed = 2.5f;
            private const float dashNodeActivationRadius = 16f;
            private bool clockWise;

            public XDashCircleToNode(Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget) : base()
            {
                this.nodePosition = nodePosition;
                this.targetedPosition = targetedPosition;
                this.relativeToTarget = relativeToTarget;

                clockWise = false;
                if ((nodePosition.X > 0 && nodePosition.Y < 0) || (nodePosition.X < 0 && nodePosition.Y > 0))
                {
                    clockWise = true;
                }
            }

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(relativeToTarget);
                writer.Write(clockWise);
                writer.WriteVector2(nodePosition);
                writer.WriteVector2(targetedPosition);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                relativeToTarget = reader.ReadBoolean();
                clockWise = reader.ReadBoolean();
                nodePosition = reader.ReadVector2();
                targetedPosition = reader.ReadVector2();
            }

            protected override void Update()
            {
                Vector2 vectorToNode = nodePosition - npc.Center;
                if (relativeToTarget)
                {
                    vectorToNode += target.Center;
                }
                else
                {
                    vectorToNode += targetedPosition;
                }

                // Go to node

                float radians = MathHelper.ToRadians((90 - (railSpeed * CurrentFrame)) * (clockWise ? 1 : -1));

                npc.velocity = Vector2.Zero;
                npc.position = (target.Center + nodePosition.RotatedBy(radians));

                // At node
                if (vectorToNode.Length() < dashNodeActivationRadius || (railSpeed * CurrentFrame > 90))
                {
                    Destroy();
                }
            }
        }

        //public class Laser : State
        //{
        //    protected override void OnUpdate(ModNPC modNPC)
        //    {
        //        if (AITimer == 1)
        //        {
        //            AIFrameOffset = 1;
        //        }

        //        // Move above player head moving slow to follow distance
        //        float speed = 0.1f;
        //        AINodePosition = -Vector2.UnitY * followDistance;
        //        Vector2 vectorToNode = AINodePosition + player.Center - npc.Center;
        //        npc.velocity = vectorToNode * speed;

        //        // Spawn defence drones
        //        if (AITimer == 1 || AITimer % 1800 == 0)
        //        {
        //            int amountDrones = 8;
        //            for (var i = 0; i < amountDrones; i++)
        //            {
        //                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.AncientOblivionCannon>(), 0, npc.whoAmI);
        //            }
        //        }

        //        // Sweep laser
        //        if (AITimer % 600 == 0)
        //        {
        //            AITargetedPosition = player.Center;
        //        }
        //        break;
        //        base.OnUpdate(modNPC);
        //    }
        //}
    }
}