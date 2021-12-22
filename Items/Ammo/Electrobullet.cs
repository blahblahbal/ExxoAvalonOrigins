using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class Electrobullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electrobullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 5.25f;
			item.damage = 13;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.Electrobullet>();
			item.maxStack = 2000;
			item.value = 400;
			item.height = dims.Height;
		}
	}
}
