using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class Moonphaser : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonphaser");
			Tooltip.SetDefault("Changes the phases of the Moon\nHas a chance to trigger a Blood Moon if night");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.rare = ItemRarityID.LightRed;
			item.width = dims.Width;
			item.useTime = 30;
			item.shoot = ModContent.ProjectileType<Projectiles.Moonphaser>();
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 2, 70, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
		}
	}
}
