using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Storage
{
	class DesertChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Desert Chest");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.DesertChest>();
			item.placeStyle = 0;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 99;
			item.value = 10000;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}