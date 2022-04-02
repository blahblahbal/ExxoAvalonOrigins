using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class EnchantedShuriken : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Enchanted Shuriken");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/EnchantedShuriken");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 6;
        Projectile.DamageType = DamageClass.Ranged;
    }

    public override void AI()
    {
        Projectile.rotation += (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y)) * 0.03f * Projectile.direction;
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] >= 20f)
        {
            Projectile.velocity.Y = Projectile.velocity.Y + 0.4f;
            Projectile.velocity.X = Projectile.velocity.X * 0.97f;
        }
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Dig, (int)Projectile.position.X, (int)Projectile.position.Y);
        for (int i = 0; i < 15; i++)
        {
            var Sparkle = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), 8, 8, DustID.MagicMirror, 0f, 0f, 100, default(Color), 1.25f);
            Main.dust[Sparkle].velocity *= 0.8f;
        }
        if (Projectile.owner == Main.myPlayer)
        {
            // Drop a javelin item, 1 in 18 chance (~5.5% chance)
            Item.NewItem(Projectile.GetItemSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<Items.Weapons.Throw.EnchantedShuriken>());
        }
    }
}
