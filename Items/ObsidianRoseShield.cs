using Microsoft.Xna.Framework;
            player.lavaRose = player.fireWalk = player.noKnockback = true;
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianShield);
            recipe.AddIngredient(ItemID.ObsidianRose);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }