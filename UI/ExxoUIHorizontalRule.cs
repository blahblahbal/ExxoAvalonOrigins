using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Graphics;

namespace ExxoAvalonOrigins.UI;

internal class ExxoUIHorizontalRule : ExxoUIElement
{
    private readonly Asset<Texture2D> dividerTexture;
    public ExxoUIHorizontalRule()
    {
        dividerTexture = ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/Divider");
        Height.Set(dividerTexture.Height(), 0);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        base.DrawSelf(spriteBatch);
        Vector2 position = GetDimensions().Position();
        spriteBatch.Draw(dividerTexture.Value, position.ToNearestPixel(), null, Color.White, 0f, Vector2.Zero, new Vector2(GetDimensions().Width / 8f, 1f), SpriteEffects.None, 0f);
    }
}
