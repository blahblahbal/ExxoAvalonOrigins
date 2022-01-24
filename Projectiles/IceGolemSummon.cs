using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class IceGolemSummon : ModProjectile
    {
        int timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Golem");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/IceGolemSummon");
            projectile.netImportant = true;
            projectile.width = dims.Width * 22 / 230;
            projectile.height = dims.Height * 22 / 230 / Main.projFrames[projectile.type];
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            projectile.minionSlots = 1f;
            projectile.ignoreWater = true;
            projectile.friendly = true;
            timer = 0;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
        public override void AI()
        {
            if (!Main.player[projectile.owner].active)
            {
                projectile.active = false;
                return;
            }
            var flag9 = false;
            var flag10 = false;
            var flag11 = false;
            var flag12 = false;
            var num356 = 85;
            Main.player[projectile.owner].AddBuff(ModContent.BuffType<Buffs.IceGolem>(), 3600);
            if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
            {
                if (Main.player[projectile.owner].dead)
                {
                    Main.player[projectile.owner].Avalon().iceGolem = false;
                }
                if (Main.player[projectile.owner].Avalon().iceGolem)
                {
                    projectile.timeLeft = 2;
                }
            }
            if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
            {
                num356 = 10;
                var num357 = 40 * (projectile.minionPos + 1) * Main.player[projectile.owner].direction;
                if (Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 < projectile.position.X + projectile.width / 2 - num356 + num357)
                {
                    flag9 = true;
                }
                else if (Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 > projectile.position.X + projectile.width / 2 + num356 + num357)
                {
                    flag10 = true;
                }
            }
            else if (Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 < projectile.position.X + projectile.width / 2 - num356)
            {
                flag9 = true;
            }
            else if (Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 > projectile.position.X + projectile.width / 2 + num356)
            {
                flag10 = true;
            }
            timer++;
            if (timer > 180)
            {
                int n = BlahBeam.FindClosest(projectile.position, 1600);
                if (n != -1)
                {
                    if (!Main.npc[n].townNPC && Main.npc[n].lifeMax > 5 && !Main.npc[n].dontTakeDamage)
                    {
                        if (Collision.CanHit(projectile.Center, projectile.width, projectile.height, Main.npc[n].Center, Main.npc[n].width, Main.npc[n].height))
                        {
                            Main.PlaySound(2, projectile.position, 12);
                            int p = Projectile.NewProjectile(projectile.Center, projectile.velocity, ModContent.ProjectileType<IceGolemBeam>(), projectile.damage, projectile.knockBack, projectile.owner);
                            Main.projectile[p].velocity = Vector2.Normalize(Main.npc[n].Center - projectile.Center) * 18f;
                        }
                    }
                }
                timer = 0;
            }
            if (projectile.ai[1] == 0f)
            {
                var num392 = 500;
                if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
                {
                    num392 += 40 * projectile.minionPos;
                    if (projectile.localAI[0] > 0f)
                    {
                        num392 += 500;
                    }
                }
                if (Main.player[projectile.owner].rocketDelay2 > 0)
                {
                    projectile.ai[0] = 1f;
                }
                var vector30 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                var num393 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - vector30.X;
                var arg_1425F_0 = projectile.type;
                var num394 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - vector30.Y;
                var num395 = (float)Math.Sqrt(num393 * num393 + num394 * num394);
                if (num395 > 2000f)
                {
                    projectile.position.X = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - projectile.width / 2;
                    projectile.position.Y = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - projectile.height / 2;
                }
                else if (num395 > num392 || (Math.Abs(num394) > 300f && (projectile.type != ModContent.ProjectileType<IceGolemSummon>()) || projectile.localAI[0] <= 0f))
                {
                    if (num394 > 0f && projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = 0f;
                    }
                    if (num394 < 0f && projectile.velocity.Y > 0f)
                    {
                        projectile.velocity.Y = 0f;
                    }
                    projectile.ai[0] = 1f;
                }
            }
            if (projectile.ai[0] != 0f)
            {
                var num396 = 0.2f;
                var num397 = 200;
                projectile.tileCollide = false;
                var vector31 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                var num398 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - vector31.X;
                if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
                {
                    num398 -= 40 * Main.player[projectile.owner].direction;
                    var num399 = 600f;
                    var flag13 = false;
                    for (var num400 = 0; num400 < 200; num400++)
                    {
                        if (Main.npc[num400].active && !Main.npc[num400].dontTakeDamage && !Main.npc[num400].friendly && Main.npc[num400].lifeMax > 5)
                        {
                            var num401 = Main.npc[num400].position.X + Main.npc[num400].width / 2;
                            var num402 = Main.npc[num400].position.Y + Main.npc[num400].height / 2;
                            var num403 = Math.Abs(Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - num401) + Math.Abs(Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - num402);
                            if (num403 < num399)
                            {
                                flag13 = true;
                                break;
                            }
                        }
                    }
                    if (!flag13)
                    {
                        num398 -= 40 * projectile.minionPos * Main.player[projectile.owner].direction;
                    }
                }
                var num404 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - vector31.Y;
                var num405 = (float)Math.Sqrt(num398 * num398 + num404 * num404);
                var num406 = 10f;
                var num407 = num405;
                if (num405 < num397 && Main.player[projectile.owner].velocity.Y == 0f && projectile.position.Y + projectile.height <= Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[0] = 0f;
                    if (projectile.velocity.Y < -6f)
                    {
                        projectile.velocity.Y = -6f;
                    }
                }
                if (num405 < 60f)
                {
                    num398 = projectile.velocity.X;
                    num404 = projectile.velocity.Y;
                }
                else
                {
                    num405 = num406 / num405;
                    num398 *= num405;
                    num404 *= num405;
                }
                if (projectile.velocity.X < num398)
                {
                    projectile.velocity.X = projectile.velocity.X + num396;
                    if (projectile.velocity.X < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X + num396 * 1.5f;
                    }
                }
                if (projectile.velocity.X > num398)
                {
                    projectile.velocity.X = projectile.velocity.X - num396;
                    if (projectile.velocity.X > 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X - num396 * 1.5f;
                    }
                }
                if (projectile.velocity.Y < num404)
                {
                    projectile.velocity.Y = projectile.velocity.Y + num396;
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y + num396 * 1.5f;
                    }
                }
                if (projectile.velocity.Y > num404)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num396;
                    if (projectile.velocity.Y > 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num396 * 1.5f;
                    }
                }
                if (projectile.velocity.X > 0.5)
                {
                    projectile.spriteDirection = -1;
                }
                else if (projectile.velocity.X < -0.5)
                {
                    projectile.spriteDirection = 1;
                }
                if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
                {
                    projectile.spriteDirection = Main.player[projectile.owner].direction;
                    projectile.frameCounter++;
                    if (projectile.frameCounter > 8)
                    {
                        projectile.frame++;
                        projectile.frameCounter = 0;
                    }
                    if (projectile.localAI[1] == 1f)
                    {
                        projectile.frame = 6;
                    }
                    else if (projectile.frame > 5)
                    {
                        projectile.frame = 1;
                    }
                    if (projectile.frame < 1)
                    {
                        projectile.frame = 1;
                    }
                }
                else if (projectile.spriteDirection == -1)
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X);
                }
                else
                {
                    projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 3.14f;
                }
                if (projectile.type != ModContent.ProjectileType<IceGolemSummon>())
                {
                    var num413 = Dust.NewDust(new Vector2(projectile.position.X + projectile.width / 2 - 4f, projectile.position.Y + projectile.height / 2 - 4f) - projectile.velocity, 8, 8, DustID.Cloud, -projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 50, default(Color), 1.7f);
                    Main.dust[num413].velocity.X = Main.dust[num413].velocity.X * 0.2f;
                    Main.dust[num413].velocity.Y = Main.dust[num413].velocity.Y * 0.2f;
                    Main.dust[num413].noGravity = true;
                }
            }
            else
            {
                if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
                {
                    float num414 = 40 * projectile.minionPos;
                    var num415 = 30;
                    var num416 = 60;
                    projectile.localAI[0] -= 1f;
                    if (projectile.localAI[0] < 0f)
                    {
                        projectile.localAI[0] = 0f;
                    }
                    if (projectile.ai[1] > 0f)
                    {
                        projectile.ai[1] -= 1f;
                    }
                    else
                    {
                        var num417 = projectile.position.X;
                        var num418 = projectile.position.Y;
                        var num419 = 100000f;
                        var num420 = num419;
                        var num421 = -1;
                        for (var num422 = 0; num422 < 200; num422++)
                        {
                            if (Main.npc[num422].active && !Main.npc[num422].dontTakeDamage && !Main.npc[num422].friendly && Main.npc[num422].lifeMax > 5)
                            {
                                var num423 = Main.npc[num422].position.X + Main.npc[num422].width / 2;
                                var num424 = Main.npc[num422].position.Y + Main.npc[num422].height / 2;
                                var num425 = Math.Abs(projectile.position.X + projectile.width / 2 - num423) + Math.Abs(projectile.position.Y + projectile.height / 2 - num424);
                                if (num425 < num419)
                                {
                                    if (num421 == -1 && num425 <= num420)
                                    {
                                        num420 = num425;
                                        num417 = num423;
                                        num418 = num424;
                                    }
                                    if (Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num422].position, Main.npc[num422].width, Main.npc[num422].height))
                                    {
                                        num419 = num425;
                                        num417 = num423;
                                        num418 = num424;
                                        num421 = num422;
                                    }
                                }
                            }
                        }
                        if (num421 == -1 && num420 < num419)
                        {
                            num419 = num420;
                        }
                        var num426 = 400f;
                        if (projectile.position.Y > Main.worldSurface * 16.0)
                        {
                            num426 = 200f;
                        }
                        if (num419 < num426 + num414 && num421 == -1)
                        {
                            var num427 = num417 - (projectile.position.X + projectile.width / 2);
                            if (num427 < -5f)
                            {
                                flag9 = true;
                                flag10 = false;
                            }
                            else if (num427 > 5f)
                            {
                                flag10 = true;
                                flag9 = false;
                            }
                        }
                        else if (num421 >= 0 && num419 < 800f + num414)
                        {
                            projectile.localAI[0] = num416;
                            var num428 = num417 - (projectile.position.X + projectile.width / 2);
                            if (num428 > 300f || num428 < -300f)
                            {
                                if (num428 < -50f)
                                {
                                    flag9 = true;
                                    flag10 = false;
                                }
                                else if (num428 > 50f)
                                {
                                    flag10 = true;
                                    flag9 = false;
                                }
                            }
                            else if (projectile.owner == Main.myPlayer)
                            {
                                projectile.ai[1] = num415;
                                var num429 = 12f;
                                var vector32 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height / 2 - 8f);
                                var num430 = num417 - vector32.X + Main.rand.Next(-20, 21);
                                var num431 = Math.Abs(num430) * 0.1f;
                                num431 = num431 * Main.rand.Next(0, 100) * 0.001f;
                                var num432 = num418 - vector32.Y + Main.rand.Next(-20, 21) - num431;
                                var num433 = (float)Math.Sqrt(num430 * num430 + num432 * num432);
                                num433 = num429 / num433;
                                num430 *= num433;
                                num432 *= num433;
                                var num434 = projectile.damage;
                                int num435 = ProjectileID.PygmySpear;
                                if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
                                {
                                    num435 = ModContent.ProjectileType<IceGolemBeam>();
                                }
                                var num436 = Projectile.NewProjectile(vector32.X, vector32.Y, num430, num432, num435, num434, (projectile.type == ModContent.ProjectileType<IceGolemSummon>()) ? 8f : projectile.knockBack, Main.myPlayer, 0f, 0f);
                                Main.projectile[num436].friendly = true;
                                Main.projectile[num436].hostile = false;
                                Main.projectile[num436].timeLeft = 300;
                                if (num430 < 0f)
                                {
                                    projectile.direction = -1;
                                }
                                if (num430 > 0f)
                                {
                                    projectile.direction = 1;
                                }
                                projectile.netUpdate = true;
                            }
                        }
                    }
                }
                var flag14 = false;
                var vector33 = Vector2.Zero;
                if (projectile.ai[1] != 0f)
                {
                    flag9 = false;
                    flag10 = false;
                }
                projectile.tileCollide = true;
                var num454 = 0.08f;
                var num455 = 6.5f;
                if (projectile.type == ModContent.ProjectileType<IceGolemSummon>())
                {
                    num455 = 6f;
                    num454 = 0.2f;
                    if (num455 < Math.Abs(Main.player[projectile.owner].velocity.X) + Math.Abs(Main.player[projectile.owner].velocity.Y))
                    {
                        num455 = Math.Abs(Main.player[projectile.owner].velocity.X) + Math.Abs(Main.player[projectile.owner].velocity.Y);
                        num454 = 0.3f;
                    }
                }
                if (flag9)
                {
                    if (projectile.velocity.X > -3.5)
                    {
                        projectile.velocity.X = projectile.velocity.X - num454;
                    }
                    else
                    {
                        projectile.velocity.X = projectile.velocity.X - num454 * 0.25f;
                    }
                }
                else if (flag10)
                {
                    if (projectile.velocity.X < 3.5)
                    {
                        projectile.velocity.X = projectile.velocity.X + num454;
                    }
                    else
                    {
                        projectile.velocity.X = projectile.velocity.X + num454 * 0.25f;
                    }
                }
                else
                {
                    projectile.velocity.X = projectile.velocity.X * 0.9f;
                    if (projectile.velocity.X >= -num454 && projectile.velocity.X <= num454)
                    {
                        projectile.velocity.X = 0f;
                    }
                }
                if (flag9 || flag10)
                {
                    var num456 = (int)(projectile.position.X + projectile.width / 2) / 16;
                    var j2 = (int)(projectile.position.Y + projectile.height / 2) / 16;
                    if (flag9)
                    {
                        num456--;
                    }
                    if (flag10)
                    {
                        num456++;
                    }
                    num456 += (int)projectile.velocity.X;
                    if (WorldGen.SolidTile(num456, j2))
                    {
                        flag12 = true;
                    }
                }
                if (Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height - 8f > projectile.position.Y + projectile.height)
                {
                    flag11 = true;
                }
                Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY, 1, false);
                if (projectile.velocity.Y == 0f)
                {
                    if (!flag11 && (projectile.velocity.X < 0f || projectile.velocity.X > 0f))
                    {
                        var num457 = (int)(projectile.position.X + projectile.width / 2) / 16;
                        var j3 = (int)(projectile.position.Y + projectile.height / 2) / 16 + 1;
                        if (flag9)
                        {
                            num457--;
                        }
                        if (flag10)
                        {
                            num457++;
                        }
                        WorldGen.SolidTile(num457, j3);
                    }
                    if (flag12)
                    {
                        var num458 = (int)(projectile.position.X + projectile.width / 2) / 16;
                        var num459 = (int)(projectile.position.Y + projectile.height) / 16 + 1;
                        if (WorldGen.SolidTile(num458, num459) || Main.tile[num458, num459].halfBrick() || Main.tile[num458, num459].slope() > 0)
                        {
                            try
                            {
                                num458 = (int)(projectile.position.X + projectile.width / 2) / 16;
                                num459 = (int)(projectile.position.Y + projectile.height / 2) / 16;
                                if (flag9)
                                {
                                    num458--;
                                }
                                if (flag10)
                                {
                                    num458++;
                                }
                                num458 += (int)projectile.velocity.X;
                                if (!WorldGen.SolidTile(num458, num459 - 1) && !WorldGen.SolidTile(num458, num459 - 2))
                                {
                                    projectile.velocity.Y = -5.1f;
                                }
                                else if (!WorldGen.SolidTile(num458, num459 - 2))
                                {
                                    projectile.velocity.Y = -7.1f;
                                }
                                else if (WorldGen.SolidTile(num458, num459 - 5))
                                {
                                    projectile.velocity.Y = -11.1f;
                                }
                                else if (WorldGen.SolidTile(num458, num459 - 4))
                                {
                                    projectile.velocity.Y = -10.1f;
                                }
                                else
                                {
                                    projectile.velocity.Y = -9.1f;
                                }
                            }
                            catch
                            {
                                projectile.velocity.Y = -9.1f;
                            }
                        }
                    }
                }
                if (projectile.velocity.X > num455)
                {
                    projectile.velocity.X = num455;
                }
                if (projectile.velocity.X < -num455)
                {
                    projectile.velocity.X = -num455;
                }
                if (projectile.velocity.X < 0f)
                {
                    projectile.direction = -1;
                }
                if (projectile.velocity.X > 0f)
                {
                    projectile.direction = 1;
                }
                if (projectile.velocity.X > num454 && flag10)
                {
                    projectile.direction = 1;
                }
                if (projectile.velocity.X < -num454 && flag9)
                {
                    projectile.direction = -1;
                }
                if (projectile.direction == -1)
                {
                    projectile.spriteDirection = 1;
                }
                if (projectile.direction == 1)
                {
                    projectile.spriteDirection = -1;
                }
            }
        }
    }
}
