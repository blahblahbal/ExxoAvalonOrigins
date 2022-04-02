using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class SpikeShard : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spike Shard");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/SpikeShard");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 3;
        Projectile.light = 0.5f;
        Projectile.scale = 1.2f;
        Projectile.timeLeft = 600;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        Projectile.light = Projectile.scale * 0.5f;
        Projectile.rotation += Projectile.velocity.X * 0.2f;
        Projectile.ai[1] += 1f;
        Projectile.velocity *= 0.96f;
        if (Projectile.ai[1] > 15f)
        {
            Projectile.scale -= 0.05f;
            if (Projectile.scale <= 0.2)
            {
                Projectile.scale = 0.2f;
                Projectile.Kill();
            }
        }
    }
}