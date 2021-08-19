﻿using Microsoft.Xna.Framework;

namespace ExxoAvalonOrigins.Items
{
    public class OutpostKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Outpost Key");
            Tooltip.SetDefault("Opens the Tuhrtl Outpost door");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/OutpostKey");
            item.maxStack = 999;
            item.width = dims.Width;
            item.value = 0;
            item.height = dims.Height;
            item.rare = 7;
        }
    }
}