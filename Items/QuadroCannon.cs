using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class QuadroCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quadro Cannon");
			Tooltip.SetDefault("Four round burst\nOnly the first shot consumes ammo and fires a spread of bullets");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/QuadroCannon");
			item.damage = 15;
			item.autoReuse = true;
			item.shootSpeed = 14f;
			item.useAmmo = AmmoID.Bullet;
			item.ranged = true;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 4;
			item.knockBack = 5f;
			item.shoot = ProjectileID.Bullet;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = 780000;
			item.reuseDelay = 14;
			item.useAnimation = 16;
			item.height = dims.Height;
            item.UseSound = SoundID.Item11;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//sound is weird sometimes?? idk why tho
			for (int num209 = 0; num209 < 4; num209++)
			{
				float num210 = speedX;
				float num211 = speedY;
				num210 += (float)Main.rand.Next(-24, 25) * 0.05f;
				num211 += (float)Main.rand.Next(-24, 25) * 0.05f;
				Projectile.NewProjectile(position.X, position.Y, num210, num211, type, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.PlaySound(SoundID.Item, -1, -1, 11);
			}
			return false;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return player.itemAnimation >= item.useAnimation - 4;
		}
	}
}