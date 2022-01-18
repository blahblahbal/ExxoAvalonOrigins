using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Network
{
    public class SyncWiring
    {
        public static void HandlePacket(BinaryReader reader, int fromWho)
        {
            int x = reader.ReadInt16();
            int y = reader.ReadInt16();
            Wiring.SetCurrentUser(fromWho);
            Tiles.BookcaseTeleporter.Trigger(x, y);
            Wiring.SetCurrentUser();
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = MessageHandler.GetPacket(MessageID.SyncWiring);
                packet.Write((short)x);
                packet.Write((short)y);
                packet.Send(-1, fromWho);
            }
        }
    }
}
