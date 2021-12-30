using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class UIItemSlot : BetterUIImageButton
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
        public readonly BetterUIImage InnerImage;
        public UIItemSlot(Texture2D backgroundTexture, int itemID) : base(backgroundTexture)
        {
            item = new Item();
            item.netDefaults(itemID);
            item.stack = 1;
            InnerImage = new BetterUIImage(Main.itemTexture[item.type])
            {
                HAlign = UIAlign.Center,
                VAlign = UIAlign.Center
            };
            Append(InnerImage);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
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
    }
}
