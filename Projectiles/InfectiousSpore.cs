using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class InfectiousSpore : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infectious Spore");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/InfectiousSpore");
            projectile.width = dims.Width * 16 / 134;
            projectile.height = dims.Height * 16 / 134 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.light = 0f;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.scale = 1f;
            projectile.tileCollide = true;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<InfectiousSpore>())
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}