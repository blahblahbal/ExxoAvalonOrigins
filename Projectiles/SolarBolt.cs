using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SolarBolt : ModProjectile
    {
        private Color color;
        private int dustId;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solar Bolt");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SapphireBolt);
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/SolarBolt");
            projectile.width = dims.Width * 10 / 16;
            projectile.height = dims.Height * 10 / 16 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.penetrate = 6;

            color = new Color(255, 50, 0) * 0.4f;
            dustId = 152;
        }

        public override void AI()
        {
            for (var i = 0; i < 2; i++)
            {
                var dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustId, projectile.velocity.X, projectile.velocity.Y, 50, color, 1.2f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.3f;
            }
            if (projectile.ai[1] == 0f)
            {
                projectile.ai[1] = 1f;
                Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 8);
            }

            Lighting.AddLight(new Vector2((int)((projectile.position.X + (float)(projectile.width / 2)) / 16f), (int)((projectile.position.Y + (float)(projectile.height / 2)) / 16f)), color.ToVector3());
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            for (int num453 = 0; num453 < 15; num453++)
            {
                int num454 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustId, projectile.oldVelocity.X, projectile.oldVelocity.Y, 50, color, 1.2f);
                Main.dust[num454].noGravity = true;
                Dust dust152 = Main.dust[num454];
                Dust dust226 = dust152;
                dust226.scale *= 1.25f;
                dust152 = Main.dust[num454];
                dust226 = dust152;
                dust226.velocity *= 0.5f;
            }
            for (int p = 0; p < 8; p++)
            {
                int proj = Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X + (Main.rand.Next(-40, 41) * 0.1f), projectile.velocity.Y + (Main.rand.Next(-40, 41) * 0.1f), ModContent.ProjectileType<SolarBoltOffspring>(), (int)(projectile.damage * 0.8), projectile.knockBack, projectile.owner);
                Main.projectile[proj].timeLeft = 300;
            }
        }
    }
}
