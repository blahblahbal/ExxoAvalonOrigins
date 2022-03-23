using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{    
    public class ShatterBolt : ModProjectile 
    {
    //unused for now
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shatter Bolt");
		}
        public override void SetDefaults()
        {
			projectile.alpha = 255;
            projectile.friendly = true;
            projectile.hostile = false;
			projectile.timeLeft = 240;
			projectile.width = 4;
			projectile.height = 4;
			projectile.tileCollide = true;
			projectile.extraUpdates = 3;
			projectile.penetrate = 5;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 60;
            projectile.damage = 80;
		}
        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                int num239 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 18, 18, 70, -0.5f, -0.5f, default, default, 1f);
                Dust dust30 = Main.dust[num239];
                dust30.noGravity = true;
                dust30.velocity = new Vector2(0f, 0f);
            }
        }
    }
}
		
