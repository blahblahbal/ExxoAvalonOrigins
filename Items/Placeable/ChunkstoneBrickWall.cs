using Microsoft.Xna.Framework;
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<ChunkstoneBrick>());
            r.AddTile(TileID.WorkBenches);
            r.SetResult(this, 4);
            r.AddRecipe();
        }