using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class TungstenBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tungsten Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 3.25f;
			item.damage = 12;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.width = dims.Width;
			item.knockBack = 3f;
			item.shoot = ProjectileID.Bullet;
			item.maxStack = 2000;
			item.value = 15;
			item.height = dims.Height;
		}
	}
}
