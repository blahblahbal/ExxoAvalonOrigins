using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class PatellaBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Patella Bullet");
			Tooltip.SetDefault("Slow speed, low range, but high damage");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 15;
			item.shootSpeed = 3f;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.knockBack = 3f;
			item.shoot = ModContent.ProjectileType<Projectiles.PatellaBullet>();
			item.value = 10;
			item.maxStack = 2000;
			item.height = dims.Height;
		}
	}
}
