using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class GemWand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gem Wand");
			Tooltip.SetDefault("Places ore-form gems");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.autoReuse = true;
			item.width = dims.Width;
			item.useTurn = true;
			item.useTime = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
