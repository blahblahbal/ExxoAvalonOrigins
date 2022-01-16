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
    internal class HerbologyState : ExxoUIState
    {
        public ExxoUIDraggablePanel MainPanel;
        private ExxoUIPanelWrapper<ExxoUIList> herbContainer;
        private ExxoUIPanelWrapper<ExxoUIList> herbologyStatsWrapper;
        private ExxoUITextPanel rankTitleText;
        private ExxoUITextPanel herbTierText;
        private ExxoUIText herbTotalText;
        private ExxoUIText potionTotalText;
        private ExxoUIPanelWrapper<ExxoUIList> herbTurnInContainer;
        private ExxoUIImageButton herbButton;
        private ExxoUIItemSlot herbItemSlot;
        private ExxoUIPanelWrapper<ExxoUIList> herbExchangeContainer;
        private ExxoUIElementWrapper<ExxoUIListGrid> herbList;
        private ExxoUIPanelWrapper<ExxoUIList> potionExchangeContainer;
        private ExxoUIElementWrapper<ExxoUIListGrid> potionList;
        private ExxoUIAttachment<ExxoUIItemSlot> contextAttachment;
        private ExxoUIPanelWrapper<ExxoUIList> contextMenu;
        private ExxoUINumberInputWithButtons contextInput;
        private ExxoUIImageButtonToggle seedToggle;
        private ExxoUIImageButtonToggle potionToggle;

        public override void OnInitialize()
        {
            base.OnInitialize();
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
            MainPanel.Append(mainContainer);

            var uITextPanel = new ExxoUITextPanel(new ExxoUIText("Herbology Bench", 0.8f, true))
            {
                HAlign = UIAlign.Center,
            };
            mainContainer.Append(uITextPanel);

            #region herb container

            herbContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList());
            herbContainer.Width.Set(0, 1);
            herbContainer.InnerElement.Direction = Direction.Horizontal;
            mainContainer.Append(herbContainer, new ExxoUIList.ElementParams(fillLength: true));

            herbologyStatsWrapper = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList())
            {
                FitMinToInnerElement = true,
                VAlign = UIAlign.Center,
            };
            herbologyStatsWrapper.Height.Set(0, 1);
            herbologyStatsWrapper.InnerElement.FitWidthToContent = true;
            herbologyStatsWrapper.InnerElement.Justification = Justification.Center;
            herbContainer.InnerElement.Append(herbologyStatsWrapper);

            rankTitleText = new ExxoUITextPanel(new ExxoUIText("")
            {
                TextColor = Color.Gold
            })
            { HAlign = UIAlign.Center };
            herbologyStatsWrapper.InnerElement.Append(rankTitleText);

            herbTierText = new ExxoUITextPanel(new ExxoUIText(""))
            {
                HAlign = UIAlign.Center
            };
            herbologyStatsWrapper.InnerElement.Append(herbTierText);

            var herbTotalContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList())
            {
                FitMinToInnerElement = true,
                HAlign = UIAlign.Center,
            };
            herbTotalContainer.InnerElement.Direction = Direction.Horizontal;
            herbTotalContainer.InnerElement.FitHeightToContent = true;
            herbTotalContainer.InnerElement.FitWidthToContent = true;
            herbologyStatsWrapper.InnerElement.Append(herbTotalContainer);

            var herbIcon = new ExxoUIImage(TextureManager.Load("Images/UI/WorldCreation/IconRandomSeed"))
            {
                Inset = new Vector2(7, 7)
            };
            herbTotalContainer.InnerElement.Append(herbIcon);

            herbTotalText = new ExxoUIText("")
            {
                VAlign = UIAlign.Center
            };
            herbTotalContainer.InnerElement.Append(herbTotalText);

            var potionTotalContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList())
            {
                FitMinToInnerElement = true,
                HAlign = UIAlign.Center,
            };
            potionTotalContainer.InnerElement.Direction = Direction.Horizontal;
            potionTotalContainer.InnerElement.FitHeightToContent = true;
            potionTotalContainer.InnerElement.FitWidthToContent = true;
            herbologyStatsWrapper.InnerElement.Append(potionTotalContainer);

            var potionIcon = new ExxoUIImage(TextureManager.Load("Images/UI/WorldCreation/IconEvilCorruption"))
            {
                Inset = new Vector2(4, 5)
            };
            potionTotalContainer.InnerElement.Append(potionIcon);

            potionTotalText = new ExxoUIText("")
            {
                VAlign = UIAlign.Center
            };
            potionTotalContainer.InnerElement.Append(potionTotalText);

            herbTurnInContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList())
            {
                FitToInnerElement = true,
                VAlign = UIAlign.Center,
            };
            herbTurnInContainer.InnerElement.Justification = Justification.Center;
            herbTurnInContainer.InnerElement.FitWidthToContent = true;
            herbContainer.InnerElement.Append(herbTurnInContainer);

            herbButton = new ExxoUIImageButton(ExxoAvalonOrigins.mod.GetTexture("Sprites/HerbButton"))
            {
                HAlign = UIAlign.Center
            };
            herbButton.OnClick += OnHerbConsumeButtonClick;
            herbTurnInContainer.InnerElement.Append(herbButton);
            herbItemSlot = new ExxoUIItemSlot(Main.inventoryBack7Texture, ItemID.None);
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

            herbExchangeContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList());
            herbExchangeContainer.Height.Set(0, 1);
            herbContainer.InnerElement.Append(herbExchangeContainer, new ExxoUIList.ElementParams(fillLength: true));

            var herbExchangeTitleContainer = new ExxoUIList
            {
                FitHeightToContent = true
            };
            herbExchangeTitleContainer.Width.Set(0, 1);
            herbExchangeTitleContainer.Direction = Direction.Horizontal;
            herbExchangeTitleContainer.Justification = Justification.Center;
            herbExchangeContainer.InnerElement.Append(herbExchangeTitleContainer);

            var herbExchangeTitle = new ExxoUIText("Herb Exchange")
            {
                VAlign = UIAlign.Center
            };
            herbExchangeTitleContainer.Append(herbExchangeTitle);

            seedToggle = new ExxoUIImageButtonToggle(TextureManager.Load("Images/UI/WorldCreation/IconRandomSeed"), Color.Red, Color.White);
            seedToggle.OnToggle += (toggled) => RefreshHerbList(toggled);
            herbExchangeTitleContainer.Append(seedToggle);

            Append(new ExxoUIContentLockPanel(seedToggle, () => Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Apprentice, $"Content locked: Must be Herbology {ExxoAvalonOriginsModPlayer.HerbTier.Apprentice}"));

            var herbExchangeTitleUnderline = new ExxoUIHorizontalRule();
            herbExchangeTitleUnderline.Width.Set(0, 1);
            herbExchangeContainer.InnerElement.Append(herbExchangeTitleUnderline);

            herbList = new ExxoUIElementWrapper<ExxoUIListGrid>(new ExxoUIListGrid())
            {
                OverflowHidden = true
            };
            herbList.Width.Set(0, 1);
            herbList.InnerElement.HAlign = UIAlign.Center;
            herbList.InnerElement.FitWidthToContent = false;
            herbExchangeContainer.InnerElement.Append(herbList, new ExxoUIList.ElementParams(fillLength: true));

            var herbScrollBar = new ExxoUIElementWrapper<ExxoUIScrollbar>(new ExxoUIScrollbar())
            {
                FitToInnerElement = true
            };
            herbScrollBar.VAlign = UIAlign.Center;
            herbScrollBar.SetPadding(0);
            herbContainer.InnerElement.Append(herbScrollBar);
            herbList.InnerElement.SetScrollbar(herbScrollBar.InnerElement);
            herbExchangeContainer.OnScrollWheel += herbList.InnerElement.ScrollWheelListener;
            herbScrollBar.InnerElement.OnViewPositionChanged += delegate { contextAttachment.AttachTo(null); };

            #endregion

            #region potion container

            var potionContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList());
            potionContainer.Width.Set(0, 1);
            potionContainer.InnerElement.Direction = Direction.Horizontal;
            mainContainer.Append(potionContainer, new ExxoUIList.ElementParams(fillLength: true));

            potionExchangeContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList());
            potionExchangeContainer.Height.Set(0, 1);
            potionExchangeContainer.InnerElement.VAlign = UIAlign.Center;
            potionContainer.InnerElement.Append(potionExchangeContainer, new ExxoUIList.ElementParams(fillLength: true));

            var potionExchangeTitleContainer = new ExxoUIList
            {
                FitHeightToContent = true
            };
            potionExchangeTitleContainer.Width.Set(0, 1);
            potionExchangeTitleContainer.Direction = Direction.Horizontal;
            potionExchangeTitleContainer.Justification = Justification.Center;
            potionExchangeContainer.InnerElement.Append(potionExchangeTitleContainer);

            var potionExchangeTitle = new ExxoUIText("Potion Exchange")
            {
                VAlign = UIAlign.Center,
            };
            potionExchangeTitleContainer.Append(potionExchangeTitle);

            potionToggle = new ExxoUIImageButtonToggle(TextureManager.Load("Images/UI/WorldCreation/IconEvilCorruption"), Color.White, Color.Orange);
            potionToggle.OnToggle += (toggled) => RefreshPotionList(toggled);
            potionExchangeTitleContainer.Append(potionToggle);

            var potionExchangeTitleUnderline = new ExxoUIHorizontalRule();
            potionExchangeTitleUnderline.Width.Set(0, 1);
            potionExchangeContainer.InnerElement.Append(potionExchangeTitleUnderline);

            potionList = new ExxoUIElementWrapper<ExxoUIListGrid>(new ExxoUIListGrid())
            {
                OverflowHidden = true
            };
            potionList.Width.Set(0, 1);
            potionList.InnerElement.HAlign = UIAlign.Center;
            potionList.InnerElement.FitWidthToContent = true;
            potionExchangeContainer.InnerElement.Append(potionList, new ExxoUIList.ElementParams(fillLength: true));

            var potionScrollBar = new ExxoUIElementWrapper<ExxoUIScrollbar>(new ExxoUIScrollbar())
            {
                FitToInnerElement = true
            };
            potionScrollBar.VAlign = UIAlign.Center;
            potionScrollBar.SetPadding(0);
            potionContainer.InnerElement.Append(potionScrollBar);
            potionList.InnerElement.SetScrollbar(potionScrollBar.InnerElement);
            potionExchangeContainer.OnScrollWheel += potionList.InnerElement.ScrollWheelListener;
            potionScrollBar.InnerElement.OnViewPositionChanged += delegate { contextAttachment.AttachTo(null); };

            #endregion

            contextMenu = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList())
            {
                FitToInnerElement = true,
            };
            contextMenu.InnerElement.FitHeightToContent = true;
            contextMenu.InnerElement.FitWidthToContent = true;
            contextMenu.InnerElement.ListPadding = 20;
            contextMenu.BackgroundColor.A = 255;
            contextAttachment = new ExxoUIAttachment<ExxoUIItemSlot>(contextMenu);
            contextAttachment.OnPositionAttachment += (sender, e) =>
            {
                e.Position.Y += sender.AttachmentHolder.GetOuterDimensions().Height;
            };
            Append(contextAttachment);

            contextInput = new ExxoUINumberInputWithButtons()
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
                    if (HerbologyLogic.PurchaseItem(contextAttachment.AttachmentHolder?.Item, contextInput.NumberInput.Number))
                    {
                        contextAttachment.AttachTo(null);
                    }
                }
            };
            contextMenu.InnerElement.Append(contextInput);

            var button = new ExxoUIPanelButton<UIText>(new UIText("Exchange"))
            {
                HAlign = UIAlign.Center,
                FitMinToInnerElement = true,
            };
            button.Width.Set(0, 1);
            button.Height.Pixels = button.InnerElement.MinHeight.Pixels + button.PaddingBottom + button.PaddingTop;
            button.InnerElement.HAlign = UIAlign.Center;
            button.OnClick += delegate
            {
                if (HerbologyLogic.PurchaseItem(contextAttachment.AttachmentHolder?.Item, contextInput.NumberInput.Number))
                {
                    contextAttachment.AttachTo(null);
                }
            };
            contextMenu.InnerElement.Append(button);

            var potionLock = new ExxoUIContentLockPanel(potionExchangeContainer, () => Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier >= ExxoAvalonOriginsModPlayer.HerbTier.Expert, $"Content locked: Must be Herbology {ExxoAvalonOriginsModPlayer.HerbTier.Expert}");
            potionLock.OnLockStatusChanged += (sender, e) =>
            {
                potionScrollBar.Active = !sender.Locked;
            };
            Append(potionLock);


            RefreshContent();
        }

        public override void RightDoubleClick(UIMouseEvent evt)
        {
            base.RightDoubleClick(evt);
            if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier == ExxoAvalonOriginsModPlayer.HerbTier.Master)
            {
                Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier = ExxoAvalonOriginsModPlayer.HerbTier.Novice;
            }
            else
            {
                Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herbTier++;
            }
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
                var herbItem = new ExxoUIItemSlot(Main.inventoryBack7Texture, itemID);
                herbItem.OnClick += (UIMouseEvent _, UIElement listeningElement) =>
                {
                    contextAttachment.AttachTo(listeningElement as ExxoUIItemSlot);
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
                var potionItem = new ExxoUIItemSlot(Main.inventoryBack7Texture, itemID);
                potionItem.OnClick += (UIMouseEvent _, UIElement listeningElement) =>
                {
                    contextAttachment.AttachTo(listeningElement as ExxoUIItemSlot);
                    contextInput.NumberInput.MaxNumber = potionItem.Item.maxStack;
                };
                elements.Add(potionItem);
            }
            potionList.InnerElement.AddRange(elements);
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
                return;
            }

            herbButton.LocalScale = 1 + (Animation.SinTime(gameTime.TotalGameTime.TotalSeconds) * 0.3f);
            herbButton.LocalRotation = (Animation.SinTime(gameTime.TotalGameTime.TotalSeconds + 1) * 0.5f) - 0.25f;

            string rankTitle = $"Herbology {modPlayer.herbTier}";
            rankTitleText.InnerElement.SetText(rankTitle);

            string tier = $"Tier {(int)(modPlayer.herbTier) + 1} Herbologist";
            herbTierText.InnerElement.SetText(tier);

            string herbTotal = modPlayer.herbTotal.ToString();
            herbTotalText.SetText(herbTotal);

            string potionTotal = modPlayer.potionTotal.ToString();
            potionTotalText.SetText(potionTotal);
        }

        public override void Click(UIMouseEvent evt)
        {
            base.Click(evt);
            if (!contextAttachment.ContainsPoint(evt.MousePosition) && contextAttachment.AttachmentHolder?.ContainsPoint(evt.MousePosition) == false)
            {
                contextAttachment.AttachTo(null);
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
            base.DrawSelf(spriteBatch);
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
