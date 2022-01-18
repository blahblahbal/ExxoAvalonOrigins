using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ImpactSphere : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Impact Sphere");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/ImpactSphere");
            projectile.width = dims.Width;
            projectile.height = dims.Height * 38 / 220 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.magic = true;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;
            projectile.light = 0.9f;
            Main.projFrames[projectile.type] = 5;
        }

        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<Minisphere>())
            {
                if (projectile.ai[0] == 0f)
                {
                    projectile.ai[0] = projectile.velocity.X;
                    projectile.ai[1] = projectile.velocity.Y;
                }
                if (projectile.velocity.X > 0f)
                {
                    projectile.rotation += (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f;
                }
                else
                {
                    projectile.rotation -= (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f;
                }
                if (projectile.type != ModContent.ProjectileType<Minisphere>())
                {
                    projectile.frameCounter++;
                    if (projectile.frameCounter > 6)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame > 4)
                        {
                            projectile.frame = 0;
                        }
                    }
                }
                if (Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y) > 2.0)
                {
                    projectile.velocity *= 0.98f;
                }
                for (var num583 = 0; num583 < 1000; num583++)
                {
                    if (num583 != projectile.whoAmI && Main.projectile[num583].active && Main.projectile[num583].owner == projectile.owner && Main.projectile[num583].type == projectile.type && projectile.timeLeft > Main.projectile[num583].timeLeft && Main.projectile[num583].timeLeft > 30)
                    {
                        Main.projectile[num583].timeLeft = 30;
                    }
                }
                var array = new int[20];
                var num584 = 0;
                var num585 = 300f;
                if (projectile.type == ModContent.ProjectileType<Minisphere>())
                {
                    num585 = 600f;
                }
                var flag21 = false;
                for (var num586 = 0; num586 < 200; num586++)
                {
                    if (Main.npc[num586].active && !Main.npc[num586].dontTakeDamage && !Main.npc[num586].friendly && Main.npc[num586].lifeMax > 5)
                    {
                        var num587 = Main.npc[num586].position.X + Main.npc[num586].width / 2;
                        var num588 = Main.npc[num586].position.Y + Main.npc[num586].height / 2;
                        var num589 = Math.Abs(projectile.position.X + projectile.width / 2 - num587) + Math.Abs(projectile.position.Y + projectile.height / 2 - num588);
                        if (num589 < num585 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num586].Center, 1, 1))
                        {
                            if (num584 < 20)
                            {
                                array[num584] = num586;
                                num584++;
                            }
                            flag21 = true;
                        }
                    }
                }
                if (flag21)
                {
                    var num590 = Main.rand.Next(num584);
                    num590 = array[num590];
                    var num591 = Main.npc[num590].position.X + Main.npc[num590].width / 2;
                    var num592 = Main.npc[num590].position.Y + Main.npc[num590].height / 2;
                    projectile.localAI[0] += 1f;
                    if (projectile.localAI[0] > 8f)
                    {
                        projectile.localAI[0] = 0f;
                        var num593 = 6f;
                        var value7 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                        value7 += projectile.velocity * 4f;
                        var num594 = num591 - value7.X;
                        var num595 = num592 - value7.Y;
                        var num596 = (float)Math.Sqrt(num594 * num594 + num595 * num595);
                        num596 = num593 / num596;
                        num594 *= num596;
                        num595 *= num596;
                        var num597 = Projectile.NewProjectile(value7.X, value7.Y, num594, num595, ProjectileID.MagnetSphereBolt, (projectile.type == ModContent.ProjectileType<Minisphere>()) ? (projectile.damage / 3 * 2) : projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                        if (projectile.type == ModContent.ProjectileType<Minisphere>())
                        {
                            Main.projectile[num597].magic = false;
                            Main.projectile[num597].melee = true;
                        }
                    }
                }
            }
            else if (projectile.type == ModContent.ProjectileType<ImpactSphere>())
            {
                if (projectile.ai[0] == 0f)
                {
                    projectile.ai[0] = projectile.velocity.X;
                    projectile.ai[1] = projectile.velocity.Y;
                }
                if (projectile.velocity.X > 0f)
                {
                    projectile.rotation += (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f;
                }
                else
                {
                    projectile.rotation -= (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f;
                }
                projectile.frameCounter++;
                if (projectile.frameCounter > 6)
                {
                    projectile.frameCounter = 0;
                    projectile.frame++;
                    if (projectile.frame > 4)
                    {
                        projectile.frame = 0;
                    }
                }
                if (Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y) > 2.0)
                {
                    projectile.velocity *= 0.98f;
                }
                for (var num598 = 0; num598 < 1000; num598++)
                {
                    if (num598 != projectile.whoAmI && Main.projectile[num598].active && Main.projectile[num598].owner == projectile.owner && Main.projectile[num598].type == projectile.type && projectile.timeLeft > Main.projectile[num598].timeLeft && Main.projectile[num598].timeLeft > 30)
                    {
                        Main.projectile[num598].timeLeft = 30;
                    }
                }
                var array2 = new int[20];
                var num599 = 0;
                var flag22 = false;
                for (var num600 = 0; num600 < 200; num600++)
                {
                    if (Main.npc[num600].active && !Main.npc[num600].dontTakeDamage && !Main.npc[num600].friendly && Main.npc[num600].lifeMax > 5)
                    {
                        var num601 = Main.npc[num600].position.X + Main.npc[num600].width / 2;
                        var num602 = Main.npc[num600].position.Y + Main.npc[num600].height / 2;
                        Math.Abs(projectile.position.X + projectile.width / 2 - num601);
                        Math.Abs(projectile.position.Y + projectile.height / 2 - num602);
                        if (Vector2.Distance(projectile.Center, Main.player[Player.FindClosest(projectile.position, projectile.width, projectile.height)].Center) < 160f)
                        {
                            if (num599 < 20)
                            {
                                array2[num599] = num600;
                                num599++;
                            }
                            flag22 = true;
                        }
                    }
                }
                if (projectile.timeLeft < 30)
                {
                    flag22 = false;
                }
                if (flag22)
                {
                    var num603 = Main.rand.Next(num599);
                    num603 = array2[num603];
                    var num604 = Main.npc[num603].position.X + Main.npc[num603].width / 2;
                    var num605 = Main.npc[num603].position.Y + Main.npc[num603].height / 2;
                    projectile.localAI[0] += 1f;
                    if (projectile.localAI[0] > 8f)
                    {
                        projectile.localAI[0] = 0f;
                        var num606 = 6f;
                        var value8 = projectile.Center;
                        var num607 = num604 - value8.X;
                        var num608 = num605 - value8.Y;
                        var num609 = (float)Math.Sqrt(num607 * num607 + num608 * num608);
                        num609 = num606 / num609;
                        num607 *= num609;
                        num608 *= num609;
                        var num610 = Projectile.NewProjectile(value8.X, value8.Y, num607, num608, ModContent.ProjectileType<ImpactBolt>(), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                        Main.projectile[num610].velocity = Vector2.Normalize(Main.player[Player.FindClosest(projectile.Center, projectile.width, projectile.height)].Center - projectile.Center) * 3f;
                    }
                }
            }
        }
    }
}