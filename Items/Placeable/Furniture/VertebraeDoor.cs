using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Furniture
{
	class VertebraeDoor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vertebrae Door");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.VertebraeDoorClosed>();
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 99;
			item.value = 200;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}