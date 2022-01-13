using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIImage : ExxoUIElement
    {
        protected Texture2D Texture { get; private set; }
        protected Color Color = Color.White;
        public float LocalScale = 1f;
        public float LocalRotation;
        private float scale = 1f;
        public float Scale
        {
            get => scale;
            set
            {
                scale = value;
                Width.Set(Texture.Width * scale, 0f);
                Height.Set(Texture.Height * scale, 0f);
            }
        }
        public void SetImage(Texture2D texture)
        {
            Texture = texture;
            Width.Set(texture.Width * scale, 0f);
            Height.Set(texture.Height * scale, 0f);
        }
        public ExxoUIImage(Texture2D texture)
        {
            SetImage(texture);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, (GetDimensions().Position() + (Texture.Size() / 2)).ToNearestPixel(), null, Color, LocalRotation, Texture.Size() / 2, Scale * LocalScale, SpriteEffects.None, 0f); ;
        }
    }
}
