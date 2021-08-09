using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.NPCs
{
	public class Infernaspaz : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infernaspaz");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults()
		{
			npc.damage = 95;
			npc.boss = true;
			npc.netAlways = true;
			npc.noTileCollide = true;
			npc.lifeMax = 75000;
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
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SoulofFright, Main.rand.Next(5) + 1, false, 0, false);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.SouloftheJungle>(), Main.rand.Next(5) + 1, false, 0, false);
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.LifeDew>(), Main.rand.Next(5) + 1, false, 0, false);
		}

        public override void AI()
        {
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            var dead3 = Main.player[npc.target].dead;
            var num524 = npc.position.X + npc.width / 2 - Main.player[npc.target].position.X - Main.player[npc.target].width / 2;
            var num525 = npc.position.Y + npc.height - 59f - Main.player[npc.target].position.Y - Main.player[npc.target].height / 2;
            var num526 = (float)Math.Atan2(num525, num524) + 1.57f;
            if (num526 < 0f)
            {
                num526 += 6.283f;
            }
            else if (num526 > 6.283)
            {
                num526 -= 6.283f;
            }
            var num527 = 0.15f;
            if (npc.rotation < num526)
            {
                if (num526 - npc.rotation > 3.1415)
                {
                    npc.rotation -= num527;
                }
                else
                {
                    npc.rotation += num527;
                }
            }
            else if (npc.rotation > num526)
            {
                if (npc.rotation - num526 > 3.1415)
                {
                    npc.rotation += num527;
                }
                else
                {
                    npc.rotation -= num527;
                }
            }
            if (npc.rotation > num526 - num527 && npc.rotation < num526 + num527)
            {
                npc.rotation = num526;
            }
            if (npc.rotation < 0f)
            {
                npc.rotation += 6.283f;
            }
            else if (npc.rotation > 6.283)
            {
                npc.rotation -= 6.283f;
            }
            if (npc.rotation > num526 - num527 && npc.rotation < num526 + num527)
            {
                npc.rotation = num526;
            }
            if (Main.rand.Next(5) == 0)
            {
                var num528 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + npc.height * 0.25f), npc.width, (int)(npc.height * 0.5f), 5, npc.velocity.X, 2f, 0, default(Color), 1f);
                var dust42 = Main.dust[num528];
                dust42.velocity.X = dust42.velocity.X * 0.5f;
                var dust43 = Main.dust[num528];
                dust43.velocity.Y = dust43.velocity.Y * 0.1f;
            }
            if (Main.dayTime || dead3)
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
                    npc.TargetClosest(true);
                    var num530 = 12f;
                    var num531 = 0.4f;
                    var num532 = 1;
                    if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
                    {
                        num532 = -1;
                    }
                    var vector50 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num533 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + num532 * 400 - vector50.X;
                    var num534 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector50.Y;
                    var num535 = (float)Math.Sqrt(num533 * num533 + num534 * num534);
                    num535 = num530 / num535;
                    num533 *= num535;
                    num534 *= num535;
                    if (npc.velocity.X < num533)
                    {
                        npc.velocity.X = npc.velocity.X + num531;
                        if (npc.velocity.X < 0f && num533 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num531;
                        }
                    }
                    else if (npc.velocity.X > num533)
                    {
                        npc.velocity.X = npc.velocity.X - num531;
                        if (npc.velocity.X > 0f && num533 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num531;
                        }
                    }
                    if (npc.velocity.Y < num534)
                    {
                        npc.velocity.Y = npc.velocity.Y + num531;
                        if (npc.velocity.Y < 0f && num534 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num531;
                        }
                    }
                    else if (npc.velocity.Y > num534)
                    {
                        npc.velocity.Y = npc.velocity.Y - num531;
                        if (npc.velocity.Y > 0f && num534 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - num531;
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
                    else
                    {
                        if (!Main.player[npc.target].dead)
                        {
                            npc.ai[3] += 1f;
                        }
                        if (npc.ai[3] >= 60f)
                        {
                            npc.ai[3] = 0f;
                            vector50 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                            num533 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector50.X;
                            num534 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector50.Y;
                            if (Main.netMode != NetmodeID.MultiplayerClient)
                            {
                                num535 = (float)Math.Sqrt(num533 * num533 + num534 * num534);
                                num535 = 12f / num535;
                                num533 *= num535;
                                num534 *= num535;
                                num533 += Main.rand.Next(-40, 41) * 0.05f;
                                num534 += Main.rand.Next(-40, 41) * 0.05f;
                                vector50.X += num533 * 4f;
                                vector50.Y += num534 * 4f;
                                int proj = Projectile.NewProjectile(vector50.X, vector50.Y, num533, num534, ModContent.ProjectileType<Projectiles.DarkMatterFireball>(), 60, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[proj].GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
                            }
                        }
                    }
                }
                else if (npc.ai[1] == 1f)
                {
                    npc.rotation = num526;
                    var num539 = 13f;
                    var vector51 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num540 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector51.X;
                    var num541 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector51.Y;
                    var num542 = (float)Math.Sqrt(num540 * num540 + num541 * num541);
                    num542 = num539 / num542;
                    npc.velocity.X = num540 * num542;
                    npc.velocity.Y = num541 * num542;
                    npc.ai[1] = 2f;
                }
                else if (npc.ai[1] == 2f)
                {
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 8f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.9f;
                        npc.velocity.Y = npc.velocity.Y * 0.9f;
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
                    if (npc.ai[2] >= 42f)
                    {
                        npc.ai[3] += 1f;
                        npc.ai[2] = 0f;
                        npc.target = 255;
                        npc.rotation = num526;
                        if (npc.ai[3] >= 10f)
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
                        Main.PlaySound(3, (int)npc.position.X, (int)npc.position.Y, 1);
                        for (var num543 = 0; num543 < 2; num543++)
                        {
                            Gore.NewGore(npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 144, 1f);
                            Gore.NewGore(npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 7, 1f);
                            Gore.NewGore(npc.position, new Vector2(Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f), 6, 1f);
                        }
                        for (var num544 = 0; num544 < 20; num544++)
                        {
                            Dust.NewDust(npc.position, npc.width, npc.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
                        }
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                    }
                }
                Dust.NewDust(npc.position, npc.width, npc.height, 5, Main.rand.Next(-30, 31) * 0.2f, Main.rand.Next(-30, 31) * 0.2f, 0, default(Color), 1f);
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
                npc.defense = npc.defDefense + 18;
                if (npc.ai[1] == 0f)
                {
                    var num545 = 4f;
                    var num546 = 0.1f;
                    var num547 = 1;
                    if (npc.position.X + npc.width / 2 < Main.player[npc.target].position.X + Main.player[npc.target].width)
                    {
                        num547 = -1;
                    }
                    var vector52 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    var num548 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 + num547 * 180 - vector52.X;
                    var num549 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector52.Y;
                    var num550 = (float)Math.Sqrt(num548 * num548 + num549 * num549);
                    num550 = num545 / num550;
                    num548 *= num550;
                    num549 *= num550;
                    if (npc.velocity.X < num548)
                    {
                        npc.velocity.X = npc.velocity.X + num546;
                        if (npc.velocity.X < 0f && num548 > 0f)
                        {
                            npc.velocity.X = npc.velocity.X + num546;
                        }
                    }
                    else if (npc.velocity.X > num548)
                    {
                        npc.velocity.X = npc.velocity.X - num546;
                        if (npc.velocity.X > 0f && num548 < 0f)
                        {
                            npc.velocity.X = npc.velocity.X - num546;
                        }
                    }
                    if (npc.velocity.Y < num549)
                    {
                        npc.velocity.Y = npc.velocity.Y + num546;
                        if (npc.velocity.Y < 0f && num549 > 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y + num546;
                        }
                    }
                    else if (npc.velocity.Y > num549)
                    {
                        npc.velocity.Y = npc.velocity.Y - num546;
                        if (npc.velocity.Y > 0f && num549 < 0f)
                        {
                            npc.velocity.Y = npc.velocity.Y - num546;
                        }
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 400f)
                    {
                        npc.ai[1] = 1f;
                        npc.ai[2] = 0f;
                        npc.ai[3] = 0f;
                        npc.target = 255;
                        npc.netUpdate = true;
                    }
                    if (!Collision.CanHit(npc.position, npc.width, npc.height, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                    {
                        return;
                    }
                    npc.localAI[2] += 1f;
                    if (npc.localAI[2] > 22f)
                    {
                        npc.localAI[2] = 0f;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 34);
                    }
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
                    if (npc.localAI[1] > 8f)
                    {
                        npc.localAI[1] = 0f;
                        var num551 = 6f;
                        vector52 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        num548 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector52.X;
                        num549 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector52.Y;
                        num550 = (float)Math.Sqrt(num548 * num548 + num549 * num549);
                        num550 = num551 / num550;
                        num548 *= num550;
                        num549 *= num550;
                        num549 += Main.rand.Next(-40, 41) * 0.01f;
                        num548 += Main.rand.Next(-40, 41) * 0.01f;
                        num549 += npc.velocity.Y * 0.5f;
                        num548 += npc.velocity.X * 0.5f;
                        vector52.X -= num548 * 1f;
                        vector52.Y -= num549 * 1f;
                        int proj = Projectile.NewProjectile(vector52.X, vector52.Y, num548, num549, ModContent.ProjectileType<Projectiles.DarkMatterFlamethrower>(), 40, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[proj].GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
                        return;
                    }
                    return;
                }
                else
                {
                    if (npc.ai[1] == 1f)
                    {
                        Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                        npc.rotation = num526;
                        var num554 = 14f;
                        var vector53 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                        var num555 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2 - vector53.X;
                        var num556 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2 - vector53.Y;
                        var num557 = (float)Math.Sqrt(num555 * num555 + num556 * num556);
                        num557 = num554 / num557;
                        npc.velocity.X = num555 * num557;
                        npc.velocity.Y = num556 * num557;
                        npc.ai[1] = 2f;
                        return;
                    }
                    if (npc.ai[1] != 2f)
                    {
                        return;
                    }
                    npc.ai[2] += 1f;
                    if (npc.ai[2] >= 50f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.93f;
                        npc.velocity.Y = npc.velocity.Y * 0.93f;
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
                    if (npc.ai[2] < 80f)
                    {
                        return;
                    }
                    npc.ai[3] += 1f;
                    npc.ai[2] = 0f;
                    npc.target = 255;
                    npc.rotation = num526;
                    if (npc.ai[3] >= 6f)
                    {
                        npc.ai[1] = 0f;
                        npc.ai[3] = 0f;
                        return;
                    }
                    npc.ai[1] = 1f;
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