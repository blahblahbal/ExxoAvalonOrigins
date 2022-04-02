using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class Rainbringer : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Rainbringer");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Rainbringer");
        Projectile.aiStyle = -1;
        Projectile.width = dims.Width;
        Projectile.height = dims.Height / Main.projFrames[Projectile.type];
        Projectile.damage = 0;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        if (Projectile.active)
        {
            if (!Main.raining)
            {
                ExxoAvalonOrigins.StartRain();
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("A rain event has started.", 0, 148, 255);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("A rain event has started."), new Color(0, 148, 255));
                }
            }
            else
            {
                ExxoAvalonOrigins.StopRain();
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    Main.NewText("The rain has stopped.", 0, 148, 255);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The rain has stopped."), new Color(0, 148, 255));
                }
            }
            Projectile.active = false;
            return;
        }
    }
}
