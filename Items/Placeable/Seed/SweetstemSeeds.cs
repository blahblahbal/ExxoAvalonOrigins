using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Seed
{
	class SweetstemSeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sweetstem Seeds");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Herbs.Sweetstem>();
			item.placeStyle = 0;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = 120;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}