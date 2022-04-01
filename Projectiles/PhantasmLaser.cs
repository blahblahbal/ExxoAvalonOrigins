using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class PhantasmLaser : ModProjectile
    {
        private Color laserColor;
        private readonly Color[] colorArray = new Color[3];
        private int colorShift;
        private static Texture2D texture2D18;
        private static Texture2D texture2D19;
        private static Texture2D texture2D20;

        public static void Load()
        {
            texture2D18 = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/BeamVenoshock").Value;
            texture2D19 = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/BeamStart").Value;
            texture2D20 = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Sprites/BeamEnd").Value;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantasm Laser");
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = -1;
            Projectile.alpha = 255;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = false;
        }

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Projectile p = Projectile;

            float num204 = Projectile.localAI[1];

            colorArray[0] = new Color(88, 219, 255, 180) * 0.9f; // TODO: make the laser shift colors better
            colorArray[1] = new Color(59, 219, 234, 180) * 0.9f;
            colorArray[2] = new Color(30, 220, 214, 180) * 0.9f;

            colorShift++;
            if (colorShift > 60)
            {
                colorShift = 0;
            }

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

            spriteBatch.Draw(texture2D19, p.Center - Main.screenPosition, null, laserColor, Projectile.rotation, texture2D19.Size() / 2f, Projectile.scale, SpriteEffects.None, 0f);
            num204 -= (texture2D19.Height / 2 + texture2D20.Height) * Projectile.scale;
            Vector2 center2 = p.Center;
            center2 += Projectile.velocity * Projectile.scale * texture2D19.Height / 2f;
            if (num204 > 0f)
            {
                float num205 = 0f;
                var rectangle7 = new Rectangle(0, 16 * (Projectile.timeLeft / 3 % 5), texture2D19.Width, 16);
                while (num205 + 1f < num204)
                {
                    if (num204 - num205 < rectangle7.Height)
                    {
                        rectangle7.Height = (int)(num204 - num205);
                    }
                    spriteBatch.Draw(texture2D18, center2 - Main.screenPosition, rectangle7, laserColor, Projectile.rotation, new Vector2(rectangle7.Width / 2, 0f), Projectile.scale, SpriteEffects.None, 0f);
                    num205 += rectangle7.Height * Projectile.scale;
                    center2 += Projectile.velocity * rectangle7.Height * Projectile.scale;
                    rectangle7.Y += 16;
                    if (rectangle7.Y + rectangle7.Height > texture2D18.Height)
                    {
                        rectangle7.Y = 0;
                    }
                }
            }
            spriteBatch.Draw(texture2D20, center2 - Main.screenPosition, null, laserColor, Projectile.rotation, texture2D20.Frame().Top(), Projectile.scale, SpriteEffects.None, 0f);
        }

        public bool Colliding2(Rectangle myRect, Rectangle targetRect)
        {
            float collisionPoint6 = 0f;
            if (Collision.CheckAABBvLineCollision(targetRect.TopLeft(), targetRect.Size(), Projectile.Center, Projectile.Center + Projectile.velocity * Projectile.localAI[1], 36f * Projectile.scale, ref collisionPoint6))
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
                Main.player[Main.myPlayer].Hurt(PlayerDeathReason.ByProjectile(Main.myPlayer, Projectile.whoAmI), Projectile.damage, Projectile.direction);
            }
            return base.Colliding(projHitbox, targetHitbox);
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            var playerRect = new Rectangle((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height);
            if (Projectile.Colliding(hitbox, playerRect))
            {
                Main.player[Main.myPlayer].Hurt(PlayerDeathReason.ByProjectile(Main.myPlayer, Projectile.whoAmI), Projectile.damage, Projectile.direction);
            }
        }

        public override void AI()
        {
            Vector2 samplingPoint = Projectile.Center;
            var value35 = new Vector2(40f, 40f); // 27, 59
            Vector2 value36 = Utils.Vector2FromElipse(Main.npc[(int)Projectile.ai[1]].localAI[0].ToRotationVector2(), value35 * Main.npc[(int)Projectile.ai[1]].localAI[1]);
            Projectile.position = Main.npc[(int)Projectile.ai[1]].Center + value36 - new Vector2(Projectile.width, Projectile.height) / 2f;
            Projectile.localAI[0]++;
            if (Projectile.localAI[0] >= 240f)
            {
                Projectile.Kill();
                return;
            }

            float num828 = Projectile.velocity.ToRotation();
            num828 += Projectile.ai[0];
            Projectile.rotation = num828 - 1.57079637f;
            Projectile.velocity = num828.ToRotationVector2();
            float[] array5 = new float[3];
            Collision.LaserScan(samplingPoint, Projectile.velocity, Projectile.width * Projectile.scale, 2400f, array5);
            float num831 = 0f;
            int num4;
            for (int num832 = 0; num832 < array5.Length; num832 = num4 + 1)
            {
                num831 += array5[num832];
                num4 = num832;
            }
            num831 /= 3;
            Projectile.localAI[1] = MathHelper.Lerp(Projectile.localAI[1], num831, 0.5f);
            Vector2 vector58 = Projectile.Center + Projectile.velocity * (Projectile.localAI[1] - 14f);
            for (int num833 = 0; num833 < 2; num833 = num4 + 1)
            {
                float num834 = Projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * 1.57079637f;
                float num835 = (float)Main.rand.NextDouble() * 2f + 2f;
                var vector59 = new Vector2((float)Math.Cos(num834) * num835, (float)Math.Sin(num834) * num835);
                int num836 = Dust.NewDust(vector58, 0, 0, DustID.DungeonSpirit, vector59.X, vector59.Y, Scale: 0.7f);
                Main.dust[num836].noGravity = true;
                Main.dust[num836].scale = 1.7f;
                num4 = num833;
            }
            if (Main.rand.Next(5) == 0)
            {
                Vector2 value42 = Projectile.velocity.RotatedBy(1.5707963705062866) * ((float)Main.rand.NextDouble() - 0.5f) * Projectile.width;
                int num837 = Dust.NewDust(vector58 + value42 - Vector2.One * 4f, 8, 8, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                Dust dust = Main.dust[num837];
                dust.velocity *= 0.5f;
                Main.dust[num837].velocity.Y = 0f - Math.Abs(Main.dust[num837].velocity.Y);
            }
        }
    }
}
