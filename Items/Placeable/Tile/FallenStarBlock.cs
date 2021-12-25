using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class FallenStarBlock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fallen Star Block");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.FallenStarTile>();
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = 0;
			item.useAnimation = 15;
			item.height = dims.Height;
		}

        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.FallenStar);
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(this);
            r.SetResult(ItemID.FallenStar);
            r.AddRecipe();
        }
    }
}
