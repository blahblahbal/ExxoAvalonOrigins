using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles
{
    public class TimechangerMkII : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Timechanger Mk II");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Projectiles/TimechangerMkII");
            projectile.penetrate = -1;
            projectile.width = dims.Width * 10 / 32;
            projectile.height = dims.Height * 10 / 32 / Main.projFrames[projectile.type];
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.damage = 0;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            switch ((int)projectile.ai[0])
            {
                case 0:
                    Main.dayTime = true;
                    Main.time = 0;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Day.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Day."), new Color(50, 255, 130));
                    projectile.active = false;
                    return;
                case 1:
                    Main.dayTime = true;
                    Main.time = 27000;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Noon.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Noon."), new Color(50, 255, 130));
                    projectile.active = false;
                    return;
                case 2:
                    Main.dayTime = false;
                    Main.time = 0;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Night.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Night."), new Color(50, 255, 130));
                    projectile.active = false;
                    return;
                case 3:
                    Main.dayTime = false;
                    Main.time = 16200;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Midnight.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Midnight."), new Color(50, 255, 130));
                    projectile.active = false;
                    return;
            }

        }
    }
}
