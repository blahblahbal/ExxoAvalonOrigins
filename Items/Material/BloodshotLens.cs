using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class BloodshotLens : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloodshot Lens");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 20, 0);
			item.height = dims.Height;
		}
	}
}
