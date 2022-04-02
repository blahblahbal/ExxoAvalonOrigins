using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.IO;

namespace ExxoAvalonOrigins.World.Passes;

class Altars
{
    public static void Method(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = Language.GetTextValue("LegacyWorldGen.26");
        int num = (int)(Main.maxTilesX * Main.maxTilesY * 1.99999994947575E-05);
        for (int index1 = 0; index1 < num; ++index1)
        {
            progress.Set(index1 / (float)num);
            for (int index2 = 0; index2 < 10000; ++index2)
            {
                int x = WorldGen.genRand.Next(1, Main.maxTilesX - 3);
                int y = (int)(WorldGen.worldSurfaceHigh + 20.0);
                WorldGen.Place3x2(x, y, ModContent.GetInstance<Tiles.IckyAltar>().Type);
                if (Main.tile[x, y].TileType == ModContent.GetInstance<Tiles.IckyAltar>().Type)
                    break;
            }
        }
    }
}
