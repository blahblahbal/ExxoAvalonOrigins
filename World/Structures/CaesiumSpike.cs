using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.World.Structures
{
    class CaesiumSpike
    {
        public static void CreateSpike(int x, int y)
        {
            int xStep = 2;
            int yStep = 7;

            while (xStep < 3)
            {
                for (int i = x - xStep + 1; i < x + xStep + 1; i++)
                {
                    for (int j = y - yStep + 1; j < y + yStep + 1; j++)
                    {
                        Main.tile[i, j].type = (ushort)ModContent.TileType<Tiles.CaesiumOre>();
                        Main.tile[i, j].active(true);
                    }
                    yStep += WorldGen.genRand.Next(1, 3);
                }
                xStep += WorldGen.genRand.Next(1, 3);
            }
            x += xStep - 2;
            if (WorldGen.genRand.Next(2) == 0)
            {
                y += WorldGen.genRand.Next(10, 15);
            }
            else y -= WorldGen.genRand.Next(10, 15);
            int xStep2 = 2;
            int yStep2 = 7;
            while (xStep2 < 3)
            {
                for (int i = x + xStep2 + 1; i > x - xStep2 + 1; i--)
                {
                    for (int j = y + yStep2 + 1; j > y - yStep2 + 1; j--)
                    {
                        Main.tile[i, j].type = (ushort)ModContent.TileType<Tiles.CaesiumOre>();
                        Main.tile[i, j].active(true);
                    }
                    yStep2 += WorldGen.genRand.Next(1, 3);
                }
                xStep2 += WorldGen.genRand.Next(1, 3);
            }
        }
    }
}
