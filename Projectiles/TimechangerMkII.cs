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
            Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/TimechangerMkII");
            Projectile.penetrate = -1;
            Projectile.width = dims.Width * 10 / 32;
            Projectile.height = dims.Height * 10 / 32 / Main.projFrames[Projectile.type];
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.damage = 0;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            switch ((int)Projectile.ai[0])
            {
                case 0:
                    Main.dayTime = true;
                    Main.time = 0;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Day.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Day."), new Color(50, 255, 130));
                    Projectile.active = false;
                    return;
                case 1:
                    Main.dayTime = true;
                    Main.time = 27000;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Noon.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Noon."), new Color(50, 255, 130));
                    Projectile.active = false;
                    return;
                case 2:
                    Main.dayTime = false;
                    Main.time = 0;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Night.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Night."), new Color(50, 255, 130));
                    Projectile.active = false;
                    return;
                case 3:
                    Main.dayTime = false;
                    Main.time = 16200;
                    if (Main.netMode == NetmodeID.SinglePlayer)
                        Main.NewText("It is now Midnight.", 50, 255, 130);
                    else if (Main.netMode == NetmodeID.Server)
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It is now Midnight."), new Color(50, 255, 130));
                    Projectile.active = false;
                    return;
            }

        }
    }
}
