using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class EarthStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Earth Stone");
			Tooltip.SetDefault("'The essence of the golem'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = Item.sellPrice(0, 0, 75, 0);
			item.height = dims.Height;
		}
	}
}
