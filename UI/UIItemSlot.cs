using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
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
                innerImage.SetImage(Main.itemTexture[Item.type]);
            }
        }
        private readonly UIImage innerImage;
        public UIItemSlot(Texture2D backgroundTexture, int itemID) : base(backgroundTexture)
        {
            item = new Item();
            item.netDefaults(itemID);
            item.stack = 1;
            innerImage = new UIImage(Main.itemTexture[item.type])
            {
                HAlign = UIAlign.Center,
                VAlign = UIAlign.Center
            };
            Append(innerImage);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (IsMouseHovering)
            {
                if (Item.type > ItemID.None && Item.stack > 0)
                {
                    Main.hoverItemName = Item.Name;
                    if (Item.stack > 1)
                    {
                        Main.hoverItemName = Main.hoverItemName + " (" + item.stack + ")";
                    }
                    Main.HoverItem = Item;
                }
            }
        }
    }
}
