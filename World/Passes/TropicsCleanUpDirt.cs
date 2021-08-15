using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class TropicsCleanUpDirt
    {
        public static void Method(GenerationProgress progress)
        {
            progress.Message = Language.GetTextValue("LegacyWorldGen.25");

            for (int num439 = 3; num439 < Main.maxTilesX - 3; num439++)
            {
                float num440 = (float)num439 / (float)Main.maxTilesX;
                progress.Set(0.5f * num440);
                bool flag34 = true;
                for (int num441 = 0; (double)num441 < Main.worldSurface; num441++)
                {
                    if (flag34)
                    {
                        if (Main.tile[num439, num441].wall == 2 || Main.tile[num439, num441].wall == 40 || Main.tile[num439, num441].wall == (ushort)ModContent.WallType<Walls.TropicalGrassWall>())
                        {
                            Main.tile[num439, num441].wall = 0;
                        }
                        if (Main.tile[num439, num441].type != 53 && Main.tile[num439, num441].type != 112 && Main.tile[num439, num441].type != 234 && Main.tile[num439, num441].type != ModContent.TileType<Tiles.Snotsand>())
                        {
                            if (Main.tile[num439 - 1, num441].wall == 2 || Main.tile[num439 - 1, num441].wall == 40 || Main.tile[num439 - 1, num441].wall == 40)
                            {
                                Main.tile[num439 - 1, num441].wall = 0;
                            }
                            if ((Main.tile[num439 - 2, num441].wall == 2 || Main.tile[num439 - 2, num441].wall == 40 || Main.tile[num439 - 2, num441].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num439 - 2, num441].wall = 0;
                            }
                            if ((Main.tile[num439 - 3, num441].wall == 2 || Main.tile[num439 - 3, num441].wall == 40 || Main.tile[num439 - 3, num441].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num439 - 3, num441].wall = 0;
                            }
                            if (Main.tile[num439 + 1, num441].wall == 2 || Main.tile[num439 + 1, num441].wall == 40 || Main.tile[num439 + 1, num441].wall == 40)
                            {
                                Main.tile[num439 + 1, num441].wall = 0;
                            }
                            if ((Main.tile[num439 + 2, num441].wall == 2 || Main.tile[num439 + 2, num441].wall == 40 || Main.tile[num439 + 2, num441].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num439 + 2, num441].wall = 0;
                            }
                            if ((Main.tile[num439 + 3, num441].wall == 2 || Main.tile[num439 + 3, num441].wall == 40 || Main.tile[num439 + 3, num441].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num439 + 3, num441].wall = 0;
                            }
                            if (Main.tile[num439, num441].active())
                            {
                                flag34 = false;
                            }
                        }
                    }
                    else if (Main.tile[num439, num441].wall == 0 && Main.tile[num439, num441 + 1].wall == 0 && Main.tile[num439, num441 + 2].wall == 0 && Main.tile[num439, num441 + 3].wall == 0 && Main.tile[num439, num441 + 4].wall == 0 && Main.tile[num439 - 1, num441].wall == 0 && Main.tile[num439 + 1, num441].wall == 0 && Main.tile[num439 - 2, num441].wall == 0 && Main.tile[num439 + 2, num441].wall == 0 && !Main.tile[num439, num441].active() && !Main.tile[num439, num441 + 1].active() && !Main.tile[num439, num441 + 2].active() && !Main.tile[num439, num441 + 3].active())
                    {
                        flag34 = true;
                    }
                }
            }
            for (int num442 = Main.maxTilesX - 5; num442 >= 5; num442--)
            {
                float num443 = (float)num442 / (float)Main.maxTilesX;
                progress.Set(1f - 0.5f * num443);
                bool flag35 = true;
                for (int num444 = 0; (double)num444 < Main.worldSurface; num444++)
                {
                    if (flag35)
                    {
                        if (Main.tile[num442, num444].wall == 2 || Main.tile[num442, num444].wall == 40 || Main.tile[num442, num444].wall == (ushort)ModContent.WallType<Walls.TropicalGrassWall>())
                        {
                            Main.tile[num442, num444].wall = 0;
                        }
                        if (Main.tile[num442, num444].type != 53)
                        {
                            if (Main.tile[num442 - 1, num444].wall == 2 || Main.tile[num442 - 1, num444].wall == 40 || Main.tile[num442 - 1, num444].wall == 40)
                            {
                                Main.tile[num442 - 1, num444].wall = 0;
                            }
                            if ((Main.tile[num442 - 2, num444].wall == 2 || Main.tile[num442 - 2, num444].wall == 40 || Main.tile[num442 - 2, num444].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num442 - 2, num444].wall = 0;
                            }
                            if ((Main.tile[num442 - 3, num444].wall == 2 || Main.tile[num442 - 3, num444].wall == 40 || Main.tile[num442 - 3, num444].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num442 - 3, num444].wall = 0;
                            }
                            if (Main.tile[num442 + 1, num444].wall == 2 || Main.tile[num442 + 1, num444].wall == 40 || Main.tile[num442 + 1, num444].wall == 40)
                            {
                                Main.tile[num442 + 1, num444].wall = 0;
                            }
                            if ((Main.tile[num442 + 2, num444].wall == 2 || Main.tile[num442 + 2, num444].wall == 40 || Main.tile[num442 + 2, num444].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num442 + 2, num444].wall = 0;
                            }
                            if ((Main.tile[num442 + 3, num444].wall == 2 || Main.tile[num442 + 3, num444].wall == 40 || Main.tile[num442 + 3, num444].wall == 40) && WorldGen.genRand.Next(2) == 0)
                            {
                                Main.tile[num442 + 3, num444].wall = 0;
                            }
                            if (Main.tile[num442, num444].active())
                            {
                                flag35 = false;
                            }
                        }
                    }
                    else if (Main.tile[num442, num444].wall == 0 && Main.tile[num442, num444 + 1].wall == 0 && Main.tile[num442, num444 + 2].wall == 0 && Main.tile[num442, num444 + 3].wall == 0 && Main.tile[num442, num444 + 4].wall == 0 && Main.tile[num442 - 1, num444].wall == 0 && Main.tile[num442 + 1, num444].wall == 0 && Main.tile[num442 - 2, num444].wall == 0 && Main.tile[num442 + 2, num444].wall == 0 && !Main.tile[num442, num444].active() && !Main.tile[num442, num444 + 1].active() && !Main.tile[num442, num444 + 2].active() && !Main.tile[num442, num444 + 3].active())
                    {
                        flag35 = true;
                    }
                }
            }
        }
    }
}
