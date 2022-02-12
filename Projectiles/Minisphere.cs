using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Minisphere : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Minisphere");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Minisphere");
            projectile.width = dims.Width * 14 / 20;
            projectile.height = dims.Height * 14 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.alpha = 0;
            projectile.timeLeft = 150;
            projectile.melee = true;
            projectile.noEnchantments = true;
        }
        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<Minisphere>())
            {
                if (projectile.ai[0] == 0f)
                {
                    projectile.ai[0] = projectile.velocity.X;
                    projectile.ai[1] = projectile.velocity.Y;
                }
                if (projectile.velocity.X > 0f)
                {
                    //projectile.rotation += (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f; ??? why this
                }
                else
                {
                    //projectile.rotation -= (Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X)) * 0.001f; ???
                }
                if (projectile.type != ModContent.ProjectileType<Minisphere>())
                {
                    projectile.frameCounter++;
                    if (projectile.frameCounter > 6)
                    {
                        projectile.frameCounter = 0;
                        projectile.frame++;
                        if (projectile.frame > 4)
                        {
                            projectile.frame = 0;
                        }
                    }
                }
                if (Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y) > 2.0)
                {
                    projectile.velocity *= 0.98f;
                }
                for (var num583 = 0; num583 < 1000; num583++)
                {
                    if (num583 != projectile.whoAmI && Main.projectile[num583].active && Main.projectile[num583].owner == projectile.owner && Main.projectile[num583].type == projectile.type && projectile.timeLeft > Main.projectile[num583].timeLeft && Main.projectile[num583].timeLeft > 30)
                    {
                        Main.projectile[num583].timeLeft = 30;
                    }
                }
                var array = new int[20];
                var num584 = 0;
                var num585 = 300f;
                if (projectile.type == ModContent.ProjectileType<Minisphere>())
                {
                    num585 = 600f;
                }
                var flag21 = false;
                for (var num586 = 0; num586 < 200; num586++)
                {
                    if (Main.npc[num586].active && !Main.npc[num586].dontTakeDamage && !Main.npc[num586].friendly && Main.npc[num586].lifeMax > 5)
                    {
                        var num587 = Main.npc[num586].position.X + Main.npc[num586].width / 2;
                        var num588 = Main.npc[num586].position.Y + Main.npc[num586].height / 2;
                        var num589 = Math.Abs(projectile.position.X + projectile.width / 2 - num587) + Math.Abs(projectile.position.Y + projectile.height / 2 - num588);
                        if (num589 < num585 && Collision.CanHit(projectile.Center, 1, 1, Main.npc[num586].Center, 1, 1))
                        {
                            if (num584 < 20)
                            {
                                array[num584] = num586;
                                num584++;
                            }
                            flag21 = true;
                        }
                    }
                }
                if (flag21)
                {
                    var num590 = Main.rand.Next(num584);
                    num590 = array[num590];
                    var num591 = Main.npc[num590].position.X + Main.npc[num590].width / 2;
                    var num592 = Main.npc[num590].position.Y + Main.npc[num590].height / 2;
                    projectile.localAI[0] += 1f;
                    if (projectile.localAI[0] > 8f)
                    {
                        projectile.localAI[0] = 0f;
                        var num593 = 6f;
                        var value7 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                        value7 += projectile.velocity * 4f;
                        var num594 = num591 - value7.X;
                        var num595 = num592 - value7.Y;
                        var num596 = (float)Math.Sqrt(num594 * num594 + num595 * num595);
                        num596 = num593 / num596;
                        num594 *= num596;
                        num595 *= num596;
                        var num597 = Projectile.NewProjectile(value7.X, value7.Y, num594, num595, ProjectileID.MagnetSphereBolt, (projectile.type == ModContent.ProjectileType<Minisphere>()) ? (projectile.damage / 3 * 2) : projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                        if (projectile.type == ModContent.ProjectileType<Minisphere>())
                        {
                            Main.projectile[num597].magic = false;
                            Main.projectile[num597].melee = true;
                        }
                    }
                }
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item54, projectile.position);
            for (int num237 = 0; num237 < 20; num237++)
            {
                int num238 = 10;
                int num239 = Dust.NewDust(projectile.Center - Vector2.One * num238, num238 * 2, num238 * 2, DustID.BubbleBurst_White);
                Dust dust30 = Main.dust[num239];
                Vector2 vector30 = Vector2.Normalize(dust30.position - projectile.Center);
                dust30.position = projectile.Center + vector30 * num238 * projectile.scale;
                if (num237 < 30)
                {
                    dust30.velocity = vector30 * dust30.velocity.Length();
                }
                else
                {
                    dust30.velocity = vector30 * Main.rand.Next(45, 91) / 10f;
                }
                dust30.color = Main.hslToRgb((float)(0.40000000596046448 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
                dust30.color = Color.Lerp(dust30.color, Color.White, 0.3f);
                dust30.noGravity = true;
                dust30.scale = 0.7f;
            }
        }
    }
}