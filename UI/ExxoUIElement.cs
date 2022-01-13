using System.Collections.Generic;
using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class ExxoUIElement : UIElement
    {
        public event MouseEvent OnMouseHovering;
        public bool IsRecalculating { get; private set; }
        public bool Active { get; set; } = true;
        public bool Hidden { get; set; }
        public Queue<UIElement> ElementsForRemoval = new Queue<UIElement>();
        private readonly Observer<float> observer;
        private bool mouseWasOver;

        public ExxoUIElement()
        {
            // TODO: Allow custom condition delegate for each observer
            observer = new Observer<float>(() => Top.Pixels + Top.Precent + Left.Pixels + Left.Precent + Width.Pixels + Width.Precent + Height.Pixels + Height.Precent + MinWidth.Pixels + MinWidth.Precent + MaxWidth.Pixels + MaxWidth.Precent + MinHeight.Pixels + MinHeight.Precent + MaxHeight.Pixels + MaxHeight.Precent + PaddingBottom + PaddingLeft + PaddingRight + PaddingTop + MarginBottom + MarginLeft + MarginRight + MarginTop + HAlign + VAlign);
        }

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
            if (observer.Check())
            {
                Recalculate();
            }
        }

        public override bool ContainsPoint(Vector2 point)
        {
            return (Active && !Hidden) && base.ContainsPoint(point);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!Active || Hidden)
            {
                return;
            }
            base.Draw(spriteBatch);
        }

        public override void Recalculate()
        {
            if (Parent is ExxoUIElement exxoParent && !exxoParent.IsRecalculating)
            {
                exxoParent.Recalculate();
                return;
            }
            IsRecalculating = true;
            RecalculateSelf();
            RecalculateChildren();
            PostRecalculate();
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
                //Terraria.Main.NewText(evt.Target.ToString());
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
