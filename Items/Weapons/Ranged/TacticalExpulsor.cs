using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class TacticalExpulsor : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tactical Expulsor");
			Tooltip.SetDefault("Fires a spread of eight bullets");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 35;
			item.autoReuse = true;
			item.useTurn = false;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 7f;
			item.crit += 1;
			item.ranged = true;
			item.rare = ItemRarityID.Cyan;
			item.noMelee = true;
			item.width = dims.Width;
			item.knockBack = 3f;
			item.useTime = 19;
			item.shoot = ProjectileID.Bullet;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 19;
			item.height = dims.Height;
            item.UseSound = SoundID.Item38;

        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10f, 0f);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			for (int num194 = 0; num194 < 8; num194++)
			{
				float num195 = speedX;
				float num196 = speedY;
				num195 += (float)Main.rand.Next(-40, 41) * 0.05f;
				num196 += (float)Main.rand.Next(-40, 41) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, num195, num196, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}

			return false;
		}
	}
}
