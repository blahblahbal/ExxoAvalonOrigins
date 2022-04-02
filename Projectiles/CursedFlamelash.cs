using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class CursedFlamelash : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Cursed Flamelash");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/CursedFlamelash");
        Projectile.width = dims.Width * 14 / 16;
        Projectile.height = dims.Height * 14 / 16 / Main.projFrames[Projectile.type];
        Projectile.friendly = true;
        Projectile.light = 0.8f;
        Projectile.DamageType = DamageClass.Magic;
        DrawOriginOffsetY = -6;
    }
    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.CursedInferno, 180);
    }
    public override Color? GetAlpha(Color lightColor) => new Color(96, 248, 2, 0);

    public override void AI()
    {
        if (Projectile.soundDelay == 0 && Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) > 2f)
        {
            Projectile.soundDelay = 10;
            SoundEngine.PlaySound(SoundID.Item9, Projectile.position);
        }

        Dust dust;
        Vector2 position = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
        dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 107, 0f, 0f, 0, new Color(255, 255, 255), 1f)];


        if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
        {

            Player player = Main.player[Projectile.owner];
            if (player.channel)
            {
                float maxDistance = 18f;
                Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                float distanceToCursor = vectorToCursor.Length();

                if (distanceToCursor > maxDistance)
                {
                    distanceToCursor = maxDistance / distanceToCursor;
                    vectorToCursor *= distanceToCursor;
                }

                int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
                int oldVelocityXBy1000 = (int)(Projectile.velocity.X * 1000f);
                int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
                int oldVelocityYBy1000 = (int)(Projectile.velocity.Y * 1000f);

                if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
                {
                    Projectile.netUpdate = true;
                }

                Projectile.velocity = vectorToCursor;

            }
            else if (Projectile.ai[0] == 0f)
            {

                Projectile.netUpdate = true;

                float maxDistance = 14f;
                Vector2 vectorToCursor = Main.MouseWorld - Projectile.Center;
                float distanceToCursor = vectorToCursor.Length();

                if (distanceToCursor == 0f)
                {
                    vectorToCursor = Projectile.Center - player.Center;
                    distanceToCursor = vectorToCursor.Length();
                }

                distanceToCursor = maxDistance / distanceToCursor;
                vectorToCursor *= distanceToCursor;

                Projectile.velocity = vectorToCursor;

                if (Projectile.velocity == Vector2.Zero)
                {
                    Projectile.Kill();
                }

                Projectile.ai[0] = 1f;
            }
        }

        if (Projectile.velocity != Vector2.Zero)
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
        }
    }

    public override void Kill(int timeLeft)
    {
        if (Projectile.penetrate == 1)
        {
            Projectile.maxPenetrate = -1;
            Projectile.penetrate = -1;

            int explosionArea = 60;
            Vector2 oldSize = Projectile.Size;
            Projectile.position = Projectile.Center;
            Projectile.Size += new Vector2(explosionArea);
            Projectile.Center = Projectile.position;

            Projectile.tileCollide = false;
            Projectile.velocity *= 0.01f;
            Projectile.Damage();
            Projectile.scale = 0.01f;

            Projectile.position = Projectile.Center;
            Projectile.Size = new Vector2(10);
            Projectile.Center = Projectile.position;
        }

        SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        for (int i = 0; i < 10; i++)
        {
            Dust dust;
            Vector2 position = Projectile.Center + new Vector2(Main.rand.Next(-4, 5), Main.rand.Next(-4, 5));
            dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 107, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.velocity *= 2f;
            dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 107, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
        }
    }
}