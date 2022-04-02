using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ExxoAvalonOrigins.World.Passes;

public class TropicsSanctum
{
    public static void Method(GenerationProgress progress)
    {
        progress.Message = "Adding tropics chests...";
        int amount = WorldGen.genRand.Next(11, 19);
        //bool flag30 = true;
        while (amount > 0)
        {
            int num406 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 250);
            int num407 = ((ExxoAvalonOriginsWorld.dungeonSide >= 0) ? WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.4)) : WorldGen.genRand.Next((int)(Main.maxTilesX * 0.6), (int)(Main.maxTilesX * 0.85)));
            if (Main.tile[num407, num406].HasTile && Main.tile[num407, num406].TileType == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
            {
                //flag30 = false;
                Structures.TropicsSanctum.MakeSanctum(num407, num406);
                amount--;
            }
        }
    }
}