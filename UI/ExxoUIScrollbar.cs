using System;
using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.UI.Elements;

namespace ExxoAvalonOrigins.UI
{
    public class ExxoUIScrollbar : UIScrollbar
    {
        public EventHandler OnViewPositionChanged;
        private readonly Observer<float> observer;
        public ExxoUIScrollbar()
        {
            observer = new Observer<float>(() => ViewPosition);
        }
        public new void SetView(float viewSize, float maxViewSize)
        {
            viewSize = MathHelper.Clamp(viewSize, 0f, maxViewSize);
            if (viewSize == maxViewSize)
            {
                Width.Set(0, 0);
                if (Parent is ExxoUIElementWrapper<ExxoUIScrollbar> exxoParent)
                {
                    exxoParent.Hidden = true;
                }
            }
            else
            {
                Width.Set(20, 0);
                if (Parent is ExxoUIElementWrapper<ExxoUIScrollbar> exxoParent)
                {
                    exxoParent.Hidden = false;
                }
            }
            base.SetView(viewSize, maxViewSize);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (observer.Check())
            {
                OnViewPositionChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
