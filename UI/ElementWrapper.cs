using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class ElementWrapper<T> : UIElement, IElementListener where T : UIElement
    {
        public bool IsRecalculating { get; set; } = false;
        public readonly T InnerElement;
        public bool FitToInnerElement { get; set; }
        public ElementWrapper(T uiElement, bool autoSize = true)
        {
            InnerElement = uiElement;
            if (autoSize)
            {
                InnerElement.Width.Set(0, 1);
                InnerElement.Height.Set(0, 1);
            }
            Append(InnerElement);
        }
        public override void Recalculate()
        {
            if (FitToInnerElement)
            {
                Width.Set(0, 1);
                Height.Set(0, 1);
            }
            base.Recalculate();
        }
        public void PostRecalculate()
        {
            if (FitToInnerElement)
            {
                Width.Set(InnerElement.GetOuterDimensions().Width + PaddingLeft + PaddingRight, 0);
                Height.Set(InnerElement.GetOuterDimensions().Height + PaddingBottom + PaddingTop, 0);
                this.RecalculateSelf();
            }
        }
    }
}
