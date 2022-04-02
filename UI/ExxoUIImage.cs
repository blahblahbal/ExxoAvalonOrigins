using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace ExxoAvalonOrigins.UI;

internal class ExxoUIImage : ExxoUIElement
{
    protected Texture2D Texture { get; private set; }
    protected Color Color = Color.White;
    public float LocalScale = 1f;
    public float LocalRotation;
    private float scale = 1f;
    private Vector2 inset;
    public Vector2 Inset { get => inset; set { inset = value; UpdateDimensions(); } }
    public float Scale
    {
        get => scale;
        set
        {
            scale = value;
            UpdateDimensions();
        }
    }
    public void SetImage(Texture2D texture)
    {
        Texture = texture;
        UpdateDimensions();
    }
    private void UpdateDimensions()
    {
        if (Texture != null)
        {
            MinWidth.Set((Texture.Width - (Inset.X * 2)) * Scale, 0f);
            MinHeight.Set((Texture.Height - (Inset.Y * 2)) * Scale, 0f);
        }
    }
    public ExxoUIImage(Texture2D texture)
    {
        SetImage(texture);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        if (Texture != null)
        {
            spriteBatch.Draw(Texture, (GetDimensions().Position() + (Texture.Size() * Scale / 2) - (Inset * Scale)).ToNearestPixel(), null, Color, LocalRotation, Texture.Size() / 2, Scale * LocalScale, SpriteEffects.None, 0f);
        }
    }
}