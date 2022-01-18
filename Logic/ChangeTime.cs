using Terraria;
using Terraria.ID;

namespace ExxoAvalonOrigins.Logic
{
    public static class ChangeTime
    {
        public static void TimeChange(int time = 0, bool forceHandle = false, int whoAmI = 0, bool dayTime = true)
        {
            bool syncData = forceHandle || Main.netMode == NetmodeID.SinglePlayer;
            if (syncData)
            {
                Main.time = time;
                Main.dayTime = dayTime;
            }
            else
            {
                Network.SyncTime.SendPacket(time, dayTime);
            }
        }

    }
}
