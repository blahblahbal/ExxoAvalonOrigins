using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class GuardianHammer : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/GuardianHammer");
            projectile.width = dims.Width;
            projectile.height = dims.Height * 58 / 80 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 3600;
        }

        public override void AI()
        {
            if (projectile.ai[1] == 0f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
            {
                projectile.ai[1] = 1f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] != 0f)
            {
                projectile.tileCollide = true;
            }
            if (projectile.soundDelay == 0)
            {
                projectile.soundDelay = 20 + Main.rand.Next(40);
                if (projectile.type != ModContent.ProjectileType<GuardianHammer>())
                {
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 9);
                }
                else
                {
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 1);
                }
            }
            if (projectile.localAI[0] == 0f)
            {
                projectile.localAI[0] = 1f;
            }
            projectile.alpha += (int)(25f * projectile.localAI[0]);
            if (projectile.alpha > 200)
            {
                projectile.alpha = 200;
                projectile.localAI[0] = -1f;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
                projectile.localAI[0] = 1f;
            }
            if (projectile.type != ModContent.ProjectileType<GuardianHammer>())
            {
                projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.01f * projectile.direction;
            }
            if (projectile.ai[1] == 1f)
            {
                projectile.light = 0.9f;
                if (Main.rand.Next(10) == 0)
                {
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Enchanted_Pink, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 150, default(Color), 1.2f);
                }
                if (Main.rand.Next(20) == 0)
                {
                    Gore.NewGore(projectile.position, new Vector2(projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
                }
            }
        }
    }
}