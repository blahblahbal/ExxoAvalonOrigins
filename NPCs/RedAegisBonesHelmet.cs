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
	public class RedAegisBonesHelmet : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Aegis Bones");
			Main.npcFrameCount[npc.type] = 15;
		}

		public override void SetDefaults()
		{
			npc.damage = 120;
			npc.lifeMax = 3100;
			npc.defense = 67;
			npc.width = 18;
			npc.aiStyle = 3;
			npc.value = 10000f;
			npc.height = 40;
			npc.knockBackResist = 0.2f;
			npc.HitSound = SoundID.NPCHit2;
	        npc.DeathSound = SoundID.NPCDeath2;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
            banner = npc.type;
            bannerItem = ModContent.ItemType<Items.Banners.RedAegisBonesBanner>();
        }

		public override void NPCLoot()
		{
			if (Main.rand.Next(50) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.AegisDash>(), 1, false, -2, false);
			}
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
                if (npc.velocity.X == 0f)
                {
                    if (npc.type == 140)
                    {
                        npc.frame.Y = frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    else
                    {
                        npc.frame.Y = 0;
                        npc.frameCounter = 0.0;
                    }
                }
                else
                {
                    npc.frameCounter += Math.Abs(npc.velocity.X) * 2f;
                    npc.frameCounter += 1.0;
                    if (npc.frameCounter > 6.0)
                    {
                        npc.frame.Y = npc.frame.Y + frameHeight;
                        npc.frameCounter = 0.0;
                    }
                    if (npc.frame.Y / frameHeight >= Main.npcFrameCount[npc.type])
                    {
                        npc.frame.Y = frameHeight * 2;
                    }
                }
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
        }
    }
}