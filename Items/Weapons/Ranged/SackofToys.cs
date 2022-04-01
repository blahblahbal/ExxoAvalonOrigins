using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class SackofToys : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sack of Toys");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 45;
            Item.color = Color.Red;
            Item.shootSpeed = 14f;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.useTime = 24;
            Item.knockBack = 4.5f;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.useAnimation = 24;
            Item.height = dims.Height;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
            ref float knockBack)
        {
            int num164 = Main.rand.Next(14);
            if (num164 == 0)
            {
                for (int num165 = 0; num165 < 2; num165++)
                {
                    float num166 = speedX;
                    float num167 = speedY;
                    num166 += (float)Main.rand.Next(-30, 31) * 0.05f;
                    num167 += (float)Main.rand.Next(-30, 31) * 0.05f;
                    Projectile.NewProjectile(position.X, position.Y, num166, num167, ProjectileID.WoodenArrowFriendly, damage, knockBack, player.whoAmI, 0f, 0f);
                }
            }
            else if (num164 == 1)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.FireArrow, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 2)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Shuriken, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 3)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.JestersArrow, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 4)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.EnchantedBoomerang, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 5)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Bullet, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 6)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.BallofFire, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 7)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.BallOHurt, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 8)
            {
                for (int num168 = 0; num168 < 2; num168++)
                {
                    float num169 = speedX;
                    float num170 = speedY;
                    num169 += (float)Main.rand.Next(-30, 31) * 0.05f;
                    num170 += (float)Main.rand.Next(-30, 31) * 0.05f;
                    Projectile.NewProjectile(position.X, position.Y, num169, num170, ProjectileID.WaterBolt, damage, knockBack, player.whoAmI, 0f, 0f);
                }
            }
            else if (num164 == 9)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.Grenade, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 10)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.ThornChakram, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 11)
            {
                int num171 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.HarpyFeather, damage, knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[num171].hostile = false;
                Main.projectile[num171].friendly = true;
            }
            else if (num164 == 12)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.DemonScythe, damage, knockBack, player.whoAmI, 0f, 0f);
            }
            else if (num164 == 13)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.PoisonedKnife, damage, knockBack, player.whoAmI, 0f, 0f);
            }

            return false;
        }
    }
}
