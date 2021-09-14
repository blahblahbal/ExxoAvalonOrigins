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
	public class DarkInferno : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dark Inferno");
			Description.SetDefault("Losing life");
			Main.debuff[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int k)
		{
				player.GetModPlayer<ExxoAvalonOriginsModPlayer>().darkInferno = true;
		}
	}
}