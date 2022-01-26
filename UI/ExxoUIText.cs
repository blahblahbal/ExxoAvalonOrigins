using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class ExxoUIText : ExxoUIElement
    {
        private string text = "";
        private float textScale;
        private bool isLarge;
        public string Text { get => text; set { text = value; UpdateText(); } }
        public float TextScale { get => textScale; set { textScale = value; UpdateText(); } }
        public bool IsLarge { get => isLarge; set { isLarge = value; UpdateText(); } }
        public Color TextColor { get; set; } = Color.White;

        public ExxoUIText(string text, float textScale = 1f, bool isLarge = false)
        {
            SetText(text, textScale, isLarge);
        }

        public void SetText(string text, float textScale = 1f, bool isLarge = false)
        {
            this.text = text;
            this.textScale = textScale;
            this.isLarge = isLarge;
            UpdateText();
        }

        private void UpdateText()
        {
            Vector2 textSize = new Vector2((IsLarge ? Main.fontDeathText : Main.fontMouseText).MeasureString(Text).X, IsLarge ? 32f : 16f) * TextScale;
            MinWidth.Set(textSize.X + PaddingLeft + PaddingRight, 0f);
            MinHeight.Set(textSize.Y + PaddingTop + PaddingBottom, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.AnisotropicClamp, DepthStencilState.None, null, null, Main.UIScaleMatrix);
            CalculatedStyle innerDimensions = GetInnerDimensions();
            Vector2 pos = innerDimensions.Position();
            if (IsLarge)
            {
                pos.Y -= 10f * TextScale;
                Utils.DrawBorderStringBig(spriteBatch, Text, pos, TextColor, TextScale);
            }
            else
            {
                pos.Y -= 2f * TextScale;
                Utils.DrawBorderString(spriteBatch, Text, pos, TextColor, TextScale);
            }
            spriteBatch.End();
            ExxoUIState.BeginDefaultSpriteBatch(spriteBatch);
        }
    }
}
