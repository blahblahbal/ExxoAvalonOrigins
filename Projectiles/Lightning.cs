using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Lightning : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            aiType = ProjectileID.CultistBossLightningOrbArc;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 600;
            projectile.friendly = true;
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
        }

        public override string Texture => "Terraria/Projectile_" + ProjectileID.CultistBossLightningOrbArc;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Dust.NewDust(projectile.Center, 0, 0, DustID.Electric, 0f, 0f);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Dust.NewDust(projectile.Center, 0, 0, DustID.Electric, 0f, 0f);
            base.OnHitNPC(target, damage, knockback, crit);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 end = projectile.position + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
            Vector2 scale = new Vector2(projectile.scale) / 2f;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        scale = new Vector2(projectile.scale) * 0.6f;
                        DelegateMethods.c_1 = new Color(115, 204, 219, 0) * 0.5f;
                        break;

                    case 1:
                        scale = new Vector2(projectile.scale) * 0.4f;
                        DelegateMethods.c_1 = new Color(113, 251, 255, 0) * 0.5f;
                        break;

                    default:
                        scale = new Vector2(projectile.scale) * 0.2f;
                        DelegateMethods.c_1 = new Color(255, 255, 255, 0) * 0.5f;
                        break;
                }
                DelegateMethods.f_1 = 1f;
                for (int j = projectile.oldPos.Length - 1; j > 0; j--)
                {
                    if (!(projectile.oldPos[j] == Vector2.Zero))
                    {
                        Vector2 start = projectile.oldPos[j] + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
                        Vector2 end2 = projectile.oldPos[j - 1] + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
                        Utils.DrawLaser(spriteBatch, Main.projectileTexture[projectile.type], start, end2, scale, DelegateMethods.LightningLaserDraw);
                    }
                }
                if (projectile.oldPos[0] != Vector2.Zero)
                {
                    DelegateMethods.f_1 = 1f;
                    Vector2 start2 = projectile.oldPos[0] + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
                    Utils.DrawLaser(spriteBatch, Main.projectileTexture[projectile.type], start2, end, scale, DelegateMethods.LightningLaserDraw);
                }
            }
            return false;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            Lighting.AddLight(projectile.Center, 0.3f, 0.45f, 0.5f);

            if (projectile.velocity == Vector2.Zero)
            {
                if (projectile.frameCounter >= projectile.extraUpdates * 2)
                {
                    projectile.frameCounter = 0;
                    bool flag28 = true;
                    for (int i = 1; i < projectile.oldPos.Length; i++)
                    {
                        if (projectile.oldPos[i] != projectile.oldPos[0])
                        {
                            flag28 = false;
                        }
                    }
                    if (flag28)
                    {
                        projectile.Kill();
                        return;
                    }
                }
                if (Main.rand.Next(projectile.extraUpdates) == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        float num1054 = projectile.rotation + ((Main.rand.Next(2) == 1) ? (-1f) : 1f) * ((float)Math.PI / 2f);
                        float num1055 = (float)Main.rand.NextDouble() * 0.8f + 1f;
                        Vector2 vector93 = new Vector2((float)Math.Cos(num1054) * num1055, (float)Math.Sin(num1054) * num1055);
                        int num1056 = Dust.NewDust(projectile.Center, 0, 0, DustID.Electric, vector93.X, vector93.Y);
                        Main.dust[num1056].noGravity = true;
                        Main.dust[num1056].scale = 1.2f;
                    }
                    if (Main.rand.Next(5) == 0)
                    {
                        Vector2 value39 = projectile.velocity.RotatedBy(1.5707963705062866) * ((float)Main.rand.NextDouble() - 0.5f) * projectile.width;
                        int num1057 = Dust.NewDust(projectile.Center + value39 - Vector2.One * 4f, 8, 8, DustID.Smoke, 0f, 0f, 100, default(Color), 1.5f);
                        Dust dust64 = Main.dust[num1057];
                        Dust dust189 = dust64;
                        dust189.velocity *= 0.5f;
                        Main.dust[num1057].velocity.Y = 0f - Math.Abs(Main.dust[num1057].velocity.Y);
                    }
                }
            }
            else
            {
                if (projectile.frameCounter < projectile.extraUpdates * 2)
                {
                    return;
                }
                projectile.frameCounter = 0;
                float num1058 = projectile.velocity.Length();
                UnifiedRandom unifiedRandom = new UnifiedRandom((int)projectile.ai[1]);
                int num1059 = 0;
                Vector2 spinningpoint6 = -Vector2.UnitY;
                while (true)
                {
                    int randomSeed = unifiedRandom.Next();
                    projectile.ai[1] = randomSeed;
                    randomSeed %= 100;
                    float f = (float)randomSeed / 100f * ((float)Math.PI * 2f);
                    Vector2 vector94 = f.ToRotationVector2();
                    if (vector94.Y > 0f)
                    {
                        vector94.Y *= -1f;
                    }
                    bool flag29 = false;
                    if (vector94.Y > -0.02f)
                    {
                        flag29 = true;
                    }
                    if (vector94.X * (float)(projectile.extraUpdates + 1) * 2f * num1058 + projectile.localAI[0] > 40f)
                    {
                        flag29 = true;
                    }
                    if (vector94.X * (float)(projectile.extraUpdates + 1) * 2f * num1058 + projectile.localAI[0] < -40f)
                    {
                        flag29 = true;
                    }
                    if (flag29)
                    {
                        if (num1059++ >= 300)
                        {
                            projectile.velocity = Vector2.Zero;
                            break;
                        }
                        continue;
                    }
                    spinningpoint6 = vector94;
                    break;
                }
                if (projectile.velocity != Vector2.Zero)
                {
                    projectile.localAI[0] += spinningpoint6.X * (float)(projectile.extraUpdates + 1) * 2f * num1058;
                    projectile.velocity = spinningpoint6.RotatedBy(projectile.ai[0] + (float)Math.PI / 2f) * num1058;
                    projectile.rotation = projectile.velocity.ToRotation() + (float)Math.PI / 2f;
                }
            }
        }
    }
}