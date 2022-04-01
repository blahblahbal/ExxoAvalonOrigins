﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.MusicBoxes
{
    class MusicBoxContagion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Contagion)");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Items/MusicBoxes/MusicBoxContagion");
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.MusicBoxes>();
            Item.placeStyle = 0;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
    }
}