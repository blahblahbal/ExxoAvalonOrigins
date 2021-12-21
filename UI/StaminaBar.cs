using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    class StaminaBar : UIState
    {
        private const int staminaPerBar = 30;
        private const int maxStaminaBars = 5;
        private const int barSpacing = 26;
        private const string labelText = "Stamina";
        private float textYOffset;
        private Vector2 labelDimensions;
        private Texture2D staminaTexture1;
        private Texture2D staminaTexture2;
        private Texture2D staminaTexture3;

        public StaminaBar()
        {
            staminaTexture1 = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina");
            staminaTexture2 = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina2");
            staminaTexture3 = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina3");

            int manaStarSpacing = 28;
            textYOffset = manaStarSpacing * 11 + 30;

            labelDimensions = Main.fontMouseText.MeasureString(labelText);

            Top.Set(textYOffset + labelDimensions.Y, 0);
            Width.Set(staminaTexture1.Width, 0);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (Main.player[Main.myPlayer].ghost)
            {
                return;
            }

            CalculatedStyle dimensions = GetDimensions();
            // Draw labelText above stamina bar
            DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, labelText, new Vector2((Main.screenWidth - labelDimensions.X + 15), textYOffset), new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, default(Vector2), 0.7f, SpriteEffects.None, 0f);

            var player = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>();

            int stamBars = player.statStamMax2 / staminaPerBar;
            if (stamBars > maxStaminaBars)
            {
                stamBars = maxStaminaBars;
            }

            int staminaThreshold = staminaPerBar * maxStaminaBars;
            int amountBars = player.statStamMax2 / staminaPerBar;
            int amountHighestTierBars = ((amountBars - 1) % maxStaminaBars) + 1;
            int highestStatLevel = ((player.statStamMax2 - 1) / staminaThreshold) + 1;

            int staminaCounter = 0;
            bool activeFound = false;

            for (var i = 1; i < stamBars + 1; i++)
            {
                int intensity;
                float scale = 1f;
                bool activeBar = false;

                int statLevel = highestStatLevel;
                if (!(i <= amountHighestTierBars))
                {
                    statLevel--;
                }

                if (!activeFound && staminaCounter + statLevel * staminaPerBar >= player.statStam)
                {
                    float barProgress = (player.statStam - staminaCounter) / (float)(statLevel * staminaPerBar);
                    intensity = (int)(30 + 225f * barProgress);
                    if (intensity < 30)
                    {
                        intensity = 30;
                    }
                    scale = barProgress / 4f + 0.75f;
                    if (scale < 0.75)
                    {
                        scale = 0.75f;
                    }

                    activeBar = true;
                    activeFound = true;
                }
                else if (!activeFound)
                {
                    intensity = 255;
                }
                else
                {
                    intensity = 30;
                    scale = 0.75f;
                }

                staminaCounter += statLevel * staminaPerBar;

                // Bobs the scale of the active bar with the cursor bobbing
                if (activeBar)
                {
                    scale += Main.cursorScale - 1f;
                }

                Texture2D texture;
                switch (statLevel)
                {
                    case 1:
                        texture = staminaTexture1;
                        break;

                    case 2:
                        texture = staminaTexture2;
                        break;

                    case 3:
                        texture = staminaTexture3;
                        break;

                    default:
                        texture = staminaTexture1;
                        break;
                }

                int alpha = (int)(intensity * 0.9f);
                int scaleOffsetX = (int)((texture.Width - texture.Width * scale) / 2f);
                var origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
                var position = new Vector2(dimensions.X + scaleOffsetX + (texture.Width / 2f), dimensions.Y + (barSpacing * (i - 1)) + (texture.Height / 2f));

                spriteBatch.Draw(texture, position, null, new Color(intensity, intensity, intensity, alpha), 0f, origin, scale, SpriteEffects.None, 0f);
            }

            if (IsMouseHovering)
            {
                string mouseText = string.Format("{0}/{1}", player.statStam, player.statStamMax2);
                Main.instance.MouseTextHackZoom(mouseText);
            }

            Left.Set(Main.screenWidth - 25 - (staminaTexture1.Width / 2f), 0);
            Height.Set(barSpacing * stamBars, 0);

            base.DrawSelf(spriteBatch);
        }
    }
}