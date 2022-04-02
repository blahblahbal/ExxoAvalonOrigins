using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.IO;

namespace ExxoAvalonOrigins.World.Passes;

class OreGenPreHardMode
{
    public static void Method(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = Lang.gen[16].Value;
        // prehardmode ores
        for (int num559 = 0; num559 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); num559++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)WorldGen.worldSurfaceHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), WorldGen.SavedOreTiers.Copper);
        }
        for (int num560 = 0; num560 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num560++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), WorldGen.SavedOreTiers.Copper);
        }
        for (int num561 = 0; num561 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num561++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SavedOreTiers.Copper);
        }
        for (int num562 = 0; num562 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); num562++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)WorldGen.worldSurfaceHigh), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), WorldGen.SavedOreTiers.Iron);
        }
        for (int num563 = 0; num563 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num563++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), WorldGen.SavedOreTiers.Iron);
        }
        for (int num564 = 0; num564 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num564++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SavedOreTiers.Iron);
        }
        for (int num565 = 0; num565 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05); num565++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), WorldGen.SavedOreTiers.Silver);
        }
        for (int num566 = 0; num566 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00015); num566++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SavedOreTiers.Silver);
        }
        for (int num567 = 0; num567 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00017); num567++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SavedOreTiers.Silver);
        }
        for (int num568 = 0; num568 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num568++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), WorldGen.SavedOreTiers.Gold);
        }
        for (int num569 = 0; num569 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num569++)
        {
            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow - 20), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), WorldGen.SavedOreTiers.Gold);
        }
        // Evil ores
        if (WorldGen.crimson)
        {
            for (int num570 = 0; num570 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num570++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), TileID.Crimtane);
            }
        }
        else if (ExxoAvalonOriginsWorld.contagion)
        {
            for (int num571 = 0; num571 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num571++)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), (ushort)ModContent.TileType<Tiles.Ores.BacciliteOre>());
            }
        }
        else if (!ExxoAvalonOriginsWorld.contagion && !WorldGen.crimson)
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
        #region motherloads
        if (WorldGen.genRand.Next(3) == 0)
        {
            // heartstone
            int i6 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            double stuff;
            stuff = Main.rockLayer - 75f;
            int j6 = WorldGen.genRand.Next((int)stuff, Main.maxTilesY - 200);
            WorldGen.OreRunner(i6, j6, (double)WorldGen.genRand.Next(20, 29), WorldGen.genRand.Next(20, 29), (ushort)ModContent.TileType<Tiles.Ores.Heartstone>());
        }
        for (int asdfasdf = 0; asdfasdf < 2; asdfasdf++)
        {
            // copper
            int i6 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            double stuff;
            stuff = Main.rockLayer - 75f;
            int j6 = WorldGen.genRand.Next((int)stuff, Main.maxTilesY - 200);
            WorldGen.OreRunner(i6, j6, (double)WorldGen.genRand.Next(20, 30), WorldGen.genRand.Next(23, 33), (ushort)WorldGen.SavedOreTiers.Copper);

            // iron
            int i3 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            int j3 = WorldGen.genRand.Next((int)stuff, Main.maxTilesY - 200);
            WorldGen.OreRunner(i3, j3, (double)WorldGen.genRand.Next(20, 30), WorldGen.genRand.Next(23, 33), (ushort)WorldGen.SavedOreTiers.Iron);

            // silver
            int i4 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            int j4 = WorldGen.genRand.Next((int)stuff, Main.maxTilesY - 200);
            WorldGen.OreRunner(i4, j4, (double)WorldGen.genRand.Next(20, 30), WorldGen.genRand.Next(23, 33), (ushort)WorldGen.SavedOreTiers.Silver);

            // gold
            int i5 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            int j5 = WorldGen.genRand.Next((int)stuff, Main.maxTilesY - 200);
            WorldGen.OreRunner(i5, j5, (double)WorldGen.genRand.Next(20, 30), WorldGen.genRand.Next(23, 33), (ushort)WorldGen.SavedOreTiers.Gold);
            // rhodium/osmium
            int i7 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            int j7 = WorldGen.genRand.Next((int)stuff, Main.maxTilesY - 200);
            WorldGen.OreRunner(i7, j7, (double)WorldGen.genRand.Next(20, 30), WorldGen.genRand.Next(23, 33), (ushort)ExxoAvalonOriginsWorld.rhodiumOre.GetTile());
        }
        #endregion motherloads
        for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)
        {
            var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
            var rockLayer = Main.rockLayer;
            var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);
            GenerateHearts(i8, j8, ModContent.TileType<Tiles.Ores.Heartstone>());
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
        int size = WorldGen.genRand.Next(2);
        if (WorldGen.genRand.Next(20) == 0) size = 2;
        if (size == 0)
        {
            //Main.tile[x + 3, y].active(true);
            WorldGen.PlaceTile(x + 3, y, type);
            for (int i = x + 2; i <= x + 4; i++)
            {
                //Main.tile[i, y + 1].active(true);
                WorldGen.PlaceTile(i, y + 1, type);
            }
            for (int i = x; i <= x + 6; i++)
            {
                //Main.tile[i, y + 2].active(true);
                WorldGen.PlaceTile(i, y + 2, type);
            }
            for (int i = x + 1; i <= x + 5; i++)
            {
                //Main.tile[i, y + 3].active(true);
                WorldGen.PlaceTile(i, y + 3, type);
            }
            for (int i = x + 2; i <= x + 4; i++)
            {
                WorldGen.PlaceTile(i, y + 4, type);
            }
            for (int i = x + 1; i <= x + 5; i++)
            {
                if (i != x + 3)
                {
                    WorldGen.PlaceTile(i, y + 5, type);
                }
            }
        }
        else if (size == 1)
        {
            for (int j = y; j <= y + 1; j++)
            {
                //Main.tile[x + 4, j].active(true);
                WorldGen.PlaceTile(x + 4, j, type);
            }
            for (int i = x + 3; i <= x + 5; i++)
            {
                //Main.tile[i, y + 2].active(true);
                WorldGen.PlaceTile(i, y + 2, type);
            }
            for (int i = x; i <= x + 8; i++)
            {
                //Main.tile[i, y + 3].active(true);
                WorldGen.PlaceTile(i, y + 3, type);
            }
            for (int i = x + 1; i <= x + 7; i++)
            {
                WorldGen.PlaceTile(i, y + 4, type);
            }
            for (int i = x + 2; i <= x + 6; i++)
            {
                for (int j = y + 5; j <= y + 6; j++)
                {
                    WorldGen.PlaceTile(i, j, type);
                }
            }
            for (int i = x + 1; i <= x + 7; i++)
            {
                if (i != x + 4)
                {
                    WorldGen.PlaceTile(i, y + 7, type);
                }
            }
            for (int i = x + 1; i <= x + 7; i++)
            {
                if (i <= x + 2 || i >= x + 6)
                {
                    WorldGen.PlaceTile(i, y + 7, type);
                }
            }
        }
        else if (size == 2)
        {
            for (int j = y; j <= y + 1; j++)
            {
                WorldGen.PlaceTile(x + 5, j, type);
                WorldGen.SquareTileFrame(x + 5, j);
            }
            for (int i = x + 4; i <= x + 6; i++)
            {
                WorldGen.PlaceTile(i, y + 2, type);
                WorldGen.SquareTileFrame(i, y + 2);
            }
            for (int i = x + 3; i <= x + 7; i++)
            {
                WorldGen.PlaceTile(i, y + 3, type);
                WorldGen.SquareTileFrame(i, y + 3);
            }
            for (int i = x; i <= x + 10; i++)
            {
                WorldGen.PlaceTile(i, y + 4, type);
                WorldGen.SquareTileFrame(i, y + 4);
            }
            for (int i = x + 1; i <= x + 9; i++)
            {
                WorldGen.PlaceTile(i, y + 5, type);
                WorldGen.SquareTileFrame(i, y + 5);
            }
            for (int i = x + 2; i <= x + 8; i++)
            {
                WorldGen.PlaceTile(i, y + 6, type);
                WorldGen.SquareTileFrame(i, y + 6);
            }
            for (int i = x + 3; i <= x + 7; i++)
            {
                WorldGen.PlaceTile(i, y + 7, type);
                WorldGen.SquareTileFrame(i, y + 7);
            }
            for (int i = x + 2; i <= x + 8; i++)
            {
                WorldGen.PlaceTile(i, y + 8, type);
                WorldGen.SquareTileFrame(i, y + 8);
            }
            for (int i = x + 1; i <= x + 9; i++)
            {
                for (int j = y + 9; j <= y + 10; j++)
                {
                    if (((i >= x + 2 && i <= x + 4) || (i >= x + 6 && i <= x + 8)) && j == y + 9)
                    {
                        WorldGen.PlaceTile(i, j, type);
                        WorldGen.SquareTileFrame(i, j);
                    }
                    if (((i >= x + 1 && i <= x + 3) || (i >= x + 7 && i <= x + 9)) && j == y + 10)
                    {
                        WorldGen.PlaceTile(i, j, type);
                        WorldGen.SquareTileFrame(i, j);
                    }
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
        WorldGen.PlaceTile(i, j + 1, (ushort)tile);
        WorldGen.SquareTileFrame(i, j + 1);
        for (var k = j; k >= j - size; k--)
        {
            for (var l = i - num2; l <= i + num2; l++)
            {
                if ((l != i - num2 && l != i + num2) || num2 != size + 1)
                {
                    WorldGen.PlaceTile(l, k, (ushort)tile);
                    WorldGen.SquareTileFrame(l, k);
                }
            }
            num2++;
        }
        for (var m = i - num2 + 1; m <= i + num2 - 1; m++)
        {
            WorldGen.PlaceTile(m, j - size - 1, (ushort)tile);
            WorldGen.SquareTileFrame(m, j + size + 1);
        }
        for (var n = i - num2 + 2; n <= i + num2 - 2; n++)
        {
            if (n != i)
            {
                WorldGen.PlaceTile(n, j - size - 2, (ushort)tile);
                WorldGen.SquareTileFrame(n, j + size + 2);
            }
        }
        for (var num3 = i - num2 + 3; num3 <= i + num2 - 3; num3++)
        {
            if (num3 != i && num3 != i + 1 && num3 != i - 1)
            {
                WorldGen.PlaceTile(num3, j - size - 3, (ushort)tile);
                WorldGen.SquareTileFrame(num3, j + size + 3);
            }
        }
    }
    public static void GenerateBolts(int x, int y, ushort type)
    {
        int size = WorldGen.genRand.Next(2);
        if (WorldGen.genRand.Next(20) == 0) size = 2;
        if (size == 0)
        {
            for (int i = x + 1; i <= x + 4; i++)
            {
                for (int j = y; j <= y + 1; j++)
                {
                    WorldGen.PlaceTile(i, j, type);
                }
            }
            for (int i = x; i <= x + 3; i++)
            {
                WorldGen.PlaceTile(i, y + 2, type);
            }
            for (int i = x; i <= x + 4; i++)
            {
                WorldGen.PlaceTile(i, y + 3, type);
            }
            for (int i = x + 1; i <= x + 3; i++)
            {
                WorldGen.PlaceTile(i, y + 4, type);
            }
            for (int i = x; i <= x + 2; i++)
            {
                WorldGen.PlaceTile(i, y + 5, type);
            }
            for (int i = x; i <= x + 1; i++)
            {
                WorldGen.PlaceTile(i, y + 6, type);
            }
        }
        else if (size == 1)
        {
            for (int i = x + 1; i <= x + 5; i++)
            {
                for (int j = y; j <= y + 1; j++)
                {
                    WorldGen.PlaceTile(i, j, type);
                }
            }
            for (int i = x; i <= x + 4; i++)
            {
                WorldGen.PlaceTile(i, y + 2, type);
            }
            for (int i = x; i <= x + 5; i++)
            {
                WorldGen.PlaceTile(i, y + 3, type);
            }
            for (int i = x + 2; i <= x + 5; i++)
            {
                WorldGen.PlaceTile(i, y + 4, type);
            }
            for (int i = x + 1; i <= x + 4; i++)
            {
                WorldGen.PlaceTile(i, y + 5, type);
            }
            for (int i = x + 1; i <= x + 3; i++)
            {
                WorldGen.PlaceTile(i, y + 6, type);
            }
            for (int i = x; i <= x + 2; i++)
            {
                WorldGen.PlaceTile(i, y + 7, type);
            }
            for (int i = x; i <= x + 1; i++)
            {
                WorldGen.PlaceTile(i, y + 8, type);
            }
        }
        else if (size == 2)
        {
            for (int i = x + 2; i <= x + 8; i++)
            {
                for (int j = y; j <= y + 1; j++)
                {
                    WorldGen.PlaceTile(i, j, type);
                }
            }
            for (int i = x + 1; i <= x + 7; i++)
            {
                for (int j = y + 2; j <= y + 3; j++)
                {
                    WorldGen.PlaceTile(i, j, type);
                }
            }
            for (int j = y + 3; j <= y + 4; j++)
            {
                WorldGen.PlaceTile(x + 8, j, type);
            }
            for (int i = x; i <= x + 7; i++)
            {
                for (int j = y + 4; j <= y + 5; j++)
                {
                    WorldGen.PlaceTile(i, j, type);
                }
            }
            for (int i = x + 2; i <= x + 6; i++)
            {
                WorldGen.PlaceTile(i, y + 6, type);
            }
            for (int i = x + 1; i <= x + 5; i++)
            {
                WorldGen.PlaceTile(i, y + 7, type);
            }
            for (int i = x + 1; i <= x + 4; i++)
            {
                WorldGen.PlaceTile(i, y + 8, type);
            }
            for (int i = x; i <= x + 3; i++)
            {
                WorldGen.PlaceTile(i, y + 9, type);
            }
            for (int i = x; i <= x + 2; i++)
            {
                WorldGen.PlaceTile(i, y + 10, type);
            }
            for (int i = x; i <= x + 1; i++)
            {
                WorldGen.PlaceTile(i, y + 11, type);
            }
        }
    }
}
