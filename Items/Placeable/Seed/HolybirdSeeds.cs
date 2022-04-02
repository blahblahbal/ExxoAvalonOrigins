﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed;

class HolybirdSeeds : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Holybird Seeds");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.createTile = ModContent.TileType<Tiles.Herbs.Holybird>();
        Item.placeStyle = 0;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.value = 90;
        Item.useAnimation = 15;
        Item.height = dims.Height;
    }
    public override void AddRecipes()
    {
        CreateRecipe(2).AddIngredient(ItemID.PearlstoneBlock, 5).AddIngredient(ItemID.PixieDust, 2).AddIngredient(ItemID.Seed, 8).AddTile(ModContent.TileType<Tiles.SeedFabricator>()).Register();
    }
}