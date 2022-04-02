using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI;

public class ExxoUIPanel : ExxoUIElement
{
    private const int CornerSize = 12;
    private const int BarSize = 4;
    private static Asset<Texture2D> BorderTexture;
    private static Asset<Texture2D> BackgroundTexture;
    public static Color DefaultBackgroundColor => new Color(63, 82, 151) * 0.7f;
    public static Color DefaultBorderColor => Color.Black;
    public Color BorderColor = DefaultBorderColor;
    public Color BackgroundColor = DefaultBackgroundColor;

    public override void OnActivate()
    {
        if (BorderTexture == null)
        {
            BorderTexture = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/PanelBorder");
        }
        if (BackgroundTexture == null)
        {
            BackgroundTexture = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/PanelBackground");
        }
    }

    public ExxoUIPanel()
    {
        SetPadding(CornerSize);
    }

    private void DrawPanel(SpriteBatch spriteBatch, Asset<Texture2D> texture, Color color)
    {
        CalculatedStyle dimensions = GetDimensions();
        var point = new Point((int)dimensions.X, (int)dimensions.Y);
        var point2 = new Point(point.X + (int)dimensions.Width - CornerSize, point.Y + (int)dimensions.Height - CornerSize);
        int width = point2.X - point.X - CornerSize;
        int height = point2.Y - point.Y - CornerSize;
        spriteBatch.Draw(texture.Value, new Rectangle(point.X, point.Y, CornerSize, CornerSize), new Rectangle(0, 0, CornerSize, CornerSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point2.X, point.Y, CornerSize, CornerSize), new Rectangle(CornerSize + BarSize, 0, CornerSize, CornerSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point.X, point2.Y, CornerSize, CornerSize), new Rectangle(0, CornerSize + BarSize, CornerSize, CornerSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point2.X, point2.Y, CornerSize, CornerSize), new Rectangle(CornerSize + BarSize, CornerSize + BarSize, CornerSize, CornerSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point.X + CornerSize, point.Y, width, CornerSize), new Rectangle(CornerSize, 0, BarSize, CornerSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point.X + CornerSize, point2.Y, width, CornerSize), new Rectangle(CornerSize, CornerSize + BarSize, BarSize, CornerSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point.X, point.Y + CornerSize, CornerSize, height), new Rectangle(0, CornerSize, CornerSize, BarSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point2.X, point.Y + CornerSize, CornerSize, height), new Rectangle(CornerSize + BarSize, CornerSize, CornerSize, BarSize), color);
        spriteBatch.Draw(texture.Value, new Rectangle(point.X + CornerSize, point.Y + CornerSize, width, height), new Rectangle(CornerSize, CornerSize, BarSize, BarSize), color);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        DrawPanel(spriteBatch, BackgroundTexture, BackgroundColor);
        DrawPanel(spriteBatch, BorderTexture, BorderColor);
    }
}
