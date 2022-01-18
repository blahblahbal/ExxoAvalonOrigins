using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class VerticalLaserBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vertical Laser Beam");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/VerticalLaserBeam");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.alpha = 50;
            projectile.magic = true;
        }

        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 100f)
            {
                projectile.rotation = 0f;
                projectile.ai[0] = 0f;
                projectile.Kill();
                return;
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.rotation -= 0.002f;
                projectile.velocity.X = projectile.velocity.X + 0.5f;
                return;
            }
            if (projectile.ai[1] == 1f)
            {
                projectile.rotation += 0.002f;
                projectile.velocity.X = projectile.velocity.X - 0.5f;
                return;
            }
        }
    }
}