using Microsoft.Xna.Framework;
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<ContaminatedMushroom>());
            r.AddTile(TileID.Bottles);
            r.SetResult(this, 5);
            r.AddRecipe();
        }
    }