using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
	class BarfbushSeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barfbush Seeds");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Herbs.Barfbush>();
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
            recipe.AddIngredient(ModContent.ItemType<Tile.ChunkstoneBlock>(), 5);
            recipe.AddIngredient(ModContent.ItemType<Material.YuckyBit>(), 2);
            recipe.AddIngredient(ItemID.Seed, 8);
            recipe.AddTile(ModContent.TileType<Tiles.SeedFabricator>());
            recipe.SetResult(this, 2);
            recipe.AddRecipe();
        }
    }
}
