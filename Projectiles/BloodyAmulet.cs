using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class BloodyAmulet : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Bloody Amulet");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/BloodyAmulet");
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
            Main.dayTime = false;
            Main.time = 0.0;
            Main.bloodMoon = true;
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("The Blood Moon is rising...", 50, 255, 130);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                Terraria.Chat.ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon is rising..."),
                    new Color(50, 255, 130));
            }
            Projectile.active = false;
            return;
        }
    }
}
