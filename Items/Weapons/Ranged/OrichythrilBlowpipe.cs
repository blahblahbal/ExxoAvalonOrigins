using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
	class OrichythrilBlowpipe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lyonic Blowpipe");
			Tooltip.SetDefault("Fires a spread of seven seeds\nAllows the collection of seeds for ammo");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 13;
			item.autoReuse = true;
            item.useAmmo = AmmoID.Dart;
            item.UseSound = SoundID.Item63;
            item.shootSpeed = 11f;
			item.ranged = true;
			item.rare = ItemRarityID.LightRed;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 30;
			item.knockBack = 3.25f;
			item.shoot = ProjectileID.PurificationPowder;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 10000;
			item.useAnimation = 30;
			item.height = dims.Height;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			for (int num206 = 0; num206 < 7; num206++)
			{
				float num207 = speedX;
				float num208 = speedY;
				num207 += (float)Main.rand.Next(-35, 36) * 0.05f;
				num208 += (float)Main.rand.Next(-35, 36) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, num207, num208, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}

			return false;
		}
	}
}
