using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Logic
{
    public static class RecipeChanger
    {
        public static void ChangeRecipes()
        {
            RecipeFinder finder;

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ClayPot);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.ClayBlock);
                editor.AddIngredient(ItemID.ClayBlock, 4);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.BladeofGrass);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<ToxinShard>(), 2);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ThornChakram);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<ToxinShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.IvyWhip);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<ToxinShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.JungleHat);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<ToxinShard>(), 3);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.JungleShirt);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<ToxinShard>(), 3);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.JunglePants);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<ToxinShard>(), 3);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.Flamarang);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.MoltenFury);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.FieryGreatsword);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.MoltenPickaxe);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.MoltenHamaxe);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.PhoenixBlaster);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ImpStaff);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.MoltenHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.MoltenBreastplate);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.MoltenGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<FireShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteMask);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteHeadgear);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophytePlateMail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteDrill);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophytePickaxe);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteChainsaw);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteGreataxe);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteJackhammer);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteWarhammer);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteShotbow);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteSaber);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteClaymore);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophytePartisan);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.VenomStaff);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<VenomShard>());
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ChlorophyteArrow);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.SetResult(ItemID.ChlorophyteArrow, 150);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.BeetleHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.BeetleHusk);
                editor.DeleteIngredient(ItemID.TurtleHelmet);
                editor.AddIngredient(ModContent.ItemType<BeetleBar>(), 12);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.BeetleScaleMail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.BeetleHusk);
                editor.DeleteIngredient(ItemID.TurtleScaleMail);
                editor.AddIngredient(ModContent.ItemType<BeetleBar>(), 24);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.BeetleShell);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.BeetleHusk);
                editor.DeleteIngredient(ItemID.TurtleScaleMail);
                editor.AddIngredient(ModContent.ItemType<BeetleBar>(), 24);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.BeetleLeggings);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.BeetleHusk);
                editor.DeleteIngredient(ItemID.TurtleLeggings);
                editor.AddIngredient(ModContent.ItemType<BeetleBar>(), 18);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.ShroomiteBar);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.GlowingMushroom);
                editor.AddIngredient(ItemID.GlowingMushroom, 10);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.JungleYoyo);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AddIngredient(ModContent.ItemType<ToxinShard>(), 2);
            }
            //armor change start
            //copper armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.CopperHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.CopperBar);
                editor.AddIngredient(ItemID.CopperBar, 15);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.CopperChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.CopperBar);
                editor.AddIngredient(ItemID.CopperBar, 25);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.CopperGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.CopperBar);
                editor.AddIngredient(ItemID.CopperBar, 20);
            }
            //end copper armor
            //tin armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.TinHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.TinBar);
                editor.AddIngredient(ItemID.TinBar, 15);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.TinChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.TinBar);
                editor.AddIngredient(ItemID.TinBar, 25);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.TinGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.TinBar);
                editor.AddIngredient(ItemID.TinBar, 20);
            }
            //end tin armor
            //iron armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.IronHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.IronBar);
                editor.AddIngredient(ItemID.IronBar, 15);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.IronChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.IronBar);
                editor.AddIngredient(ItemID.IronBar, 25);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.IronGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.IronBar);
                editor.AddIngredient(ItemID.IronBar, 20);
            }
            //end iron armor
            //lead armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.LeadHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.LeadBar);
                editor.AddIngredient(ItemID.LeadBar, 15);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.LeadChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.LeadBar);
                editor.AddIngredient(ItemID.LeadBar, 25);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.LeadGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.LeadBar);
                editor.AddIngredient(ItemID.LeadBar, 20);
            }
            //end lead armor
            //silver armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.SilverHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.SilverBar);
                editor.AddIngredient(ItemID.SilverBar, 15);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.SilverChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.SilverBar);
                editor.AddIngredient(ItemID.SilverBar, 25);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.SilverGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.SilverBar);
                editor.AddIngredient(ItemID.SilverBar, 20);
            }
            //end silver armor
            //tungsten armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.TungstenHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.TungstenBar);
                editor.AddIngredient(ItemID.TungstenBar, 15);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.TungstenChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.TungstenBar);
                editor.AddIngredient(ItemID.TungstenBar, 25);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.TungstenGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.TungstenBar);
                editor.AddIngredient(ItemID.TungstenBar, 20);
            }
            //end tungsten armor
            //gold armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.GoldHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.GoldBar);
                editor.AddIngredient(ItemID.GoldBar, 20);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.GoldChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.GoldBar);
                editor.AddIngredient(ItemID.GoldBar, 30);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.GoldGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.GoldBar);
                editor.AddIngredient(ItemID.GoldBar, 25);
            }
            //end gold armor
            //platinum armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.PlatinumHelmet);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.PlatinumBar);
                editor.AddIngredient(ItemID.PlatinumBar, 20);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.PlatinumChainmail);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.PlatinumBar);
                editor.AddIngredient(ItemID.PlatinumBar, 30);
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.PlatinumGreaves);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.DeleteIngredient(ItemID.PlatinumBar);
                editor.AddIngredient(ItemID.PlatinumBar, 25);
            }
            //end plat armor
            //end armor
            finder = new RecipeFinder();
            finder.SetResult(ItemID.Timer5Second);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AcceptRecipeGroup("ExxoAvalonOrigins:Tier1Watch");
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.Timer3Second);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AcceptRecipeGroup("ExxoAvalonOrigins:Tier2Watch");
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.Timer1Second);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AcceptRecipeGroup("ExxoAvalonOrigins:Tier3Watch");
            }

            finder = new RecipeFinder();
            finder.SetResult(ItemID.GPS);
            foreach (var recipe in finder.SearchRecipes())
            {
                var editor = new RecipeEditor(recipe);
                editor.AcceptRecipeGroup("ExxoAvalonOrigins:Tier3Watch");
            }
        }
    }
}
