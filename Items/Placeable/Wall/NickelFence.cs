using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall
{
	class NickelFence : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nickel Fence");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.createWall = ModContent.WallType<Walls.NickelFence>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}