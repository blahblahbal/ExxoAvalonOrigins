using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
	class BloodberrySeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodberry Seeds");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Herbs.Bloodberry>();
			item.placeStyle = 0;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = 90;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 5);
            recipe.AddIngredient(ItemID.Vertebrae, 2);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
