using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ContentLockPanel : UIPanel
    {
        private bool display = true;
        public bool Locked => !unlockCondition();
        private readonly Func<bool> unlockCondition;
        private readonly AdvancedUIList list;
        private readonly UIElement contentHolder;
        private bool wasOversize;
        private bool wasLocked;
        private readonly string message;
        private readonly UIElement elementToLock;
        private readonly CalculatedStyle listOuterDimensions;
        private bool ListIsOversize => listOuterDimensions.Width > elementToLock.GetInnerDimensions().Width || listOuterDimensions.Height > elementToLock.GetInnerDimensions().Height;
        public ContentLockPanel(UIElement elementToLock, Func<bool> unlockCondition, string message = "Content locked")
        {
            this.message = message;
            this.elementToLock = elementToLock;
            this.unlockCondition = unlockCondition;

            BackgroundColor = Color.Black * 0.9f;
            SetPadding(0);

            list = new AdvancedUIList
            {
                VAlign = UIAlign.Center,
                HAlign = UIAlign.Center
            };
            list.SetPadding(0);
            list.Direction = Direction.Horizontal;
            list.FitHeightToContent = true;
            list.FitWidthToContent = true;

            var iconBackground = new BetterUIImage(TextureManager.Load("Images/UI/Wires_1"))
            {
                VAlign = UIAlign.Center
            };
            list.Append(iconBackground);
            var innerImage = new BetterUIImage(TextureManager.Load("Images/UI/Workshop/PublicityPrivate"))
            {
                VAlign = UIAlign.Center,
                HAlign = UIAlign.Center
            };
            iconBackground.Append(innerImage);

            var text = new UIText(message)
            {
                VAlign = UIAlign.Center
            };
            list.Append(text);

            contentHolder = new UIElement();
            contentHolder.SetPadding(0);
            contentHolder.Width.Set(0, 1);
            contentHolder.Height.Set(0, 1);
            Append(contentHolder);

            listOuterDimensions = list.GetOuterDimensions();
            wasOversize = !ListIsOversize;
            wasLocked = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (wasLocked != Locked)
            {
                if (!Locked)
                {
                    Deactivate();
                }
                else
                {
                    Activate();
                }
                wasLocked = Locked;
            }
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            display = false;
            Width.Set(0, 0);
            Height.Set(0, 0);
            base.Recalculate();
        }

        public override void OnActivate()
        {
            base.OnActivate();
            display = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!display)
            {
                return;
            }
            base.Draw(spriteBatch);
            if (IsMouseHovering && ListIsOversize)
            {
                Main.hoverItemName = message;
            }
        }

        public override void Recalculate()
        {
            if (!display)
            {
                return;
            }
            Width.Set(elementToLock.GetOuterDimensions().Width, 0);
            Height.Set(elementToLock.GetOuterDimensions().Height, 0);
            Vector2 position = elementToLock.GetDimensions().Position() - Parent.GetDimensions().Position();
            Left.Set(position.X - Parent.PaddingLeft, 0);
            Top.Set(position.Y - Parent.PaddingTop, 0);
            base.Recalculate();
            if (wasOversize != ListIsOversize)
            {
                contentHolder.RemoveAllChildren();
                if (ListIsOversize)
                {
                    var image = new BetterUIImage(TextureManager.Load("Images/UI/Workshop/PublicityPrivate"))
                    {
                        VAlign = UIAlign.Center,
                        HAlign = UIAlign.Center
                    };
                    contentHolder.Append(image);
                }
                else
                {
                    contentHolder.Append(list);
                }
                wasOversize = ListIsOversize;
            }
        }
    }
}
