using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class BookcaseTeleporter : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new[]{ 16, 16, 16, 16 };
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
        public override bool NewRightClick(int i, int j)
        {
            if (Main.tile[i, j].frameX == 18 && Main.tile[i, j].frameY == 36)
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
            Main.PlaySound(28, i * 16, j * 16, 0);
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
                    if ((Main.tile[tileC.X, tileC.Y].active() && Main.tile[tileC.X, tileC.Y].type == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y].active() && Main.tile[tileC.X + 1, tileC.Y].type == Type) ||
                        (Main.tile[tileC.X, tileC.Y + 1].active() && Main.tile[tileC.X, tileC.Y + 1].type == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y + 1].active() && Main.tile[tileC.X + 1, tileC.Y + 1].type == Type) ||
                        (Main.tile[tileC.X, tileC.Y + 2].active() && Main.tile[tileC.X, tileC.Y + 2].type == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y + 2].active() && Main.tile[tileC.X + 1, tileC.Y + 2].type == Type) ||
                        (Main.tile[tileC.X, tileC.Y + 3].active() && Main.tile[tileC.X, tileC.Y + 3].type == Type) ||
                        (Main.tile[tileC.X + 1, tileC.Y + 3].active() && Main.tile[tileC.X + 1, tileC.Y + 3].type == Type))
                    {
                        if (!Main.tile[i, j + 1].active())
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
                        if (!Main.tile[i, j + 1].active() || !Main.tile[i, j + 2].active())
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
