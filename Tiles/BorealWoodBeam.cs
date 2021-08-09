using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;

namespace ExxoAvalonOrigins.Tiles
{
	public class BorealWoodBeam : ModTile
	{
		public override void SetDefaults()
		{
            drop = mod.ItemType("BorealWoodBeam");
            AddMapEntry(new Color(73, 51, 36));
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = false;
            Main.tileFrameImportant[Type] = false;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            //TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.AlternateTile | AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.HookCheck = new PlacementHook(CanPlaceAlter, -1, 0, processedCoordinates: true);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(AfterPlacement, -1, 0, processedCoordinates: false);
            TileObjectData.addTile(Type);
            dustType = 22;
        }

        public override bool CanPlace(int i, int j)
        {
            return (Main.tile[i, j - 1].active() || Main.tile[i - 1, j].active() || Main.tile[i, j + 1].active() || Main.tile[i + 1, j].active() || Main.tile[i, j].wall != 0 && !Main.tile[i, j].active());
        }

        public int CanPlaceAlter(int i, int j, int type, int style, int direction)
        {
            return 1;
        }
        public static int AfterPlacement(int i, int j, int type, int style, int direction)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                NetMessage.SendTileRange(Main.myPlayer, i, j, 1, 1);
            }
            return 1;
        }
    }
}