using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Bones : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bones");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Bones");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.scale = 1.2f;
            projectile.friendly = true;
            projectile.magic = true;
        }

        public override void AI()
        {
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * projectile.direction;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 30f)
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