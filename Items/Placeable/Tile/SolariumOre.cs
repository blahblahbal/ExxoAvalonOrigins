using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Tile
{
	class SolariumOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solarium Ore");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.createTile = ModContent.TileType<Tiles.Ores.SolariumOre>();
			item.consumable = true;
			item.rare = ItemRarityID.Cyan;
			item.width = dims.Width;
			item.useTime = 10;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
