using Terraria.ID;using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    public static class TomeRecipeCreator
    {
        public static void CreateRecipes(Mod mod)
        {
            var recipe = new ModRecipe(mod);

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RubybeadHerb>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.Sandstone>(), 3);
            recipe.AddIngredient(ItemID.LesserHealingPotion, 5);
            recipe.AddIngredient(ItemID.BandofRegeneration);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheHeavenlyScent>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalClaw>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.MysteriousPage>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Sandstone>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.DewOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.ChristmasTome>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.ElementDust>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.ElementDiamond>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.RubybeadHerb>(), 6);
            recipe.AddIngredient(ModContent.ItemType<Items.DewOrb>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.StrongVenom>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTotem>());
            recipe.AddIngredient(ModContent.ItemType<Items.DewofHerbs>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalClaw>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.TheVoidlands>());
            recipe.AddIngredient(ModContent.ItemType<Items.ScrollofTome>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.FineLumber>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.Gravel>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Sandstone>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.CarbonSteel>(), 15);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.CreatorsTome>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.AdventuresandMishaps>());
            recipe.AddIngredient(ModContent.ItemType<Items.ScrollofTome>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.FineLumber>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Gravel>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.Sandstone>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.CarbonSteel>(), 20);
            recipe.AddIngredient(ModContent.ItemType<Items.MysteriousPage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.LoveUpandDown>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.EternitysMoon>());
            recipe.AddIngredient(ModContent.ItemType<Items.TomeofDistance>());
            recipe.AddIngredient(ModContent.ItemType<Items.FlankersTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<Items.BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<Items.MeditationsFlame>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheVoidlands>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<Items.EternitysMoon>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<Items.TaleoftheDolt>());
            recipe.AddIngredient(ModContent.ItemType<Items.MeditationsFlame>());
            recipe.AddIngredient(ModContent.ItemType<Items.TaleoftheRedLotus>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheVoidlands>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<Items.FlankersTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.TomeofDistance>());
            recipe.AddIngredient(ModContent.ItemType<Items.TomeoftheRiverSpirits>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheVoidlands>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.BurningDesire>());
            recipe.AddIngredient(ModContent.ItemType<Items.TomeoftheRiverSpirits>());
            recipe.AddIngredient(ModContent.ItemType<Items.SoutheasternPeacock>());
            recipe.AddIngredient(ModContent.ItemType<Items.TaleoftheDolt>());
            recipe.AddIngredient(ModContent.ItemType<Items.TaleoftheRedLotus>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheVoidlands>());
            recipe.AddRecipe();



            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DewOrb>(), 6);
            recipe.AddIngredient(ModContent.ItemType<Items.CarbonSteel>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.Sandstone>(), 10);
            recipe.AddIngredient(ItemID.FallenStar, 15);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TaleoftheRedLotus>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.RubybeadHerb>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.FineLumber>(), 20);
            recipe.AddIngredient(ItemID.FallenStar, 60);
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.MeditationsFlame>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.StrongVenom>(), 5);
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalClaw>(), 4);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TomorrowsPhoenix>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.StrongVenom>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.FineLumber>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.RubybeadHerb>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.FlankersTome>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.Gravel>(), 15);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalClaw>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.EternitysMoon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.FlankersTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.MistyPeachBlossoms>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TaleoftheDolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.TomorrowsPhoenix>());
            recipe.AddIngredient(ModContent.ItemType<Items.ChristmasTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.SoutheasternPeacock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.MistyPeachBlossoms>());
            recipe.AddIngredient(ModContent.ItemType<Items.TaleoftheRedLotus>());
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TomeofDistance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.StrongVenom>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.FineLumber>(), 20);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.MistyPeachBlossoms>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.MeditationsFlame>());
            recipe.AddIngredient(ModContent.ItemType<Items.EternitysMoon>());
            recipe.AddIngredient(ItemID.FallenStar, 20);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>());
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TomeoftheRiverSpirits>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddIngredient(ModContent.ItemType<Items.FineLumber>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.CarbonSteel>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Items.RubybeadHerb>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.AdventuresandMishaps>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Sandstone>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Items.ElementDust>(), 4);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalClaw>(), 6);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 2);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.UnderestimatedResolve>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Gravel>(), 7);
            recipe.AddIngredient(ModContent.ItemType<Items.RubybeadHerb>(), 3);
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 4);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.BurningDesire>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.UnvolanditeBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.IronskinPotion, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheThreeScholars>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.VorazylcumBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.IronskinPotion, 10);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheThreeScholars>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.OblivionBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.FallenStar, 100);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.ChantoftheWaterDragon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.Opal>(), 50);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ItemID.ShroomiteBar, 12);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.ThePlumHarvest>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.BerserkerBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.DarkMatterGel>(), 100);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.SceneofCarnage>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>());
            recipe.AddIngredient(ModContent.ItemType<Items.HydrolythBar>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofBlight>(), 30);
            recipe.AddIngredient(ModContent.ItemType<Items.MysticalTomePage>(), 5);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.TheOasisRemembered>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.TheOasisRemembered>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<Items.TheOasisRemembered>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.SceneofCarnage>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<Items.SceneofCarnage>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.ThePlumHarvest>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<Items.ThePlumHarvest>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.ChantoftheWaterDragon>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<Items.ChantoftheWaterDragon>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.CreatorsTome>());
            recipe.AddIngredient(ModContent.ItemType<Items.TheThreeScholars>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.LoveUpandDown>());
            recipe.AddIngredient(ModContent.ItemType<Items.TheThreeScholars>());
            recipe.AddIngredient(ModContent.ItemType<Items.DragonOrb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Items.Onyx>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Dominance>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Dominance>());
            recipe.AddIngredient(ModContent.ItemType<Items.VictoryPiece>(), 3);
            recipe.AddIngredient(ModContent.ItemType<Items.SoulofTorture>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(ModContent.ItemType<Items.Emperor>());
            recipe.AddRecipe();
        }
    }
}