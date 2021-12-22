using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light
{
	class ResistantWoodCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Resistant Wood Candle");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.noWet = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.ResistantWoodCandle>();
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 99;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
