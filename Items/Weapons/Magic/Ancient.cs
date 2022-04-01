using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
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
            Rectangle dims = this.GetDims();
            Item.DamageType = DamageClass.Magic;
            Item.damage = 46;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shootSpeed = 10f;
            Item.crit += 2;
            Item.mana = 19;
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 25;
            Item.knockBack = 4f;
            Item.shoot = ModContent.ProjectileType<Projectiles.AncientSandstorm>();
            Item.UseSound = SoundID.Item34;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 25, 0, 0);
            Item.useAnimation = 25;
            Item.height = dims.Height;
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
            Item ancient = Item;
            int baseCost = 19;
            if (player.Avalon().ancientLessCost)
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
