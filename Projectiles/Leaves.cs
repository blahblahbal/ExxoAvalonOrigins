using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class Leaves : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Leaves");
    }

    public override void SetDefaults()
    {
        Projectile.width = 7;
        Projectile.height = 7;
        Projectile.scale = 1.2f;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = 7;
        Projectile.timeLeft = 600;
        Projectile.alpha = 50;
        Projectile.aiStyle = 1;
    }

    public override void AI()
    {
        Projectile.rotation += Projectile.velocity.X * 0.2f;
        Projectile.ai[1] += 1f;
        Projectile.velocity *= 0.96f;
        if (Projectile.ai[1] > 15f)
        {
            Projectile.scale -= 0.05f;
            if ((double)Projectile.scale <= 0.2)
            {
                Projectile.scale = 0.2f;
                Projectile.active = false;
            }
        }
    }
}