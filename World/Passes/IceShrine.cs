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
            for (var num721 = 0; num721 < 3; num721++)
            {
                var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);
                while (Main.tile[x10, y6].type == TileID.LihzahrdBrick ||
                    Main.tile[x10, y6].type == TileID.BlueDungeonBrick ||
                    Main.tile[x10, y6].type == TileID.PinkDungeonBrick ||
                    Main.tile[x10, y6].type == TileID.GreenDungeonBrick ||
                    Main.tile[x10, y6].type == ModContent.TileType<Tiles.TuhrtlBrick>() ||
                    Main.tile[x10, y6].type == ModContent.TileType<Tiles.OrangeBrick>())
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
