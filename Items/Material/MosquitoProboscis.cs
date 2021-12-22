using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class MosquitoProboscis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mosquito Proboscis");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 0, 40);
			item.height = dims.Height;
		}
	}
}
