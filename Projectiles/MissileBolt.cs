using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class MissileBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Missile Bolt");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/MissileBolt");
            projectile.MaxUpdates = 1;
            projectile.width = dims.Width * 10 / 38;
            projectile.height = dims.Height * 10 / 38 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.alpha = 0;
        }

        public override void AI()
        {
            if ((projectile.type == ModContent.ProjectileType<MissileBolt>() && projectile.ai[1] < 45f) || (projectile.type != ModContent.ProjectileType<VileSpit>() && projectile.type != ModContent.ProjectileType<RottenBullet>() && projectile.type != ModContent.ProjectileType<PatellaBullet>() && projectile.type != ModContent.ProjectileType<Soundwave>() && projectile.type != ModContent.ProjectileType<FeroziumBullet>() && projectile.type != ModContent.ProjectileType<Electrobullet>() && projectile.type != ModContent.ProjectileType<SpikeCannon>() && projectile.type != ModContent.ProjectileType<PathogenBullet>() && projectile.type != ModContent.ProjectileType<MagmaticBullet>() && projectile.type != ModContent.ProjectileType<TritonBullet>() && projectile.type != ModContent.ProjectileType<FocusBeam>() && projectile.type != ModContent.ProjectileType<VileSpit>() && projectile.type != ModContent.ProjectileType<InfectiousSpore>()))
            {
                projectile.ai[0] += 1f;
            }
            if (projectile.type == ModContent.ProjectileType<MissileBolt>())
            {
                if (projectile.localAI[0] == 0f)
                {
                    projectile.localAI[1] = projectile.velocity.ToRotation();
                    projectile.localAI[0] = projectile.velocity.Length();
                }
                projectile.ai[1] += 1f;
                if (projectile.ai[1] < 45f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + 0.02f;
                }
                if (projectile.ai[1] == 45f)
                {
                    var value = projectile.Center;
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.direction * -0.4f, -1.4f, 0, default(Color), 1f);
                    var num48 = 1.5f;
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Smoke, projectile.direction * -0.4f, -1.4f, 0, default(Color), num48);
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.direction * -0.4f, 1.4f, 0, default(Color), 1f);
                    num48 = 1.5f;
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Smoke, projectile.direction * -0.4f, 1.4f, 0, default(Color), num48);
                    projectile.velocity = projectile.localAI[1].ToRotationVector2() * projectile.localAI[0] * 2.1f;
                }
                else
                {
                    for (var num49 = 0; num49 < 5; num49++)
                    {
                        var num50 = projectile.velocity.X / 3f * num49;
                        var num51 = projectile.velocity.Y / 3f * num49;
                        var num52 = 4;
                        var num53 = Dust.NewDust(new Vector2(projectile.position.X + num52, projectile.position.Y + num52), projectile.width - num52 * 2, projectile.height - num52 * 2, DustID.Fire, 0f, 0f, 100, default(Color), 1.2f);
                        Main.dust[num53].noGravity = true;
                        Main.dust[num53].velocity *= 0.1f;
                        Main.dust[num53].velocity += projectile.velocity * 0.1f;
                        var dust5 = Main.dust[num53];
                        dust5.position.X = dust5.position.X - num50;
                        var dust6 = Main.dust[num53];
                        dust6.position.Y = dust6.position.Y - num51;
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                        var num54 = 4;
                        var num55 = Dust.NewDust(new Vector2(projectile.position.X + num54, projectile.position.Y + num54), projectile.width - num54 * 2, projectile.height - num54 * 2, DustID.Smoke, 0f, 0f, 100, default(Color), 0.6f);
                        Main.dust[num55].velocity *= 0.25f;
                        Main.dust[num55].velocity += projectile.velocity * 0.5f;
                    }
                }
            }
            else
            {
                if (projectile.ai[0] >= 15f)
                {
                    projectile.ai[0] = 15f;
                    projectile.velocity.Y = projectile.velocity.Y + 0.1f;
                }
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}