using Microsoft.Xna.Framework;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
        }
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Tourmaline>(), 12);
            recipe.AddIngredient(ItemID.Chain);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }
    }