using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.World.Structures
{
    public class TropicsSanctum
    {
        public static void MakeSanctum2(int x, int y)
        {
            ushort t = (ushort)WorldGen.genRand.Next(3);
            if (t == 0) t = TileID.IridescentBrick;
            else if (t == 1) t = (ushort)ModContent.TileType<Tiles.BismuthBrick>();
            else if (t == 2) t = (ushort)ModContent.TileType<Tiles.Loamstone>();


        }

        public static void MakeSanctum(int x, int y)
        {
            int[,] _structure = {
                {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
                {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0},
                {0,1,1,1,1,2,2,2,2,2,2,2,2,2,2,1,1,1,1,0},
                {1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1},
                {1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},
                {1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},
                {1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1},
                {1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1},
                {0,2,2,4,2,2,3,2,2,2,5,2,2,3,2,2,4,2,2,0},
                {0,2,2,2,2,1,1,1,1,1,1,1,1,1,1,2,2,2,2,0},
                {0,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,0},
                {0,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };
            int PosX = x;   //spawnX and spawnY is where you want the anchor to be when this generates
            int PosY = y;
            ushort t = (ushort)WorldGen.genRand.Next(3);
            if (t == 0) t = TileID.IridescentBrick;
            else if (t == 1) t = (ushort)ModContent.TileType<Tiles.BismuthBrick>();
            else if (t == 2) t = (ushort)ModContent.TileType<Tiles.Loamstone>();
            //i = vertical, j = horizontal
            for (int confirmPlatforms = 0; confirmPlatforms < 2; confirmPlatforms++)    //Increase the iterations on this outermost for loop if tabletop-objects are not properly spawning
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
                            //if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>() || tile.wall != (ushort)ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>()) continue;
                            switch (_structure[i, j])
                            {
                                case 0:
                                    break;
                                case 1:
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.active(true);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.type = t;
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.slope(0);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.halfBrick(false);
                                    break;
                                case 2:
                                    if (confirmPlatforms == 0)
                                    {
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.active(false);
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.halfBrick(false);
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.slope(0);
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.wall = (ushort)ModContent.WallType<Walls.TropicalGrassWall>();
                                    }
                                    break;
                                case 3:
                                    if (confirmPlatforms == 1)
                                    {
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.active(false);
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.slope(0);
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.halfBrick(false);
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) WorldGen.PlaceTile(k, l, 93, true, true, -1, 0);
                                        if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.wall = (ushort)ModContent.WallType<Walls.TropicalGrassWall>();
                                    }
                                    break;
                                case 4:
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.wall = (ushort)ModContent.WallType<Walls.TropicalGrassWall>();
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.active(true);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.type = 4;
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.slope(0);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.halfBrick(false);
                                    break;
                                case 5:
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.active(false);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.slope(0);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.halfBrick(false);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) WorldGen.AddBuriedChest(k, l, contain: WorldGen.GetNextJungleChestItem(), Style: 10);
                                    if (tile.type != (ushort)ModContent.TileType<Tiles.TuhrtlBrick>()) tile.wall = (ushort)ModContent.WallType<Walls.TropicalGrassWall>();
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
