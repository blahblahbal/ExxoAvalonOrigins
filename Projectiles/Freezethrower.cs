using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Freezethrower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Freezethrower");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/Freezethrower");
            projectile.width = dims.Width * 6 / 16;
            projectile.height = dims.Height * 6 / 16 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 4;
            projectile.MaxUpdates = 2;
            projectile.ranged = true;
        }

        public override void AI()
        {
            if (projectile.timeLeft > 60)
            {
                projectile.timeLeft = 60;
            }
            if (projectile.ai[0] > 6f)
            {
                var num349 = 1f;
                if (projectile.ai[0] == 8f)
                {
                    num349 = 0.25f;
                }
                else if (projectile.ai[0] == 9f)
                {
                    num349 = 0.5f;
                }
                else if (projectile.ai[0] == 10f)
                {
                    num349 = 0.75f;
                }
                projectile.ai[0] += 1f;
                var num350 = 6;
                if (projectile.type == ProjectileID.EyeFire)
                {
                    num350 = 75;
                }
                if (projectile.type == ModContent.ProjectileType<Freezethrower>())
                {
                    num350 = ModContent.DustType<Dusts.FreezethrowerDust>();
                }
                if (num350 == 6 || num350 == 181 || Main.rand.Next(2) == 0)
                {
                    for (var num351 = 0; num351 < 1; num351++)
                    {
                        var num352 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, num350, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
                        if (Main.rand.Next(3) != 0 || (num350 == 75 && Main.rand.Next(3) == 0))
                        {
                            Main.dust[num352].noGravity = true;
                            Main.dust[num352].scale *= 3f;
                            var dust53 = Main.dust[num352];
                            dust53.velocity.X = dust53.velocity.X * 2f;
                            var dust54 = Main.dust[num352];
                            dust54.velocity.Y = dust54.velocity.Y * 2f;
                        }
                        else
                        {
                            Main.dust[num352].scale *= 1.5f;
                        }
                        var dust55 = Main.dust[num352];
                        dust55.velocity.X = dust55.velocity.X * 1.2f;
                        var dust56 = Main.dust[num352];
                        dust56.velocity.Y = dust56.velocity.Y * 1.2f;
                        Main.dust[num352].scale *= num349;
                        if (num350 == 75)
                        {
                            Main.dust[num352].velocity += projectile.velocity;
                            if (!Main.dust[num352].noGravity)
                            {
                                Main.dust[num352].velocity *= 0.5f;
                            }
                        }
                    }
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
            projectile.rotation += 0.3f * projectile.direction;
        }
    }
}