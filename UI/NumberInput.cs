using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class NumberInput : AdvancedUIList
    {
        public int Number { get; set; }
        public NumberInput(int amountNumbers = 3)
        {
            Direction = Direction.Horizontal;
            FitWidthToContent = true;
            FitHeightToContent = true;
            ListPadding = 0;

            for (int i = 0; i < amountNumbers; i++)
            {
                var text = new UIText("0")
                {
                    VAlign = UIAlign.Center,
                    HAlign = UIAlign.Center,
                };
                text.SetPadding(8);
                var number = new PanelWrapper<UIText>(text, false)
                {
                    FitToInnerElement = true
                };
                number.SetPadding(0);
                Append(number);
            }
        }
    }
}
