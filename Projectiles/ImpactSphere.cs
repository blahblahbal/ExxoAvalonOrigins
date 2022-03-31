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
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/ImpactSphere");
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
        public override bool PreAI()
        {
            Lighting.AddLight(projectile.position, 2 / 255, 254 / 255, 201 / 255);
            return true;
        }
        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<ImpactSphere>())
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
                    projectile.localAI[0]++;
                    if (projectile.localAI[0] > 14f)
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
