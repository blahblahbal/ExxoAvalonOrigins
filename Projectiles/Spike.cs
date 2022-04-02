using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Projectiles;

public class Spike : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Spike");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Spike");
        Projectile.width = dims.Width * 8 / 16;
        Projectile.height = dims.Height * 8 / 16 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = false;
        Projectile.hostile = true;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
        Projectile.alpha = 0;
        Projectile.MaxUpdates = 1;
        Projectile.scale = 1f;
        Projectile.timeLeft = 300;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.GetGlobalProjectile<ExxoAvalonOriginsGlobalProjectileInstance>().notReflect = true;
    }

    public override void AI()
    {
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        if (Projectile.velocity.Y > 16f)
        {
            Projectile.velocity.Y = 16f;
        }
    }
}