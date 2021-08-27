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
        }
        public static void GenerateHearts(int i, int j, int tile)
        {
            var num = WorldGen.genRand.Next(2);
            if (num == 0)
            {
                num = 1;
            }
            else if (num == 1)
            {
                num = 3;
            }
            if (WorldGen.genRand.Next(20) == 0)
            {
                num = 5;
            }
            var num2 = 1;
            Main.tile[i, j + 1].active(true);
            Main.tile[i, j + 1].type = (ushort)tile;
            WorldGen.SquareTileFrame(i, j + 1);
            for (var k = j; k >= j - num; k--)
            {
                for (var l = i - num2; l <= i + num2; l++)
                {
                    if ((l != i - num2 && l != i + num2) || num2 != num + 1)
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
                Main.tile[m, j - num - 1].active(true);
                Main.tile[m, j - num - 1].type = (ushort)tile;
                WorldGen.SquareTileFrame(m, j + num + 1);
            }
            for (var n = i - num2 + 2; n <= i + num2 - 2; n++)
            {
                if (n != i)
                {
                    Main.tile[n, j - num - 2].active(true);
                    Main.tile[n, j - num - 2].type = (ushort)tile;
                    WorldGen.SquareTileFrame(n, j + num + 2);
                }
            }
            for (var num3 = i - num2 + 3; num3 <= i + num2 - 3; num3++)
            {
                if (num3 != i && num3 != i + 1 && num3 != i - 1)
                {
                    Main.tile[num3, j - num - 3].active(true);
                    Main.tile[num3, j - num - 3].type = (ushort)tile;
                    WorldGen.SquareTileFrame(num3, j + num + 3);
                }
            }
        }
    }
}
