using System;
using System.Collections.Generic;
using System.IO;
using ExxoAvalonOrigins.NPCs.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.NPCs.Bosses.Oblivion;

public class OblivionPhase1 : AdvancedModNPC<OblivionPhase1.MainState>
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Oblivion (WIP)");
        Main.npcFrameCount[NPC.type] = 6;
    }

    public override void SetDefaults()
    {
        NPC.damage = 150;
        NPC.boss = true;
        NPC.netAlways = true;
        NPC.noTileCollide = true;
        NPC.lifeMax = 85000;
        NPC.defense = 50;
        NPC.noGravity = true;
        NPC.width = 110;
        NPC.aiStyle = -1;
        NPC.npcSlots = 6f;
        NPC.value = 50000f;
        NPC.timeLeft = 22500;
        NPC.height = 152;
        NPC.knockBackResist = 0f;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath14;
        NPC.buffImmune[BuffID.Frostburn] = true;
    }

    private const int AISlotFrameOffset = 0;

    public int AIFrameOffset
    {
        get => (int)NPC.ai[AISlotFrameOffset];
        set
        {
            NPC.ai[AISlotFrameOffset] = value;
            switch (value)
            {
                case 1:
                    NPC.HitSound = SoundID.NPCHit4;
                    break;
                default:
                    NPC.HitSound = SoundID.NPCHit1;
                    break;
            }
        }
    }

    public override string[] AltTextures => new string[]
    {
        Texture + "_Shadow"
    };

    public override void FindFrame(int frameHeight)
    {
        NPC.frameCounter++;
        NPC.frameCounter %= 21;
        NPC.frame.Y = frameHeight * (int)(NPC.frameCounter / 7);
        NPC.frame.Y += frameHeight * 3 * AIFrameOffset;
    }

    public class MainState : StateParent
    {
        protected override bool AutoDestroyOnFinish => false;
        private const byte TreeDashStage = 0;
        private const byte TreeLaserStage = 1;

        protected override void InactiveUpdate()
        {
            if (npc.life > npc.lifeMax * 3 / 4)
            {
                StartTree(TreeDashStage);
            }
            else if (npc.life > npc.lifeMax / 3)
            {
                StartTree(TreeLaserStage);
            }
        }

        protected override void HandleAdvanceState(bool isNewState)
        {
            switch (TreeID)
            {
                case TreeDashStage:
                    HandleDashStageTree();
                    break;

                case TreeLaserStage:
                    HandleLaserStageTree();
                    break;
            }
        }

        private void HandleDashStageTree()
        {
            switch (StatePosition)
            {
                case 0:
                    SetState(new DashState());
                    break;
            }
        }

        private void HandleLaserStageTree()
        {
            switch (StatePosition)
            {
                case 0:
                    SetState(new LaserState());
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
        protected override bool AutoDestroyOnFinish => true;

        protected override void Start()
        {
            StartTree(0);
        }

        protected override void HandleAdvanceState(bool isNewState)
        {
            switch (StatePosition)
            {
                case 0:
                    SetState(new FlurryDash(8, 25, CubicEase.Out), 4);
                    break;

                case 1:
                    SetState(new Stalk(250));
                    break;

                case 2:
                    SetState(new XDash(3));
                    break;
            }
        }
    }

    public class FlurryDash : State
    {
        private readonly float dashDistance = 8 * 16f;
        private readonly float projectileSpeed = 25f;
        private readonly uint dashFrameDuration;
        private readonly Func<float, float> easeFunction;

        private uint remainingDashes;
        private Vector2 nodePosition;
        private Vector2Tween movementTween;

        public FlurryDash(uint dashes, uint dashFrameDuration, Func<float, float> easeFunction)
        {
            remainingDashes = dashes;
            this.dashFrameDuration = dashFrameDuration;
            this.easeFunction = easeFunction;
        }

        public override void PostDraw(SpriteBatch spriteBatch)
        {
            if (movementTween != null)
            {
                Utils.Debug.DrawIndicator(spriteBatch, movementTween.EndPosition);
            }
        }

        public override void Write(BinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(remainingDashes);
            movementTween.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            base.Read(reader);
            remainingDashes = reader.ReadUInt32();
            movementTween = new Vector2Tween(dashFrameDuration, easeFunction, Vector2.Zero, Vector2.Zero);
            movementTween.Read(reader);
        }

        protected override void Start()
        {
            remainingDashes--;

            nodePosition = (unitVectorToTarget * dashDistance).RotatedBy(syncedRandom.NextDouble() * Math.PI * 2);
            //nodePosition = (unitVectorToTarget * dashDistance).RotatedBy((syncedRandom.NextDouble() * Math.PI / 2) - (Math.PI / 4));
            movementTween = new Vector2Tween(dashFrameDuration, easeFunction, npc.Center, target.Center + nodePosition);
        }

        protected override void Update()
        {
            // Fire shot
            if (Main.netMode != NetmodeID.MultiplayerClient && remainingDashes <= 0)
            {
                Vector2 unitVectorToNode = nodePosition.SafeNormalize(Vector2.UnitX);

                if (Parent.RepeatTimes > 0)
                {
                    if (CurrentFrame == 1)
                    {
                        Projectile.NewProjectile(npc.Center + (unitVectorToNode * npc.height / 2), unitVectorToTarget * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFireball>(), 25, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                else
                {
                    if (CurrentFrame < 5)
                    {
                        Projectile.NewProjectile(npc.Center + (unitVectorToNode * npc.height / 2), unitVectorToTarget * projectileSpeed, ModContent.ProjectileType<Projectiles.DarkMatterFlamethrower>(), 30, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            npc.velocity = Vector2.Zero;
            npc.Center = movementTween.Update();

            if (movementTween.Finished)
            {
                if (remainingDashes > 0)
                {
                    Restart();
                }
                else
                {
                    Destroy();
                }
            }
        }
    }

    public class Stalk : State
    {
        private readonly float followDistance = 16f * 15f;
        private readonly Color tintColor = new Color(80, 0, 120);
        private readonly uint duration;
        private readonly uint tweenFrameDuration = 40;
        private readonly Func<float, float> tweenFunction = CubicEase.Out;
        private float stalkRotation;
        private Vector2Tween movementTween;

        public Stalk(uint duration)
        {
            this.duration = duration;
        }

        protected override void Start()
        {
            stalkRotation = npc.rotation;
            movementTween = new Vector2Tween(tweenFrameDuration, tweenFunction, npc.Center - target.Center, Vector2.UnitY.RotatedBy(stalkRotation) * followDistance);
        }

        public override void Write(BinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(stalkRotation);
            movementTween.Write(writer);
        }

        public override void Read(BinaryReader reader)
        {
            base.Read(reader);
            stalkRotation = reader.ReadSingle();
            movementTween = new Vector2Tween(tweenFrameDuration, tweenFunction, Vector2.Zero, Vector2.Zero);
            movementTween.Read(reader);
        }

        public override void PostDraw(SpriteBatch spriteBatch)
        {
            Texture2D texture = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("NPCs/Bosses/Oblivion/OblivionPhase1_Shadow_Glow").Value;
            spriteBatch.Draw
            (
                texture,
                npc.Center - Main.screenPosition,
                npc.frame,
                Color.White * (1 - (npc.alpha / 255f)),
                npc.rotation,
                ModNPC.
                    NPC.frame.Size() * 0.5f,
                npc.scale,
                SpriteEffects.None,
                0f
            );
        }

        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
            {
                Filters.Scene.Activate(Effects.EffectsManager.SceneKeyOblivionDarkenScreen).GetShader().UseColor(tintColor);
                ModNPC.NPC.altTexture = 1;
            }
        }

        protected override void Update()
        {
            // Every n seconds, change stalk rotation, ensuring rotation is atleast a 45 degree difference to the current rotation
            if (CurrentFrame % 45 == 0)
            {
                stalkRotation += (float)((syncedRandom.NextDouble() * Math.PI * 6 / 4) + (Math.PI / 4));
                stalkRotation %= (float)(Math.PI * 2);
                npc.Center = target.Center + (Vector2.UnitY.RotatedBy(stalkRotation) * vectorToTarget.Length());
                movementTween = new Vector2Tween(tweenFrameDuration, tweenFunction, npc.Center - target.Center, Vector2.UnitY.RotatedBy(stalkRotation) * followDistance);
                npc.alpha = 255;
            }

            // Fade back alpha
            if (npc.alpha > 0)
            {
                npc.alpha -= 7;
            }

            npc.velocity = Vector2.Zero;
            npc.Center = target.Center + movementTween.Update();

            if (CurrentFrame > duration)
            {
                Destroy();
            }
        }

        public override void Unload()
        {
            if (Main.netMode != NetmodeID.Server) // This all needs to happen client-side!
            {
                Filters.Scene[Effects.EffectsManager.SceneKeyOblivionDarkenScreen].Deactivate();
                ModNPC.NPC.altTexture = 0;
            }
            ModNPC.NPC.alpha = 0;
        }
    }

    public class XDash : StateParent
    {
        private const float DashNodeRadius = 16f * 45f;
        private int remainingDashes;
        private Vector2 nodePosition;
        private Vector2 targetedPosition;

        public XDash(int dashes)
        {
            remainingDashes = dashes;
        }

        public override void PreWrite(BinaryWriter writer)
        {
            writer.Write(remainingDashes);
            writer.WriteVector2(nodePosition);
            writer.WriteVector2(targetedPosition);
        }

        public override void PreRead(BinaryReader reader)
        {
            remainingDashes = reader.ReadInt32();
            nodePosition = reader.ReadVector2();
            targetedPosition = reader.ReadVector2();
        }

        protected override bool AutoDestroyOnFinish => false;
        private const int TreeFirstDash = 0;
        private const int TreeNextDash = 1;

        protected override void Start()
        {
            remainingDashes--;
            StartTree(TreeFirstDash);
        }

        protected override void InactiveUpdate()
        {
            if (remainingDashes > 0)
            {
                remainingDashes--;
                StartTree(TreeNextDash);
            }
            else
            {
                Destroy();
            }
        }

        protected override void HandleAdvanceState(bool isNewState)
        {
            switch (TreeID)
            {
                case TreeFirstDash:
                    HandleFirstDashTree(isNewState);
                    break;

                case TreeNextDash:
                    HandleNextDashTree(isNewState);
                    break;
            }
        }

        private void HandleFirstDashTree(bool isNewState)
        {
            switch (StatePosition)
            {
                case 0:
                    if (isNewState)
                    {
                        FindInitialNode();
                    }
                    SetState(new Utils.States.MoveToPosition(nodePosition, 30, CubicEase.Out, true));
                    break;

                case 1:
                    if (isNewState)
                    {
                        FindNextDashNode();
                    }
                    SetState(new XDashToNode(nodePosition, 40, CubicEase.Out, targetedPosition, 15));
                    break;
            }
        }

        private void HandleNextDashTree(bool isNewState)
        {
            switch (StatePosition)
            {
                case 0:
                    SetState(new Utils.States.MoveToPosition(nodePosition, 30, CubicEase.Out, true));
                    break;

                case 1:
                    if (isNewState)
                    {
                        FindNextCircleToNode();
                    }
                    SetState(new XDashCircleToNode(nodePosition, targetedPosition, true));
                    break;

                case 2:
                    if (isNewState)
                    {
                        FindNextDashNode();
                    }
                    SetState(new XDashToNode(nodePosition, 40, CubicEase.Out, targetedPosition, 15));
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
            nodePosition = unitVectorToNode * DashNodeRadius;
        }

        private void FindNextDashNode()
        {
            targetedPosition = target.Center;
            nodePosition = unitVectorToTarget * DashNodeRadius;
        }

        private void FindNextCircleToNode()
        {
            nodePosition = new Vector2(-unitVectorToTarget.X, unitVectorToTarget.Y) * DashNodeRadius;
        }
    }

    public class XDashToNode : Utils.States.MoveToPosition
    {
        private readonly uint waitFrameDuration;
        public XDashToNode(Vector2 position, uint frameDuration, Func<float, float> easeFunction, Vector2 targetedPosition, uint waitFrameDuration) : base(position, frameDuration, easeFunction, targetedPosition)
        {
            this.waitFrameDuration = waitFrameDuration;
        }
        protected override void Update()
        {
            if (CurrentFrame < waitFrameDuration)
            {
                return;
            }

            if (CurrentFrame == waitFrameDuration)
            {
                SoundEngine.PlaySound(SoundID.ForceRoar, (int)npc.Center.X, (int)npc.Center.Y, -1);
            }

            base.Update();
        }
    }

    public class XDashCircleToNode : State
    {
        private const float RailSpeed = 2.5f;
        private const float DashNodeActivationRadius = 16f;
        private readonly bool relativeToTarget;
        private readonly Vector2 nodePosition;
        private readonly Vector2 targetedPosition;
        private readonly bool clockWise;

        public XDashCircleToNode(Vector2 nodePosition, Vector2 targetedPosition, bool relativeToTarget)
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
            float radians = MathHelper.ToRadians((90 - (RailSpeed * CurrentFrame)) * (clockWise ? 1 : -1));

            npc.velocity = Vector2.Zero;
            npc.Center = (target.Center + nodePosition.RotatedBy(radians));

            // At node
            if (vectorToNode.Length() < DashNodeActivationRadius || (RailSpeed * CurrentFrame > 90))
            {
                Destroy();
            }
        }
    }

    public class LaserState : StateParent
    {
        protected override bool AutoDestroyOnFinish => false;
        private const byte TreeSpinTransform = 0;
        private const byte TreeLaserAttack = 1;
        private const int MaxDrones = 10;
        public List<int> ActiveDrones { get; set; }
        public LaserState()
        {
            ActiveDrones = new List<int>();
        }
        protected override void Start()
        {
            StartTree(TreeSpinTransform);
        }
        protected override void PreUpdate()
        {
            Vector2 desiredPosition = (-Vector2.UnitY * 16f * 25) + target.Center;
            npc.velocity = (desiredPosition - npc.Center) * 0.1f;
        }
        protected override void InactiveUpdate()
        {
            StartTree(TreeLaserAttack);
        }
        protected override void HandleAdvanceState(bool isNewState)
        {
            switch (TreeID)
            {
                case TreeSpinTransform:
                    HandleSpinTransformTree();
                    break;
                case TreeLaserAttack:
                    HandleLaserAttackTree(isNewState);
                    break;
            }
        }

        private void HandleSpinTransformTree()
        {
            switch (StatePosition)
            {
                case 0:
                    SetState(new SpinTransform(200, (float)Math.PI * 16f));
                    break;
                case 1:
                    SetState(new Utils.States.MoveToPosition(-Vector2.UnitY * 16f * 25, 50, CubicEase.Out, true));
                    break;
            }
        }

        private void HandleLaserAttackTree(bool isNewState)
        {
            switch (StatePosition)
            {
                case 0:
                    if (isNewState)
                    {
                        CheckDrones();
                    }
                    SetState(new LaserAttack(), 6);
                    break;
            }
        }

        private void CheckDrones() // COuld use an ID check to spawn only drones who are missing from the list. I'd write it myself but my style of code would clash pretty bad
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int i = ActiveDrones.Count; i < MaxDrones; i++)
                {
                    ActiveDrones.Add(NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y,
                        ModContent.NPCType<Oblivion.ShieldDrone>(), 0,
                        npc.whoAmI, i, MaxDrones));
                }

                for (int i = 0; i < ActiveDrones.Count; i++)
                {
                    if (!Main.npc[ActiveDrones[i]].active)
                    {
                        ActiveDrones[i] = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y,
                            ModContent.NPCType<Oblivion.ShieldDrone>(), 0,
                            npc.whoAmI, i, MaxDrones);
                    }
                }
            }
        }

        protected override void PreDestroy()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                foreach (int id in ActiveDrones)
                {
                    Main.npc[id].active = false;
                }
            }
        }

        public override void Unload()
        {
            if (ModNPC is OblivionPhase1 oblivionPhase1)
            {
                oblivionPhase1.AIFrameOffset = 0;
            }
        }
    }

    public class LaserAttack : StateParent
    {
        protected override bool AutoDestroyOnFinish => true;
        protected override void Start()
        {
            StartTree(0);
        }
        protected override void HandleAdvanceState(bool isNewState)
        {
            switch (StatePosition)
            {
                case 0:
                    SetState(new ChargeLaser(180));
                    break;
                case 1:
                    SetState(new FireLaser());
                    break;
            }
        }
    }

    public class SpinTransform : State
    {
        private readonly int duration;
        private readonly float totalRotation;
        public SpinTransform(int duration, float totalRotation)
        {
            this.duration = duration;
            this.totalRotation = totalRotation;
        }
        protected override void Start()
        {
            npc.velocity = Vector2.Zero;
        }
        protected override void Update()
        {
            npc.rotation += totalRotation * CubicEase.InOut(CurrentFrame / (float)duration);

            // Transform
            if (CurrentFrame == duration / 2)
            {
                if (ModNPC is OblivionPhase1 oblivionPhase1)
                {
                    oblivionPhase1.AIFrameOffset = 1;
                }

                SoundEngine.PlaySound(SoundID.NPCHit, (int)npc.Center.X, (int)npc.Center.Y);
                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(npc.Center, new Vector2(syncedRandom.Next(-30, 31) * 0.2f, syncedRandom.Next(-30, 31) * 0.2f), 8);
                    Gore.NewGore(npc.Center, new Vector2(syncedRandom.Next(-30, 31) * 0.2f, syncedRandom.Next(-30, 31) * 0.2f), 7);
                    Gore.NewGore(npc.Center, new Vector2(syncedRandom.Next(-30, 31) * 0.2f, syncedRandom.Next(-30, 31) * 0.2f), 6);
                }
                for (int num855 = 0; num855 < 20; num855++)
                {
                    Dust.NewDust(npc.Center, npc.width, npc.height, DustID.Blood, syncedRandom.Next(-30, 31) * 0.2f, syncedRandom.Next(-30, 31) * 0.2f);
                }
                SoundEngine.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 0);
            }

            if (CurrentFrame > duration)
            {
                Destroy();
            }
        }
    }

    public class ChargeLaser : State
    {
        private readonly int duration;
        public ChargeLaser(int duration)
        {
            this.duration = duration;
        }

        protected override void Update()
        {
            if (CurrentFrame > duration)
            {
                Destroy();
            }

            if (CurrentFrame % 60 == 0)
            {
                Main.NewText("Charge Pulse");
            }
        }
    }

    public class FireLaser : State
    {
        protected override void Start()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 spinningPoint = (target.Center - npc.Center).SafeNormalize(Vector2.UnitX);
                float direction = -1f;
                if (spinningPoint.X < 0f)
                {
                    direction = 1f;
                }
                spinningPoint = spinningPoint.RotatedBy(-direction * ((float)Math.PI * 2f) / 6f);

                Projectile.NewProjectile(npc.Center, spinningPoint,
                    ModContent.ProjectileType<Projectiles.OblivionLaser>(), 50, 0f,
                    Main.myPlayer, direction * ((float)Math.PI * 2f) / 540f, npc.whoAmI);
            }
        }
        protected override void Update()
        {
            if (CurrentFrame > Projectiles.OblivionLaser.LifeTime)
            {
                Destroy();
            }
        }
    }
}