using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class LightningTrail : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.scale = 1f;
            Projectile.alpha = 100;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 100;
            Projectile.friendly = true;
            Projectile.penetrate = 100;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.alpha = 255 - (Projectile.timeLeft * 2) - (int)(25 * Projectile.scale);
            if (Projectile.alpha < 100) Projectile.alpha = 0;
        }
    }
}