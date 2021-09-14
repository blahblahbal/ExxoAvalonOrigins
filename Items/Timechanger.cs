using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Items
{
	class Timechanger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Timechanger");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Timechanger");
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.height = dims.Height;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = Item.sellPrice(0, 2, 70, 0);
		}

		public override bool UseItem(Player player)
		{
			Main.dayTime = !Main.dayTime;
			Main.time = 0;

			if (Main.netMode == NetmodeID.SinglePlayer)
			{
				Main.NewText(String.Format("It is now {0}.", Main.dayTime ? "Day" : "Night"), 50, 255, 130, false);
			}
			else if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(String.Format("It is now {0}.", Main.dayTime ? "Day" : "Night")), new Color(50, 255, 130));
			}

			return true;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup(RecipeGroup.recipeGroupIDs["ExxoAvalonOrigins:GoldBar"], 30);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddRecipeGroup(RecipeGroup.recipeGroupIDs["ExxoAvalonOrigins:Tier3Watch"], 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(item.type);
			recipe.AddRecipe();
		}
	}
}