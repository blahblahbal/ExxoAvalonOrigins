using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class MissileBolt : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Missile Bolt");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/MissileBolt");
        Projectile.MaxUpdates = 1;
        Projectile.width = dims.Width * 10 / 38;
        Projectile.height = dims.Height * 10 / 38 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.alpha = 0;
    }

    public override void AI()
    {
        if ((Projectile.type == ModContent.ProjectileType<MissileBolt>() && Projectile.ai[1] < 45f) || (Projectile.type != ModContent.ProjectileType<VileSpit>() && Projectile.type != ModContent.ProjectileType<RottenBullet>() && Projectile.type != ModContent.ProjectileType<PatellaBullet>() && Projectile.type != ModContent.ProjectileType<Soundwave>() && Projectile.type != ModContent.ProjectileType<FeroziumBullet>() && Projectile.type != ModContent.ProjectileType<Electrobullet>() && Projectile.type != ModContent.ProjectileType<SpikeCannon>() && Projectile.type != ModContent.ProjectileType<PathogenBullet>() && Projectile.type != ModContent.ProjectileType<MagmaticBullet>() && Projectile.type != ModContent.ProjectileType<TritonBullet>() && Projectile.type != ModContent.ProjectileType<FocusBeam>() && Projectile.type != ModContent.ProjectileType<VileSpit>() && Projectile.type != ModContent.ProjectileType<InfectiousSpore>()))
        {
            Projectile.ai[0] += 1f;
        }
        if (Projectile.type == ModContent.ProjectileType<MissileBolt>())
        {
            if (Projectile.localAI[0] == 0f)
            {
                Projectile.localAI[1] = Projectile.velocity.ToRotation();
                Projectile.localAI[0] = Projectile.velocity.Length();
            }
            Projectile.ai[1] += 1f;
            if (Projectile.ai[1] < 45f)
            {
                Projectile.velocity.Y = Projectile.velocity.Y + 0.02f;
            }
            if (Projectile.ai[1] == 45f)
            {
                var value = Projectile.Center;
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.direction * -0.4f, -1.4f, 0, default(Color), 1f);
                var num48 = 1.5f;
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Smoke, Projectile.direction * -0.4f, -1.4f, 0, default(Color), num48);
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.direction * -0.4f, 1.4f, 0, default(Color), 1f);
                num48 = 1.5f;
                Dust.NewDust(value - Projectile.velocity, Projectile.width, Projectile.height, DustID.Smoke, Projectile.direction * -0.4f, 1.4f, 0, default(Color), num48);
                Projectile.velocity = Projectile.localAI[1].ToRotationVector2() * Projectile.localAI[0] * 2.1f;
            }
            else
            {
                for (var num49 = 0; num49 < 5; num49++)
                {
                    var num50 = Projectile.velocity.X / 3f * num49;
                    var num51 = Projectile.velocity.Y / 3f * num49;
                    var num52 = 4;
                    var num53 = Dust.NewDust(new Vector2(Projectile.position.X + num52, Projectile.position.Y + num52), Projectile.width - num52 * 2, Projectile.height - num52 * 2, DustID.Torch, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num53].noGravity = true;
                    Main.dust[num53].velocity *= 0.1f;
                    Main.dust[num53].velocity += Projectile.velocity * 0.1f;
                    var dust5 = Main.dust[num53];
                    dust5.position.X = dust5.position.X - num50;
                    var dust6 = Main.dust[num53];
                    dust6.position.Y = dust6.position.Y - num51;
                }
                if (Main.rand.Next(5) == 0)
                {
                    var num54 = 4;
                    var num55 = Dust.NewDust(new Vector2(Projectile.position.X + num54, Projectile.position.Y + num54), Projectile.width - num54 * 2, Projectile.height - num54 * 2, DustID.Smoke, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num55].velocity *= 0.25f;
                    Main.dust[num55].velocity += Projectile.velocity * 0.5f;
                }
            }
        }
        else
        {
            if (Projectile.ai[0] >= 15f)
            {
                Projectile.ai[0] = 15f;
                Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
            }
        }
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}