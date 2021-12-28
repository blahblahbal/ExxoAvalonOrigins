using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class BetterUIImageButton : UIElement
    {
        private readonly Texture2D texture;
        private float visibilityActive = 1f;
        private float visibilityInactive = 0.4f;
        public float LocalScale = 1f;
        public float LocalRotation = 0f;
        private float scale = 1f;
        public float Scale
        {
            get => scale;
            set
            {
                scale = value;
                Width.Set(texture.Width * scale, 0f);
                Height.Set(texture.Height * scale, 0f);
            }
        }
        private bool mouseWasOver;
        public BetterUIImageButton(Texture2D texture)
        {
            this.texture = texture;
            Width.Set(texture.Width * scale, 0f);
            Height.Set(texture.Height * scale, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetDimensions().Position() + texture.Size() / 2, null, Color.White * (IsMouseHovering ? visibilityActive : visibilityInactive), LocalRotation, texture.Size() / 2, scale * LocalScale, SpriteEffects.None, 0f);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            if (!mouseWasOver)
            {
                mouseWasOver = true;
                Main.PlaySound(SoundID.MenuTick);
            }
            base.MouseOver(evt);
        }

        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);

            if (!ContainsPoint(evt.MousePosition))
            {
                mouseWasOver = false;
            }
        }

        public void SetVisibility(float whenActive, float whenInactive)
        {
            visibilityActive = MathHelper.Clamp(whenActive, 0f, 1f);
            visibilityInactive = MathHelper.Clamp(whenInactive, 0f, 1f);
        }
    }
}
