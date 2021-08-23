using Microsoft.Xna.Framework;
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ItemID.JungleSpores, 10);
            r.AddIngredient(ItemID.CursedFlame, 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ItemID.JungleSpores, 10);
            r.AddIngredient(ItemID.Ichor, 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Goggles);
            r.AddIngredient(ModContent.ItemType<BloodshotLens>(), 2);
            r.AddIngredient(ItemID.JungleSpores, 10);
            r.AddIngredient(ModContent.ItemType<Pathogen>(), 15);
            r.AddIngredient(ItemID.SoulofNight, 10);
            r.AddIngredient(ModContent.ItemType<Sulphur>(), 20);
            r.AddTile(TileID.DemonAltar);
            r.SetResult(this);
            r.AddRecipe();
        }
    }