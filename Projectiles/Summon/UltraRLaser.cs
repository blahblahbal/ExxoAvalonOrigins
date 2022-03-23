using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon
{
    public class UltraRLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionShot[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 4;
            projectile.height = 4;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.aiStyle = 1;
            projectile.light = 0.75f;
            projectile.scale = 1.2f;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 2;
            //Main.PlaySound(SoundID.Item33);
        }
    }
}
