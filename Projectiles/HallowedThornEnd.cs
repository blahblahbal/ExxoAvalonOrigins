using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class HallowedThornEnd : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Thorn");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/HallowedThornEnd");
            projectile.width = dims.Width * 28 / 32;
            projectile.height = dims.Height * 28 / 32 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.alpha = 255;
            projectile.ignoreWater = true;
            projectile.magic = true;
        }

        public override void AI()
        {
            var vector73 = projectile.position + new Vector2(projectile.width / 2, projectile.height / 2);
            projectile.position -= projectile.velocity;
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57079637f;
            if (projectile.ai[0] == 0f)
            {
                projectile.alpha -= 50;
                if (projectile.alpha <= 0)
                {
                    projectile.alpha = 0;
                    projectile.ai[0] = 1f;
                    if (projectile.ai[1] == 0f)
                    {
                        projectile.ai[1] += 1f;
                        projectile.position += projectile.velocity * 1f;
                    }
                    if (projectile.type == ModContent.ProjectileType<HallowedThorn>() && Main.myPlayer == projectile.owner)
                    {
                        var num928 = ModContent.ProjectileType<HallowedThorn>();
                        if (projectile.ai[1] >= 11f)
                        {
                            num928 = ModContent.ProjectileType<HallowedThornEnd>();
                        }
                        else
                        {
                            num928 = ModContent.ProjectileType<HallowedThorn>();
                        }
                        if ((int)projectile.ai[1] % 3 == 0)
                        {
                            var point = new Vector2(projectile.velocity.X, projectile.velocity.Y);
                            var num929 = 0.3926991f * (float)Main.rand.NextDouble();
                            projectile.velocity = projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().RotateAboutOrigin(point, num929);
                            var num930 = Projectile.NewProjectile(vector73.X + projectile.velocity.X, vector73.Y + projectile.velocity.Y, projectile.velocity.X, projectile.velocity.Y, num928, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                            var nprojectile = Main.projectile[num930];
                            nprojectile.damage = projectile.damage;
                            projectile.ai[1] = projectile.ai[1] + 1f;
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num930, 0f, 0f, 0f, 0);
                            num929 = 0.3926991f * (float)Main.rand.NextDouble();
                            projectile.velocity = projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().RotateAboutOrigin(point, -num929);
                            num930 = Projectile.NewProjectile(vector73.X + projectile.velocity.X, vector73.Y + projectile.velocity.Y, projectile.velocity.X, projectile.velocity.Y, num928, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                            nprojectile = Main.projectile[num930];
                            nprojectile.damage = projectile.damage;
                            nprojectile.ai[1] = projectile.ai[1] + 1f;
                            NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num930, 0f, 0f, 0f, 0);
                            return;
                        }
                        var num931 = Projectile.NewProjectile(vector73.X + projectile.velocity.X, vector73.Y + projectile.velocity.Y, projectile.velocity.X, projectile.velocity.Y, num928, projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                        var projectile2 = Main.projectile[num931];
                        projectile2.damage = projectile.damage;
                        projectile2.ai[1] = projectile.ai[1] + 1f;
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), num931, 0f, 0f, 0f, 0);
                        return;
                    }
                }
            }
            else
            {
                if (projectile.alpha < 170 && projectile.alpha + 5 >= 170)
                {
                    for (var num932 = 0; num932 < 3; num932++)
                    {
                        Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Enchanted_Gold, projectile.velocity.X * 0.025f, projectile.velocity.Y * 0.025f, 170, default(Color), 1.2f);
                    }
                    Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Enchanted_Gold, 0f, 0f, 170, default(Color), 1.1f);
                }
                projectile.alpha += 5;
                if (projectile.alpha >= 255)
                {
                    projectile.Kill();
                    return;
                }
            }
        }
    }
}