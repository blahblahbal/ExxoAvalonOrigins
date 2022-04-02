using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class KunzitePulseBolt : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Kunzite Pulse Bolt");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/KunzitePulseBolt");
        Projectile.width = dims.Width * 4 / 1;
        Projectile.height = dims.Height * 4 / 1 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = 6;
        Projectile.alpha = 255;
        Projectile.MaxUpdates = 2;
        Projectile.scale = 1.2f;
        Projectile.timeLeft = 600;
        Projectile.DamageType = DamageClass.Ranged;
    }

    public override void AI()
    {
        if (Projectile.type == ModContent.ProjectileType<KunzitePulseBolt>())
        {
            if (Projectile.alpha < 170)
            {
                for (var n = 0; n < 10; n++)
                {
                    var x = Projectile.position.X - Projectile.velocity.X / 10f * n;
                    var y = Projectile.position.Y - Projectile.velocity.Y / 10f * n;
                    var num25 = Dust.NewDust(new Vector2(x, y), 1, 1, DustID.UnusedWhiteBluePurple, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num25].alpha = Projectile.alpha;
                    Main.dust[num25].position.X = x;
                    Main.dust[num25].position.Y = y;
                    Main.dust[num25].velocity *= 0f;
                    Main.dust[num25].noGravity = true;
                }
            }
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 25;
            }
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }
        }
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}