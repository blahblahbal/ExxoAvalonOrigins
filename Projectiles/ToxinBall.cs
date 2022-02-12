using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ToxinBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toxin Splash");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/ToxinBall");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.light = 0.2f;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 5f)
            {
                projectile.ai[0] = 5f;
                if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
                {
                    projectile.velocity.X *= 0.97f;
                    if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
                    {
                        projectile.velocity.X = 0f;
                        projectile.netUpdate = true;
                    }
                }
                projectile.velocity.Y += 0.2f;
            }
            projectile.rotation += projectile.velocity.X * 0.1f;

            if ((double)projectile.velocity.Y < 0.25 && (double)projectile.velocity.Y > 0.15)
                projectile.velocity.X *= 0.8f;

            projectile.rotation = (0f - projectile.velocity.X) * 0.05f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.NewProjectile(projectile.Center, new Vector2(0f, projectile.velocity.Y), ModContent.ProjectileType<Projectiles.ToxinSplash>(), projectile.damage, projectile.knockBack, projectile.owner);
            return true;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 180);
        }
    }
}