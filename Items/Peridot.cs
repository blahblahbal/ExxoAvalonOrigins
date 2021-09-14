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
	class Peridot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Peridot");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Peridot");
			item.autoReuse = true;
			item.useTurn = true;
			item.maxStack = 999;
			item.createTile = ModContent.TileType<Tiles.PlacedGems>();
			item.placeStyle = 4;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 10;
			item.value = 4000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}