using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Projectiles{
    public class PhantasmLaser : ModProjectile
    {
        Color laserColor;
        Color[] colorArray = new Color[3];
        int colorShift;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantasm Laser");
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = -1;
            projectile.alpha = 255;
            projectile.magic = true;
            projectile.penetrate = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.timeLeft = 3600;
            projectile.tileCollide = false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Projectile p = projectile;
            Texture2D texture2D18 = ExxoAvalonOrigins.BeamEndTexture;
            Texture2D texture2D19 = ExxoAvalonOrigins.BeamVTexture;
            Texture2D texture2D20 = ExxoAvalonOrigins.BeamStartTexture;
            float num204 = projectile.localAI[1];

            colorArray[0] = new Color(88, 219, 255, 180) * 0.9f; // TODO: make the laser shift colors better
            colorArray[1] = new Color(59, 219, 234, 180) * 0.9f;
            colorArray[2] = new Color(30, 220, 214, 180) * 0.9f;

            colorShift++;
            if (colorShift > 60)
                colorShift = 0;

            if (colorShift <= 15)
            {
                laserColor = colorArray[0];
            }
            else if (colorShift > 15 && colorShift <= 30 || colorShift > 45 && colorShift <= 61)
            {
                laserColor = colorArray[1];
            }
            else if (colorShift > 30 && colorShift <= 45)
            {
                laserColor = colorArray[2];
            }

            spriteBatch.Draw(texture2D18, p.Center - Main.screenPosition, null, laserColor, projectile.rotation, texture2D18.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);
            num204 -= (float)(texture2D18.Height / 2 + texture2D20.Height) * projectile.scale;
            Vector2 center2 = p.Center;
            center2 += projectile.velocity * projectile.scale * (float)texture2D18.Height / 2f;
            if (num204 > 0f)
            {
                float num205 = 0f;
                Rectangle rectangle7 = new Rectangle(0, 16 * (projectile.timeLeft / 3 % 5), texture2D19.Width, 16);
                while (num205 + 1f < num204)
                {
                    if (num204 - num205 < (float)rectangle7.Height)
                    {
                        rectangle7.Height = (int)(num204 - num205);
                    }
                    spriteBatch.Draw(texture2D19, center2 - Main.screenPosition, rectangle7, laserColor, projectile.rotation, new Vector2((float)(rectangle7.Width / 2), 0f), projectile.scale, SpriteEffects.None, 0f);
                    num205 += (float)rectangle7.Height * projectile.scale;
                    center2 += projectile.velocity * (float)rectangle7.Height * projectile.scale;
                    rectangle7.Y += 16;
                    if (rectangle7.Y + rectangle7.Height > texture2D19.Height)
                    {
                        rectangle7.Y = 0;
                    }
                }
            }
            spriteBatch.Draw(texture2D20, center2 - Main.screenPosition, null, laserColor, projectile.rotation, texture2D20.Frame().Top(), projectile.scale, SpriteEffects.None, 0f);
        }
        public bool Colliding2(Rectangle myRect, Rectangle targetRect)
        {
            float collisionPoint6 = 0f;
            if (Collision.CheckAABBvLineCollision(targetRect.TopLeft(), targetRect.Size(), projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], 36f * projectile.scale, ref collisionPoint6))
            {
                return true;
            }
            return false;
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            //Rectangle playerRect = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height);
            if (Colliding2(projHitbox, targetHitbox))
            {
                Main.player[Main.myPlayer].Hurt(PlayerDeathReason.ByProjectile(Main.myPlayer, projectile.whoAmI), projectile.damage, projectile.direction);
            }
            return base.Colliding(projHitbox, targetHitbox);
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            Rectangle playerRect = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height);
            if (projectile.Colliding(hitbox, playerRect))
            {
                Main.player[Main.myPlayer].Hurt(PlayerDeathReason.ByProjectile(Main.myPlayer, projectile.whoAmI), projectile.damage, projectile.direction);
            }
        }
        public override void AI()
        {
            Vector2 samplingPoint = projectile.Center;
            Vector2 value35 = new Vector2(40f, 40f); // 27, 59
            Vector2 value36 = Utils.Vector2FromElipse(Main.npc[(int)projectile.ai[1]].localAI[0].ToRotationVector2(), value35 * Main.npc[(int)projectile.ai[1]].localAI[1]);
            projectile.position = Main.npc[(int)projectile.ai[1]].Center + value36 - new Vector2(projectile.width, projectile.height) / 2f;
            projectile.localAI[0]++;
            if (projectile.localAI[0] >= 240f)
            {
                projectile.Kill();
                return;
            }

            float num828 = projectile.velocity.ToRotation();
            num828 += projectile.ai[0];
            projectile.rotation = num828 - 1.57079637f;
            projectile.velocity = num828.ToRotationVector2();
            float[] array5 = new float[3];
            Collision.LaserScan(samplingPoint, projectile.velocity, projectile.width * projectile.scale, 2400f, array5);
            float num831 = 0f;
            int num4;
            for (int num832 = 0; num832 < array5.Length; num832 = num4 + 1)
            {
                num831 += array5[num832];
                num4 = num832;
            }
            num831 /= 3;
            projectile.localAI[1] = MathHelper.Lerp(projectile.localAI[1], num831, 0.5f);
            Vector2 vector58 = projectile.Center + projectile.velocity * (projectile.localAI[1] - 14f);
            for (int num833 = 0; num833 < 2; num833 = num4 + 1)
            {
                float num834 = projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * 1.57079637f;
                float num835 = (float)Main.rand.NextDouble() * 2f + 2f;
                Vector2 vector59 = new Vector2((float)Math.Cos((double)num834) * num835, (float)Math.Sin((double)num834) * num835);
                int num836 = Dust.NewDust(vector58, 0, 0, DustID.DungeonSpirit, vector59.X, vector59.Y, Scale: 0.7f);
                Main.dust[num836].noGravity = true;
                Main.dust[num836].scale = 1.7f;
                num4 = num833;
            }
            if (Main.rand.Next(5) == 0)
            {
                Vector2 value42 = projectile.velocity.RotatedBy(1.5707963705062866) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width;
                int num837 = Dust.NewDust(vector58 + value42 - Vector2.One * 4f, 8, 8, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                Dust dust = Main.dust[num837];
                dust.velocity *= 0.5f;
                Main.dust[num837].velocity.Y = 0f - Math.Abs(Main.dust[num837].velocity.Y);
            }
        }
    }}