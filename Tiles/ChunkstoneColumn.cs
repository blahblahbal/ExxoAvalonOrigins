using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExxoAvalonOrigins.Tiles
{
	public class ChunkstoneColumn : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(73, 51, 36));
			drop = mod.ItemType("ChunkstoneColumn");
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.HookCheck = new PlacementHook(CanPlaceAlter, -1, 0, processedCoordinates: true);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacement, -1, 0, processedCoordinates: false);
            TileObjectData.addTile(Type);
        }
        public int CanPlaceAlter(int i, int j, int type, int style, int direction)
        {
            return 1;
        }
        public static int AfterPlacement(int i, int j, int type, int style, int direction)
        {
            if (Main.netMode == 1)
            {
                NetMessage.SendTileRange(Main.myPlayer, i, j, 1, 1);
            }
            return 1;
        }
    }
}