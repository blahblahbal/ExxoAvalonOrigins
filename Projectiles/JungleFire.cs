using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class JungleFire : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Jungle Fire");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/JungleFire");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.light = 0.8f;
        Projectile.alpha = 100;
        Projectile.DamageType = DamageClass.Magic;
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] >= 6f)
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
        return false;
    }

    public override void AI()
    {
        if (Projectile.type == ModContent.ProjectileType<DarkFlame>())
        {
            var num150 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Enchanted_Pink, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1f);
            Main.dust[num150].noGravity = true;
            var num151 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Ash, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1f);
            Main.dust[num151].noGravity = true;
        }
        else if (Projectile.type == ModContent.ProjectileType<GoldenFlamelet>())
        {
            if (Projectile.ai[2] == 1f)
            {
                for (var num152 = 0; num152 < 2; num152++)
                {
                    var num153 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.HoneyBubbles, Projectile.velocity.X, Projectile.velocity.Y, 50, default(Color), 1.2f);
                    Main.dust[num153].noGravity = true;
                    Main.dust[num153].velocity *= 0.3f;
                }
                Projectile.alpha = 0;
            }
            else
            {
                var num154 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.velocity.X, Projectile.position.Y + Projectile.velocity.Y), Projectile.width, Projectile.height, DustID.Enchanted_Gold, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1f);
                Main.dust[num154].noGravity = true;
            }
        }
        else if (Projectile.type == ModContent.ProjectileType<JungleFire>())
        {
            for (var num157 = 0; num157 < 2; num157++)
            {
                var num158 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.RuneWizard, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num158].noGravity = true;
                var dust15 = Main.dust[num158];
                dust15.velocity.X = dust15.velocity.X * 0.3f;
                var dust16 = Main.dust[num158];
                dust16.velocity.Y = dust16.velocity.Y * 0.3f;
            }
        }
        else
        {
            for (var num159 = 0; num159 < 2; num159++)
            {
                var num160 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num160].noGravity = true;
                var dust17 = Main.dust[num160];
                dust17.velocity.X = dust17.velocity.X * 0.3f;
                var dust18 = Main.dust[num160];
                dust18.velocity.Y = dust18.velocity.Y * 0.3f;
            }
        }
        if (Projectile.type != ModContent.ProjectileType<DarkFlame>())
        {
            Projectile.ai[1] += 1f;
        }
        if (Projectile.type == ModContent.ProjectileType<GoldenFlamelet>() && Projectile.ai[2] == 1f)
        {
            Projectile.ai[1] -= 1f;
        }
        if (Projectile.ai[1] >= 20f)
        {
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
        Projectile.rotation += 0.3f * Projectile.direction;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}