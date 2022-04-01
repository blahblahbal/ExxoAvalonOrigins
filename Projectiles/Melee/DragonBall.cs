using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class DragonBall : ModProjectile
    {
        int meteorCooldown;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon's Ball and Chain");
            Main.projFrames[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/DragonBall");
            Projectile.width = dims.Width * 22 / 24;
            Projectile.height = dims.Height * 22 / 24 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1.1f;

            meteorCooldown = 0;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bool flag5 = false;
            if (oldVelocity.X != Projectile.velocity.X)
            {
                if (Math.Abs(oldVelocity.X) > 4f)
                {
                    flag5 = true;
                }
                Projectile.position.X = Projectile.position.X + Projectile.velocity.X;
                Projectile.velocity.X = -oldVelocity.X * 0.2f;
            }
            if (oldVelocity.Y != Projectile.velocity.Y)
            {
                if (Math.Abs(oldVelocity.Y) > 4f)
                {
                    flag5 = true;
                }
                Projectile.position.Y = Projectile.position.Y + Projectile.velocity.Y;
                Projectile.velocity.Y = -oldVelocity.Y * 0.2f;
            }
            //projectile.ai[0] = 1f;
            if (flag5)
            {
                Projectile.netUpdate = true;
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.Dig, (int)Projectile.position.X, (int)Projectile.position.Y, 1);
            }
            return false;
        }

        public override void AI()
        {
            if (Projectile.localAI[0] <= 0 && Projectile.localAI[0] > 3 || Main.player[Projectile.owner].dead)
            {
                Projectile.Kill();
                return;
            }

            if (meteorCooldown < 0)
                meteorCooldown = 0;
            else
                meteorCooldown--;

            Projectile.frame = (int)Projectile.localAI[0];
            if (Projectile.position.X + Projectile.width / 2 > Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2)
            {
                Projectile.direction = 1;
            }
            else
            {
                Projectile.direction = -1;
            }
            if (Vector2.Distance(Main.player[Projectile.owner].Center, Projectile.Center) > 800)
                Projectile.tileCollide = false;
            var vector19 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
            var num253 = Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 - vector19.X;
            var num254 = Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - vector19.Y;
            var num255 = (float)Math.Sqrt(num253 * num253 + num254 * num254);
            if (Projectile.ai[0] == 0f)
            {
                var num256 = 160f;
                Projectile.tileCollide = true;
                if (num255 > num256)
                {
                    Projectile.ai[0] = 1f;
                    Projectile.netUpdate = true;
                }
                /*else if (!Main.player[projectile.owner].channel)
                {
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.9f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y + 1f;
                    projectile.velocity.X = projectile.velocity.X * 0.9f;
                }*/
            }
            else if (Projectile.ai[0] == 1f)
            {
                var num257 = (11f + (Projectile.localAI[0] / 3)) / Main.player[Projectile.owner].meleeSpeed;
                var num258 = (0.9f + (Projectile.localAI[0] / 15)) / Main.player[Projectile.owner].meleeSpeed;
                Math.Abs(num253);
                Math.Abs(num254);
                if (Projectile.ai[1] == 1f)
                {
                    Projectile.tileCollide = false;
                }
                /*if (!Main.player[projectile.owner].channel || num255 > num259 || !projectile.tileCollide)
                {
                    projectile.ai[1] = 1f;
                    if (projectile.tileCollide)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.tileCollide = false;
                    if (num255 < 20f)
                    {
                        projectile.Kill();
                    }
                }*/
                if (!Projectile.tileCollide)
                {
                    num258 *= 2f;
                }
                var num260 = 60;
                if (num255 > num260 || !Projectile.tileCollide)
                {
                    num255 = num257 / num255;
                    num253 *= num255;
                    num254 *= num255;
                    new Vector2(Projectile.velocity.X, Projectile.velocity.Y);
                    var num261 = num253 - Projectile.velocity.X;
                    var num262 = num254 - Projectile.velocity.Y;
                    var num263 = (float)Math.Sqrt(num261 * num261 + num262 * num262);
                    num263 = num258 / num263;
                    num261 *= num263;
                    num262 *= num263;
                    Projectile.velocity.X = Projectile.velocity.X * 0.98f;
                    Projectile.velocity.Y = Projectile.velocity.Y * 0.98f;
                    Projectile.velocity.X = Projectile.velocity.X + num261;
                    Projectile.velocity.Y = Projectile.velocity.Y + num262;
                }
                else
                {
                    if (Math.Abs(Projectile.velocity.X) + Math.Abs(Projectile.velocity.Y) < 6f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X * 0.96f;
                        Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
                    }
                    if (Main.player[Projectile.owner].velocity.X == 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X * 0.96f;
                    }
                }
            }
            Projectile.rotation = (float)Math.Atan2(num254, num253) - Projectile.velocity.X * 0.1f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (meteorCooldown <= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int rand = Main.rand.Next(3);
                    Vector2 origin = new Vector2(Projectile.Center.X, Main.player[Projectile.owner].Center.Y) + new Vector2(Main.rand.NextFloat(-250f, 251f), -600f);
                    Vector2 rotation = target.Center - origin;
                    if (rotation.Y < 0f)
                        rotation.Y *= -1f;
                    if (rotation.Y < 6f)
                        rotation.Y = 6f;
                    rotation.Normalize();
                    rotation *= new Vector2(6f, 6f).Length();
                    Vector2 velocity = new Vector2(rotation.X, rotation.Y + Main.rand.Next(-40, 41) * 0.02f);
                    int meteor = Projectile.NewProjectile(origin, velocity, ProjectileID.Meteor1 + rand, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0.5f + (float)Main.rand.NextDouble() * 0.3f);
                }
                meteorCooldown = 120;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var texture = ModContent.Request<Texture2D>("ExxoAvalonOrigins/Projectiles/Cell_Chain");

            var position = Projectile.Center;
            var mountedCenter = Main.player[Projectile.owner].MountedCenter;
            var sourceRectangle = new Rectangle?();
            var origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            float num1 = texture.Height;
            var vector2_4 = mountedCenter - position;
            var rotation = (float)Math.Atan2(vector2_4.Y, vector2_4.X) - 1.57f;
            var flag = true;
            if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                flag = false;
            if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
                flag = false;
            while (flag)
            {
                if (vector2_4.Length() < num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    var vector2_1 = vector2_4;
                    vector2_1.Normalize();
                    position += vector2_1 * num1;
                    vector2_4 = mountedCenter - position;
                    var color2 = Lighting.GetColor((int)position.X / 16, (int)(position.Y / 16.0));
                    color2 = Projectile.GetAlpha(color2);
                    Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }

            return true;
        }
    }
}
