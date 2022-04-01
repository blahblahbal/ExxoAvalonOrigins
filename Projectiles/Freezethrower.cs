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
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Freezethrower");
            Projectile.width = dims.Width * 6 / 16;
            Projectile.height = dims.Height * 6 / 16 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.penetrate = 4;
            Projectile.MaxUpdates = 2;
            Projectile.DamageType = DamageClass.Ranged;
        }

        public override void AI()
        {
            if (Projectile.timeLeft > 60)
            {
                Projectile.timeLeft = 60;
            }
            if (Projectile.ai[0] > 6f)
            {
                var num349 = 1f;
                if (Projectile.ai[0] == 8f)
                {
                    num349 = 0.25f;
                }
                else if (Projectile.ai[0] == 9f)
                {
                    num349 = 0.5f;
                }
                else if (Projectile.ai[0] == 10f)
                {
                    num349 = 0.75f;
                }
                Projectile.ai[0] += 1f;
                var num350 = 6;
                if (Projectile.type == ProjectileID.EyeFire)
                {
                    num350 = 75;
                }
                if (Projectile.type == ModContent.ProjectileType<Freezethrower>())
                {
                    num350 = ModContent.DustType<Dusts.FreezethrowerDust>();
                }
                if (num350 == 6 || num350 == 181 || Main.rand.Next(2) == 0)
                {
                    for (var num351 = 0; num351 < 1; num351++)
                    {
                        var num352 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, num350, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1f);
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
                            Main.dust[num352].velocity += Projectile.velocity;
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
                Projectile.ai[0] += 1f;
            }
            Projectile.rotation += 0.3f * Projectile.direction;
        }
    }
}