using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class CorruptKnife : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corrupt Knife");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/CorruptKnife");
        Projectile.width = dims.Width * 30 / 30;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.light = 0.6f;
        Projectile.ignoreWater = true;
        Projectile.extraUpdates = 0;
    }

    public override void AI()
    {
        Projectile.rotation += (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y)) * 0.03f * Projectile.direction;
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] < 30f)
        {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        }
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }

    public override void Kill(int timeLeft)
    {
        for (int num84 = 0; num84 < 2; num84++)
        {
            Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, Projectile.velocity.X, Projectile.velocity.Y, ProjectileID.TinyEater, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
        }
        for (int num85 = 0; num85 < 3; num85++)
        {
            int num86 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Water_Hallowed, 0f, 0f, 100, default(Color), 0.8f);
            Main.dust[num86].noGravity = true;
            Main.dust[num86].velocity *= 1.2f;
            Main.dust[num86].velocity -= Projectile.oldVelocity * 0.3f;
        }
    }
}