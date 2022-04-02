using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class StingerLaser : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Stinger Laser");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/StingerLaser");
        Projectile.width = dims.Width * 4 / 20;
        Projectile.height = dims.Height * 4 / 20 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = 1;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.penetrate = 1;
        Projectile.light = 0.8f;
        Projectile.alpha = 0;
        Projectile.scale = 1.2f;
        Projectile.timeLeft = 300;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
        AIType = ProjectileID.DeathLaser;
    }
}
