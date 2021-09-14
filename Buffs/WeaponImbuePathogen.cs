using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Buffs
{
	public class WeaponImbuePathogen : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Weapon Imbue: Infection");
			Description.SetDefault("Melee attacks inflict Infected on your targets");
		}

		public override void Update(Player player, ref int k)
		{
				player.meleeEnchant = 9;
		}
	}
}