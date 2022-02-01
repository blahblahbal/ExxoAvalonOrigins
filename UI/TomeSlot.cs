using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class TomeSlot : UIState
    {
        public UIPanel tomeSlotDisplay;
        public float scale = 1f;
        public static Texture2D BackgroundTexture = ExxoAvalonOrigins.Mod.GetTexture("Sprites/TomeSlotBackground");

        public event Action<Item, Item> OnItemChange;

        public event Func<Item, bool> CanPutIntoSlot;

        private readonly Item[] ssa = new Item[1];

        public override void OnInitialize()
        {
            tomeSlotDisplay = new UIPanel();
            tomeSlotDisplay.SetPadding(0);
            tomeSlotDisplay.Left.Set(-100f, 1f);
            tomeSlotDisplay.Top.Set(-100f, 1f);
            tomeSlotDisplay.Width.Set(BackgroundTexture.Width * scale, 0f);
            tomeSlotDisplay.Height.Set(BackgroundTexture.Height * scale, 0f);
            tomeSlotDisplay.BackgroundColor = new Color(73, 94, 171);
            Append(tomeSlotDisplay);
        }

        public void DrawTomes(SpriteBatch spriteBatch)
        {
            if (Main.playerInventory && Main.EquipPage == 2)
            {
                var mouseLoc = new Point(Main.mouseX, Main.mouseY);
                var r = new Rectangle(0, 0, (int)(Main.inventoryBackTexture.Width * 0.9), (int)(Main.inventoryBackTexture.Height * 0.9));
                Main.inventoryScale = 0.85f;
                Item tmpItem = Main.player[Main.myPlayer].Avalon().tomeItem;
                int mH = 0;
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
                        if (Main.mouseItem.stack == 1 && Main.mouseItem.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome && Main.player[Main.myPlayer].Avalon().tomeItem.type == ItemID.None && Main.player[Main.myPlayer].Avalon().tomeItem.type != Main.mouseItem.type)
                        {
                            Main.PlaySound(SoundID.Grab, -1, -1, 1);
                            Item item6 = Main.mouseItem;
                            Main.mouseItem = Main.player[Main.myPlayer].Avalon().tomeItem;
                            Main.player[Main.myPlayer].Avalon().tomeItem = item6;
                        }
                        else if (Main.mouseItem.type == ItemID.None && Main.player[Main.myPlayer].Avalon().tomeItem.type > ItemID.None)
                        {
                            Item item7 = Main.mouseItem;
                            Main.mouseItem = Main.player[Main.myPlayer].Avalon().tomeItem;
                            Main.player[Main.myPlayer].Avalon().tomeItem = item7;
                            if (Main.player[Main.myPlayer].Avalon().tomeItem.type == ItemID.None || Main.player[Main.myPlayer].Avalon().tomeItem.stack < 1)
                            {
                                Main.player[Main.myPlayer].Avalon().tomeItem = new Item();
                            }
                            if (Main.mouseItem.type == ItemID.None || Main.mouseItem.stack < 1)
                            {
                                Main.mouseItem = new Item();
                            }
                            if (Main.mouseItem.type > ItemID.None || Main.player[Main.myPlayer].Avalon().tomeItem.type > ItemID.None)
                            {
                                Recipe.FindRecipes();
                                Main.PlaySound(SoundID.Grab, -1, -1, 1);
                            }
                        }
                    }
                    Main.hoverItemName = Main.player[Main.myPlayer].Avalon().tomeItem.type > ItemID.None ? Main.player[Main.myPlayer].Avalon().tomeItem.Name : "Tome";
                    Main.HoverItem = Main.player[Main.myPlayer].Avalon().tomeItem.Clone();
                }
                ssa[0] = tmpItem;
                //spriteBatch.Draw(BackgroundTexture, r, default(Color));
                ItemSlot.Draw(spriteBatch, ssa, 10, 0, new Vector2(r.X, r.Y));
                //Main.spriteBatch.Draw(BackgroundTexture, r, default(Color));
                tmpItem = ssa[0];
                //Main.player[Main.myPlayer].Avalon().tomeItem = tmpItem;
            }
        }
    }
}
