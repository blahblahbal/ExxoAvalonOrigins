using Microsoft.Xna.Framework;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIDraggablePanel : ExxoUIPanel
    {
        private bool isMouseHeld;
        private Vector2 clickDelta;
        public override void MouseDown(UIMouseEvent evt)
        {
            if (evt.Target == this)
            {
                clickDelta = UserInterface.ActiveInstance.MousePosition - new Vector2(GetInnerDimensions().X, GetInnerDimensions().Y);
                isMouseHeld = true;
            }
            base.MouseDown(evt);
        }

        public override void MouseUp(UIMouseEvent evt)
        {
            isMouseHeld = false;
            base.MouseUp(evt);
        }

        public override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            if (isMouseHeld)
            {
                Vector2 mouseDelta = UserInterface.ActiveInstance.MousePosition - (new Vector2(GetInnerDimensions().X, GetInnerDimensions().Y) + clickDelta);
                Left.Set(Left.Pixels + mouseDelta.X, 0);
                Top.Set(Top.Pixels + mouseDelta.Y, 0);
            }
        }
    }
}
