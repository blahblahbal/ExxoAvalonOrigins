using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.Audio;

namespace ExxoAvalonOrigins.UI.Herbology
{
    internal class HerbologyUIState : ExxoUIState
    {
        public ExxoUIDraggablePanel MainPanel;
        private HerbologyUIStats stats;
        private HerbologyUITurnIn turnIn;
        private HerbologyUIHerbExchange herbExchange;
        private HerbologyUIPotionExchange potionExchange;
        private HerbologyUIPurchaseAttachment purchaseAttachment;
        private HerbologyUIHerbCountAttachment herbCountAttachment;
        private HerbologyUIHelpAttachment helpAttachment;
        private ExxoUIImageButtonToggle helpToggle;

        public override void OnInitialize()
        {
            base.OnInitialize();

            helpAttachment = new HerbologyUIHelpAttachment();

            MainPanel = new ExxoUIDraggablePanel();
            MainPanel.SetPadding(15);
            MainPanel.Width.Set(720, 0);
            MainPanel.Height.Set(660, 0);
            MainPanel.VAlign = UIAlign.Center;
            MainPanel.HAlign = UIAlign.Center;
            Append(MainPanel);

            var mainContainer = new ExxoUIList();
            mainContainer.Width.Set(0, 1);
            mainContainer.Height.Set(0, 1);
            mainContainer.ContentHAlign = UIAlign.Center;
            MainPanel.Append(mainContainer);

            var titleRow = new ExxoUIList()
            {
                Direction = Direction.Horizontal,
                Justification = Justification.Center,
                FitHeightToContent = true,
                ContentVAlign = UIAlign.Center,
            };
            titleRow.Width.Set(0, 1);
            mainContainer.Append(titleRow);

            var titleText = new ExxoUITextPanel(new ExxoUIText("Herbology Bench", 0.8f, true));
            titleRow.Append(titleText);

            helpToggle = new ExxoUIImageButtonToggle(TextureManager.Load("Images/UI/ButtonRename"), Color.White * 0.7f, Color.White)
            {
                Scale = 2,
                Tooltip = "Help"
            };
            titleRow.Append(helpToggle);
            helpToggle.OnToggle += (toggled) => { helpAttachment.Enabled = toggled; helpToggle.MouseOver(new UIMouseEvent(helpToggle, UserInterface.ActiveInstance.MousePosition)); };
            helpAttachment.Register(helpToggle, "When this button is active, hovering over elements provides a description of their purpose");

            var herbContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList());
            herbContainer.Width.Set(0, 1);
            herbContainer.InnerElement.Direction = Direction.Horizontal;
            mainContainer.Append(herbContainer, new ExxoUIList.ElementParams(fillLength: true));

            stats = new HerbologyUIStats();
            herbContainer.InnerElement.Append(stats);
            helpAttachment.Register(stats, "A list of herbology stats relating to the player");
            helpAttachment.Register(stats.RankTitleText, "Title of the current herbology tier");
            helpAttachment.Register(stats.HerbTierText, "Current herbology tier");
            helpAttachment.Register(stats.HerbTotalContainer, "Herb tokens used to purchase seeds in the herb exchange");
            helpAttachment.Register(stats.PotionTotalContainer, "Potion tokens used to purchase potions and elixirs in the potion exchange");

            turnIn = new HerbologyUITurnIn();
            herbContainer.InnerElement.Append(turnIn);
            helpAttachment.Register(turnIn, "Turn in herbs and potions in exchange for tokens");
            helpAttachment.Register(turnIn.ItemSlot, "Place items here to be exchanged for tokens");
            helpAttachment.Register(turnIn.Button, "Converts the current items in the item slot into tokens");

            turnIn.Button.OnClick += delegate
            {
                Item item = turnIn.ItemSlot.Item;

                ExxoAvalonOriginsModPlayer.HerbTier oldTier = Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier;
                if (HerbologyLogic.SellItem(item))
                {
                    item.stack = 0;
                    if (oldTier != Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier)
                    {
                        RefreshContent();
                    }
                }
            };

