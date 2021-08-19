using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class LavaShrine
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
                TileID.IceBrick,
                TileID.JungleGrass
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
            };
            var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
            var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);
            while (noTiles.Contains(Main.tile[x10, y6].type) || noWalls.Contains(Main.tile[x10, y6].wall))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;

            }
            while (noTiles.Contains(Main.tile[x10 + 30, y6].type) || noWalls.Contains(Main.tile[x10 + 30, y6].wall))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;
            }
            while (noTiles.Contains(Main.tile[x10, y6 + 20].type) || noWalls.Contains(Main.tile[x10, y6 + 20].wall))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;
            }
            while (noTiles.Contains(Main.tile[x10 + 30, y6 + 20].type) || noWalls.Contains(Main.tile[x10 + 30, y6 + 20].wall))
            {
                if (x10 > (Main.maxTilesY / 2))
                    x10--;
                else
                    x10++;
            }
            Structures.LavaShrine.AddLavaShrine(x10, y6);
        }
    }
}
