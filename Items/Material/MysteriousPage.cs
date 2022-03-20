﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
    class MysteriousPage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysterious Page");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Green;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.maxStack = 999;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 10);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
