using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.UI.Chat;

namespace ExxoAvalonOrigins.Hooks
{
    class UIChanges
    {
        // Adds proper text alpha support
        public static Vector2 OnDrawColorCodedStringWithShadow(On.Terraria.UI.Chat.ChatManager.orig_DrawColorCodedStringWithShadow_SpriteBatch_DynamicSpriteFont_string_Vector2_Color_float_Vector2_Vector2_float_float orig,
            SpriteBatch spriteBatch, object font, string text, Vector2 position, Color baseColor, float rotation, Vector2 origin, Vector2 baseScale, float maxWidth, float spread)
        {
            TextSnippet[] snippets = ChatManager.ParseMessage(text, baseColor).ToArray();
            ChatManager.ConvertNormalSnippets(snippets);
            ChatManager.DrawColorCodedStringShadow(spriteBatch, (DynamicSpriteFont)font, snippets, position, new Color(0, 0, 0, baseColor.A), rotation, origin, baseScale, maxWidth, spread);
            return ChatManager.DrawColorCodedString(spriteBatch, (DynamicSpriteFont)font, snippets, position, new Color(255, 255, 255, baseColor.A), rotation, origin, baseScale, out _, maxWidth);
        }
    }
}
