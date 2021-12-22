using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Storage
{
	class ContaigonChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagion Chest");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.maxStack = 99;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.ContaigonChest>();
			item.width = dims.Width;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
