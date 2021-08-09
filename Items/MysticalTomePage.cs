using Microsoft.Xna.Framework;
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddIngredient(ItemID.IronBar);
            recipe.AddIngredient(ItemID.Wood, 3);
            recipe.AddRecipeGroup(RecipeGroupID.Wood);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.SetResult(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }