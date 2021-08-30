using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class PoisonDartFrog : ModNPC
	{
        bool jump = false;

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
		}

        public override void AI()
        {
            npc.ai[1]++;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            npc.spriteDirection = npc.direction;
            if (npc.ai[1] == 1)
            {
                npc.ai[0] = 0;
            }
            int jumpType = 0;
            if (npc.ai[2] == 0)
            {
                jumpType = Main.rand.Next(2);
                npc.ai[2] = 1;
            }
            float verticalMovementSpeed = jumpType == 0 ? -5f : -8f;
            float horizontalMovementSpeedFactor = 12f;
            if (Vector2.Distance(npc.position, Main.player[npc.target].position) < 16 * 10)
            {
                verticalMovementSpeed = jumpType == 0 ? -7f : -10f;
                horizontalMovementSpeedFactor = 5f;
            }
            if (npc.collideX)
            {
                verticalMovementSpeed *= 2;
            }
            if (npc.ai[1] >= 150)
            {
                npc.ai[0] = 1;
                npc.velocity.Y = verticalMovementSpeed;
                if (npc.ai[1] > 160)
                {
                    npc.velocity.X += horizontalMovementSpeedFactor * npc.direction;
                    npc.ai[1] = 0;
                    npc.ai[2] = 0;
                }
            }
            

            if (npc.collideY && npc.velocity.Y >= 0 && ExxoAvalonOriginsCollisions.SolidCollisionArma(npc.position, npc.width, npc.height))
            {
                npc.velocity.X *= 0.7f;
                if (npc.velocity.X > -0.5 && npc.velocity.X < 0.5)
                {
                    npc.velocity.X = 0f;
                    //npc.ai[0] = 0;
                }
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
                if (npc.ai[0] == 0)
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