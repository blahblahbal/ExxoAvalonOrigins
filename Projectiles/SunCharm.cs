using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class SunCharm : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sun Charm");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/SunCharm");
            projectile.aiStyle = -1;
            projectile.width = dims.Width;
            projectile.height = dims.Height / Main.projFrames[projectile.type];
            projectile.damage = 0;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (projectile.active)
            {
                Main.dayTime = true;
                Main.time = 0.0;
                Main.eclipse = true;
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("A solar eclipse is happening!", 50, 255, 130, false);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("A solar eclipse is happening!"), new Color(50, 255, 130));
                }
            }
            projectile.active = false;
            return;
        }
    }
}
