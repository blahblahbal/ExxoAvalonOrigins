using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class FeroziumBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ferozium Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 5.25f;
			item.damage = 15;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Lime;
			item.width = dims.Width;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.FeroziumBullet>();
			item.maxStack = 2000;
			item.value = 200;
			item.height = dims.Height;
		}
	}
}
