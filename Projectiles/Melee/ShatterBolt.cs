using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee;

public class ShatterBolt : ModProjectile 
{
    //unused for now
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Shatter Bolt");
    }
    public override void SetDefaults()
    {
        Projectile.alpha = 255;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.timeLeft = 240;
        Projectile.width = 4;
        Projectile.height = 4;
        Projectile.tileCollide = true;
        Projectile.extraUpdates = 3;
        Projectile.penetrate = 5;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 60;
        Projectile.damage = 80;
    }
    public override void AI()
    {
        if (Main.rand.Next(2) == 0)
        {
            int num239 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y), 18, 18, 70, -0.5f, -0.5f, default, default, 1f);
            Dust dust30 = Main.dust[num239];
            dust30.noGravity = true;
            dust30.velocity = new Vector2(0f, 0f);
        }
    }
}