﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIContentLockPanel : ExxoUIPanel
    {
        public bool Locked => !unlockCondition();
        public delegate void LockStatusChangedEventHandler(ExxoUIContentLockPanel sender, EventArgs e);
        public LockStatusChangedEventHandler OnLockStatusChanged;
        private readonly Func<bool> unlockCondition;
        private readonly ExxoUIList list;
        private readonly UIElement contentHolder;
        private bool wasOversize;
        private bool wasLocked;
        private readonly string message;
        private readonly UIElement elementToLock;
        private readonly CalculatedStyle listOuterDimensions;
        private bool ListIsOversize => listOuterDimensions.Width > elementToLock.GetInnerDimensions().Width || listOuterDimensions.Height > elementToLock.GetInnerDimensions().Height;
        public ExxoUIContentLockPanel(UIElement elementToLock, Func<bool> unlockCondition, string message = "Content locked")
        {
            this.message = message;
            this.elementToLock = elementToLock;
            this.unlockCondition = unlockCondition;

            BackgroundColor = Color.Black * 0.9f;
            SetPadding(0);

            list = new ExxoUIList
            {
                VAlign = UIAlign.Center,
                HAlign = UIAlign.Center
            };
            list.SetPadding(0);
            list.ListPadding = 5;
            list.Direction = Direction.Horizontal;
            list.FitHeightToContent = true;
            list.FitWidthToContent = true;

            var iconBackground = new ExxoUIImage(TextureManager.Load("Images/UI/Wires_1"))
            {
                VAlign = UIAlign.Center
            };
            list.Append(iconBackground);
            var innerImage = new ExxoUIImage(TextureManager.Load("Images/UI/UI_quickicon1"))
            {
                VAlign = UIAlign.Center,
                HAlign = UIAlign.Center
            };
            iconBackground.Append(innerImage);

            var text = new ExxoUIText(message)
            {
                VAlign = UIAlign.Center
            };
            list.Append(text);
            list.Recalculate();

            contentHolder = new UIElement();
            contentHolder.SetPadding(0);
            contentHolder.Width.Set(0, 1);
            contentHolder.Height.Set(0, 1);
            Append(contentHolder);

            listOuterDimensions = list.GetOuterDimensions();
            wasOversize = !ListIsOversize;
            wasLocked = !Locked;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (wasLocked != Locked)
            {
                LockStatusChanged();
                wasLocked = Locked;
            }
        }

        protected virtual void LockStatusChanged()
        {
            OnLockStatusChanged?.Invoke(this, EventArgs.Empty);
            Hidden = !Locked;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (IsMouseHovering && ListIsOversize)
            {
                Main.hoverItemName = message;
            }
        }

        public override void Recalculate()
        {
            if (Parent == null)
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
                    var image = new ExxoUIImage(TextureManager.Load("Images/UI/UI_quickicon1"))
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
