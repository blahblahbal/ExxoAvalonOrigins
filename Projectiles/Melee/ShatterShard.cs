using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class ShatterShard : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shatter Shard");
    }
    public override void SetDefaults()
    {
        Projectile.penetrate = 1;
        Projectile.width = 16;
        Projectile.height = 16;
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.timeLeft = 45;
        Projectile.scale = 1.2f;
    }
    public override void AI()
    {
        Projectile.spriteDirection = Projectile.direction;
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Main.rand.Next(2) == 0)
        {
            int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, 70, -0.5f, -0.5f, default, default, 1f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
        }
    }
    public override void ModifyDamageHitbox(ref Rectangle hitbox)
    {
        int size = 10;
        hitbox.X -= size;
        hitbox.Y -= size;
        hitbox.Width += size * 2;
        hitbox.Height += size * 2;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, 150);
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.Center.X, (int)Projectile.Center.Y, 27, 0.8f, -0.25f);
        for (int num237 = 0; num237 < 10; num237++)
        {
            int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, 70, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, default, default, 1.2f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
        }
        for (int num237 = 0; num237 < 10; num237++)
        {
            int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, 70, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, default, default, 1.2f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
        }
    }
}