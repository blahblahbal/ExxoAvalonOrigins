using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class DarkCinder : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Cinder");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/DarkCinder");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.hostile = true;
            projectile.light = 0.4f;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 300;
        }

        public override void AI()
        {
            int randomDust;
            if (Main.rand.NextBool(2))
                randomDust = 58;
            else
                randomDust = 36;

            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 5f)
            {
                projectile.ai[0] = 5f;
                if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
                {
                    projectile.velocity.X *= 0.97f;
                    if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
                    {
                        projectile.velocity.X = 0f;
                        projectile.netUpdate = true;
                    }
                }
                projectile.velocity.Y += 0.2f;
            }
            projectile.rotation += projectile.velocity.X * 0.1f;

            if (Main.rand.Next(3) != 0)
            {
                Dust dust6 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, randomDust);
                dust6.velocity.Y -= 2f;
                dust6.noGravity = true;
                Dust dust = dust6;
                dust.scale += Main.rand.NextFloat() * 0.8f + 0.3f;
                dust = dust6;
                dust.velocity += projectile.velocity * 1f;
            }

            if ((double)projectile.velocity.Y < 0.25 && (double)projectile.velocity.Y > 0.15)
                projectile.velocity.X *= 0.8f;

            projectile.rotation = (0f - projectile.velocity.X) * 0.05f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
                projectile.velocity.X = oldVelocity.X * -0.1f;

            if (projectile.velocity.X != oldVelocity.X)
                projectile.velocity.X = oldVelocity.X * -0.5f;

            if (projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 1f)
                projectile.velocity.Y = oldVelocity.Y * -0.5f;

            return false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Buffs.DarkInferno>(), 120);
        }
    }
}