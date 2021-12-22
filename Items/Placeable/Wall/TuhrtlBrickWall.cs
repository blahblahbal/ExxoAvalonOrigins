using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Wall
{
	class TuhrtlBrickWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tuhrtl Brick Wall");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.consumable = true;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.createWall = ModContent.WallType<Walls.TuhrtlBrickWall>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.maxStack = 999;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}