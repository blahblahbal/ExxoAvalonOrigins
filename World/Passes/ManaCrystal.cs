using Terraria;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class ManaCrystal
    {
        public static void Method(GenerationProgress progress)
        {
            for (int num381 = 0; num381 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-06); num381++)
            {
                float num382 = (float)((double)num381 / ((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05));
                Main.statusText = string.Concat(new object[]
                {
                            "Adding mana crystals:",
                            " ",
                            (int)(num382 * 100f + 1f),
                            "%"
                });
                bool flag27 = false;
                int num383 = 0;
                while (!flag27)
                {
                    if (AddManaCrystal(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)(WorldGen.worldSurfaceLow + 20.0), Main.maxTilesY - 300)))
                    {
                        flag27 = true;
                    }
                    else
                    {
                        num383++;
                        if (num383 >= 10000)
                        {
                            flag27 = true;
                        }
                    }
                }
            }
        }
        public static bool AddManaCrystal(int i, int j)
        {
            int k = j;
            while (k < Main.maxTilesY)
            {
                if (Main.tile[i, k].active() && Main.tileSolid[(int)Main.tile[i, k].type])
                {
                    int num = k - 1;
                    if (Main.tile[i, num - 1].lava() || Main.tile[i - 1, num - 1].lava())
                    {
                        return false;
                    }
                    if (!WorldGen.EmptyTileCheck(i - 1, i, num - 1, num, -1))
                    {
                        return false;
                    }
                    if (!Main.tileSolid[(int)Main.tile[i, num].type] || !Main.tileSolid[(int)Main.tile[i - 1, num].type])
                    {
                        return false;
                    }
                    if (!Main.wallDungeon[(int)Main.tile[i, num].wall])
                    {
                        return false;
                    }
                    Main.tile[i - 1, num - 1].active(true);
                    Main.tile[i - 1, num - 1].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i - 1, num - 1].frameX = 0;
                    Main.tile[i - 1, num - 1].frameY = 0;
                    Main.tile[i, num - 1].active(true);
                    Main.tile[i, num - 1].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i, num - 1].frameX = 18;
                    Main.tile[i, num - 1].frameY = 0;
                    Main.tile[i - 1, num].active(true);
                    Main.tile[i - 1, num].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i - 1, num].frameX = 0;
                    Main.tile[i - 1, num].frameY = 18;
                    Main.tile[i, num].active(true);
                    Main.tile[i, num].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i, num].frameX = 18;
                    Main.tile[i, num].frameY = 18;
                    return true;
                }
                else
                {
                    k++;
                }
            }
            return false;
        }
    }
}
