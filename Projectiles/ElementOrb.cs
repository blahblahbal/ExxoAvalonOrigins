using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

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
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.8f;
            Projectile.alpha = 100;
            Projectile.penetrate = 2;
            Projectile.DamageType = DamageClass.Magic;
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
            if (Projectile.type == ModContent.ProjectileType<ElementOrb>())
            {
                var num162 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                Main.dust[num162].noGravity = true;
                Main.dust[num162].velocity *= 1.4f;
                num162 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                var num163 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Pixie, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                Main.dust[num163].noGravity = true;
                Main.dust[num163].velocity *= 1.4f;
                num163 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Pixie, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                var num164 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GrassBlades, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 3.5f);
                Main.dust[num164].noGravity = true;
                Main.dust[num164].velocity *= 1.4f;
                num164 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.GrassBlades, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                var num165 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.DungeonWater_Old, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
                Main.dust[num165].noGravity = true;
                Main.dust[num165].velocity *= 1.4f;
                num165 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.DungeonWater_Old, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.5f);
            }
            if (Projectile.soundDelay == 0 && Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) > 2f)
            {
                Projectile.soundDelay = 10;
                SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 9);
            }
            var num170 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num170].velocity *= 0.3f;
            Main.dust[num170].position.X = Projectile.position.X + Projectile.width / 2 + 4f + Main.rand.Next(-4, 5);
            Main.dust[num170].position.Y = Projectile.position.Y + Projectile.height / 2 + Main.rand.Next(-4, 5);
            Main.dust[num170].noGravity = true;
            if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
            {
                if (Main.player[Projectile.owner].channel)
                {
                    var num171 = 12f;
                    var vector12 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                    var num172 = Main.mouseX + Main.screenPosition.X - vector12.X;
                    var num173 = Main.mouseY + Main.screenPosition.Y - vector12.Y;
                    if (Main.player[Projectile.owner].gravDir == -1f)
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
                        var num176 = (int)(Projectile.velocity.X * 1000f);
                        var num177 = (int)(num173 * 1000f);
                        var num178 = (int)(Projectile.velocity.Y * 1000f);
                        if (num175 != num176 || num177 != num178)
                        {
                            Projectile.netUpdate = true;
                        }
                        Projectile.velocity.X = num172;
                        Projectile.velocity.Y = num173;
                    }
                    else
                    {
                        var num179 = (int)(num172 * 1000f);
                        var num180 = (int)(Projectile.velocity.X * 1000f);
                        var num181 = (int)(num173 * 1000f);
                        var num182 = (int)(Projectile.velocity.Y * 1000f);
                        if (num179 != num180 || num181 != num182)
                        {
                            Projectile.netUpdate = true;
                        }
                        Projectile.velocity.X = num172;
                        Projectile.velocity.Y = num173;
                    }
                }
                else if (Projectile.ai[0] == 0f)
                {
                    Projectile.ai[0] = 1f;
                    Projectile.netUpdate = true;
                    var num183 = 12f;
                    var vector13 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                    var num184 = Main.mouseX + Main.screenPosition.X - vector13.X;
                    var num185 = Main.mouseY + Main.screenPosition.Y - vector13.Y;
                    if (Main.player[Projectile.owner].gravDir == -1f)
                    {
                        num185 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector13.Y;
                    }
                    var num186 = (float)Math.Sqrt(num184 * num184 + num185 * num185);
                    if (num186 == 0f)
                    {
                        vector13 = new Vector2(Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2, Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2);
                        num184 = Projectile.position.X + Projectile.width * 0.5f - vector13.X;
                        num185 = Projectile.position.Y + Projectile.height * 0.5f - vector13.Y;
                        num186 = (float)Math.Sqrt(num184 * num184 + num185 * num185);
                    }
                    num186 = num183 / num186;
                    num184 *= num186;
                    num185 *= num186;
                    Projectile.velocity.X = num184;
                    Projectile.velocity.Y = num185;
                    if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
                    {
                        Projectile.Kill();
                    }
                }
            }
            else if (Projectile.velocity.X != 0f || Projectile.velocity.Y != 0f)
            {
                Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) - 2.355f;
            }
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }
    }
}