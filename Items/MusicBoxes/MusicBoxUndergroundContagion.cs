﻿using Microsoft.Xna.Framework;
    class MusicBoxUndergroundContagion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Underground Contagion)");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/MusicBoxes/MusicBoxUndergroundContagion");
            item.autoReuse = true;
            item.useTurn = true;
            item.maxStack = 999;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.MusicBoxes>();
            item.placeStyle = 4;
            item.rare = 4;
            item.width = dims.Width;
            item.useTime = 10;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.useStyle = 1;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }