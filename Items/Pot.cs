using Terraria.ID;
using ExxoAvalonOrigins.Tiles;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items
{
	public class Pot : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 90;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 99;
			Item.value = 20000;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.ContagionPot>();
			Item.placeStyle = 0;
			Item.rare = ItemRarityID.Green;
		}
	}
}
