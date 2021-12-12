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
	public class Pigron : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pigron");
			Main.npcFrameCount[npc.type] = 14;
		}

		public override void SetDefaults()
		{
			npc.damage = 70;
			npc.lifeMax = 230;
			npc.defense = 16;
			npc.width = 44;
			npc.aiStyle = 2;
			npc.value = 2000f;
			npc.height = 36;
			npc.knockBackResist = 0.5f;
            npc.HitSound = SoundID.NPCHit27;
	        npc.DeathSound = SoundID.NPCDeath30;
			npc.buffImmune[BuffID.Confused] = true;
		}
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.55f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.8f);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            npc.frameCounter += 1.0;
            if (npc.frameCounter >= 4.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * 14)
            {
                npc.frame.Y = 0;
            }
        }
    }
}