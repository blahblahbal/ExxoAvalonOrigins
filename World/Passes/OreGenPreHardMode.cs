using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class OreGenPreHardMode
    {
        public static void Method(GenerationProgress progress)
        {
            progress.Message = Lang.gen[16].Value;
            // prehardmode ores
            for (int num559 = 0; num559 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); num559++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)WorldGen.worldSurfaceHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), WorldGen.CopperTierOre);
            }
            for (int num560 = 0; num560 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num560++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), WorldGen.CopperTierOre);
            }
            for (int num561 = 0; num561 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num561++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.CopperTierOre);
            }
            for (int num562 = 0; num562 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); num562++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)WorldGen.worldSurfaceHigh), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), WorldGen.IronTierOre);
            }
            for (int num563 = 0; num563 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num563++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), WorldGen.IronTierOre);
            }
            for (int num564 = 0; num564 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num564++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.IronTierOre);
            }
            for (int num565 = 0; num565 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05); num565++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), WorldGen.SilverTierOre);
            }
            for (int num566 = 0; num566 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00015); num566++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SilverTierOre);
            }
            for (int num567 = 0; num567 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00017); num567++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SilverTierOre);
            }
            for (int num568 = 0; num568 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num568++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), WorldGen.GoldTierOre);
            }
            for (int num569 = 0; num569 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num569++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow - 20), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), WorldGen.GoldTierOre);
            }
            // Evil ores
            if (WorldGen.crimson)
            {
                for (int num570 = 0; num570 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num570++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), TileID.Crimtane);
                }
            }
            else if (ExxoAvalonOriginsWorld.contaigon)
            {
                for (int num571 = 0; num571 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num571++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), (ushort)ModContent.TileType<Tiles.BacciliteOre>());
                }
            }
            else if (!ExxoAvalonOriginsWorld.contaigon && !WorldGen.crimson)
            {
                for (int num571 = 0; num571 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num571++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), TileID.Demonite);
                }
            }

            for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); i++)
            {
                WorldGen.TileRunner(
                    WorldGen.genRand.Next(100, Main.maxTilesX - 100), // Xcoord of tile
                    WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 150), // Ycoord of tile
                    WorldGen.genRand.Next(4, 5), // Quantity
                    WorldGen.genRand.Next(5, 7),
                    ExxoAvalonOriginsWorld.rhodiumOre.GetTile(), //Tile to spawn
                    false, 0f, 0f, false, true); //last input overrides existing tiles
            }
            for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)
            {
                var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                var rockLayer = Main.rockLayer;
                var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);
                GenerateHearts(i8, j8, ModContent.TileType<Tiles.Heartstone>());
            }

            for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 1E-05); i++)
            {
                var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                var rockLayer = Main.rockLayer;
                var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);
                GenerateStars(i8, j8, (ushort)ModContent.TileType<Tiles.Ores.Starstone>());
            }
            for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 7E-06); i++)
            {
                var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                var rockLayer = Main.rockLayer + 50;
                var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);
                GenerateBolts(i8, j8, (ushort)ModContent.TileType<Tiles.Ores.Boltstone>());
            }
        }
        public static void GenerateStars(int x, int y, ushort type)
        {
            for (int j = y; j <= y + 1; j++)
            {
                Main.tile[x + 7, j].active(true);
                Main.tile[x + 7, j].type = type;
                WorldGen.SquareTileFrame(x + 7, j);
            }
            for (int i = x + 6; i <= x + 8; i++)
            {
                for (int j = y + 2; j <= y + 4; j++)
                {
                    Main.tile[i, j].active(true);
                    Main.tile[i, j].type = type;
                    WorldGen.SquareTileFrame(i, j);
                }
            }
            for (int i = x + 5; i <= x + 9; i++)
            {
                Main.tile[i, y + 4].active(true);
                Main.tile[i, y + 4].type = type;
                WorldGen.SquareTileFrame(i, y + 4);
            }
            for (int i = x; i <= x + 14; i++)
            {
                Main.tile[i, y + 5].active(true);
                Main.tile[i, y + 5].type = type;
                WorldGen.SquareTileFrame(i, y + 5);
            }
            for (int i = x + 1; i <= x + 13; i++)
            {
                Main.tile[i, y + 6].active(true);
                Main.tile[i, y + 6].type = type;
                WorldGen.SquareTileFrame(i, y + 6);
            }
            for (int i = x + 3; i <= x + 11; i++)
            {
                Main.tile[i, y + 7].active(true);
                Main.tile[i, y + 7].type = type;
                WorldGen.SquareTileFrame(i, y + 7);
            }
            for (int i = x + 4; i <= x + 10; i++)
            {
                for (int j = y + 8; j <= y + 9; j++)
                {
                    Main.tile[i, j].active(true);
                    Main.tile[i, j].type = type;
                    WorldGen.SquareTileFrame(i, j);
                }
            }
            for (int i = x + 2; i <= x + 12; i++)
            {
                for (int j = y + 10; j <= y + 13; j++)
                {
                    if (((i >= x + 4 && i <= x + 6) || (i >= x + 8 && i <= x + 10)) && j == y + 10)
                    {
                        Main.tile[i, j].active(true);
                        Main.tile[i, j].type = type;
                        WorldGen.SquareTileFrame(i, j);
                    }
                    if (((i >= x + 3 && i <= x + 5) || (i >= x + 9 && i <= x + 11)) && j == y + 11)
                    {
                        Main.tile[i, j].active(true);
                        Main.tile[i, j].type = type;
                        WorldGen.SquareTileFrame(i, j);
                    }
                    if (((i >= x + 3 && i <= x + 4) || (i >= x + 10 && i <= x + 11)) && j == y + 12)
                    {
                        Main.tile[i, j].active(true);
                        Main.tile[i, j].type = type;
                        WorldGen.SquareTileFrame(i, j);
                    }
                    if (((i >= x + 2 && i <= x + 3) || (i >= x + 11 && i <= x + 12)) && j == y + 13)
                    {
                        Main.tile[i, j].active(true);
                        Main.tile[i, j].type = type;
                        WorldGen.SquareTileFrame(i, j);
                    }
                }
            }
        }
        public static void GenerateHearts(int i, int j, int tile)
        {
            var size = WorldGen.genRand.Next(2);
            if (size == 0)
            {
                size = 1;
            }
            else if (size == 1)
            {
                size = 3;
            }
            if (WorldGen.genRand.Next(20) == 0)
            {
                size = 5;
            }
            var num2 = 1;
            Main.tile[i, j + 1].active(true);
            Main.tile[i, j + 1].type = (ushort)tile;
            WorldGen.SquareTileFrame(i, j + 1);
            for (var k = j; k >= j - size; k--)
            {
                for (var l = i - num2; l <= i + num2; l++)
                {
                    if ((l != i - num2 && l != i + num2) || num2 != size + 1)
                    {
                        Main.tile[l, k].active(true);
                        Main.tile[l, k].type = (ushort)tile;
                        WorldGen.SquareTileFrame(l, k);
                    }
                }
                num2++;
            }
            for (var m = i - num2 + 1; m <= i + num2 - 1; m++)
            {
                Main.tile[m, j - size - 1].active(true);
                Main.tile[m, j - size - 1].type = (ushort)tile;
                WorldGen.SquareTileFrame(m, j + size + 1);
            }
            for (var n = i - num2 + 2; n <= i + num2 - 2; n++)
            {
                if (n != i)
                {
                    Main.tile[n, j - size - 2].active(true);
                    Main.tile[n, j - size - 2].type = (ushort)tile;
                    WorldGen.SquareTileFrame(n, j + size + 2);
                }
            }
            for (var num3 = i - num2 + 3; num3 <= i + num2 - 3; num3++)
            {
                if (num3 != i && num3 != i + 1 && num3 != i - 1)
                {
                    Main.tile[num3, j - size - 3].active(true);
                    Main.tile[num3, j - size - 3].type = (ushort)tile;
                    WorldGen.SquareTileFrame(num3, j + size + 3);
                }
            }
        }
        public static void GenerateBolts(int x, int y, ushort type)
        {
            for (int i = x + 2; i <= x + 8; i++)
            {
                for (int j = y; j <= y + 1; j++)
                {
                    Main.tile[i, j].active(true);
                    Main.tile[i, j].type = type;
                    WorldGen.SquareTileFrame(i, j);
                }
            }
            for (int i = x + 1; i <= x + 7; i++)
            {
                for (int j = y + 2; j <= y + 3; j++)
                {
                    Main.tile[i, j].active(true);
                    Main.tile[i, j].type = type;
                    WorldGen.SquareTileFrame(i, j);
                }
            }
            for (int j = y + 3; j <= y + 4; j++)
            {
                Main.tile[x + 8, j].active(true);
                Main.tile[x + 8, j].type = type;
                WorldGen.SquareTileFrame(x + 8, j);
            }
            for (int i = x; i <= x + 7; i++)
            {
                for (int j = y + 4; j <= y + 5; j++)
                {
                    Main.tile[i, j].active(true);
                    Main.tile[i, j].type = type;
                    WorldGen.SquareTileFrame(i, j);
                }
            }
            for (int i = x + 2; i <= x + 6; i++)
            {
                Main.tile[i, y + 6].active(true);
                Main.tile[i, y + 6].type = type;
                WorldGen.SquareTileFrame(i, y + 6);
            }
            for (int i = x + 1; i <= x + 5; i++)
            {
                Main.tile[i, y + 7].active(true);
                Main.tile[i, y + 7].type = type;
                WorldGen.SquareTileFrame(i, y + 7);
            }
            for (int i = x + 1; i <= x + 4; i++)
            {
                Main.tile[i, y + 8].active(true);
                Main.tile[i, y + 8].type = type;
                WorldGen.SquareTileFrame(i, y + 8);
            }
            for (int i = x; i <= x + 3; i++)
            {
                Main.tile[i, y + 9].active(true);
                Main.tile[i, y + 9].type = type;
                WorldGen.SquareTileFrame(i, y + 9);
            }
            for (int i = x; i <= x + 2; i++)
            {
                Main.tile[i, y + 10].active(true);
                Main.tile[i, y + 10].type = type;
                WorldGen.SquareTileFrame(i, y + 10);
            }
            for (int i = x; i <= x + 1; i++)
            {
                Main.tile[i, y + 11].active(true);
                Main.tile[i, y + 11].type = type;
                WorldGen.SquareTileFrame(i, y + 11);
            }
        }
    }
}
