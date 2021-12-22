using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class UnvolanditeFusebow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unvolandite Fusebow");
			Tooltip.SetDefault("Fires a spread of pulse arrows that explode on the final impact");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 70;
			item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;
			item.shootSpeed = 9f;
			item.ranged = true;
			item.rare = ItemRarityID.Cyan;
			item.noMelee = true;
			item.width = dims.Width;
			item.knockBack = 5f;
			item.useTime = 15;
			item.shoot = ModContent.ProjectileType<Projectiles.KunzitePulseBolt>();
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.useAnimation = 15;
			item.height = dims.Height;
            item.UseSound = SoundID.Item5;
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			for (int num155 = 0; num155 < 4; num155++)
			{
				float num156 = speedX;
				float num157 = speedY;
				num156 += (float)Main.rand.Next(-30, 31) * 0.05f;
				num157 += (float)Main.rand.Next(-30, 31) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, num156, num157, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}

			return false;
		}
	}
}
