using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class ExxoUIElement : UIElement
    {
        public event MouseEvent OnMouseHovering;
        public event EventHandler OnRecalculateFinish;
        public bool IsRecalculating { get; private set; }
        public bool Active { get; set; } = true;
        public bool Hidden { get; set; }
        public bool IsVisible => Active && !Hidden && (GetOuterDimensions().Width > 0 && GetOuterDimensions().Height > 0);
        public readonly Queue<UIElement> ElementsForRemoval = new Queue<UIElement>();
        private bool mouseWasOver;


        public override void Update(GameTime gameTime)
        {
            if (!Active)
            {
                return;
            }

            if (IsMouseHovering)
            {
                OnMouseHovering?.Invoke(new UIMouseEvent(this, UserInterface.ActiveInstance.MousePosition), this);
            }
            base.Update(gameTime);
            while (ElementsForRemoval.Count > 0)
            {
                RemoveChild(ElementsForRemoval.Dequeue());
            }
        }

        public override bool ContainsPoint(Vector2 point)
        {
            return IsVisible && base.ContainsPoint(point);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsVisible)
            {
                return;
            }
            base.Draw(spriteBatch);
        }

        public override void Recalculate()
        {
            IsRecalculating = true;
            RecalculateSelf();
            RecalculateChildren();
            PostRecalculate();
            OnRecalculateFinish?.Invoke(this, EventArgs.Empty);
            IsRecalculating = false;
        }

        // This works because the UIChanges.ILUIElementRecalculate hook doesn't recalulate children if the element is an ExxoUIElement
        public virtual void RecalculateSelf()
        {
            base.Recalculate();
        }

        public virtual void PostRecalculate()
        {
        }

        protected override void DrawChildren(SpriteBatch spriteBatch)
        {
            foreach (UIElement element in Elements)
            {
                if (element is ExxoUIElement exxoElement && !exxoElement.Active)
                {
                    continue;
                }
                element.Draw(spriteBatch);
            }
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            if (!mouseWasOver)
            {
                mouseWasOver = true;
                FirstMouseOver(evt);
            }
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);
            if (!ContainsPoint(evt.MousePosition))
            {
                mouseWasOver = false;
                FirstMouseOut(evt);
            }
        }

        public virtual void FirstMouseOver(UIMouseEvent evt)
        {
        }

        public virtual void FirstMouseOut(UIMouseEvent evt)
        {
        }
    }
}
