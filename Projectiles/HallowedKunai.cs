using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class HallowedKunai : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Kunai");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/HallowedKunai");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 3;
            projectile.light = 0.7f;
            projectile.alpha = 0;
            projectile.scale = 1f;
            projectile.timeLeft = 3600;
            projectile.ranged = true;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (projectile.type == ProjectileID.MagicDagger && Main.rand.Next(5) == 0)
            {
                var num58 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Enchanted_Gold, projectile.velocity.X * 0.2f + projectile.direction * 3, projectile.velocity.Y * 0.2f, 100, default(Color), 0.3f);
                var dust7 = Main.dust[num58];
                dust7.velocity.X = dust7.velocity.X * 0.3f;
                var dust8 = Main.dust[num58];
                dust8.velocity.Y = dust8.velocity.Y * 0.3f;
            }
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.4f;
                projectile.velocity.X = projectile.velocity.X * 0.97f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
