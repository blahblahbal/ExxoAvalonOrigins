using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BerserkerBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BerserkerBullet");
            projectile.width = dims.Width * 4 / 20;
            projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.light = 0.8f;
            projectile.alpha = 255;
            projectile.MaxUpdates = 2;
            projectile.scale = 1.2f;
            projectile.timeLeft = 600;
            projectile.ranged = true;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int num133 = 0; num133 < 3; num133++)
            {
                float num134 = -projectile.velocity.X * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                float num135 = -projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
                Projectile.NewProjectile(projectile.position.X + num134, projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<BerserkerCrystal>(), (int)((double)projectile.damage * 0.5), 0f, projectile.owner, 0f, 0f);
            }
        }

        public override void AI()
        {
            if (projectile.alpha < 170)
            {
                for (var num26 = 0; num26 < 10; num26++)
                {
                    var x2 = projectile.position.X - projectile.velocity.X / 10f * num26;
                    var y2 = projectile.position.Y - projectile.velocity.Y / 10f * num26;
                    int num27;
                    num27 = Dust.NewDust(new Vector2(x2, y2), 1, 1, DustID.Ice_Pink, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num27].alpha = projectile.alpha;
                    Main.dust[num27].position.X = x2;
                    Main.dust[num27].position.Y = y2;
                    Main.dust[num27].velocity *= 0f;
                    Main.dust[num27].noGravity = true;
                }
            }
            var num28 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            var num29 = projectile.localAI[0];
            if (num29 == 0f)
            {
                projectile.localAI[0] = num28;
                num29 = num28;
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
                var num42 = num29;
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
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}
