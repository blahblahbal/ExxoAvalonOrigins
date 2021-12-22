using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
	class OpalStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Opal Staff");
            Item.staff[item.type] = true;
        }

		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.SapphireStaff);
			Item.staff[item.type] = true;
			Rectangle dims = this.GetDims();
			item.width = dims.Width;
			item.height = dims.Height;
			item.damage = 90;
			item.autoReuse = true;
			item.shootSpeed = 9.5f;
			item.mana = 14;
			item.rare = ItemRarityID.Yellow;
			item.useTime = 23;
			item.useAnimation = 23;
			item.knockBack = 7.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.OpalBolt>();
			item.value = Item.buyPrice(0, 30, 0, 0);
            item.UseSound = SoundID.Item43;
        }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
			ref float knockBack)
		{
			for (int num182 = 0; num182 < 3; num182++)
			{
				float num183 = speedX;
				float num184 = speedY;
				num183 += (float)Main.rand.Next(-30, 31) * 0.05f;
				num184 += (float)Main.rand.Next(-30, 31) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, num183, num184, type, damage, knockBack, player.whoAmI, 0f, 0f);
			}

			return false;
		}
	}
}
