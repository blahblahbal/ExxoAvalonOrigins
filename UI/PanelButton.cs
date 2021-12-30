using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class PanelButton<T> : PanelWrapper<T> where T : UIElement
    {
        private bool mouseWasOver;
        private float visibilityActive = 1f;
        private float visibilityInactive = 0.4f;
        private Color inactiveColor;
        public PanelButton(T uiElement, bool autoSize = true) : base(uiElement, autoSize)
        {
            inactiveColor = BackgroundColor;
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
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsMouseHovering)
            {
                BackgroundColor = inactiveColor * visibilityActive;
            }
            else
            {
                BackgroundColor = inactiveColor * visibilityInactive;
            }
            base.Draw(spriteBatch);
        }
        public void SetVisibility(float whenActive, float whenInactive)
        {
            visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
            visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
        }
    }
}
