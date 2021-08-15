using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class JungleMudWalls
    {
        public static void Method(GenerationProgress progress)
        {
            int num88 = 0;
            int num89 = 0;
            bool flag2 = false;
            for (int num90 = 5; num90 < Main.maxTilesX - 5; num90++)
            {
                for (int num91 = 0; (double)num91 < Main.worldSurface + 20.0; num91++)
                {
                    if (Main.tile[num90, num91].active() && Main.tile[num90, num91].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
                    {
                        num88 = num90;
                        flag2 = true;
                        break;
                    }
                }
                if (flag2)
                {
                    break;
                }
            }
            flag2 = false;
            for (int num92 = Main.maxTilesX - 5; num92 > 5; num92--)
            {
                for (int num93 = 0; (double)num93 < Main.worldSurface + 20.0; num93++)
                {
                    if (Main.tile[num92, num93].active() && Main.tile[num92, num93].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
                    {
                        num89 = num92;
                        flag2 = true;
                        break;
                    }
                }
                if (flag2)
                {
                    break;
                }
            }
            for (int num94 = num88; num94 <= num89; num94++)
            {
                for (int num95 = 0; (double)num95 < Main.worldSurface + 20.0; num95++)
                {
                    if (((num94 >= num88 + 2 && num94 <= num89 - 2) || WorldGen.genRand.Next(2) != 0) && ((num94 >= num88 + 3 && num94 <= num89 - 3) || WorldGen.genRand.Next(3) != 0) && (Main.tile[num94, num95].wall == 2 || Main.tile[num94, num95].wall == 59))
                    {
                        Main.tile[num94, num95].wall = (ushort)ModContent.WallType<Walls.TropicalMudWall>();
                    }
                }
            }
        }
    }
}
