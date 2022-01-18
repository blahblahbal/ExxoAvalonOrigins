using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Leaves : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaves");
        }

        public override void SetDefaults()
        {
            projectile.width = 7;
            projectile.height = 7;
            projectile.scale = 1.2f;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 7;
            projectile.timeLeft = 600;
            projectile.alpha = 50;
            projectile.aiStyle = 1;
        }

        public override void AI()
        {
            projectile.rotation += projectile.velocity.X * 0.2f;
            projectile.ai[1] += 1f;
            projectile.velocity *= 0.96f;
            if (projectile.ai[1] > 15f)
            {
                projectile.scale -= 0.05f;
                if ((double)projectile.scale <= 0.2)
                {
                    projectile.scale = 0.2f;
                    projectile.active = false;
                }
            }
        }
    }
}