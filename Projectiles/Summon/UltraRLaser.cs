using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles.Summon;

public class UltraRLaser : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.Homing[Projectile.type] = true;
        ProjectileID.Sets.MinionShot[Projectile.type] = true;
    }

    public override void SetDefaults()
    {
        Projectile.width = 4;
        Projectile.height = 4;
        Projectile.penetrate = 3;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.aiStyle = 1;
        Projectile.light = 0.75f;
        Projectile.scale = 1.2f;
        Projectile.timeLeft = 600;
        Projectile.extraUpdates = 2;
        //Main.PlaySound(SoundID.Item33);
    }
}