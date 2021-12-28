using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class PanelWrapper<T> : UIPanel where T : UIElement
    {
        public readonly T InnerElement;
        public PanelWrapper(T uiElement) : base()
        {
            InnerElement = uiElement;
            Append(InnerElement);
            InnerElement.Width.Set(0, 1);
            InnerElement.Height.Set(0, 1);
        }
    }
}
