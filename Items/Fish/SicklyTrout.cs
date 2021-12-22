using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Fish
{
	class SicklyTrout : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sickly Trout");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.White;
			item.width = dims.Width;
			item.value = 10;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
