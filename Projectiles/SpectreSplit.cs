﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SpectreSplit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantom Wrath");
        }
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.aiStyle = -1;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.extraUpdates = 3;
        }
        public override void AI()
        {
            Projectile.ai[1] += 1f;
            if (Projectile.ai[1] >= 60f)
            {
                Projectile.friendly = true;
                int num483 = (int)Projectile.ai[0];
                if (!Main.npc[num483].active)
                {
                    num483 = -1;
                    int[] array2 = new int[200];
                    int num484 = 0;
                    for (int num485 = 0; num485 < 200; num485++)
                    {
                        if (Main.npc[num485].CanBeChasedBy(this))
                        {
                            float num486 = Math.Abs(Main.npc[num485].position.X + (float)(Main.npc[num485].width / 2) - Projectile.position.X + (float)(Projectile.width / 2)) + Math.Abs(Main.npc[num485].position.Y + (float)(Main.npc[num485].height / 2) - Projectile.position.Y + (float)(Projectile.height / 2));
                            if (num486 < 800f)
                            {
                                array2[num484] = num485;
                                num484++;
                            }
                        }
                    }
                    if (num484 == 0)
                    {
                        Projectile.Kill();
                        return;
                    }
                    num483 = array2[Main.rand.Next(num484)];
                    Projectile.ai[0] = num483;
                }
                float num487 = 4f;
                Vector2 vector27 = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num488 = Main.npc[num483].Center.X - vector27.X;
                float num489 = Main.npc[num483].Center.Y - vector27.Y;
                float num490 = (float)Math.Sqrt(num488 * num488 + num489 * num489);
                float num491 = num490;
                num490 = num487 / num490;
                num488 *= num490;
                num489 *= num490;
                int num492 = 30;
                Projectile.velocity.X = (Projectile.velocity.X * (float)(num492 - 1) + num488) / (float)num492;
                Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num492 - 1) + num489) / (float)num492;
            }
            for (int num493 = 0; num493 < 1; num493++)
            {
                float num494 = Projectile.velocity.X * 0.2f * (float)num493;
                float num495 = (0f - Projectile.velocity.Y * 0.2f) * (float)num493;
                int num496 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.DungeonSpirit, 0f, 0f, 100, default(Color), 1.3f);
                Main.dust[num496].noGravity = true;
                Dust dust = Main.dust[num496];
                dust.velocity *= 0f;
                Main.dust[num496].position.X -= num494;
                Main.dust[num496].position.Y -= num495;
            }
        }
    }
}
