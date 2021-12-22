using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Material
{
	class ElementShard : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Element Shard");
			Tooltip.SetDefault("'A fragment of the elements'");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = 3000;
			item.height = dims.Height;
		}
	}
}
