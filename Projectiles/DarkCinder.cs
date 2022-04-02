using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class DarkCinder : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Dark Cinder");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/DarkCinder");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.hostile = true;
        Projectile.light = 0.4f;
        Projectile.alpha = 255;
        Projectile.penetrate = -1;
        Projectile.tileCollide = true;
        Projectile.ignoreWater = true;
        Projectile.timeLeft = 300;
    }

    public override void AI()
    {
        int randomDust;
        if (Main.rand.NextBool(2))
            randomDust = 58;
        else
            randomDust = 36;

        Projectile.ai[0] += 1f;
        if (Projectile.ai[0] > 5f)
        {
            Projectile.ai[0] = 5f;
            if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
            {
                Projectile.velocity.X *= 0.97f;
                if ((double)Projectile.velocity.X > -0.01 && (double)Projectile.velocity.X < 0.01)
                {
                    Projectile.velocity.X = 0f;
                    Projectile.netUpdate = true;
                }
            }
            Projectile.velocity.Y += 0.2f;
        }
        Projectile.rotation += Projectile.velocity.X * 0.1f;

        if (Main.rand.Next(3) != 0)
        {
            Dust dust6 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, randomDust);
            dust6.velocity.Y -= 2f;
            dust6.noGravity = true;
            Dust dust = dust6;
            dust.scale += Main.rand.NextFloat() * 0.8f + 0.3f;
            dust = dust6;
            dust.velocity += Projectile.velocity * 1f;
        }

        if ((double)Projectile.velocity.Y < 0.25 && (double)Projectile.velocity.Y > 0.15)
            Projectile.velocity.X *= 0.8f;

        Projectile.rotation = (0f - Projectile.velocity.X) * 0.05f;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.velocity.X != oldVelocity.X)
            Projectile.velocity.X = oldVelocity.X * -0.1f;

        if (Projectile.velocity.X != oldVelocity.X)
            Projectile.velocity.X = oldVelocity.X * -0.5f;

        if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 1f)
            Projectile.velocity.Y = oldVelocity.Y * -0.5f;

        return false;
    }
    public override void OnHitPlayer(Player target, int damage, bool crit)
    {
        target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 120);
    }
}