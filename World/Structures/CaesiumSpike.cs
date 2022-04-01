using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace ExxoAvalonOrigins.World.Structures
{
    class CaesiumSpike
    {
        public static Vector2 CreateSpike2(float X, float Y, float xDir, float yDir, int Steps, int Size)
        {
            float num = X;
            float num2 = Y;
            try
            {
                float num3 = 0f;
                float num4 = 0f;
                float num5 = Size;
                num = MathHelper.Clamp(num, num5 + 1f, Main.maxTilesX - num5 - 1f);
                num2 = MathHelper.Clamp(num2, num5 + 1f, Main.maxTilesY - num5 - 1f);
                for (int i = 0; i < Steps; i++)
                {
                    for (int j = (int)(num - num5); j <= num + num5; j++)
                    {
                        for (int k = (int)(num2 - num5); k <= num2 + num5; k++)
                        {
                            if ((Math.Abs(j - num) + Math.Abs(k - num2)) < num5 * (1.0 + WorldGen.genRand.Next(-10, 11) * 0.005) && j >= 0 && j < Main.maxTilesX && k >= 0 && k < Main.maxTilesY)
                            {
                                Main.tile[j, k].active(true);
                                Main.tile[j, k].TileType = (ushort)ModContent.TileType<Tiles.Ores.CaesiumOre>();
                                WorldGen.SquareTileFrame(j, k);
                            }
                        }
                    }
                    num5 += WorldGen.genRand.Next(-50, 51) * 0.03f;
                    if (num5 < Size * 0.6)
                    {
                        num5 = Size * 0.6f;
                    }
                    if (num5 > (Size * 2))
                    {
                        num5 = Size * 2f;
                    }
                    num3 += WorldGen.genRand.Next(-20, 21) * 0.01f;
                    num4 += WorldGen.genRand.Next(-20, 21) * 0.01f;
                    if (num3 < -1f)
                    {
                        num3 = -1f;
                    }
                    if (num3 > 1f)
                    {
                        num3 = 1f;
                    }
                    if (num4 < -1f)
                    {
                        num4 = -1f;
                    }
                    if (num4 > 1f)
                    {
                        num4 = 1f;
                    }
                    num += (xDir + num3) * 0.3f;
                    num2 += (yDir + num4) * 0.6f;
                }
            }
            catch
            {
            }
            return new Vector2(num, num2);
        }

        public static bool CreateSpikeDown(int x, int y, ushort type, bool down = false)
        {
            if (!WorldUtils.Find(new Point(x, y), Searches.Chain(new Searches.Down(10), new Conditions.IsSolid().AreaAnd(6, 1)), out var result))
            {
                return false;
            }
            float angle = 1 / 3f * 2f + 0.57075f;
            WorldUtils.Gen(result, new ShapeRoot(angle, WorldGen.genRand.Next(25, 35), 6, 2), new Actions.SetTile(type, setSelfFrames: true));
            return true;
        }

        public static bool CreateSpikeUp(int x, int y, ushort type)
        {
            if (!WorldUtils.Find(new Point(x, y), Searches.Chain(new Searches.Down(10), new Conditions.IsSolid().AreaAnd(6, 1)), out var result))
            {
                return false;
            }
            float angle = -(1 / 3f * 2f + 0.57075f * 2);
            WorldUtils.Gen(result, new ShapeRoot(angle, WorldGen.genRand.Next(35, 45), 8, 3), new Actions.SetTile(type, setSelfFrames: true));
            return true;
        }

        public static void CreateSpike(int x, int y)
        {
            int xStep = 2;
            int yStep = 7;

            while (xStep < 3)
            {
                for (int i = x - xStep + 1; i < x + xStep + 1; i++)
                {
                    for (int j = y - yStep + 1; j < y + yStep + 1; j++)
                    {
                        Main.tile[i, j].TileType = (ushort)ModContent.TileType<Tiles.Ores.CaesiumOre>();
                        Main.tile[i, j].active(true);
                    }
                    yStep += WorldGen.genRand.Next(1, 3);
                }
                xStep += WorldGen.genRand.Next(1, 3);
            }
            x += xStep - 2;
            if (WorldGen.genRand.Next(2) == 0)
            {
                y += WorldGen.genRand.Next(10, 15);
            }
            else y -= WorldGen.genRand.Next(10, 15);
            int xStep2 = 2;
            int yStep2 = 7;
            while (xStep2 < 3)
            {
                for (int i = x + xStep2 + 1; i > x - xStep2 + 1; i--)
                {
                    for (int j = y + yStep2 + 1; j > y - yStep2 + 1; j--)
                    {
                        Main.tile[i, j].TileType = (ushort)ModContent.TileType<Tiles.Ores.CaesiumOre>();
                        Main.tile[i, j].active(true);
                    }
                    yStep2 += WorldGen.genRand.Next(1, 3);
                }
                xStep2 += WorldGen.genRand.Next(1, 3);
            }
        }
    }
}
