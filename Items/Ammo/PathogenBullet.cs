using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class PathogenBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pathogen Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 7f;
			item.damage = 11;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Orange;
			item.width = dims.Width;
			item.knockBack = 3f;
			item.shoot = ModContent.ProjectileType<Projectiles.PathogenBullet>();
			item.maxStack = 2000;
			item.value = 100;
			item.height = dims.Height;
		}
	}
}
