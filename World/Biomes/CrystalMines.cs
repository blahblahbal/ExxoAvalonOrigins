using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Biomes
{
    public class CrystalMines : MicroBiome
    {
        private struct Magma
        {
            public readonly float Pressure;

            public readonly float Resistance;

            public readonly bool IsActive;

            private Magma(float pressure, float resistance, bool active)
            {
                Pressure = pressure;
                Resistance = resistance;
                IsActive = active;
            }

            public Magma ToFlow()
            {
                return new Magma(Pressure, Resistance, active: true);
            }

            public static Magma CreateFlow(float pressure, float resistance = 0f)
            {
                return new Magma(pressure, resistance, active: true);
            }

            public static Magma CreateEmpty(float resistance = 0f)
            {
                return new Magma(0f, resistance, active: false);
            }
        }

        private const int MAX_MAGMA_ITERATIONS = 300;

        private static Magma[,] _sourceMagmaMap = new Magma[200, 200];

        private static Magma[,] _targetMagmaMap = new Magma[200, 200];

        public override bool Place(Point origin, StructureMap structures)
        {
            if (GenBase._tiles[origin.X, origin.Y].active())
            {
                return false;
            }
            int length = _sourceMagmaMap.GetLength(0);
            int length2 = _sourceMagmaMap.GetLength(1);
            int num = length / 2;
            int num12 = length2 / 2;
            origin.X -= num;
            origin.Y -= num12;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    int i2 = i + origin.X;
                    int j2 = j + origin.Y;
                    _sourceMagmaMap[i, j] = Magma.CreateEmpty(WorldGen.SolidTile(i2, j2) ? 4f : 1f);
                    _targetMagmaMap[i, j] = _sourceMagmaMap[i, j];
                }
            }
            int num20 = num;
            int num21 = num;
            int num22 = num12;
            int num23 = num12;
            for (int k = 0; k < 300; k++)
            {
                for (int l = num20; l <= num21; l++)
                {
                    for (int m = num22; m <= num23; m++)
                    {
                        Magma magma = _sourceMagmaMap[l, m];
                        if (!magma.IsActive)
                        {
                            continue;
                        }
                        float num24 = 0f;
                        Vector2 zero = Vector2.Zero;
                        for (int n = -1; n <= 1; n++)
                        {
                            for (int num25 = -1; num25 <= 1; num25++)
                            {
                                if (n == 0 && num25 == 0)
                                {
                                    continue;
                                }
                                Vector2 value = new Vector2(n, num25);
                                value.Normalize();
                                Magma magma2 = _sourceMagmaMap[l + n, m + num25];
                                if (magma.Pressure > 0.01f && !magma2.IsActive)
                                {
                                    if (n == -1)
                                    {
                                        num20 = Terraria.Utils.Clamp(l + n, 1, num20);
                                    }
                                    else
                                    {
                                        num21 = Terraria.Utils.Clamp(l + n, num21, length - 2);
                                    }
                                    if (num25 == -1)
                                    {
                                        num22 = Terraria.Utils.Clamp(m + num25, 1, num22);
                                    }
                                    else
                                    {
                                        num23 = Terraria.Utils.Clamp(m + num25, num23, length2 - 2);
                                    }
                                    _targetMagmaMap[l + n, m + num25] = magma2.ToFlow();
                                }
                                float pressure = magma2.Pressure;
                                num24 += pressure;
                                zero += pressure * value;
                            }
                        }
                        num24 /= 8f;
                        if (num24 > magma.Resistance)
                        {
                            float num26 = zero.Length() / 8f;
                            float val = Math.Max(num24 - num26 - magma.Pressure, 0f) + num26 + magma.Pressure * 0.875f - magma.Resistance;
                            val = Math.Max(0f, val);
                            _targetMagmaMap[l, m] = Magma.CreateFlow(val, Math.Max(0f, magma.Resistance - val * 0.02f));
                        }
                    }
                }
                if (k < 2)
                {
                    _targetMagmaMap[num, num12] = Magma.CreateFlow(25f);
                }
                Utils.Swap(ref _sourceMagmaMap, ref _targetMagmaMap);
            }
            bool flag = origin.Y + num12 > WorldGen.lavaLine - 30;
            bool flag2 = false;
            for (int num2 = -50; num2 < 50; num2++)
            {
                if (flag2)
                {
                    break;
                }
                for (int num3 = -50; num3 < 50; num3++)
                {
                    if (flag2)
                    {
                        break;
                    }
                    if (_tiles[origin.X + num + num2, origin.Y + num12 + num3].active())
                    {
                        ushort type = _tiles[origin.X + num + num2, origin.Y + num12 + num3].type;
                        if (type == 147 || (uint)(type - 161) <= 2u || type == 200)
                        {
                            flag = false;
                            flag2 = true;
                        }
                    }
                }
            }
            for (int num4 = num20; num4 <= num21; num4++)
            {
                for (int num5 = num22; num5 <= num23; num5++)
                {
                    Magma magma3 = _sourceMagmaMap[num4, num5];
                    if (!magma3.IsActive)
                    {
                        continue;
                    }
                    Tile tile = GenBase._tiles[origin.X + num4, origin.Y + num5];
                    float num6 = (float)Math.Sin((float)(origin.Y + num5) * 0.4f) * 0.7f + 1.2f;
                    float num7 = 0.2f + 0.5f / (float)Math.Sqrt(Math.Max(0f, magma3.Pressure - magma3.Resistance));
                    if (Math.Max(1f - Math.Max(0f, num6 * num7), magma3.Pressure / 15f) > 0.35f + (WorldGen.SolidTile(origin.X + num4, origin.Y + num5) ? 0f : 0.5f))
                    {
                        if (TileID.Sets.Ore[tile.type])
                        {
                            tile.ResetToType(tile.type);
                        }
                        else if (tile.type == TileID.Pots || tile.type == TileID.Containers || tile.type == TileID.Containers2 || tile.type == TileID.Heart ||
                            tile.type == TileID.ShadowOrbs || tile.type == TileID.DemonAltar || tile.type == ModContent.TileType<Tiles.HallowedAltar>() ||
                            tile.type == ModContent.TileType<Tiles.SnotOrb>() || tile.type == TileID.LihzahrdBrick || tile.type == TileID.BlueDungeonBrick ||
                            tile.type == TileID.PinkDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == ModContent.TileType<Tiles.TuhrtlBrick>() ||
                            tile.type == TileID.Statues)
                        {
                        }
                        else
                        {
                            tile.ResetToType((ushort)ModContent.TileType<Tiles.CrystalStone>());
                        }
                        if (tile.wall != WallID.LihzahrdBrickUnsafe && tile.wall != ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>() && !Main.wallDungeon[tile.wall])
                        {
                            tile.wall = (ushort)ModContent.WallType<Walls.CrystalStoneWall>();
                        }
                    }
                    else if (magma3.Resistance < 0.01f)
                    {
                        WorldUtils.ClearTile(origin.X + num4, origin.Y + num5);
                        tile.wall = (ushort)ModContent.WallType<Walls.CrystalStoneWall>();
                    }
                    if (tile.liquid > 0 && flag)
                    {
                        tile.liquid = 0;
                    }
                }
            }
            List<Point16> list = new List<Point16>();
            for (int num8 = num20; num8 <= num21; num8++)
            {
                for (int num9 = num22; num9 <= num23; num9++)
                {
                    if (!_sourceMagmaMap[num8, num9].IsActive)
                    {
                        continue;
                    }
                    int num10 = 0;
                    int num11 = num8 + origin.X;
                    int num13 = num9 + origin.Y;
                    if (!WorldGen.SolidTile(num11, num13))
                    {
                        continue;
                    }
                    for (int num14 = -1; num14 <= 1; num14++)
                    {
                        for (int num15 = -1; num15 <= 1; num15++)
                        {
                            if (WorldGen.SolidTile(num11 + num14, num13 + num15))
                            {
                                num10++;
                            }
                        }
                    }
                    if (num10 < 3)
                    {
                        list.Add(new Point16(num11, num13));
                    }
                }
            }
            foreach (Point16 item in list)
            {
                int x = item.X;
                int y = item.Y;
                WorldUtils.ClearTile(x, y, frameNeighbors: true);
                GenBase._tiles[x, y].wall = (ushort)ModContent.WallType<Walls.CrystalStoneWall>();
            }
            list.Clear();
            for (int num16 = num20; num16 <= num21; num16++)
            {
                for (int num17 = num22; num17 <= num23; num17++)
                {
                    Magma magma4 = _sourceMagmaMap[num16, num17];
                    int num18 = num16 + origin.X;
                    int num19 = num17 + origin.Y;
                    if (!magma4.IsActive)
                    {
                        continue;
                    }
                    WorldUtils.TileFrame(num18, num19);
                    WorldGen.SquareWallFrame(num18, num19);
                    //if (GenBase._random.Next(8) == 0 && GenBase._tiles[num18, num19].active())
                    //{
                    //    if (!GenBase._tiles[num18, num19 + 1].active())
                    //    {
                    //        WorldGen.PlaceTight(num18, num19 + 1, 165);
                    //    }
                    //    if (!GenBase._tiles[num18, num19 - 1].active())
                    //    {
                    //        WorldGen.PlaceTight(num18, num19 - 1, 165);
                    //    }
                    //}
                    if (!Main.tile[num18, num19].active() && Main.tile[num18, num19 - 1].active() && Main.tile[num18, num19 - 1].type == ModContent.TileType<Tiles.CrystalStone>() ||
                        !Main.tile[num18, num19].active() && Main.tile[num18, num19 + 1].active() && Main.tile[num18, num19 + 1].type == ModContent.TileType<Tiles.CrystalStone>() ||
                        !Main.tile[num18, num19].active() && Main.tile[num18 - 1, num19].active() && Main.tile[num18 - 1, num19].type == ModContent.TileType<Tiles.CrystalStone>() ||
                        !Main.tile[num18, num19].active() && Main.tile[num18 + 1, num19].active() && Main.tile[num18 + 1, num19].type == ModContent.TileType<Tiles.CrystalStone>())
                    {
                        if (Main.tile[num18, num19].type != TileID.Crystals)
                        {
                            if (WorldGen.genRand.Next(8) == 0)
                            {
                                WorldGen.PlaceTile(num18, num19, TileID.Crystals);
                            }
                        }
                    }
                    if (GenBase._random.Next(2) == 0)
                    {
                        Tile.SmoothSlope(num18, num19);
                    }
                }
            }
            return true;
        }
    }
}
