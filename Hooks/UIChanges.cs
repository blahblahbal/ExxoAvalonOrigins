using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ReLogic.Graphics;
using System;
using Terraria;
using Terraria.Graphics;
using Terraria.UI.Chat;

namespace ExxoAvalonOrigins.Hooks
{
    class UIChanges
    {
        private static readonly float characterUIStaminaYOffset = 30f;
        private static readonly float characterUIStaminaPanelWidth = 200f;
        // Adds proper text alpha support
        public static Vector2 OnDrawColorCodedStringWithShadow(On.Terraria.UI.Chat.ChatManager.orig_DrawColorCodedStringWithShadow_SpriteBatch_DynamicSpriteFont_string_Vector2_Color_float_Vector2_Vector2_float_float orig,
            SpriteBatch spriteBatch, object font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth, float spread)
        {
            TextSnippet[] snippets = ChatManager.ParseMessage(text, baseColor).ToArray();
            ChatManager.ConvertNormalSnippets(snippets);
            ChatManager.DrawColorCodedStringShadow(spriteBatch, (DynamicSpriteFont)font, snippets, position, new Color(0, 0, 0, baseColor.A), rotation, origin, baseScale, maxWidth, spread);
            return ChatManager.DrawColorCodedString(spriteBatch, (DynamicSpriteFont)font, snippets, position, new Color(255, 255, 255, baseColor.A), rotation, origin, baseScale, out _, maxWidth);
        }

        public static void ILUICharacterListItemDrawSelf(ILContext il)
        {
            var c = new ILCursor(il);

            FieldReference dataField = null;
            MethodReference getPlayer = null;
            MethodReference drawPanel = null;

            if (!c.TryGotoNext(i => i.MatchLdsfld<Main>(nameof(Main.heartTexture))))
                return;

            if (!c.TryGotoNext(i => i.MatchLdarg(1)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdfld(out dataField)))
                return;
            if (!c.TryGotoNext(i => i.MatchCallvirt(out getPlayer)))
                return;

            if (!c.TryGotoPrev(i => i.MatchLdsfld<Main>(nameof(Main.heartTexture))))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdarg(1)))
                return;
            if (!c.TryGotoPrev(i => i.MatchCall(out drawPanel)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdarg(1)))
                return;

            #region lazyfix for panel size height
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.Emit(OpCodes.Ldloc, 6);
            c.EmitDelegate<Func<Vector2, Vector2>>((vector2) =>
            {
                return vector2 + new Vector2(0f, characterUIStaminaYOffset);
            });
            c.EmitDelegate<Func<float>>(() =>
            {
                return characterUIStaminaPanelWidth;
            });
            c.Emit(OpCodes.Call, drawPanel);

            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.Emit(OpCodes.Ldloc, 6);
            c.EmitDelegate<Func<Vector2, Vector2>>((vector2) =>
            {
                return vector2 + new Vector2(0f, characterUIStaminaYOffset - 10f);
            });
            c.EmitDelegate<Func<float>>(() =>
            {
                return characterUIStaminaPanelWidth;
            });
            c.Emit(OpCodes.Call, drawPanel);
            #endregion

            c.Emit(OpCodes.Ldarg_1);
            c.Emit(OpCodes.Ldloc, 6);
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldfld, dataField);
            c.Emit(OpCodes.Callvirt, getPlayer);

            c.EmitDelegate<Action<SpriteBatch, Vector2, Player>>((spriteBatch, vector2, player) =>
            {
                ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();
                if (modPlayer == null)
                {
                    return;
                }

                Texture2D staminaTexture = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina");
                Texture2D defenceTexture = TextureManager.Load("Images/UI/Bestiary/Stat_Defense");
                //switch ((modPlayer.statStamMax - 1) / 150)
                //{
                //    case 0:
                //        staminaTexture = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina");
                //        break;
                //    case 1:
                //        staminaTexture = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina2");
                //        break;
                //    case 2:
                //        staminaTexture = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina3");
                //        break;
                //    default:
                //        staminaTexture = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina");
                //        break;
                //}

                player.ResetEffects();
                modPlayer.UpdateMana();
                player.UpdateEquips(Main.myPlayer);
                player.UpdateArmorSets(Main.myPlayer);

                spriteBatch.Draw(staminaTexture, vector2 + new Vector2(5f, 2f + characterUIStaminaYOffset), Color.White);
                vector2.X += 10f + (float)Main.heartTexture.Width;
                Terraria.Utils.DrawBorderString(spriteBatch, modPlayer.statStamMax2 + " SP", vector2 + new Vector2(0f, 3f + characterUIStaminaYOffset), Color.White);

                vector2.X += 65f;
                spriteBatch.Draw(defenceTexture, vector2 + new Vector2(5f, characterUIStaminaYOffset), new Rectangle(3, 3, 26, 26), Color.White);
                vector2.X += 10f + (float)Main.manaTexture.Width;
                Terraria.Utils.DrawBorderString(spriteBatch, player.statDefense + " DP", vector2 + new Vector2(0f, 3f + characterUIStaminaYOffset), Color.White);
            });
        }
        public static void ILUICharacterListItemCtor(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(i => i.MatchLdcR4(96)))
                return;
            c.Index++;
            c.EmitDelegate<Func<float, float>>((origHeight) =>
            {
                return origHeight + characterUIStaminaYOffset - 2f;
            });
        }
    }
}