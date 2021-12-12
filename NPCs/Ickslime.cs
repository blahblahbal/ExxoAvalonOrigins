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
	public class Ickslime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ickslime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.damage = 57;
			npc.lifeMax = 186;
			npc.defense = 30;
			npc.alpha = 55;
			npc.width = 40;
			npc.aiStyle = 1;
			npc.scale = 1.1f;
			npc.value = 400f;
			npc.height = 30;
			npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.IckslimeBanner>();
        }

		public override void NPCLoot()
		{
			if (Main.rand.Next(90) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Vitamins, 1, false, -1, false);
			}
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.65f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.45f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && !spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().InPillarZone() && Main.hardMode)
                return (spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger && !spawnInfo.player.GetModPlayer<ExxoAvalonOriginsModPlayer>().InPillarZone() && Main.hardMode) ? 0.7f : 0f;
            return 0f;
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
    }
}