using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class MysticalTomePage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mystical Tome Page");
			Tooltip.SetDefault("Used to craft tomes");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
            recipe.SetResult(ModContent.TileType<Tiles.TomeForge>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
