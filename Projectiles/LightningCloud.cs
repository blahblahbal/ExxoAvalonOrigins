using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Projectiles;

public class LightningCloud : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lightning Cloud");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/LightningCloud");
        Projectile.width = dims.Width;
        Projectile.height = dims.Height;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.tileCollide = false;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 3600;
        Projectile.alpha = 20;
        Projectile.aiStyle = -1;
        DrawOriginOffsetX = Projectile.width / 2;
        DrawOriginOffsetY = Projectile.height / 2;
    }

    public override void AI()
    {
        Projectile.frameCounter++;
        if (Projectile.frameCounter == 11)
        {
            SoundEngine.PlaySound(SoundLoader.GetSoundSlot(Mod, "Sounds/Item/LightningStrike"), (int)Projectile.position.X, (int)Projectile.position.Y + 10);
        }
        if (Projectile.frameCounter > 11f)
        {
            Projectile.alpha += 4;
            if (Projectile.alpha > 200)
            {
                Projectile.active = false;
            }
        }
    }
}
