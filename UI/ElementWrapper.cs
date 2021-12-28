using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class ElementWrapper<T> : UIElement where T : UIElement
    {
        public readonly T InnerElement;
        public ElementWrapper(T uiElement) : base()
        {
            InnerElement = uiElement;
            Append(InnerElement);
            InnerElement.Width.Set(0, 1);
            InnerElement.Height.Set(0, 1);
        }
    }
}
