using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class KunziteShower : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kunzite Shower");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/KunziteShower");
            projectile.width = dims.Width * 32 / 16;
            projectile.height = dims.Height * 32 / 16 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.penetrate = 5;
            projectile.MaxUpdates = 2;
            projectile.ignoreWater = true;
            projectile.magic = true;
        }

        public override void AI()
        {
            if (projectile.type == ProjectileID.GoldenShowerHostile && projectile.localAI[0] == 0f)
            {
                projectile.localAI[0] = 1f;
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 17);
            }
            if (projectile.type != ModContent.ProjectileType<KunziteShower>())
            {
                projectile.scale -= 0.02f;
            }
            else
            {
                projectile.scale -= 0.002f;
            }
            if (projectile.scale <= 0f)
            {
                projectile.Kill();
            }
            if (projectile.ai[0] > 3f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
                for (var num216 = 0; num216 < 1; num216++)
                {
                    for (var num217 = 0; num217 < 3; num217++)
                    {
                        var num218 = projectile.velocity.X / 3f * num217;
                        var num219 = projectile.velocity.Y / 3f * num217;
                        var num220 = 6;
                        var num221 = 172;
                        if (projectile.type == ModContent.ProjectileType<KunziteShower>())
                        {
                            num221 = 141;
                        }
                        var num222 = Dust.NewDust(new Vector2(projectile.position.X + num220, projectile.position.Y + num220), projectile.width - num220 * 2, projectile.height - num220 * 2, num221, 0f, 0f, 100, default(Color), 1.2f);
                        Main.dust[num222].noGravity = true;
                        Main.dust[num222].velocity *= 0.3f;
                        Main.dust[num222].velocity += projectile.velocity * 0.5f;
                        var dust29 = Main.dust[num222];
                        dust29.position.X = dust29.position.X - num218;
                        var dust30 = Main.dust[num222];
                        dust30.position.Y = dust30.position.Y - num219;
                    }
                    if (Main.rand.Next(8) == 0)
                    {
                        var num223 = 6;
                        var num224 = 172;
                        if (projectile.type == ModContent.ProjectileType<KunziteShower>())
                        {
                            num224 = 141;
                        }
                        var num225 = Dust.NewDust(new Vector2(projectile.position.X + num223, projectile.position.Y + num223), projectile.width - num223 * 2, projectile.height - num223 * 2, num224, 0f, 0f, 100, default(Color), 0.75f);
                        Main.dust[num225].velocity *= 0.5f;
                        Main.dust[num225].velocity += projectile.velocity * 0.5f;
                    }
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
        }
    }
}