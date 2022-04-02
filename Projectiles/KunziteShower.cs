using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class KunziteShower : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Kunzite Shower");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/KunziteShower");
        Projectile.width = dims.Width * 32 / 16;
        Projectile.height = dims.Height * 32 / 16 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.alpha = 255;
        Projectile.penetrate = 5;
        Projectile.MaxUpdates = 2;
        Projectile.ignoreWater = true;
        Projectile.DamageType = DamageClass.Magic;
    }

    public override void AI()
    {
        if (Projectile.type == ProjectileID.GoldenShowerHostile && Projectile.localAI[0] == 0f)
        {
            Projectile.localAI[0] = 1f;
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 17);
        }
        if (Projectile.type != ModContent.ProjectileType<KunziteShower>())
        {
            Projectile.scale -= 0.02f;
        }
        else
        {
            Projectile.scale -= 0.002f;
        }
        if (Projectile.scale <= 0f)
        {
            Projectile.Kill();
        }
        if (Projectile.ai[0] > 3f)
        {
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
            for (var num216 = 0; num216 < 1; num216++)
            {
                for (var num217 = 0; num217 < 3; num217++)
                {
                    var num218 = Projectile.velocity.X / 3f * num217;
                    var num219 = Projectile.velocity.Y / 3f * num217;
                    var num220 = 6;
                    var num221 = 172;
                    if (Projectile.type == ModContent.ProjectileType<KunziteShower>())
                    {
                        num221 = 141;
                    }
                    var num222 = Dust.NewDust(new Vector2(Projectile.position.X + num220, Projectile.position.Y + num220), Projectile.width - num220 * 2, Projectile.height - num220 * 2, num221, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num222].noGravity = true;
                    Main.dust[num222].velocity *= 0.3f;
                    Main.dust[num222].velocity += Projectile.velocity * 0.5f;
                    var dust29 = Main.dust[num222];
                    dust29.position.X = dust29.position.X - num218;
                    var dust30 = Main.dust[num222];
                    dust30.position.Y = dust30.position.Y - num219;
                }
                if (Main.rand.Next(8) == 0)
                {
                    var num223 = 6;
                    var num224 = 172;
                    if (Projectile.type == ModContent.ProjectileType<KunziteShower>())
                    {
                        num224 = 141;
                    }
                    var num225 = Dust.NewDust(new Vector2(Projectile.position.X + num223, Projectile.position.Y + num223), Projectile.width - num223 * 2, Projectile.height - num223 * 2, num224, 0f, 0f, 100, default(Color), 0.75f);
                    Main.dust[num225].velocity *= 0.5f;
                    Main.dust[num225].velocity += Projectile.velocity * 0.5f;
                }
            }
        }
        else
        {
            Projectile.ai[0] += 1f;
        }
    }
}