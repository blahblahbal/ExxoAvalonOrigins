using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.World.Structures
{
    public class Nest
    {
        // 19 wide x 19 tall
        public static Vector2 MakeCell(int x, int y)
        {
            int[,] _structure = {
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,1,1,1,3,1,1,1,0,0,0,0,0,0},
                {0,0,0,0,0,1,1,3,3,2,3,3,1,1,0,0,0,0,0},
                {0,0,0,1,1,1,3,2,2,2,2,2,3,1,1,1,0,0,0},
                {0,0,1,1,3,3,2,2,2,2,2,2,2,3,3,1,1,0,0},
                {1,1,1,3,2,2,2,2,2,2,2,2,2,2,2,3,1,1,1},
                {1,1,3,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1,1},
                {1,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1},
                {1,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1},
                {1,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1},
                {1,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1},
                {1,3,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1},
                {1,1,3,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1,1},
                {1,1,1,3,2,2,2,2,2,2,2,2,2,2,2,3,1,1,1},
                {0,0,1,1,3,3,2,2,2,2,2,2,2,3,3,1,1,0,0},
                {0,0,0,1,1,1,3,2,2,2,2,2,3,1,1,1,0,0,0},
                {0,0,0,0,0,1,1,3,3,2,3,3,1,1,0,0,0,0,0},
                {0,0,0,0,0,0,1,1,1,3,1,1,1,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0}
            };
            int PosX = x - (int)Math.Ceiling(_structure.GetLength(0) / 2f);  //spawnX and spawnY is where you want the anchor to be when this generates
            int PosY = y - (int)Math.Ceiling(_structure.GetLength(1) / 2f);

            //i = vertical, j = horizontal
            for (int confirmPlatforms = 0; confirmPlatforms < 1; confirmPlatforms++)    //Increase the iterations on this outermost for loop if tabletop-objects are not properly spawning
            {
                for (int i = 0; i < _structure.GetLength(0); i++)
                {
                    for (int j = _structure.GetLength(1) - 1; j >= 0; j--)
                    {
                        int k = PosX + j;
                        int l = PosY + i;
                        if (WorldGen.InWorld(k, l, 30))
                        {
                            Tile tile = Framing.GetTileSafely(k, l);
                            switch (_structure[i, j])
                            {
                                case 0:
                                    break;
                                case 1:
                                    tile.active(true);
                                    if (tile.TileType != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.TileType = (ushort)ModContent.TileType<Tiles.Nest>();
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    //tile.wall = (ushort)ModContent.WallType<Walls.NestWall>();
                                    break;
                                case 2:
                                    if (confirmPlatforms == 0)
                                    {
                                        if (tile.TileType != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.active(false);
                                        if (tile.TileType != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.halfBrick(false);
                                        if (tile.TileType != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.slope(0);
                                        if (tile.TileType != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.WallType = (ushort)ModContent.WallType<Walls.NestWall>();
                                        tile.liquid = 0;
                                        tile.lava(false);
                                        tile.honey(true);
                                    }
                                    break;
                                case 3:
                                    tile.active(true);
                                    if (tile.TileType != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.TileType = (ushort)ModContent.TileType<Tiles.Nest>();
                                    if (tile.TileType != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.WallType = (ushort)ModContent.WallType<Walls.NestWall>();
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    //tile.wall = (ushort)ModContent.WallType<Walls.NestWall>();
                                    break;
                            }
                        }
                    }
                }
            }
            return new Vector2(x + 9, y + 9);
        }

        public static void CreateWaspNest(int x, int y)
        {
            //int num = 150;
            //for (int i = x - num; i < x + num; i += 10)
            //{
            //    if (i <= 0 || i > Main.maxTilesX - 1)
            //    {
            //        continue;
            //    }
            //    for (int j = y - num; j < y + num; j += 10)
            //    {
            //        if (j > 0 && j <= Main.maxTilesY - 1)
            //        {
            //            if (Main.tile[i, j].HasTile && Main.tile[i, j].type == (ushort)ModContent.TileType<Tiles.TuhrtlBrick>())
            //            {
            //                return;
            //            }
            //            if (Main.tile[i, j].wall == (ushort)ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>() || Main.tile[i, j].wall == (ushort)ModContent.WallType<Walls.ChunkstoneWall>() || Main.tile[i, j].wall == 3 || Main.tile[i, j].wall == 83)
            //            {
            //                return;
            //            }
            //        }
            //    }
            //}

            MakeCell(x, y);

            int rightSide = WorldGen.genRand.Next(2);
            int leftSide = WorldGen.genRand.Next(2);

            //int radius = 9;

            if (rightSide == 0)
            {
                Vector2 rSideM = MakeCell(x + 18, y);

                int xOffR = (int)(rSideM.X + 19 * (float)Math.Cos(2 * 60 * Math.PI / 180f));
                int yOffR = (int)(rSideM.Y + 19 * (float)Math.Sin(2 * 60 * Math.PI / 180f));

                Vector2 cell = MakeCell(xOffR, yOffR);
                int xoffcell = (int)(cell.X + 17 * (float)Math.Cos(3 * 60 * Math.PI / 180f));
                int yoffcell = (int)(cell.Y + 17 * (float)Math.Sin(3 * 60 * Math.PI / 180f));

                if (WorldGen.genRand.Next(2) == 0)
                {
                    MakeCell(xoffcell, yoffcell + 3);
                }
            }

            if (leftSide == 0)
            {
                Vector2 lSideM = MakeCell(x - 18, y);
                int xOffL = (int)(lSideM.X + 19 * (float)Math.Cos(1 * 60 * Math.PI / 180f));
                int yOffL = (int)(lSideM.Y + 19 * (float)Math.Sin(1 * 60 * Math.PI / 180f));

                Vector2 cell = MakeCell(xOffL, yOffL);
                int xoffcell = (int)(cell.X + 17 * (float)Math.Cos(3 * 60 * Math.PI / 180f));
                int yoffcell = (int)(cell.Y + 17 * (float)Math.Sin(3 * 60 * Math.PI / 180f));

                if (WorldGen.genRand.Next(2) == 0)
                {
                    MakeCell(xoffcell, yoffcell + 3);
                }

                //int xOffL2 = (int)(lSideM.X + 19 * (float)Math.Cos(2 * 60 * Math.PI / 180f));
                //int yOffL2 = (int)(lSideM.Y + 19 * (float)Math.Sin(2 * 60 * Math.PI / 180f));
                //if (WorldGen.genRand.Next(1) == 0)
                //{
                //    MakeCell(xoffcell - 18, yoffcell);
                //}
            }

            Main.tile[x, y].TileType = (ushort)ModContent.TileType<Tiles.Nest>();
            Main.tile[x - 1, y].TileType = (ushort)ModContent.TileType<Tiles.Nest>();
            Main.tile[x + 1, y].TileType = (ushort)ModContent.TileType<Tiles.Nest>();
            Main.tile[x, y].active(true);
            Main.tile[x - 1, y].active(true);
            Main.tile[x + 1, y].active(true);
            WorldGen.PlaceTile(x, y - 1, (ushort)ModContent.TileType<Tiles.WaspLarva>());

            //WorldGen.Place3x3(x - 1, y - 4, (ushort)ModContent.TileType<Tiles.WaspLarva>());


            int xoff1 = (int)(x + 16 * (float)Math.Cos(1 * 60 * Math.PI / 180f));
            int yoff1 = (int)(y + 16 * (float)Math.Sin(1 * 60 * Math.PI / 180f));
            MakeCell(xoff1, yoff1);

            int xoff2 = (int)(x + 15 * (float)Math.Cos(2 * 60 * Math.PI / 180f));
            int yoff2 = (int)(y + 15 * (float)Math.Sin(2 * 60 * Math.PI / 180f));
            MakeCell(xoff2, yoff2);

            int xoff3 = (int)(x + 15 * (float)Math.Cos(4 * 60 * Math.PI / 180f));
            int yoff3 = (int)(y + 15 * (float)Math.Sin(4 * 60 * Math.PI / 180f));
            Vector2 cellthing = MakeCell(xoff3, yoff3);

            if (WorldGen.genRand.Next(3) == 0)
            {
                //int xoff4 = (int)(cellthing.X + 15 * (float)Math.Cos(5 * 60 * Math.PI / 180f));
                //int yoff4 = (int)(cellthing.Y + 15 * (float)Math.Sin(5 * 60 * Math.PI / 180f));
                MakeCell(xoff2 - 18, yoff2);
            }
        }
    }
}
