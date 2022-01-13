using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;

namespace ExxoAvalonOrigins.UI
{
    public class AdvancedUIScrollbar : UIScrollbar
    {
        // TODO: ExxoUIScrollbar which can hide itself rather than parent
        public new void SetView(float viewSize, float maxViewSize)
        {
            viewSize = MathHelper.Clamp(viewSize, 0f, maxViewSize);
            if (viewSize == maxViewSize)
            {
                Width.Set(0, 0);
                if (Parent is ElementWrapper<AdvancedUIScrollbar> exxoParent)
                {
                    exxoParent.Hidden = true;
                }
            }
            else
            {
                Width.Set(20, 0);
                if (Parent is ElementWrapper<AdvancedUIScrollbar> exxoParent)
                {
                    exxoParent.Hidden = false;
                }
            }
            base.SetView(viewSize, maxViewSize);
        }
    }
}
