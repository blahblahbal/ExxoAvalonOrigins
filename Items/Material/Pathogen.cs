using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class Pathogen : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pathogen");
			Tooltip.SetDefault("'Blech'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = 4500;
			item.height = dims.Height;
		}
	}
}
