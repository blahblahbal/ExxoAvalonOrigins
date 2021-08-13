using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins
{
    public static class CanBeFrozen
    {
        public static bool CanFreeze(NPC npc)
        {
			if (!Main.hardMode)
			{
				if (npc.lifeMax <= 300 && !npc.boss && !npc.dontTakeDamage)
					return true;
				else
					return false;
			}
			else
			{
				if (ExxoAvalonOrigins.superHardmode)
				{
					if (npc.lifeMax <= 11000 && !npc.boss && !npc.dontTakeDamage)
						return true;
					else
						return false;
				}
				else
				{
					if (npc.lifeMax <= 5000 && !npc.boss && !npc.dontTakeDamage)
						return true;
					else
						return false;
				}
			}
		}
    }
}