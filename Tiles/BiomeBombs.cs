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

namespace ExxoAvalonOrigins.Tiles
{
	public class BiomeBombs : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Gray);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
			Main.tileFrameImportant[Type] = true;
			drop = mod.ItemType("BiomeBombs");
		}
        public override void HitWire(int i, int j)
        {
            //switch (Main.tile[i, j].frameX % 54)
            //{
            //    case 0:
            //        WorldGen.Convert(i, j, 0, 75);
            //        break;
            //    case 1:
            //        WorldGen.Convert(i, j, 1, 75);
            //        break;
            //    case 2:
            //        WorldGen.Convert(i, j, 5, 75);
            //        break;
            //    case 3:
            //        WorldGen.Convert(i, j, 4, 75);
            //        break;
            //    case 4:
            //        WorldGen.Convert(i, j, 6, 75);
            //        break;
            //    case 5:
            //        WorldGen.Convert(i, j, 3, 75);
            //        break;
            //    case 6:
            //        WorldGen.Convert(i, j, 2, 75);
            //        break;
            //}
            int typeC = 2;
            Tile tile = Main.tile[i, j];
            if (tile.frameX <= 52) typeC = 0;
            else if (tile.frameX >= 54 && tile.frameX <= 106) typeC = 1;
            else if (tile.frameX >= 108 && tile.frameX <= 160) typeC = 5;
            else if (tile.frameX >= 162 && tile.frameX <= 214) typeC = 4;
            else if (tile.frameX >= 216 && tile.frameX <= 268) typeC = 6;
            else if (tile.frameX >= 270 && tile.frameX <= 312) typeC = 3;
            else if (tile.frameX >= 314 && tile.frameX <= 366) typeC = 2;
            //Main.NewText("HI");
            ExxoAvalonOriginsWorld.BCBConvert(i, j, typeC, 75);
            WorldGen.KillTile(i, j, noItem: true);
        }
    }
}
