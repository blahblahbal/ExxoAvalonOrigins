using Terraria;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class JungleTrees
    {
        public static void Method(GenerationProgress progress)
        {
            for (int num272 = 0; num272 < Main.maxTilesX; num272++)
            {
                for (int num273 = (int)Main.worldSurface - 1; num273 < Main.maxTilesY - 350; num273++)
                {
                    if (WorldGen.genRand.Next(10) == 0)
                    {
                        WorldGen.GrowUndergroundTree(num272, num273);
                    }
                }
            }
        }
    }
}
