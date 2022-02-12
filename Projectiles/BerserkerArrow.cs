using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BerserkerArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Arrow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BerserkerArrow");
            projectile.penetrate = 4;
            projectile.width = dims.Width * 10 / 32;
            projectile.height = dims.Height * 10 / 32 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.ranged = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate > 0)
            {
                float x = projectile.position.X + Main.rand.Next(-400, 400);
                float y = projectile.position.Y - Main.rand.Next(600, 900);
                Vector2 vector3 = new Vector2(x, y);
                float num125 = projectile.position.X + projectile.width / 2 - vector3.X;
                float num126 = projectile.position.Y + projectile.height / 2 - vector3.Y;
                int num127 = 22;
                float num128 = (float)Math.Sqrt(num125 * num125 + num126 * num126);
                num128 = num127 / num128;
                num125 *= num128;
                num126 *= num128;
                int num129 = projectile.damage;
                num129 = (int)(num129 * 0.5f);
                int num130 = Projectile.NewProjectile(x, y, num125, num126, 92, num129, projectile.knockBack, projectile.owner, 0f, 0f);
                if (projectile.type == 91 || projectile.type == 459)
                {
                    Main.projectile[num130].ai[1] = projectile.position.Y;
                    Main.projectile[num130].ai[0] = 1f;
                }
                else
                {
                    Main.projectile[num130].ai[1] = projectile.position.Y;
                }
                projectile.velocity = -oldVelocity;
                projectile.penetrate--;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int num121 = 0; num121 < 10; num121++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 119, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 150, default, 1.2f);
            }
        }
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 15f)
            {
                projectile.ai[0] = 15f;
                projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
