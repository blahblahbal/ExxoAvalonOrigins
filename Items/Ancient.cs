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
	class Ancient : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient");
			Tooltip.SetDefault("Creates a sandstorm");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Ancient");
			item.magic = true;
			item.damage = 46;
			item.autoReuse = true;
			item.useTurn = true;
			item.shootSpeed = 10f;
			item.crit += 2;
			item.mana = 19;
			item.rare = ItemRarityID.Yellow;
			item.noMelee = true;
			item.width = dims.Width;
			item.useTime = 25;
			item.knockBack = 4f;
			item.shoot = ModContent.ProjectileType<Projectiles.AncientSandstorm>();
			item.UseSound = SoundID.Item34;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.value = Item.sellPrice(0, 25, 0, 0);
			item.useAnimation = 25;
			item.height = dims.Height;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            float num175 = 14f;
            float num176 = (float)Main.mouseX + Main.screenPosition.X - (player.position.X + (float)player.width * 0.5f) + (float)Main.rand.Next(-10, 11);
            float num177 = (float)Main.mouseY + Main.screenPosition.Y - (player.position.Y + (float)player.height * 0.5f) + (float)Main.rand.Next(-10, 11);
            float num178 = (float)Math.Sqrt((double)(num176 * num176 + num177 * num177));
            num178 = num175 / num178;
            num176 *= num178;
            num177 *= num178;
            for (int num179 = 0; num179 < 2; num179++)
            {
                float num180 = speedX;
                float num181 = speedY;
                num180 += (float)Main.rand.Next(-15, 16) * 0.05f;
                num181 += (float)Main.rand.Next(-15, 16) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, num176, num177, type, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
        public override void HoldItem(Player player)
        {
			Item ancient = item;
			int baseCost = 19;
			if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ancientLessCost)
            {
				foreach (Item item in player.inventory)
				{
					if (item.type == ancient.type)
					{
						item.mana = 9;
						break;
					}
				}
			}
			else
            {
				foreach (Item item in player.inventory)
                {
					if (item.type == ancient.type)
                    {
						item.mana = baseCost;
						break;
                    }
                }
            }
        }
    }
}