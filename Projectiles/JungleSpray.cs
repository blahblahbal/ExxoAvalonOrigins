using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class JungleSpray : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Jungle Spray");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/JungleSpray");
        Projectile.width = dims.Width * 6 / 16;
        Projectile.height = dims.Height * 6 / 16 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.alpha = 255;
        Projectile.penetrate = -1;
        Projectile.MaxUpdates = 2;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
    }

    public override void AI()
    {
        var num500 = 110;
        var num501 = 0;
        if (Projectile.type == ProjectileID.HallowSpray)
        {
            num500 = 111;
            num501 = 2;
        }
        if (Projectile.type == ProjectileID.CorruptSpray)
        {
            num500 = 112;
            num501 = 1;
        }
        if (Projectile.type == ProjectileID.MushroomSpray)
        {
            num500 = 113;
            num501 = 3;
        }
        if (Projectile.type == ProjectileID.CrimsonSpray)
        {
            num500 = 114;
            num501 = 4;
        }
        if (Projectile.type == ModContent.ProjectileType<JungleSpray>())
        {
            num500 = 226;
            num501 = 5;
        }
        if (Projectile.type == ModContent.ProjectileType<ContagionSpray>())
        {
            num500 = 237;
            num501 = 6;
        }
        if (Projectile.owner == Main.myPlayer)
        {
            WorldGen.Convert((int)(Projectile.position.X + Projectile.width / 2) / 16, (int)(Projectile.position.Y + Projectile.height / 2) / 16, num501, 2);
        }
        if (Projectile.timeLeft > 133)
        {
            Projectile.timeLeft = 133;
        }
        if (Projectile.ai[0] > 7f)
        {
            var num502 = 1f;
            if (Projectile.ai[0] == 8f)
            {
                num502 = 0.2f;
            }
            else if (Projectile.ai[0] == 9f)
            {
                num502 = 0.4f;
            }
            else if (Projectile.ai[0] == 10f)
            {
                num502 = 0.6f;
            }
            else if (Projectile.ai[0] == 11f)
            {
                num502 = 0.8f;
            }
            Projectile.ai[0] += 1f;
            for (var num503 = 0; num503 < 1; num503++)
            {
                var num504 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num500, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                Main.dust[num504].noGravity = true;
                Main.dust[num504].scale *= 1.75f;
                var dust57 = Main.dust[num504];
                dust57.velocity.X = dust57.velocity.X * 2f;
                var dust58 = Main.dust[num504];
                dust58.velocity.Y = dust58.velocity.Y * 2f;
                Main.dust[num504].scale *= num502;
            }
        }
        else
        {
            Projectile.ai[0] += 1f;
        }
        Projectile.rotation += 0.3f * Projectile.direction;
    }
}