﻿using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class Virus : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Viris");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.damage = 40;
			npc.lifeMax = 300;
			npc.defense = 12;
			npc.noGravity = true;
			npc.width = 56;
			npc.aiStyle = 22;
			npc.npcSlots = 1f;
			npc.value = 610f;
			npc.height = 58;
            npc.scale = 0.6f;
			npc.knockBackResist = 0.2f;
            npc.HitSound = SoundID.NPCHit18;
	        npc.DeathSound = SoundID.NPCDeath21;
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f);
            npc.damage = (int)(npc.damage * 0.7f);
        }
        public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Pathogen>(), 2 + Main.rand.Next(4), false, 0, false);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 8.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/VirusTail"), 0.6f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/VirusLimb"), 0.6f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/VirusLimb"), 0.6f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/VirusLimb"), 0.6f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/VirusLimb"), 0.6f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/VirusHead"), 0.6f);
                Gore.NewGore(npc.position, npc.velocity * 0.8f, mod.GetGoreSlot("Gores/VirusHair"), 0.6f);
            }
        }
    }
}
