﻿using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class Holybird : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holybird");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.width = dims.Width;
            item.maxStack = 999;
            item.value = 100;
            item.height = dims.Height;
        }
    }
}
