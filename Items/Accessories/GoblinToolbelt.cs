using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class GoblinToolbelt : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goblin Toolbelt");
			Tooltip.SetDefault("Increases block placement range by 2, tells time and shows position\nCan craft Tinkerer's Workshop and Work Bench items by hand");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.blockRange += 2;
			player.accWatch = 3;
			player.accCompass = 1;
			player.accDepthMeter = 1;
		}
	}
}