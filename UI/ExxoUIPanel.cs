using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class ExxoUIPanel : ExxoUIElement
    {
        // TODO: Rename once figured out what these do
        public int BorderRadius = 12;
        public int BorderSize = 4;
        private static Texture2D BorderTexture;
        private static Texture2D BackgroundTexture;
        public static Color DefaultBackgroundColor => new Color(63, 82, 151) * 0.7f;
        public Color BorderColor = Color.Black;
        public Color BackgroundColor = DefaultBackgroundColor;

        public override void OnActivate()
        {
            if (BorderTexture == null)
            {
                BorderTexture = TextureManager.Load("Images/UI/PanelBorder");
            }
            if (BackgroundTexture == null)
            {
                BackgroundTexture = TextureManager.Load("Images/UI/PanelBackground");
            }
        }

        public ExxoUIPanel()
        {
            SetPadding(BorderRadius);
        }

        private void DrawPanel(SpriteBatch spriteBatch, Texture2D texture, Color color)
        {
            CalculatedStyle dimensions = GetDimensions();
            var point = new Point((int)dimensions.X, (int)dimensions.Y);
            var point2 = new Point(point.X + (int)dimensions.Width - BorderRadius, point.Y + (int)dimensions.Height - BorderRadius);
            int width = point2.X - point.X - BorderRadius;
            int height = point2.Y - point.Y - BorderRadius;
            spriteBatch.Draw(texture, new Rectangle(point.X, point.Y, BorderRadius, BorderRadius), new Rectangle(0, 0, BorderRadius, BorderRadius), color);
            spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y, BorderRadius, BorderRadius), new Rectangle(BorderRadius + BorderSize, 0, BorderRadius, BorderRadius), color);
            spriteBatch.Draw(texture, new Rectangle(point.X, point2.Y, BorderRadius, BorderRadius), new Rectangle(0, BorderRadius + BorderSize, BorderRadius, BorderRadius), color);
            spriteBatch.Draw(texture, new Rectangle(point2.X, point2.Y, BorderRadius, BorderRadius), new Rectangle(BorderRadius + BorderSize, BorderRadius + BorderSize, BorderRadius, BorderRadius), color);
            spriteBatch.Draw(texture, new Rectangle(point.X + BorderRadius, point.Y, width, BorderRadius), new Rectangle(BorderRadius, 0, BorderSize, BorderRadius), color);
            spriteBatch.Draw(texture, new Rectangle(point.X + BorderRadius, point2.Y, width, BorderRadius), new Rectangle(BorderRadius, BorderRadius + BorderSize, BorderSize, BorderRadius), color);
            spriteBatch.Draw(texture, new Rectangle(point.X, point.Y + BorderRadius, BorderRadius, height), new Rectangle(0, BorderRadius, BorderRadius, BorderSize), color);
            spriteBatch.Draw(texture, new Rectangle(point2.X, point.Y + BorderRadius, BorderRadius, height), new Rectangle(BorderRadius + BorderSize, BorderRadius, BorderRadius, BorderSize), color);
            spriteBatch.Draw(texture, new Rectangle(point.X + BorderRadius, point.Y + BorderRadius, width, height), new Rectangle(BorderRadius, BorderRadius, BorderSize, BorderSize), color);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            DrawPanel(spriteBatch, BackgroundTexture, BackgroundColor);
            DrawPanel(spriteBatch, BorderTexture, BorderColor);
        }
    }
}
