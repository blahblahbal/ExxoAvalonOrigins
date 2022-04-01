﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Crafting
{
    class LibraryAltar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Library Altar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.LibraryAltar>();
            Item.rare = ItemRarityID.Blue;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}
