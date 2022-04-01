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
            Projectile.width = dims.Width * 16 / 134;
            Projectile.height = dims.Height * 16 / 134 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.hostile = true;
            Projectile.light = 0f;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.scale = 1f;
            Projectile.tileCollide = true;
            Main.projFrames[Projectile.type] = 4;
        }

        public override void AI()
        {
            if (Projectile.type == ModContent.ProjectileType<InfectiousSpore>())
            {
                Projectile.frameCounter++;
                if (Projectile.frameCounter >= 6)
                {
                    Projectile.frame++;
                    Projectile.frameCounter = 0;
                }
                if (Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
    }
}