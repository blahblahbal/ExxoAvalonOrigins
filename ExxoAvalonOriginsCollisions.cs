using ExxoAvalonOrigins.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using BloodiedSpike = ExxoAvalonOrigins.Tiles.BloodiedSpike;
using NastySpike = ExxoAvalonOrigins.Tiles.NastySpike;

namespace ExxoAvalonOrigins
{
    public class ExxoAvalonOriginsCollisions
    {
        public static bool SolidCollisionArma(Vector2 Position, int Width, int Height)
        {
            int num = (int)(Position.X / 16f) - 1;
            int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
            int num3 = (int)(Position.Y / 16f) - 1;
            int num4 = (int)((Position.Y + (float)Height) / 16f) + 4;
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
            for (int i = num; i < num2; i++)
            {
                for (int j = num3; j < num4; j++)
                {
                    if (Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
                    {
                        Vector2 vector;
                        vector.X = (float)(i * 16);
                        vector.Y = (float)(j * 16);
                        int num5 = 16;
                        if (Main.tile[i, j].halfBrick())
                        {
                            vector.Y += 8f;
                            num5 -= 8;
                        }
                        if (Position.Y + (float)Height >= vector.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool SpikeCollision(Vector2 Position, int Width, int Height)
        {
            int num = (int)(Position.X / 16f) - 1;
            int num2 = (int)((Position.X + (float)Width) / 16f) + 2;
            int num3 = (int)(Position.Y / 16f) - 1;
            int num4 = (int)((Position.Y + (float)Height) / 16f) + 2;
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
            for (int i = num; i < num2; i++)
            {
                for (int j = num3; j < num4; j++)
                {
                    if ((Main.tile[i, j] != null && !Main.tile[i, j].inActive() && Main.tile[i, j].active() && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type] && Main.tile[i, j].type == ModContent.TileType<DemonSpikescale>()) || Main.tile[i, j].type == ModContent.TileType<BloodiedSpike>())
                    {
                        Vector2 vector;
                        vector.X = (float)(i * 16);
                        vector.Y = (float)(j * 16);
                        int num5 = 16;
                        if (Main.tile[i, j].halfBrick())
                        {
                            vector.Y += 8f;
                            num5 -= 8;
                        }
                        if (Position.X + (float)Width > vector.X && Position.X < vector.X + 16f && Position.Y + (float)Height > vector.Y && Position.Y < vector.Y + (float)num5)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool SpikeCollision2(Vector2 Position, int Width, int Height)
        {
            int num = (int)((Position.X - 2f) / 16f);
            int num2 = (int)((Position.X + (float)Width) / 16f);
            int num3 = (int)((Position.Y - 2f) / 16f);
            int num4 = (int)((Position.Y + (float)Height) / 16f);
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
            for (int i = num; i <= num2; i++)
            {
                for (int j = num3; j <= num4; j++)
                {
                    if (Main.tile[i, j] != null && Main.tile[i, j].active() && (Main.tile[i, j].type == ModContent.TileType<DemonSpikescale>() || Main.tile[i, j].type == ModContent.TileType<BloodiedSpike>() || Main.tile[i, j].type == ModContent.TileType<NastySpike>()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}