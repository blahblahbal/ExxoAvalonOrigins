using System;
using ExxoAvalonOrigins.Items.Material;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.NPCs
{
    public class Astigmatazer : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astigmatazer");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults()
        {
            npc.damage = 90;
            npc.boss = true;
            npc.netAlways = true;
            npc.noTileCollide = true;
            npc.lifeMax = 60000;
            npc.defense = 30;
            npc.noGravity = true;
            npc.width = 100;
            npc.aiStyle = -1;
            npc.npcSlots = 2f;
            npc.value = 50000f;
            npc.timeLeft = 750;
            npc.height = 110;
            npc.knockBackResist = 0f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.buffImmune[BuffID.Confused] = true;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SoulofBlight>(), Main.rand.Next(5) + 1, false, 0, false);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofMight, Main.rand.Next(5) + 1, false, 0, false);
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofSight, Main.rand.Next(5) + 1, false, 0, false);
        }

        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            var dead2 = Main.player[npc.target].dead;
            var num485 = npc.position.X + npc.width / 2 - Main.player[npc.target].position.X - Main.player[npc.target].width / 2;
            var num486 = npc.position.Y + npc.height - 59f - Main.player[npc.target].position.Y - Main.player[npc.target].height / 2;
            var num487 = (float)Math.Atan2(num486, num485) + 1.57f;
            if (num487 < 0f)
            {
                num487 += 6.283f;
            }
            else if (num487 > 6.283)
            {
                num487 -= 6.283f;
            }
            if (npc.rotation < num487)
            {
                if (num487 - npc.rotation > 3.1415)
                {
                    npc.rotation -= 0.1f;
                }
                else
                {
                    npc.rotation += 0.1f;
                }
            }
            else if (npc.rotation > num487)
            {
                if (npc.rotation - num487 > 3.1415)
                {
                    npc.rotation += 0.1f;
                }
                else
                {
                    npc.rotation -= 0.1f;
                }
            }
            if (npc.rotation > num487 - 0.1f && npc.rotation < num487 + 0.1f)
            {
                npc.rotation = num487;
            }
            if (npc.rotation < 0f)
            {
                npc.rotation += 6.283f;
            }
            else if (npc.rotation > 6.283)
            {
                npc.rotation -= 6.283f;
            }
            if (npc.rotation > num487 - 0.1f && npc.rotation < num487 + 0.1f)
            {
                npc.rotation = num487;
            }
            if (Main.rand.Next(5) == 0)
            {
                var num489 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), DustID.Blood, npc.velocity.X, 2f, 0, default(Color), 1f);
                var dust40 = Main.dust[num489];
                dust40.velocity.X = dust40.velocity.X * 0.5f;
                var dust41 = Main.dust[num489];
                dust41.velocity.Y = dust41.velocity.Y * 0.1f;
            }
            if (Main.netMode != NetmodeID.MultiplayerClient && !Main.dayTime && !dead2 && npc.timeLeft < 10)
            {
                for (var num490 = 0; num490 < 200; num490++)
                {
                    if (num490 != npc.whoAmI && Main.npc[num490].active && (Main.npc[num490].type == NPCID.Retinazer || Main.npc[num490].type == NPCID.Spazmatism) && Main.npc[num490].timeLeft - 1 > npc.timeLeft)
                    {
                        npc.timeLeft = Main.npc[num490].timeLeft - 1;
                    }
                }
            }
            if (Main.dayTime || dead2)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
                return;
            }
            else if (npc.ai[0] == 0f)
            {
                if (npc.ai[1] == 0f)
                {
                    var num493 = 1;
                    if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
                    {
                        num493 = -1;
                    }
                    var vector46 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num494 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + num493 * 300 - vector46.X;
                    var num495 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 300f - vector46.Y;
                    var num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
                    num496 = 7f / num496;
                    num494 *= num496;
                    num495 *= num496;
                    if (npc.velocity.X < num494)
                    {
                        npc.velocity.X = npc.velocity.X + 0.1f;
                        if (npc.velocity.X < 0f && num494 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + 0.1f;
                        }
                    }
                    else if (npc.velocity.X > num494)
                    {
                        npc.velocity.X = npc.velocity.X - 0.1f;
                        if (npc.velocity.X > 0f && num494 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - 0.1f;
                        }
                    }
                    if (npc.velocity.Y < num495)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.1f;
                        if (npc.velocity.Y < 0f && num495 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + 0.1f;
                        }
                    }
                    else if (npc.velocity.Y > num495)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.1f;
                        if (npc.velocity.Y > 0f && num495 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - 0.1f;
                        }
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 600f)
                    {
                        npc.ai[1] = 1f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.target = 255;
                        npc.netUpdate = true;
                    }
                    else if (npc.position.Y + npc.height < Main.player[npc.target].position.Y && num496 < 400f)
                    {
                        if (!Main.player[npc.target].dead)
                        {
                            npc.ai[3] += 1f;
                        }
                        if (npc.ai[3] >= 60f)
                        {
                            npc.ai[3] = 0f;
                            vector46 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                            num494 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector46.X;
                            num495 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector46.Y;
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                var num499 = (npc.type == ModContent.NPCType<Astigmatazer>()) ? 49 : 20;
                                num496 = (float)Math.Sqrt(num494 * num494 + num495 * num495);
                                num496 = 9f / num496;
                                num494 *= num496;
                                num495 *= num496;
                                num494 += Main.rand.Next(-40, 41) * 0.08f;
                                num495 += Main.rand.Next(-40, 41) * 0.08f;
                                vector46.X += num494 * 15f;
                                vector46.Y += num495 * 15f;
                                Projectile.NewProjectile(vector46.X, vector46.Y, num494, num495, ProjectileID.EyeLaser, num499, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
                else if (npc.ai[1] == 1f)
                {
                    npc.rotation = num487;
                    var vector47 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num502 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector47.X;
                    var num503 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector47.Y;
                    var num504 = (float)Math.Sqrt(num502 * num502 + num503 * num503);
                    num504 = 12f / num504;
                    npc.velocity.X = num502 * num504;
                    npc.velocity.Y = num503 * num504;
                    npc.ai[1] = 2f;
                }
                else if (npc.ai[1] == 2f)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 25f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.96f;
                        npc.velocity.Y = npc.velocity.Y * 0.96f;
                        if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                        {
                            npc.velocity.X = 0f;
                        }
                        if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                        {
                            npc.velocity.Y = 0f;
                        }
                    }
                    else
                    {
                        npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) - 1.57f;
                    }
                    if (npc.ai[2] >= 70f)
                    {
                        npc.ai[3] += 1f;
                        npc.ai[2] = 0f;
                        npc.target = 255;
                        npc.rotation = num487;
                        if (npc.ai[3] >= 4f)
                        {
                            npc.ai[1] = 0f;
                            npc.ai[3] = 0f;
                        }
                        else
                        {
                            npc.ai[1] = 1f;
                        }
                    }
                }
                if (npc.life < npc.lifeMax * 0.4)
                {
                    npc.ai[0] = 1f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] = 0f;
                    npc.netUpdate = true;
                    return;
                }
                return;
            }
            else if (npc.ai[0] == 1f || npc.ai[0] == 2f)
            {
                if (npc.ai[0] == 1f)
                {
                    npc.ai[2] += 0.005f;
                    if (npc.ai[2] > 0.5)
                    {
                        npc.ai[2] = 0.5f;
                    }
                }
                else
                {
                    npc.ai[2] -= 0.005f;
                    if (npc.ai[2] < 0f)
                    {
                        npc.ai[2] = 0f;
                    }
                }
                npc.rotation += npc.ai[2];
                npc.ai[1] += 1f;
                if (npc.ai[1] == 100f)
                {
                    npc.ai[0] += 1f;
                    npc.ai[1] = 0f;
                    if (npc.ai[0] == 3f)
                    {
                        npc.ai[2] = 0f;
                    }
                    else
                    {
                        Main.PlaySound(SoundID.NPCHit, (int)npc.position.X, (int)npc.position.Y, 1);
                        for (var num505 = 0; num505 < 2; num505++)
                        {
                            Gore.NewGore(npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 143, 1f);
                            Gore.NewGore(npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
                            Gore.NewGore(npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
                        }
                        for (var num506 = 0; num506 < 20; num506++)
                        {
                            Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                        }
                        Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 0);
                        npc.HitSound = SoundID.NPCHit4;
                    }
                }
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                npc.velocity.X = npc.velocity.X * 0.98f;
                npc.velocity.Y = npc.velocity.Y * 0.98f;
                if (npc.velocity.X > -0.1 && npc.velocity.X < 0.1)
                {
                    npc.velocity.X = 0f;
                }
                if (npc.velocity.Y > -0.1 && npc.velocity.Y < 0.1)
                {
                    npc.velocity.Y = 0f;
                    return;
                }
                return;
            }
            else
            {
                npc.HitSound = SoundID.NPCHit4;
                npc.damage = (int)(npc.defDamage * 1.5);
                npc.defense = npc.defDefense + 10;
                if (npc.ai[1] == 0f)
                {
                    var vector48 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num509 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector48.X;
                    var num510 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - 300f - vector48.Y;
                    var num511 = (float)Math.Sqrt(num509 * num509 + num510 * num510);
                    num511 = 8f / num511;
                    num509 *= num511;
                    num510 *= num511;
                    if (npc.velocity.X < num509)
                    {
                        npc.velocity.X = npc.velocity.X + 0.15f;
                        if (npc.velocity.X < 0f && num509 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + 0.15f;
                        }
                    }
                    else if (npc.velocity.X > num509)
                    {
                        npc.velocity.X = npc.velocity.X - 0.15f;
                        if (npc.velocity.X > 0f && num509 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - 0.15f;
                        }
                    }
                    if (npc.velocity.Y < num510)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.15f;
                        if (npc.velocity.Y < 0f && num510 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + 0.15f;
                        }
                    }
                    else if (npc.velocity.Y > num510)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.15f;
                        if (npc.velocity.Y > 0f && num510 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - 0.15f;
                        }
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 300f)
                    {
                        npc.ai[1] = 1f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.TargetClosest(true);
                        npc.netUpdate = true;
                    }
                    vector48 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num509 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector48.X;
                    num510 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector48.Y;
                    npc.rotation = (float)Math.Atan2(num510, num509) - 1.57f;
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        return;
                    }
                    npc.localAI[1] += 1f;
                    if (npc.life < npc.lifeMax * 0.75)
                    {
                        npc.localAI[1] += 1f;
                    }
                    if (npc.life < npc.lifeMax * 0.5)
                    {
                        npc.localAI[1] += 1f;
                    }
                    if (npc.life < npc.lifeMax * 0.25)
                    {
                        npc.localAI[1] += 1f;
                    }
                    if (npc.life < npc.lifeMax * 0.1)
                    {
                        npc.localAI[1] += 2f;
                    }
                    if (npc.localAI[1] > 180f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        npc.localAI[1] = 0f;
                        var num513 = (npc.type == ModContent.NPCType<Astigmatazer>()) ? 50 : 25;
                        num511 = (float)Math.Sqrt(num509 * num509 + num510 * num510);
                        num511 = 8.5f / num511;
                        num509 *= num511;
                        num510 *= num511;
                        vector48.X += num509 * 15f;
                        vector48.Y += num510 * 15f;
                        Projectile.NewProjectile(vector48.X, vector48.Y, num509, num510, ProjectileID.DeathLaser, num513, 0f, Main.myPlayer, 0f, 0f);
                        return;
                    }
                    return;
                }
                else
                {
                    var num515 = 1;
                    if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
                    {
                        num515 = -1;
                    }
                    var vector49 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num518 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + num515 * 340 - vector49.X;
                    var num519 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector49.Y;
                    var num520 = (float)Math.Sqrt(num518 * num518 + num519 * num519);
                    num520 = 8f / num520;
                    num518 *= num520;
                    num519 *= num520;
                    if (npc.velocity.X < num518)
                    {
                        npc.velocity.X = npc.velocity.X + 0.2f;
                        if (npc.velocity.X < 0f && num518 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + 0.2f;
                        }
                    }
                    else if (npc.velocity.X > num518)
                    {
                        npc.velocity.X = npc.velocity.X - 0.2f;
                        if (npc.velocity.X > 0f && num518 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - 0.2f;
                        }
                    }
                    if (npc.velocity.Y < num519)
                    {
                        npc.velocity.Y = npc.velocity.Y + 0.2f;
                        if (npc.velocity.Y < 0f && num519 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + 0.2f;
                        }
                    }
                    else if (npc.velocity.Y > num519)
                    {
                        npc.velocity.Y = npc.velocity.Y - 0.2f;
                        if (npc.velocity.Y > 0f && num519 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - 0.2f;
                        }
                    }
                    vector49 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num518 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector49.X;
                    num519 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector49.Y;
                    npc.rotation = (float)Math.Atan2(num519, num518) - 1.57f;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        npc.localAI[1] += 1f;
                        if (npc.life < npc.lifeMax * 0.75)
                        {
                            npc.localAI[1] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.5)
                        {
                            npc.localAI[1] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.25)
                        {
                            npc.localAI[1] += 1f;
                        }
                        if (npc.life < npc.lifeMax * 0.1)
                        {
                            npc.localAI[1] += 2f;
                        }
                        if (npc.localAI[1] > 60f && Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                        {
                            npc.localAI[1] = 0f;
                            var num521 = 9f;
                            var num522 = 18;
                            var num523 = 100;
                            num520 = (float)Math.Sqrt(num518 * num518 + num519 * num519);
                            num520 = num521 / num520;
                            num518 *= num520;
                            num519 *= num520;
                            vector49.X += num518 * 15f;
                            vector49.Y += num519 * 15f;
                            Projectile.NewProjectile(vector49.X, vector49.Y, num518, num519, num523, num522, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 180f)
                    {
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.TargetClosest(true);
                        npc.netUpdate = true;
                        return;
                    }
                    return;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1.0;
            if (npc.frameCounter < 7.0)
            {
                npc.frame.Y = 0;
            }
            else if (npc.frameCounter < 14.0)
            {
                npc.frame.Y = frameHeight;
            }
            else if (npc.frameCounter < 21.0)
            {
                npc.frame.Y = frameHeight * 2;
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
            if (npc.ai[0] > 1f)
            {
                npc.frame.Y = npc.frame.Y + frameHeight * 3;
            }
        }
    }
}
