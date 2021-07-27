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
	public class DarkMotherSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Mother Slime");
			Main.npcFrameCount[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.damage = 95;
			npc.lifeMax = 600;
			npc.defense = 26;
			npc.width = 60;
			npc.aiStyle = 1;
			npc.value = 0f;
			npc.height = 42;
			npc.knockBackResist = 0.3f;
			npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Confused] = true;
		}

		public override void NPCLoot()
		{
			for (var k = 0; k < 2; k++)
			{
				if (NPC.AnyNPCs(ModContent.NPCType<ArmageddonSlime>()))
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.DarkMatterSlime>(), 0);
				}
				else
				{
					NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<NPCs.DarkMatterSlime>(), 0);
				}
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