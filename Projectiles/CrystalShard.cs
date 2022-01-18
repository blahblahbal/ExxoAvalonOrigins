using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class CrystalShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Shard");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/CrystalShard");
            projectile.aiStyle = 14;
            projectile.width = 20;
            projectile.height = 20;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.alpha = 255;
            projectile.timeLeft = 180;
            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity.X = oldVelocity.X * -0.1f;
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = oldVelocity.X * -0.5f;
            }
            if (projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 1f)
            {
                projectile.velocity.Y = oldVelocity.Y * -0.5f;
            }
            return false;
        }
        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] > 5f)
            {
                projectile.ai[0] = 5f;
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
            projectile.rotation += projectile.velocity.X * 0.1f;
            if (projectile.type == ModContent.ProjectileType<CrystalShard>())
            {
                if (projectile.wet)
                {
                    projectile.Kill();
                }
                if (projectile.ai[1] == 0f && projectile.type == ModContent.ProjectileType<CrystalShard>())
                {
                    projectile.ai[1] = 1f;
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 13);
                }
                int d = Main.rand.Next(3);
                if (d == 0) d = DustID.BlueCrystalShard;
                if (d == 1) d = DustID.PinkCrystalShard;
                if (d == 2) d = DustID.PurpleCrystalShard;
                int num218 = Dust.NewDust(projectile.position, projectile.width, projectile.height, d, 0f, 0f, 100, default, 1f);
                Main.dust[num218].position.X -= 2f;
                Main.dust[num218].position.Y += 2f;
                Main.dust[num218].scale += Main.rand.Next(50) * 0.01f;
                Main.dust[num218].noGravity = true;
                Main.dust[num218].velocity.Y -= 2f;
                if (Main.rand.Next(5) == 0)
                {
                    int num219 = Dust.NewDust(projectile.position, projectile.width, projectile.height, d, 0f, 0f, 100, default, 1f);
                    Main.dust[num219].position.X -= 2f;
                    Main.dust[num219].position.Y += 2f;
                    Main.dust[num219].scale += 0.3f + Main.rand.Next(50) * 0.01f;
                    Main.dust[num219].noGravity = true;
                    Main.dust[num219].velocity *= 0.1f;
                }
                if (projectile.velocity.Y < 0.25 && projectile.velocity.Y > 0.15)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.8f;
                }
                projectile.rotation = -projectile.velocity.X * 0.05f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
