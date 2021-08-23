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
        Texture2D background = ExxoAvalonOrigins.tomeSlotBackgroundTexture;
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

        internal void DrawTomes(SpriteBatch spriteBatch)
        {
            if (Main.playerInventory && Main.EquipPage == 2)
            {

                var mouseLoc = new Point(Main.mouseX, Main.mouseY);
                var r = new Rectangle(0, 0, (int)(Main.inventoryBackTexture.Width * 0.9), (int)(Main.inventoryBackTexture.Height * 0.9));
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
                r.Y = mH + 174 + 47 + 47 + 47 + 47;
                if (r.Contains(mouseLoc))
                {
                    Main.LocalPlayer.mouseInterface = true;
                    Main.armorHide = true;
                    if (Main.mouseLeftRelease && Main.mouseLeft)
                    {
                        if (Main.mouseItem.stack == 1 && Main.mouseItem.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome && Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.type == ItemID.None && Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.type != Main.mouseItem.type)
                        {
                            Main.PlaySound(SoundID.Grab, -1, -1, 1);
                            Item item6 = Main.mouseItem;
                            Main.mouseItem = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem;
                            Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem = item6;
                        }
                        else if (Main.mouseItem.type == ItemID.None && Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.type > ItemID.None)
                        {
                            Item item7 = Main.mouseItem;
                            Main.mouseItem = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem;
                            Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem = item7;
                            if (Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.type == ItemID.None || Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.stack < 1)
                            {
                                Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem = new Item();
                            }
                            if (Main.mouseItem.type == ItemID.None || Main.mouseItem.stack < 1)
                            {
                                Main.mouseItem = new Item();
                            }
                            if (Main.mouseItem.type > ItemID.None || Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.type > ItemID.None)
                            {
                                Recipe.FindRecipes();
                                Main.PlaySound(SoundID.Grab, -1, -1, 1);
                            }
                        }
                    }
                    Main.hoverItemName = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.type > ItemID.None ? Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.Name : "Tome";
                    Main.HoverItem = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem.Clone();
                }
                ssa[0] = tmpItem;
                //spriteBatch.Draw(background, r, default(Color));
                ItemSlot.Draw(spriteBatch, ssa, 10, 0, new Vector2(r.X, r.Y));
                //Main.spriteBatch.Draw(background, r, default(Color));
                tmpItem = ssa[0];
                //Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsModPlayer>().tomeItem = tmpItem;
            }
        }
    }
}
