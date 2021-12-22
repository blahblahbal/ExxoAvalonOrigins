using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class BrokenVigilanteTome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Vigilante Tome");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.maxStack = 99;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.height = dims.Height;
		}
	}
}
