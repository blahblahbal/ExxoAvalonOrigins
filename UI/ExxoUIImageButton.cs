using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.Audio;

namespace ExxoAvalonOrigins.UI;

internal class ExxoUIImageButton : ExxoUIImage
{
    private float visibilityActive = 1f;
    private float visibilityInactive = 0.4f;
    public ExxoUIImageButton(Texture2D texture) : base(texture)
    {
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        Color oldColor = Color;
        Color *= (IsMouseHovering ? visibilityActive : visibilityInactive);
        base.DrawSelf(spriteBatch);
        Color = oldColor;
    }

    public override void FirstMouseOver(UIMouseEvent evt)
    {
        base.FirstMouseOver(evt);
        SoundEngine.PlaySound(SoundID.MenuTick);
    }

    public void SetVisibility(float whenInactive, float whenActive)
    {
        visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
        visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
    }
}