using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class InfectedMist : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infected Mist");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/InfectedMist");
            projectile.width = dims.Width * 30 / 16;
            projectile.height = dims.Height * 30 / 16 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 6;
            projectile.light = 0.2f;
        }

        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<InfectedMist>())
            {
                projectile.velocity *= 0.96f;
                projectile.alpha += 3;
                if (projectile.alpha > 255)
                {
                    projectile.Kill();
                }
            }
            else if (projectile.type == ProjectileID.SporeCloud)
            {
                projectile.velocity *= 0.96f;
                projectile.alpha += 4;
                if (projectile.alpha > 255)
                {
                    projectile.Kill();
                }
            }
            else if (projectile.type == ProjectileID.ChlorophyteOrb)
            {
                if (projectile.ai[0] == 0f)
                {
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
                }
                projectile.ai[0] += 1f;
                if (projectile.ai[0] > 20f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + 0.3f;
                    projectile.velocity.X = projectile.velocity.X * 0.98f;
                }
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }
            if (projectile.frame >= Main.projFrames[projectile.type])
            {
                projectile.frame = 0;
            }
        }
    }
}