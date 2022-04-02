using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Players;

public class ExxoBuffPlayer : ModPlayer
{
    private bool daggerBuffLock;
    public float DaggerStaffRotation { get; private set; }

    public void UpdateDaggerStaff()
    {
        if (daggerBuffLock)
        {
            return;
        }

        DaggerStaffRotation = (DaggerStaffRotation % MathHelper.TwoPi) + 0.01f;
        daggerBuffLock = true;
    }

    public override void PreUpdateBuffs()
    {
        daggerBuffLock = false;
    }

    public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
    {
        if (newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write(DaggerStaffRotation);
            packet.Send(toWho, fromWho);
        }
    }
}
