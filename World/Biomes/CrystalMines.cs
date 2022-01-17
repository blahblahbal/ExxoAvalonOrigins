// Warning: Some assembly references could not be resolved automatically. This might lead to incorrect decompilation of some parts,
// for ex. property getter/setter access. To get optimal decompilation results, please manually add the missing references to the list of loaded assemblies.
// Terraria.GameContent.Biomes.MarbleBiome
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Biomes
{
    public class CrystalMines : MicroBiome
    {
        private delegate bool SlabState(int x, int y, int scale);

        private class SlabStates
        {
            public static bool Empty(int x, int y, int scale)
            {
                return false;
            }

            public static bool Solid(int x, int y, int scale)
            {
                return true;
            }

            public static bool HalfBrick(int x, int y, int scale)
            {
                return y >= scale / 2;
            }

            public static bool BottomRightFilled(int x, int y, int scale)
            {
                return x >= scale - y;
            }

            public static bool BottomLeftFilled(int x, int y, int scale)
            {
                return x < y;
            }

            public static bool TopRightFilled(int x, int y, int scale)
            {
                return x > y;
            }

            public static bool TopLeftFilled(int x, int y, int scale)
            {
                return x < scale - y;
            }
        }

        private struct Slab
        {
            public readonly SlabState State;

            public readonly bool HasWall;

            public bool IsSolid => State != new SlabState(SlabStates.Empty);

            private Slab(SlabState state, bool hasWall)
            {
                State = state;
                HasWall = hasWall;
            }

            public Slab WithState(SlabState state)
            {
                return new Slab(state, HasWall);
            }

            public static Slab Create(SlabState state, bool hasWall)
            {
                return new Slab(state, hasWall);
            }
        }

        private const int SCALE = 3;

        private Slab[,] _slabs;

        private void SmoothSlope(int x, int y)
        {
            Slab slab = _slabs[x, y];
            if (slab.IsSolid)
            {
                bool isSolid5 = _slabs[x, y - 1].IsSolid;
                bool isSolid2 = _slabs[x, y + 1].IsSolid;
                bool isSolid3 = _slabs[x - 1, y].IsSolid;
                bool isSolid4 = _slabs[x + 1, y].IsSolid;
                switch (((isSolid5 ? 1 : 0) << 3) | ((isSolid2 ? 1 : 0) << 2) | ((isSolid3 ? 1 : 0) << 1) | (isSolid4 ? 1 : 0))
                {
                    case 10:
                        _slabs[x, y] = slab.WithState(SlabStates.TopLeftFilled);
                        break;
                    case 9:
                        _slabs[x, y] = slab.WithState(SlabStates.TopRightFilled);
                        break;
                    case 6:
                        _slabs[x, y] = slab.WithState(SlabStates.BottomLeftFilled);
                        break;
                    case 5:
                        _slabs[x, y] = slab.WithState(SlabStates.BottomRightFilled);
                        break;
                    case 4:
                        _slabs[x, y] = slab.WithState(SlabStates.HalfBrick);
                        break;
                    default:
                        _slabs[x, y] = slab.WithState(SlabStates.Solid);
                        break;
                }
            }
        }

        private void PlaceSlab(Slab slab, int originX, int originY, int scale)
        {
            for (int i = 0; i < scale; i++)
            {
                for (int j = 0; j < scale; j++)
                {
                    Tile tile = _tiles[originX + i, originY + j];
                    if (TileID.Sets.Ore[tile.type] || tile.type == TileID.LihzahrdBrick || tile.type == TileID.BlueDungeonBrick ||
                        tile.type == TileID.PinkDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.Containers ||
                        tile.type == TileID.Containers2 || tile.type == TileID.Pots || tile.type == ModContent.TileType<Tiles.TuhrtlBrick>())
                    {
                        tile.ResetToType(tile.type);
                    }
                    else
                    {
                        tile.ResetToType((ushort)ModContent.TileType<Tiles.CrystalStone>());
                    }
                    bool active = slab.State(i, j, scale);
                    tile.active(active);
                    if (slab.HasWall && tile.wall != WallID.LihzahrdBrickUnsafe && tile.wall != ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>() && !Main.wallDungeon[tile.wall])
                    {
                        tile.wall = (ushort)ModContent.WallType<Walls.CrystalStoneWall>();
                    }
                    WorldUtils.TileFrame(originX + i, originY + j, frameNeighbors: true);
                    WorldGen.SquareWallFrame(originX + i, originY + j);
                    Tile.SmoothSlope(originX + i, originY + j);
                    //if (WorldGen.SolidTile(originX + i, originY + j - 1) && WorldGen.genRand.Next(4) == 0)
                    //{
                    //    WorldGen.PlaceTight(originX + i, originY + j, 165);
                    //}
                    //if (WorldGen.SolidTile(originX + i, originY + j) && WorldGen.genRand.Next(4) == 0)
                    //{
                    //    WorldGen.PlaceTight(originX + i, originY + j - 1, 165);
                    //}
                }
            }
        }

        private bool IsGroupSolid(int x, int y, int scale)
        {
            int num = 0;
            for (int i = 0; i < scale; i++)
            {
                for (int j = 0; j < scale; j++)
                {
                    if (WorldGen.SolidOrSlopedTile(x + i, y + j))
                    {
                        num++;
                    }
                }
            }
            return num > scale / 4 * 3;
        }

        public override bool Place(Point origin, StructureMap structures)
        {
            if (_slabs == null)
            {
                _slabs = new Slab[56, 26];
            }
            int num = WorldGen.genRand.Next(80, 150) / 3;
            int num6 = WorldGen.genRand.Next(40, 60) / 3;
            int num7 = (num6 * 3 - WorldGen.genRand.Next(20, 30)) / 3;
            origin.X -= num * 3 / 2;
            origin.Y -= num6 * 3 / 2;
            for (int i = -1; i < num + 1; i++)
            {
                float num8 = (i - num / 2) / num + 0.5f;
                int num9 = (int)((0.5f - Math.Abs(num8 - 0.5f)) * 5f) - 2;
                for (int j = -1; j < num6 + 1; j++)
                {
                    bool hasWall = true;
                    bool flag = false;
                    bool flag2 = IsGroupSolid(i * 3 + origin.X, j * 3 + origin.Y, 3);
                    int num10 = Math.Abs(j - num6 / 2) - num7 / 4 + num9;
                    if (num10 > 3)
                    {
                        flag = flag2;
                        hasWall = false;
                    }
                    else if (num10 > 0)
                    {
                        flag = j - num6 / 2 > 0 || flag2;
                        hasWall = j - num6 / 2 < 0 || num10 <= 2;
                    }
                    else if (num10 == 0)
                    {
                        flag = WorldGen.genRand.Next(2) == 0 && (j - num6 / 2 > 0 || flag2);
                    }
                    if (Math.Abs(num8 - 0.5f) > 0.35f + WorldGen.genRand.NextFloat() * 0.1f && !flag2)
                    {
                        hasWall = false;
                        flag = false;
                    }
                    _slabs[i + 1, j + 1] = Slab.Create(flag ? new SlabState(SlabStates.Solid) : new SlabState(SlabStates.Empty), hasWall);
                }
            }
            for (int k = 0; k < num; k++)
            {
                for (int l = 0; l < num6; l++)
                {
                    SmoothSlope(k + 1, l + 1);
                }
            }
            int num11 = num / 2;
            int num12 = num6 / 2;
            int num13 = (num12 + 1) * (num12 + 1);
            float value = WorldGen.genRand.NextFloat() * 2f - 1f;
            float num2 = WorldGen.genRand.NextFloat() * 2f - 1f;
            float value2 = WorldGen.genRand.NextFloat() * 2f - 1f;
            float num3 = 0f;
            for (int m = 0; m <= num; m++)
            {
                float num4 = num12 / num11 * (m - num11);
                int num5 = Math.Min(num12, (int)Math.Sqrt(Math.Max(0f, num13 - num4 * num4)));
                num3 = ((m >= num / 2) ? (num3 + MathHelper.Lerp(num2, value2, m / (float)(num / 2) - 1f)) : (num3 + MathHelper.Lerp(value, num2, m / (float)(num / 2))));
                for (int n = num12 - num5; n <= num12 + num5; n++)
                {
                    PlaceSlab(_slabs[m + 1, n + 1], m * 3 + origin.X, n * 3 + origin.Y + (int)num3, 3);
                }
            }
            return true;
        }
    }
}
