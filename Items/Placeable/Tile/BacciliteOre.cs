using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class BacciliteOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baccilite Ore");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.Ores.BacciliteOre>();
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 7, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
