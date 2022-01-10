using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI.Herbology
{
    internal class HerbologyState : AdvancedUIState
    {
        public DraggableUIPanel MainPanel;
        private PanelWrapper<AdvancedUIList> herbContainer;
        private PanelWrapper<AdvancedUIList> herbStatsWrapper;
        private UITextPanel<string> rankTitleText;
        private UITextPanel<string> herbTierText;
        private UITextPanel<string> herbTotalText;
        private UITextPanel<string> potionTotalText;
        private PanelWrapper<AdvancedUIList> herbTurnInContainer;
        private BetterUIImageButton herbButton;
        private UIItemSlot herbItemSlot;
        private PanelWrapper<AdvancedUIList> herbExchangeContainer;
        private ElementWrapper<AdvancedUIListGrid> herbList;
        private PanelWrapper<AdvancedUIList> potionExchangeContainer;
        private ElementWrapper<AdvancedUIListGrid> potionList;
        private AttachmentManager contextAttachment;
        private PanelWrapper<AdvancedUIList> contextMenu;
        private NumberInputWithButtons contextInput;
        private UIImageToggle seedToggle;
        private UIImageToggle potionToggle;
        private bool mouseWasOver;
        private int oldFocusRecipe;

        public override void OnInitialize()
        {
            RemoveAllChildren();

            MainPanel = new DraggableUIPanel();
            MainPanel.SetPadding(15);
            MainPanel.Width.Set(720, 0);
            MainPanel.Height.Set(660, 0);
            MainPanel.VAlign = UIAlign.Center;
            MainPanel.HAlign = UIAlign.Center;
            Append(MainPanel);

            // Prevent scrolling from changing recipe focus while mouse is over UI
            MainPanel.OnMouseOver += delegate
            {
                if (!mouseWasOver)
                {
                    mouseWasOver = true;
                    oldFocusRecipe = Main.focusRecipe;
                }
            };
            MainPanel.OnMouseOut += (evt, listeningElement) =>
            {
                if (!listeningElement.ContainsPoint(evt.MousePosition))
                {
                    mouseWasOver = false;
                }
            };

            var mainContainer = new AdvancedUIList();
            mainContainer.Width.Set(0, 1);
            mainContainer.Height.Set(0, 1);
            MainPanel.Append(mainContainer);

            var uITextPanel = new UITextPanel<string>("Herbology Bench", 0.8f, true)
            {
                HAlign = UIAlign.Center,
            };
            mainContainer.Append(uITextPanel);

            #region herb container

            herbContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            herbContainer.Width.Set(0, 1);
            herbContainer.InnerElement.Direction = Direction.Horizontal;
            mainContainer.Append(herbContainer, new UIListItemParams(fillLength: true));

            herbStatsWrapper = new PanelWrapper<AdvancedUIList>(new AdvancedUIList())
            {
                FitToInnerElement = true,
                VAlign = UIAlign.Center,
            };
            herbStatsWrapper.InnerElement.FitWidthToContent = true;
            herbStatsWrapper.InnerElement.Justification = Justification.Center;
            herbContainer.InnerElement.Append(herbStatsWrapper);

            rankTitleText = new UITextPanel<string>("")
            {
                TextColor = Color.Gold,
                HAlign = UIAlign.Center
            };
            herbStatsWrapper.InnerElement.Append(rankTitleText);

            herbTierText = new UITextPanel<string>("")
            {
                HAlign = UIAlign.Center
            };
            herbStatsWrapper.InnerElement.Append(herbTierText);

            herbTotalText = new UITextPanel<string>("")
            {
                HAlign = UIAlign.Center
            };
            herbStatsWrapper.InnerElement.Append(herbTotalText);

            potionTotalText = new UITextPanel<string>("")
            {
                HAlign = UIAlign.Center
            };
            herbStatsWrapper.InnerElement.Append(potionTotalText);

            herbTurnInContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList())
            {
                FitToInnerElement = true,
                VAlign = UIAlign.Center,
            };
            herbTurnInContainer.InnerElement.Justification = Justification.Center;
            herbTurnInContainer.InnerElement.FitWidthToContent = true;
            herbContainer.InnerElement.Append(herbTurnInContainer);

            herbButton = new BetterUIImageButton(ExxoAvalonOrigins.mod.GetTexture("Sprites/HerbButton"))
            {
                HAlign = UIAlign.Center
            };
            herbButton.OnClick += OnHerbConsumeButtonClick;
            herbTurnInContainer.InnerElement.Append(herbButton);
            herbItemSlot = new UIItemSlot(Main.inventoryBack7Texture, ItemID.None);
            herbItemSlot.OnClick += (_, __) =>
            {
                if ((Main.mouseItem.type == ItemID.None && (herbItemSlot.Item.type != ItemID.None && herbItemSlot.Item.stack > 0)) || (Main.mouseItem.stack >= 1 && (ExxoAvalonOriginsGlobalItem.IsHerb(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsPotion(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsAdvancedPotion(Main.mouseItem.Name))))
                {
                    Main.PlaySound(SoundID.Grab);
                    Item item6 = Main.mouseItem;
                    Main.mouseItem = herbItemSlot.Item;
                    herbItemSlot.Item = item6;
                    Recipe.FindRecipes();
                }
            };
            herbTurnInContainer.InnerElement.Append(herbItemSlot);

            herbExchangeContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            herbExchangeContainer.Height.Set(0, 1);
            herbContainer.InnerElement.Append(herbExchangeContainer, new UIListItemParams(fillLength: true));

            var herbExchangeTitleContainer = new AdvancedUIList
            {
                FitHeightToContent = true
            };
            herbExchangeTitleContainer.Width.Set(0, 1);
            herbExchangeTitleContainer.Direction = Direction.Horizontal;
            herbExchangeTitleContainer.Justification = Justification.Center;
            herbExchangeContainer.InnerElement.Append(herbExchangeTitleContainer);

            var herbExchangeTitle = new UIText("Herb Exchange")
            {
                VAlign = UIAlign.Center
            };
            herbExchangeTitleContainer.Append(herbExchangeTitle);

            seedToggle = new UIImageToggle(TextureManager.Load("Images/UI/WorldCreation/IconRandomSeed"), Color.Red, Color.White);
            seedToggle.OnToggle += (toggled) => RefreshHerbList(toggled);
            herbExchangeTitleContainer.Append(seedToggle);

            MainPanel.Append(new ContentLockPanel(seedToggle, () => Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Apprentice, $"Content locked: Must be Herbology {ExxoAvalonOriginsModPlayer.HerbTier.Apprentice}"));

            var herbExchangeTitleUnderline = new HorizontalRule();
            herbExchangeTitleUnderline.Width.Set(0, 1);
            herbExchangeContainer.InnerElement.Append(herbExchangeTitleUnderline);

            herbList = new ElementWrapper<AdvancedUIListGrid>(new AdvancedUIListGrid())
            {
                OverflowHidden = true
            };
            herbList.Width.Set(0, 1);
            herbList.InnerElement.HAlign = UIAlign.Center;
            herbList.InnerElement.FitWidthToContent = true;
            herbExchangeContainer.InnerElement.Append(herbList, new UIListItemParams(fillLength: true));

            var herbScrollBar = new AdvancedUIScrollbar();
            herbScrollBar.Height.Set(0, 1);
            herbScrollBar.VAlign = UIAlign.Center;
            herbScrollBar.SetPadding(0);
            herbContainer.InnerElement.Append(herbScrollBar);
            herbList.InnerElement.SetScrollbar(herbScrollBar);
            herbExchangeContainer.OnScrollWheel += herbList.InnerElement.ScrollWheelListener;

            #endregion

            #region potion container

            var potionContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            potionContainer.Width.Set(0, 1);
            potionContainer.InnerElement.Direction = Direction.Horizontal;
            mainContainer.Append(potionContainer, new UIListItemParams(fillLength: true));

            potionExchangeContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            potionExchangeContainer.Height.Set(0, 1);
            potionExchangeContainer.InnerElement.VAlign = UIAlign.Center;
            potionContainer.InnerElement.Append(potionExchangeContainer, new UIListItemParams(fillLength: true));

            var potionExchangeTitleContainer = new AdvancedUIList
            {
                FitHeightToContent = true
            };
            potionExchangeTitleContainer.Width.Set(0, 1);
            potionExchangeTitleContainer.Direction = Direction.Horizontal;
            potionExchangeTitleContainer.Justification = Justification.Center;
            potionExchangeContainer.InnerElement.Append(potionExchangeTitleContainer);

            var potionExchangeTitle = new UIText("Potion Exchange")
            {
                VAlign = UIAlign.Center,
            };
            potionExchangeTitleContainer.Append(potionExchangeTitle);

            potionToggle = new UIImageToggle(TextureManager.Load("Images/UI/WorldCreation/IconEvilCorruption"), Color.White, Color.Orange);
            potionToggle.OnToggle += (toggled) => RefreshPotionList(toggled);
            potionExchangeTitleContainer.Append(potionToggle);

            var potionExchangeTitleUnderline = new HorizontalRule();
            potionExchangeTitleUnderline.Width.Set(0, 1);
            potionExchangeContainer.InnerElement.Append(potionExchangeTitleUnderline);

            potionList = new ElementWrapper<AdvancedUIListGrid>(new AdvancedUIListGrid())
            {
                OverflowHidden = true
            };
            potionList.Width.Set(0, 1);
            potionList.InnerElement.HAlign = UIAlign.Center;
            potionList.InnerElement.FitWidthToContent = true;
            potionExchangeContainer.InnerElement.Append(potionList, new UIListItemParams(fillLength: true));

            var potionScrollBar = new AdvancedUIScrollbar();
            potionScrollBar.Height.Set(0, 1);
            potionScrollBar.VAlign = UIAlign.Center;
            potionScrollBar.SetPadding(0);
            potionContainer.InnerElement.Append(potionScrollBar);
            potionList.InnerElement.SetScrollbar(potionScrollBar);
            potionExchangeContainer.OnScrollWheel += potionList.InnerElement.ScrollWheelListener;

            #endregion

            contextMenu = new PanelWrapper<AdvancedUIList>(new AdvancedUIList())
            {
                FitToInnerElement = true,
            };
            contextMenu.InnerElement.FitHeightToContent = true;
            contextMenu.InnerElement.FitWidthToContent = true;
            contextMenu.InnerElement.ListPadding = 20;
            contextMenu.BackgroundColor.A = 255;

            contextInput = new NumberInputWithButtons()
            {
                HAlign = UIAlign.Center
            };
            contextInput.NumberInput.OnKeyboardUpdate += (_, keyboardState) =>
            {
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                {
                    contextAttachment.AttachTo(null);
                }
                else if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    if (HerbologyLogic.PurchaseItem((contextAttachment.AttachmentHolder as UIItemSlot)?.Item, contextInput.NumberInput.Number))
                    {
                        contextAttachment.AttachTo(null);
                    }
                }
            };
            contextMenu.InnerElement.Append(contextInput);

            var button = new PanelButton<UIText>(new UIText("Exchange"))
            {
                HAlign = UIAlign.Center
            };
            button.Width.Set(0, 1);
            button.Height.Pixels = button.InnerElement.MinHeight.Pixels + button.PaddingBottom + button.PaddingTop;
            button.InnerElement.HAlign = UIAlign.Center;
            button.OnClick += delegate
            {
                if (HerbologyLogic.PurchaseItem((contextAttachment.AttachmentHolder as UIItemSlot)?.Item, contextInput.NumberInput.Number))
                {
                    contextAttachment.AttachTo(null);
                }
            };
            contextMenu.InnerElement.Append(button);

            contextAttachment = new AttachmentManager(MainPanel, contextMenu, (attachment, attachmentHolder) => attachment.Top.Set(attachment.Top.Pixels + attachmentHolder.GetOuterDimensions().Height, 0));

            MainPanel.Append(new ContentLockPanel(potionExchangeContainer, () => Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Expert, $"Content locked: Must be Herbology {ExxoAvalonOriginsModPlayer.HerbTier.Expert}"));

            RefreshContent();
        }

        public override void OnActivate()
        {
            base.OnActivate();
            Main.PlaySound(SoundID.MenuOpen);
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            Main.PlaySound(SoundID.MenuClose);
        }

        private void RefreshContent()
        {
            RefreshHerbList(seedToggle.Toggled);
            RefreshPotionList(potionToggle.Toggled);
        }

        private void RefreshHerbList(bool displayLargeSeed)
        {
            herbList.InnerElement.Clear();
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
                var herbItem = new UIItemSlot(Main.inventoryBack7Texture, itemID);
                herbItem.OnClick += (UIMouseEvent _, UIElement listeningElement) =>
                {
                    contextAttachment.AttachTo(listeningElement);
                    contextInput.NumberInput.MaxNumber = herbItem.Item.maxStack;
                };
                elements.Add(herbItem);
            }
            herbList.InnerElement.AddRange(elements);
        }

        private void RefreshPotionList(bool displayElixirs)
        {
            potionList.InnerElement.Clear();
            var items = new List<int>();
            if (displayElixirs)
            {
                items.AddRange(HerbologyLogic.ElixirIdByPotionId.Values);
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
                var potionItem = new UIItemSlot(Main.inventoryBack7Texture, itemID);
                potionItem.OnClick += (UIMouseEvent _, UIElement listeningElement) =>
                {
                    contextAttachment.AttachTo(listeningElement);
                    contextInput.NumberInput.MaxNumber = potionItem.Item.maxStack;
                };
                elements.Add(potionItem);
            }
            potionList.InnerElement.AddRange(elements);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (MainPanel.IsMouseHovering)
            {
                Main.focusRecipe = oldFocusRecipe;
                Main.LocalPlayer.showItemIcon = false;
                Main.LocalPlayer.mouseInterface = true;
            }
            herbButton.LocalScale = 1 + (Animation.SinTime(gameTime.TotalGameTime.TotalSeconds) * 0.3f);
            herbButton.LocalRotation = (Animation.SinTime(gameTime.TotalGameTime.TotalSeconds + 1) * 0.5f) - 0.25f;
        }

        public override void Click(UIMouseEvent evt)
        {
            base.Click(evt);
            if (!contextAttachment.ContainsPoint(evt.MousePosition))
            {
                contextAttachment.AttachTo(null);
            }
        }

        public override void MiddleDoubleClick(UIMouseEvent evt)
        {
            base.MiddleDoubleClick(evt);
            if (ExxoAvalonOrigins.DevMode)
            {
                OnInitialize();
            }
        }

        private void OnHerbConsumeButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            ExxoAvalonOriginsModPlayer.HerbTier oldTier = Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier;
            if (HerbologyLogic.SellItem(herbItemSlot.Item))
            {
                herbItemSlot.Item.stack = 0;
                if (oldTier != Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier)
                {
                    RefreshContent();
                }
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            if (player.chest != -1 || Main.npcShop != 0)
            {
                modPlayer.herb = false;
                player.dropItemCheck();
                Recipe.FindRecipes();
                return;
            }

            string rankTitle = $"Herbology {modPlayer.herbTier}";
            rankTitleText.SetText(rankTitle);

            string tier = $"Tier {(int)(modPlayer.herbTier) + 1} Herbologist";
            herbTierText.SetText(tier);

            string herbTotal = $"Herb Total: {modPlayer.herbTotal}";
            herbTotalText.SetText(herbTotal);

            string potionTotal = $"Potion Total: {modPlayer.potionTotal}";
            potionTotalText.SetText(potionTotal);

            if (herbButton.IsMouseHovering)
            {
                Main.hoverItemName = "Consume Herbs/Potions";
            }
            if (seedToggle.IsMouseHovering)
            {
                Main.hoverItemName = "Toggle Seeds/Large Seeds";
            }
            if (potionToggle.IsMouseHovering)
            {
                Main.hoverItemName = "Toggle Potions/Elixirs";
            }
        }
    }
}
