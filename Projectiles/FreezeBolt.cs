using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class FreezeBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freeze Bolt");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/FreezeBolt");
            projectile.width = dims.Width * 12 / 16;
            projectile.height = dims.Height * 12 / 16 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.light = 0.9f;
            projectile.penetrate = 12;
            projectile.magic = true;
            projectile.timeLeft = 2400;
            projectile.ignoreWater = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.type == ModContent.ProjectileType<FreezeBolt>())
            {
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 7f)
                {
                    projectile.position += projectile.velocity;
                    projectile.Kill();
                }
                else
                {
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y;
                    }
                    if (projectile.velocity.X != oldVelocity.X)
                    {
                        projectile.velocity.X = -oldVelocity.X;
                    }
                }
            }
            return false;
        }

        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<FreezeBolt>())
            {
                for (var num917 = 0; num917 < 5; num917++)
                {
                    var num918 = projectile.velocity.X / 3f * num917;
                    var num919 = projectile.velocity.Y / 3f * num917;
                    var num920 = 4;
                    var num921 = Dust.NewDust(new Vector2(projectile.position.X + num920, projectile.position.Y + num920), projectile.width - num920 * 2, projectile.height - num920 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num921].noGravity = true;
                    Main.dust[num921].velocity *= 0.1f;
                    Main.dust[num921].velocity += projectile.velocity * 0.1f;
                    var dust105 = Main.dust[num921];
                    dust105.position.X = dust105.position.X - num918;
                    var dust106 = Main.dust[num921];
                    dust106.position.Y = dust106.position.Y - num919;
                }
                if (Main.rand.Next(5) == 0)
                {
                    var num922 = 4;
                    var num923 = Dust.NewDust(new Vector2(projectile.position.X + num922, projectile.position.Y + num922), projectile.width - num922 * 2, projectile.height - num922 * 2, DustID.MagicMirror, 0f, 0f, 100, default(Color), 0.6f);
                    Main.dust[num923].velocity *= 0.25f;
                    Main.dust[num923].velocity += projectile.velocity * 0.5f;
                }
            }
            else
            {
                for (var num926 = 0; num926 < 2; num926++)
                {
                    var num927 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num927].noGravity = true;
                    var dust107 = Main.dust[num927];
                    dust107.velocity.X = dust107.velocity.X * 0.3f;
                    var dust108 = Main.dust[num927];
                    dust108.velocity.Y = dust108.velocity.Y * 0.3f;
                }
            }
            if (projectile.type != ModContent.ProjectileType<FreezeBolt>() && projectile.type != ModContent.ProjectileType<ChaosBolt>() && projectile.type != ModContent.ProjectileType<MagmafrostBolt>())
            {
                projectile.ai[1] += 1f;
            }
            if (projectile.ai[1] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            projectile.rotation += 0.3f * projectile.direction;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
                return;
            }
        }
    }
}