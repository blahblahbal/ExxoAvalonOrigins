using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SpikeShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spike Shard");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SpikeShard");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.light = 0.5f;
            projectile.scale = 1.2f;
            projectile.timeLeft = 600;
            projectile.ranged = true;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            projectile.light = projectile.scale * 0.5f;
            projectile.rotation += projectile.velocity.X * 0.2f;
            projectile.ai[1] += 1f;
            projectile.velocity *= 0.96f;
            if (projectile.ai[1] > 15f)
            {
                projectile.scale -= 0.05f;
                if (projectile.scale <= 0.2)
                {
                    projectile.scale = 0.2f;
                    projectile.Kill();
                }
            }
        }
    }
}
