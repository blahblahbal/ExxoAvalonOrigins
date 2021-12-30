using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class NumberInputWithButtons : AdvancedUIList
    {
        public readonly NumberInput NumberInput;
        private readonly AdvancedUIList buttonColumn;
        private readonly BetterUIImageButton incrementButton;
        private readonly BetterUIImageButton decrementButton;
        public int Number { get; set; }
        public NumberInputWithButtons(int amountNumbers = 3)
        {
            Direction = Direction.Horizontal;
            FitWidthToContent = true;
            FitHeightToContent = true;

            NumberInput = new NumberInput(amountNumbers)
            {
                VAlign = UIAlign.Center,
            };
            Append(NumberInput);

            buttonColumn = new AdvancedUIList
            {
                FitWidthToContent = true,
                FitHeightToContent = true,
                Justification = Justification.Center
            };

            incrementButton = new BetterUIImageButton(TextureManager.Load("Images/UI/Minimap/Default/MinimapButton_ZoomIn"));
            incrementButton.OnClick += delegate
            {
                NumberInput.Number++;
            };
            buttonColumn.Append(incrementButton);
            decrementButton = new BetterUIImageButton(TextureManager.Load("Images/UI/Minimap/Default/MinimapButton_ZoomOut"));
            decrementButton.OnClick += delegate
            {
                NumberInput.Number--;
            };
            buttonColumn.Append(decrementButton);
            Append(buttonColumn);
        }
    }
}
