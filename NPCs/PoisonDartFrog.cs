using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class PoisonDartFrog : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Dart Frog");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.damage = 65;
            npc.scale = 1f;
            npc.lifeMax = 500;
            npc.defense = 20;
            npc.width = 22;
            npc.aiStyle = -1;
            npc.npcSlots = 1f;
            npc.value = 0f;
            npc.timeLeft = 750;
            npc.height = 22;
            npc.knockBackResist = 0.2f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.CursedInferno] = true;
            AIInJump = true;
        }

        private const int AISlotFrame = 0;
        private const int AISlotTimer = 1;
        private const int AISlotInJump = 2;

        public float AIFrame
        {
            get => npc.ai[AISlotFrame];
            set => npc.ai[AISlotFrame] = value;
        }

        public float AITimer
        {
            get => npc.ai[AISlotTimer];
            set => npc.ai[AISlotTimer] = value;
        }

        public bool AIInJump
        {
            get => npc.ai[AISlotInJump] == 1;
            set => npc.ai[AISlotInJump] = value ? 1 : 0;
        }

        public override void AI()
        {
            AITimer++;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            npc.spriteDirection = npc.direction;

            if (AITimer == 1)
            {
                AIFrame = 0;
            }

            // Ready to jump
            if (AITimer >= 150)
            {
                int jumpType = Main.rand.Next(2);

                float speedY = jumpType == 0 ? -5f : -8f;
                float speedX = 12f;

                if (Vector2.Distance(npc.position, Main.player[npc.target].position) < 16 * 10)
                {
                    speedY = jumpType == 0 ? -7f : -10f;
                    speedX = 5f;
                }

                if (npc.collideX)
                {
                    speedY *= 2;
                }

                AIFrame = 1;
                npc.velocity.Y = speedY;
                npc.velocity.X += speedX * npc.direction;
                AITimer = 0;
                AIInJump = true;
            }

            if (AIInJump && npc.velocity.X == 0)
            {
                float speedX = 12f;
                if (Vector2.Distance(npc.position, Main.player[npc.target].position) < 16 * 10)
                {
                    speedX = 5f;
                }

                npc.velocity.X += speedX * npc.direction;
            }

            if (npc.collideY && npc.velocity.Y >= 0 && ExxoAvalonOriginsCollisions.SolidCollisionArma(npc.position, npc.width, npc.height))
            {
                npc.velocity.X *= 0.7f;
                if (npc.velocity.X > -0.5 && npc.velocity.X < 0.5)
                {
                    npc.velocity.X = 0f;
                    //AIFrame = 0;
                }
                AIInJump = false;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (ExxoAvalonOriginsCollisions.SolidCollisionArma(npc.position, npc.width, npc.height))
            {
                npc.frame.Y = 0;
            }
            else
            {
                if (AIFrame == 0)
                {
                    npc.frame.Y = frameHeight * 1;
                }
                else npc.frame.Y = frameHeight * 2;
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneTropics && Main.hardMode ? 0.083f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}