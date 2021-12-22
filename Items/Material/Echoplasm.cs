using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class Echoplasm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Echoplasm");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.height = dims.Height;
		}
	}
}
