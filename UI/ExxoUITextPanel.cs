namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUITextPanel : ExxoUIPanelWrapper<ExxoUIText>
    {
        public ExxoUITextPanel(ExxoUIText uiElement, bool autoSize = false) : base(uiElement, autoSize)
        {
            FitMinToInnerElement = true;
        }
    }
}
