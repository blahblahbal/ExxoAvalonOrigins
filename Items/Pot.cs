using Terraria.ID;
using ExxoAvalonOrigins.Tiles;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
	public class Pot : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 90;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 20000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.ContagionPot>();
			item.placeStyle = 0;
			item.rare = ItemRarityID.Green;
		}
	}
}
