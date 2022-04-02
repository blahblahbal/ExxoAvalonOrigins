using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.IO;

namespace ExxoAvalonOrigins.World.Passes;

class SmoothWorld
{
    public static void Method(GenerationProgress progress, GameConfiguration configuration)
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
                    Tile t = Main.tile[i, j];
                    t.BlockType = Terraria.ID.BlockType.Solid;
                    t.Slope = Terraria.ID.SlopeType.Solid;
                }
            }
        }
        // unsmoothing hellcastle
    }
}
