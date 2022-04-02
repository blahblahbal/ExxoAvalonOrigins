using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee;

public class ShellHammer : ModItem
{
    int fireDelay = 90;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shell Hammer");
        Tooltip.SetDefault("Lobs shells");
    }
    public override void SetDefaults()
    {
        Item.width = Item.height = 56;
        //item.projFireDelay = 240;
        Item.knockBack = 12f;
        Item.DamageType = // item.useTurn = item.autoReuse = true /* tModPorter - this is redundant, for more info see https://github.com/tModLoader/tModLoader/wiki/Update-Migration-Guide#damage-classes */ ;
            Item.rare = 7;
        Item.UseSound = SoundID.Item1;
        Item.useStyle = Item.maxStack = 1;
        Item.useAnimation = Item.useTime = 35;
        //item.shoot = ModContent.ProjectileType<Projectiles.Shell>();
        Item.shootSpeed = 5.5f;
        Item.damage = 87;
        Item.value = Item.sellPrice(0, 6, 20, 0);
    }
    public override void HoldItem(Player player)
    {
        if (fireDelay > 0 && player.itemAnimation > 0) fireDelay--;
        if (fireDelay == 0)
        {
            float velX = Main.mouseX + Main.screenPosition.X - player.Center.X;
            float velY = Main.mouseY + Main.screenPosition.Y - player.Center.Y;
            if (player.gravDir == -1f)
            {
                velY = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - player.Center.Y;
            }
            float v = MathHelper.Clamp(velX, -7f, 7f);
            if (v < 0 && v > -5f) v = -5f;
            if (v > 0 && v < 5f) v = 5f;
            int p = Projectile.NewProjectile(player.position.X, player.position.Y, v, -4f, ModContent.ProjectileType<Projectiles.Melee.Shell>(), 87, 6f);
            Main.projectile[p].owner = player.whoAmI;
            fireDelay = 90;
        }
    }
}