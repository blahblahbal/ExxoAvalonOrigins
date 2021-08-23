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
            int xStep = 3;
            int yStep = 1;

            while (xStep < 5)
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
                xStep += WorldGen.genRand.Next(2, 5);
            }
            x += xStep - 2;
            if (WorldGen.genRand.Next(2) == 0)
            {
                y += WorldGen.genRand.Next(6, 9);
            }
            else y -= WorldGen.genRand.Next(6, 9);
            int xStep2 = 3;
            int yStep2 = 1;
            while (xStep2 < 5)
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
                xStep2 += WorldGen.genRand.Next(2, 5);
            }
        }
    }
}
