using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class BerserkerCrystal : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker Crystal");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BerserkerCrystal");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.light = 0.5f;
        Projectile.alpha = 50;
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
        if (Projectile.type == ProjectileID.CrystalStorm)
        {
            if (Main.rand.Next(4) == 0)
            {
                var num353 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PurpleCrystalShard, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num353].noGravity = true;
                Main.dust[num353].velocity *= 0.5f;
                Main.dust[num353].scale *= 0.9f;
            }
            Projectile.velocity *= 0.985f;
            if (Projectile.ai[1] > 130f)
            {
                Projectile.scale -= 0.05f;
                if (Projectile.scale <= 0.2)
                {
                    Projectile.scale = 0.2f;
                    Projectile.Kill();
                }
            }
        }
        else
        {
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
}