using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class BottledLava : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bottled Lava");
			Tooltip.SetDefault("'Drinking may be fatal'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
			item.maxStack = 100;
			item.value = 50;
			item.height = dims.Height;
		}
	}
}
