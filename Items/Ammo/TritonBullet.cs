using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
	class TritonBullet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Triton Bullet");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.shootSpeed = 11f;
			item.damage = 17;
			item.ammo = AmmoID.Bullet;
			item.ranged = true;
			item.consumable = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.knockBack = 20f;
			item.shoot = ModContent.ProjectileType<Projectiles.TritonBullet>();
			item.maxStack = 2000;
			item.value = 1200;
			item.height = dims.Height;
		}
	}
}
