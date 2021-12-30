using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class NumberInputWithButtons : AdvancedUIList
    {
        private readonly NumberInput numberInput;
        private readonly AdvancedUIList buttonColumn;
        private readonly BetterUIImageButton incrementButton;
        private readonly BetterUIImageButton decrementButton;
        public int Number { get; set; }
        public NumberInputWithButtons(int number = 1)
        {
            Number = number;

            Direction = Direction.Horizontal;
            FitWidthToContent = true;
            FitHeightToContent = true;

            numberInput = new NumberInput
            {
                VAlign = UIAlign.Center,
            };
            Append(numberInput);

            buttonColumn = new AdvancedUIList
            {
                FitWidthToContent = true,
                FitHeightToContent = true,
                Justification = Justification.Center
            };

            incrementButton = new BetterUIImageButton(TextureManager.Load("Images/UI/Minimap/Default/MinimapButton_ZoomIn"));
            buttonColumn.Append(incrementButton);
            decrementButton = new BetterUIImageButton(TextureManager.Load("Images/UI/Minimap/Default/MinimapButton_ZoomOut"));
            buttonColumn.Append(decrementButton);
            Append(buttonColumn);
        }
    }
}
