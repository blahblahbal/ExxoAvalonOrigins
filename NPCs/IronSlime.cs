﻿using Microsoft.Xna.Framework;
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
	public class IronSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.damage = 15;
			npc.lifeMax = 253;
			npc.defense = 10;
			npc.width = 36;
			npc.aiStyle = 1;
			npc.value = 1000f;
			npc.knockBackResist = 0.4f;
			npc.height = 24;
            npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.IronSlimeBanner>();
        }

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.IronOre, Main.rand.Next(15, 25), false, 0, false);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f);
            npc.damage = (int)(npc.damage * 0.45f);
        }
        public override void FindFrame(int frameHeight)
        {
            var num2 = 0;
            if (npc.aiAction == 0)
            {
                if (npc.velocity.Y < 0f)
                {
                    num2 = 2;
                }
                else if (npc.velocity.Y > 0f)
                {
                    num2 = 3;
                }
                else if (npc.velocity.X != 0f)
                {
                    num2 = 1;
                }
                else
                {
                    num2 = 0;
                }
            }
            else if (npc.aiAction == 1)
            {
                num2 = 4;
            }
            npc.frameCounter += 1.0;
            if (num2 > 0)
            {
                npc.frameCounter += 1.0;
            }
            if (num2 == 4)
            {
                npc.frameCounter += 1.0;
            }
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
            return spawnInfo.player.ZoneRockLayerHeight && !spawnInfo.player.ZoneDungeon && (Main.hardMode || WorldGen.IronTierOre == TileID.Iron) ? 0.00526f * ExxoAvalonOriginsGlobalNPC.endoSpawnRate : 0f;
        }
    }
}
