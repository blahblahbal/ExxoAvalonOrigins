using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class Sweetstem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sweetstem");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = 100;
			item.height = dims.Height;
		}
	}
}
