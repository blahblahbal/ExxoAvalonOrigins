using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class TerraTyphoon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Typhoon");
            Main.projFrames[projectile.type] = 3;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }
        public override void SetDefaults()
        {
            projectile.width = 63;
            projectile.height = 63;
            projectile.alpha = 255;
            projectile.friendly = true;
            projectile.timeLeft = 540;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.MaxUpdates = 2;
            projectile.scale = 1f;
            projectile.magic = true;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 200);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            return false;
        }
        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            height = 30;
            width = 30;
            return true;
        }
        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 3)
            {
                projectile.frame = (projectile.frame + 1) % Main.projFrames[projectile.type];
                projectile.frameCounter = 0;
            }
            projectile.localAI[1]++;
            if (projectile.localAI[1] > 10f && Main.rand.Next(3) == 0)
            {
                int num586 = 6;
                for (int num587 = 0; num587 < num586; num587++)
                {
                    Vector2 spinningpoint4 = Vector2.Normalize(projectile.velocity) * new Vector2(projectile.width, projectile.height) / 2f;
                    spinningpoint4 = spinningpoint4.RotatedBy((double)(num587 - (num586 / 2 - 1)) * Math.PI / (double)num586) + projectile.Center;
                    Vector2 vector54 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                    int num588 = Dust.NewDust(spinningpoint4 + vector54, 0, 0, DustID.TerraBlade, vector54.X * 2f, vector54.Y * 2f, 100, default(Color), 1.4f);
                    Main.dust[num588].noGravity = true;
                    Main.dust[num588].noLight = true;
                    Dust dust = Main.dust[num588];
                    dust.velocity *= 0.05f;
                    dust = Main.dust[num588];
                    dust.velocity -= projectile.velocity;
                }
                projectile.alpha -= 5;
                if (projectile.alpha < 50)
                {
                    projectile.alpha = 50;
                }
                projectile.rotation += projectile.velocity.X * 0.1f;
                projectile.frame = (int)(projectile.localAI[1] / 3f) % 3;
                Lighting.AddLight((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16, 0.1f, 0.4f, 0.6f);
            }
            int num589 = -1;
            Vector2 vector55 = projectile.Center;
            float num590 = 500f;
            if (projectile.localAI[0] > 0f)
            {
                projectile.localAI[0]--;
            }
            if (projectile.ai[0] == 0f && projectile.localAI[0] == 0f)
            {
                for (int num591 = 0; num591 < 200; num591++)
                {
                    NPC nPC4 = Main.npc[num591];
                    if (nPC4.CanBeChasedBy(this) && (projectile.ai[0] == 0f || projectile.ai[0] == (float)(num591 + 1)))
                    {
                        Vector2 center6 = nPC4.Center;
                        float num592 = Vector2.Distance(center6, vector55);
                        if (num592 < num590 && Collision.CanHit(projectile.position, projectile.width, projectile.height, nPC4.position, nPC4.width, nPC4.height))
                        {
                            num590 = num592;
                            vector55 = center6;
                            num589 = num591;
                        }
                    }
                }
                if (num589 >= 0)
                {
                    projectile.ai[0] = num589 + 1;
                    projectile.netUpdate = true;
                }
                num589 = -1;
            }
            if (projectile.localAI[0] == 0f && projectile.ai[0] == 0f)
            {
                projectile.localAI[0] = 30f;
            }
            bool flag28 = false;
            if (projectile.ai[0] != 0f)
            {
                int num593 = (int)(projectile.ai[0] - 1f);
                if (Main.npc[num593].active && !Main.npc[num593].dontTakeDamage && Main.npc[num593].immune[projectile.owner] == 0)
                {
                    float num594 = Main.npc[num593].position.X + (float)(Main.npc[num593].width / 2);
                    float num595 = Main.npc[num593].position.Y + (float)(Main.npc[num593].height / 2);
                    float num596 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num594) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num595);
                    if (num596 < 1000f)
                    {
                        flag28 = true;
                        vector55 = Main.npc[num593].Center;
                    }
                }
                else
                {
                    projectile.ai[0] = 0f;
                    flag28 = false;
                    projectile.netUpdate = true;
                }
            }
            if (flag28)
            {
                Vector2 v2 = vector55 - projectile.Center;
                float num597 = projectile.velocity.ToRotation();
                float num598 = v2.ToRotation();
                double num599 = num598 - num597;
                if (num599 > Math.PI)
                {
                    num599 -= Math.PI * 2.0;
                }
                if (num599 < -Math.PI)
                {
                    num599 += Math.PI * 2.0;
                }
                projectile.velocity = projectile.velocity.RotatedBy(num599 * 0.10000000149011612);
            }
            float num600 = projectile.velocity.Length();
            projectile.velocity.Normalize();
            projectile.velocity *= num600 + 0.0025f;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, new Rectangle(0, projectile.height * projectile.frame, projectile.width, projectile.height), color, projectile.rotation, drawOrigin, projectile.scale * 0.9f, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}