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

            mainState = new MainState(this);
        }

        private const int AISlotFrameOffset = 0;
        public int AIFrameOffset
        {
            get => (int)npc.ai[AISlotFrameOffset];
            set => npc.ai[AISlotFrameOffset] = value;
        }

        private BitsByte AINetworkOptimisedBooleans = new BitsByte();

        public override string[] AltTextures => new string[] { ExxoAvalonOrigins.mod.Name + "/NPCs/Bosses/OblivionPhase1Shadow" };


        private MainState mainState;

        public override void AI()
        {
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
            if (Main.netMode != NetmodeID.Server && Filters.Scene["OblivionDarkenScreen"].IsActive()) // This all needs to happen client-side!
            {
                Filters.Scene["OblivionDarkenScreen"].Deactivate();
                Main.npcTexture[npc.type] = ExxoAvalonOrigins.mod.GetTexture("NPCs/Bosses/OblivionPhase1");
            }
        }

        private class MainState : StateParent
        {
            private bool inStage;
            private bool firstRun;
            private float finishedFrame;
            private OblivionPhase1 oblivionPhase1;

            public MainState(OblivionPhase1 oblivionPhase1, Action destroyAction = null) : base(oblivionPhase1, destroyAction)
            {
                this.oblivionPhase1 = oblivionPhase1;
            }

            protected override void PostStart()
            {
                inStage = false;
                firstRun = true;
            }

            protected override void PostUpdate()
            {
                FindTarget();
                LookAtTarget();

                if (npc.life > npc.lifeMax * 3 / 4)
                {
                    if (firstRun || (!inStage && currentFrame - finishedFrame == 1))
                    {
                        firstRun = false;
                        states.Add(new DashState(modNPC, delegate
                        {
                            inStage = false;
                            finishedFrame = currentFrame;
                        }));
                    }
                }
                else if (npc.life > npc.lifeMax / 3)
                {
                    oblivionPhase1.AIFrameOffset = 1;
                }
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
            public DashState(ModNPC modNPC, Action destroyAction = null) : base(modNPC, destroyAction)
            {
            }

            protected override void PostStart()
            {
                states.Add(new FlurryDash(modNPC, delegate
                {
                    states.Add(new Stalk(modNPC, delegate
                    {
                        states.Add(new XDash(modNPC, delegate
                        {
                            Destroy();
                        }));
                    }));
                }));
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

            public FlurryDash(ModNPC modNPC, Action destroyAction = null) : base(modNPC, destroyAction)
            {
                remainingDashes = 4;
                remainingFlurryDashes = 5;
            }

            protected override void PostStart()
            {
                remainingFlurryDashes--;
                nodePosition = (unitVectorToTarget * dashDistance).RotatedByRandom(Math.PI / 2);
                targetedPosition = modNPC.npc.Center;
            }

            protected override void PostUpdate()
            {
                Vector2 unitVectorToNode = nodePosition.SafeNormalize(Vector2.UnitX);

                if (Main.netMode != NetmodeID.MultiplayerClient && remainingFlurryDashes <= 0)
                {
                    if (remainingDashes > 0)
                    {
                        if (currentFrame == 1)
                        {
                            Projectile.NewProjectile(npc.Center + unitVectorToNode * Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2, unitVectorToTarget * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFireball>(), 25, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    else
                    {
                        if (currentFrame < 5)
                        {
                            Projectile.NewProjectile(npc.Center + unitVectorToNode * Main.npcTexture[npc.type].Height / Main.npcFrameCount[npc.type] / 2, unitVectorToTarget * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFlamethrower>(), 30, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }

                Vector2 vectorToNode = targetedPosition + nodePosition - npc.Center;
                npc.velocity = vectorToNode * speed;

                if (vectorToNode.Length() < dashNodeActivationRadius)
                {
                    if (remainingFlurryDashes > 0)
                    {
                        Start();
                    }
                    else
                    {
                        if (remainingDashes > 0)
                        {
                            remainingDashes--;
                            remainingFlurryDashes = 5;
                            Start();
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

            public Stalk(ModNPC modNPC, Action destroyAction = null) : base(modNPC, destroyAction)
            {
            }

            protected override void PostStart()
            {
                if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                {
                    Color tintColor = new Color(80, 0, 120);
                    Filters.Scene.Activate(Effects.Effects.SceneKeyOblivionDarkenScreen).GetShader().UseColor(tintColor);
                    modNPC.npc.altTexture = 1;
                }
                stalkRotation = (float)Math.Atan2(unitVectorToTarget.Y, unitVectorToTarget.X);
            }

            protected override void PostUpdate()
            {
                float speed = 0.05f;

                // Every n seconds, change stalk rotation, ensuring rotation is atleast a 45 degree difference to the current rotation
                if (currentFrame % 45 == 0)
                {
                    stalkRotation += (float)((Main.rand.NextFloat() * Math.PI * 6 / 4) + Math.PI / 4);
                    stalkRotation %= (float)(Math.PI * 2);
                    npc.alpha = 255;
                    npc.position = target.Center + Vector2.UnitY.RotatedBy(stalkRotation) * vectorToTarget.Length();
                }

                // Fade back alpha
                if (npc.alpha > 0)
                {
                    npc.alpha -= 7;
                }

                // Go to target position relative to player
                Vector2 targetPosition = target.Center + Vector2.UnitY.RotatedBy(stalkRotation) * followDistance;
                npc.velocity = target.velocity + (targetPosition - npc.Center) * speed;

                if (currentFrame > 250)
                {
                    Destroy();
                }
            }

            protected override void PreDestroy()
            {
                if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
                {
                    Filters.Scene[Effects.Effects.SceneKeyOblivionDarkenScreen].Deactivate();
                    modNPC.npc.altTexture = 0;
                }
                modNPC.npc.alpha = 0;
            }
        }

        public class XDash : StateParent
        {
            private bool inDash;
            private Vector2 nodePosition;
            private Vector2 targetedPosition;
            private int remainingDashes;
            private float dashNodeRadius = 16f * 45f;
            private readonly float dashNodeActivationRadius = 16f;

            public XDash(ModNPC modNPC, Action destroyAction = null) : base(modNPC, destroyAction)
            {
            }

            protected override void PostStart()
            {
                inDash = true;
                remainingDashes = 3;

                FindInitialNode();

                states.Add(new XDashToNodeSlow(modNPC, nodePosition, targetedPosition, true, delegate
                {
                    FindNextDashNode();
                    states.Add(new XDashToNode(modNPC, nodePosition, targetedPosition, false, delegate
                    {
                        remainingDashes--;
                        inDash = false;
                    }));
                }));
            }

            protected override void PostUpdate()
            {
                if (!inDash)
                {
                    inDash = true;
                    if (remainingDashes > 0)
                    {
                        states.Add(new XDashToNodeSlow(modNPC, nodePosition, targetedPosition, true, delegate
                        {
                            FindNextCircleToNode();
                            states.Add(new XDashCircleToNode(modNPC, nodePosition, targetedPosition, true, delegate
                            {
                                FindNextDashNode();
                                states.Add(new XDashToNode(modNPC, nodePosition, targetedPosition, false, delegate
                                {
                                    remainingDashes--;
                                    inDash = false;
                                }));
                            }));
                        }));
                    }
                    else
                    {
                        Destroy();
                    }
                }
                base.PostUpdate();
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

            public XDashToNodeSlow(ModNPC modNPC, Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget, Action destroyAction = null) : base(modNPC, destroyAction)
            {
                this.nodePosition = nodePosition;
                this.targetedPosition = targetedPosition;
                this.relativeToTarget = relativeToTarget;
            }

            protected override void PostUpdate()
            {
                NPC npc = modNPC.npc;

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

            public XDashToNode(ModNPC modNPC, Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget, Action destroyAction = null) : base(modNPC, destroyAction)
            {
                this.nodePosition = nodePosition;
                this.targetedPosition = targetedPosition;
                this.relativeToTarget = relativeToTarget;
            }

            protected override void PostUpdate()
            {
                if (currentFrame < 15)
                {
                    return;
                }

                if (currentFrame == 15)
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

            public XDashCircleToNode(ModNPC modNPC, Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget, Action destroyAction = null) : base(modNPC, destroyAction)
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

                float radians = MathHelper.ToRadians((90 - (railSpeed * currentFrame)) * (clockWise ? 1 : -1));

                npc.velocity = Vector2.Zero;
                npc.position = (target.Center + nodePosition.RotatedBy(radians));

                // At node
                if (vectorToNode.Length() < dashNodeActivationRadius || (railSpeed * currentFrame > 90))
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