using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Network
{
    public static class ShadowTeleport
    {
        public static void SendPacket(int teleportType = 0)
        {
            ModPacket message = MessageHandler.GetPacket(MessageID.CursorPosition);
            message.Write(teleportType);
            message.Send();
        }

        public static void HandlePacket(BinaryReader reader, int fromWho)
        {
            global::ExxoAvalonOrigins.ShadowTeleport.Teleport(reader.ReadInt32(), true, fromWho);
        }
    }
}