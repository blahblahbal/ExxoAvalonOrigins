using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class OblivionLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Laser");
        }

        public override void SetDefaults()
        {
            projectile.width = 36;
            projectile.height = 36;
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.alpha = 255;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
        }

        public const uint LifeTime = 100;
        public override string Texture => "Terraria/Projectile_" + ProjectileID.PhantasmalDeathray;

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.velocity == Vector2.Zero)
            {
                return false;
            }
            Texture2D texture2D10 = Main.projectileTexture[projectile.type];
            Texture2D texture2D11 = Main.extraTexture[21];
            Texture2D texture2D13 = Main.extraTexture[22];
            float num120 = projectile.localAI[1];
            Microsoft.Xna.Framework.Color color35 = new Microsoft.Xna.Framework.Color(255, 255, 255, 0) * 0.9f;
            Main.spriteBatch.Draw(texture2D10, projectile.Center - Main.screenPosition, null, color35, projectile.rotation, texture2D10.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);
            num120 -= (texture2D10.Height / 2 + texture2D13.Height) * projectile.scale;
            Vector2 center3 = projectile.Center;
            center3 += projectile.velocity * projectile.scale * texture2D10.Height / 2f;
            if (num120 > 0f)
            {
                float num121 = 0f;
                Microsoft.Xna.Framework.Rectangle value14 = new Microsoft.Xna.Framework.Rectangle(0, 16 * (projectile.timeLeft / 3 % 5), texture2D11.Width, 16);
                while (num121 + 1f < num120)
                {
                    if (num120 - num121 < value14.Height)
                    {
                        value14.Height = (int)(num120 - num121);
                    }
                    Main.spriteBatch.Draw(texture2D11, center3 - Main.screenPosition, value14, color35, projectile.rotation, new Vector2(value14.Width / 2, 0f), projectile.scale, SpriteEffects.None, 0f);
                    num121 += value14.Height * projectile.scale;
                    center3 += projectile.velocity * value14.Height * projectile.scale;
                    value14.Y += 16;
                    if (value14.Y + value14.Height > texture2D11.Height)
                    {
                        value14.Y = 0;
                    }
                }
            }
            Main.spriteBatch.Draw(texture2D13, center3 - Main.screenPosition, null, color35, projectile.rotation, texture2D13.Frame().Top(), projectile.scale, SpriteEffects.None, 0f);

            return false;
        }

        public override void AI()
        {
            Vector2? vector76 = null;
            if (projectile.velocity.HasNaNs() || projectile.velocity == Vector2.Zero)
            {
                projectile.velocity = -Vector2.UnitY;
            }

            Vector2 elipseSizes = new Vector2(27f, 59f) * Main.npc[(int)projectile.ai[1]].localAI[1];
            Vector2 value20 = Utils.Vector2FromElipse(Main.npc[(int)projectile.ai[1]].localAI[0].ToRotationVector2(), elipseSizes);
            projectile.position = Main.npc[(int)projectile.ai[1]].Center + value20 - new Vector2(projectile.width, projectile.height) / 2f;

            if (projectile.localAI[0] == 0f)
            {
                Main.PlaySound(SoundID.Zombie, (int)projectile.position.X, (int)projectile.position.Y, 104);
            }
            float num990 = 1f;
            projectile.localAI[0]++;

            if (projectile.localAI[0] >= LifeTime)
            {
                projectile.Kill();
                return;
            }

            projectile.scale = (float)Math.Sin(projectile.localAI[0] * (float)Math.PI / 180f) * 10f * num990;
            if (projectile.scale > num990)
            {
                projectile.scale = num990;
            }

            float num994 = projectile.velocity.ToRotation();
            num994 += projectile.ai[0];

            projectile.rotation = num994 - (float)Math.PI / 2f;
            projectile.velocity = num994.ToRotationVector2();
            float num995 = 0f;
            float num996 = 0f;
            Vector2 samplingPoint = projectile.Center;

            if (vector76.HasValue)
            {
                samplingPoint = vector76.Value;
            }
            num995 = 3f;
            num996 = projectile.width;

            float[] array3 = new float[(int)num995];
            Collision.LaserScan(samplingPoint, projectile.velocity, num996 * projectile.scale, 2400f, array3);
            float num997 = 0f;
            for (int num998 = 0; num998 < array3.Length; num998++)
            {
                num997 += array3[num998];
            }
            num997 /= num995;
            float amount = 0.5f;
            projectile.localAI[1] = MathHelper.Lerp(projectile.localAI[1], num997, amount);

            Vector2 vector77 = projectile.Center + projectile.velocity * (projectile.localAI[1] - 14f);
            for (int num999 = 0; num999 < 2; num999++)
            {
                float num1000 = projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * ((float)Math.PI / 2f);
                float num1001 = (float)Main.rand.NextDouble() * 2f + 2f;
                Vector2 vector78 = new Vector2((float)Math.Cos(num1000) * num1001, (float)Math.Sin(num1000) * num1001);
                int num1002 = Dust.NewDust(vector77, 0, 0, DustID.Vortex, vector78.X, vector78.Y);
                Main.dust[num1002].noGravity = true;
                Main.dust[num1002].scale = 1.7f;
            }
            if (Main.rand.Next(5) == 0)
            {
                Vector2 value26 = projectile.velocity.RotatedBy(1.5707963705062866) * ((float)Main.rand.NextDouble() - 0.5f) * projectile.width;
                int num1003 = Dust.NewDust(vector77 + value26 - Vector2.One * 4f, 8, 8, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                Dust dust74 = Main.dust[num1003];
                Dust dust189 = dust74;
                dust189.velocity *= 0.5f;
                Main.dust[num1003].velocity.Y = 0f - Math.Abs(Main.dust[num1003].velocity.Y);
            }
            DelegateMethods.v3_1 = new Vector3(0.3f, 0.65f, 0.7f);
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], projectile.width * projectile.scale, DelegateMethods.CastLight);
        }
    }
}
