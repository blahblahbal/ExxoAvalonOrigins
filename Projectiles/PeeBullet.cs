using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PeeBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pee Bullet");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/PeeBullet");
            projectile.width = dims.Width * 4 / 20;
            projectile.height = dims.Height * 4 / 20 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.light = 0.7f;
            projectile.alpha = 0;
            projectile.MaxUpdates = 1;
            projectile.scale = 1f;
            projectile.timeLeft = 1200;
            projectile.ranged = true;
        }

        public override void AI()
        {
            if ((projectile.type == ModContent.ProjectileType<MissileBolt>() && projectile.ai[1] < 45f) || (projectile.type != ModContent.ProjectileType<VileSpit>() && projectile.type != ModContent.ProjectileType<RottenBullet>() && projectile.type != ModContent.ProjectileType<PatellaBullet>() && projectile.type != ModContent.ProjectileType<Soundwave>() && projectile.type != ModContent.ProjectileType<FeroziumBullet>() && projectile.type != ModContent.ProjectileType<Electrobullet>() && projectile.type != ModContent.ProjectileType<SpikeCannon>() && projectile.type != ModContent.ProjectileType<PathogenBullet>() && projectile.type != ModContent.ProjectileType<MagmaticBullet>() && projectile.type != ModContent.ProjectileType<TritonBullet>() && projectile.type != ModContent.ProjectileType<FocusBeam>() && projectile.type != ModContent.ProjectileType<VileSpit>() && projectile.type != ModContent.ProjectileType<InfectiousSpore>()))
            {
                projectile.ai[0] += 1f;
            }
            if (projectile.type == ModContent.ProjectileType<VileSpit>())
            {
                for (var j = 0; j < 2; j++)
                {
                    var num19 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width, projectile.height, DustID.Vile, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 80, default(Color), 1.3f);
                    Main.dust[num19].velocity *= 0.3f;
                    Main.dust[num19].noGravity = true;
                }
            }
            if (projectile.type == ModContent.ProjectileType<InfectiousSpore>())
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 6)
                {
                    projectile.frame++;
                    projectile.frameCounter = 0;
                }
                if (projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
            if (projectile.type == ModContent.ProjectileType<KunzitePulseBolt>())
            {
                if (projectile.alpha < 170)
                {
                    for (var n = 0; n < 10; n++)
                    {
                        var x = projectile.position.X - projectile.velocity.X / 10f * n;
                        var y = projectile.position.Y - projectile.velocity.Y / 10f * n;
                        var num25 = Dust.NewDust(new Vector2(x, y), 1, 1, DustID.UnusedWhiteBluePurple, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num25].alpha = projectile.alpha;
                        Main.dust[num25].position.X = x;
                        Main.dust[num25].position.Y = y;
                        Main.dust[num25].velocity *= 0f;
                        Main.dust[num25].noGravity = true;
                    }
                }
                if (projectile.alpha > 0)
                {
                    projectile.alpha -= 25;
                }
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
            }
            else if (projectile.type == ModContent.ProjectileType<BerserkerBullet>())
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
                var num30 = projectile.position.X;
                var num31 = projectile.position.Y;
                var num32 = 300f;
                var flag = false;
                var num33 = 0;
                if (projectile.ai[1] == 0f)
                {
                    for (var num34 = 0; num34 < 200; num34++)
                    {
                        if (Main.npc[num34].active && !Main.npc[num34].dontTakeDamage && !Main.npc[num34].friendly && Main.npc[num34].lifeMax > 5 && (projectile.ai[1] == 0f || projectile.ai[1] == num34 + 1))
                        {
                            var num35 = Main.npc[num34].position.X + Main.npc[num34].width / 2;
                            var num36 = Main.npc[num34].position.Y + Main.npc[num34].height / 2;
                            var num37 = Math.Abs(projectile.position.X + projectile.width / 2 - num35) + Math.Abs(projectile.position.Y + projectile.height / 2 - num36);
                            if (num37 < num32 && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[num34].position, Main.npc[num34].width, Main.npc[num34].height))
                            {
                                num32 = num37;
                                num30 = num35;
                                num31 = num36;
                                flag = true;
                                num33 = num34;
                            }
                        }
                    }
                    if (flag)
                    {
                        projectile.ai[1] = num33 + 1;
                    }
                    flag = false;
                }
                if (projectile.ai[1] != 0f)
                {
                    var num38 = (int)(projectile.ai[1] - 1f);
                    if (Main.npc[num38].active)
                    {
                        var num39 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                        var num40 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                        var num41 = Math.Abs(projectile.position.X + projectile.width / 2 - num39) + Math.Abs(projectile.position.Y + projectile.height / 2 - num40);
                        if (num41 < 1000f)
                        {
                            flag = true;
                            num30 = Main.npc[num38].position.X + Main.npc[num38].width / 2;
                            num31 = Main.npc[num38].position.Y + Main.npc[num38].height / 2;
                        }
                    }
                }
                if (flag)
                {
                    var num42 = num29;
                    var vector = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                    var num43 = num30 - vector.X;
                    var num44 = num31 - vector.Y;
                    var num45 = (float)Math.Sqrt(num43 * num43 + num44 * num44);
                    num45 = num42 / num45;
                    num43 *= num45;
                    num44 *= num45;
                    var num46 = 8;
                    projectile.velocity.X = (projectile.velocity.X * (num46 - 1) + num43) / num46;
                    projectile.velocity.Y = (projectile.velocity.Y * (num46 - 1) + num44) / num46;
                }
            }
            else if (projectile.type == ModContent.ProjectileType<MissileBolt>())
            {
                if (projectile.localAI[0] == 0f)
                {
                    projectile.localAI[1] = projectile.velocity.ToRotation();
                    projectile.localAI[0] = projectile.velocity.Length();
                }
                projectile.ai[1] += 1f;
                if (projectile.ai[1] < 45f)
                {
                    projectile.velocity.Y = projectile.velocity.Y + 0.02f;
                }
                if (projectile.ai[1] == 45f)
                {
                    var value = projectile.Center;
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.direction * -0.4f, -1.4f, 0, default(Color), 1f);
                    var num48 = 1.5f;
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Smoke, projectile.direction * -0.4f, -1.4f, 0, default(Color), num48);
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.direction * -0.4f, 1.4f, 0, default(Color), 1f);
                    num48 = 1.5f;
                    Dust.NewDust(value - projectile.velocity, projectile.width, projectile.height, DustID.Smoke, projectile.direction * -0.4f, 1.4f, 0, default(Color), num48);
                    projectile.velocity = projectile.localAI[1].ToRotationVector2() * projectile.localAI[0] * 2.1f;
                }
                else
                {
                    for (var num49 = 0; num49 < 5; num49++)
                    {
                        var num50 = projectile.velocity.X / 3f * num49;
                        var num51 = projectile.velocity.Y / 3f * num49;
                        var num52 = 4;
                        var num53 = Dust.NewDust(new Vector2(projectile.position.X + num52, projectile.position.Y + num52), projectile.width - num52 * 2, projectile.height - num52 * 2, DustID.Fire, 0f, 0f, 100, default(Color), 1.2f);
                        Main.dust[num53].noGravity = true;
                        Main.dust[num53].velocity *= 0.1f;
                        Main.dust[num53].velocity += projectile.velocity * 0.1f;
                        var dust5 = Main.dust[num53];
                        dust5.position.X = dust5.position.X - num50;
                        var dust6 = Main.dust[num53];
                        dust6.position.Y = dust6.position.Y - num51;
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                        var num54 = 4;
                        var num55 = Dust.NewDust(new Vector2(projectile.position.X + num54, projectile.position.Y + num54), projectile.width - num54 * 2, projectile.height - num54 * 2, DustID.Smoke, 0f, 0f, 100, default(Color), 0.6f);
                        Main.dust[num55].velocity *= 0.25f;
                        Main.dust[num55].velocity += projectile.velocity * 0.5f;
                    }
                }
            }
            else
            {
                if (projectile.ai[0] >= 15f)
                {
                    projectile.ai[0] = 15f;
                    projectile.velocity.Y = projectile.velocity.Y + 0.1f;
                }
            }
            if (projectile.type == ModContent.ProjectileType<Soundwave>())
            {
                projectile.scale = Math.Min(11f, 185.08197f * (float)Math.Pow(0.99111479520797729, projectile.timeLeft));
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
                var v = projectile.Center - new Vector2(projectile.width * projectile.scale / 2f, projectile.height * projectile.scale / 2f);
                var wH = new Vector2(projectile.width * projectile.scale, projectile.height * projectile.scale);
                var value2 = ExxoAvalonOrigins.NewRectVector2(v, wH);
                var npc = Main.npc;
                for (var num57 = 0; num57 < npc.Length; num57++)
                {
                    var nPC = npc[num57];
                    if (nPC.active && !nPC.dontTakeDamage && !nPC.friendly && nPC.life >= 1 && nPC.getRect().Intersects(value2))
                    {
                        nPC.StrikeNPC(projectile.damage, projectile.knockBack, (nPC.Center.X < projectile.Center.X) ? -1 : 1, false, false);
                    }
                }
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}