using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Tiles
{
    public class BookcaseTeleporter : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            var name = CreateMapEntryName();
            name.SetDefault("Bookcase");
            AddMapEntry(new Color(191, 142, 111), name);
            dustType = DustID.Dirt;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.Furniture.BookcaseTeleporter>());
        }
        public override bool RightClick(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX == 18 && Main.tile[i, j].TileFrameY == 36)
            {
                Trigger(i, j);
                if (Main.netMode == 1)
                {
                    ModPacket packet = Network.MessageHandler.GetPacket(Network.MessageID.SyncWiring);
                    packet.Write((short)i);
                    packet.Write((short)j);
                    packet.Send();
                }
                return true;
            }
            return false;
        }
        public static void Trigger(int i, int j)
        {
            SoundEngine.PlaySound(28, i * 16, j * 16, 0);
            Wiring.TripWire(i, j, 1, 1);
        }
        public override void HitWire(int i, int j)
        {
            Wiring.SkipWire(i, j);
            for (int p = 0; p < Main.player.Length; p++)
            {
                Player q = Main.player[p];
                if (q.active && !q.dead)
                {
                    Point tileC = q.position.ToTileCoordinates();
                    if ((Main.tile[tileC.X, tileC.Y].HasTile && Main.tile[tileC.X, tileC.Y].TileType == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y].HasTile && Main.tile[tileC.X + 1, tileC.Y].TileType == Type) ||
                        (Main.tile[tileC.X, tileC.Y + 1].HasTile && Main.tile[tileC.X, tileC.Y + 1].TileType == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y + 1].HasTile && Main.tile[tileC.X + 1, tileC.Y + 1].TileType == Type) ||
                        (Main.tile[tileC.X, tileC.Y + 2].HasTile && Main.tile[tileC.X, tileC.Y + 2].TileType == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y + 2].HasTile && Main.tile[tileC.X + 1, tileC.Y + 2].TileType == Type) ||
                        (Main.tile[tileC.X, tileC.Y + 3].HasTile && Main.tile[tileC.X, tileC.Y + 3].TileType == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y + 3].HasTile && Main.tile[tileC.X + 1, tileC.Y + 3].TileType == Type))
                    {
                        if (!Main.tile[i, j + 1].HasTile)
                        {
                            if (Main.netMode == NetmodeID.Server)
                            {
                                RemoteClient.CheckSection(p, new Vector2(i * 16, j * 16 - 16));
                            }
                            q.Teleport(new Vector2(i * 16, j * 16 - 16));
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, p, i * 16, j * 16 - 16);
                            }
                        }
                        if (!Main.tile[i, j + 1].HasTile || !Main.tile[i, j + 2].HasTile)
                        {
                            if (Main.netMode == NetmodeID.Server)
                            {
                                RemoteClient.CheckSection(p, new Vector2(i * 16, j * 16));
                            }
                            q.Teleport(new Vector2(i * 16, j * 16));
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, p, i * 16, j * 16);
                            }
                        }
                        else
                        {
                            if (Main.netMode == NetmodeID.Server)
                            {
                                RemoteClient.CheckSection(p, new Vector2(i * 16, j * 16 - 32));
                            }
                            q.Teleport(new Vector2(i * 16, j * 16 - 32));
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, p, i * 16, j * 16 - 32);
                            }
                        }
                    }
                }
            }
        }
    }
}
