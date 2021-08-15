using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ExxoAvalonOrigins.World.Passes
{
    class Tropics
    {
        static bool mudWall;
        static int grassSpread = 0;
        public static void Method(GenerationProgress progress)
        {
            mudWall = false;
            progress.Message = "Generating Tropics";
            float num616 = Main.maxTilesX / 4200;
            num616 *= 1.5f;
            int num617 = 0;
            float num618 = (float)WorldGen.genRand.Next(15, 30) * 0.01f;
            if (ExxoAvalonOriginsWorld.dungeonSide == -1)
            {
                num618 = 1f - num618;
                num617 = (int)((float)Main.maxTilesX * num618);
            }
            else
            {
                num617 = (int)((float)Main.maxTilesX * num618);
            }
            int num619 = (int)((double)Main.maxTilesY + Main.rockLayer) / 2;
            num617 += WorldGen.genRand.Next((int)(-100f * num616), (int)(101f * num616));
            num619 += WorldGen.genRand.Next((int)(-100f * num616), (int)(101f * num616));
            int num620 = num617;
            int num621 = num619;
            TileRunner(num617, num619, WorldGen.genRand.Next((int)(250f * num616), (int)(500f * num616)), WorldGen.genRand.Next(50, 150), ModContent.TileType<Tiles.TropicalMud>(), addTile: false, ExxoAvalonOriginsWorld.dungeonSide * 3);
            for (int num622 = 0; (float)num622 < 6f * num616; num622++)
            {
                TileRunner(num617 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), num619 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(63, 65));
            }
            mudWall = true;
            progress.Set(0.15f);
            num617 += WorldGen.genRand.Next((int)(-250f * num616), (int)(251f * num616));
            num619 += WorldGen.genRand.Next((int)(-150f * num616), (int)(151f * num616));
            int num623 = num617;
            int num624 = num619;
            int num625 = num617;
            int num626 = num619;
            TileRunner(num617, num619, WorldGen.genRand.Next((int)(250f * num616), (int)(500f * num616)), WorldGen.genRand.Next(50, 150), ModContent.TileType<Tiles.TropicalMud>());
            mudWall = false;
            for (int num627 = 0; (float)num627 < 6f * num616; num627++)
            {
                TileRunner(num617 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), num619 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(65, 67));
            }
            mudWall = true;
            progress.Set(0.3f);
            num617 += WorldGen.genRand.Next((int)(-400f * num616), (int)(401f * num616));
            num619 += WorldGen.genRand.Next((int)(-150f * num616), (int)(151f * num616));
            int num628 = num617;
            int num629 = num619;
            TileRunner(num617, num619, WorldGen.genRand.Next((int)(250f * num616), (int)(500f * num616)), WorldGen.genRand.Next(50, 150), ModContent.TileType<Tiles.TropicalMud>(), addTile: false, ExxoAvalonOriginsWorld.dungeonSide * -3);
            mudWall = false;
            for (int num630 = 0; (float)num630 < 6f * num616; num630++)
            {
                TileRunner(num617 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), num619 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(67, 69));
            }
            mudWall = true;
            progress.Set(0.45f);
            num617 = (num620 + num623 + num628) / 3;
            num619 = (num621 + num624 + num629) / 3;
            TileRunner(num617, num619, WorldGen.genRand.Next((int)(400f * num616), (int)(600f * num616)), 10000, ModContent.TileType<Tiles.TropicalMud>(), addTile: false, 0f, -20f, noYChange: true);
            TropicalRunner(num617, num619);
            progress.Set(0.6f);
            mudWall = false;
            for (int num631 = 0; num631 < Main.maxTilesX / 4; num631++)
            {
                num617 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                num619 = WorldGen.genRand.Next((int)WorldGen.worldSurface + 10, Main.maxTilesY - 200);
                while (Main.tile[num617, num619].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>() && Main.tile[num617, num619].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>())
                {
                    num617 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                    num619 = WorldGen.genRand.Next((int)WorldGen.worldSurface + 10, Main.maxTilesY - 200);
                }
                WorldGen.MudWallRunner(num617, num619);
            }
            num617 = num625;
            num619 = num626;
            for (int num632 = 0; (float)num632 <= 20f * num616; num632++)
            {
                progress.Set((60f + (float)num632 / num616) * 0.01f);
                num617 += WorldGen.genRand.Next((int)(-5f * num616), (int)(6f * num616));
                num619 += WorldGen.genRand.Next((int)(-5f * num616), (int)(6f * num616));
                TileRunner(num617, num619, WorldGen.genRand.Next(40, 100), WorldGen.genRand.Next(300, 500), ModContent.TileType<Tiles.TropicalMud>());
            }
            for (int num633 = 0; (float)num633 <= 10f * num616; num633++)
            {
                progress.Set((80f + (float)num633 / num616 * 2f) * 0.01f);
                num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                while (num617 < 1 || num617 >= Main.maxTilesX - 1 || num619 < 1 || num619 >= Main.maxTilesY - 1 || Main.tile[num617, num619].type != ModContent.TileType<Tiles.TropicalMud>())
                {
                    num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                    num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                }
                for (int num634 = 0; (float)num634 < 8f * num616; num634++)
                {
                    num617 += WorldGen.genRand.Next(-30, 31);
                    num619 += WorldGen.genRand.Next(-30, 31);
                    int type5 = -1;
                    if (WorldGen.genRand.Next(7) == 0)
                    {
                        type5 = -2;
                    }
                    TileRunner(num617, num619, WorldGen.genRand.Next(10, 20), WorldGen.genRand.Next(30, 70), type5);
                }
            }
            for (int num635 = 0; (float)num635 <= 300f * num616; num635++)
            {
                num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                while (num617 < 1 || num617 >= Main.maxTilesX - 1 || num619 < 1 || num619 >= Main.maxTilesY - 1 || Main.tile[num617, num619].type != ModContent.TileType<Tiles.TropicalMud>())
                {
                    num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                    num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                }
                TileRunner(num617, num619, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(5, 30), (ushort)ModContent.TileType<Tiles.TropicalStone>());
                if (WorldGen.genRand.Next(4) == 0)
                {
                    int type6 = WorldGen.genRand.Next(63, 69);
                    TileRunner(num617 + WorldGen.genRand.Next(-1, 2), num619 + WorldGen.genRand.Next(-1, 2), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(4, 8), type6);
                }
            }
            for (int num106 = 0; num106 < Main.maxTilesX; num106++)
            {
                for (int num107 = 0; num107 < Main.maxTilesY; num107++)
                {
                    if (Main.tile[num106, num107].active())
                    {
                        try
                        {
                            grassSpread = 0;
                            AvalonSpreadGrass(num106, num107, (ushort)ModContent.TileType<Tiles.TropicalMud>(), (ushort)ModContent.TileType<Tiles.TropicalGrass>(), true, 0);
                        }
                        catch
                        {
                            grassSpread = 0;
                            AvalonSpreadGrass(num106, num107, (ushort)ModContent.TileType<Tiles.TropicalMud>(), (ushort)ModContent.TileType<Tiles.TropicalGrass>(), false, 0);
                        }
                    }
                }
            }
        }
        public static void TropicalRunner(int i, int j)
        {
            double num = WorldGen.genRand.Next(5, 11);
            Vector2 vector = default(Vector2);
            vector.X = i;
            vector.Y = j;
            Vector2 vector2 = default(Vector2);
            vector2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            vector2.Y = (float)WorldGen.genRand.Next(10, 20) * 0.1f;
            int num2 = 0;
            bool flag = true;
            while (flag)
            {
                if ((double)vector.Y < Main.worldSurface)
                {
                    int value = (int)vector.X;
                    int value2 = (int)vector.Y;
                    value = Terraria.Utils.Clamp(value, 10, Main.maxTilesX - 10);
                    value2 = Terraria.Utils.Clamp(value2, 10, Main.maxTilesY - 10);
                    if (value2 < 5)
                    {
                        value2 = 5;
                    }
                    if (Main.tile[value, value2].wall == 0 && !Main.tile[value, value2].active() && Main.tile[value, value2 - 3].wall == 0 && !Main.tile[value, value2 - 3].active() && Main.tile[value, value2 - 1].wall == 0 && !Main.tile[value, value2 - 1].active() && Main.tile[value, value2 - 4].wall == 0 && !Main.tile[value, value2 - 4].active() && Main.tile[value, value2 - 2].wall == 0 && !Main.tile[value, value2 - 2].active() && Main.tile[value, value2 - 5].wall == 0 && !Main.tile[value, value2 - 5].active())
                    {
                        flag = false;
                    }
                }
                //WorldGen.JungleX = (int)vector.X;
                num += (double)((float)WorldGen.genRand.Next(-20, 21) * 0.1f);
                if (num < 5.0)
                {
                    num = 5.0;
                }
                if (num > 10.0)
                {
                    num = 10.0;
                }
                int value6 = (int)((double)vector.X - num * 0.5);
                int value3 = (int)((double)vector.X + num * 0.5);
                int value4 = (int)((double)vector.Y - num * 0.5);
                int value5 = (int)((double)vector.Y + num * 0.5);
                int num4 = Terraria.Utils.Clamp(value6, 10, Main.maxTilesX - 10);
                value3 = Terraria.Utils.Clamp(value3, 10, Main.maxTilesX - 10);
                value4 = Terraria.Utils.Clamp(value4, 10, Main.maxTilesY - 10);
                value5 = Terraria.Utils.Clamp(value5, 10, Main.maxTilesY - 10);
                for (int k = num4; k < value3; k++)
                {
                    for (int l = value4; l < value5; l++)
                    {
                        if ((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < num * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
                        {
                            WorldGen.KillTile(k, l);
                        }
                    }
                }
                num2++;
                if (num2 > 10 && WorldGen.genRand.Next(50) < num2)
                {
                    num2 = 0;
                    int num3 = -2;
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        num3 = 2;
                    }
                    TileRunner((int)vector.X, (int)vector.Y, WorldGen.genRand.Next(3, 20), WorldGen.genRand.Next(10, 100), -1, addTile: false, num3);
                }
                vector += vector2;
                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.01f;
                if (vector2.Y > 0f)
                {
                    vector2.Y = 0f;
                }
                if (vector2.Y < -2f)
                {
                    vector2.Y = -2f;
                }
                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
                if (vector.X < (float)(i - 200))
                {
                    vector2.X += (float)WorldGen.genRand.Next(5, 21) * 0.1f;
                }
                if (vector.X > (float)(i + 200))
                {
                    vector2.X -= (float)WorldGen.genRand.Next(5, 21) * 0.1f;
                }
                if ((double)vector2.X > 1.5)
                {
                    vector2.X = 1.5f;
                }
                if ((double)vector2.X < -1.5)
                {
                    vector2.X = -1.5f;
                }
            }
        }
        public static void TileRunner(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f, bool noYChange = false, bool overRide = true)
        {
            double num = strength;
            float num2 = steps;
            Vector2 vector = default(Vector2);
            vector.X = i;
            vector.Y = j;
            Vector2 vector2 = default(Vector2);
            vector2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            vector2.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            if (speedX != 0f || speedY != 0f)
            {
                vector2.X = speedX;
                vector2.Y = speedY;
            }
            bool flag = type == 368;
            bool flag2 = type == 367;
            while (num > 0.0 && num2 > 0f)
            {
                if (vector.Y < 0f && num2 > 0f && type == ModContent.TileType<Tiles.TropicalMud>())
                {
                    num2 = 0f;
                }
                num = strength * (double)(num2 / (float)steps);
                num2 -= 1f;
                int num3 = (int)((double)vector.X - num * 0.5);
                int num4 = (int)((double)vector.X + num * 0.5);
                int num5 = (int)((double)vector.Y - num * 0.5);
                int num6 = (int)((double)vector.Y + num * 0.5);
                if (num3 < 1)
                {
                    num3 = 1;
                }
                if (num4 > Main.maxTilesX - 1)
                {
                    num4 = Main.maxTilesX - 1;
                }
                if (num5 < 1)
                {
                    num5 = 1;
                }
                if (num6 > Main.maxTilesY - 1)
                {
                    num6 = Main.maxTilesY - 1;
                }
                for (int k = num3; k < num4; k++)
                {
                    for (int l = num5; l < num6; l++)
                    {
                        if (!((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015)))
                        {
                            continue;
                        }
                        if (mudWall && (double)l > Main.worldSurface && Main.tile[k, l - 1].wall != 2 && l < Main.maxTilesY - 210 - WorldGen.genRand.Next(3))
                        {
                            if (l > WorldGen.lavaLine - WorldGen.genRand.Next(0, 4) - 50)
                            {
                                if (Main.tile[k, l - 1].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>() && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>() && Main.tile[k - 1, l].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>() && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>())
                                {
                                    WorldGen.PlaceWall(k, l, (ushort)ModContent.WallType<Walls.TropicalMudWall>(), mute: true);
                                }
                            }
                            else if (Main.tile[k, l - 1].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>() && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>() && Main.tile[k - 1, l].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>() && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>())
                            {
                                WorldGen.PlaceWall(k, l, (ushort)ModContent.WallType<Walls.TropicalGrassWall>(), mute: true);
                            }
                        }
                        if (type < 0)
                        {
                            if (type == -2 && Main.tile[k, l].active() && (l < WorldGen.waterLine || l > WorldGen.lavaLine))
                            {
                                Main.tile[k, l].liquid = byte.MaxValue;
                                if (l > WorldGen.lavaLine)
                                {
                                    Main.tile[k, l].lava(lava: true);
                                }
                            }
                            Main.tile[k, l].active(active: false);
                            continue;
                        }
                        if (flag && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.01))
                        {
                            WorldGen.PlaceWall(k, l, 180, mute: true);
                        }
                        if (flag2 && (double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < strength * 0.3 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.01))
                        {
                            WorldGen.PlaceWall(k, l, 178, mute: true);
                        }
                        if (overRide || !Main.tile[k, l].active())
                        {
                            Tile tile = Main.tile[k, l];
                            bool flag3 = false;
                            flag3 = Main.tileStone[type] && tile.type != 1;
                            if (!TileID.Sets.CanBeClearedDuringGeneration[tile.type])
                            {
                                flag3 = true;
                            }
                            switch (tile.type)
                            {
                                case 53:
                                    if (type == 40)
                                    {
                                        flag3 = true;
                                    }
                                    if ((double)l < Main.worldSurface && !(type == ModContent.TileType<Tiles.TropicalMud>() || type == TileID.Mud))
                                    {
                                        flag3 = true;
                                    }
                                    break;
                                case 45:
                                case 147:
                                case 189:
                                case 190:
                                case 196:
                                    flag3 = true;
                                    break;
                                case 396:
                                case 397:
                                    flag3 = !TileID.Sets.Ore[type];
                                    break;
                                case 1:
                                    if ((type == TileID.Mud || type == ModContent.TileType<Tiles.TropicalMud>()) && (double)l < Main.worldSurface + (double)WorldGen.genRand.Next(-50, 50))
                                    {
                                        flag3 = true;
                                    }
                                    break;
                                case 367:
                                case 368:
                                    if (type == TileID.Mud || type == ModContent.TileType<Tiles.TropicalMud>())
                                    {
                                        flag3 = true;
                                    }
                                    break;
                            }
                            if (!flag3)
                            {
                                tile.type = (ushort)type;
                            }
                        }
                        if (addTile)
                        {
                            Main.tile[k, l].active(active: true);
                            Main.tile[k, l].liquid = 0;
                            Main.tile[k, l].lava(lava: false);
                        }
                        if (noYChange && (double)l < Main.worldSurface && type != ModContent.TileType<Tiles.TropicalMud>())
                        {
                            Main.tile[k, l].wall = 2;
                        }
                        if ((type == TileID.Mud || type == ModContent.TileType<Tiles.TropicalMud>()) && l > WorldGen.waterLine && Main.tile[k, l].liquid > 0)
                        {
                            Main.tile[k, l].lava(lava: false);
                            Main.tile[k, l].liquid = 0;
                        }
                    }
                }
                vector += vector2;
                if (num > 50.0)
                {
                    vector += vector2;
                    num2 -= 1f;
                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (num > 100.0)
                    {
                        vector += vector2;
                        num2 -= 1f;
                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (num > 150.0)
                        {
                            vector += vector2;
                            num2 -= 1f;
                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if (num > 200.0)
                            {
                                vector += vector2;
                                num2 -= 1f;
                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                if (num > 250.0)
                                {
                                    vector += vector2;
                                    num2 -= 1f;
                                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    if (num > 300.0)
                                    {
                                        vector += vector2;
                                        num2 -= 1f;
                                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        if (num > 400.0)
                                        {
                                            vector += vector2;
                                            num2 -= 1f;
                                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            if (num > 500.0)
                                            {
                                                vector += vector2;
                                                num2 -= 1f;
                                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                if (num > 600.0)
                                                {
                                                    vector += vector2;
                                                    num2 -= 1f;
                                                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    if (num > 700.0)
                                                    {
                                                        vector += vector2;
                                                        num2 -= 1f;
                                                        vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        if (num > 800.0)
                                                        {
                                                            vector += vector2;
                                                            num2 -= 1f;
                                                            vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            if (num > 900.0)
                                                            {
                                                                vector += vector2;
                                                                num2 -= 1f;
                                                                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (vector2.X > 1f)
                {
                    vector2.X = 1f;
                }
                if (vector2.X < -1f)
                {
                    vector2.X = -1f;
                }
                if (!noYChange)
                {
                    vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (vector2.Y > 1f)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector2.Y < -1f)
                    {
                        vector2.Y = -1f;
                    }
                }
                else if (type != ModContent.TileType<Tiles.TropicalMud>() && num < 3.0)
                {
                    if (vector2.Y > 1f)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector2.Y < -1f)
                    {
                        vector2.Y = -1f;
                    }
                }
                if ((type == TileID.Mud || type == ModContent.TileType<Tiles.TropicalMud>()) && !noYChange)
                {
                    if ((double)vector2.Y > 0.5)
                    {
                        vector2.Y = 0.5f;
                    }
                    if ((double)vector2.Y < -0.5)
                    {
                        vector2.Y = -0.5f;
                    }
                    if ((double)vector.Y < Main.rockLayer + 100.0)
                    {
                        vector2.Y = 1f;
                    }
                    if (vector.Y > (float)(Main.maxTilesY - 300))
                    {
                        vector2.Y = -1f;
                    }
                }
            }
        }
        // TODO: Replace with WorldGen.AddGenerationPass("Spreading Grass", delegate(GenerationProgress progress, GameConfiguration passConfig)
        public static void AvalonSpreadGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true, byte color = 0)
        {
            try
            {
                if (WorldGen.InWorld(i, j, 1))
                {
                    if ((int)Main.tile[i, j].type == dirt && Main.tile[i, j].active() && ((double)j < Main.worldSurface || dirt != 0))
                    {
                        int num = i - 1;
                        int num2 = i + 2;
                        int num3 = j - 1;
                        int num4 = j + 2;
                        if (num < 0)
                        {
                            num = 0;
                        }
                        if (num2 > Main.maxTilesX)
                        {
                            num2 = Main.maxTilesX;
                        }
                        if (num3 < 0)
                        {
                            num3 = 0;
                        }
                        if (num4 > Main.maxTilesY)
                        {
                            num4 = Main.maxTilesY;
                        }
                        bool flag = true;
                        for (int k = num; k < num2; k++)
                        {
                            for (int l = num3; l < num4; l++)
                            {
                                if (!Main.tile[k, l].active() || !Main.tileSolid[(int)Main.tile[k, l].type])
                                {
                                    flag = false;
                                }
                                if (Main.tile[k, l].lava() && Main.tile[k, l].liquid > 0)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        if (!flag && TileID.Sets.CanBeClearedDuringGeneration[(int)Main.tile[i, j].type])
                        {
                            if (grass != 23 || Main.tile[i, j - 1].type != 27)
                            {
                                if (grass != 199 || Main.tile[i, j - 1].type != 27)
                                {
                                    Main.tile[i, j].type = (ushort)grass;
                                    Main.tile[i, j].color(color);
                                    for (int m = num; m < num2; m++)
                                    {
                                        for (int n = num3; n < num4; n++)
                                        {
                                            if (Main.tile[m, n].active() && (int)Main.tile[m, n].type == dirt)
                                            {
                                                try
                                                {
                                                    if (repeat && grassSpread < 1000)
                                                    {
                                                        grassSpread++;
                                                        AvalonSpreadGrass(m, n, dirt, grass, true, 0);
                                                        grassSpread--;
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
