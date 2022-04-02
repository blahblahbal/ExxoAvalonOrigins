using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public class IceGolemSummon : ModProjectile
{
    int timer;
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Ice Golem");
        Main.projFrames[Projectile.type] = 6;
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Summon/IceGolemSummon");
        Projectile.netImportant = true;
        Projectile.width = dims.Width * 22 / 230;
        Projectile.height = dims.Height * 22 / 230 / Main.projFrames[Projectile.type];
        Projectile.penetrate = -1;
        Projectile.timeLeft *= 5;
        Projectile.minion = true;
        Projectile.minionSlots = 1f;
        Projectile.ignoreWater = true;
        Projectile.friendly = true;
        timer = 0;
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        return false;
    }
    public override void AI()
    {
        if (!Main.player[Projectile.owner].active)
        {
            Projectile.active = false;
            return;
        }
        var flag9 = false;
        var flag10 = false;
        var flag11 = false;
        var flag12 = false;
        var num356 = 85;
        Main.player[Projectile.owner].AddBuff(ModContent.BuffType<Buffs.IceGolem>(), 3600);
        if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
        {
            if (Main.player[Projectile.owner].dead)
            {
                Main.player[Projectile.owner].Avalon().iceGolem = false;
            }
            if (Main.player[Projectile.owner].Avalon().iceGolem)
            {
                Projectile.timeLeft = 2;
            }
        }
        if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
        {
            num356 = 10;
            var num357 = 40 * (Projectile.minionPos + 1) * Main.player[Projectile.owner].direction;
            if (Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 < Projectile.position.X + Projectile.width / 2 - num356 + num357)
            {
                flag9 = true;
            }
            else if (Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 > Projectile.position.X + Projectile.width / 2 + num356 + num357)
            {
                flag10 = true;
            }
        }
        else if (Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 < Projectile.position.X + Projectile.width / 2 - num356)
        {
            flag9 = true;
        }
        else if (Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 > Projectile.position.X + Projectile.width / 2 + num356)
        {
            flag10 = true;
        }
        timer++;
        if (timer > 180)
        {
            int n = Projectile.FindClosestNPC(1600);
            if (n != -1)
            {
                if (!Main.npc[n].townNPC && Main.npc[n].lifeMax > 5 && !Main.npc[n].dontTakeDamage)
                {
                    if (Collision.CanHit(Projectile.Center, Projectile.width, Projectile.height, Main.npc[n].Center, Main.npc[n].width, Main.npc[n].height))
                    {
                        SoundEngine.PlaySound(2, Projectile.position, 12);
                        int p = Projectile.NewProjectile(Projectile.Center, Projectile.velocity, ModContent.ProjectileType<IceGolemBeam>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
                        Main.projectile[p].velocity = Vector2.Normalize(Main.npc[n].Center - Projectile.Center) * 18f;
                    }
                }
            }
            timer = 0;
        }
        if (Projectile.ai[1] == 0f)
        {
            var num392 = 500;
            if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
            {
                num392 += 40 * Projectile.minionPos;
                if (Projectile.localAI[0] > 0f)
                {
                    num392 += 500;
                }
            }
            if (Main.player[Projectile.owner].rocketDelay2 > 0)
            {
                Projectile.ai[0] = 1f;
            }
            var vector30 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
            var num393 = Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 - vector30.X;
            var arg_1425F_0 = Projectile.type;
            var num394 = Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - vector30.Y;
            var num395 = (float)Math.Sqrt(num393 * num393 + num394 * num394);
            if (num395 > 2000f)
            {
                Projectile.position.X = Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 - Projectile.width / 2;
                Projectile.position.Y = Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - Projectile.height / 2;
            }
            else if (num395 > num392 || (Math.Abs(num394) > 300f && (Projectile.type != ModContent.ProjectileType<IceGolemSummon>()) || Projectile.localAI[0] <= 0f))
            {
                if (num394 > 0f && Projectile.velocity.Y < 0f)
                {
                    Projectile.velocity.Y = 0f;
                }
                if (num394 < 0f && Projectile.velocity.Y > 0f)
                {
                    Projectile.velocity.Y = 0f;
                }
                Projectile.ai[0] = 1f;
            }
        }
        if (Projectile.ai[0] != 0f)
        {
            var num396 = 0.2f;
            var num397 = 200;
            Projectile.tileCollide = false;
            var vector31 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
            var num398 = Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 - vector31.X;
            if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
            {
                num398 -= 40 * Main.player[Projectile.owner].direction;
                var num399 = 600f;
                var flag13 = false;
                for (var num400 = 0; num400 < 200; num400++)
                {
                    if (Main.npc[num400].active && !Main.npc[num400].dontTakeDamage && !Main.npc[num400].friendly && Main.npc[num400].lifeMax > 5)
                    {
                        var num401 = Main.npc[num400].position.X + Main.npc[num400].width / 2;
                        var num402 = Main.npc[num400].position.Y + Main.npc[num400].height / 2;
                        var num403 = Math.Abs(Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 - num401) + Math.Abs(Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - num402);
                        if (num403 < num399)
                        {
                            flag13 = true;
                            break;
                        }
                    }
                }
                if (!flag13)
                {
                    num398 -= 40 * Projectile.minionPos * Main.player[Projectile.owner].direction;
                }
            }
            var num404 = Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - vector31.Y;
            var num405 = (float)Math.Sqrt(num398 * num398 + num404 * num404);
            var num406 = 10f;
            var num407 = num405;
            if (num405 < num397 && Main.player[Projectile.owner].velocity.Y == 0f && Projectile.position.Y + Projectile.height <= Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
            {
                Projectile.ai[0] = 0f;
                if (Projectile.velocity.Y < -6f)
                {
                    Projectile.velocity.Y = -6f;
                }
            }
            if (num405 < 60f)
            {
                num398 = Projectile.velocity.X;
                num404 = Projectile.velocity.Y;
            }
            else
            {
                num405 = num406 / num405;
                num398 *= num405;
                num404 *= num405;
            }
            if (Projectile.velocity.X < num398)
            {
                Projectile.velocity.X = Projectile.velocity.X + num396;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.velocity.X = Projectile.velocity.X + num396 * 1.5f;
                }
            }
            if (Projectile.velocity.X > num398)
            {
                Projectile.velocity.X = Projectile.velocity.X - num396;
                if (Projectile.velocity.X > 0f)
                {
                    Projectile.velocity.X = Projectile.velocity.X - num396 * 1.5f;
                }
            }
            if (Projectile.velocity.Y < num404)
            {
                Projectile.velocity.Y = Projectile.velocity.Y + num396;
                if (Projectile.velocity.Y < 0f)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y + num396 * 1.5f;
                }
            }
            if (Projectile.velocity.Y > num404)
            {
                Projectile.velocity.Y = Projectile.velocity.Y - num396;
                if (Projectile.velocity.Y > 0f)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y - num396 * 1.5f;
                }
            }
            if (Projectile.velocity.X > 0.5)
            {
                Projectile.spriteDirection = -1;
            }
            else if (Projectile.velocity.X < -0.5)
            {
                Projectile.spriteDirection = 1;
            }
            if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
            {
                Projectile.spriteDirection = Main.player[Projectile.owner].direction;
                Projectile.frameCounter++;
                if (Projectile.frameCounter > 8)
                {
                    Projectile.frame++;
                    Projectile.frameCounter = 0;
                }
                if (Projectile.localAI[1] == 1f)
                {
                    Projectile.frame = 6;
                }
                else if (Projectile.frame > 5)
                {
                    Projectile.frame = 1;
                }
                if (Projectile.frame < 1)
                {
                    Projectile.frame = 1;
                }
            }
            else if (Projectile.spriteDirection == -1)
            {
                Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X);
            }
            else
            {
                Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 3.14f;
            }
            if (Projectile.type != ModContent.ProjectileType<IceGolemSummon>())
            {
                var num413 = Dust.NewDust(new Vector2(Projectile.position.X + Projectile.width / 2 - 4f, Projectile.position.Y + Projectile.height / 2 - 4f) - Projectile.velocity, 8, 8, DustID.Cloud, -Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 50, default(Color), 1.7f);
                Main.dust[num413].velocity.X = Main.dust[num413].velocity.X * 0.2f;
                Main.dust[num413].velocity.Y = Main.dust[num413].velocity.Y * 0.2f;
                Main.dust[num413].noGravity = true;
            }
        }
        else
        {
            if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
            {
                float num414 = 40 * Projectile.minionPos;
                var num415 = 30;
                var num416 = 60;
                Projectile.localAI[0] -= 1f;
                if (Projectile.localAI[0] < 0f)
                {
                    Projectile.localAI[0] = 0f;
                }
                if (Projectile.ai[1] > 0f)
                {
                    Projectile.ai[1] -= 1f;
                }
                else
                {
                    var num417 = Projectile.position.X;
                    var num418 = Projectile.position.Y;
                    var num419 = 100000f;
                    var num420 = num419;
                    var num421 = -1;
                    for (var num422 = 0; num422 < 200; num422++)
                    {
                        if (Main.npc[num422].active && !Main.npc[num422].dontTakeDamage && !Main.npc[num422].friendly && Main.npc[num422].lifeMax > 5)
                        {
                            var num423 = Main.npc[num422].position.X + Main.npc[num422].width / 2;
                            var num424 = Main.npc[num422].position.Y + Main.npc[num422].height / 2;
                            var num425 = Math.Abs(Projectile.position.X + Projectile.width / 2 - num423) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - num424);
                            if (num425 < num419)
                            {
                                if (num421 == -1 && num425 <= num420)
                                {
                                    num420 = num425;
                                    num417 = num423;
                                    num418 = num424;
                                }
                                if (Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[num422].position, Main.npc[num422].width, Main.npc[num422].height))
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
                    if (Projectile.position.Y > Main.worldSurface * 16.0)
                    {
                        num426 = 200f;
                    }
                    if (num419 < num426 + num414 && num421 == -1)
                    {
                        var num427 = num417 - (Projectile.position.X + Projectile.width / 2);
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
                        Projectile.localAI[0] = num416;
                        var num428 = num417 - (Projectile.position.X + Projectile.width / 2);
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
                        else if (Projectile.owner == Main.myPlayer)
                        {
                            Projectile.ai[1] = num415;
                            var num429 = 12f;
                            var vector32 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height / 2 - 8f);
                            var num430 = num417 - vector32.X + Main.rand.Next(-20, 21);
                            var num431 = Math.Abs(num430) * 0.1f;
                            num431 = num431 * Main.rand.Next(0, 100) * 0.001f;
                            var num432 = num418 - vector32.Y + Main.rand.Next(-20, 21) - num431;
                            var num433 = (float)Math.Sqrt(num430 * num430 + num432 * num432);
                            num433 = num429 / num433;
                            num430 *= num433;
                            num432 *= num433;
                            var num434 = Projectile.damage;
                            int num435 = ProjectileID.PygmySpear;
                            if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
                            {
                                num435 = ModContent.ProjectileType<IceGolemBeam>();
                            }
                            var num436 = Projectile.NewProjectile(vector32.X, vector32.Y, num430, num432, num435, num434, (Projectile.type == ModContent.ProjectileType<IceGolemSummon>()) ? 8f : Projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Main.projectile[num436].friendly = true;
                            Main.projectile[num436].hostile = false;
                            Main.projectile[num436].timeLeft = 300;
                            if (num430 < 0f)
                            {
                                Projectile.direction = -1;
                            }
                            if (num430 > 0f)
                            {
                                Projectile.direction = 1;
                            }
                            Projectile.netUpdate = true;
                        }
                    }
                }
            }
            var vector33 = Vector2.Zero;
            if (Projectile.ai[1] != 0f)
            {
                flag9 = false;
                flag10 = false;
            }
            Projectile.tileCollide = true;
            var num454 = 0.08f;
            var num455 = 6.5f;
            if (Projectile.type == ModContent.ProjectileType<IceGolemSummon>())
            {
                num455 = 6f;
                num454 = 0.2f;
                if (num455 < Math.Abs(Main.player[Projectile.owner].velocity.X) + Math.Abs(Main.player[Projectile.owner].velocity.Y))
                {
                    num455 = Math.Abs(Main.player[Projectile.owner].velocity.X) + Math.Abs(Main.player[Projectile.owner].velocity.Y);
                    num454 = 0.3f;
                }
            }
            if (flag9)
            {
                if (Projectile.velocity.X > -3.5)
                {
                    Projectile.velocity.X = Projectile.velocity.X - num454;
                }
                else
                {
                    Projectile.velocity.X = Projectile.velocity.X - num454 * 0.25f;
                }
            }
            else if (flag10)
            {
                if (Projectile.velocity.X < 3.5)
                {
                    Projectile.velocity.X = Projectile.velocity.X + num454;
                }
                else
                {
                    Projectile.velocity.X = Projectile.velocity.X + num454 * 0.25f;
                }
            }
            else
            {
                Projectile.velocity.X = Projectile.velocity.X * 0.9f;
                if (Projectile.velocity.X >= -num454 && Projectile.velocity.X <= num454)
                {
                    Projectile.velocity.X = 0f;
                }
            }
            if (flag9 || flag10)
            {
                var num456 = (int)(Projectile.position.X + Projectile.width / 2) / 16;
                var j2 = (int)(Projectile.position.Y + Projectile.height / 2) / 16;
                if (flag9)
                {
                    num456--;
                }
                if (flag10)
                {
                    num456++;
                }
                num456 += (int)Projectile.velocity.X;
                if (WorldGen.SolidTile(num456, j2))
                {
                    flag12 = true;
                }
            }
            if (Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height - 8f > Projectile.position.Y + Projectile.height)
            {
                flag11 = true;
            }
            Collision.StepUp(ref Projectile.position, ref Projectile.velocity, Projectile.width, Projectile.height, ref Projectile.stepSpeed, ref Projectile.gfxOffY, 1, false);
            if (Projectile.velocity.Y == 0f)
            {
                if (!flag11 && (Projectile.velocity.X < 0f || Projectile.velocity.X > 0f))
                {
                    var num457 = (int)(Projectile.position.X + Projectile.width / 2) / 16;
                    var j3 = (int)(Projectile.position.Y + Projectile.height / 2) / 16 + 1;
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
                    var num458 = (int)(Projectile.position.X + Projectile.width / 2) / 16;
                    var num459 = (int)(Projectile.position.Y + Projectile.height) / 16 + 1;
                    if (WorldGen.SolidTile(num458, num459) || Main.tile[num458, num459].IsHalfBlock || Main.tile[num458, num459].slope() > 0)
                    {
                        try
                        {
                            num458 = (int)(Projectile.position.X + Projectile.width / 2) / 16;
                            num459 = (int)(Projectile.position.Y + Projectile.height / 2) / 16;
                            if (flag9)
                            {
                                num458--;
                            }
                            if (flag10)
                            {
                                num458++;
                            }
                            num458 += (int)Projectile.velocity.X;
                            if (!WorldGen.SolidTile(num458, num459 - 1) && !WorldGen.SolidTile(num458, num459 - 2))
                            {
                                Projectile.velocity.Y = -5.1f;
                            }
                            else if (!WorldGen.SolidTile(num458, num459 - 2))
                            {
                                Projectile.velocity.Y = -7.1f;
                            }
                            else if (WorldGen.SolidTile(num458, num459 - 5))
                            {
                                Projectile.velocity.Y = -11.1f;
                            }
                            else if (WorldGen.SolidTile(num458, num459 - 4))
                            {
                                Projectile.velocity.Y = -10.1f;
                            }
                            else
                            {
                                Projectile.velocity.Y = -9.1f;
                            }
                        }
                        catch
                        {
                            Projectile.velocity.Y = -9.1f;
                        }
                    }
                }
            }
            if (Projectile.velocity.X > num455)
            {
                Projectile.velocity.X = num455;
            }
            if (Projectile.velocity.X < -num455)
            {
                Projectile.velocity.X = -num455;
            }
            if (Projectile.velocity.X < 0f)
            {
                Projectile.direction = -1;
            }
            if (Projectile.velocity.X > 0f)
            {
                Projectile.direction = 1;
            }
            if (Projectile.velocity.X > num454 && flag10)
            {
                Projectile.direction = 1;
            }
            if (Projectile.velocity.X < -num454 && flag9)
            {
                Projectile.direction = -1;
            }
            if (Projectile.direction == -1)
            {
                Projectile.spriteDirection = 1;
            }
            if (Projectile.direction == 1)
            {
                Projectile.spriteDirection = -1;
            }
        }
    }
}