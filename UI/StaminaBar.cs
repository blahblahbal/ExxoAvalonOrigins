﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    class StaminaBar : UIState
    {
        private bool mouseIsOver;
        private readonly int staminaPerBar = 30;
        private readonly int maxStaminaBars = 5;
        private readonly int barSpacing = 26;
        private readonly string labelText = "Stamina";
        private float textYOffset;
        private Vector2 labelDimensions;
        private static Texture2D staminaTexture1;
        private static Texture2D staminaTexture2;
        private static Texture2D staminaTexture3;
        public StaminaBar(Vector2 position)
        {
            if (staminaTexture1 == null)
            {
                staminaTexture1 = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina");
                staminaTexture2 = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina2");
                staminaTexture3 = ExxoAvalonOrigins.mod.GetTexture("Sprites/Stamina3");
            }

            int manaStarSpacing = 28;
            textYOffset = manaStarSpacing * 11 + 30;

            labelDimensions = Main.fontMouseText.MeasureString(labelText);

            Top.Set(textYOffset + labelDimensions.Y, 0);
            Width.Set(staminaTexture1.Width, 0);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            mouseIsOver = true;
            base.MouseOver(evt);
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            mouseIsOver = false;
            base.MouseOut(evt);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (Main.player[Main.myPlayer].ghost || !ExxoAvalonOrigins.mod.subInterface)
            {
                return;
            }

            CalculatedStyle dimensions = GetDimensions();
            // Draw labelText above stamina bar
            DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, labelText, new Vector2((float)(Main.screenWidth - labelDimensions.X - 5), textYOffset), new Color(Main.mouseTextColor, Main.mouseTextColor,Main.mouseTextColor, Main.mouseTextColor), 0f, default(Vector2), 1f, SpriteEffects.None, 0f);

            var player = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>();

            int stamBars = player.statStamMax2 / staminaPerBar;
            if (stamBars > maxStaminaBars)
            {
                stamBars = maxStaminaBars;
            }

            int staminaThreshold = maxStaminaBars * staminaPerBar;

            int remainingStamina = (player.statStam % staminaThreshold);
            if (remainingStamina == 0)
            {
                remainingStamina = staminaThreshold;
            }

            int activeIndex = (remainingStamina / staminaPerBar) + 1;
            if (remainingStamina % staminaPerBar == 0)
            {
                activeIndex -= 1;
            }

            for (var i = 1; i <= stamBars; i++)
            {
                float scale = 1f;
                bool activeBar = false;
                int intensity;

                int statLevel = player.statStam / staminaThreshold;
                if (remainingStamina == staminaThreshold)
                {
                    statLevel -= 1;
                }

                if (i < activeIndex)
                {
                    intensity = 255;
                }
                else if (i == activeIndex)
                {
                    float barProgress = (player.statStam % staminaPerBar) / (float)staminaPerBar;
                    if (barProgress == 0)
                    {
                        barProgress = 1;
                    }
                    if (statLevel > 0)
                    {
                        if (barProgress < 0.5f)
                        {
                            statLevel -= 1;
                            barProgress = 1 - barProgress;
                        }
                        if (barProgress < 0.8f)
                        {
                            barProgress = 0.8f;
                        }
                    }
                    intensity = (int)(staminaPerBar + 225f * barProgress);
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
                }
                else
                {
                    if (player.statStam <= staminaThreshold)
                    {
                        intensity = 30;
                        scale = 0.75f;
                    }
                    else
                    {
                        statLevel -= 1;
                        intensity = 255;
                    }
                }

                // Bobs the scale of the active bar with the cursor bobbing
                if (activeBar)
                {
                    scale += Main.cursorScale - 1f;
                }

                Texture2D texture;
                switch (statLevel)
                {
                    case 0:
                        texture = staminaTexture1;
                        break;
                    case 1:
                        texture = staminaTexture2;
                        break;
                    case 2:
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

            if (mouseIsOver)
            {
                //int X = Main.mouseX + 10;
                //int Y = Main.mouseY + 10;
                //if (Main.ThickMouse)
                //{
                //    X += 6;
                //    Y += 6;
                //}
                string mouseText = string.Format("{0}/{1}", player.statStam, player.statStamMax2);
                Main.instance.MouseTextHackZoom(mouseText);
                //Utils.DrawBorderString(spriteBatch, string.Format("{0}/{1}", player.statStam, player.statStamMax2), new Vector2(X, Y), Color.White, 1f);
            }

            Left.Set(Main.screenWidth - 25 - (staminaTexture1.Width / 2f), 0);
            Height.Set(barSpacing * stamBars, 0);

            base.DrawSelf(spriteBatch);
        }
    }
}