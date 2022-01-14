using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class Gems
    {
        public static void Method(GenerationProgress progress)
        {
            for (var num284 = 69; num284 < 72; num284++)
            {
                var type8 = 0;
                float num285 = 0;
                if (num284 == 69)
                {
                    type8 = ModContent.TileType<Tiles.Ores.Tourmaline>();
                    num285 = Main.maxTilesX * 0.2f;
                }
                else if (num284 == 70)
                {
                    type8 = ModContent.TileType<Tiles.Ores.Peridot>();
                    num285 = Main.maxTilesX * 0.2f;
                }
                else if (num284 == 71)
                {
                    type8 = ModContent.TileType<Tiles.Ores.Zircon>();
                    num285 = Main.maxTilesX * 0.2f;
                }
                num285 *= 0.2f;
                var num286 = 0;
                while (num286 < num285)
                {
                    var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                    var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                    while (Main.tile[num287, num288].type != 1)
                    {
                        num287 = WorldGen.genRand.Next(0, Main.maxTilesX);
                        num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
                    }
                    WorldGen.TileRunner(num287, num288, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type8, false, 0f, 0f, false, true);
                    num286++;
                }
            }
        }
    }
}
