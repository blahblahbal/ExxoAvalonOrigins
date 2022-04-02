using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Projectiles;

public class Moonphaser : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Moonphaser");
    }

    public override void SetDefaults()
    {
        Rectangle dims = ExxoAvalonOrigins.GetDims("Projectiles/Moonphaser");
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
            Main.moonPhase++;
            if (Main.moonPhase >= 8)
            {
                Main.moonPhase = 0;
            }
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                if (Main.moonPhase == 0)
                {
                    Main.NewText("Moon Phase is now Full.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 1)
                {
                    Main.NewText("Moon Phase is now Last Gibbous.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 2)
                {
                    Main.NewText("Moon Phase is now Last Quarter.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 3)
                {
                    Main.NewText("Moon Phase is now Last Crescent.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 4)
                {
                    Main.NewText("Moon Phase is now New.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 5)
                {
                    Main.NewText("Moon Phase is now First Crescent.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 6)
                {
                    Main.NewText("Moon Phase is now First Quarter.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
                if (Main.moonPhase == 7)
                {
                    Main.NewText("Moon Phase is now First Gibbous.", 50, 255, 130, false);
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        Main.NewText("The Blood Moon has risen...", 50, 255, 130, false);
                    }
                    Projectile.active = false;
                    return;
                }
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                if (Main.moonPhase == 0)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Full."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 1)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Last Gibbous."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 2)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Last Quarter."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 3)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now Last Crescent."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 4)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now New."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 5)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now First Crescent."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 6)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now First Quarter."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                }
                if (Main.moonPhase == 7)
                {
                    NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Moon Phase is now First Gibbous."), new Color(50, 255, 130));
                    if (Main.rand.Next(14) == 0 && !Main.dayTime)
                    {
                        Main.bloodMoon = true;
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The Blood Moon has risen..."), new Color(50, 255, 130));
                    }
                    Projectile.active = false;
                    return;
                }
            }
        }
    }
}