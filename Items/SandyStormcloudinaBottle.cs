using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class SandyStormcloudinaBottle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sandy Stormcloud in a Bottle");
			Tooltip.SetDefault("The holder can quadruple jump");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SandyStormcloudinaBottle");
			item.rare = 3;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 3, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.doubleJumpSandstorm = true;
            player.doubleJumpCloud = true;
            player.doubleJumpBlizzard = true;
		}
	}
}