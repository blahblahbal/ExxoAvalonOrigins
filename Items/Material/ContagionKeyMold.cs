using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class ContagionKeyMold : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagion Key Mold");
			Tooltip.SetDefault("Used for crafting a Contagion Key");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.scale = 1f;
			item.maxStack = 999;
			item.height = dims.Height;
		}
	}
}
