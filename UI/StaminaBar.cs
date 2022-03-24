using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    class StaminaBar : UIState
    {
        private float staminaPerBar = 30;
        private const int maxStaminaBars = 5;
        private const int barSpacing = 26;
        private const string labelText = "Stamina";
        private float textYOffset;
        private Vector2 labelDimensions;
        private Texture2D staminaTexture1;
        private Texture2D staminaTexture2;
        private Texture2D staminaTexture3;
        private Texture2D staminaTexture4;

        public StaminaBar()
        {
            staminaTexture1 = ExxoAvalonOrigins.Mod.GetTexture("Sprites/Stamina");
            staminaTexture2 = ExxoAvalonOrigins.Mod.GetTexture("Sprites/Stamina2");
            staminaTexture3 = ExxoAvalonOrigins.Mod.GetTexture("Sprites/Stamina3");
            staminaTexture4 = ExxoAvalonOrigins.Mod.GetTexture("Sprites/Stamina4");

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

            var player = Main.player[Main.myPlayer].Avalon();

            /*int green = (int)(player.statStamMax / staminaPerBar);
            int purple = (int)((player.statStamMax - 150) / staminaPerBar);
            int pink = (int)((player.statStamMax - 300) / staminaPerBar);
            int surge = (int)((player.statStamMax - 400) / 20);
            if (purple < 0)
            {
                purple = 0;
            }
            if (pink < 0)
            {
                pink = 0;
            }
            if (surge < 0)
            {
                surge = 0;
            }
            if (purple > 0)
            {
                green = player.statStamMax / (20 + purple / 4);
                staminaPerBar = player.statStamMax / 20f;
            }
            if (pink > 0)
            {
                green = player.statStamMax / (20 + purple / 4);
                staminaPerBar = player.statStamMax / 20f;
            }
            int num3 = player.statStamMax2 - player.statStamMax;
            staminaPerBar += num3 / green;
            int stamBars = (int)(player.statStamMax2 / staminaPerBar);
            if (stamBars > maxStaminaBars)
            {
                stamBars = maxStaminaBars;
            }

            for (int i = 1; i < (int)(player.statStamMax2 / staminaPerBar) + 1; i++)
            {
                float scale = 1f;
                bool activeBar = false;
                int intensity;
                if ((float)Main.player[Main.myPlayer].statLife >= i * staminaPerBar)
                {
                    intensity = 255;
                    if ((float)Main.player[Main.myPlayer].statLife == i * staminaPerBar)
                    {
                        activeBar = true;
                    }
                }
                else
                {
                    float num7 = (player.statStam - (i - 1) * staminaPerBar) / staminaPerBar;
                    intensity = (int)(30f + 225f * num7);
                    if (intensity < 30)
                    {
                        intensity = 30;
                    }
                    scale = num7 / 4f + 0.75f;
                    if (scale < 0.75)
                    {
                        scale = 0.75f;
                    }
                    if (num7 > 0f)
                    {
                        activeBar = true;
                    }
                }
                if (activeBar)
                {
                    scale += Main.cursorScale - 1f;
                }
                int num8 = 0;
                int num9 = 0;
                if (i > 10)
                {
                    num8 -= 260;
                    num9 += 26;
                }
                int num10 = (int)((float)intensity * 0.9);
                if (!Main.player[Main.myPlayer].ghost)
                {
                    int alpha = (int)(intensity * 0.9f);
                    int scaleOffsetX = (int)((staminaTexture1.Width - staminaTexture1.Width * scale) / 2f);
                    var origin = new Vector2(staminaTexture1.Width / 2f, staminaTexture1.Height / 2f);
                    var position = new Vector2(dimensions.X + scaleOffsetX + (staminaTexture1.Width / 2f), dimensions.Y + (barSpacing * (i - 1)) + (staminaTexture1.Height / 2f));
                    if (surge > 0)
                    {
                        surge--;
                        spriteBatch.Draw(staminaTexture4, position, null, new Color(intensity, intensity, intensity, alpha), 0f, origin, scale, SpriteEffects.None, 0f);
                    }
                    else if(pink > 0)
                    {
                        pink--;
                        spriteBatch.Draw(staminaTexture3, position, null, new Color(intensity, intensity, intensity, alpha), 0f, origin, scale, SpriteEffects.None, 0f);
                    }
                    else if (purple > 0)
                    {
                        purple--;
                        spriteBatch.Draw(staminaTexture2, position, null, new Color(intensity, intensity, intensity, alpha), 0f, origin, scale, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(staminaTexture1, position, null, new Color(intensity, intensity, intensity, alpha), 0f, origin, scale, SpriteEffects.None, 0f);
                    }
                }
            }*/



            int stamBars = player.statStamMax2 / (int)staminaPerBar;
            if (stamBars > maxStaminaBars)
            {
                stamBars = maxStaminaBars;
            }

            int staminaThreshold = (int)staminaPerBar * maxStaminaBars;
            int amountBars = player.statStamMax2 / (int)staminaPerBar;
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

                staminaCounter += statLevel * (int)staminaPerBar;

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
