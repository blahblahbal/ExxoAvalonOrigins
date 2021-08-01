﻿using Microsoft.Xna.Framework;
    class HardenedSnotsandBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hardened Snotsand Block");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/HardenedSnotsandBlock");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.HardenedSnotsand>();
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 10;
            item.useStyle = 1;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }