using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Material;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class BloodshotEye : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodshot Eye");
			Main.npcFrameCount[npc.type] = 3;
		}

		public override void SetDefaults()
		{
			npc.damage = 25;
			npc.lifeMax = 110;
			npc.defense = 5;
			npc.width = 48;
			npc.aiStyle = 2;
			npc.value = 150f;
			npc.height = 34;
			npc.knockBackResist = 0.4f;
			npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath6;
			npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.BloodshotEyeBanner>();
        }

		public override void NPCLoot()
		{
			if (Main.rand.Next(100) <= 45)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BloodshotLens>(), 1, false, 0, false);
			}
			if (Main.rand.Next(33) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.BlackLens, 1, false, 0, false);
			}
			if (npc.life <= 0)
			{
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodshotEye1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/BloodshotEye2"), 1f);
			}
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X > 0f)
            {
                npc.spriteDirection = 1;
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
            }
            if (npc.velocity.X < 0f)
            {
                npc.spriteDirection = -1;
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 3.14f;
            }
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

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.bloodMoon ? 0.091f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
