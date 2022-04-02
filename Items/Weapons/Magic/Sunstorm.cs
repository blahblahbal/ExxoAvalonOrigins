using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic;

class Sunstorm : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sunstorm");
        Tooltip.SetDefault("Fires beams from the sun itself");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.DamageType = DamageClass.Magic;
        Item.damage = 50;
        Item.scale = 1.1f;
        Item.shootSpeed = 12f;
        Item.mana = 17;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 60;
        Item.knockBack = 6f;
        Item.shoot = ModContent.ProjectileType<Projectiles.VerticalLaserBeam>();
        Item.value = 999000;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.useAnimation = 60;
        Item.height = dims.Height;
        Item.UseSound = SoundID.Item8;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage,
                               ref float knockBack)
    {
        for (int num144 = 0; num144 < 12; num144++)
        {
            float num145 = position.X + Main.rand.Next(-400, 400);
            float num146 = position.Y - 200f;
            float num147 = position.X + player.width / 2 - num145;
            float num148 = position.Y + player.height / 2 - num146;
            num147 += Main.rand.Next(-100, 101);
            int num149 = 23;
            float num150 = (float)Math.Sqrt(num147 * num147 + num148 * num148);
            num150 = num149 / num150;
            num147 *= num150;
            num148 *= num150;
            int num151 = Projectile.NewProjectile(num145, num146, num147, 0f, type, damage, knockBack, player.whoAmI, 0f, 0f);
            Main.projectile[num151].ai[1] = Main.rand.Next(2);
        }

        return false;
    }
}