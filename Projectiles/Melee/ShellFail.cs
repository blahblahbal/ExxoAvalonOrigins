using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class ShellFail : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shell Fail");
        }
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.aiStyle = 0;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
        }
    }
}
