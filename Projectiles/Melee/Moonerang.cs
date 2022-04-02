using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class Moonerang : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moonerang");
    }
    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/Moonerang");
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.aiStyle = 3;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.tileCollide = true;
        Projectile.penetrate = 1;
        Projectile.timeLeft = 300;
        DrawOffsetX = -9;
        DrawOriginOffsetY = -9;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, Projectile.alpha);
    }
    public override void ModifyDamageHitbox(ref Rectangle hitbox)
    {
        int size = 10;
        hitbox.X -= size;
        hitbox.Y -= size;
        hitbox.Width += size * 2;
        hitbox.Height += size * 2;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.Kill();
        return true;
    }
    public override void AI()
    {
        if (Main.rand.Next(3) == 0)
        {
            int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, 68, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, default, default, 1.2f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
        }
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.NPCHit, (int)Projectile.Center.X, (int)Projectile.Center.Y, 3, 0.8f, -0.25f);
        for (int num237 = 0; num237 < 15; num237++)
        {
            int num239 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), 18, 18, 68, Projectile.oldVelocity.X * 0.3f, Projectile.oldVelocity.Y * 0.3f, default, default, 1.5f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
        }
    }
}
