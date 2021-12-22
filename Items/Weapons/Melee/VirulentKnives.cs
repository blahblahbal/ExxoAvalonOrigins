using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class VirulentKnives : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Virulent Knives");
			Tooltip.SetDefault("Throws homing knives");
		}

		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 46;
			item.noUseGraphic = true;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1f;
			item.shootSpeed = 11f;
			item.noMelee = true;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTime = 18;
			item.knockBack = 3f;
			item.shoot = ModContent.ProjectileType<Projectiles.YuckyKnife>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.useAnimation = 18;
			item.height = dims.Height;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = ExxoAvalonOriginsGlobalProjectile.howManyProjectiles(1, 5);
			float shootSpeed = (float) Math.Sqrt((double) speedX * speedX + speedY * speedY);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				float newSpeedX = speedX * 2f + Main.rand.Next(-35, 36) * 0.05f * i;
				float newSpeedY = speedY * 2f + Main.rand.Next(-35, 36) * 0.05f * i;
				float multiMod = shootSpeed / (float) Math.Sqrt((double) newSpeedX * newSpeedX + newSpeedY * newSpeedY);
				newSpeedX *= multiMod;
				newSpeedY *= multiMod;
				Projectile.NewProjectile(position.X, position.Y, newSpeedX, newSpeedY, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}
