using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Blahcket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blahcket");
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = -1;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.friendly = true;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 22;
            projectile.height = 22;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            for (int num369 = 0; num369 < 20; num369++)
            {
                int num370 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num370].velocity *= 1.4f;
            }
            for (int num371 = 0; num371 < 10; num371++)
            {
                int num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
                Main.dust[num372].noGravity = true;
                Main.dust[num372].velocity *= 5f;
                num372 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num372].velocity *= 3f;
            }
            int num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore expr_B3F3_cp_0 = Main.gore[num373];
            expr_B3F3_cp_0.velocity.X = expr_B3F3_cp_0.velocity.X + 1f;
            Gore expr_B413_cp_0 = Main.gore[num373];
            expr_B413_cp_0.velocity.Y = expr_B413_cp_0.velocity.Y + 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore expr_B497_cp_0 = Main.gore[num373];
            expr_B497_cp_0.velocity.X = expr_B497_cp_0.velocity.X - 1f;
            Gore expr_B4B7_cp_0 = Main.gore[num373];
            expr_B4B7_cp_0.velocity.Y = expr_B4B7_cp_0.velocity.Y + 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore expr_B53B_cp_0 = Main.gore[num373];
            expr_B53B_cp_0.velocity.X = expr_B53B_cp_0.velocity.X + 1f;
            Gore expr_B55B_cp_0 = Main.gore[num373];
            expr_B55B_cp_0.velocity.Y = expr_B55B_cp_0.velocity.Y - 1f;
            num373 = Gore.NewGore(new Vector2(projectile.position.X, projectile.position.Y), default(Vector2), Main.rand.Next(61, 64), 1f);
            Main.gore[num373].velocity *= 0.4f;
            Gore expr_B5DF_cp_0 = Main.gore[num373];
            expr_B5DF_cp_0.velocity.X = expr_B5DF_cp_0.velocity.X - 1f;
            Gore expr_B5FF_cp_0 = Main.gore[num373];
            expr_B5FF_cp_0.velocity.Y = expr_B5FF_cp_0.velocity.Y - 1f;
        }

        //public override bool OnTileCollide(Vector2 oldVelocity)
        //{
        //    if (projectile.type == ModContent.ProjectileType<BlahBeam>())
        //    {
        //        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
        //        projectile.ai[0] += 1f;
        //        if (projectile.ai[0] >= 4f)
        //        {
        //            projectile.position += projectile.velocity;
        //            projectile.Kill();
        //        }
        //        else
        //        {
        //            if (projectile.velocity.Y != oldVelocity.Y)
        //            {
        //                projectile.velocity.Y = -oldVelocity.Y;
        //            }
        //            if (projectile.velocity.X != oldVelocity.X)
        //            {
        //                projectile.velocity.X = -oldVelocity.X;
        //            }
        //        }
        //    }
        //    return false;
        //}
        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<Blahcket>())
            {
                if (projectile.localAI[0] == 0)
                {
                    projectile.localAI[1] = projectile.velocity.ToRotation();
                    projectile.localAI[0] = projectile.velocity.Length();
                }
                projectile.ai[0]++;
                if (projectile.ai[0] < 45) projectile.velocity.Y += 0.02f; //gravity
                if (projectile.ai[0] == 45)
                {
                    Vector2 dustPoint = projectile.Center;
                    Dust.NewDust(dustPoint - projectile.velocity, projectile.width, projectile.height, 6, projectile.direction * -0.4f, -1.4f);
                    Dust.NewDust(dustPoint - projectile.velocity, projectile.width, projectile.height, 31, projectile.direction * -0.4f, -1.4f, Scale: 1.5f);
                    Dust.NewDust(dustPoint - projectile.velocity, projectile.width, projectile.height, 6, projectile.direction * -0.4f, 1.4f);
                    Dust.NewDust(dustPoint - projectile.velocity, projectile.width, projectile.height, 31, projectile.direction * -0.4f, 1.4f, Scale: 1.5f);

                    projectile.velocity = projectile.localAI[1].ToRotationVector2() * projectile.localAI[0] * 2.1f;
                }
                else
                {
                    for (int num126 = 0; num126 < 5; num126++)
                    {
                        float num127 = projectile.velocity.X / 3f * (float)num126;
                        float num128 = projectile.velocity.Y / 3f * (float)num126;
                        int num129 = 4;
                        int num130 = Dust.NewDust(new Vector2(projectile.position.X + (float)num129, projectile.position.Y + (float)num129), projectile.width - num129 * 2, projectile.height - num129 * 2, 6, 0f, 0f, 100, default(Color), 1.2f);
                        Main.dust[num130].noGravity = true;
                        Main.dust[num130].velocity *= 0.1f;
                        Main.dust[num130].velocity += projectile.velocity * 0.1f;
                        Dust expr_62C2_cp_0 = Main.dust[num130];
                        expr_62C2_cp_0.position.X = expr_62C2_cp_0.position.X - num127;
                        Dust expr_62DD_cp_0 = Main.dust[num130];
                        expr_62DD_cp_0.position.Y = expr_62DD_cp_0.position.Y - num128;
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                        int num131 = 4;
                        int num132 = Dust.NewDust(new Vector2(projectile.position.X + (float)num131, projectile.position.Y + (float)num131), projectile.width - num131 * 2, projectile.height - num131 * 2, 31, 0f, 0f, 100, default(Color), 0.6f);
                        Main.dust[num132].velocity *= 0.25f;
                        Main.dust[num132].velocity += projectile.velocity * 0.5f;
                    }
                }
            }
            if (projectile.alpha < 170)
            {
                for (int n = 0; n < 10; n++)
                {
                    float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)n;
                    float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)n;
                    int num25;
                    if (projectile.type == 207)
                    {
                        num25 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 75, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num25].alpha = projectile.alpha;
                        Main.dust[num25].position.X = x2;
                        Main.dust[num25].position.Y = y2;
                        Main.dust[num25].velocity *= 0f;
                        Main.dust[num25].noGravity = true;
                    }
                    else if (projectile.type == 428)
                    {
                        num25 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 119, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num25].alpha = projectile.alpha;
                        Main.dust[num25].position.X = x2;
                        Main.dust[num25].position.Y = y2;
                        Main.dust[num25].velocity *= 0f;
                        Main.dust[num25].noGravity = true;
                    }
                    else if (projectile.type == 622 || projectile.type == 623)
                    {
                        num25 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 6, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num25].alpha = projectile.alpha;
                        Main.dust[num25].position.X = x2;
                        Main.dust[num25].position.Y = y2;
                        Main.dust[num25].velocity *= 0f;
                        Main.dust[num25].noGravity = true;
                    }
                }
            }
            float num26 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
            float num27 = projectile.localAI[0];
            if (num27 == 0f)
            {
                projectile.localAI[0] = num26;
                num27 = num26;
            }
            if (projectile.alpha > 0)
            {
                projectile.alpha -= 25;
            }
            if (projectile.alpha < 0)
            {
                projectile.alpha = 0;
            }
            float num28 = projectile.position.X;
            float num29 = projectile.position.Y;
            float num30 = (projectile.type == 605 ? 250f : 300f);
            bool flag = false;
            int num31 = 0;
            if (projectile.ai[1] == 0f)
            {
                if (projectile.type == 605)
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
                    }
                }
                else
                {
                    for (int num32 = 0; num32 < 200; num32++)
                    {
                        if (Main.npc[num32].active && !Main.npc[num32].dontTakeDamage && !Main.npc[num32].friendly && Main.npc[num32].lifeMax > 5 && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num32 + 1)))
                        {
                            float num33 = Main.npc[num32].position.X + (float)(Main.npc[num32].width / 2);
                            float num34 = Main.npc[num32].position.Y + (float)(Main.npc[num32].height / 2);
                            float num35 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num33) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num34);
                            if (num35 < num30 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num32].position, Main.npc[num32].width, Main.npc[num32].height))
                            {
                                num30 = num35;
                                num28 = num33;
                                num29 = num34;
                                flag = true;
                                num31 = num32;
                            }
                        }
                    }
                }
                if (flag)
                {
                    projectile.ai[1] = (float)(num31 + 1);
                }
                flag = false;
            }
            if (projectile.ai[1] != 0f)
            {
                int num36 = (int)(projectile.ai[1] - 1f);
                if (projectile.type == 605)
                {
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
                else
                {
                    if (Main.npc[num36].active)
                    {
                        float num37 = Main.npc[num36].position.X + (float)(Main.npc[num36].width / 2);
                        float num38 = Main.npc[num36].position.Y + (float)(Main.npc[num36].height / 2);
                        float num39 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num37) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num38);
                        if (num39 < 1000f)
                        {
                            flag = true;
                            num28 = Main.npc[num36].position.X + (float)(Main.npc[num36].width / 2);
                            num29 = Main.npc[num36].position.Y + (float)(Main.npc[num36].height / 2);
                        }
                    }
                }
            }
            if (flag)
            {
                float num40 = num27;
                Vector2 vector = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num41 = num28 - vector.X;
                float num42 = num29 - vector.Y;
                float num43 = (float)Math.Sqrt((double)(num41 * num41 + num42 * num42));
                num43 = num40 / num43;
                num41 *= num43;
                num42 *= num43;
                int num44 = 8;
                projectile.velocity.X = (projectile.velocity.X * (float)(num44 - 1) + num41) / (float)num44;
                projectile.velocity.Y = (projectile.velocity.Y * (float)(num44 - 1) + num42) / (float)num44;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
