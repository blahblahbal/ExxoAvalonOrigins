using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUINumberInput : ExxoUIList
    {
        public delegate void KeyboardEvent(UIElement target, KeyboardState keyboardState);
        public delegate void NumberChangedEventHandler(ExxoUINumberInput sender, EventArgs e);
        public event KeyboardEvent OnKeyboardUpdate;
        public event NumberChangedEventHandler OnNumberChanged;
        private int maxNumber = int.MaxValue;
        public int MaxNumber
        {
            get => maxNumber;
            set
            {
                if (maxNumber == value)
                {
                    return;
                }
                maxNumber = value;
                Resize(maxNumber.ToString().Length);
            }
        }
        public int AmountNumbers { get; private set; }
        private int number;
        public int Number
        {
            get => number;
            set
            {
                string oldString = number.ToString();
                number = (int)MathHelper.Clamp(value, 0, MaxNumber);
                SetActiveIndex(activeNumberIndex + number.ToString().Length - oldString.Length);
                OnNumberChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private ExxoUITextPanel[] numbers;
        private int activeNumberIndex;
        private ExxoUITextPanel ActiveNumberElement => numbers[activeNumberIndex];
        private Color inactiveColor;
        public ExxoUINumberInput(int amountNumbers = 3)
        {
            Direction = Direction.Horizontal;
            FitWidthToContent = true;
            FitHeightToContent = true;
            ListPadding = 0;

            Resize(amountNumbers);
        }

        private void Resize(int amountNumbers = 3)
        {
            Clear();
            AmountNumbers = System.Math.Max(1, amountNumbers);
            Number = 1;

            // Match the text params below, ensures size consistency
            var textSize = new ExxoUIText("000");

            numbers = new ExxoUITextPanel[amountNumbers];

            for (int i = 0; i < amountNumbers; i++)
            {
                var text = new ExxoUIText("")
                {
                    VAlign = UIAlign.Center,
                    HAlign = UIAlign.Center,
                };
                var number = new ExxoUITextPanel(text)
                {
                    FitMinToInnerElement = false,
                    Width = textSize.MinWidth
                };
                number.Height.Pixels = textSize.MinHeight.Pixels * 2;
                Append(number);
                numbers[i] = number;
            }
            inactiveColor = numbers[0].BackgroundColor;
            SetActiveIndex(0);
        }

        private void SetActiveIndex(int index)
        {
            if (activeNumberIndex != index && index >= 0 && index < AmountNumbers)
            {
                ActiveNumberElement.BackgroundColor = inactiveColor;
                activeNumberIndex = index;
                inactiveColor = ActiveNumberElement.BackgroundColor;
            }
        }

        public override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            ActiveNumberElement.BackgroundColor = inactiveColor * 2f;

            PlayerInput.WritingText = true;
            Main.instance.HandleIME();
            string currentString = Number.ToString();
            string newString = Main.GetInputText(currentString);

            if (int.TryParse(newString, out int newNumber))
            {
                if (Number != newNumber && newNumber.ToString().Length <= AmountNumbers)
                {
                    Number = newNumber;
                }
            }
            else if (newString?.Length == 0)
            {
                Number = 0;
            }

            OnKeyboardUpdate.Invoke(this, Main.inputText);

            string numString = number.ToString();

            for (int i = 0; i < AmountNumbers; i++)
            {
                if (i < numString.Length)
                {
                    numbers[i].InnerElement.SetText(numString[i].ToString());
                }
                else
                {
                    numbers[i].InnerElement.SetText("");
                }
            }
        }
    }
}
