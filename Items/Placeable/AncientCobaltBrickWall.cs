using Microsoft.Xna.Framework;
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<AncientCobaltBrick>());
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(this, 4);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(this, 4);
            r.AddTile(ModContent.TileType<Tiles.AncientWorkbench>());
            r.SetResult(ModContent.ItemType<AncientCobaltBrick>());
            r.AddRecipe();
        }
    }