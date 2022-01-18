using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class SnowHardMode
    {
        public static void Method(GenerationProgress progress)
        {
            for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); i++)
            {
                IceSnowOreRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 200), WorldGen.genRand.Next(6, 9), WorldGen.genRand.Next(6, 9), (ushort)ModContent.TileType<Tiles.Ores.FeroziumOre>());
            }
        }
        /// <summary>
        /// Identical to WorldGen.OreRunner() except only replaces ice and snow.
        /// </summary>
        /// <param name="i">The x coordinate of the tile to start the generation.</param>
        /// <param name="j">The y coordinate of the tile to start the generation.</param>
        /// <param name="strength">Unsure.</param>
        /// <param name="steps">Unsure.</param>
        /// <param name="type">The type of the tile to generate.</param>
        public static void IceSnowOreRunner(int i, int j, double strength, int steps, ushort type)
        {
            double num = strength;
            float num2 = (float)steps;
            Vector2 value;
            value.X = (float)i;
            value.Y = (float)j;
            Vector2 value2;
            value2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            value2.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            while (num > 0.0 && num2 > 0f)
            {
                if (value.Y < 0f && num2 > 0f && type == 59)
                {
                    num2 = 0f;
                }
                num = strength * (double)(num2 / (float)steps);
                num2 -= 1f;
                int num3 = (int)((double)value.X - num * 0.5);
                int num4 = (int)((double)value.X + num * 0.5);
                int num5 = (int)((double)value.Y - num * 0.5);
                int num6 = (int)((double)value.Y + num * 0.5);
                if (num3 < 0)
                {
                    num3 = 0;
                }
                if (num4 > Main.maxTilesX)
                {
                    num4 = Main.maxTilesX;
                }
                if (num5 < 0)
                {
                    num5 = 0;
                }
                if (num6 > Main.maxTilesY)
                {
                    num6 = Main.maxTilesY;
                }
                for (int k = num3; k < num4; k++)
                {
                    for (int l = num5; l < num6; l++)
                    {
                        if ((double)(Math.Abs((float)k - value.X) + Math.Abs((float)l - value.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015) && Main.tile[k, l].active() && (Main.tile[k, l].type == TileID.SnowBlock || Main.tile[k, l].type == TileID.IceBlock || Main.tile[k, l].type == TileID.FleshIce || Main.tile[k, l].type == TileID.CorruptIce || Main.tile[k, l].type == TileID.HallowedIce || Main.tile[k, l].type == ModContent.TileType<Tiles.YellowIce>()))
                        {
                            Main.tile[k, l].type = type;
                            WorldGen.SquareTileFrame(k, l, true);
                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendTileSquare(-1, k, l, 1);
                            }
                        }
                    }
                }
                value += value2;
                value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (value2.X > 1f)
                {
                    value2.X = 1f;
                }
                if (value2.X < -1f)
                {
                    value2.X = -1f;
                }
            }
        }
    }
}
