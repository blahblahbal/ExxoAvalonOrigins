using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class Rainbringer : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rainbringer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Rainbringer");
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
                if (!Main.raining)
                {
                    ExxoAvalonOrigins.StartRain();
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText("A rain event has started.", 0, 148, 255, false);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("A rain event has started."), new Color(0, 148, 255));
                    }
                }
                else
                {
                    ExxoAvalonOrigins.StopRain();
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Main.NewText("The rain has stopped.", 0, 148, 255, false);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The rain has stopped."), new Color(0, 148, 255));
                    }
                }
                projectile.active = false;
                return;
            }
        }
    }
}
