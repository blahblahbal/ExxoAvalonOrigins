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
	class AeonsEternity : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeon's Eternity");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AeonsEternity");
			item.damage = 36;
			item.scale = 1.1f;
			item.melee = true;
			item.autoReuse = true;
			item.useTurn = true;
			item.rare = ItemRarityID.Pink;
			item.width = dims.Width;
			item.height = dims.Height;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.AeonBeam2>();
			item.shootSpeed = 9f;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				int num208 = Main.rand.Next(3);
				if (num208 == 0)
				{
					num208 = 15;
				}
				else if (num208 == 1)
				{
					num208 = 57;
				}
				else if (num208 == 2)
				{
					num208 = 58;
				}
				int num209 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, num208);
				Dust dust = Main.dust[num209];
				dust.velocity *= 0.2f;
				dust.scale = 1.3f;
			}
		}
	}
}