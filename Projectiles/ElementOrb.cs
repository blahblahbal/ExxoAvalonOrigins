using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ElementOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Element Orb");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.light = 0.8f;
            projectile.alpha = 100;
            projectile.penetrate = 2;
            projectile.magic = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int randomNum = Main.rand.Next(7);
            if (randomNum == 0) target.AddBuff(20, 300);
            else if (randomNum == 1) target.AddBuff(24, 200);
            else if (randomNum == 2) target.AddBuff(31, 120);
            else if (randomNum == 3) target.AddBuff(39, 300);
            else if (randomNum == 4) target.AddBuff(44, 300);
            else if (randomNum == 5) target.AddBuff(70, 240);
            else if (randomNum == 6) target.AddBuff(69, 300);
        }

        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<ElementOrb>())
            {
                var num162 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CursedTorch, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                Main.dust[num162].noGravity = true;
                Main.dust[num162].velocity *= 1.4f;
                num162 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CursedTorch, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                var num163 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Pixie, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                Main.dust[num163].noGravity = true;
                Main.dust[num163].velocity *= 1.4f;
                num163 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Pixie, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                var num164 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.GrassBlades, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 3.5f);
                Main.dust[num164].noGravity = true;
                Main.dust[num164].velocity *= 1.4f;
                num164 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.GrassBlades, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                var num165 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.DungeonWater_Old, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                Main.dust[num165].noGravity = true;
                Main.dust[num165].velocity *= 1.4f;
                num165 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.DungeonWater_Old, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
            }
            if (projectile.soundDelay == 0 && Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) > 2f)
            {
                projectile.soundDelay = 10;
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 9);
            }
            var num170 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num170].velocity *= 0.3f;
            Main.dust[num170].position.X = projectile.position.X + projectile.width / 2 + 4f + Main.rand.Next(-4, 5);
            Main.dust[num170].position.Y = projectile.position.Y + projectile.height / 2 + Main.rand.Next(-4, 5);
            Main.dust[num170].noGravity = true;
            if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f)
            {
                if (Main.player[projectile.owner].channel)
                {
                    var num171 = 12f;
                    var vector12 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                    var num172 = Main.mouseX + Main.screenPosition.X - vector12.X;
                    var num173 = Main.mouseY + Main.screenPosition.Y - vector12.Y;
                    if (Main.player[projectile.owner].gravDir == -1f)
                    {
                        num173 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector12.Y;
                    }
                    var num174 = (float)Math.Sqrt(num172 * num172 + num173 * num173);
                    num174 = (float)Math.Sqrt(num172 * num172 + num173 * num173);
                    if (num174 > num171)
                    {
                        num174 = num171 / num174;
                        num172 *= num174;
                        num173 *= num174;
                        var num175 = (int)(num172 * 1000f);
                        var num176 = (int)(projectile.velocity.X * 1000f);
                        var num177 = (int)(num173 * 1000f);
                        var num178 = (int)(projectile.velocity.Y * 1000f);
                        if (num175 != num176 || num177 != num178)
                        {
                            projectile.netUpdate = true;
                        }
                        projectile.velocity.X = num172;
                        projectile.velocity.Y = num173;
                    }
                    else
                    {
                        var num179 = (int)(num172 * 1000f);
                        var num180 = (int)(projectile.velocity.X * 1000f);
                        var num181 = (int)(num173 * 1000f);
                        var num182 = (int)(projectile.velocity.Y * 1000f);
                        if (num179 != num180 || num181 != num182)
                        {
                            projectile.netUpdate = true;
                        }
                        projectile.velocity.X = num172;
                        projectile.velocity.Y = num173;
                    }
                }
                else if (projectile.ai[0] == 0f)
                {
                    projectile.ai[0] = 1f;
                    projectile.netUpdate = true;
                    var num183 = 12f;
                    var vector13 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                    var num184 = Main.mouseX + Main.screenPosition.X - vector13.X;
                    var num185 = Main.mouseY + Main.screenPosition.Y - vector13.Y;
                    if (Main.player[projectile.owner].gravDir == -1f)
                    {
                        num185 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector13.Y;
                    }
                    var num186 = (float)Math.Sqrt(num184 * num184 + num185 * num185);
                    if (num186 == 0f)
                    {
                        vector13 = new Vector2(Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2, Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2);
                        num184 = projectile.position.X + projectile.width * 0.5f - vector13.X;
                        num185 = projectile.position.Y + projectile.height * 0.5f - vector13.Y;
                        num186 = (float)Math.Sqrt(num184 * num184 + num185 * num185);
                    }
                    num186 = num183 / num186;
                    num184 *= num186;
                    num185 *= num186;
                    projectile.velocity.X = num184;
                    projectile.velocity.Y = num185;
                    if (projectile.velocity.X == 0f && projectile.velocity.Y == 0f)
                    {
                        projectile.Kill();
                    }
                }
            }
            else if (projectile.velocity.X != 0f || projectile.velocity.Y != 0f)
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) - 2.355f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}