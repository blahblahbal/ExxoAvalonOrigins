﻿using Microsoft.Xna.Framework;
    class TropicalMudBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tropical Mud Block");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/TropicalMudBlock");
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.TropicalMud>();
            item.width = dims.Width;
            item.useTime = 10;
            item.useTurn = true;
            item.useStyle = 1;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
    }