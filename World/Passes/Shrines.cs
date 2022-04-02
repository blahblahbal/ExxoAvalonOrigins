using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ExxoAvalonOrigins.World.Passes;

class Shrines
{
    public static void Method(GenerationProgress progress)
    {
        List<int> noTiles = new List<int>()
        {
            TileID.LihzahrdBrick,
            TileID.BlueDungeonBrick,
            TileID.PinkDungeonBrick,
            TileID.GreenDungeonBrick,
            ModContent.TileType<Tiles.TuhrtlBrick>(),
            ModContent.TileType<Tiles.OrangeBrick>(),
            ModContent.TileType<Tiles.TropicalGrass>(),
            ModContent.TileType<Tiles.TropicalMud>(),
            TileID.Mud,
            TileID.JungleGrass,
            TileID.CrimtaneBrick,
            TileID.DemoniteBrick,
            TileID.EbonstoneBrick
        };
        List<int> noWalls = new List<int>()
        {
            WallID.LihzahrdBrickUnsafe,
            WallID.BlueDungeonSlabUnsafe,
            WallID.BlueDungeonUnsafe,
            WallID.BlueDungeonTileUnsafe,
            WallID.PinkDungeonSlabUnsafe,
            WallID.PinkDungeonUnsafe,
            WallID.PinkDungeonTileUnsafe,
            WallID.GreenDungeonSlabUnsafe,
            WallID.GreenDungeonUnsafe,
            WallID.GreenDungeonTileUnsafe,
            ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>(),
            ModContent.WallType<Walls.OrangeBrickUnsafe>(),
            ModContent.WallType<Walls.OrangeTiledUnsafe>(),
            ModContent.WallType<Walls.OrangeSlabUnsafe>(),
            WallID.IceBrick,
            ModContent.WallType<Walls.ObsidianLavaTube>()
        };
        for (int q = 0; q < 4; q++)
        {
            var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
            var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);
            if (q == 2) y6 = WorldGen.genRand.Next(WorldGen.lavaLine, Main.maxTilesY - 250);
            while (noTiles.Contains(Main.tile[x10, y6].TileType) || noWalls.Contains(Main.tile[x10, y6].WallType))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;

            }
            while (noTiles.Contains(Main.tile[x10 + 30, y6].TileType) || noWalls.Contains(Main.tile[x10 + 30, y6].WallType))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;
            }
            while (noTiles.Contains(Main.tile[x10, y6 + 20].TileType) || noWalls.Contains(Main.tile[x10, y6 + 20].WallType))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;
            }
            while (noTiles.Contains(Main.tile[x10 + 30, y6 + 20].TileType) || noWalls.Contains(Main.tile[x10 + 30, y6 + 20].WallType))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;
            }
            if (q == 0) Structures.IceShrine.Generate(x10, y6);
            else if (q == 1) Structures.EvilShrine.GenerateEvilShrine(x10, y6);
            else if (q == 2) Structures.LavaShrine.AddLavaShrine(x10, y6);
            else if (q == 3) Structures.ObserverTemple.MakeObserverTemple(x10, y6);
        }
    }
}