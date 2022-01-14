using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class TritanoriumOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tritanorium Ore");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.createTile = ModContent.TileType<Tiles.Ores.TritanoriumOre>();
			item.consumable = true;
			item.rare = ItemRarityID.Purple;
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
