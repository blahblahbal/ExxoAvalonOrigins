﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall
{
    class EmeraldWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emerald Wall");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.autoReuse = true;
            item.consumable = true;
            item.width = dims.Width;
            item.useTurn = true;
            item.useTime = 7;
            item.createWall = ModContent.WallType<Walls.EmeraldGemWall>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.maxStack = 999;
            item.useAnimation = 15;
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 4);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.Emerald);
            recipe.AddRecipe();
        }
    }
}
