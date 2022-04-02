﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class HomingRocket : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Heat-Seeking Missile");
    }

    public override void SetDefaults()
    {
        Projectile.width = 14;
        Projectile.height = 14;
        Projectile.aiStyle = -1;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = 1;
        Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;

    }
    public override void Kill(int timeLeft)
    {
        foreach (Player P in Main.player)
        {
            if (P.getRect().Intersects(Projectile.getRect()))
            {
                P.Hurt(PlayerDeathReason.ByProjectile(P.whoAmI, Projectile.whoAmI), Projectile.damage, 0);
            }
        }
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 14);
        Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
        Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
        Projectile.width = 22;
        Projectile.height = 22;
        Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
        Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
        for (int num341 = 0; num341 < 30; num341++)
        {
            int num342 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num342].velocity *= 1.4f;
        }
        for (int num343 = 0; num343 < 20; num343++)
        {
            int num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 3.5f);
            Main.dust[num344].noGravity = true;
            Main.dust[num344].velocity *= 7f;
            num344 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[num344].velocity *= 3f;
        }
        for (int num345 = 0; num345 < 2; num345++)
        {
            float scaleFactor8 = 0.4f;
            if (num345 == 1)
            {
                scaleFactor8 = 0.8f;
            }
            int num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A0B0_cp_0 = Main.gore[num346];
            expr_A0B0_cp_0.velocity.X = expr_A0B0_cp_0.velocity.X + 1f;
            Gore expr_A0D0_cp_0 = Main.gore[num346];
            expr_A0D0_cp_0.velocity.Y = expr_A0D0_cp_0.velocity.Y + 1f;
            num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A153_cp_0 = Main.gore[num346];
            expr_A153_cp_0.velocity.X = expr_A153_cp_0.velocity.X - 1f;
            Gore expr_A173_cp_0 = Main.gore[num346];
            expr_A173_cp_0.velocity.Y = expr_A173_cp_0.velocity.Y + 1f;
            num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A1F6_cp_0 = Main.gore[num346];
            expr_A1F6_cp_0.velocity.X = expr_A1F6_cp_0.velocity.X + 1f;
            Gore expr_A216_cp_0 = Main.gore[num346];
            expr_A216_cp_0.velocity.Y = expr_A216_cp_0.velocity.Y - 1f;
            num346 = Gore.NewGore(new Vector2(Projectile.position.X, Projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num346].velocity *= scaleFactor8;
            Gore expr_A299_cp_0 = Main.gore[num346];
            expr_A299_cp_0.velocity.X = expr_A299_cp_0.velocity.X - 1f;
            Gore expr_A2B9_cp_0 = Main.gore[num346];
            expr_A2B9_cp_0.velocity.Y = expr_A2B9_cp_0.velocity.Y - 1f;
        }
    }
    //public override void ModifyDamageHitbox(ref Rectangle hitbox)
    //{
    //    base.ModifyDamageHitbox(ref hitbox);
    //}
    public override void AI()
    {
        if (Math.Abs(Projectile.velocity.X) >= 5f || Math.Abs(Projectile.velocity.Y) >= 5f)
        {
            for (int num264 = 0; num264 < 2; num264++)
            {
                float num265 = 0f;
                float num266 = 0f;
                if (num264 == 1)
                {
                    num265 = Projectile.velocity.X * 0.5f;
                    num266 = Projectile.velocity.Y * 0.5f;
                }
                int num267 = Dust.NewDust(new Vector2(Projectile.position.X + 3f + num265, Projectile.position.Y + 3f + num266) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Torch, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num267].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
                Main.dust[num267].velocity *= 0.2f;
                Main.dust[num267].noGravity = true;
                num267 = Dust.NewDust(new Vector2(Projectile.position.X + 3f + num265, Projectile.position.Y + 3f + num266) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default(Color), 0.5f);
                Main.dust[num267].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[num267].velocity *= 0.05f;
            }
        }
        if (Math.Abs(Projectile.velocity.X) < 15f && Math.Abs(Projectile.velocity.Y) < 15f)
        {
            Projectile.velocity *= 1.1f;
        }
        Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
        for (int p = 0; p < Main.player.Length; p++)
        {
            if (Main.player[p].active)
            {
                if (ClassExtensions.NewRectVector2(Main.player[p].position, new Vector2(Main.player[p].width, Main.player[p].height)).Intersects(ClassExtensions.NewRectVector2(Projectile.position, new Vector2(Projectile.width, Projectile.height))))
                {
                    Projectile.timeLeft = 3;
                    break;
                }
            }
        }
        if (Projectile.timeLeft <= 3)
        {
            Projectile.position.X = Projectile.position.X + (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y + (float)(Projectile.height / 2);
            Projectile.width = 128;
            Projectile.height = 128;
            Projectile.position.X = Projectile.position.X - (float)(Projectile.width / 2);
            Projectile.position.Y = Projectile.position.Y - (float)(Projectile.height / 2);
            Projectile.knockBack = 8f;
            Projectile.Kill();
        }
        float num26 = (float)Math.Sqrt((double)(Projectile.velocity.X * Projectile.velocity.X + Projectile.velocity.Y * Projectile.velocity.Y));
        float num27 = Projectile.localAI[0];
        if (num27 == 0f)
        {
            Projectile.localAI[0] = num26;
            num27 = num26;
        }
        if (Projectile.alpha > 0)
        {
            Projectile.alpha -= 25;
        }
        if (Projectile.alpha < 0)
        {
            Projectile.alpha = 0;
        }
        float num28 = Projectile.position.X;
        float num29 = Projectile.position.Y;
        float num30 = 250f;
        bool flag = false;
        int num31 = 0;
        if (Projectile.ai[1] == 0)
        {
            for (int num32 = 0; num32 < Main.player.Length; num32++)
            {
                if (Main.player[num32].active && Main.player[num32].statLife > 0 && (Projectile.ai[1] == 0f || Projectile.ai[1] == (float)(num32 + 1)))
                {
                    float num33 = Main.player[num32].position.X + (float)(Main.player[num32].width / 2);
                    float num34 = Main.player[num32].position.Y + (float)(Main.player[num32].height / 2);
                    float num35 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num33) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num34);
                    if (num35 < num30 && Collision.CanHit(new Vector2(Projectile.position.X + (float)(Projectile.width / 2), Projectile.position.Y + (float)(Projectile.height / 2)), 1, 1, Main.player[num32].position, Main.player[num32].width, Main.player[num32].height))
                    {
                        num30 = num35;
                        num28 = num33;
                        num29 = num34;
                        flag = true;
                        num31 = num32;
                    }
                }
            }
            if (flag)
            {
                Projectile.ai[1] = (float)(num31 + 1);
            }
            flag = false;
        }
        if (Projectile.ai[1] != 0f)
        {
            int num36 = (int)(Projectile.ai[1] - 1f);
            if (Main.player[num36].active)
            {
                float num37 = Main.player[num36].position.X + (float)(Main.player[num36].width / 2);
                float num38 = Main.player[num36].position.Y + (float)(Main.player[num36].height / 2);
                float num39 = Math.Abs(Projectile.position.X + (float)(Projectile.width / 2) - num37) + Math.Abs(Projectile.position.Y + (float)(Projectile.height / 2) - num38);
                if (num39 < 1000f)
                {
                    flag = true;
                    num28 = Main.player[num36].position.X + (float)(Main.player[num36].width / 2);
                    num29 = Main.player[num36].position.Y + (float)(Main.player[num36].height / 2);
                }
            }
        }
        if (flag)
        {
            float num40 = num27;
            Vector2 vector = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
            float num41 = num28 - vector.X;
            float num42 = num29 - vector.Y;
            float num43 = (float)Math.Sqrt((double)(num41 * num41 + num42 * num42));
            num43 = num40 / num43;
            num41 *= num43;
            num42 *= num43;
            int num44 = 8;
            Projectile.velocity.X = (Projectile.velocity.X * (float)(num44 - 1) + num41) / (float)num44;
            Projectile.velocity.Y = (Projectile.velocity.Y * (float)(num44 - 1) + num42) / (float)num44;
        }
    }
}