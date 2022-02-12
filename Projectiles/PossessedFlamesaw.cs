using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PossessedFlamesaw : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Possessed Flamesaw");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/PossessedFlamesaw");
            projectile.light = 0.9f;
            projectile.width = dims.Width * 30 / 62;
            projectile.height = dims.Height * 30 / 62 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = 10;
            projectile.melee = true;
            projectile.MaxUpdates = 1;
        }

        public override void AI()
        {
            if (projectile.soundDelay == 0)
            {
                projectile.soundDelay = 8;
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 7);
            }
            if (projectile.ai[0] == 0f)
            {
                projectile.ai[1] += 1f;
                if (projectile.type == ModContent.ProjectileType<PossessedFlamesaw>())
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        var num88 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Enchanted_Gold, 0f, 0f, 255, default(Color), 0.75f);
                        Main.dust[num88].velocity *= 0.1f;
                        Main.dust[num88].noGravity = true;
                    }
                    if (projectile.velocity.X > 0f)
                    {
                        projectile.spriteDirection = 1;
                    }
                    else if (projectile.velocity.X < 0f)
                    {
                        projectile.spriteDirection = -1;
                    }
                    var num89 = projectile.position.X;
                    var num90 = projectile.position.Y;
                    var flag2 = false;
                    if (projectile.ai[1] > 10f)
                    {
                        for (var num91 = 0; num91 < 200; num91++)
                        {
                            if (Main.npc[num91].active && !Main.npc[num91].dontTakeDamage && !Main.npc[num91].friendly && Main.npc[num91].lifeMax > 5)
                            {
                                var num92 = Main.npc[num91].position.X + Main.npc[num91].width / 2;
                                var num93 = Main.npc[num91].position.Y + Main.npc[num91].height / 2;
                                var num94 = Math.Abs(projectile.position.X + projectile.width / 2 - num92) + Math.Abs(projectile.position.Y + projectile.height / 2 - num93);
                                if (num94 < 800f && Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2, projectile.position.Y + projectile.height / 2), 1, 1, Main.npc[num91].position, Main.npc[num91].width, Main.npc[num91].height))
                                {
                                    num89 = num92;
                                    num90 = num93;
                                    flag2 = true;
                                }
                            }
                        }
                    }
                    if (!flag2)
                    {
                        num89 = projectile.position.X + projectile.width / 2 + projectile.velocity.X * 100f;
                        num90 = projectile.position.Y + projectile.height / 2 + projectile.velocity.Y * 100f;
                        if (projectile.ai[1] >= 30f)
                        {
                            projectile.ai[0] = 1f;
                            projectile.ai[1] = 0f;
                            projectile.netUpdate = true;
                        }
                    }
                    var num95 = 12f;
                    var num96 = 0.25f;
                    var vector3 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                    var num97 = num89 - vector3.X;
                    var num98 = num90 - vector3.Y;
                    var num99 = (float)Math.Sqrt(num97 * num97 + num98 * num98);
                    num99 = num95 / num99;
                    num97 *= num99;
                    num98 *= num99;
                    if (projectile.velocity.X < num97)
                    {
                        projectile.velocity.X = projectile.velocity.X + num96;
                        if (projectile.velocity.X < 0f && num97 > 0f)
                        {
                            projectile.velocity.X = projectile.velocity.X + num96 * 2f;
                        }
                    }
                    else if (projectile.velocity.X > num97)
                    {
                        projectile.velocity.X = projectile.velocity.X - num96;
                        if (projectile.velocity.X > 0f && num97 < 0f)
                        {
                            projectile.velocity.X = projectile.velocity.X - num96 * 2f;
                        }
                    }
                    if (projectile.velocity.Y < num98)
                    {
                        projectile.velocity.Y = projectile.velocity.Y + num96;
                        if (projectile.velocity.Y < 0f && num98 > 0f)
                        {
                            projectile.velocity.Y = projectile.velocity.Y + num96 * 2f;
                        }
                    }
                    else if (projectile.velocity.Y > num98)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num96;
                        if (projectile.velocity.Y > 0f && num98 < 0f)
                        {
                            projectile.velocity.Y = projectile.velocity.Y - num96 * 2f;
                        }
                    }
                    if (projectile.type == ModContent.ProjectileType<PossessedFlamesaw>() && Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].active() && Main.tile[(int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f)].type == 5)
                    {
                        WorldGen.KillTile((int)(projectile.position.X / 16f), (int)(projectile.position.Y / 16f), false, false, false);
                    }
                }
                else if (projectile.ai[1] >= 30f)
                {
                    projectile.ai[0] = 1f;
                    projectile.ai[1] = 0f;
                    projectile.netUpdate = true;
                }
            }
            else
            {
                projectile.tileCollide = false;
                var num100 = 9f;
                var num101 = 0.4f;
                if (projectile.type == ModContent.ProjectileType<PossessedFlamesaw>())
                {
                    num100 = 16f;
                    num101 = 1.2f;
                }
                else if (projectile.type == ModContent.ProjectileType<Shurikerang>())
                {
                    num100 = 15f;
                    num101 = 0.8f;
                }
                var vector4 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                var num102 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - vector4.X;
                var num103 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - vector4.Y;
                var num104 = (float)Math.Sqrt(num102 * num102 + num103 * num103);
                if (num104 > 3000f)
                {
                    projectile.Kill();
                }
                num104 = num100 / num104;
                num102 *= num104;
                num103 *= num104;
                if (projectile.velocity.X < num102)
                {
                    projectile.velocity.X = projectile.velocity.X + num101;
                    if (projectile.velocity.X < 0f && num102 > 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X + num101;
                    }
                }
                else if (projectile.velocity.X > num102)
                {
                    projectile.velocity.X = projectile.velocity.X - num101;
                    if (projectile.velocity.X > 0f && num102 < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X - num101;
                    }
                }
                if (projectile.velocity.Y < num103)
                {
                    projectile.velocity.Y = projectile.velocity.Y + num101;
                    if (projectile.velocity.Y < 0f && num103 > 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y + num101;
                    }
                }
                else if (projectile.velocity.Y > num103)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num101;
                    if (projectile.velocity.Y > 0f && num103 < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num101;
                    }
                }
                if (Main.myPlayer == projectile.owner)
                {
                    var rectangle = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                    var value4 = new Rectangle((int)Main.player[projectile.owner].position.X, (int)Main.player[projectile.owner].position.Y, Main.player[projectile.owner].width, Main.player[projectile.owner].height);
                    if (rectangle.Intersects(value4))
                    {
                        projectile.Kill();
                    }
                }
            }
            projectile.rotation += 0.4f * projectile.direction;
        }
    }
}