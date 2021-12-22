using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class PeeShooter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pee Shooter");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.UseSound = SoundID.Item11;
			item.damage = 8;
			item.scale = 1f;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 7f;
			item.ranged = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Blue;
			item.width = dims.Width;
			item.useTime = 13;
			item.shoot = ProjectileID.Bullet;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 50000;
			item.useAnimation = 13;
			item.height = dims.Height;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(4, 0);
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<Projectiles.PeeBullet>();
            }
            return true;
        }
    }
}
