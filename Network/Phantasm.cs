using Microsoft.Xna.Framework;
using System.IO;
using Terraria;

namespace ExxoAvalonOrigins.Network
{
    class Phantasm
    {
        public static void SendPacket(Vector2 coords)
        {
            var netMessage = MessageHandler.GetPacket(MessageID.PhantasmRelocate);
            netMessage.WriteVector2(coords);
            netMessage.Send();
        }
        public static void HandlePacket(BinaryReader reader, int fromWho)
        {
            NPCs.Phantasm.Teleport(reader.ReadVector2(), true, fromWho);
        }
    }
}
