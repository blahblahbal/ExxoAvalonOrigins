using Microsoft.Xna.Framework;
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<XanthophyteOre>(), 6);
            r.AddTile(TileID.AdamantiteForge);
            r.SetResult(this);
            r.AddRecipe();
        }
    }