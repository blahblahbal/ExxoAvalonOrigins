using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class Beak : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beak");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Beak>();
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.maxStack = 999;
			item.value = 50;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
