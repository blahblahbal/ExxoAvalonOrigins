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
	public class GolemSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golem Slime");
			Main.npcFrameCount[npc.type] = 2;
		}

		public override void SetDefaults()
		{
			npc.damage = 62;
			npc.lifeMax = 1000;
			npc.boss = true;
			npc.defense = 50;
			npc.width = 36;
			npc.aiStyle = 1;
			npc.value = 0f;
			npc.knockBackResist = 0.2f;
			npc.height = 24;
			npc.HitSound = SoundID.NPCHit1;
	        npc.DeathSound = SoundID.NPCDeath1;
		}
	}
}