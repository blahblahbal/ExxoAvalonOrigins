using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
	class OnyxHook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Onyx Hook");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.noUseGraphic = true;
			item.damage = 70;
			item.useTurn = true;
			item.shootSpeed = 16f;
			item.rare = ItemRarityID.Lime;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 25f;
			item.shoot = ModContent.ProjectileType<Projectiles.OnyxHook>();
			item.value = Item.sellPrice(0, 9, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}
