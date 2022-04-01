﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
    class SweetstemSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sweetstem Seeds");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Herbs.Sweetstem>();
            Item.placeStyle = 0;
            Item.width = dims.Width;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = 999;
            Item.value = 120;
            Item.useAnimation = 15;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(2).AddIngredient(ItemID.Hive, 5).AddIngredient(ItemID.Stinger).AddIngredient(ItemID.Seed, 8).AddTile(ModContent.TileType<Tiles.SeedFabricator>()).Register();
        }
    }
}