            herbExchange = new HerbologyUIHerbExchange();
            herbContainer.InnerElement.Append(herbExchange, new ExxoUIList.ElementParams(fillLength: true));
            helpAttachment.Register(herbExchange, "Purchase herbs using herb tokens");
            helpAttachment.Register(herbExchange.Toggle, "Toggle listing between seeds and large seeds");
            helpAttachment.Register(herbExchange.Grid, "Select an item to purchase");

            herbExchange.Toggle.OnToggle += (toggled) => RefreshHerbList(toggled);
            herbExchange.Scrollbar.InnerElement.OnViewPositionChanged += delegate { purchaseAttachment.AttachTo(null); herbCountAttachment.AttachTo(null); };

            Append(new ExxoUIContentLockPanel(herbExchange.Toggle, () => Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Apprentice, $"Content locked: Must be Herbology {ExxoAvalonOriginsModPlayer.HerbTier.Apprentice}"));

            var potionContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList());
            potionContainer.Width.Set(0, 1);
            potionContainer.InnerElement.Direction = Direction.Horizontal;
            mainContainer.Append(potionContainer, new ExxoUIList.ElementParams(fillLength: true));

            potionExchange = new HerbologyUIPotionExchange();
            potionContainer.InnerElement.Append(potionExchange, new ExxoUIList.ElementParams(fillLength: true));
            helpAttachment.Register(potionExchange, "Purchase potions using potion tokens");
            helpAttachment.Register(potionExchange.Toggle, "Toggle listing between potions and elixirs");
            helpAttachment.Register(potionExchange.Grid, "Select an item to purchase");

            potionExchange.Toggle.OnToggle += (toggled) => RefreshPotionList(toggled);
            potionExchange.Scrollbar.InnerElement.OnViewPositionChanged += delegate { purchaseAttachment.AttachTo(null); herbCountAttachment.AttachTo(null); };

            var potionLock = new ExxoUIContentLockPanel(potionExchange, () => Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Expert, $"Content locked: Must be Herbology {ExxoAvalonOriginsModPlayer.HerbTier.Expert}");
            Append(potionLock);
            potionLock.OnLockStatusChanged += (sender, _) => potionExchange.Scrollbar.Active = !sender.Locked;

            purchaseAttachment = new HerbologyUIPurchaseAttachment();
            Append(purchaseAttachment);
            helpAttachment.Register(purchaseAttachment.NumberInputWithButtons, "Select amount of the selected item to purchase");
            helpAttachment.Register(purchaseAttachment.DifferenceContainer, "How the following purchase will affect your token balance");
            helpAttachment.Register(purchaseAttachment.Button, "Click to purchase items");

