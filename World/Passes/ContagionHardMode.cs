using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using ExxoAvalonOrigins.Tiles;
using Microsoft.Xna.Framework;
using Terraria.Utilities;

namespace ExxoAvalonOrigins.World.Passes
{
    class ContagionHardMode
    {
        public static void Method(GenerationProgress progress)
        {
            WorldGen.IsGeneratingHardMode = true;
            if (Main.rand == null)
                Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
            float num1 = (float)Main.rand.Next(300, 400) * (1f / 1000f);
            float num2 = (float)Main.rand.Next(200, 300) * (1f / 1000f);
            int i1 = (int)((double)Main.maxTilesX * (double)num1);
            int i2 = (int)((double)Main.maxTilesX * (1.0 - (double)num1));
            int num3 = 1;
            if (Main.rand.Next(2) == 0)
            {
                i2 = (int)((double)Main.maxTilesX * (double)num1);
                i1 = (int)((double)Main.maxTilesX * (1.0 - (double)num1));
                num3 = -1;
            }
            int num4 = 1;
            if (WorldGen.dungeonX < Main.maxTilesX / 2)
                num4 = -1;
            if (num4 < 0)
            {
                if (i2 < i1)
                    i2 = (int)((double)Main.maxTilesX * num2);
                else
                    i1 = (int)((double)Main.maxTilesX * num2);
            }
            else if (i2 > i1)
                i2 = (int)(Main.maxTilesX * (1.0 - num2));
            else
                i1 = (int)(Main.maxTilesX * (1.0 - num2));
            GERunner(i1, 0, (3 * num3), 5f, true);
            GERunner(i2, 0, (3 * -num3), 5f, false);
        }
        public static void GERunner(int i, int j, float speedX = 0f, float speedY = 0f, bool good = true)
        {
            if (Main.rand == null)
            {
                Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
            }
            int num = Main.rand.Next(200, 250);
            float num2 = Main.maxTilesX / 4200;
            num = (int)((float)num * num2);
            double num3 = num;
            Vector2 vector = default(Vector2);
            vector.X = i;
            vector.Y = j;
            Vector2 vector2 = default(Vector2);
            vector2.X = (float)Main.rand.Next(-10, 11) * 0.1f;
            vector2.Y = (float)Main.rand.Next(-10, 11) * 0.1f;
            if (speedX != 0f || speedY != 0f)
            {
                vector2.X = speedX;
                vector2.Y = speedY;
            }
            bool flag = true;
            while (flag)
            {
                int num4 = (int)((double)vector.X - num3 * 0.5);
                int num5 = (int)((double)vector.X + num3 * 0.5);
                int num6 = (int)((double)vector.Y - num3 * 0.5);
                int num7 = (int)((double)vector.Y + num3 * 0.5);
                if (num4 < 0)
                {
                    num4 = 0;
                }
                if (num5 > Main.maxTilesX)
                {
                    num5 = Main.maxTilesX;
                }
                if (num6 < 0)
                {
                    num6 = 0;
                }
                if (num7 > Main.maxTilesY)
                {
                    num7 = Main.maxTilesY;
                }
                for (int k = num4; k < num5; k++)
                {
                    for (int l = num6; l < num7; l++)
                    {
                        if (!((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < (double)num * 0.5 * (1.0 + (double)Main.rand.Next(-10, 11) * 0.015)))
                        {
                            continue;
                        }
                        if (good)
                        {
                            if (Main.tile[k, l].wall == 63 || Main.tile[k, l].wall == 65 || Main.tile[k, l].wall == 66 || Main.tile[k, l].wall == 68 || Main.tile[k, l].wall == 69 || Main.tile[k, l].wall == 81 || Main.tile[k, l].wall == (ushort)ModContent.WallType<Walls.ChunkstoneWall>())
                            {
                                Main.tile[k, l].wall = 70;
                            }
                            else if (Main.tile[k, l].wall == 216 || Main.tile[k, l].wall == (ushort)ModContent.WallType<Walls.ContagionNaturalWall1>())
                            {
                                Main.tile[k, l].wall = 219;
                            }
                            else if (Main.tile[k, l].wall == 187 || Main.tile[k, l].wall == (ushort)ModContent.WallType<Walls.ContagionNaturalWall2>())
                            {
                                Main.tile[k, l].wall = 222;
                            }
                            if (Main.tile[k, l].active() && !Main.tile[k, l - 1].active() && !Main.tile[k, l - 1].lava() && Main.tile[k, l - 1].type != TileID.Containers && Main.tile[k, l - 1].type != TileID.Containers2 && l < Main.maxTilesY - 200 && Main.rand.Next(150) == 0) // hallowed altar gen
                            {
                                WorldGen.Place3x2(k, l - 1, (ushort)ModContent.TileType<Tiles.HallowedAltar>());
                            }
                            if (Main.tile[k, l].wall == 3 || Main.tile[k, l].wall == 83)
                            {
                                Main.tile[k, l].wall = 28;
                            }
                            if (Main.tile[k, l].type == 2 || Main.tile[k, l].type == (ushort)ModContent.TileType<Ickgrass>())
                            {
                                Main.tile[k, l].type = 109;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 1 || Main.tile[k, l].type == (ushort)ModContent.TileType<Chunkstone>())
                            {
                                Main.tile[k, l].type = 117;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 123 || Main.tile[k, l].type == (ushort)ModContent.TileType<Snotsand>())
                            {
                                Main.tile[k, l].type = 116;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 23 || Main.tile[k, l].type == 199 || Main.tile[k, l].type == (ushort)ModContent.TileType<Ickgrass>())
                            {
                                Main.tile[k, l].type = 109;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 25 || Main.tile[k, l].type == 203 || Main.tile[k, l].type == (ushort)ModContent.TileType<Chunkstone>())
                            {
                                Main.tile[k, l].type = 117;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 112 || Main.tile[k, l].type == 234 || Main.tile[k, l].type == (ushort)ModContent.TileType<Snotsand>())
                            {
                                Main.tile[k, l].type = 116;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 161 || Main.tile[k, l].type == 163 || Main.tile[k, l].type == 200 || Main.tile[k, l].type == (ushort)ModContent.TileType<YellowIce>())
                            {
                                Main.tile[k, l].type = 164;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 396 || Main.tile[k, l].type == (ushort)ModContent.TileType<Snotsandstone>())
                            {
                                Main.tile[k, l].type = 403;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 397 || Main.tile[k, l].type == (ushort)ModContent.TileType<HardenedSnotsand>())
                            {
                                Main.tile[k, l].type = 402;
                                Utils.SquareTileFrame(k, l);
                            }
                        }
                        else if (ExxoAvalonOriginsWorld.contaigon)
                        {
                            if (Main.tile[k, l].wall == 63 || Main.tile[k, l].wall == 65 || Main.tile[k, l].wall == 66 || Main.tile[k, l].wall == 68)
                            {
                                Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();
                            }
                            else if (Main.tile[k, l].wall == 216)
                            {
                                Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ContagionNaturalWall1>();
                            }
                            else if (Main.tile[k, l].wall == 187)
                            {
                                Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ContagionNaturalWall2>();
                            }
                            if (Main.tile[k, l].type == 2)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Ickgrass>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 1)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Chunkstone>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 123)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsand>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 109)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Ickgrass>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 117)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Chunkstone>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 116)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsand>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 161 || Main.tile[k, l].type == 164)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<YellowIce>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 396)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsandstone>();
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 397)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<HardenedSnotsand>();
                                Utils.SquareTileFrame(k, l);
                            }
                        }
                        else
                        {
                            if (Main.tile[k, l].wall == 63 || Main.tile[k, l].wall == 65 || Main.tile[k, l].wall == 66 || Main.tile[k, l].wall == 68)
                            {
                                Main.tile[k, l].wall = 69;
                            }
                            else if (Main.tile[k, l].wall == 216)
                            {
                                Main.tile[k, l].wall = 217;
                            }
                            else if (Main.tile[k, l].wall == 187)
                            {
                                Main.tile[k, l].wall = 220;
                            }
                            if (Main.tile[k, l].type == 2)
                            {
                                Main.tile[k, l].type = 23;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 1)
                            {
                                Main.tile[k, l].type = 25;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 123)
                            {
                                Main.tile[k, l].type = 112;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 109)
                            {
                                Main.tile[k, l].type = 23;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 117)
                            {
                                Main.tile[k, l].type = 25;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 116)
                            {
                                Main.tile[k, l].type = 112;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 161 || Main.tile[k, l].type == 164)
                            {
                                Main.tile[k, l].type = 163;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 396)
                            {
                                Main.tile[k, l].type = 400;
                                Utils.SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 397)
                            {
                                Main.tile[k, l].type = 398;
                                Utils.SquareTileFrame(k, l);
                            }
                        }
                    }
                }
                vector += vector2;
                vector2.X += (float)Main.rand.Next(-10, 11) * 0.05f;
                if (vector2.X > speedX + 1f)
                {
                    vector2.X = speedX + 1f;
                }
                if (vector2.X < speedX - 1f)
                {
                    vector2.X = speedX - 1f;
                }
                if (vector.X < (float)(-num) || vector.Y < (float)(-num) || vector.X > (float)(Main.maxTilesX + num) || vector.Y > (float)(Main.maxTilesX + num))
                {
                    flag = false;
                }
            }
        }
    }
}
