using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic;

public class RecipeChanger : ModSystem
{
    public override void PostAddRecipes()
    {
        for (int i = 0; i < Recipe.numRecipes; i++)
        {
            Item q;
            Recipe recipe = Main.recipe[i];
            #region frost armor
            if (recipe.HasResult(ItemID.FrostHelmet))
            {
                if (recipe.TryGetIngredient(ItemID.AdamantiteBar, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 12);
                    recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
                }
                else if (recipe.HasIngredient(ItemID.TitaniumBar))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }
            if (recipe.HasResult(ItemID.FrostBreastplate))
            {
                if (recipe.TryGetIngredient(ItemID.AdamantiteBar, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 24);
                    recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
                }
                else if (recipe.HasIngredient(ItemID.TitaniumBar))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }
            if (recipe.HasResult(ItemID.FrostLeggings))
            {
                if (recipe.TryGetIngredient(ItemID.AdamantiteBar, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddIngredient(ModContent.ItemType<FeroziumBar>(), 18);
                    recipe.AddIngredient(ModContent.ItemType<FrigidShard>());
                }
                else if (recipe.HasIngredient(ItemID.TitaniumBar))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }
            #endregion
            if (recipe.HasResult(ItemID.Throne))
            {
                if (recipe.TryGetIngredient(ItemID.GoldBar, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddRecipeGroup("ExxoAvalonOrigins:GoldBar", 30);
                }
                else if (recipe.HasIngredient(ItemID.PlatinumBar))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }
            if (recipe.HasResult(ItemID.Timer1Second))
            {
                if (recipe.TryGetIngredient(ItemID.GoldWatch, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddRecipeGroup("ExxoAvalonOrigins:Tier3Watch");
                }
                else if (recipe.HasIngredient(ItemID.PlatinumWatch))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }
            if (recipe.HasResult(ItemID.Timer3Second))
            {
                if (recipe.TryGetIngredient(ItemID.SilverWatch, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddRecipeGroup("ExxoAvalonOrigins:Tier2Watch");
                }
                else if (recipe.HasIngredient(ItemID.TungstenWatch))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }
            if (recipe.HasResult(ItemID.Timer5Second))
            {
                if (recipe.TryGetIngredient(ItemID.CopperWatch, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddRecipeGroup("ExxoAvalonOrigins:Tier1Watch");
                }
                else if (recipe.HasIngredient(ItemID.TinWatch))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }
            if (recipe.HasResult(ItemID.GPS))
            {
                if (recipe.TryGetIngredient(ItemID.GoldWatch, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddRecipeGroup("ExxoAvalonOrigins:Tier3Watch");
                }
                else if (recipe.HasIngredient(ItemID.PlatinumWatch))
                {
                    recipe.RemoveRecipe();
                    i--;
                }
            }

            if (recipe.HasResult(ItemID.ClayPot))
            {
                if (recipe.TryGetIngredient(ItemID.ClayBlock, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddIngredient(ItemID.ClayBlock, 4);
                }
            }
            if (recipe.HasResult(ItemID.TerrasparkBoots))
            {
                recipe.RemoveRecipe();
                i--;
            }
            #region toxin shard stuff
            if (recipe.HasResult(ItemID.BladeofGrass))
            {
                recipe.AddIngredient(ModContent.ItemType<ToxinShard>());
            }
            if (recipe.HasResult(ItemID.ThornChakram))
            {
                recipe.AddIngredient(ModContent.ItemType<ToxinShard>());
            }
            if (recipe.HasResult(ItemID.IvyWhip))
            {
                recipe.AddIngredient(ModContent.ItemType<ToxinShard>());
            }
            if (recipe.HasResult(ItemID.JungleHat))
            {
                recipe.AddIngredient(ModContent.ItemType<ToxinShard>());
            }
            if (recipe.HasResult(ItemID.JungleShirt))
            {
                recipe.AddIngredient(ModContent.ItemType<ToxinShard>());
            }
            if (recipe.HasResult(ItemID.JunglePants))
            {
                recipe.AddIngredient(ModContent.ItemType<ToxinShard>());
            }
            if (recipe.HasResult(ItemID.JungleYoyo))
            {
                recipe.AddIngredient(ModContent.ItemType<ToxinShard>());
            }
            #endregion
            #region fire shard stuff
            if (recipe.HasResult(ItemID.Flamarang))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.MoltenFury))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.FieryGreatsword))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.MoltenPickaxe))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.MoltenHamaxe))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.PhoenixBlaster))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.ImpStaff))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.MoltenHelmet))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.MoltenBreastplate))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            if (recipe.HasResult(ItemID.MoltenGreaves))
            {
                recipe.AddIngredient(ModContent.ItemType<FireShard>());
            }
            #endregion
            if (recipe.HasResult(ItemID.VenomStaff))
            {
                recipe.AddIngredient(ModContent.ItemType<VenomShard>());
            }
            #region beetle armor
            if (recipe.HasResult(ItemID.BeetleHelmet))
            {
                if (recipe.TryGetIngredient(ItemID.BeetleHusk, out Item husk) && recipe.TryGetIngredient(ItemID.TurtleHelmet, out Item helm))
                {
                    recipe.RemoveIngredient(husk);
                    recipe.RemoveIngredient(helm);
                    recipe.AddIngredient(ModContent.ItemType<BeetleBar>(), 12);
                }
            }
            if (recipe.HasResult(ItemID.BeetleScaleMail))
            {
                if (recipe.TryGetIngredient(ItemID.BeetleHusk, out Item husk) && recipe.TryGetIngredient(ItemID.TurtleScaleMail, out Item chest))
                {
                    recipe.RemoveIngredient(husk);
                    recipe.RemoveIngredient(chest);
                    recipe.AddIngredient(ModContent.ItemType<BeetleBar>(), 24);
                }
            }
            if (recipe.HasResult(ItemID.BeetleShell))
            {
                if (recipe.TryGetIngredient(ItemID.BeetleHusk, out Item husk) && recipe.TryGetIngredient(ItemID.TurtleScaleMail, out Item chest))
                {
                    recipe.RemoveIngredient(husk);
                    recipe.RemoveIngredient(chest);
                    recipe.AddIngredient(ModContent.ItemType<BeetleBar>(), 24);
                }
            }
            if (recipe.HasResult(ItemID.BeetleLeggings))
            {
                if (recipe.TryGetIngredient(ItemID.BeetleHusk, out Item husk) && recipe.TryGetIngredient(ItemID.TurtleLeggings, out Item legs))
                {
                    recipe.RemoveIngredient(husk);
                    recipe.RemoveIngredient(legs);
                    recipe.AddIngredient(ModContent.ItemType<BeetleBar>(), 18);
                }
            }
            #endregion
            if (recipe.HasResult(ItemID.ShroomiteBar))
            {
                if (recipe.TryGetIngredient(ItemID.GlowingMushroom, out Item ing))
                {
                    recipe.RemoveIngredient(ing);
                    recipe.AddIngredient(ItemID.GlowingMushroom, 10);
                }
            }
        }
    }
}
