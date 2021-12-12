using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace ExxoAvalonOrigins.NPCs.Utils
{
    public static class Debug
    {
        public static void DrawIndicator(SpriteBatch spriteBatch, Vector2 worldPosition)
        {
            spriteBatch.Draw(ExxoAvalonOrigins.mod.GetTexture("Sprites/DebugIndicator"), worldPosition - Main.screenPosition, Color.White);
        }
    }
}
