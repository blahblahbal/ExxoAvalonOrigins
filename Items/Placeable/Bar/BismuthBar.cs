﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Bar
{
    class BismuthBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Bar");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PlacedBars>();
            Item.placeStyle = 21;
            Item.rare = ItemRarityID.White;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Tile.BismuthOre>(), 4).AddTile(TileID.Furnaces).Register();
        }
    }
}
