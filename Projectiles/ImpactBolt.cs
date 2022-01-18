using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ImpactBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impact Bolt");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/ImpactBolt");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.magic = true;
            projectile.MaxUpdates = 100;
            projectile.timeLeft = 100;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.immuneTime = 8;
        }
        public override void AI()
        {
            if (projectile.type == ProjectileID.MagnetSphereBolt)
            {
                for (var num611 = 0; num611 < 4; num611++)
                {
                    var value9 = projectile.position;
                    value9 -= projectile.velocity * num611 * 0.25f;
                    projectile.alpha = 255;
                    var num612 = Dust.NewDust(value9, 1, 1, DustID.MagnetSphere, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num612].position = value9;
                    var dust63 = Main.dust[num612];
                    dust63.position.X = dust63.position.X + projectile.width / 2;
                    var dust64 = Main.dust[num612];
                    dust64.position.Y = dust64.position.Y + projectile.height / 2;
                    Main.dust[num612].scale = Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[num612].velocity *= 0.2f;
                }
            }
            else if (projectile.type == ModContent.ProjectileType<ImpactBolt>())
            {
                for (var num613 = 0; num613 < 4; num613++)
                {
                    var value10 = projectile.position;
                    value10 -= projectile.velocity * num613 * 0.25f;
                    projectile.alpha = 255;
                    var num614 = Dust.NewDust(value10, 1, 1, DustID.MagnetSphere, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num614].position = value10;
                    var dust65 = Main.dust[num614];
                    dust65.position.X = dust65.position.X + projectile.width / 2;
                    var dust66 = Main.dust[num614];
                    dust66.position.Y = dust66.position.Y + projectile.height / 2;
                    Main.dust[num614].scale = Main.rand.Next(70, 110) * 0.013f;
                    Main.dust[num614].velocity *= 0.2f;
                }
            }
            else if (projectile.type == ProjectileID.ShadowBeamHostile)
            {
                if (projectile.localAI[0] == 0f)
                {
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
                }
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] > 3f)
                {
                    for (var num615 = 0; num615 < 3; num615++)
                    {
                        var value11 = projectile.position;
                        value11 -= projectile.velocity * num615 * 0.3334f;
                        projectile.alpha = 255;
                        var num616 = Dust.NewDust(value11, 1, 1, DustID.ShadowbeamStaff, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num616].position = value11;
                        Main.dust[num616].scale = Main.rand.Next(70, 110) * 0.013f;
                        Main.dust[num616].velocity *= 0.2f;
                    }
                }
            }
            else if (projectile.type == ModContent.ProjectileType<ArrowBeam>())
            {
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] > 9f)
                {
                    for (var num617 = 0; num617 < 4; num617++)
                    {
                        var value12 = projectile.position;
                        value12 -= projectile.velocity * num617 * 0.25f;
                        projectile.alpha = 255;
                        var num618 = 173;
                        if (projectile.type == ModContent.ProjectileType<ArrowBeam>())
                        {
                            num618 = 141;
                        }
                        var num619 = Dust.NewDust(value12, 1, 1, num618, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num619].position = value12;
                        Main.dust[num619].scale = Main.rand.Next(70, 110) * 0.013f;
                        Main.dust[num619].velocity *= 0.2f;
                    }
                }
            }
            else
            {
                projectile.localAI[0] += 1f;
                if (projectile.localAI[0] > 3f)
                {
                    for (var num620 = 0; num620 < 4; num620++)
                    {
                        var value13 = projectile.position;
                        value13 -= projectile.velocity * num620 * 0.25f;
                        projectile.alpha = 255;
                        var num621 = Dust.NewDust(value13, 1, 1, DustID.HeatRay, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num621].position = value13;
                        var dust67 = Main.dust[num621];
                        dust67.position.X = dust67.position.X + projectile.width / 2;
                        var dust68 = Main.dust[num621];
                        dust68.position.Y = dust68.position.Y + projectile.height / 2;
                        Main.dust[num621].scale = Main.rand.Next(70, 110) * 0.013f;
                        Main.dust[num621].velocity *= 0.2f;
                    }
                }
            }
        }
    }
}