using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using System.Collections.Generic;
using Terraria.ModLoader;
using System.Reflection;

namespace ExxoAvalonOrigins.Hooks
{
    /// <summary>
    /// REDO/TODO: Old Backgrounds
    /// </summary>
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

            // Old Code
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
                Vector2 vector = Main.screenPosition + new Vector2(Main.screenWidth >> 1, Main.screenHeight >> 1);
                float num = (Main.GameViewMatrix.Zoom.Y - 1f) * 0.5f * 200f;
                var caesiumBgs = new Texture2D[5];
                for (int i = 0; i <= 4; i++)
                    caesiumBgs[i] = ExxoAvalonOrigins.mod.GetTexture("Backgrounds/Caesium" + (i + 1).ToString());

                for (int num2 = 4; num2 >= 0; num2--)
                {
                    Texture2D texture2D = caesiumBgs[num2];
                    Vector2 value = new Vector2(texture2D.Width, texture2D.Height) * 0.5f;
                    float num3 = flat ? 1f : ((num2 * 2) + 3f);
                    var vector2 = new Vector2(1f / num3);
                    var rectangle = new Rectangle(0, 0, texture2D.Width, texture2D.Height);
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
                        zero.Y += ((caesiumBgs[0].Height >> 1) * 1.3f) - value.Y;
                    }
                    zero.Y -= num;
                    float num6 = num4 * rectangle.Width;
                    int num7 = (int)(((vector.X * vector2.X) - value.X + zero.X - (Main.screenWidth >> 1)) / num6);
                    for (int i = num7 - 2; i < num7 + 4 + (int)(Main.screenWidth / num6); i++)
                    {
                        Vector2 vector3 = ((new Vector2(i * num4 * (rectangle.Width / vector2.X), (Main.maxTilesY - 200) * 16f) + value - vector) * vector2) + vector - Main.screenPosition - value + zero;
                        Color color = Color.White * ExxoAvalonOrigins.caesiumTransition;
                        Main.spriteBatch.Draw(texture2D, vector3, rectangle, color, 0f, Vector2.Zero, num4, SpriteEffects.None, 0f);
                        if (num2 == 0)
                        {
                            int num8 = (int)(vector3.Y + (rectangle.Height * num4));
                            Main.spriteBatch.Draw(Main.blackTileTexture, new Rectangle((int)vector3.X, num8, (int)(rectangle.Width * num4), Math.Max(0, Main.screenHeight - num8)), new Color(6, 5, 6) * ExxoAvalonOrigins.caesiumTransition);
                        }
                    }
                }
            });
        }

        private static readonly List<int> UnderworldBGs = new List<int> // Add value here that you want to change
        {
            5,
            6,
            125,
            126,
            127,
            128,
            129,
            130,
            131,
            132,
            133,
            134,
            135,
            136,
            137,
            138,
            139,
            140,
            141,
            142,
            143,
            144,
            145,
            150,
            152,
            157,
            159,
            185,
            186,
            187,
        };

        // RE-DO
        /*
        public static void ILDoOld(ILContext il)
        {
            var c = new ILCursor(il);
            for (int j = 0; j < 10; j++)
            {
                if (!c.TryGotoNext(i => i.MatchLdcI4(6)))
                    return;
            }

            if (!c.TryGotoNext(i => i.MatchLdelemRef()))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdsfld<Main>(nameof(Main.spriteBatch))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdsfld<Main>(nameof(Main.backgroundTexture))))
                return;
            if (!c.TryGotoNext(i => i.MatchCallvirt(out _)))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldloc, 4);
            c.Emit(OpCodes.Ldloc, 101);
            c.Emit(OpCodes.Ldloc, 103);
            c.Emit(OpCodes.Ldloc, 100);
            c.Emit(OpCodes.Ldloc, 102);
            c.Emit(OpCodes.Ldloc, 104);
            c.Emit(OpCodes.Ldloc, 5);
            c.Emit(OpCodes.Ldloc, 114);
            c.Emit(OpCodes.Ldloc, 111);
            c.Emit(OpCodes.Ldloc, 112);
            c.Emit(OpCodes.Ldloc, 113);
            c.Emit(OpCodes.Ldloc, 110);
            c.EmitDelegate<Action<int, int, int, int, int, int, Vector2, Color, int, int, int, int>>((num3, num71, num73, num70, num72, num74, vector, color26, num86, width3, height3, num85) =>
            {
                foreach (int i in UnderworldBGs)
                {
                    int bgStart = (int)typeof(Main).GetField("bgStart", BindingFlags.NonPublic).GetValue(null);
                    int bgStartY = (int)typeof(Main).GetField("bgStartY", BindingFlags.NonPublic).GetValue(null);

                    Texture2D texture2D = Main.magicPixel;
                    if (ModContent.TextureExists($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}"))
                        texture2D = ModContent.GetTexture($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}");

                    Main.spriteBatch.Draw(texture2D,
                        new Vector2(bgStart + (num3 * num71) + (16 * num73) + num85 + num70, bgStartY + (Main.backgroundHeight[2] * num72) + (16 * num74) + num86) + vector,
                        new Rectangle((16 * num73) + num85 + num70 + 16, (16 * num74) + (Main.backgroundHeight[2] * Main.magmaBGFrame) + num86, width3, height3),
                        color26,
                        0f,
                        default,
                        1f,
                        SpriteEffects.None,
                        0f);
                }
            });

            if (!c.TryGotoNext(i => i.MatchLdelemRef()))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdsfld<Main>(nameof(Main.spriteBatch))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdsfld<Main>(nameof(Main.backgroundTexture))))
                return;
            if (!c.TryGotoNext(i => i.MatchCallvirt(out _)))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldloc, 4);
            c.Emit(OpCodes.Ldloc, 101);
            c.Emit(OpCodes.Ldloc, 103);
            c.Emit(OpCodes.Ldloc, 100);
            c.Emit(OpCodes.Ldloc, 102);
            c.Emit(OpCodes.Ldloc, 104);
            c.Emit(OpCodes.Ldloc, 5);
            c.Emit(OpCodes.Ldloc, 118);
            c.Emit(OpCodes.Ldloc, 119);
            c.Emit(OpCodes.Ldloc, 120);
            c.EmitDelegate<Action<int, int, int, int, int, int, Vector2, int, int, Color>>((num3, num71, num73, num70, num72, num74, vector, num88, num89, color28) =>
            {
                foreach (int i in UnderworldBGs)
                {
                    int bgStart = (int)typeof(Main).GetField("bgStart", BindingFlags.NonPublic).GetValue(null);
                    int bgStartY = (int)typeof(Main).GetField("bgStartY", BindingFlags.NonPublic).GetValue(null);

                    Texture2D texture2D = Main.magicPixel;
                    if (ModContent.TextureExists($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}"))
                        texture2D = ModContent.GetTexture($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}");

                    Main.spriteBatch.Draw(texture2D,
                        new Vector2(bgStart + (num3 * num71) + (16 * num73) + num88 + num70, (bgStartY + (Main.backgroundHeight[2] * num72) + (16 * num74) + num89)) + vector,
                        new Rectangle((16 * num73) + num88 + num70 + 16, (16 * num74) + (Main.backgroundHeight[2] * Main.magmaBGFrame) + num89, 8, 8),
                        color28,
                        0f,
                        default,
                        1f,
                        SpriteEffects.None,
                        0f);
                }
            });

            if (!c.TryGotoNext(i => i.MatchLdelemRef()))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdsfld<Main>(nameof(Main.spriteBatch))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdsfld<Main>(nameof(Main.backgroundTexture))))
                return;
            if (!c.TryGotoNext(i => i.MatchCallvirt(out _)))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldloc, 4);
            c.Emit(OpCodes.Ldloc, 101);
            c.Emit(OpCodes.Ldloc, 103);
            c.Emit(OpCodes.Ldloc, 100);
            c.Emit(OpCodes.Ldloc, 102);
            c.Emit(OpCodes.Ldloc, 104);
            c.Emit(OpCodes.Ldloc, 5);
            c.Emit(OpCodes.Ldloc, 107);
            c.EmitDelegate<Action<int, int, int, int, int, int, Vector2, Color>>((num3, num71, num73, num70, num72, num74, vector, color25) =>
            {
                foreach (int i in UnderworldBGs)
                {
                    int bgStart = (int)typeof(Main).GetField("bgStart", BindingFlags.NonPublic).GetValue(null);
                    int bgStartY = (int)typeof(Main).GetField("bgStartY", BindingFlags.NonPublic).GetValue(null);

                    Texture2D texture2D = Main.magicPixel;
                    if (ModContent.TextureExists($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}"))
                        texture2D = ModContent.GetTexture($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}");

                    Main.spriteBatch.Draw(texture2D,
                        new Vector2(bgStart + (num3 * num71) + (16 * num73) + num70, bgStartY + (Main.backgroundHeight[2] * num72) + (16 * num74)) + vector,
                        new Rectangle((16 * num73) + num70 + 16, (16 * num74) + (Main.backgroundHeight[2] * Main.magmaBGFrame), 16, 16),
                        color25,
                        0f,
                        default,
                        1f,
                        SpriteEffects.None,
                        0f);
                }
            });

            if (!c.TryGotoNext(i => i.MatchLdelemRef()))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdsfld<Main>(nameof(Main.spriteBatch))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdsfld<Main>(nameof(Main.backgroundTexture))))
                return;
            if (!c.TryGotoNext(i => i.MatchCallvirt(out _)))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldloc, 4);
            c.Emit(OpCodes.Ldloc, 101);
            c.Emit(OpCodes.Ldloc, 103);
            c.Emit(OpCodes.Ldloc, 100);
            c.Emit(OpCodes.Ldloc, 102);
            c.Emit(OpCodes.Ldloc, 104);
            c.Emit(OpCodes.Ldloc, 5);
            c.Emit(OpCodes.Ldloc, 107);
            c.EmitDelegate<Action<int, int, int, int, int, int, Vector2, Color>>((num3, num71, num73, num70, num72, num74, vector, color25) =>
            {
                foreach (int i in UnderworldBGs)
                {
                    int bgStart = (int)typeof(Main).GetField("bgStart", BindingFlags.NonPublic).GetValue(null);
                    int bgStartY = (int)typeof(Main).GetField("bgStartY", BindingFlags.NonPublic).GetValue(null);

                    Texture2D texture2D = Main.magicPixel;
                    if (ModContent.TextureExists($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}"))
                        texture2D = ModContent.GetTexture($"ExxoAvalonOrigins/Backgrounds/OldCaesium{i}");

                    Main.spriteBatch.Draw(texture2D,
                        new Vector2(bgStart + (num3 * num71) + (16 * num73) + num70, bgStartY + (Main.backgroundHeight[2] * num72) + (16 * num74)) + vector,
                        new Rectangle((16 * num73) + num70 + 16, (16 * num74) + (Main.backgroundHeight[2] * Main.magmaBGFrame), 16, 16),
                        color25 * ExxoAvalonOrigins.caesiumTransition,
                        0f,
                        default,
                        1f,
                        SpriteEffects.None,
                        0f);
                }
            });

            if (!c.TryGotoNext(i => i.MatchRet()))
                return;
            c.Remove();

            c.EmitDelegate<Action>(() =>
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

            c.Emit(OpCodes.Ret);
        }
        */
    }
}
