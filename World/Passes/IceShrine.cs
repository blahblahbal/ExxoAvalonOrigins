using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class IceShrine
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
                TileID.JungleGrass
            };
            for (var num721 = 0; num721 < 3; num721++)
            {
                var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);
                while (noTiles.Contains(Main.tile[x10, y6].type))
                {
                    if (x10 > (Main.maxTilesY / 2))
                        x10--;
                    else
                        x10++;

                }
                while (noTiles.Contains(Main.tile[x10 + 30, y6].type))
                {
                    if (x10 > (Main.maxTilesY / 2))
                        x10--;
                    else
                        x10++;
                }
                while (noTiles.Contains(Main.tile[x10, y6 + 20].type))
                {
                    if (x10 > (Main.maxTilesY / 2))
                        x10--;
                    else
                        x10++;
                }
                while (noTiles.Contains(Main.tile[x10 + 30, y6 + 20].type))
                {
                    if (x10 > (Main.maxTilesY / 2))
                        x10--;
                    else
                        x10++;
                }
                Structures.IceShrine.Generate(x10, y6);
            }
        }

    }
}
