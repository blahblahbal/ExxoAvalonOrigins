using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class BetterUIImageButton : BetterUIImage
    {
        private float visibilityActive = 1f;
        private float visibilityInactive = 0.4f;
        private bool mouseWasOver;
        public BetterUIImageButton(Texture2D texture) : base(texture)
        {
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, (GetDimensions().Position() + (Texture.Size() / 2)).ToNearestPixel(), null, Color * (IsMouseHovering ? visibilityActive : visibilityInactive), LocalRotation, Texture.Size() / 2, Scale * LocalScale, SpriteEffects.None, 0f);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            if (!mouseWasOver)
            {
                mouseWasOver = true;
                Main.PlaySound(SoundID.MenuTick);
            }
            base.MouseOver(evt);
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);

            if (!ContainsPoint(evt.MousePosition))
            {
                mouseWasOver = false;
            }
        }

        public void SetVisibility(float whenInactive, float whenActive)
        {
            visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
            visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
        }
    }
}
