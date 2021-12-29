using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class Starstone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starstone");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Ores.Starstone>();
			item.rare = ItemRarityID.Green;
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
		}
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(this, 30);
            r.AddTile(TileID.Furnaces);
            r.SetResult(ItemID.ManaCrystal);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.ManaCrystal);
            r.AddTile(TileID.Furnaces);
            r.SetResult(this, 30);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(this, 10);
            r.AddTile(TileID.Furnaces);
            r.SetResult(ItemID.FallenStar);
            r.AddRecipe();
        }
    }
}
