﻿using Microsoft.Xna.Framework;
    public class BlahBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BlahBullet");
            projectile.width = dims.Width * 4 / 20;
            projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.light = 0.8f;
            projectile.alpha = 255;
            projectile.MaxUpdates = 2;
            projectile.scale = 1f;
            projectile.timeLeft = 600;
            projectile.ranged = true;
        }
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            for (int num200 = 0; num200 < 7; num200++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
            }
            for (int num201 = 0; num201 < 3; num201++)
            {
                int num202 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num202].noGravity = true;
                Main.dust[num202].velocity *= 3f;
                num202 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num202].velocity *= 2f;
            }
            int num203 = Gore.NewGore(new Vector2(projectile.position.X - 10f, projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num203].velocity *= 0.3f;
            Gore expr_639C_cp_0 = Main.gore[num203];
            expr_639C_cp_0.velocity.X = expr_639C_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
            Gore expr_63CA_cp_0 = Main.gore[num203];
            expr_63CA_cp_0.velocity.Y = expr_63CA_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
            if (projectile.owner == Main.myPlayer)
            {
                for (int num133 = 0; num133 < 3; num133++)
                {
                    float num134 = -projectile.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                    float num135 = -projectile.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.9f;
                    Projectile.NewProjectile(projectile.position.X + num134, projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<BlahBulletOffspring>(), projectile.damage, 0f, projectile.owner, 0f, 0f);
                }
            }
            if (projectile.owner == Main.myPlayer)
            {
                projectile.localAI[1] = -1f;
                projectile.maxPenetrate = 0;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 80;
                projectile.height = 80;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.Damage();
            }
        }