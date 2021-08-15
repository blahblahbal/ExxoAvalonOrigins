// Warning: Some assembly references could not be resolved automatically. This might lead to incorrect decompilation of some parts,
// for ex. property getter/setter access. To get optimal decompilation results, please manually add the missing references to the list of loaded assemblies.
// Terraria.GameContent.Biomes.DesertBiome
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Biomes;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins
{
    public class DesertBiome : MicroBiome
    {
        private struct Hub
        {
            public Vector2 Position;

            public Hub(Vector2 position)
            {
                Position = position;
            }

            public Hub(float x, float y)
            {
                Position = new Vector2(x, y);
            }
        }

        private class Cluster : List<Hub>
        {
        }

        private class ClusterGroup : List<Cluster>
        {
            public int Width;

            public int Height;

            private void SearchForCluster(bool[,] hubMap, List<Point> pointCluster, int x, int y, int level = 2)
            {
                pointCluster.Add(new Point(x, y));
                hubMap[x, y] = false;
                level--;
                if (level != -1)
                {
                    if (x > 0 && hubMap[x - 1, y])
                    {
                        SearchForCluster(hubMap, pointCluster, x - 1, y, level);
                    }
                    if (x < hubMap.GetLength(0) - 1 && hubMap[x + 1, y])
                    {
                        SearchForCluster(hubMap, pointCluster, x + 1, y, level);
                    }
                    if (y > 0 && hubMap[x, y - 1])
                    {
                        SearchForCluster(hubMap, pointCluster, x, y - 1, level);
                    }
                    if (y < hubMap.GetLength(1) - 1 && hubMap[x, y + 1])
                    {
                        SearchForCluster(hubMap, pointCluster, x, y + 1, level);
                    }
                }
            }

            private void AttemptClaim(int x, int y, int[,] clusterIndexMap, List<List<Point>> pointClusters, int index)
            {
                int num = clusterIndexMap[x, y];
                if (num == -1 || num == index)
                {
                    return;
                }
                int num2 = ((WorldGen.genRand.Next(2) == 0) ? (-1) : index);
                foreach (Point item in pointClusters[num])
                {
                    clusterIndexMap[item.X, item.Y] = num2;
                }
            }

            public void Generate(int width, int height)
            {
                Width = width;
                Height = height;
                Clear();
                bool[,] array = new bool[width, height];
                int num = (width >> 1) - 1;
                int num2 = (height >> 1) - 1;
                int num3 = (num + 1) * (num + 1);
                Point point = new Point(num, num2);
                for (int i = point.Y - num2; i <= point.Y + num2; i++)
                {
                    float num4 = (float)num / (float)num2 * (float)(i - point.Y);
                    int num5 = Math.Min(num, (int)Math.Sqrt((float)num3 - num4 * num4));
                    for (int j = point.X - num5; j <= point.X + num5; j++)
                    {
                        array[j, i] = WorldGen.genRand.Next(2) == 0;
                    }
                }
                List<List<Point>> list = new List<List<Point>>();
                for (int k = 0; k < array.GetLength(0); k++)
                {
                    for (int l = 0; l < array.GetLength(1); l++)
                    {
                        if (array[k, l] && WorldGen.genRand.Next(2) == 0)
                        {
                            List<Point> list2 = new List<Point>();
                            SearchForCluster(array, list2, k, l);
                            if (list2.Count > 2)
                            {
                                list.Add(list2);
                            }
                        }
                    }
                }
                int[,] array2 = new int[array.GetLength(0), array.GetLength(1)];
                for (int m = 0; m < array2.GetLength(0); m++)
                {
                    for (int n = 0; n < array2.GetLength(1); n++)
                    {
                        array2[m, n] = -1;
                    }
                }
                for (int num6 = 0; num6 < list.Count; num6++)
                {
                    foreach (Point item in list[num6])
                    {
                        array2[item.X, item.Y] = num6;
                    }
                }
                for (int num7 = 0; num7 < list.Count; num7++)
                {
                    foreach (Point item5 in list[num7])
                    {
                        int x = item5.X;
                        int y = item5.Y;
                        if (array2[x, y] == -1)
                        {
                            break;
                        }
                        int index = array2[x, y];
                        if (x > 0)
                        {
                            AttemptClaim(x - 1, y, array2, list, index);
                        }
                        if (x < array2.GetLength(0) - 1)
                        {
                            AttemptClaim(x + 1, y, array2, list, index);
                        }
                        if (y > 0)
                        {
                            AttemptClaim(x, y - 1, array2, list, index);
                        }
                        if (y < array2.GetLength(1) - 1)
                        {
                            AttemptClaim(x, y + 1, array2, list, index);
                        }
                    }
                }
                foreach (List<Point> item6 in list)
                {
                    item6.Clear();
                }
                for (int num8 = 0; num8 < array2.GetLength(0); num8++)
                {
                    for (int num9 = 0; num9 < array2.GetLength(1); num9++)
                    {
                        if (array2[num8, num9] != -1)
                        {
                            list[array2[num8, num9]].Add(new Point(num8, num9));
                        }
                    }
                }
                foreach (List<Point> item2 in list)
                {
                    if (item2.Count < 4)
                    {
                        item2.Clear();
                    }
                }
                foreach (List<Point> item3 in list)
                {
                    Cluster cluster = new Cluster();
                    if (item3.Count <= 0)
                    {
                        continue;
                    }
                    foreach (Point item4 in item3)
                    {
                        cluster.Add(new Hub((float)item4.X + (WorldGen.genRand.NextFloat() - 0.5f) * 0.5f, (float)item4.Y + (WorldGen.genRand.NextFloat() - 0.5f) * 0.5f));
                    }
                    Add(cluster);
                }
            }
        }

        private void PlaceSand(ClusterGroup clusters, Point start, Vector2 scale)
        {
            int num = (int)(scale.X * (float)clusters.Width);
            int num10 = (int)(scale.Y * (float)clusters.Height);
            int num11 = 5;
            int num12 = start.Y + (num10 >> 1);
            float num13 = 0f;
            short[] array = new short[num + num11 * 2];
            for (int i = -num11; i < num + num11; i++)
            {
                for (int j = 150; j < num12; j++)
                {
                    if (WorldGen.SolidOrSlopedTile(i + start.X, j))
                    {
                        num13 += (float)(j - 1);
                        array[i + num11] = (short)(j - 1);
                        break;
                    }
                }
            }
            float num14 = num13 / (float)(num + num11 * 2);
            int num15 = 0;
            for (int k = -num11; k < num + num11; k++)
            {
                float value = Math.Abs((float)(k + num11) / (float)(num + num11 * 2)) * 2f - 1f;
                value = MathHelper.Clamp(value, -1f, 1f);
                if (k % 3 == 0)
                {
                    num15 = Utils.Clamp(num15 + GenBase._random.Next(-1, 2), -10, 10);
                }
                float num16 = (float)Math.Sqrt(1f - value * value * value * value);
                int num17 = num12 - (int)(num16 * ((float)num12 - num14)) + num15;
                int val = num12 - (int)(((float)num12 - num14) * (num16 - 0.15f / (float)Math.Sqrt(Math.Max(0.01, (double)Math.Abs(8f * value) - 0.1)) + 0.25f));
                val = Math.Min(num12, val);
                if (Math.Abs(value) < 0.8f)
                {
                    float num2 = Utils.SmoothStep(0.5f, 0.8f, Math.Abs(value));
                    num2 = num2 * num2 * num2;
                    int val2 = 10 + (int)(num14 - num2 * 20f) + num15;
                    val2 = Math.Min(val2, num17);
                    int num3 = 50;
                    for (int l = num3; (float)l < num14; l++)
                    {
                        int num4 = k + start.X;
                        if (GenBase._tiles[num4, l].active() && (GenBase._tiles[num4, l].type == 189 || GenBase._tiles[num4, l].type == 196))
                        {
                            num3 = l + 5;
                        }
                    }
                    for (int m = num3; m < val2; m++)
                    {
                        int num5 = k + start.X;
                        int num6 = m;
                        GenBase._tiles[num5, num6].active(active: false);
                        GenBase._tiles[num5, num6].wall = 0;
                    }
                    array[k + num11] = (short)val2;
                }
                for (int num7 = num12 - 1; num7 >= num17; num7--)
                {
                    int num8 = k + start.X;
                    int num9 = num7;
                    Tile tile = GenBase._tiles[num8, num9];
                    tile.liquid = 0;
                    Tile testTile = GenBase._tiles[num8, num9 + 1];
                    Tile testTile2 = GenBase._tiles[num8, num9 + 2];
                    tile.type = (ushort)((WorldGen.SolidTile(testTile) && WorldGen.SolidTile(testTile2)) ? 53u : 397u);
                    if (num7 > num17 + 5)
                    {
                        tile.wall = 187;
                    }
                    tile.active(active: true);
                    if (tile.wall != 187)
                    {
                        tile.wall = 0;
                    }
                    if (num7 < val)
                    {
                        if (num7 > num17 + 5)
                        {
                            tile.wall = 187;
                        }
                        tile.active(active: false);
                    }
                    WorldGen.SquareWallFrame(num8, num9);
                }
            }
        }

        private void PlaceClusters(ClusterGroup clusters, Point start, Vector2 scale)
        {
            int num = (int)(scale.X * (float)clusters.Width);
            int num4 = (int)(scale.Y * (float)clusters.Height);
            Vector2 value = new Vector2(num, num4);
            Vector2 value2 = new Vector2(clusters.Width, clusters.Height);
            for (int i = -20; i < num + 20; i++)
            {
                for (int j = -20; j < num4 + 20; j++)
                {
                    float num5 = 0f;
                    int num6 = -1;
                    float num7 = 0f;
                    int num8 = i + start.X;
                    int num9 = j + start.Y;
                    Vector2 value3 = new Vector2(i, j) / value * value2;
                    float num10 = (new Vector2(i, j) / value * 2f - Vector2.One).Length();
                    for (int k = 0; k < clusters.Count; k++)
                    {
                        Cluster cluster = clusters[k];
                        if (Math.Abs(cluster[0].Position.X - value3.X) > 10f || Math.Abs(cluster[0].Position.Y - value3.Y) > 10f)
                        {
                            continue;
                        }
                        float num11 = 0f;
                        foreach (Hub item in cluster)
                        {
                            num11 += 1f / Vector2.DistanceSquared(item.Position, value3);
                        }
                        if (num11 > num5)
                        {
                            if (num5 > num7)
                            {
                                num7 = num5;
                            }
                            num5 = num11;
                            num6 = k;
                        }
                        else if (num11 > num7)
                        {
                            num7 = num11;
                        }
                    }
                    float num2 = num5 + num7;
                    Tile tile = GenBase._tiles[num8, num9];
                    bool flag = num10 >= 0.8f;
                    if (num2 > 3.5f)
                    {
                        tile.ClearEverything();
                        tile.wall = 187;
                        tile.liquid = 0;
                        if (num6 % 15 == 2)
                        {
                            tile.ResetToType(404);
                            tile.wall = 187;
                            tile.active(active: true);
                        }
                        Tile.SmoothSlope(num8, num9);
                    }
                    else if (num2 > 1.8f)
                    {
                        tile.wall = 187;
                        if (!flag || tile.active())
                        {
                            tile.ResetToType(396);
                            tile.wall = 187;
                            tile.active(active: true);
                            Tile.SmoothSlope(num8, num9);
                        }
                        tile.liquid = 0;
                    }
                    else if (num2 > 0.7f || !flag)
                    {
                        if (!flag || tile.active())
                        {
                            tile.ResetToType(397);
                            tile.active(active: true);
                            Tile.SmoothSlope(num8, num9);
                        }
                        tile.liquid = 0;
                        tile.wall = 216;
                    }
                    else
                    {
                        if (!(num2 > 0.25f))
                        {
                            continue;
                        }
                        float num3 = (num2 - 0.25f) / 0.45f;
                        if (GenBase._random.NextFloat() < num3)
                        {
                            if (tile.active())
                            {
                                tile.ResetToType(397);
                                tile.active(active: true);
                                Tile.SmoothSlope(num8, num9);
                                tile.wall = 216;
                            }
                            tile.liquid = 0;
                            tile.wall = 187;
                        }
                    }
                }
            }
        }

        private void AddTileVariance(ClusterGroup clusters, Point start, Vector2 scale)
        {
            int num = (int)(scale.X * (float)clusters.Width);
            int num2 = (int)(scale.Y * (float)clusters.Height);
            for (int i = -20; i < num + 20; i++)
            {
                for (int j = -20; j < num2 + 20; j++)
                {
                    int num3 = i + start.X;
                    int num4 = j + start.Y;
                    Tile tile = GenBase._tiles[num3, num4];
                    Tile testTile = GenBase._tiles[num3, num4 + 1];
                    Tile testTile2 = GenBase._tiles[num3, num4 + 2];
                    if (tile.type == 53 && (!WorldGen.SolidTile(testTile) || !WorldGen.SolidTile(testTile2)))
                    {
                        tile.type = 397;
                    }
                }
            }
            for (int k = -20; k < num + 20; k++)
            {
                for (int l = -20; l < num2 + 20; l++)
                {
                    int num5 = k + start.X;
                    int num6 = l + start.Y;
                    Tile tile2 = GenBase._tiles[num5, num6];
                    if (!tile2.active() || tile2.type != 396)
                    {
                        continue;
                    }
                    bool flag = true;
                    for (int num7 = -1; num7 >= -3; num7--)
                    {
                        if (GenBase._tiles[num5, num6 + num7].active())
                        {
                            flag = false;
                            break;
                        }
                    }
                    bool flag2 = true;
                    for (int m = 1; m <= 3; m++)
                    {
                        if (GenBase._tiles[num5, num6 + m].active())
                        {
                            flag2 = false;
                            break;
                        }
                    }
                    if ((flag ^ flag2) && GenBase._random.Next(5) == 0)
                    {
                        WorldGen.PlaceTile(num5, num6 + ((!flag) ? 1 : (-1)), 165, mute: true, forced: true);
                    }
                    else if (flag && GenBase._random.Next(5) == 0)
                    {
                        WorldGen.PlaceTile(num5, num6 - 1, 187, mute: true, forced: true, -1, 29 + GenBase._random.Next(6));
                    }
                }
            }
        }

        private bool FindStart(Point origin, Vector2 scale, int xHubCount, int yHubCount, out Point start)
        {
            start = new Point(0, 0);
            int num = (int)(scale.X * (float)xHubCount);
            int height = (int)(scale.Y * (float)yHubCount);
            origin.X -= num >> 1;
            int num2 = 220;
            for (int i = -20; i < num + 20; i++)
            {
                for (int j = 220; j < Main.maxTilesY; j++)
                {
                    if (!WorldGen.SolidTile(i + origin.X, j))
                    {
                        continue;
                    }
                    ushort type = GenBase._tiles[i + origin.X, j].type;
                    if (type == (ushort)ModContent.TileType<Tiles.TropicalMud>() || type == (ushort)ModContent.TileType<Tiles.TropicalGrass>() || type == 59)
                    {
                        return false;
                    }
                    if (j > num2)
                    {
                        num2 = j;
                    }
                    break;
                }
            }
            WorldGen.UndergroundDesertLocation = new Rectangle(origin.X, num2, num, height);
            start = new Point(origin.X, num2);
            return true;
        }

        public override bool Place(Point origin, StructureMap structures)
        {
            float num = (float)Main.maxTilesX / 4200f;
            int num2 = (int)(80f * num);
            int num3 = (int)((GenBase._random.NextFloat() + 1f) * 80f * num);
            Vector2 scale = new Vector2(4f, 2f);
            if (!FindStart(origin, scale, num2, num3, out var start))
            {
                return false;
            }
            ClusterGroup clusterGroup = new ClusterGroup();
            clusterGroup.Generate(num2, num3);
            PlaceSand(clusterGroup, start, scale);
            PlaceClusters(clusterGroup, start, scale);
            AddTileVariance(clusterGroup, start, scale);
            int num4 = (int)(scale.X * (float)clusterGroup.Width);
            int num5 = (int)(scale.Y * (float)clusterGroup.Height);
            for (int i = -20; i < num4 + 20; i++)
            {
                for (int j = -20; j < num5 + 20; j++)
                {
                    if (i + start.X > 0 && i + start.X < Main.maxTilesX - 1 && j + start.Y > 0 && j + start.Y < Main.maxTilesY - 1)
                    {
                        WorldGen.SquareWallFrame(i + start.X, j + start.Y);
                        WorldUtils.TileFrame(i + start.X, j + start.Y, frameNeighbors: true);
                    }
                }
            }
            return true;
        }
    }
}