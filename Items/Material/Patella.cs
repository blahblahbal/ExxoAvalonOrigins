using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class Patella : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Patella");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
			item.value = 90;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
