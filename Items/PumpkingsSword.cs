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
	class PumpkingsSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pumpking's Sword");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PumpkingsSword");
			item.damage = 90;
			item.autoReuse = true;
			item.scale = 1.15f;
			item.shootSpeed = 9f;
			item.rare = 9;
			item.width = dims.Width;
			item.useTime = 26;
			item.knockBack = 6.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.PumpkingsBeam>();
			item.melee = true;
			item.useStyle = 1;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.useAnimation = 26;
			item.height = dims.Height;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            pumpkinSword(target.whoAmI, (int)(damage * 1.5), knockBack, 0, player);
        }

        private void pumpkinSword(int i, int dmg, float kb, int Type, Player p)
        {
            int num = Main.rand.Next(100, 300);
            int num2 = Main.rand.Next(100, 300);
            if (Main.rand.Next(2) == 0)
            {
                num -= Main.maxScreenW / 2 + num;
            }
            else
            {
                num += Main.maxScreenW / 2 - num;
            }
            if (Main.rand.Next(2) == 0)
            {
                num2 -= Main.maxScreenH / 2 + num2;
            }
            else
            {
                num2 += Main.maxScreenH / 2 - num2;
            }
            num += (int)p.position.X;
            num2 += (int)p.position.Y;
            float num3 = 8f;
            Vector2 vector = new Vector2((float)num, (float)num2);
            float num4 = Main.npc[i].position.X - vector.X;
            float num5 = Main.npc[i].position.Y - vector.Y;
            float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
            num6 = num3 / num6;
            num4 *= num6;
            num5 *= num6;
            Projectile.NewProjectile((float)num, (float)num2, num4, num5, ModContent.ProjectileType<Projectiles.PumpkinHead>(), dmg, kb, p.whoAmI, (float)i, 0f);
        }
    }
}