using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;

namespace ExxoAvalonOrigins.Hooks
{
    internal static class CaesiumUnderworldBackground
    {
        public static void ILDoSelf(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchStloc(0)))
                return;

            c.Index++;
            c.EmitDelegate<Action>(() => // Transition thingy
            {
                if (Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneCaesium)
                {
                    ExxoAvalonOrigins.caesiumTransition += 0.05f;
                    if (ExxoAvalonOrigins.caesiumTransition > 1f)
                    {
                        ExxoAvalonOrigins.caesiumTransition = 1f;
                    }
                }
                else
                {
                    ExxoAvalonOrigins.caesiumTransition -= 0.05f;
                    if (ExxoAvalonOrigins.caesiumTransition < 0f)
                    {
                        ExxoAvalonOrigins.caesiumTransition = 0f;
                    }
                }
            });

            if (!c.TryGotoNext(i => i.MatchRet()))
                return;

            /*if (!c.TryGotoPrev(i => i.MatchCallvirt(out _)))
                return;

            c.Index++;
            c.Emit(OpCodes.Ldloc, 14);
            c.Emit(OpCodes.Ldloc, 15);
            c.Emit(OpCodes.Ldloc, 7);
            c.Emit(OpCodes.Ldloc, 8);
            c.EmitDelegate<Action<Vector2, int, Rectangle, float>>((vector3, num8, rectangle, num4) =>
            {
                Main.spriteBatch.Draw(Main.blackTileTexture,
                    new Rectangle((int)vector3.X, num8, (int)(rectangle.Width * num4), Math.Max(0, Main.screenHeight - num8)),
                    new Color(6, 5, 6) * ExxoAvalonOrigins.caesiumTransition);
            });

            if (!c.TryGotoPrev(i => i.MatchCallvirt(out _)))
                return;

            c.Index++;
            c.Emit(OpCodes.Ldloc, 14);
            c.Emit(OpCodes.Ldloc, 7);
            c.Emit(OpCodes.Ldloc, 8);
            c.EmitDelegate<Action<Vector2, Rectangle, float>>((vector3, rectangle, num4) =>
            {
                var caesiumBgs = new Texture2D[5];
                for (int i = 0; i < 4; i++)
                    caesiumBgs[i] = ExxoAvalonOrigins.mod.GetTexture("Backgrounds/Caesium" + (i + 1).ToString());
                for (int num2 = 4; num2 >= 0; num2--)
                {
                    Texture2D texture2D = caesiumBgs[num2];
                    Rectangle rectangle2 = rectangle;
                    if (num2 == 1)
                    {
                        int num5 = (int)(Main.GlobalTime * 8f) % 4;
                        rectangle = new Rectangle((num5 >> 1) * (texture2D.Width >> 1), num5 % 2 * (texture2D.Height >> 1), texture2D.Width >> 1, texture2D.Height >> 1);
                    }
                    Main.spriteBatch.Draw(texture2D, vector3, rectangle, Color.White * ExxoAvalonOrigins.caesiumTransition, 0f, Vector2.Zero, num4, SpriteEffects.None, 0f);
                }
            });*/

            if (!c.TryGotoPrev(i => i.MatchBge(out _)))
                return;

            c.Index++;
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<bool>>((flat) =>
            {
                Vector2 vector = Main.screenPosition + new Vector2((float)(Main.screenWidth >> 1), (float)(Main.screenHeight >> 1));
                float num = (Main.GameViewMatrix.Zoom.Y - 1f) * 0.5f * 200f;
                Texture2D[] caesiumBgs = new Texture2D[5];
                for (int i = 0; i <= 4; i++)
                    caesiumBgs[i] = ExxoAvalonOrigins.mod.GetTexture("Backgrounds/Caesium" + (i + 1).ToString());

                for (int num2 = 4; num2 >= 0; num2--)
                {
                    Texture2D texture2D = caesiumBgs[num2];
                    Vector2 value = new Vector2((float)texture2D.Width, (float)texture2D.Height) * 0.5f;
                    float num3 = flat ? 1f : ((float)(num2 * 2) + 3f);
                    Vector2 vector2 = new Vector2(1f / num3);
                    Rectangle rectangle = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
                    float num4 = 1.3f;
                    Vector2 zero = Vector2.Zero;
                    switch (num2)
                    {
                        case 1:
                            {
                                int num5 = (int)(Main.GlobalTime * 8f) % 4;
                                rectangle = new Rectangle((num5 >> 1) * (texture2D.Width >> 1), num5 % 2 * (texture2D.Height >> 1), texture2D.Width >> 1, texture2D.Height >> 1);
                                value *= 0.5f;
                                zero.Y += 75f;
                                break;
                            }
                        case 2:
                        case 3:
                            zero.Y += 75f;
                            break;
                        case 4:
                            num4 = 0.5f;
                            zero.Y -= 25f;
                            break;
                    }
                    if (flat)
                    {
                        num4 *= 1.5f;
                    }
                    value *= num4;
                    if (flat)
                    {
                        zero.Y += (float)(caesiumBgs[0].Height >> 1) * 1.3f - value.Y;
                    }
                    zero.Y -= num;
                    float num6 = num4 * (float)rectangle.Width;
                    int num7 = (int)((vector.X * vector2.X - value.X + zero.X - (float)(Main.screenWidth >> 1)) / num6);
                    for (int i = num7 - 2; i < num7 + 4 + (int)((float)Main.screenWidth / num6); i++)
                    {
                        Vector2 vector3 = (new Vector2((float)i * num4 * ((float)rectangle.Width / vector2.X), (float)(Main.maxTilesY - 200) * 16f) + value - vector) * vector2 + vector - Main.screenPosition - value + zero;
                        Main.spriteBatch.Draw(texture2D, vector3, rectangle, Color.White * ExxoAvalonOrigins.caesiumTransition, 0f, Vector2.Zero, num4, SpriteEffects.None, 0f);
                        if (num2 == 0)
                        {
                            int num8 = (int)(vector3.Y + (float)rectangle.Height * num4);
                            Main.spriteBatch.Draw(Main.blackTileTexture, new Rectangle((int)vector3.X, num8, (int)((float)rectangle.Width * num4), Math.Max(0, Main.screenHeight - num8)), new Color(6, 5, 6) * ExxoAvalonOrigins.caesiumTransition);
                        }
                    }
                }
            });
        }
    }
}
