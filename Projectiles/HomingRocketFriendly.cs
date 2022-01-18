using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class HomingRocketFriendly : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Homing Rocket");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
        }
        public override void Kill(int timeLeft)
        {
            foreach (NPC P in Main.npc)
            {
                if (P.getRect().Intersects(projectile.getRect()))
                {
                    P.StrikeNPC(projectile.damage, projectile.knockBack, 0);
                }
            }
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 14);
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 22;
            projectile.height = 22;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            for (int num341 = 0; num341 < 30; num341++)
            {
                int num342 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num342].velocity *= 1.4f;
            }
            for (int num343 = 0; num343 < 20; num343++)
            {
                int num344 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 3.5f);
                Main.dust[num344].noGravity = true;
                Main.dust[num344].velocity *= 7f;
                num344 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 100, default(Color), 1.5f);
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
        }
        public override void AI()
        {
            if (Math.Abs(projectile.velocity.X) >= 5f || Math.Abs(projectile.velocity.Y) >= 5f)
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
                    int num267 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num265, projectile.position.Y + 3f + num266) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, DustID.Fire, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num267].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
                    Main.dust[num267].velocity *= 0.2f;
                    Main.dust[num267].noGravity = true;
                    num267 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num265, projectile.position.Y + 3f + num266) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default(Color), 0.5f);
                    Main.dust[num267].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                    Main.dust[num267].velocity *= 0.05f;
                }
            }
            if (Math.Abs(projectile.velocity.X) < 15f && Math.Abs(projectile.velocity.Y) < 15f)
            {
                projectile.velocity *= 1.1f;
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int p = 0; p < Main.npc.Length; p++)
            {
                if (Main.npc[p].active)
                {
                    if (ClassExtensions.NewRectVector2(Main.npc[p].position, new Vector2(Main.npc[p].width, Main.npc[p].height)).Intersects(ClassExtensions.NewRectVector2(projectile.position, new Vector2(projectile.width, projectile.height))))
                    {
                        projectile.timeLeft = 3;
                        break;
                    }
                }
            }
            if (projectile.timeLeft <= 3)
            {
                projectile.position.X = projectile.position.X + projectile.width / 2;
                projectile.position.Y = projectile.position.Y + projectile.height / 2;
                projectile.width = 128;
                projectile.height = 128;
                projectile.position.X = projectile.position.X - projectile.width / 2;
                projectile.position.Y = projectile.position.Y - projectile.height / 2;
                projectile.knockBack = 8f;
                projectile.Kill();
            }
            float num26 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
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
            var projPosStoredX = projectile.position.X;
            var projPosStoredY = projectile.position.Y;
            var distance = 300f;
            var flag = false;
            var npcArrayIndexStored = 0;
            if (projectile.ai[1] == 0f)
            {
                for (var npcArrayIndex = 0; npcArrayIndex < 200; npcArrayIndex++)
                {
                    if (Main.npc[npcArrayIndex].active && !Main.npc[npcArrayIndex].dontTakeDamage && !Main.npc[npcArrayIndex].friendly && Main.npc[npcArrayIndex].lifeMax > 5 && (projectile.ai[1] == 0f || projectile.ai[1] == npcArrayIndex + 1))
                    {
                        var npcCenterX = Main.npc[npcArrayIndex].position.X + Main.npc[npcArrayIndex].width / 2;
                        var npcCenterY = Main.npc[npcArrayIndex].position.Y + Main.npc[npcArrayIndex].height / 2;
                        var num37 = Math.Abs(projectile.position.X + projectile.width / 2 - npcCenterX) + Math.Abs(projectile.position.Y + projectile.height / 2 - npcCenterY);
                        if (num37 < distance && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[npcArrayIndex].position, Main.npc[npcArrayIndex].width, Main.npc[npcArrayIndex].height))
                        {
                            distance = num37;
                            projPosStoredX = npcCenterX;
                            projPosStoredY = npcCenterY;
                            flag = true;
                            npcArrayIndexStored = npcArrayIndex;
                        }
                    }
                }
                if (flag)
                {
                    projectile.ai[1] = npcArrayIndexStored + 1;
                }
                flag = false;
            }
            if (projectile.ai[1] != 0f)
            {
                var npcArrayIndexAgain = (int)(projectile.ai[1] - 1f);
                if (Main.npc[npcArrayIndexAgain].active)
                {
                    var npcCenterX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
                    var npcCenterY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
                    var num41 = Math.Abs(projectile.position.X + projectile.width / 2 - npcCenterX) + Math.Abs(projectile.position.Y + projectile.height / 2 - npcCenterY);
                    if (num41 < 1000f)
                    {
                        flag = true;
                        projPosStoredX = Main.npc[npcArrayIndexAgain].position.X + Main.npc[npcArrayIndexAgain].width / 2;
                        projPosStoredY = Main.npc[npcArrayIndexAgain].position.Y + Main.npc[npcArrayIndexAgain].height / 2;
                    }
                }
            }
            if (flag)
            {
                var num42 = num27;
                var projCenter = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                var num43 = projPosStoredX - projCenter.X;
                var num44 = projPosStoredY - projCenter.Y;
                var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
                num45 = num42 / num45;
                num43 *= num45;
                num44 *= num45;
                var num46 = 8;
                projectile.velocity.X = (projectile.velocity.X * (num46 - 1) + num43) / num46;
                projectile.velocity.Y = (projectile.velocity.Y * (num46 - 1) + num44) / num46;
            }
        }
    }
}
