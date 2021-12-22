using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
	class HydrolythTrace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hydrolyth Trace");
			Tooltip.SetDefault("Calls forth a comet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.value = 0;
			item.maxStack = 999;
			item.useAnimation = 45;
			item.height = dims.Height;
		}
	}
}
