using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Melee
{
    public class GuardianHammer : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Melee/GuardianHammer");
            projectile.width = dims.Width * 28 / 40;
            projectile.height = dims.Height * 28 / 40 / Main.projFrames[projectile.type];
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.MaxUpdates = 2;
            aiType = 301;
        }
        public override void AI()
        {
            /*if (projectile.soundDelay == 0)
            {
                projectile.soundDelay = 32;
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 7);
            }
            if (projectile.ai[0] == 0)
            {
                projectile.ai[1]++;
                if (projectile.ai[1] >= 20f)
                {
                    projectile.ai[0] = 1f;
                    projectile.ai[1] = 0f;
                    projectile.netUpdate = true;
                }
            }
            else
            {
                projectile.tileCollide = false;
                float num88 = 20f;
                float num89 = 3f;
                Vector2 vector3 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                float num90 = Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2 - vector3.X;
                float num91 = Main.player[projectile.owner].position.Y + Main.player[projectile.owner].height / 2 - vector3.Y;
                float num92 = (float)Math.Sqrt(num90 * num90 + num91 * num91);
                if (num92 > 3000f)
                {
                    projectile.Kill();
                }
                num92 = num88 / num92;
                num90 *= num92;
                num91 *= num92;
                if (projectile.velocity.X < num90)
                {
                    projectile.velocity.X = projectile.velocity.X + num89;
                    if (projectile.velocity.X < 0f && num90 > 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X + num89;
                    }
                }
                else if (projectile.velocity.X > num90)
                {
                    projectile.velocity.X = projectile.velocity.X - num89;
                    if (projectile.velocity.X > 0f && num90 < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X - num89;
                    }
                }
                if (projectile.velocity.Y < num91)
                {
                    projectile.velocity.Y = projectile.velocity.Y + num89;
                    if (projectile.velocity.Y < 0f && num91 > 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y + num89;
                    }
                }
                else if (projectile.velocity.Y > num91)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num89;
                    if (projectile.velocity.Y > 0f && num91 < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num89;
                    }
                }
                if (Main.myPlayer == projectile.owner)
                {
                    Rectangle rectangle = projectile.getRect();
                    Rectangle value2 = new Rectangle((int)Main.player[projectile.owner].position.X, (int)Main.player[projectile.owner].position.Y, Main.player[projectile.owner].width, Main.player[projectile.owner].height);
                    if (rectangle.Intersects(value2))
                    {
                        projectile.Kill();
                    }
                }
            }
            projectile.rotation += 0.4f * projectile.direction;*/
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            StrikeLightning(projectile);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            StrikeLightning(projectile);
            int num34 = 10;
            int num35 = 10;
            Vector2 vector7 = new Vector2(projectile.Center.X - num34 / 2, projectile.Center.Y - num35 / 2);
            projectile.velocity = Collision.TileCollision(vector7, projectile.velocity, num34, num35, true, true, 1);
            return base.OnTileCollide(oldVelocity);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(250, 250, 250, 50);
        }
        public void StrikeLightning(Projectile p)
        {
            var cloudPosition = new Vector2(p.Center.X + 0f, p.Center.Y - 160f);
            var targetPosition = new Vector2(p.Center.X, p.Center.Y);
            var targetPosition2 = new Vector2(p.Center.X + Main.rand.Next(-40, -20), p.Center.Y);
            var targetPosition3 = new Vector2(p.Center.X + Main.rand.Next(-40, -20), p.Center.Y);
            if (Main.rand.Next(2) == 0)
            {
                targetPosition2 = new Vector2(p.Center.X + Main.rand.Next(20, 40), p.Center.Y);
            }
            if (Main.rand.Next(2) == 0)
            {
                targetPosition3 = new Vector2(p.Center.X + Main.rand.Next(20, 40), p.Center.Y);
            }

            Projectile.NewProjectile(cloudPosition, Vector2.Zero, ModContent.ProjectileType<LightningCloud>(), 0, 0f, p.owner);

            for (int i = 0; i < 1; i++)
            {
                Vector2 vectorBetween = targetPosition - cloudPosition;
                float randomSeed = Main.rand.Next(100);
                Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                Projectile.NewProjectile(cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), p.damage, 0f, p.owner, vectorBetween.ToRotation(), randomSeed);
            }
            for (int i = 0; i < 1; i++)
            {
                Vector2 vectorBetween = targetPosition2 - cloudPosition;
                float randomSeed = Main.rand.Next(100);
                Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                Projectile.NewProjectile(cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), p.damage, 0f, p.owner, vectorBetween.ToRotation(), randomSeed);
            }
            for (int i = 0; i < 1; i++)
            {
                Vector2 vectorBetween = targetPosition3 - cloudPosition;
                float randomSeed = Main.rand.Next(100);
                Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                Projectile.NewProjectile(cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), p.damage, 0f, p.owner, vectorBetween.ToRotation(), randomSeed);
            }
        }
    }
}
