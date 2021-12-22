using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class HeartoftheGolem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart of the Golem");
			Tooltip.SetDefault("Grants a 5% chance for enemies to drop a platinum heart");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().heartGolem = true;
		}
	}
}
