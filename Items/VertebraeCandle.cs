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
	class VertebraeCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vertebrae Candle");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/VertebraeCandle");
			item.autoReuse = true;
			item.noWet = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.VertebraeCandle>();
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 99;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}