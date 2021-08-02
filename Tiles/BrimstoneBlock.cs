using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.ObjectData;namespace ExxoAvalonOrigins.Tiles{	public class BrimstoneBlock : ModTile	{		public override void SetDefaults()		{			AddMapEntry(Color.LightPink);			Main.tileSolid[Type] = true;			Main.tileBlockLight[Type] = true;            Main.tileMerge[Type][ModContent.TileType<Impgrass>()] = true;            Main.tileMerge[Type][TileID.Ash] = true;
            Main.tileMerge[TileID.Ash][Type] = true;
            drop = ModContent.ItemType<Items.BrimstoneBlock>();            soundType = SoundID.Tink;            soundStyle = 1;        }        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            //TileFraming.CustomMergeFrame
            return false;
            //Tile tile = Main.tile[i, j];
            //int type = tile.type;
            //Tile tile2 = Main.tile[i, j - 1];
            //Tile tile3 = Main.tile[i, j + 1];
            //Tile tile4 = Main.tile[i - 1, j];
            //Tile tile5 = Main.tile[i + 1, j];
            //Tile tile6 = Main.tile[i - 1, j + 1];
            //Tile tile7 = Main.tile[i + 1, j + 1];
            //Tile tile8 = Main.tile[i - 1, j - 1];
            //Tile tile9 = Main.tile[i + 1, j - 1];
            //int num42 = -1;
            //int num43 = -1;
            //int num44 = -1;
            //int num45 = -1;
            //int num46 = -1;
            //int num47 = -1;
            //int num48 = -1;
            //int num49 = -1;
            //bool mergeDown = false;
            //bool mergeUp = false;
            //bool mergeRight = false;
            //bool mergeLeft = false;
            //if (tile4 != null && tile4.active())
            //{
            //    if (Main.tileStone[(int)tile4.type])
            //    {
            //        num45 = 1;
            //    }
            //    else
            //    {
            //        num45 = (int)tile4.type;
            //    }
            //    if (tile4.slope() == 1 || tile4.slope() == 3)
            //    {
            //        num45 = -1;
            //    }
            //}
            //if (tile5 != null && tile5.active())
            //{
            //    if (Main.tileStone[(int)tile5.type])
            //    {
            //        num46 = 1;
            //    }
            //    else
            //    {
            //        num46 = (int)tile5.type;
            //    }
            //    if (tile5.slope() == 2 || tile5.slope() == 4)
            //    {
            //        num46 = -1;
            //    }
            //}
            //if (tile2 != null && tile2.active())
            //{
            //    if (Main.tileStone[(int)tile2.type])
            //    {
            //        num43 = 1;
            //    }
            //    else
            //    {
            //        num43 = (int)tile2.type;
            //    }
            //    if (tile2.slope() == 3 || tile2.slope() == 4)
            //    {
            //        num43 = -1;
            //    }
            //}
            //if (tile3 != null && tile3.active())
            //{
            //    if (Main.tileStone[(int)tile3.type])
            //    {
            //        num48 = 1;
            //    }
            //    else
            //    {
            //        num48 = (int)tile3.type;
            //    }
            //    if (tile3.slope() == 1 || tile3.slope() == 2)
            //    {
            //        num48 = -1;
            //    }
            //}
            //if (tile8 != null && tile8.active())
            //{
            //    if (Main.tileStone[(int)tile8.type])
            //    {
            //        num42 = 1;
            //    }
            //    else
            //    {
            //        num42 = (int)tile8.type;
            //    }
            //}
            //if (tile9 != null && tile9.active())
            //{
            //    if (Main.tileStone[(int)tile9.type])
            //    {
            //        num44 = 1;
            //    }
            //    else
            //    {
            //        num44 = (int)tile9.type;
            //    }
            //}
            //if (tile6 != null && tile6.active())
            //{
            //    if (Main.tileStone[(int)tile6.type])
            //    {
            //        num47 = 1;
            //    }
            //    else
            //    {
            //        num47 = (int)tile6.type;
            //    }
            //}
            //if (tile7 != null && tile7.active())
            //{
            //    if (Main.tileStone[(int)tile7.type])
            //    {
            //        num49 = 1;
            //    }
            //    else
            //    {
            //        num49 = (int)tile7.type;
            //    }
            //}
            //if (tile.slope() == 2)
            //{
            //    num43 = -1;
            //    num45 = -1;
            //}
            //if (tile.slope() == 1)
            //{
            //    num43 = -1;
            //    num46 = -1;
            //}
            //if (tile.slope() == 4)
            //{
            //    num48 = -1;
            //    num45 = -1;
            //}
            //if (tile.slope() == 3)
            //{
            //    num48 = -1;
            //    num46 = -1;
            //}
            //if (type == 58 || type == 76 || type == 75 || type == 349 || type == ModContent.TileType<BrimstoneBlock>())
            //{
            //    if (num43 == TileID.Ash)
            //    {
            //        num43 = -2;
            //    }
            //    if (num48 == TileID.Ash)
            //    {
            //        num48 = -2;
            //    }
            //    if (num45 == TileID.Ash)
            //    {
            //        num45 = -2;
            //    }
            //    if (num46 == TileID.Ash)
            //    {
            //        num46 = -2;
            //    }
            //    if (num42 == TileID.Ash)
            //    {
            //        num42 = -2;
            //    }
            //    if (num44 == TileID.Ash)
            //    {
            //        num44 = -2;
            //    }
            //    if (num47 == TileID.Ash)
            //    {
            //        num47 = -2;
            //    }
            //    if (num49 == TileID.Ash)
            //    {
            //        num49 = -2;
            //    }
            //}
            //else if (type == 57)
            //{
            //    if (num43 == 1)
            //    {
            //        num43 = -2;
            //    }
            //    if (num48 == 1)
            //    {
            //        num48 = -2;
            //    }
            //    if (num45 == 1)
            //    {
            //        num45 = -2;
            //    }
            //    if (num46 == 1)
            //    {
            //        num46 = -2;
            //    }
            //    if (num42 == 1)
            //    {
            //        num42 = -2;
            //    }
            //    if (num44 == 1)
            //    {
            //        num44 = -2;
            //    }
            //    if (num47 == 1)
            //    {
            //        num47 = -2;
            //    }
            //    if (num49 == 1)
            //    {
            //        num49 = -2;
            //    }
            //    if (num43 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        WorldGen.TileFrame(i, j - 1, false, false);
            //        if (mergeDown)
            //        {
            //            num43 = type;
            //        }
            //    }
            //    if (num48 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        WorldGen.TileFrame(i, j + 1, false, false);
            //        if (mergeUp)
            //        {
            //            num48 = type;
            //        }
            //    }
            //    if (num45 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        WorldGen.TileFrame(i - 1, j, false, false);
            //        if (mergeRight)
            //        {
            //            num45 = type;
            //        }
            //    }
            //    if (num46 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        WorldGen.TileFrame(i + 1, j, false, false);
            //        if (mergeLeft)
            //        {
            //            num46 = type;
            //        }
            //    }
            //    if (num42 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        num42 = type;
            //    }
            //    if (num44 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        num44 = type;
            //    }
            //    if (num47 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        num47 = type;
            //    }
            //    if (num49 == ModContent.TileType<BrimstoneBlock>())
            //    {
            //        num49 = type;
            //    }
            //}
            //return false;
        }
    }}