using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class HorizontalRule : UIElement
    {
        private readonly Texture2D dividerTexture;
        public HorizontalRule()
        {
            dividerTexture = TextureManager.Load("Images/UI/Divider");
            Height.Set(dividerTexture.Height, 0);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            Vector2 position = GetDimensions().Position();
            spriteBatch.Draw(dividerTexture, position.ToNearestPixel(), null, Color.White, 0f, Vector2.Zero, new Vector2(GetDimensions().Width / 8f, 1f), SpriteEffects.None, 0f);
        }
    }
}
