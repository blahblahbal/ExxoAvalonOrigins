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
	public class DarkMatterSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.damage = 100;
			npc.lifeMax = 760;
			npc.defense = 30;
			npc.width = 32;
			npc.aiStyle = 1;
			npc.scale = 1.4f;
			npc.value = 1000f;
			npc.height = 24;
			npc.knockBackResist = 0.1f;
			npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.DarkMatterSlimeBanner>();
        }

		public override void NPCLoot()
		{
            bool canDrop = true;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC scannedNPC = Main.npc[i];
                if (scannedNPC.type == ModContent.NPCType<NPCs.ArmageddonSlime>())
                {
                    if (Vector2.Distance(npc.Center, scannedNPC.Center) < 5000)
                    {
                        canDrop = false;
                        npc.value = 0;
                    }
                }
            }

			if (Main.rand.Next(75) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.SixHundredWattLightbulb>(), 1, false, -2, false);
			}
			if (npc.type == ModContent.NPCType<NPCs.DarkMatterSlime>() && canDrop)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.DarkMatterGel>(), Main.rand.Next(2) + 2, false, 0, false);
			}
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