using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class BerserkerArrow : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Berserker Arrow");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BerserkerArrow");
        Projectile.penetrate = 4;
        Projectile.width = dims.Width * 10 / 32;
        Projectile.height = dims.Height * 10 / 32 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.penetrate > 0)
        {
            float x = Projectile.position.X + Main.rand.Next(-400, 400);
            float y = Projectile.position.Y - Main.rand.Next(600, 900);
            Vector2 vector3 = new Vector2(x, y);
            float num125 = Projectile.position.X + Projectile.width / 2 - vector3.X;
            float num126 = Projectile.position.Y + Projectile.height / 2 - vector3.Y;
            int num127 = 22;
            float num128 = (float)Math.Sqrt(num125 * num125 + num126 * num126);
            num128 = num127 / num128;
            num125 *= num128;
            num126 *= num128;
            int num129 = Projectile.damage;
            num129 = (int)(num129 * 0.5f);
            int num130 = Projectile.NewProjectile(Projectile.GetProjectileSource_FromThis(), x, y, num125, num126, 92, num129, Projectile.knockBack, Projectile.owner, 0f, 0f);
            if (Projectile.type == 91 || Projectile.type == 459)
            {
                Main.projectile[num130].ai[1] = Projectile.position.Y;
                Main.projectile[num130].ai[0] = 1f;
            }
            else
            {
                Main.projectile[num130].ai[1] = Projectile.position.Y;
            }
            Projectile.velocity = -oldVelocity;
            Projectile.penetrate--;
        }
        return false;
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
        for (int num121 = 0; num121 < 10; num121++)
        {
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 119, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 150, default, 1.2f);
        }
    }
    public override void AI()
    {
        Projectile.ai[0] += 1f;
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
}