            purchaseAttachment.NumberInputWithButtons.NumberInput.OnKeyboardUpdate += (_, keyboardState) =>
            {
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                {
                    purchaseAttachment.AttachTo(null);
                    herbCountAttachment.AttachTo(null);
                }
                else if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    if (HerbologyLogic.PurchaseItem(purchaseAttachment.AttachmentHolder?.Item, purchaseAttachment.NumberInputWithButtons.NumberInput.Number))
                    {
                        purchaseAttachment.AttachTo(null);
                        herbCountAttachment.AttachTo(null);
                    }
                }
            };

            purchaseAttachment.Button.OnClick += delegate
            {
                if (HerbologyLogic.PurchaseItem(purchaseAttachment.AttachmentHolder?.Item, purchaseAttachment.NumberInputWithButtons.NumberInput.Number))
                {
                    purchaseAttachment.AttachTo(null);
                    herbCountAttachment.AttachTo(null);
                }
            };

            herbCountAttachment = new HerbologyUIHerbCountAttachment();
            Append(herbCountAttachment);
            helpAttachment.Register(herbCountAttachment.AttachmentElement, "The amount of herbs of that type available, needed to purchase large herb seeds");

            Append(helpAttachment);

            RefreshContent();
        }

        public override void RightDoubleClick(UIMouseEvent evt)
        {
            base.RightDoubleClick(evt);
            if (ExxoAvalonOrigins.DevMode)
            {
                if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier == ExxoAvalonOriginsModPlayer.HerbTier.Master)
                {
                    Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier = ExxoAvalonOriginsModPlayer.HerbTier.Novice;
                }
                else
                {
                    Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier++;
                }
                RefreshContent();
            }
        }

        public override void OnActivate()
        {
            base.OnActivate();
            HerbologyLogic.UpdateHerbTier(Main.LocalPlayer.Avalon());
            SoundEngine.PlaySound(SoundID.MenuOpen);
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            SoundEngine.PlaySound(SoundID.MenuClose);
        }

        private void RefreshContent()
        {
            RefreshHerbList(herbExchange.Toggle.Toggled);
            RefreshPotionList(potionExchange.Toggle.Toggled);
        }

        private void RefreshHerbList(bool displayLargeSeed)
        {
            herbExchange.Grid.InnerElement.Clear();
            var items = new List<int>();
            if (displayLargeSeed)
            {
                items.AddRange(HerbologyLogic.LargeHerbSeedIdByHerbSeedId.Values);
            }
            else
            {
                items.AddRange(HerbologyLogic.LargeHerbSeedIdByHerbSeedId.Keys);
            }

            var elements = new List<UIElement>();
            foreach (int itemID in items)
            {
                var herbItem = new ExxoUIItemSlot(Main.inventoryBack7Texture, itemID);
                herbItem.OnClick += (UIMouseEvent _, UIElement listeningElement) =>
                {
                    purchaseAttachment.AttachTo(listeningElement as ExxoUIItemSlot);
                    herbCountAttachment.AttachTo(listeningElement as ExxoUIItemSlot);
                    purchaseAttachment.NumberInputWithButtons.NumberInput.MaxNumber = herbItem.Item.maxStack;
                };
                elements.Add(herbItem);
            }
            herbExchange.Grid.InnerElement.AddRange(elements);
        }

        private void RefreshPotionList(bool displayElixirs)
        {
            potionExchange.Grid.InnerElement.Clear();
            var items = new List<int>();
            if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Master)
            {
                items.Add(ItemID.SuperHealingPotion);
                items.Add(ItemID.SuperManaPotion);
                items.Add(ModContent.ItemType<Items.Potions.SuperStaminaPotion>());
            }
            if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Expert)
            {
                items.Add(ItemID.HealingPotion);
                items.Add(ItemID.ManaPotion);
                items.Add(ModContent.ItemType<Items.Potions.StaminaPotion>());
            }
            if (displayElixirs)
            {
                items.AddRange(HerbologyLogic.ElixirIds);
            }
            else
            {
                items.AddRange(HerbologyLogic.PotionIds);
            }

            if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Master)
            {
                items.Add(ModContent.ItemType<Items.Potions.BlahPotion>());
            }

            var elements = new List<UIElement>();
            foreach (int itemID in items)
            {
                var potionItem = new ExxoUIItemSlot(Main.inventoryBack7Texture, itemID);
                potionItem.OnClick += (UIMouseEvent _, UIElement listeningElement) =>
                {
                    purchaseAttachment.AttachTo(listeningElement as ExxoUIItemSlot);
                    herbCountAttachment.AttachTo(null);
                    purchaseAttachment.NumberInputWithButtons.NumberInput.MaxNumber = potionItem.Item.maxStack;
                };
                if (itemID == ModContent.ItemType<Items.Potions.BlahPotion>())
                {
                    potionItem.SetImage(Main.inventoryBack6Texture);
                }
                elements.Add(potionItem);
            }
            potionExchange.Grid.InnerElement.AddRange(elements);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            if (player.chest != -1 || Main.npcShop != 0)
            {
                modPlayer.herb = false;
                player.dropItemCheck();
                Recipe.FindRecipes();
            }
        }

        public override void Click(UIMouseEvent evt)
        {
            base.Click(evt);
            if (!purchaseAttachment.ContainsPoint(evt.MousePosition) && !herbCountAttachment.ContainsPoint(evt.MousePosition) && purchaseAttachment.AttachmentHolder?.ContainsPoint(evt.MousePosition) == false)
            {
                purchaseAttachment.AttachTo(null);
                herbCountAttachment.AttachTo(null);
            }
        }
    }
}
