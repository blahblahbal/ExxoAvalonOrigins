using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SacredLyreSplittingNote3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lyre Note");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SacredLyreSplittingNote3");
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = 21;
            projectile.magic = true;
            projectile.light = 0.8f;
            projectile.penetrate = -1;
            projectile.friendly = true;
            projectile.timeLeft = 360;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 150);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.type == ModContent.ProjectileType<SacredLyreSplittingNote3>())
            {
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
                projectile.ai[0] += 1f;
                if (projectile.ai[0] >= 9f)
                {
                    projectile.position += projectile.velocity;
                    projectile.Kill();
                }
                else
                {
                    if (projectile.velocity.Y != oldVelocity.Y)
                    {
                        projectile.velocity.Y = -oldVelocity.Y;
                    }
                    if (projectile.velocity.X != oldVelocity.X)
                    {
                        projectile.velocity.X = -oldVelocity.X;
                    }
                }
            }
            return false;
        }
    }
}
