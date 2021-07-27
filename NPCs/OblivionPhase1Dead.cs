using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
	public class OblivionPhase1Dead : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Oblivion");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.damage = 0;
			npc.noTileCollide = false;
			npc.dontTakeDamage = true;
			npc.lifeMax = 1;
			npc.defense = 0;
			npc.noGravity = false;
			npc.width = 48;
			npc.aiStyle = -1;
			npc.npcSlots = 1f;
			npc.value = 0f;
			npc.timeLeft = 750;
			npc.height = 26;
			npc.knockBackResist = 0f;
		}

        public override void AI()
        {
            npc.life = 1;
            npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth++;
            if (npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth == 300)
            {
                npc.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().oRebirth = 0;
                npc.life = 0;
                npc.active = false;
                npc.NPCLoot();
                return;
            }
            return;
        }

        public override void NPCLoot()
        {
            NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<OblivionHead1>(), 0);
            Main.NewText("Oblivion has been reborn!", 175, 75, 255, false);
            if (Main.netMode == 2)
            {
                NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("Oblivion has been reborn!"), 255, 175f, 75f, 255f, 0);
            }
        }
    }
}