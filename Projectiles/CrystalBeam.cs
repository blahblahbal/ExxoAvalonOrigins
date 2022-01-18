using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles
{
    public class CrystalBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Beam");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/CrystalBeam");
            projectile.aiStyle = -1;
            projectile.width = 4;
            projectile.height = 4;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.MaxUpdates = 100;
            projectile.alpha = 255;
            projectile.timeLeft = 100;
            projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        }
        public override void AI()
        {
            for (int num560 = 0; num560 < 4; num560++)
            {
                Vector2 value7 = projectile.position;
                value7 -= projectile.velocity * num560 * 0.25f;
                projectile.alpha = 255;
                int dt = Main.rand.Next(3);
                if (dt == 0) dt = DustID.BlueCrystalShard;
                if (dt == 1) dt = DustID.PinkCrystalShard;
                if (dt == 2) dt = DustID.PurpleCrystalShard;
                int num561 = Dust.NewDust(value7, 1, 1, dt, 0f, 0f, 0, default, 1f);
                Main.dust[num561].position = value7;
                Main.dust[num561].position.X += projectile.width / 2;
                Main.dust[num561].position.Y += projectile.height / 2;
                Main.dust[num561].scale = Main.rand.Next(70, 110) * 0.013f;
                Main.dust[num561].velocity *= 0.2f;
                Main.dust[num561].noGravity = true;
            }
        }
    }
}
