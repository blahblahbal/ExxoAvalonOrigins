using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class ArrowBeam : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Arrow Beam");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/ArrowBeam");
        Projectile.width = dims.Width * 4 / 1;
        Projectile.height = dims.Height * 4 / 1 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.MaxUpdates = 100;
        Projectile.timeLeft = 100;
        Projectile.penetrate = -1;
    }

    public override void AI()
    {
        Projectile.localAI[0] += 1f;
        if (Projectile.localAI[0] > 9f)
        {
            for (var num617 = 0; num617 < 4; num617++)
            {
                var value12 = Projectile.position;
                value12 -= Projectile.velocity * num617 * 0.25f;
                Projectile.alpha = 255;
                var num618 = 173;
                if (Projectile.type == 503)
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