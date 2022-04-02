using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class SkeletonHeadbomb : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Skeleton Headbomb");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/SkeletonHeadbomb");
        Projectile.width = dims.Width * 22 / 26;
        Projectile.height = dims.Height * 22 / 26 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.hostile = true;
        Projectile.penetrate = 1;
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
}