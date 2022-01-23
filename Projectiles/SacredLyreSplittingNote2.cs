using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SacredLyreSplittingNote2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lyre Note");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SacredLyreSplittingNote2");
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
            if (projectile.type == ModContent.ProjectileType<SacredLyreSplittingNote2>())
            {
                //Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
                for (int num133 = 0; num133 < 2; num133++)
                {
                    float num134 = -projectile.velocity.X * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                    float num135 = -projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                    int proj = Projectile.NewProjectile(projectile.position.X + num134, projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<SacredLyreSplittingNote3>(), (int)(projectile.damage * 0.8), 0f, projectile.owner, 0f, 0f);
                }
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
