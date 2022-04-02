using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class DemonSpikeScale : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Demon Spikescale");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/DemonSpikeScale");
        Projectile.width = dims.Width * 8 / 16;
        Projectile.height = dims.Height * 8 / 16 / Main.projFrames[Projectile.type];
        Projectile.aiStyle = -1;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.MaxUpdates = 1;
        Projectile.scale = 1f;
        Projectile.timeLeft = 1200;
        Projectile.DamageType = DamageClass.Ranged;
    }
    public override void Kill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 10);
        for (int num133 = 0; num133 < 3; num133++)
        {
            float num134 = -Projectile.velocity.X * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
            float num135 = -Projectile.velocity.Y * Main.rand.Next(40, 70) * 0.01f + Main.rand.Next(-20, 21) * 0.4f;
            Projectile.NewProjectile(Projectile.position.X + num134, Projectile.position.Y + num135, num134, num135, ModContent.ProjectileType<SpikeShard>(), (int)(Projectile.damage * 0.33), 0f, Projectile.owner, 0f, 0f);
        }
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