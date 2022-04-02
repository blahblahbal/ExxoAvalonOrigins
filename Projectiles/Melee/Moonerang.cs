using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
        projectile.width = 18;
        projectile.height = 18;
        projectile.aiStyle = 3;
        projectile.friendly = true;
        projectile.melee = true;
        projectile.tileCollide = true;
        projectile.penetrate = 1;
        projectile.timeLeft = 300;
        drawOffsetX = -9;
        drawOriginOffsetY = -9;
    }
    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(255, 255, 255, this.projectile.alpha);
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
        projectile.Kill();
        return true;
    }
    public override void AI()
    {
        if (Main.rand.Next(3) == 0)
        {
            int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, 68, projectile.oldVelocity.X * 0.1f, projectile.oldVelocity.Y * 0.1f, default, default, 1.2f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
        }
    }
    public override void Kill(int timeLeft)
    {
        Main.PlaySound(SoundID.NPCHit, (int)projectile.Center.X, (int)projectile.Center.Y, 3, 0.8f, -0.25f);
        for (int num237 = 0; num237 < 15; num237++)
        {
            int num239 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 18, 18, 68, projectile.oldVelocity.X * 0.3f, projectile.oldVelocity.Y * 0.3f, default, default, 1.5f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
        }
    }
}