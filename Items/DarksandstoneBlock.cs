﻿using Microsoft.Xna.Framework;
    class DarksandstoneBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darksandstone Block");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/DarksandstoneBlock");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.Darksandstone>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = 1;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }