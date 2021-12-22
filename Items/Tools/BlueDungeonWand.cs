using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class BlueDungeonWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dungeon Brick Wands");
			Tooltip.SetDefault("Places unsafe blue dungeon walls");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 10;
			item.createWall = WallID.BlueDungeonUnsafe;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
