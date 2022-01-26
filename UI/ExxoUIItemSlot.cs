using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class ExxoUIItemSlot : ExxoUIImageButton
    {
        private Item item;
        public Item Item
        {
            get => item;
            set
            {
                item = value;
                InnerImage.SetImage(Main.itemTexture[Item.type]);
            }
        }
        public bool HoverItemDrawStack = true;
        public readonly ExxoUIImage InnerImage;
        public ExxoUIItemSlot(Texture2D backgroundTexture, int itemID) : base(backgroundTexture)
        {
            item = new Item();
            item.netDefaults(itemID);
            item.stack = 1;
            InnerImage = new ExxoUIImage(Main.itemTexture[item.type])
            {
                HAlign = UIAlign.Center,
                VAlign = UIAlign.Center
            };
            Append(InnerImage);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            if (IsMouseHovering && Item.type > ItemID.None && Item.stack > 0)
            {
                Main.hoverItemName = Item.Name;
                if (Item.stack > 1 && HoverItemDrawStack)
                {
                    Main.hoverItemName += $" ({Item.stack})";
                }
                Main.HoverItem = Item;
            }
        }

        protected override void DrawChildren(SpriteBatch spriteBatch)
        {
            if (Item.stack > 0)
            {
                base.DrawChildren(spriteBatch);
            }
        }
    }
}
