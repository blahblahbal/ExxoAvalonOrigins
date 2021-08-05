using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Projectiles{
    public class HomingRocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heat-Seeking Missile");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
        }        public override void Kill(int timeLeft)
        {
            foreach (Player P in Main.player)
            {
                if (P.getRect().Intersects(projectile.getRect()))
                {
                    P.Hurt(PlayerDeathReason.ByProjectile(P.whoAmI, projectile.whoAmI), projectile.damage, 0);
                }
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 22;
            projectile.height = 22;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            for (int num341 = 0; num341 < 30; num341++)
            {
                int num342 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num342].velocity *= 1.4f;
            }
            for (int num343 = 0; num343 < 20; num343++)
            {
                int num344 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3.5f);
                Main.dust[num344].noGravity = true;
                Main.dust[num344].velocity *= 7f;
                num344 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num344].velocity *= 3f;
            }
            for (int num345 = 0; num345 < 2; num345++)
            {
                float scaleFactor8 = 0.4f;
                if (num345 == 1)
                {
                    scaleFactor8 = 0.8f;
                }
                int num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A0B0_cp_0 = Main.gore[num346];
                expr_A0B0_cp_0.velocity.X = expr_A0B0_cp_0.velocity.X + 1f;
                Gore expr_A0D0_cp_0 = Main.gore[num346];
                expr_A0D0_cp_0.velocity.Y = expr_A0D0_cp_0.velocity.Y + 1f;
                num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A153_cp_0 = Main.gore[num346];
                expr_A153_cp_0.velocity.X = expr_A153_cp_0.velocity.X - 1f;
                Gore expr_A173_cp_0 = Main.gore[num346];
                expr_A173_cp_0.velocity.Y = expr_A173_cp_0.velocity.Y + 1f;
                num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A1F6_cp_0 = Main.gore[num346];
                expr_A1F6_cp_0.velocity.X = expr_A1F6_cp_0.velocity.X + 1f;
                Gore expr_A216_cp_0 = Main.gore[num346];
                expr_A216_cp_0.velocity.Y = expr_A216_cp_0.velocity.Y - 1f;
                num346 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
                Main.gore[num346].velocity *= scaleFactor8;
                Gore expr_A299_cp_0 = Main.gore[num346];
                expr_A299_cp_0.velocity.X = expr_A299_cp_0.velocity.X - 1f;
                Gore expr_A2B9_cp_0 = Main.gore[num346];
                expr_A2B9_cp_0.velocity.Y = expr_A2B9_cp_0.velocity.Y - 1f;
            }
        }        //public override void ModifyDamageHitbox(ref Rectangle hitbox)
        //{
        //    base.ModifyDamageHitbox(ref hitbox);
        //}        public override void AI()        {            if (Math.Abs(projectile.velocity.X) >= 5f || Math.Abs(projectile.velocity.Y) >= 5f)
            {
                for (int num264 = 0; num264 < 2; num264++)
                {
                    float num265 = 0f;
                    float num266 = 0f;
                    if (num264 == 1)
                    {
                        num265 = projectile.velocity.X * 0.5f;
                        num266 = projectile.velocity.Y * 0.5f;
                    }
                    int num267 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num265, projectile.position.Y + 3f + num266) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 6, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num267].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
                    Main.dust[num267].velocity *= 0.2f;
                    Main.dust[num267].noGravity = true;
                    num267 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num265, projectile.position.Y + 3f + num266) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
                    Main.dust[num267].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[num267].velocity *= 0.05f;
                }
            }
            if (Math.Abs(projectile.velocity.X) < 15f && Math.Abs(projectile.velocity.Y) < 15f)
            {
                projectile.velocity *= 1.1f;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int p = 0; p < Main.player.Length; p++)
            {
                if (Main.player[p].active)
                {
                    if (ClassExtensions.NewRectVector2(Main.player[p].position, new Vector2(Main.player[p].width, Main.player[p].height)).Intersects(ClassExtensions.NewRectVector2(projectile.position, new Vector2(projectile.width, projectile.height))))
                    {
                        projectile.timeLeft = 3;
                        break;
                    }
                }
            }
            if (projectile.timeLeft <= 3)
            {
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 128;
                projectile.height = 128;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.knockBack = 8f;
                projectile.Kill();
            }            float num28 = projectile.position.X;
            float num29 = projectile.position.Y;
            float num30 = 250f;
            bool flag = false;
            int num31 = 0;            if (projectile.ai[1] == 0f)
            {
                for (int num32 = 0; num32 < Main.player.Length; num32++)
                {
                    if (Main.player[num32].active && Main.player[num32].statLife > 0 && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num32 + 1)))
                    {
                        float num33 = Main.player[num32].position.X + (float)(Main.player[num32].width / 2);
                        float num34 = Main.player[num32].position.Y + (float)(Main.player[num32].height / 2);
                        float num35 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num33) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num34);
                        if (num35 < num30 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.player[num32].position, Main.player[num32].width, Main.player[num32].height))
                        {
                            num30 = num35;
                            num28 = num33;
                            num29 = num34;
                            flag = true;
                            num31 = num32;
                        }
                    }
                }                if (flag)
                {
                    projectile.ai[1] = (float)(num31 + 1);
                }
                flag = false;            }            if (projectile.ai[1] != 0f)
            {
                int num36 = (int)(projectile.ai[1] - 1f);
                if (Main.player[num36].active)
                {
                    float num37 = Main.player[num36].position.X + (float)(Main.player[num36].width / 2);
                    float num38 = Main.player[num36].position.Y + (float)(Main.player[num36].height / 2);
                    float num39 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num37) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num38);
                    if (num39 < 1000f)
                    {
                        flag = true;
                        num28 = Main.player[num36].position.X + (float)(Main.player[num36].width / 2);
                        num29 = Main.player[num36].position.Y + (float)(Main.player[num36].height / 2);
                    }
                }
            }
        }    }}