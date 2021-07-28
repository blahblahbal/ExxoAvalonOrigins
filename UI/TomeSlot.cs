using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;

namespace ExxoAvalonOrigins.UI
{
    class TomeSlot : UIState
    {
        public UIPanel tomeSlotDisplay;
        internal float scale = 1f;
        Texture2D background = Main.inventoryBack9Texture;
        internal event Action<Item, Item> OnItemChange;
        internal event Func<Item, bool> CanPutIntoSlot;
        Item[] ssa = new Item[1];

        public override void OnInitialize()
        {
            tomeSlotDisplay = new UIPanel();
            tomeSlotDisplay.SetPadding(0);
            tomeSlotDisplay.Left.Set(-100f, 1f);
            tomeSlotDisplay.Top.Set(-100f, 1f);
            tomeSlotDisplay.Width.Set(background.Width * scale, 0f);
            tomeSlotDisplay.Height.Set(background.Height * scale, 0f);
            tomeSlotDisplay.BackgroundColor = new Color(73, 94, 171);

            Append(tomeSlotDisplay);
        }
        /*
        void MouseItemDown(UIMouseEvent evt, UIElement listeningElement)
        {
            Player player = Main.LocalPlayer;
            if ((!item.IsAir || (!Main.mouseItem.IsAir /*&& CanPutIntoSlot(Main.mouseItem)* /)) && player.itemAnimation == 0 && player.itemTime == 0)
            {
                Item tempItem = Main.mouseItem.Clone();
                Main.mouseItem = item.Clone();
                if (!Main.mouseItem.IsAir)
                {
                    Main.playerInventory = true;
                }
                item = tempItem;
                Main.PlaySound(SoundID.Grab, Main.LocalPlayer.position);
                OnItemChange.Invoke(Main.mouseItem, item);
            }
        }*/

        internal void DrawTomes(SpriteBatch spriteBatch)
        {
            if (Main.playerInventory && Main.EquipPage == 2)
            {

                var mouseLoc = new Point(Main.mouseX, Main.mouseY);
                var r = new Rectangle(0, 0, (int)(Main.inventoryBackTexture.Width * Main.inventoryScale), (int)(Main.inventoryBackTexture.Height * Main.inventoryScale));
                Main.inventoryScale = 0.85f;
                var tmpItem = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem;
                var mH = 0;
                if (Main.mapEnabled)
                {
                    if (!Main.mapFullscreen && Main.mapStyle == 1)
                    {
                        mH = 256;
                    }
                    if (mH + 600 > Main.screenHeight)
                    {
                        mH = Main.screenHeight - 600;
                    }
                }
                r.X = Main.screenWidth - 92 - 47 - 47;
                r.Y = mH + 174;
                if (r.Contains(mouseLoc))
                {
                    Main.LocalPlayer.mouseInterface = true;
                    Main.armorHide = true;
                    ssa[0] = tmpItem;
                    var tm = Main.mouseItem.IsAir || Main.mouseItem.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome;
                    if (tm) ItemSlot.Handle(ssa, ItemSlot.Context.InventoryItem, 0);
                    tmpItem = ssa[0];
                }
                ssa[0] = tmpItem;
                ItemSlot.Draw(spriteBatch, ssa, 10, 0, new Vector2(r.X, r.Y));
                tmpItem = ssa[0];
                Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem = tmpItem;
            }
        }
    }
}
