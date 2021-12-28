using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;

namespace ExxoAvalonOrigins.UI
{
    public class AdvancedUIScrollbar : UIScrollbar
    {
        private bool overFlow = true;
        public new void SetView(float viewSize, float maxViewSize)
        {
            viewSize = MathHelper.Clamp(viewSize, 0f, maxViewSize);
            if (viewSize == maxViewSize)
            {
                Width.Set(0, 0);
                overFlow = false;
            }
            else
            {
                Width.Set(20, 0);
                overFlow = true;
            }
            base.SetView(viewSize, maxViewSize);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (overFlow)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}
