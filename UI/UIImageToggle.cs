﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class UIImageToggle : BetterUIImageButton
    {
        public bool Toggled { get; set; }
        private Color inactiveColor;
        private Color activeColor;
        public UIImageToggle(Texture2D texture, Color inactiveColor, Color activeColor) : base(texture)
        {
            this.inactiveColor = inactiveColor;
            this.activeColor = activeColor;
            SetVisibility(0.7f, 1);
        }
        public override void Click(UIMouseEvent evt)
        {
            base.Click(evt);
            Toggled = !Toggled;
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Color = Toggled ? activeColor : inactiveColor;
            base.DrawSelf(spriteBatch);
        }
    }
}