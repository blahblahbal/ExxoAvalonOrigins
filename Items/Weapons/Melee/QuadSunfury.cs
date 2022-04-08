using System;
using System.Collections.Generic;
using ExxoAvalonOrigins.Systems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

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
        Item.width = 52;
        Item.height = 48;
        Item.useStyle = 5;
        Item.useTime = Item.useAnimation = 61;
        Item.channel = true;
        Item.damage = 45;
        Item.knockBack = 8;
        Item.scale = 1.1f;
        Item.UseSound = SoundID.Item1;
        Item.rare = 5;
        Item.noUseGraphic = true;
        Item.noMelee = true;
        Item.DamageType = DamageClass.Melee;
        Item.value = 999000;
        Item.shootSpeed = 12f;
        Item.shoot = ModContent.ProjectileType<Projectiles.Melee.QuadBall>();
    }
    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        List<string> assignedKeys = KeybindSystem.ModeChangeHotkey.GetAssignedKeys();

        var assignedKeyInfo = new TooltipLine(Mod, "Controls:PromptKey", "Press " + (assignedKeys.Count > 0 ? string.Join(", ", assignedKeys) : "[c/565656:<Unbound>]") + " to change attack modes");
        tooltips.Add(assignedKeyInfo);

        if (!(assignedKeys.Count > 0))
        {
            var unboundKeyInfo = new TooltipLine(Mod, "Controls:PromptKeyInfo", "[c/900C3F:Please bind hotkey in the settings to change attack modes!]");
            tooltips.Add(unboundKeyInfo);
        }
    }
    public override void HoldItem(Player player)
    {
        if (KeybindSystem.ModeChangeHotkey.JustPressed)
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
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        done = false;
        if (mode == 2)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X, position.Y, -velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, -velocity.Y, type, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position.X, position.Y, -velocity.X, -velocity.Y, type, damage, knockback, player.whoAmI);
        }
        if (mode == 3)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<Projectiles.Melee.MegaQuadBall>(), damage, knockback, player.whoAmI);
        }

        if (mode == 4)
        {
            int amt = 4;
            int spread = 24;
            float mult = 0.1f;
            for (int i = 0; i < amt; i++)
            {
                float
                    vX = velocity.X + Main.rand.Next(-spread, spread + 1) * mult,
                    vY = velocity.Y + Main.rand.Next(-spread, spread + 1) * mult;
                Projectile.NewProjectile(source, position.X, position.Y, vX, vY, type, damage, knockback, player.whoAmI);
            }
        }
        return false;
    }

    public override void UseStyle(Player player, Rectangle r)
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
                Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.GetDamage(DamageClass.Melee)), 8, PID);
            }

            if (timer == 16)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.GetDamage(DamageClass.Melee)), 8, PID);
            }

            if (timer == 31)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.GetDamage(DamageClass.Melee)), 8, PID);
            }

            if (timer == 46)
            {
                Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.position.X + player.width / 2, player.position.Y + player.height / 2, speedX, speedY, ModContent.ProjectileType<Projectiles.Melee.QuadBall>(), (int)(player.inventory[player.selectedItem].damage * player.GetDamage(DamageClass.Melee)), 8, PID);
                timer = 0;
                done = true;
            }
        }
    }
}
