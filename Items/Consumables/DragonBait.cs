using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
	class DragonBait : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Bait");
            Tooltip.SetDefault("Vital in the creation of the Dragon Spine");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.maxStack = 999;
			item.value = 1000;
			item.height = dims.Height;
		}
	}
}
