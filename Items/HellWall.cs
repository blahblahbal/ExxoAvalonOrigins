using Microsoft.Xna.Framework;
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AshBlock);
            recipe.AddIngredient(ItemID.Hellstone);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 8);
            recipe.AddRecipe();
        }
    }