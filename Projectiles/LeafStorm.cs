using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class LeafStorm : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("LeafStorm");
    }

    public override void SetDefaults()
    {
        Projectile.width = 10;
        Projectile.height = 10;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.alpha = 255;
        Projectile.timeLeft = 1200;
        Projectile.DamageType = DamageClass.Magic;
    }

    public override void AI()
    {
        float num998 = 900f;
        if (Projectile.soundDelay == 0)
        {
            Projectile.soundDelay = -1;
            SoundEngine.PlaySound(SoundID.Item82, Projectile.Center);
        }
        Projectile.ai[0]++;
        if (Projectile.ai[0] >= num998)
        {
            Projectile.Kill();
        }
        if (Projectile.localAI[0] >= 30f)
        {
            Projectile.damage = 0;
            if (Projectile.ai[0] < num998 - 120f)
            {
                float num999 = Projectile.ai[0] % 60f;
                Projectile.ai[0] = num998 - 120f + num999;
                Projectile.netUpdate = true;
            }
        }
        float num1000 = 15f;
        float num1001 = 15f;
        Point point5 = Projectile.Center.ToTileCoordinates();
        Collision.ExpandVertically(point5.X, point5.Y, out int topY, out int bottomY, (int)num1000, (int)num1001);
        topY++;
        bottomY--;
        Vector2 value68 = new Vector2(point5.X, topY) * 16f + new Vector2(8f);
        Vector2 value69 = new Vector2(point5.X, bottomY) * 16f + new Vector2(8f);
        Vector2 vector105 = Vector2.Lerp(value68, value69, 0.5f);
        Vector2 value70 = new Vector2(0f, value69.Y - value68.Y);
        value70.X = value70.Y * 0.2f;
        Projectile.width = (int)(value70.X * 0.65f);
        Projectile.height = (int)value70.Y;
        Projectile.Center = vector105;
        if (Projectile.owner == Main.myPlayer)
        {
            bool flag60 = false;
            Vector2 center13 = Main.player[Projectile.owner].Center;
            Vector2 top = Main.player[Projectile.owner].Top;
            for (float num1002 = 0f; num1002 < 1f; num1002 += 0.05f)
            {
                Vector2 position8 = Vector2.Lerp(value68, value69, num1002);
                if (Collision.CanHitLine(position8, 0, 0, center13, 0, 0) || Collision.CanHitLine(position8, 0, 0, top, 0, 0))
                {
                    flag60 = true;
                    break;
                }
            }
            if (!flag60 && Projectile.ai[0] < num998 - 120f)
            {
                float num1003 = Projectile.ai[0] % 60f;
                Projectile.ai[0] = num998 - 120f + num1003;
                Projectile.netUpdate = true;
            }
        }
        if (!(Projectile.ai[0] < num998 - 120f))
        {
            return;
        }
        for (int num1004 = 0; num1004 < 1; num1004++)
        {
            float value71 = -0.5f;
            float value72 = 0.9f;
            float amount3 = Main.rand.NextFloat();
            Vector2 value73 = new Vector2(MathHelper.Lerp(0.1f, 1f, Main.rand.NextFloat()), MathHelper.Lerp(value71, value72, amount3));
            value73.X *= MathHelper.Lerp(2.2f, 0.6f, amount3);
            value73.X *= -1f;
            Vector2 value74 = new Vector2(6f, 10f);
            Vector2 position9 = vector105 + value70 * value73 * 0.5f + value74;
            Dust dust48 = Main.dust[Dust.NewDust(position9, 0, 0, DustID.Sandnado, default, default, default, Color.DarkGreen)]; // prolly needs a new dust type
            dust48.position = position9;
            dust48.customData = vector105 + value74;
            dust48.fadeIn = 1f;
            dust48.scale = 0.3f;
            if (value73.X > -1.2f)
            {
                dust48.velocity.X = 1f + Main.rand.NextFloat();
            }
            dust48.velocity.Y = Main.rand.NextFloat() * -0.5f - 1f;
            Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), dust48.position + new Vector2(20 + Main.rand.Next(-10, 11), (55 + Main.rand.Next(-10, 11)) * -1f), new Vector2((float)(Main.rand.Next(-500, 501) / 100), (float)(Main.rand.Next(-500, 501) / 100)), ModContent.ProjectileType<Projectiles.Leaves>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
        }
    }
}
