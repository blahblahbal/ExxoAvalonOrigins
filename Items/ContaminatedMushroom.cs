﻿using Microsoft.Xna.Framework;
    class ContaminatedMushroom : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contaminated Mushroom");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ContaminatedMushroom");
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 50;
            item.height = dims.Height;
        }
    }