using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class ChaosBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chaos Bolt");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/ChaosBolt");
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.timeLeft = 540;
            projectile.light = 1f;
            projectile.penetrate = -1;
            projectile.magic = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            var num924 = Dust.NewDust(new Vector2(projectile.position.X + projectile.velocity.X, projectile.position.Y + projectile.velocity.Y), projectile.width, projectile.height, DustID.Shadowflame, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 3f);
            Main.dust[num924].noGravity = true;
            if (Main.rand.Next(10) == 0)
            {
                num924 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Shadowflame, projectile.velocity.X, projectile.velocity.Y, 100, default(Color), 1.4f);
            }
            if (projectile.ai[1] >= 20f)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.2f;
            }
            projectile.rotation += 0.3f * projectile.direction;
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
                return;
            }
        }
    }
}