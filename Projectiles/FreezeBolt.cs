using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class FreezeBolt : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Freeze Bolt");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/FreezeBolt");
        Projectile.width = dims.Width * 12 / 16;
        Projectile.height = dims.Height * 12 / 16 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.tileCollide = true;
        Projectile.friendly = true;
        Projectile.alpha = 255;
        Projectile.light = 0.9f;
        Projectile.penetrate = 12;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.timeLeft = 2400;
        Projectile.ignoreWater = true;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.type == ModContent.ProjectileType<FreezeBolt>())
        {
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 7f)
            {
                Projectile.position += Projectile.velocity;
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
            }
        }
        return false;
    }

    public override void AI()
    {
        if (Projectile.type == ModContent.ProjectileType<FreezeBolt>())
        {
            for (var num917 = 0; num917 < 5; num917++)
            {
                var num918 = Projectile.velocity.X / 3f * num917;
                var num919 = Projectile.velocity.Y / 3f * num917;
                var num920 = 4;
                var num921 = Dust.NewDust(new Vector2(Projectile.position.X + num920, Projectile.position.Y + num920), Projectile.width - num920 * 2, Projectile.height - num920 * 2, DustID.IceTorch, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num921].noGravity = true;
                Main.dust[num921].velocity *= 0.1f;
                Main.dust[num921].velocity += Projectile.velocity * 0.1f;
                var dust105 = Main.dust[num921];
                dust105.position.X = dust105.position.X - num918;
                var dust106 = Main.dust[num921];
                dust106.position.Y = dust106.position.Y - num919;
            }
            if (Main.rand.Next(5) == 0)
            {
                var num922 = 4;
                var num923 = Dust.NewDust(new Vector2(Projectile.position.X + num922, Projectile.position.Y + num922), Projectile.width - num922 * 2, Projectile.height - num922 * 2, DustID.MagicMirror, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num923].velocity *= 0.25f;
                Main.dust[num923].velocity += Projectile.velocity * 0.5f;
            }
        }
        else
        {
            for (var num926 = 0; num926 < 2; num926++)
            {
                var num927 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num927].noGravity = true;
                var dust107 = Main.dust[num927];
                dust107.velocity.X = dust107.velocity.X * 0.3f;
                var dust108 = Main.dust[num927];
                dust108.velocity.Y = dust108.velocity.Y * 0.3f;
            }
        }
        if (Projectile.type != ModContent.ProjectileType<FreezeBolt>() && Projectile.type != ModContent.ProjectileType<ChaosBolt>() && Projectile.type != ModContent.ProjectileType<MagmafrostBolt>())
        {
            Projectile.ai[1] += 1f;
        }
        if (Projectile.ai[1] >= 20f)
        {
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
        Projectile.rotation += 0.3f * Projectile.direction;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
            return;
        }
    }
}