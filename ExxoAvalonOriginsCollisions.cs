using ExxoAvalonOrigins.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using BloodiedSpike = ExxoAvalonOrigins.Tiles.BloodiedSpike;
using NastySpike = ExxoAvalonOrigins.Tiles.NastySpike;
using Terraria.Audio;

namespace ExxoAvalonOrigins;

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
                if (Main.tile[i, j] != null && !Main.tile[i, j].IsActuated && Main.tile[i, j].HasTile && Main.tileSolid[(int)Main.tile[i, j].TileType] && !Main.tileSolidTop[(int)Main.tile[i, j].TileType])
                {
                    Vector2 vector;
                    vector.X = (float)(i * 16);
                    vector.Y = (float)(j * 16);
                    int num5 = 16;
                    if (Main.tile[i, j].IsHalfBlock)
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
                if ((Main.tile[i, j] != null && !Main.tile[i, j].IsActuated && Main.tile[i, j].HasTile && Main.tileSolid[(int)Main.tile[i, j].TileType] && !Main.tileSolidTop[(int)Main.tile[i, j].TileType] && Main.tile[i, j].TileType == ModContent.TileType<DemonSpikescale>()) || Main.tile[i, j].TileType == ModContent.TileType<BloodiedSpike>())
                {
                    Vector2 vector;
                    vector.X = (float)(i * 16);
                    vector.Y = (float)(j * 16);
                    int num5 = 16;
                    if (Main.tile[i, j].IsHalfBlock)
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
                if (Main.tile[i, j] != null && Main.tile[i, j].HasTile && (Main.tile[i, j].TileType == ModContent.TileType<DemonSpikescale>() || Main.tile[i, j].TileType == ModContent.TileType<BloodiedSpike>() || Main.tile[i, j].TileType == ModContent.TileType<NastySpike>()))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static bool PlayerSensor(Vector2 Position, int Width, int Height, Vector2 oldPosition)
    {
        int num = (int)(Position.X / 16f) - 1;
        int num2 = (int)((Position.X + Width) / 16f) + 2;
        int num3 = (int)(Position.Y / 16f) - 1;
        int num4 = (int)((Position.Y + Height) / 16f) + 2;
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
        if (Main.tile[num, num3].TileType == ModContent.TileType<PlayerSensor>() ^ Main.tile[num + 1, num3].TileType == ModContent.TileType<PlayerSensor>() ^
            Main.tile[num, num3 + 1].TileType == ModContent.TileType<PlayerSensor>() ^ Main.tile[num + 1, num3 + 1].TileType == ModContent.TileType<PlayerSensor>() ^
            Main.tile[num, num3 + 2].TileType == ModContent.TileType<PlayerSensor>() ^ Main.tile[num + 1, num3 + 2].TileType == ModContent.TileType<PlayerSensor>())
        {
            SoundEngine.PlaySound(28, num * 16, num3 * 16, 0);
            Wiring.TripWire(num, num3, 1, 1);
            NetMessage.SendData(59, -1, -1, null, num, num3, 0f, 0f, 0);
            return true;
        }
        //for (int i = num; i < num2; i++)
        //{
        //    for (int j = num3; j < num4; j++)
        //    {
        //        if (Main.tile[i, j] != null && Main.tile[i, j].HasTile && Main.tile[i, j].type == ModContent.TileType<PlayerSensor>())
        //        {
        //            Vector2 vector;
        //            vector.X = i * 16;
        //            vector.Y = j * 16 + 12;
        //            if (Position.X + Width > vector.X && Position.X < vector.X + 16f && Position.Y + Height > vector.Y && Position.Y < vector.Y)
        //            {
        //                if (oldPosition.X + Width <= vector.X || oldPosition.X >= vector.X + 16f || oldPosition.Y <= vector.Y || oldPosition.Y >= vector.Y)
        //                {
        //                    Main.PlaySound(28, i * 16, j * 16, 0);
        //                    Wiring.TripWire(i, j, 1, 1);
        //                    NetMessage.SendData(59, -1, -1, null, i, j, 0f, 0f, 0);
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //}
        return false;
    }
}
