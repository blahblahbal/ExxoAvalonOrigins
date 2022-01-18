using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ArrowBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arrow Beam");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/ArrowBeam");
            projectile.width = dims.Width * 4 / 1;
            projectile.height = dims.Height * 4 / 1 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.MaxUpdates = 100;
            projectile.timeLeft = 100;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] > 9f)
            {
                for (var num617 = 0; num617 < 4; num617++)
                {
                    var value12 = projectile.position;
                    value12 -= projectile.velocity * num617 * 0.25f;
                    projectile.alpha = 255;
                    var num618 = 173;
                    if (projectile.type == 503)
                    {
                        num618 = 141;
                    }
                    var num619 = Dust.NewDust(value12, 1, 1, num618, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num619].position = value12;
                    Main.dust[num619].scale = Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[num619].velocity *= 0.2f;
                }
            }
        }
    }
}