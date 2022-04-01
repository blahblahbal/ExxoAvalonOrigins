using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon
{
    public class UltraLFire : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[Projectile.type] = true;
            ProjectileID.Sets.MinionShot[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.penetrate = 3;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 101;
            Projectile.light = 0.75f;
            Projectile.scale = 1.2f;
            Projectile.timeLeft = 600;
            Projectile.extraUpdates = 2;
            //Main.PlaySound(SoundID.Item20);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 5 * 60);
        }
    }
}
