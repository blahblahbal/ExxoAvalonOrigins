using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
namespace ExxoAvalonOrigins
{
	public static class RecipeChanger
	{
		public static void ChangeRecipes(Mod mod)
		{
			var finder = new RecipeFinder();

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
				editor.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 2);
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ThornChakram);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.ToxinShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.IvyWhip);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.ToxinShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.JungleHat);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 3);
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.JungleShirt);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 3);
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.JunglePants);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 3);
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.Flamarang);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.MoltenFury);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.FieryGreatsword);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.MoltenPickaxe);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.MoltenHamaxe);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.PhoenixBlaster);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ImpStaff);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.MoltenHelmet);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.MoltenBreastplate);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.MoltenGreaves);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.FireShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteHelmet);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteMask);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteHeadgear);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophytePlateMail);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteGreaves);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteDrill);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophytePickaxe);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteChainsaw);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteGreataxe);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteJackhammer);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteWarhammer);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteShotbow);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteSaber);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophyteClaymore);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.ChlorophytePartisan);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.VenomStaff);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.AddIngredient(ModContent.ItemType<Items.VenomShard>());
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
				editor.AddIngredient(ModContent.ItemType<Items.BeetleBar>(), 12);
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.BeetleScaleMail);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.DeleteIngredient(ItemID.BeetleHusk);
				editor.DeleteIngredient(ItemID.TurtleScaleMail);
				editor.AddIngredient(ModContent.ItemType<Items.BeetleBar>(), 24);
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.BeetleShell);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.DeleteIngredient(ItemID.BeetleHusk);
				editor.DeleteIngredient(ItemID.TurtleScaleMail);
				editor.AddIngredient(ModContent.ItemType<Items.BeetleBar>(), 24);
			}

			finder = new RecipeFinder();
			finder.SetResult(ItemID.BeetleLeggings);
			foreach (var recipe in finder.SearchRecipes())
			{
				var editor = new RecipeEditor(recipe);
				editor.DeleteIngredient(ItemID.BeetleHusk);
				editor.DeleteIngredient(ItemID.TurtleLeggings);
				editor.AddIngredient(ModContent.ItemType<Items.BeetleBar>(), 18);
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
				editor.AddIngredient(ModContent.ItemType<Items.ToxinShard>(), 2);
			}

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