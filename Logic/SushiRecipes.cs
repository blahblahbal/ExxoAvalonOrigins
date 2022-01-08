using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic
{
    public static class SushiRecipes
    {
        public static void CreateRecipes(Mod mod, Mod imk)
        {
            ModRecipe recipe;

            //start swapping
            //start mechasting
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.Mechazapinator>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.StingerPack>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.HeatSeeker>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.StingerPack>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.StingerPack>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.Mechazapinator>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.HeatSeeker>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.Mechazapinator>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.StingerPack>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.HeatSeeker>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.Mechazapinator>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.HeatSeeker>());
            recipe.AddRecipe();
            //end mechasting

            //start dragon lord
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddRecipe();
            //end dragon lord

            //start wall of steel
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.BubbleBoost>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagicCleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.FleshBoiler>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagicCleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.BubbleBoost>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.FleshBoiler>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.MagicCleaver>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.FleshBoiler>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.MagicCleaver>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.BubbleBoost>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Ranged.FleshBoiler>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.BubbleBoost>());
            recipe.AddRecipe();
            //end wall of steel

            //start phantasm
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.PhantomKnives>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.VampireTeeth>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.EtherealHeart>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.VampireTeeth>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Weapons.Magic.PhantomKnives>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.EtherealHeart>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.VampireTeeth>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Accessories.EtherealHeart>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.VampireTeeth>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.PhantomKnives>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Accessories.EtherealHeart>());
            recipe.AddIngredient(imk.ItemType("SwapToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.PhantomKnives>());
            recipe.AddRecipe();
            //end phantasm
            //end swapping

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.HellcastleToken>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(imk.ItemType("LootMartiansToken"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(imk.ItemType("UndergroundCorruptionEocToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(imk.ItemType("UndergroundCrimsonEocToken"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(imk.ItemType("UndergroundCrimsonEocToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Tokens.ContagionToken>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.ContagionToken>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(imk.ItemType("UndergroundCorruptionEocToken"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.TropicsToken>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(imk.ItemType("UndergroundJungleStartToken"));
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(imk.ItemType("UndergroundJungleStartToken"));
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(ModContent.ItemType<Items.Tokens.TropicsToken>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.TropicsToken>(), 25);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.Thompson>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.TropicsToken>(), 25);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.AnkletoftheWind);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagicCleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.FleshBoiler>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.BubbleBoost>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.GoldenShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.GreekExtinguisher>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.SixHundredWattLightbulb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.Vortex>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Material.SpikedBlastShell>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Material.PointingLaser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 60);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Material.AlienDevice>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 40);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Material.Rock>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.HellcastleToken>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.Material.GhostintheMachine>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.HellcastleToken>(), 30);
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.Boomlash>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.HellcastleToken>());
            recipe.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            recipe.SetResult(ModContent.ItemType<Items.Placeable.Tile.ImperviousBrick>(), 10);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 60);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.Terraspin>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>());
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Tokens.HellcastleToken>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.DarkMatterToken>());
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.DarkMatterToken>(), 75);
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.VampireHarpyWings>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>());
            recipe.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Tokens.DarkMatterToken>());
            recipe.AddRecipe();
        }
    }
}
