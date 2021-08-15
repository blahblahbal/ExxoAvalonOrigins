using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class WetJungle
    {
        public static void Method(GenerationProgress progress)
        {
            int i2;
            for (int num411 = 0; num411 < Main.maxTilesX; num411++)
            {
                i2 = num411;
                for (int num412 = (int)WorldGen.worldSurfaceLow; (double)num412 < Main.worldSurface - 1.0; num412++)
                {
                    if (Main.tile[i2, num412].active())
                    {
                        if (Main.tile[i2, num412].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
                        {
                            Main.tile[i2, num412 - 1].liquid = byte.MaxValue;
                            Main.tile[i2, num412 - 2].liquid = byte.MaxValue;
                        }
                        break;
                    }
                }
            }
        }
    }
}
