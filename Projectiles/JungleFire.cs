using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class JungleFire : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Fire");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/JungleFire");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.light = 0.8f;
            projectile.alpha = 100;
            projectile.magic = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 6f)
            {
                projectile.position += projectile.velocity;
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
            }
            return false;
        }

        public override void AI()
        {
            if (projectile.type == ModContent.ProjectileType<DarkFlame>())
            {
                var num150 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Enchanted_Pink, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
                Main.dust[num150].noGravity = true;
                var num151 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Ash, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
                Main.dust[num151].noGravity = true;
            }
            else if (projectile.type == ModContent.ProjectileType<GoldenFlamelet>())
            {
                if (projectile.ai[2] == 1f)
                {
                    for (var num152 = 0; num152 < 2; num152++)
                    {
                        var num153 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.HoneyBubbles, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);
                        Main.dust[num153].noGravity = true;
                        Main.dust[num153].velocity *= 0.3f;
                    }
                    projectile.alpha = 0;
                }
                else
                {
                    var num154 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Enchanted_Gold, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1f);
                    Main.dust[num154].noGravity = true;
                }
            }
            else if (projectile.type == ModContent.ProjectileType<JungleFire>())
            {
                for (var num157 = 0; num157 < 2; num157++)
                {
                    var num158 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.RuneWizard, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num158].noGravity = true;
                    var dust15 = Main.dust[num158];
                    dust15.velocity.X = dust15.velocity.X * 0.3f;
                    var dust16 = Main.dust[num158];
                    dust16.velocity.Y = dust16.velocity.Y * 0.3f;
                }
            }
            else
            {
                for (var num159 = 0; num159 < 2; num159++)
                {
                    var num160 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num160].noGravity = true;
                    var dust17 = Main.dust[num160];
                    dust17.velocity.X = dust17.velocity.X * 0.3f;
                    var dust18 = Main.dust[num160];
                    dust18.velocity.Y = dust18.velocity.Y * 0.3f;
                }
            }
            if (projectile.type != ModContent.ProjectileType<DarkFlame>())
            {
                projectile.ai[1] += 1f;
            }
            if (projectile.type == ModContent.ProjectileType<GoldenFlamelet>() && projectile.ai[2] == 1f)
            {
                projectile.ai[1] -= 1f;
            }
            if (projectile.ai[1] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            projectile.rotation += 0.3f * projectile.direction;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
        }
    }
}