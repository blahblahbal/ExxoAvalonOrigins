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
                mainState = new MainState(this, null);
            }
            mainState.Read(reader);
        }

        public override void AI()
        {
            if (mainState == null)
            {
                mainState = new MainState(this, null);
            }
            mainState.Update(this);
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
            private bool firstRun;

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(firstRun);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                firstRun = reader.ReadBoolean();
            }

            public override Type[] UsedTypes => new Type[] { typeof(DashState) };

            public MainState() : base() { }
            public MainState(ModNPC modNPC, StateParent parent, State nextState = null) : base(modNPC, parent, nextState)
            {
            }

            protected override void PostStart()
            {
                firstRun = true;
            }

            protected override void InactiveUpdate()
            {
                if (npc.life > npc.lifeMax * 3 / 4)
                {
                    if (firstRun || framesInactive == 1)
                    {
                        firstRun = false;
                        SetFirstState(new DashState(ModNPC, this));
                    }
                }
                else if (npc.life > npc.lifeMax / 3)
                {
                    (ModNPC as OblivionPhase1).AIFrameOffset = 1;
                }
            }

            protected override void PostUpdate()
            {
                FindTarget();
                LookAtTarget();
                base.PostUpdate();
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
            public DashState() : base() { }
            public DashState(ModNPC modNPC, StateParent parent, State nextState = null) : base(modNPC, parent, nextState)
            {
            }

            public override Type[] UsedTypes => new Type[] { typeof(FlurryDash), typeof(Stalk), typeof(XDash) };

            protected override void PostStart()
            {
                SetFirstState(new FlurryDash(ModNPC, this, new Stalk(ModNPC, this, new XDash(ModNPC, this))));
            }

            protected override void InactiveUpdate()
            {
                Destroy();
            }
        }

        public class FlurryDash : State
        {
            private readonly float dashNodeActivationRadius = 16f;
            private readonly float dashDistance = 12 * 16f;
            private readonly float speed = 0.2f;
            private readonly float projectileSpeed = 25f;
            private int remainingDashes;
            private int remainingFlurryDashes;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;

            public FlurryDash() : base() { }
            public FlurryDash(ModNPC modNPC, StateParent parent, State nextState = null) : base(modNPC, parent, nextState)
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

            protected override void PostStart()
            {
                remainingFlurryDashes--;
                float random = 0.5f;
                nodePosition = (unitVectorToTarget * dashDistance).RotatedBy((random * Math.PI / 2) - (Math.PI / 4));
                targetedPosition = ModNPC.npc.Center;
            }

            protected override void PostUpdate()
            {
                Vector2 unitVectorToNode = nodePosition.SafeNormalize(Vector2.UnitX);

                if (Main.netMode != NetmodeID.MultiplayerClient && remainingFlurryDashes <= 0)
                {
                    if (remainingDashes > 0)
                    {
                        if (CurrentFrame == 1)
                        {
                            // replace with non texutre
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
            private float stalkRotation;
            private readonly float followDistance = 16f * 15f;

            public Stalk() : base() { }
            public Stalk(ModNPC modNPC, StateParent parent, State nextState = null) : base(modNPC, parent, nextState)
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

            protected override void PostUpdate()
            {
                float speed = 0.05f;

                // Every n seconds, change stalk rotation, ensuring rotation is atleast a 45 degree difference to the current rotation
                if (CurrentFrame % 45 == 0)
                {
                    float random = 0.5f;
                    stalkRotation += (float)((random * Math.PI * 6 / 4) + Math.PI / 4);
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
            private bool firstDash;
            private int remainingDashes;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;
            private float dashNodeRadius = 16f * 45f;

            public override void Write(BinaryWriter writer)
            {
                base.Write(writer);
                writer.Write(firstDash);
                writer.Write(remainingDashes);
                writer.WriteVector2(nodePosition);
                writer.WriteVector2(targetedPosition);
            }

            public override void Read(BinaryReader reader)
            {
                base.Read(reader);
                firstDash = reader.ReadBoolean();
                remainingDashes = reader.ReadInt32();
                nodePosition = reader.ReadVector2();
                targetedPosition = reader.ReadVector2();
            }

            public XDash() : base() { }
            public XDash(ModNPC modNPC, StateParent parent, State nextState = null) : base(modNPC, parent, nextState)
            {
            }

            public override Type[] UsedTypes => new Type[] { typeof(XDashToNodeSlow), typeof(XDashToNode), typeof(XDashCircleToNode) };

            protected override void PostStart()
            {
                remainingDashes = 3;
                firstDash = true;
            }

            protected override void InactiveUpdate()
            {
                if (remainingDashes > 0)
                {
                    remainingDashes--;
                    if (firstDash)
                    {
                        FindInitialNode();
                        SetFirstState(new XDashToNodeSlow(ModNPC, this, nodePosition, targetedPosition, true));
                    }
                    else
                    {
                        SetFirstState(new XDashToNodeSlow(ModNPC, this, nodePosition, targetedPosition, true));
                    }
                }
                else
                {
                    Destroy();
                }
            }

            protected override void PreAdvanceState()
            {
                if (firstDash)
                {
                    if (statePosition == 1)
                    {
                        FindNextDashNode();
                        SetState(new XDashToNode(ModNPC, this, nodePosition, targetedPosition, false));
                    }
                    else if (statePosition == 2)
                    {
                        firstDash = false;
                    }
                }
                else
                {
                    if (statePosition == 1)
                    {
                        FindNextCircleToNode();
                        SetState(new XDashCircleToNode(ModNPC, this, nodePosition, targetedPosition, true));
                    }
                    else if (statePosition == 2)
                    {
                        FindNextDashNode();
                        SetState(new XDashToNode(ModNPC, this, nodePosition, targetedPosition, false));
                    }
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
            private readonly float speed = 0.1f;
            private readonly float minSpeed = 8f;
            private readonly float dashNodeActivationRadius = 16f;

            public XDashToNodeSlow() : base() { }
            public XDashToNodeSlow(ModNPC modNPC, StateParent parent, Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget, State nextState = null) : base(modNPC, parent, nextState)
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

            protected override void PostUpdate()
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
            private readonly float speed = 0.1f;
            private readonly float dashNodeActivationRadius = 16f;

            public XDashToNode() : base() { }
            public XDashToNode(ModNPC modNPC, StateParent parent, Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget, State nextState = null) : base(modNPC, parent, nextState)
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

            protected override void PostUpdate()
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
            private float railSpeed = 2.5f;
            private readonly float dashNodeActivationRadius = 16f;
            private bool clockWise;

            public XDashCircleToNode() : base() { }
            public XDashCircleToNode(ModNPC modNPC, StateParent parent, Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget, State nextState = null) : base(modNPC, parent, nextState)
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

            protected override void PostUpdate()
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