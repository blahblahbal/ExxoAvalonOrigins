using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BombSkeleton : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BombSkeleton");
            projectile.width = dims.Width;
            projectile.height = dims.Height * 22 / 48 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.ranged = true;
            Main.projFrames[projectile.type] = 2;
        }

        public override void AI()
        {
            projectile.velocity = Vector2.Normalize(Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)].Center - projectile.Center) * 3f;
            if (projectile.velocity.Y > 10f)
            {
                projectile.velocity.Y = 10f;
            }
            if (projectile.localAI[0] == 0f)
            {
                projectile.localAI[0] = 1f;
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 3)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame > 1)
            {
                projectile.frame = 0;
            }
            if (projectile.velocity.Y == 0f)
            {
                projectile.position.X = projectile.position.X + projectile.width / 2;
                projectile.position.Y = projectile.position.Y + projectile.height / 2;
                projectile.width = 128;
                projectile.height = 128;
                projectile.position.X = projectile.position.X - projectile.width / 2;
                projectile.position.Y = projectile.position.Y - projectile.height / 2;
                projectile.damage = 70;
                projectile.knockBack = 8f;
                projectile.timeLeft = 3;
                projectile.netUpdate = true;
            }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.ai[1] = 0f;
                projectile.alpha = 255;
            }
            else
            {
                if (Main.rand.Next(2) == 0)
                {
                    var num300 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num300].scale = 0.1f + Main.rand.Next(5) * 0.1f;
                    Main.dust[num300].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
                    Main.dust[num300].noGravity = true;
                    Main.dust[num300].position = projectile.Center + new Vector2(0f, -(float)projectile.height / 2f).RotatedBy(projectile.rotation, default(Vector2)) * 1.1f;
                    Main.rand.Next(2);
                    num300 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num300].scale = 1f + Main.rand.Next(5) * 0.1f;
                    Main.dust[num300].noGravity = true;
                    Main.dust[num300].position = projectile.Center + new Vector2(0f, -(float)projectile.height / 2f - 6f).RotatedBy(projectile.rotation, default(Vector2)) * 1.1f;
                }
            }
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 5f)
            {
                projectile.ai[0] = 10f;
                if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.97f;
                    if (projectile.velocity.X > -0.01 && projectile.velocity.X < 0.01)
                    {
                        projectile.velocity.X = 0f;
                        projectile.netUpdate = true;
                    }
                }
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
        }
    }
}