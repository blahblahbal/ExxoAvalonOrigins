using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class HerbologyItem : UIItemSlot
    {
        public HerbologyItem(Texture2D backgroundTexture, int itemID) : base(backgroundTexture, itemID)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsMouseHovering)
            {
                if (Item.type > ItemID.None && Item.stack >= 0)
                {
                    Main.hoverItemName = Item.Name;
                    Main.HoverItem = Item;
                }
            }
        }
        public override void MouseDown(UIMouseEvent evt)
        {
            base.MouseDown(evt);
        }
    }
}
