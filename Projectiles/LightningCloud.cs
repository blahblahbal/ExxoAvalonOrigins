using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class LightningCloud : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Cloud");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/LightningCloud");
            projectile.width = dims.Width;
            projectile.height = dims.Height;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 3600;
            projectile.alpha = 20;
            projectile.aiStyle = -1;
            drawOriginOffsetX = projectile.width / 2;
            drawOriginOffsetY = projectile.height / 2;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter == 11)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LightningStrike"), (int)projectile.position.X, (int)projectile.position.Y + 10);
            }
            if (projectile.frameCounter > 11f)
            {
                projectile.alpha += 4;
                if (projectile.alpha > 200)
                {
                    projectile.active = false;
                }
            }
        }
    }
}