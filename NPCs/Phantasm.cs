﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.NPCs
{
    [AutoloadBossHead]
    public class Phantasm : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantasm");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = npc.height = 70;
            npc.boss = npc.noTileCollide = npc.noGravity = true;
            npc.npcSlots = 100f;
            npc.damage = 65;
            npc.lifeMax = 47800;
            npc.defense = 55;
            npc.aiStyle = -1;
            npc.value = 100000f;
            npc.knockBackResist = 0f;
            npc.scale = 1.5f;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath39;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 255);
        }
        public override void AI()
        {
            npc.rotation = npc.velocity.X * 0.02f;
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 2f, 2f, 2f);
            npc.TargetClosest(true);
            //if (alpha > 0) alpha--;
            if (Main.player[npc.target].dead) // || !Main.player[target].zoneHellcastle)
            {
                npc.velocity.Y = npc.velocity.Y - 0.04f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                    return;
                }
            }
            if (npc.life > npc.lifeMax * 0.75)
            {
                if (Main.player[npc.target].position.X < npc.position.X)
                {
                    if (npc.velocity.X > -8) npc.velocity.X -= 0.22f;
                }
                if (Main.player[npc.target].position.X > npc.position.X)
                {
                    if (npc.velocity.X < 8) npc.velocity.X += 0.22f;
                }
                if (Main.player[npc.target].position.Y < npc.position.Y + 300)
                {
                    if (npc.velocity.Y < 0)
                    {
                        if (npc.velocity.Y > -4) npc.velocity.Y -= 0.8f;
                    }
                    else npc.velocity.Y -= 0.6f;
                    if (npc.velocity.Y < -4) npc.velocity.Y = -4;
                }
                if (Main.player[npc.target].position.Y > npc.position.Y + 300)
                {
                    if (npc.velocity.Y > 0)
                    {
                        if (npc.velocity.Y < 4) npc.velocity.Y += 0.8f;
                    }
                    else npc.velocity.Y += 0.6f;
                    if (npc.velocity.Y > 4) npc.velocity.Y = 4;
                }
                npc.ai[1]++;
                // fire ghostflame orbs
                if (npc.ai[1] >= 150)
                {
                    float rotation = (float)Math.Atan2(npc.Center.Y - Main.player[npc.target].Center.Y, npc.Center.X - Main.player[npc.target].Center.X);
                    float speed = 12f;
                    float f = 0;
                    int p;
                    while (f <= 0.3f)
                    {
                        p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation + f) * speed) * -1), (float)((Math.Sin(rotation + f) * 12f) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 40, 0f, npc.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        //Main.projectile[p].notReflect = true;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        if (Main.netMode != 0)
                        {
                            NetMessage.SendData(27, -1, -1, NetworkText.Empty, p);
                        }
                        p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation - f) * speed) * -1), (float)((Math.Sin(rotation - f) * 12f) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 40, 0f, npc.target);
                        Main.projectile[p].timeLeft = 600;
                        Main.projectile[p].friendly = false;
                        //Main.projectile[p].notReflect = true;
                        Main.projectile[p].hostile = true;
                        Main.projectile[p].tileCollide = false;
                        if (Main.netMode != 0)
                        {
                            NetMessage.SendData(27, -1, -1, NetworkText.Empty, p);
                        }
                        f += 0.1f;
                    }
                    npc.ai[1] = 0;
                }
            }
            // ai phase 2; swooping attack and charging mah laser
            else if (npc.life <= npc.lifeMax * 0.75 && npc.life > npc.lifeMax / 3)
            {
                if (npc.ai[1] <= 3)
                {
                    // swooping attack
                    // after swooping attack, increment ai[1]
                    // using ai[2] to create the swooping attack
                    npc.ai[2]++;
                    npc.ai[0] = 1;
                    if (npc.ai[2] <= 300)
                    {
                        Player T = Main.player[npc.target];
                        npc.velocity *= 0f;
                        npc.position = ExxoAvalonOriginsWorld.LoK * 16;
                        if (npc.ai[2] % 20 == 0)
                        {
                            float Speed = 9f;
                            int damage = 50;
                            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 33).Volume *= 0.8f;
                            Vector2 offset = new Vector2(npc.Center.X + Main.rand.Next(5) * npc.direction, npc.Center.Y + Main.rand.Next(5, 10));
                            float rotation = (float)Math.Atan2(npc.Center.Y, npc.Center.X);
                            int num54 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), damage, 0f, 0);
                            Main.projectile[num54].velocity = Vector2.Normalize(T.position - npc.position) * 9f;
                            //Main.projectile[num54].notReflect = true;
                        }
                    }
                    if (npc.ai[2] == 301)
                    {
                        npc.ai[1]++;
                        npc.ai[2] = 0;
                    }
                }
                if (npc.ai[1] >= 4 && npc.ai[1] < 305)
                {
                    npc.ai[1]++;
                    npc.velocity *= 0f;
                    npc.position = ExxoAvalonOriginsWorld.LoK * 16;
                    if (npc.ai[1] % 75 == 0)
                    {
                        Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/LaserFire"));
                        // fire laser
                        Vector2 velocityOfProj = Main.player[npc.target].Center - npc.Center;
                        velocityOfProj.Normalize();
                        float num1275 = -1f;
                        if (velocityOfProj.X < 0f)
                        {
                            num1275 = 1f;
                        }
                        velocityOfProj = velocityOfProj.RotatedBy((double)((0f - num1275) * MathHelper.TwoPi / 6f));
                        int p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + npc.width / 3, velocityOfProj.X, velocityOfProj.Y, ModContent.ProjectileType<Projectiles.PhantasmLaser>(), 45, 0f, Main.myPlayer, num1275 * MathHelper.TwoPi / 720f, (float)npc.whoAmI);
                        npc.localAI[1] += 0.05f;
                        if (npc.localAI[1] > 1f)
                        {
                            npc.localAI[1] = 1f;
                        }
                        float num1277 = 1;
                        if (num1277 < 0f)
                        {
                            num1277 *= -1f;
                        }
                        num1277 += MathHelper.Pi * -3;
                        num1277 += MathHelper.TwoPi / 720f;
                        npc.localAI[0] = num1277;
                    }
                    if (npc.ai[1] == 304)
                    {
                        npc.ai[1] = 0;
                    }
                }
            }
            // ai phase 3, fire spiral spread of ghostflame orbs
            else
            {
                npc.velocity *= 0f;
                npc.position = ExxoAvalonOriginsWorld.LoK * 16; // new Vector2(Main.maxTilesX / 3 + 168, Main.maxTilesY - 140 + 57) * 16;
                npc.ai[3]++;
                if (npc.ai[3] >= 300)
                {
                    npc.dontTakeDamage = true;
                    npc.position = ExxoAvalonOriginsWorld.LoK * 16; // new Vector2(Main.maxTilesX / 3 + 168, Main.maxTilesY - 140 + 57) * 16;
                    npc.velocity *= 0f;
                    npc.ai[1]++;
                    if (npc.ai[1] >= 250) npc.ai[1] = 250;
                    npc.ai[0]++;
                    Vector2 offset = new Vector2(npc.Center.X + 20, npc.Center.Y + 20);
                    Vector2 offset2 = new Vector2(npc.Center.X - 20, npc.Center.Y - 20);
                    Vector2 offset3 = new Vector2(npc.Center.X + 20, npc.Center.Y - 20);
                    Vector2 offset4 = new Vector2(npc.Center.X - 20, npc.Center.Y + 20);
                    float rotation = (float)Math.Atan2(npc.Center.Y - offset.Y, npc.Center.X - offset.X);
                    float rotation2 = (float)Math.Atan2(npc.Center.Y - offset2.Y, npc.Center.X - offset2.X);
                    float rotation3 = (float)Math.Atan2(npc.Center.Y - offset3.Y, npc.Center.X - offset3.X);
                    float rotation4 = (float)Math.Atan2(npc.Center.Y - offset4.Y, npc.Center.X - offset4.X);
                    float speed = 8f;
                    int p;
                    if (npc.ai[1] == 50 || npc.ai[1] == 100 || npc.ai[1] == 150 || npc.ai[1] == 200)
                    {
                        NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<NPCs.PhantasmMinion>());
                    }
                    if (npc.ai[0] % 10 == 0)
                    {
                        if (npc.ai[2] <= 7.2f)
                        {
                            p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation - npc.ai[2]) * speed) * -1), (float)((Math.Sin(rotation - npc.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 40, 0f, npc.target);
                            Main.projectile[p].timeLeft = 600;
                            Main.projectile[p].friendly = false;
                            //Main.projectile[p].notReflect = true;
                            Main.projectile[p].hostile = true;
                            Main.projectile[p].tileCollide = false;
                            if (Main.netMode != 0)
                            {
                                NetMessage.SendData(27, -1, -1, NetworkText.Empty, p);
                            }
                            p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation2 - npc.ai[2]) * speed) * -1), (float)((Math.Sin(rotation2 - npc.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 40, 0f, npc.target);
                            Main.projectile[p].timeLeft = 600;
                            Main.projectile[p].friendly = false;
                            Main.projectile[p].hostile = true;
                            Main.projectile[p].tileCollide = false;
                            if (Main.netMode != 0)
                            {
                                NetMessage.SendData(27, -1, -1, NetworkText.Empty, p);
                            }
                            p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation3 - npc.ai[2]) * speed) * -1), (float)((Math.Sin(rotation3 - npc.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 40, 0f, npc.target);
                            Main.projectile[p].timeLeft = 600;
                            Main.projectile[p].friendly = false;
                            Main.projectile[p].hostile = true;
                            Main.projectile[p].tileCollide = false;
                            if (Main.netMode != 0)
                            {
                                NetMessage.SendData(27, -1, -1, NetworkText.Empty, p);
                            }
                            p = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)((Math.Cos(rotation4 - npc.ai[2]) * speed) * -1), (float)((Math.Sin(rotation4 - npc.ai[2]) * speed) * -1), ModContent.ProjectileType<Projectiles.Ghostflame>(), 40, 0f, npc.target);
                            Main.projectile[p].timeLeft = 600;
                            Main.projectile[p].friendly = false;
                            Main.projectile[p].hostile = true;
                            Main.projectile[p].tileCollide = false;
                            if (Main.netMode != 0)
                            {
                                NetMessage.SendData(27, -1, -1, NetworkText.Empty, p);
                            }
                            if (npc.ai[2] >= 7.2f)
                            {
                                npc.ai[2] = 0;
                                npc.ai[0] = 0;
                                npc.ai[1] = 0;
                                //return;
                            }
                        }
                        npc.ai[2] += .18f;
                    }
                    if (npc.ai[0] == 400 || npc.ai[0] == 450 || npc.ai[0] == 500 || npc.ai[0] == 550)
                    {
                        Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/LaserFire"));
                        Vector2 velocityOfProj = Main.player[npc.target].Center - npc.Center;
                        velocityOfProj.Normalize();
                        float num1275 = -1f;
                        if (velocityOfProj.X < 0f)
                        {
                            num1275 = 1f;
                        }
                        velocityOfProj = velocityOfProj.RotatedBy((double)((0f - num1275) * MathHelper.TwoPi / 6f));
                        int p2 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, velocityOfProj.X, velocityOfProj.Y, ModContent.ProjectileType<Projectiles.PhantasmLaser>(), 45, 0f, Main.myPlayer, num1275 * MathHelper.TwoPi / 720f, (float)npc.whoAmI);
                        Main.projectile[p2].localAI[0] += 120;
                        npc.localAI[1] += 0.05f;
                        if (npc.localAI[1] > 1f)
                        {
                            npc.localAI[1] = 1f;
                        }
                        float num1277 = 1;
                        if (num1277 < 0f)
                        {
                            num1277 *= -1f;
                        }
                        num1277 += MathHelper.Pi * -3;
                        num1277 += MathHelper.TwoPi / 720f;
                        npc.localAI[0] = num1277;
                    }

                    if (npc.ai[0] == 600)
                    {
                        npc.ai[0] = 0;
                        npc.ai[2] = 0;
                        npc.ai[1] = 0;
                        npc.ai[3] = 0;
                        if (NPC.AnyNPCs(ModContent.NPCType<NPCs.PhantasmMinion>())) { }
                        else npc.dontTakeDamage = false;
                    }
                }
            }
        }

        public override void NPCLoot()
        {
            if (!ExxoAvalonOriginsWorld.downedPhantasm)
            {
                if (Main.netMode == 0)
                {
                    Main.NewText("The spirits are stirring in the depths!", 50, 255, 130, false);
                }
                else if (Main.netMode == 2)
                {
                    NetMessage.SendData(25, -1, -1, NetworkText.FromLiteral("The spirits are stirring in the depths!"), 255, 50f, 255f, 130f, 0);
                }
                ExxoAvalonOriginsWorld.downedPhantasm = true;
            }
            int drop = Main.rand.Next(3);
            if (drop == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.PhantomKnives>(), 1, false, -1);
            }
            if (drop == 1)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.EtherealHeart>(), 1, false, -1);
            }
            if (drop == 2)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.VampireTeeth>(), 1, false, -1);
            }
            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.GhostintheMachine>(), Main.rand.Next(3, 6), false, 0);
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<Items.PhantasmTrophy>(), 1, false, 0);
            }
            for (int i = 0; i < 40; i++)
            {
                int num890 = Dust.NewDust(npc.position, npc.width, npc.height, 180, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num890].velocity *= 5f;
                Main.dust[num890].scale = 1.5f;
                Main.dust[num890].noGravity = true;
                Main.dust[num890].fadeIn = 2f;
            }
            for (int i = 0; i < 20; i++)
            {
                int num893 = Dust.NewDust(npc.position, npc.width, npc.height, 180, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num893].velocity *= 2f;
                Main.dust[num893].scale = 1.5f;
                Main.dust[num893].noGravity = true;
                Main.dust[num893].fadeIn = 3f;
            }
            for (int i = 0; i < 40; i++)
            {
                int num892 = Dust.NewDust(npc.position, npc.width, npc.height, 175, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num892].velocity *= 5f;
                Main.dust[num892].scale = 1.5f;
                Main.dust[num892].noGravity = true;
                Main.dust[num892].fadeIn = 2f;
            }
            for (int i = 0; i < 40; i++)
            {
                int num891 = Dust.NewDust(npc.position, npc.width, npc.height, 180, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num891].velocity *= 10f;
                Main.dust[num891].scale = 1.5f;
                Main.dust[num891].noGravity = true;
                Main.dust[num891].fadeIn = 1.5f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= 4.0)
            {
                npc.frame.Y = npc.frame.Y + frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
            }
        }
    }
}