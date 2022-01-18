using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class BerserkerSphere : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Sphere");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/BerserkerSphere");
            projectile.width = dims.Width * 22 / 34;
            projectile.height = dims.Height * 22 / 34 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.light = 0.4f;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 0.9f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            bool flag5 = false;
            if (oldVelocity.X != projectile.velocity.X)
            {
                if (Math.Abs(oldVelocity.X) > 4f)
                {
                    flag5 = true;
                }
                projectile.position.X = projectile.position.X + projectile.velocity.X;
                projectile.velocity.X = -oldVelocity.X * 0.2f;
            }
            if (oldVelocity.Y != projectile.velocity.Y)
            {
                if (Math.Abs(oldVelocity.Y) > 4f)
                {
                    flag5 = true;
                }
                projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
                projectile.velocity.Y = -oldVelocity.Y * 0.2f;
            }
            projectile.ai[0] = 1f;
            if (flag5)
            {
                projectile.netUpdate = true;
                Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y, 1);
            }
            return false;
        }

        public override void AI()
        {
            var vector64 = Main.player[projectile.owner].Center - projectile.Center;
            projectile.rotation = vector64.ToRotation() - 1.57f;
            if (Main.player[projectile.owner].dead)
            {
                projectile.Kill();
                return;
            }
            Main.player[projectile.owner].itemAnimation = 10;
            Main.player[projectile.owner].itemTime = 10;
            if (vector64.X < 0f)
            {
                Main.player[projectile.owner].ChangeDir(1);
                projectile.direction = 1;
            }
            else
            {
                Main.player[projectile.owner].ChangeDir(-1);
                projectile.direction = -1;
            }
            Main.player[projectile.owner].itemRotation = (vector64 * -1f * projectile.direction).ToRotation();
            projectile.spriteDirection = ((vector64.X > 0f) ? -1 : 1);
            if (projectile.ai[0] == 0f && vector64.Length() > 400f)
            {
                projectile.ai[0] = 1f;
            }
            if (projectile.ai[0] == 1f || projectile.ai[0] == 2f)
            {
                var num866 = vector64.Length();
                if (num866 > 1500f)
                {
                    projectile.Kill();
                    return;
                }
                if (num866 > 600f)
                {
                    projectile.ai[0] = 2f;
                }
                projectile.tileCollide = false;
                var num867 = 20f;
                if (projectile.ai[0] == 2f)
                {
                    num867 = 40f;
                }
                projectile.velocity = Vector2.Normalize(vector64) * num867;
                if (vector64.Length() < num867)
                {
                    projectile.Kill();
                    return;
                }
            }
            projectile.ai[1] += 1f;
            if (projectile.ai[1] > 5f)
            {
                projectile.alpha = 0;
            }
            if ((int)projectile.ai[1] % 3 == 0 && projectile.owner == Main.myPlayer)
            {
                var vector65 = vector64 * -1f;
                vector65.Normalize();
                vector65 *= Main.rand.Next(45, 65) * 0.1f;
                vector65 = vector65.RotatedBy((Main.rand.NextDouble() - 0.5) * 1.5707963705062866, default(Vector2));
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vector65.X, vector65.Y, ModContent.ProjectileType<Minisphere>(), projectile.damage, projectile.knockBack, projectile.owner, -10f, 0f);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var texture = ModContent.GetTexture("ExxoAvalonOrigins/Projectiles/BerserkerSphere_Chain");

            var position = projectile.Center;
            var mountedCenter = Main.player[projectile.owner].MountedCenter;
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
                    color2 = projectile.GetAlpha(color2);
                    Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }

            return true;
        }
    }
}