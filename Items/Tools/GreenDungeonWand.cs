using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class GreenDungeonWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Green Dungeon Wand");
			Tooltip.SetDefault("Places unsafe green dungeon walls");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 7;
			item.createWall = WallID.GreenDungeonUnsafe;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
