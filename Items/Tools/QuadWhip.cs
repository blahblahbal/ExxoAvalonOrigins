using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class QuadWhip : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quad Whip");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.noUseGraphic = true;
			item.useTurn = true;
			item.shootSpeed = 16f;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 20;
			item.knockBack = 7f;
			item.shoot = ModContent.ProjectileType<Projectiles.QuadHook>();
			item.value = Item.sellPrice(0, 12, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 20;
			item.height = dims.Height;
		}
	}
}
