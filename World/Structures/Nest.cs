using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
                {0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0},
                {0,0,0,0,0,1,1,1,1,2,1,1,1,1,0,0,0,0,0},
                {0,0,0,1,1,1,1,2,2,2,2,2,1,1,1,1,0,0,0},
                {0,0,1,1,1,1,2,2,2,2,2,2,2,1,1,1,1,0,0},
                {1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1},
                {1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},
                {1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1},
                {1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1},
                {1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1},
                {1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1},
                {1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1},
                {1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},
                {1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1},
                {0,0,1,1,1,1,2,2,2,2,2,2,2,1,1,1,1,0,0},
                {0,0,0,1,1,1,1,2,2,2,2,2,1,1,1,1,0,0,0},
                {0,0,0,0,0,1,1,1,1,2,1,1,1,1,0,0,0,0,0},
                {0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0}
            };
            int PosX = x;  //spawnX and spawnY is where you want the anchor to be when this generates
            int PosY = y;

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
                                    tile.type = (ushort)ModContent.TileType<Tiles.Nest>();
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    //tile.wall = (ushort)ModContent.WallType<Walls.NestWall>();
                                    break;
                                case 2:
                                    if (confirmPlatforms == 0)
                                    {
                                        tile.active(false);
                                        tile.halfBrick(false);
                                        tile.slope(0);
                                        tile.wall = (ushort)ModContent.WallType<Walls.NestWall>();
                                    }
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
            MakeCell(x, y);

            int rightSide = WorldGen.genRand.Next(3);
            int leftSide = WorldGen.genRand.Next(3);

            //int radius = 15;

            if (rightSide == 0)
            {
                Vector2 rSideM = MakeCell(x + 18, y);

                int xOffR = (int)(rSideM.X + 19 * (float)Math.Cos(2 * 60 * Math.PI / 180f));
                int yOffR = (int)(rSideM.Y + 19 * (float)Math.Sin(2 * 60 * Math.PI / 180f));

                MakeCell(xOffR, yOffR);
            }

            if (leftSide == 0)
            {
                Vector2 lSideM = MakeCell(x - 18, y);
                int xOffL = (int)(lSideM.X + 19 * (float)Math.Cos(1 * 60 * Math.PI / 180f));
                int yOffL = (int)(lSideM.Y + 19 * (float)Math.Sin(1 * 60 * Math.PI / 180f));

                MakeCell(xOffL, yOffL);
            }
            
            
            
            int xoff1 = (int)(x + 16 * (float)Math.Cos(1 * 60 * Math.PI / 180f));
            int yoff1 = (int)(y + 16 * (float)Math.Sin(1 * 60 * Math.PI / 180f));
            MakeCell(xoff1, yoff1);

            int xoff2 = (int)(x + 15 * (float)Math.Cos(2 * 60 * Math.PI / 180f));
            int yoff2 = (int)(y + 15 * (float)Math.Sin(2 * 60 * Math.PI / 180f));
            MakeCell(xoff2, yoff2);
        }
    }
}
