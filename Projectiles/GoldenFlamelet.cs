using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class GoldenFlamelet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Golden Flamelet");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.scale = 1;
            projectile.alpha = 100;
            projectile.aiStyle = 8;
            projectile.timeLeft = 600;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.light = 0.8f;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.hostile = false;
            projectile.knockBack = 4;
        }
    }
}