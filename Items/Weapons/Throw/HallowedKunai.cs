using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Throw
{
	class HallowedKunai : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Kunai");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.noUseGraphic = true;
			item.damage = 38;
			item.maxStack = 999;
			item.shootSpeed = 11f;
			item.crit += 2;
			item.ranged = true;
			item.consumable = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.useTime = 10;
			item.knockBack = 2.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.HallowedKunai>();
			item.value = 400;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 10;
			item.height = dims.Height;
		}
	}
}
