﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class SkyBrick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sky Brick");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.SkyBrick>();
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = 0;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}