﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class QuadBall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Quad Ball");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/QuadBall");
            projectile.width = dims.Width * 32 / 34;
            projectile.height = dims.Height * 32 / 34 / Main.projFrames[projectile.type];
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 3600;
            projectile.aiStyle = -1;
            projectile.light = 1f;
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
            if (Main.player[projectile.owner].dead)
            {
                projectile.Kill();
                return;
            }
            Main.player[projectile.owner].itemAnimation = 10;
            Main.player[projectile.owner].itemTime = 10;
            if (projectile.position.X + projectile.width / 2 > Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2)
            {
                Main.player[projectile.owner].ChangeDir(1);
                projectile.direction = 1;
            }
            else
            {
                Main.player[projectile.owner].ChangeDir(-1);
                projectile.direction = -1;
            }
            var vector19 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
            var num253 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - vector19.X;
            var num254 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - vector19.Y;
            var num255 = (float)Math.Sqrt(num253 * num253 + num254 * num254);
            if (projectile.ai[0] == 0f)
            {
                var num256 = 160f;
                projectile.tileCollide = true;
                if (num255 > num256)
                {
                    projectile.ai[0] = 1f;
                    projectile.netUpdate = true;
                }
                else if (!Main.player[projectile.owner].channel)
                {
                    if (projectile.velocity.Y < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y * 0.9f;
                    }
                    projectile.velocity.Y = projectile.velocity.Y + 1f;
                    projectile.velocity.X = projectile.velocity.X * 0.9f;
                }
            }
            else if (projectile.ai[0] == 1f)
            {
                var num257 = 14f / Main.player[projectile.owner].meleeSpeed;
                var num258 = 0.9f / Main.player[projectile.owner].meleeSpeed;
                var num259 = 300f;
                Math.Abs(num253);
                Math.Abs(num254);
                if (projectile.ai[1] == 1f)
                {
                    projectile.tileCollide = false;
                }
                if (!Main.player[projectile.owner].channel || num255 > num259 || !projectile.tileCollide)
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
                }
                if (!projectile.tileCollide)
                {
                    num258 *= 2f;
                }
                var num260 = 60;
                if (num255 > num260 || !projectile.tileCollide)
                {
                    num255 = num257 / num255;
                    num253 *= num255;
                    num254 *= num255;
                    new Vector2(projectile.velocity.X, projectile.velocity.Y);
                    var num261 = num253 - projectile.velocity.X;
                    var num262 = num254 - projectile.velocity.Y;
                    var num263 = (float)Math.Sqrt(num261 * num261 + num262 * num262);
                    num263 = num258 / num263;
                    num261 *= num263;
                    num262 *= num263;
                    projectile.velocity.X = projectile.velocity.X * 0.98f;
                    projectile.velocity.Y = projectile.velocity.Y * 0.98f;
                    projectile.velocity.X = projectile.velocity.X + num261;
                    projectile.velocity.Y = projectile.velocity.Y + num262;
                }
                else
                {
                    if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 6f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.96f;
                        projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                    }
                    if (Main.player[projectile.owner].velocity.X == 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.96f;
                    }
                }
            }
            projectile.rotation = (float)Math.Atan2(num254, num253) - projectile.velocity.X * 0.1f;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var texture = ModContent.GetTexture("ExxoAvalonOrigins/Projectiles/QuadBall_Chain");

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
