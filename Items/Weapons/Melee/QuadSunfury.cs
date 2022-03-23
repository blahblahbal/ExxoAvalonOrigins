using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    public class QuadSunfury : ModItem
    {
        private byte mode = 1;
        private byte timer = 0;
        private bool done = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quad Sunfury");
        }
        public override void SetDefaults()
        {
            item.width = 52;
            item.height = 48;
            item.useStyle = 5;
            item.useTime = item.useAnimation = 61;
            item.channel = true;
            item.damage = 45;
            item.knockBack = 8;
            item.scale = 1.1f;
            item.UseSound = SoundID.Item1;
            item.rare = 5;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.melee = true;
            item.value = 999000;
            item.shootSpeed = 12f;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.QuadBall>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            List<string> assignedKeys = ExxoAvalonOrigins.Mod.ModeChangeHotkey.GetAssignedKeys();

            var assignedKeyInfo = new TooltipLine(mod, "Controls:PromptKey", "Press " + (assignedKeys.Count > 0 ? string.Join(", ", assignedKeys) : "[c/565656:<Unbound>]") + " to change attack modes");
            tooltips.Add(assignedKeyInfo);

            if (!(assignedKeys.Count > 0))
            {
                var unboundKeyInfo = new TooltipLine(mod, "Controls:PromptKeyInfo", "[c/900C3F:Please bind hotkey in the settings to change attack modes!]");
                tooltips.Add(unboundKeyInfo);
            }
        }
        public override void HoldItem(Player player)
        {
            if (ExxoAvalonOrigins.Mod.ModeChangeHotkey.JustPressed)
            {
                mode++;
                if (mode == 1)
                {
                    Main.NewText("Mode: Volley attack");
                }

                if (mode == 2)
                {
                    Main.NewText("Mode: X spread");
                }

                if (mode == 3)
                {
                    Main.NewText("Mode: Mega flail");
                }

                if (mode == 4)
                {
                    Main.NewText("Mode: Spread attack");
                }
            }
            if (mode > 4)
            {
                mode = 1;
                done = false;
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            done = false;
            if (mode == 2)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, -speedX, speedY, type, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, speedX, -speedY, type, damage, knockBack, player.whoAmI);
                Projectile.NewProjectile(position.X, position.Y, -speedX, -speedY, type, damage, knockBack, player.whoAmI);
            }
            if (mode == 3)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.MegaQuadBall>(), damage, knockBack, player.whoAmI);
            }

            if (mode == 4)
            {
                int amt = 4;
                int spread = 24;
                float mult = 0.1f;
                for (int i = 0; i < amt; i++)
                {
                    float
                        vX = speedX + Main.rand.Next(-spread, spread + 1) * mult,
                        vY = speedY + Main.rand.Next(-spread, spread + 1) * mult;
                    Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, player.whoAmI);
                }
            }
            return false;
        }

        public override void UseStyle(Player player)
        {
            int PID = player.whoAmI;
            float
                num48 = 12f,
                speedX = (Main.mouseX + Main.screenPosition.X) - (player.position.X + player.width / 2),
                speedY = (Main.mouseY + Main.screenPosition.Y) - (player.position.Y + player.height / 2),
                num51 = (float)Math.Sqrt((speedX * speedX) + (speedY * speedY));
            num51 = num48 / num51;
            speedX *= num51;
            speedY *= num51;
            if (mode == 1 && !done)
            {
                timer++;
                if (timer == 1)
                {
                    Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.meleeDamage), 8, PID);
                }

                if (timer == 16)
                {
                    Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.meleeDamage), 8, PID);
                }

                if (timer == 31)
                {
                    Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.meleeDamage), 8, PID);
                }

                if (timer == 46)
                {
                    Projectile.NewProjectile(player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.meleeDamage), 8, PID);
                    timer = 0;
                    done = true;
                }
            }
        }
    }
}
