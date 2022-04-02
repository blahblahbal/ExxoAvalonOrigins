using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ExxoAvalonOrigins.World.Passes;

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
            if (Main.tile[i, k].HasTile && Main.tileSolid[(int)Main.tile[i, k].TileType])
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
                if (!Main.tileSolid[(int)Main.tile[i, num].TileType] || !Main.tileSolid[(int)Main.tile[i - 1, num].TileType])
                {
                    return false;
                }
                if (!Main.wallDungeon[(int)Main.tile[i, num].WallType])
                {
                    return false;
                }
                Main.tile[i - 1, num - 1].active(true);
                Main.tile[i - 1, num - 1].TileType = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                Main.tile[i - 1, num - 1].TileFrameX = 0;
                Main.tile[i - 1, num - 1].TileFrameY = 0;
                Main.tile[i, num - 1].active(true);
                Main.tile[i, num - 1].TileType = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                Main.tile[i, num - 1].TileFrameX = 18;
                Main.tile[i, num - 1].TileFrameY = 0;
                Main.tile[i - 1, num].active(true);
                Main.tile[i - 1, num].TileType = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                Main.tile[i - 1, num].TileFrameX = 0;
                Main.tile[i - 1, num].TileFrameY = 18;
                Main.tile[i, num].active(true);
                Main.tile[i, num].TileType = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                Main.tile[i, num].TileFrameX = 18;
                Main.tile[i, num].TileFrameY = 18;
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