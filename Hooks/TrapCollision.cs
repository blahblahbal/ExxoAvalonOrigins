using ExxoAvalonOrigins.Items.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class TrapCollision
    {
        public static Vector2 OnHurtTiles(On.Terraria.Collision.orig_HurtTiles orig, Vector2 Position,
            Vector2 Velocity, int Width, int Height, bool fireImmune = false)
        {
            Vector2 output = orig(Position, Velocity, Width, Height, fireImmune);
            Vector2 vector = Position;
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
                    if (Main.tile[i, j] != null && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].inActive() && Main.tile[i, j].HasTile && (Main.tile[i, j].TileType == ModContent.TileType<Tiles.PoisonSpike>() || Main.tile[i, j].TileType == ModContent.TileType<Tiles.VenomSpike>() || Main.tile[i, j].TileType == TileID.Spikes || Main.tile[i, j].TileType == TileID.WoodenSpikes))
                    {
                        Vector2 vector2;
                        vector2.X = i * 16;
                        vector2.Y = j * 16;
                        int num5 = 0;
                        int type = (int)Main.tile[i, j].TileType;
                        int num6 = 16;
                        if (Main.tile[i, j]IsHalfBlock)
                        {
                            vector2.Y += 8f;
                            num6 -= 8;
                        }
                        if (vector.X + Width >= vector2.X && vector.X <= vector2.X + 16f && vector.Y + Height >= vector2.Y && vector.Y <= (vector2.Y + num6) + 0.01)
                        {
                            int num9 = 1;
                            if (vector.X + Width / 2 < vector2.X + 8f)
                            {
                                num9 = -1;
                            }
                            if (!fireImmune && (type == 37 || type == 58 || type == 76))
                            {
                                num5 = 20;
                            }
                            if (!Main.LocalPlayer.Avalon().trapImmune && !Main.LocalPlayer.Avalon().spikeImmune && type == TileID.Spikes)
                            {
                                num5 = 40;
                            }
                            if (!Main.LocalPlayer.Avalon().trapImmune && !Main.LocalPlayer.Avalon().spikeImmune && type == TileID.WoodenSpikes)
                            {
                                num5 = 60;
                            }
                            if (!Main.LocalPlayer.Avalon().trapImmune && !Main.LocalPlayer.Avalon().spikeImmune && type == ModContent.TileType<Tiles.PoisonSpike>())
                            {
                                num5 = 35;
                                Main.player[Main.myPlayer].AddBuff(BuffID.Poisoned, 180, true);
                            }
                            if (!Main.LocalPlayer.Avalon().trapImmune && !Main.LocalPlayer.Avalon().spikeImmune && type == ModContent.TileType<Tiles.VenomSpike>())
                            {
                                num5 = 90;
                                Main.player[Main.myPlayer].AddBuff(BuffID.Venom, 180, true);
                            }
                            return new Vector2(num9, num5);
                        }
                    }
                }
            }
            return output;
        }
    }
}
