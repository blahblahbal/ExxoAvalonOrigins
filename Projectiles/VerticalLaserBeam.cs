using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class VerticalLaserBeam : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Vertical Laser Beam");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/VerticalLaserBeam");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
        Projectile.alpha = 50;
        Projectile.DamageType = DamageClass.Magic;
    }

    public override void AI()
    {
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] >= 100f)
        {
            Projectile.rotation = 0f;
            Projectile.ai[0] = 0f;
            Projectile.Kill();
            return;
        }
        if (Projectile.ai[1] == 0f)
        {
            Projectile.rotation -= 0.002f;
            Projectile.velocity.X = Projectile.velocity.X + 0.5f;
            return;
        }
        if (Projectile.ai[1] == 1f)
        {
            Projectile.rotation += 0.002f;
            Projectile.velocity.X = Projectile.velocity.X - 0.5f;
            return;
        }
    }
}