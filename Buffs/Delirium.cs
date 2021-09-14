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
	public class Delirium : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Curse of Delirium");
			Description.SetDefault("Experiencing random bouts of confusion");
			Main.debuff[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int k)
		{
				if (Main.rand.Next(600) == 0)
				{
					player.GetModPlayer<ExxoAvalonOriginsModPlayer>().deliriumCount = Main.rand.Next(240, 481);
				}
				if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().deliriumCount > 0)
				{
					player.confused = true;
					player.GetModPlayer<ExxoAvalonOriginsModPlayer>().deliriumCount--;
				}
		}
	}
}