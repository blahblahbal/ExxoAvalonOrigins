using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class PyroscoricBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pyroscoric Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 9f;
			item.damage = 19;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.MagmaticBullet>();
			item.maxStack = 2000;
			item.value = 1200;
			item.height = dims.Height;
		}
	}
}
