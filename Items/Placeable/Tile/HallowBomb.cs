﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
    class HallowBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallow Bomb");
            Tooltip.SetDefault("Converts tiles to the Hallow in a large radius");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.mech = true;
            item.createTile = ModContent.TileType<Tiles.BiomeBombs>();
            item.placeStyle = 6;
            item.consumable = true;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }
}
