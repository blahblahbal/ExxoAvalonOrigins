using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SpikyBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiky Ball");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SpikyBall");
            projectile.width = dims.Width * 8 / 16;
            projectile.height = dims.Height * 8 / 16 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.alpha = 0;
            projectile.MaxUpdates = 1;
            projectile.scale = 1f;
            projectile.timeLeft = 300;
            projectile.ranged = true;
        }

        public override void AI()
        {
            projectile.ai[0]++;
            if (projectile.ai[0] >= 240)
            {

                Vector2 offset = new Vector2(projectile.Center.X + 20, projectile.Center.Y + 20);
                Vector2 offset2 = new Vector2(projectile.Center.X - 20, projectile.Center.Y - 20);
                Vector2 offset3 = new Vector2(projectile.Center.X + 20, projectile.Center.Y - 20);
                Vector2 offset4 = new Vector2(projectile.Center.X - 20, projectile.Center.Y + 20);
                float rotation = (float)Math.Atan2(projectile.Center.Y - offset.Y, projectile.Center.X - offset.X);
                float rotation2 = (float)Math.Atan2(projectile.Center.Y - offset2.Y, projectile.Center.X - offset2.X);
                float rotation3 = (float)Math.Atan2(projectile.Center.Y - offset3.Y, projectile.Center.X - offset3.X);
                float rotation4 = (float)Math.Atan2(projectile.Center.Y - offset4.Y, projectile.Center.X - offset4.X);
                float speed = 8f;
                int p;

                if (projectile.ai[0] % 10 == 0)
                {
                    if (projectile.ai[1] <= 7.2f)
                    {
                        p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)((Math.Cos(rotation - projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation - projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)((Math.Cos(rotation2 - projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation2 - projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)((Math.Cos(rotation3 - projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation3 - projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)((Math.Cos(rotation4 - projectile.ai[1]) * speed) * -1), (float)((Math.Sin(rotation4 - projectile.ai[1]) * speed) * -1), ModContent.ProjectileType<Spike>(), 60, 0f);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        Main.projectile[p].owner = projectile.owner;
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.Empty, p);
                        }
                        if (projectile.ai[1] >= 7.2f)
                        {
                            projectile.ai[0] = 0;
                            projectile.ai[1] = 0;
                        }
                    }
                    projectile.ai[1] += .18f;
                }
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 8f)
            {
                projectile.velocity.Y = 8f;
            }
        }
    }
}
