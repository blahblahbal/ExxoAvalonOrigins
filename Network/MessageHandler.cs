using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Network
{
    public class MessageHandler
    {
        public static ModPacket GetPacket(MessageID messageID, int capacity = 256)
        {
            ModPacket message = ExxoAvalonOrigins.mod.GetPacket(capacity);
            message.Write((int)messageID);
            return message;
        }
        public static void HandlePacket(BinaryReader reader, int fromWho)
        {
            MessageID id = (MessageID)reader.ReadInt32();
            switch (id)
            {
                case MessageID.ShadowTeleport:
                    // what is the point of this, it never gets called as it never gets a message sent
                    ShadowTeleport.HandlePacket(reader, fromWho);
                    break;
                case MessageID.PhantasmRelocate:
                    // what is the point of this, it never gets called as it never gets a message sent
                    Phantasm.HandlePacket(reader, fromWho);
                    break;
                case MessageID.CursorPosition:
                    CursorPosition.HandlePacket(reader, fromWho);
                    break;
            }
        }
    }
}