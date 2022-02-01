using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class UltrabrightRazorbladeBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultrabright Razorblade Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/UltrabrightRazorbladeBullet");
            projectile.width = dims.Width * 4 / 20;
            projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.light = 3f;
            projectile.alpha = 0;
            projectile.scale = 1.2f;
            projectile.timeLeft = 1200;
            projectile.ranged = true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num200 = 0; num200 < 7; num200++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.DungeonSpirit, 0f, 0f, 100, default(Color), 1.5f);
            }
            for (int i = 0; i < 2; i++)
            {
                float num134 = -projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                float num135 = -projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                Projectile.NewProjectile(projectile.position.X + num134, projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<UltrabrightRazorbladeBulletTyphoon>(), projectile.damage, 0f, projectile.owner, 0f, 0f);
            }
        }
        public override void AI()
        {
            if (projectile.type != ModContent.ProjectileType<UltrabrightRazorbladeBullet>())
            {
                projectile.ai[0] += 1f;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
