using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Terraria.Audio;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIPanelButton<T> : ExxoUIPanelWrapper<T> where T : UIElement
    {
        private bool mouseWasOver;
        private float visibilityActive = 1f;
        private float visibilityInactive = 0.4f;
        private Color inactiveColor;
        public ExxoUIPanelButton(T uiElement, bool autoSize = true) : base(uiElement, autoSize)
        {
            inactiveColor = BackgroundColor;
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            if (!mouseWasOver)
            {
                mouseWasOver = true;
                SoundEngine.PlaySound(SoundID.MenuTick);
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

        public override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            if (IsMouseHovering)
            {
                BackgroundColor = inactiveColor * visibilityActive;
            }
            else
            {
                BackgroundColor = inactiveColor * visibilityInactive;
            }
        }

        public void SetVisibility(float whenActive, float whenInactive)
        {
            visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
            visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
        }
    }
}
