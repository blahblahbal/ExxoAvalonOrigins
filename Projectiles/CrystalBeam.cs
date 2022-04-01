using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/CrystalBeam");
            Projectile.aiStyle = -1;
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.hostile = true;
            Projectile.MaxUpdates = 100;
            Projectile.alpha = 255;
            Projectile.timeLeft = 100;
            Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        }
        public override void AI()
        {
            for (int num560 = 0; num560 < 4; num560++)
            {
                Vector2 value7 = Projectile.position;
                value7 -= Projectile.velocity * num560 * 0.25f;
                Projectile.alpha = 255;
                int dt = Main.rand.Next(3);
                if (dt == 0) dt = DustID.BlueCrystalShard;
                if (dt == 1) dt = DustID.PinkCrystalShard;
                if (dt == 2) dt = DustID.PurpleCrystalShard;
                int num561 = Dust.NewDust(value7, 1, 1, dt, 0f, 0f, 0, default, 1f);
                Main.dust[num561].position = value7;
                Main.dust[num561].position.X += Projectile.width / 2;
                Main.dust[num561].position.Y += Projectile.height / 2;
                Main.dust[num561].scale = Main.rand.Next(70, 110) * 0.013f;
                Main.dust[num561].velocity *= 0.2f;
                Main.dust[num561].noGravity = true;
            }
        }
    }
}
