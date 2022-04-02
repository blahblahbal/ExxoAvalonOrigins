using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class BombSkeleton : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bomb");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BombSkeleton");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height * 22 / 48 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.hostile = true;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Ranged;
        Main.projFrames[Projectile.type] = 2;
    }

    public override void AI()
    {
        Projectile.velocity = Vector2.Normalize(Main.player[Player.FindClosest(Projectile.position, Projectile.width, Projectile.height)].Center - Projectile.Center) * 3f;
        if (Projectile.velocity.Y > 10f)
        {
            Projectile.velocity.Y = 10f;
        }
        if (Projectile.localAI[0] == 0f)
        {
            Projectile.localAI[0] = 1f;
            SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
        }
        Projectile.frameCounter++;
        if (Projectile.frameCounter > 3)
        {
            Projectile.frame++;
            Projectile.frameCounter = 0;
        }
        if (Projectile.frame > 1)
        {
            Projectile.frame = 0;
        }
        if (Projectile.velocity.Y == 0f)
        {
            Projectile.position.X = Projectile.position.X + Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
            Projectile.width = 128;
            Projectile.height = 128;
            Projectile.position.X = Projectile.position.X - Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;
            Projectile.damage = 70;
            Projectile.knockBack = 8f;
            Projectile.timeLeft = 3;
            Projectile.netUpdate = true;
        }
        if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
        {
            Projectile.tileCollide = false;
            Projectile.ai[1] = 0f;
            Projectile.alpha = 255;
        }
        else
        {
            if (Main.rand.Next(2) == 0)
            {
                var num300 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num300].scale = 0.1f + Main.rand.Next(5) * 0.1f;
                Main.dust[num300].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
                Main.dust[num300].noGravity = true;
                Main.dust[num300].position = Projectile.Center + new Vector2(0f, -(float)Projectile.height / 2f).RotatedBy(Projectile.rotation, default(Vector2)) * 1.1f;
                Main.rand.Next(2);
                num300 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num300].scale = 1f + Main.rand.Next(5) * 0.1f;
                Main.dust[num300].noGravity = true;
                Main.dust[num300].position = Projectile.Center + new Vector2(0f, -(float)Projectile.height / 2f - 6f).RotatedBy(Projectile.rotation, default(Vector2)) * 1.1f;
            }
        }
        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] > 5f)
        {
            Projectile.ai[0] = 10f;
            if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
            {
                Projectile.velocity.X = Projectile.velocity.X * 0.97f;
                if (Projectile.velocity.X > -0.01 && Projectile.velocity.X < 0.01)
                {
                    Projectile.velocity.X = 0f;
                    Projectile.netUpdate = true;
                }
            }
            Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
        }
    }
}