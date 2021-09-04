using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class FallenHero : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fallen Hero");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 30;
			npc.lifeMax = 180;
			npc.defense = 6;
			npc.width = 18;
			npc.aiStyle = 3;
			npc.value = 10000f;
			npc.height = 40;
			npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath2;
			npc.buffImmune[BuffID.Confused] = true;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.Y == 0f)
            {
                if (npc.direction == 1)
                {
                    npc.spriteDirection = 1;
                }
                if (npc.direction == -1)
                {
                    npc.spriteDirection = -1;
                }
            }
            if (npc.velocity.Y != 0f || (npc.direction == -1 && npc.velocity.X > 0f) || (npc.direction == 1 && npc.velocity.X < 0f))
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = frameHeight * 2;
            }
            else if (npc.velocity.X == 0f)
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
            else
            {
                npc.frameCounter += Math.Abs(npc.velocity.X);
                if (npc.frameCounter < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if (npc.frameCounter < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (npc.frameCounter < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (npc.frameCounter < 32.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else
                {
                    npc.frameCounter = 0.0;
                }
            }
        }
        public override void NPCLoot()
        {
            if (Main.rand.Next(18) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.BloodstainedHelmet>(), 1, false, 0, false);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneOverworldHeight && !spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().InPillarZone() && Main.bloodMoon ? 0.055f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}