using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ExxoAvalonOrigins.World.Passes;

class SmoothWorld
{
    public static void Method(GenerationProgress progress)
    {
        int x = Main.maxTilesX / 3 - 210;
        int y = Main.maxTilesY - 140;
        //int x = Main.maxTilesX / 2;
        //int y = 250;
        for (int i = x; i <= x + 444; i++)
        {
            for (int j = y; j <= y + 99; j++)
            {
                if (Main.tile[i, j].TileType == (ushort)ModContent.TileType<Tiles.ResistantWoodPlatform>())
                { }
                else
                {
                    Main.tile[i, j].slope(0);
                    Main.tile[i, j].halfBrick(false);
                }
            }
        }
        // unsmoothing hellcastle
    }
}