using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class HallowSpit : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hallow Spit");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/HallowSpit");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.hostile = true;
        Projectile.light = 0f;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = -1;
        Projectile.scale = 1f;
        Projectile.tileCollide = true;
    }
    public override void AI()
    {
        if (Projectile.alpha > 0)
        {
            Projectile.alpha -= 15;
        }
        if (Projectile.alpha < 0)
        {
            Projectile.alpha = 0;
        }
        for (int num168 = 0; num168 < 2; num168++)
        {
            int num171 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 80, default(Color), 1.3f);
            Main.dust[num171].velocity *= 0.3f;
            Main.dust[num171].noGravity = true;
        }
        if (Projectile.ai[0] >= 15f)
        {
            Projectile.ai[0] = 15f;
            Projectile.velocity.Y = Projectile.velocity.Y + 0.1f;
        }
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.NPCKilled, (int)Projectile.position.X, (int)Projectile.position.Y, 9);
        Projectile.active = false;
    }
}