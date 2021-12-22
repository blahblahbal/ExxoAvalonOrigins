using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class SpikedBlastShell : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spiked Blast Shell");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = -12;
			item.width = dims.Width;
			item.value = 5000;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
