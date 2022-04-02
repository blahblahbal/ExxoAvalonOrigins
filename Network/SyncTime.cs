using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Network;

public static class SyncTime
{
    public static void SendPacket(int time = 0, bool dayTime = true)
    {
        ModPacket message = MessageHandler.GetPacket(MessageID.SyncTime);
        message.Write(time);
        message.Write(dayTime);
        message.Send();
    }

    public static void HandlePacket(BinaryReader reader, int fromWho)
    {
        Main.time = reader.ReadInt32();
        Main.dayTime = reader.ReadBoolean();
    }
}