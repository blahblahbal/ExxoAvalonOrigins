﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
    class BarfbushSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Barfbush Seeds");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.Herbs.Barfbush>();
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
            CreateRecipe(2).AddIngredient(ModContent.ItemType<Tile.ChunkstoneBlock>(), 5).AddIngredient(ModContent.ItemType<Material.YuckyBit>(), 2).AddIngredient(ItemID.Seed, 8).AddTile(ModContent.TileType<Tiles.SeedFabricator>()).Register();
        }
    }
}
