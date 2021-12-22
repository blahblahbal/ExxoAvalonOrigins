using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class Opal : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Opal");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.useTurn = true;
			item.maxStack = 999;
			item.createTile = ModContent.TileType<Tiles.PlacedGems>();
			item.placeStyle = 0;
			item.consumable = true;
			item.rare = -12;
			item.width = dims.Width;
			item.useTime = 10;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
