namespace ExxoAvalonOrigins.UI;

internal class ExxoUITextPanel : ExxoUIPanelWrapper<ExxoUIText>
{
    public ExxoUITextPanel(ExxoUIText uiElement) : base(uiElement, false)
    {
        FitMinToInnerElement = true;
    }
}