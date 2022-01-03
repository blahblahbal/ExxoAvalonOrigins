﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class LargeHolybird : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Large Holybird");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.LargeHerbsStage4>();
            item.placeStyle = 10;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}