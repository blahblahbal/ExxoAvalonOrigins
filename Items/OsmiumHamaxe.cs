﻿using Microsoft.Xna.Framework;
    class OsmiumHamaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Osmium Hamaxe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/OsmiumHamaxe");
            item.damage = 19;
            item.autoReuse = true;
            item.hammer = 70;
            item.useTurn = true;
            item.scale = 1.3f;
            item.axe = 20;
            item.crit += 5;
            item.rare = 3;
            item.width = dims.Width;
            item.useTime = 14;
            item.knockBack = 2.2f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 50000;
            item.useAnimation = 14;
            item.height = dims.Height;
        }
    }