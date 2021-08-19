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
	class CaesiumScimitar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caesium Scimitar");
			Tooltip.SetDefault("Explodes foes on hit");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/CaesiumScimitar");
			item.UseSound = SoundID.Item1;
			item.damage = 66;
			item.useTurn = true;
			item.scale = 1.3f;
			item.rare = 5;
			item.width = dims.Width;
			item.useTime = 18;
			item.knockBack = 8f;
			item.melee = true;
			item.autoReuse = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.useAnimation = 18;
			item.height = dims.Height;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			Main.PlaySound(SoundID.Item14, target.position);
			for (int i = 0; i < 5; i++)
            {
				Projectile.NewProjectile(target.Center.X, target.Center.Y, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3), ModContent.ProjectileType<Projectiles.CaesiumExplosion>(), damage, knockBack, player.whoAmI, 0f, 0f);
			}
		}
	}
}