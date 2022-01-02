using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic
{
    public static class SushiRecipes
    {
        public static void CreateRecipes(Mod mod)
        {
            ModRecipe recipe;

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagicCleaver>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.FleshBoiler>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 25);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.BubbleBoost>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.GoldenShield>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.GreekExtinguisher>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.SixHundredWattLightbulb>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 20);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.Vortex>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 10);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Material.SpikedBlastShell>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 50);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Material.PointingLaser>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 60);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Material.AlienDevice>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>(), 40);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
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
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.Terraspin>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Ranged.QuadroCannon>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Summon.ReflectorStaff>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Accessories.DragonStone>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Melee.Infernasword>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>(), 45);
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Weapons.Magic.MagmafrostBolt>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Tokens.HellcastleToken>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.DarkMatterToken>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Tokens.SuperhardmodeToken>());
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Tokens.MechastingToken>());
            recipe.AddTile(ModContent.TileType<Tiles.XeradonAnvil>());
            recipe.SetResult(ModContent.ItemType<Items.Tokens.DarkMatterToken>());
            recipe.AddRecipe();
        }
    }
}
