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
			item.damage = 105;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1.15f;
			item.rare = ItemRarityID.Red;
			item.width = dims.Width;
			item.useTime = 36;
			item.useAnimation = 16;
			item.knockBack = 8f;
			item.shoot = ModContent.ProjectileType<Projectiles.PumpkingsBeam>();
            item.shootSpeed = 12f;
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 40, 0, 0);
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            pumpkinSword(target.whoAmI, (int)(damage * 2), knockBack, 0, player);
        }
        private void pumpkinSword(int i, int dmg, float kb, int Type, Player p)
        {
			//if (Main.rand.Next(2) == 1)
			{
				int logicCheckScreenHeight = Main.LogicCheckScreenHeight;
				int logicCheckScreenWidth = Main.LogicCheckScreenWidth;
				int num = Main.rand.Next(100, 300);
				int num2 = Main.rand.Next(100, 300);
				num = ((Main.rand.Next(2) != 0) ? (num + (logicCheckScreenWidth / 2 - num)) : (num - (logicCheckScreenWidth / 2 + num)));
				num2 = ((Main.rand.Next(2) != 0) ? (num2 + (logicCheckScreenHeight / 2 - num2)) : (num2 - (logicCheckScreenHeight / 2 + num2)));
				num += (int)p.position.X;
				num2 += (int)p.position.Y;
				Vector2 vector = new Vector2(num, num2);
				float num3 = Main.npc[i].position.X - vector.X;
				float num4 = Main.npc[i].position.Y - vector.Y;
				float num5 = (float)Math.Sqrt(num3 * num3 + num4 * num4);
				num5 = 8f / num5;
				num3 *= num5;
				num4 *= num5;
				Projectile.NewProjectile((float)num, (float)num2, num4, num5, ModContent.ProjectileType<Projectiles.PumpkinHead>(), dmg, kb, p.whoAmI, (float)i, 0f);
			}
		}

    }
}