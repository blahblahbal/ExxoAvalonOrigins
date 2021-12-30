using System.Collections.Generic;
using System.Linq;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Items.Potions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    internal class HerbologyBenchUI : AdvancedUIState
    {
        public static Dictionary<int, int> AdvancedPotion = new Dictionary<int, int>
        {
            { ItemID.ObsidianSkinPotion, ModContent.ItemType<Items.AdvancedPotions.AdvObsidianSkinPotion>() },
            { ItemID.RegenerationPotion, ModContent.ItemType<Items.AdvancedPotions.AdvRegenerationPotion>() },
            { ItemID.SwiftnessPotion, ModContent.ItemType<Items.AdvancedPotions.AdvSwiftnessPotion>() },
            { ItemID.GillsPotion, ModContent.ItemType<Items.AdvancedPotions.AdvGillsPotion>() },
            { ItemID.IronskinPotion, ModContent.ItemType<Items.AdvancedPotions.AdvIronskinPotion>() },
            { ItemID.ManaRegenerationPotion, ModContent.ItemType<Items.AdvancedPotions.AdvManaRegenerationPotion>() },
            { ItemID.MagicPowerPotion, ModContent.ItemType<Items.AdvancedPotions.AdvMagicPowerPotion>() },
            { ItemID.FeatherfallPotion, ModContent.ItemType<Items.AdvancedPotions.AdvFeatherfallPotion>() },
            { ItemID.SpelunkerPotion, ModContent.ItemType<Items.AdvancedPotions.AdvSpelunkerPotion>() },
            { ItemID.InvisibilityPotion, ModContent.ItemType<Items.AdvancedPotions.AdvInvisibilityPotion>() },
            { ItemID.ShinePotion, ModContent.ItemType<Items.AdvancedPotions.AdvShinePotion>() },
            { ItemID.NightOwlPotion, ModContent.ItemType<Items.AdvancedPotions.AdvNightOwlPotion>() },
            { ItemID.BattlePotion, ModContent.ItemType<Items.AdvancedPotions.AdvBattlePotion>() },
            { ItemID.ThornsPotion, ModContent.ItemType<Items.AdvancedPotions.AdvThornsPotion>() },
            { ItemID.WaterWalkingPotion, ModContent.ItemType<Items.AdvancedPotions.AdvWaterWalkingPotion>() },
            { ItemID.ArcheryPotion, ModContent.ItemType<Items.AdvancedPotions.AdvArcheryPotion>() },
            { ItemID.HunterPotion, ModContent.ItemType<Items.AdvancedPotions.AdvHunterPotion>() },
            { ItemID.GravitationPotion, ModContent.ItemType<Items.AdvancedPotions.AdvGravitationPotion>() },
            { ItemID.MiningPotion, ModContent.ItemType<Items.AdvancedPotions.AdvMiningPotion>() },
            { ItemID.HeartreachPotion, ModContent.ItemType<Items.AdvancedPotions.AdvHeartreachPotion>() },
            { ItemID.CalmingPotion, ModContent.ItemType<Items.AdvancedPotions.AdvCalmingPotion>() },
            { ItemID.BuilderPotion, ModContent.ItemType<Items.AdvancedPotions.AdvBuilderPotion>() },
            { ItemID.TitanPotion, ModContent.ItemType<Items.AdvancedPotions.AdvTitanPotion>() },
            { ItemID.FlipperPotion, ModContent.ItemType<Items.AdvancedPotions.AdvFlipperPotion>() },
            { ItemID.SummoningPotion, ModContent.ItemType<Items.AdvancedPotions.AdvSummoningPotion>() },
            { ItemID.TrapsightPotion, ModContent.ItemType<Items.AdvancedPotions.AdvDangersensePotion>() },
            { ItemID.AmmoReservationPotion, ModContent.ItemType<Items.AdvancedPotions.AdvAmmoReservationPotion>() },
            { ItemID.LifeforcePotion, ModContent.ItemType<Items.AdvancedPotions.AdvLifeforcePotion>() },
            { ItemID.EndurancePotion, ModContent.ItemType<Items.AdvancedPotions.AdvEndurancePotion>() },
            { ItemID.RagePotion, ModContent.ItemType<Items.AdvancedPotions.AdvRagePotion>() },
            { ItemID.InfernoPotion, ModContent.ItemType<Items.AdvancedPotions.AdvInfernoPotion>() },
            { ItemID.WrathPotion, ModContent.ItemType<Items.AdvancedPotions.AdvWrathPotion>() },
            { ItemID.FishingPotion, ModContent.ItemType<Items.AdvancedPotions.AdvFishingPotion>() },
            { ItemID.SonarPotion, ModContent.ItemType<Items.AdvancedPotions.AdvSonarPotion>() },
            { ItemID.CratePotion, ModContent.ItemType<Items.AdvancedPotions.AdvCratePotion>() },
            { ItemID.WarmthPotion, ModContent.ItemType<Items.AdvancedPotions.AdvWarmthPotion>() }
        };

        public static readonly int[] Potions = new int[]
        {
            ItemID.ObsidianSkinPotion,
            ItemID.RegenerationPotion,
            ItemID.SwiftnessPotion,
            ItemID.GillsPotion,
            ItemID.IronskinPotion,
            ItemID.ManaRegenerationPotion,
            ItemID.MagicPowerPotion,
            ItemID.FeatherfallPotion,
            ItemID.SpelunkerPotion,
            ItemID.InvisibilityPotion,
            ItemID.ShinePotion,
            ItemID.NightOwlPotion,
            ItemID.BattlePotion,
            ItemID.ThornsPotion,
            ItemID.WaterWalkingPotion,
            ItemID.ArcheryPotion,
            ItemID.HunterPotion,
            ItemID.GravitationPotion,
            ItemID.MiningPotion,
            ItemID.HeartreachPotion,
            ItemID.CalmingPotion,
            ItemID.BuilderPotion,
            ItemID.TitanPotion,
            ItemID.FlipperPotion,
            ItemID.SummoningPotion,
            ItemID.TrapsightPotion,
            ItemID.AmmoReservationPotion,
            ItemID.LifeforcePotion,
            ItemID.EndurancePotion,
            ItemID.RagePotion,
            ItemID.InfernoPotion,
            ItemID.WrathPotion,
            ItemID.FishingPotion,
            ItemID.SonarPotion,
            ItemID.CratePotion,
            ItemID.WarmthPotion,
            ModContent.ItemType<CrimsonPotion>(),
            ModContent.ItemType<ShockwavePotion>(),
            ModContent.ItemType<LuckPotion>(),
            ModContent.ItemType<BloodCastPotion>(),
            ModContent.ItemType<StarbrightPotion>(),
            ModContent.ItemType<VisionPotion>(),
            ModContent.ItemType<StrengthPotion>(),
            ModContent.ItemType<GPSPotion>(),
            ModContent.ItemType<TimeShiftPotion>(),
            ModContent.ItemType<ShadowPotion>(),
            ModContent.ItemType<RoguePotion>(),
            ModContent.ItemType<GauntletPotion>(),
            ModContent.ItemType<WisdomPotion>(),
            ModContent.ItemType<TitanskinPotion>(),
            ModContent.ItemType<InvincibilityPotion>(),
            ModContent.ItemType<ForceFieldPotion>(),
            ModContent.ItemType<FuryPotion>()
            // Magnet Potion
        };

        public static readonly Dictionary<int, int> Herbs = new Dictionary<int, int>
        {
            { ModContent.ItemType<LargeDaybloom>(), ItemID.Daybloom },
            { ModContent.ItemType<LargeMoonglow>(), ItemID.Moonglow },
            { ModContent.ItemType<LargeBlinkroot>(), ItemID.Blinkroot },
            { ModContent.ItemType<LargeDeathweed>(), ItemID.Deathweed },
            { ModContent.ItemType<LargeWaterleaf>(), ItemID.Waterleaf },
            { ModContent.ItemType<LargeFireblossom>(), ItemID.Fireblossom },
            { ModContent.ItemType<LargeShiverthorn>(), ItemID.Shiverthorn },
            { ModContent.ItemType<LargeBloodberry>(), ModContent.ItemType<Bloodberry>() },
            { ModContent.ItemType<LargeSweetstem>(), ModContent.ItemType<Sweetstem>() },
            { ModContent.ItemType<LargeBarfbush>(), ModContent.ItemType<Barfbush>() }
        };

        public static readonly Dictionary<int, int> LargeHerbs = new Dictionary<int, int>
        {
            { ModContent.ItemType<LargeDaybloomSeed>(), ModContent.ItemType<LargeDaybloom>() },
            { ModContent.ItemType<LargeMoonglowSeed>(), ModContent.ItemType<LargeMoonglow>() },
            { ModContent.ItemType<LargeBlinkrootSeed>(), ModContent.ItemType<LargeBlinkroot>() },
            { ModContent.ItemType<LargeDeathweedSeed>(), ModContent.ItemType<LargeDeathweed>() },
            { ModContent.ItemType<LargeWaterleafSeed>(), ModContent.ItemType<LargeWaterleaf>() },
            { ModContent.ItemType<LargeFireblossomSeed>(), ModContent.ItemType<LargeFireblossom>() },
            { ModContent.ItemType<LargeShiverthornSeed>(), ModContent.ItemType<LargeShiverthorn>() },
            { ModContent.ItemType<LargeBloodberrySeed>(), ModContent.ItemType<LargeBloodberry>() },
            { ModContent.ItemType<LargeSweetstemSeed>(), ModContent.ItemType<LargeSweetstem>() },
            { ModContent.ItemType<LargeBarfbushSeed>(), ModContent.ItemType<LargeBarfbush>() }
        };

        public static readonly Dictionary<int, int> LargeHerbSeeds = new Dictionary<int, int>
        {
            { ItemID.Daybloom, ModContent.ItemType<LargeDaybloomSeed>() },
            { ItemID.Moonglow, ModContent.ItemType<LargeMoonglowSeed>() },
            { ItemID.Blinkroot, ModContent.ItemType<LargeBlinkrootSeed>() },
            { ItemID.Deathweed, ModContent.ItemType<LargeDeathweedSeed>() },
            { ItemID.Waterleaf, ModContent.ItemType<LargeWaterleafSeed>() },
            { ItemID.Fireblossom, ModContent.ItemType<LargeFireblossomSeed>() },
            { ItemID.Shiverthorn, ModContent.ItemType<LargeShiverthornSeed>() },
            { ModContent.ItemType<Bloodberry>(), ModContent.ItemType<LargeBloodberrySeed>() },
            { ModContent.ItemType<Sweetstem>(), ModContent.ItemType<LargeSweetstemSeed>() },
            { ModContent.ItemType<Barfbush>(), ModContent.ItemType<LargeBarfbushSeed>() }
        };

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
        private bool mouseWasOver;
        private int oldFocusRecipe;
        private readonly bool purchaseLargeSeed;
        private readonly bool purchaseAdvancedPotion;

        private bool firstUpdate = true;

        private static void UpdateHerbTier(ExxoAvalonOriginsModPlayer modPlayer)
        {
            if (modPlayer.herbTotal >= 1500 && Main.hardMode)
            {
                modPlayer.herbTier = ExxoAvalonOriginsModPlayer.HerbTier.Master; // tier 4; Blah Potion exchange
            }
            else if (modPlayer.herbTotal >= 750 && Main.hardMode)
            {
                modPlayer.herbTier = ExxoAvalonOriginsModPlayer.HerbTier.Expert; // tier 3; allows you to obtain advanced potions
            }
            else if (modPlayer.herbTotal >= 250)
            {
                modPlayer.herbTier = ExxoAvalonOriginsModPlayer.HerbTier.Apprentice; // tier 2; allows for large herb seeds
            }
            else
            {
                modPlayer.herbTier = ExxoAvalonOriginsModPlayer.HerbTier.Novice; // tier 1; allows for exchanging one herb for another
            }
        }

        public override void OnInitialize()
        {
            MainPanel?.Remove();
            MainPanel = new DraggableUIPanel();
            MainPanel.SetPadding(15);
            MainPanel.Width.Set(720, 0);
            MainPanel.Height.Set(660, 0);
            MainPanel.VAlign = UIAlign.Center;
            MainPanel.HAlign = UIAlign.Center;

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
            Append(MainPanel);

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

            herbExchangeContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            herbExchangeContainer.Height.Set(0, 1);
            herbContainer.InnerElement.Append(herbExchangeContainer, new UIListItemParams(fillLength: true));

            var herbExchangeTitle = new UIText("Herb Exchange")
            {
                HAlign = UIAlign.Center,
            };
            herbExchangeContainer.InnerElement.Append(herbExchangeTitle);

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

            var potionExchangeTitle = new UIText("Potion Exchange")
            {
                HAlign = UIAlign.Center,
            };
            potionExchangeContainer.InnerElement.Append(potionExchangeTitle);

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
            contextInput.NumberInput.OnKeyboardUpdate += (target, keyboardState) =>
            {
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                {
                    contextAttachment.AttachTo(null);
                }
                else if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                {
                    if (PurchaseItem((contextAttachment.AttachmentHolder as UIItemSlot)?.Item, contextInput.NumberInput.Number))
                    {
                        contextAttachment.AttachTo(null);
                    }
                }
            };
            contextMenu.InnerElement.Append(contextInput);

            var button = new PanelButton<UIText>(new UIText("Exchange"))
            {
                HAlign = UIAlign.Center,
                FitToInnerElement = true
            };
            button.InnerElement.Height = button.InnerElement.MinHeight;
            button.InnerElement.HAlign = UIAlign.Center;
            button.OnClick += delegate
            {
                if (PurchaseItem((contextAttachment.AttachmentHolder as UIItemSlot)?.Item, contextInput.NumberInput.Number))
                {
                    contextAttachment.AttachTo(null);
                }
            };
            contextMenu.InnerElement.Append(button, new UIListItemParams(fillOppLength: true));

            contextAttachment = new AttachmentManager(MainPanel, contextMenu, (attachment, attachmentHolder) =>
            {
                attachment.Top.Set(attachment.Top.Pixels + attachmentHolder.GetOuterDimensions().Height, 0);
            });

            firstUpdate = true;
        }

        private bool PurchaseItem(Item item, int amount)
        {
            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            int herbCharge = 0;
            int herbType = ItemID.None;
            bool chargeInventory = false;
            if (Herbs.ContainsValue(item.type))
            {
                herbCharge = amount;
                herbType = item.type;
            }
            else if (LargeHerbSeeds.ContainsValue(item.type))
            {
                herbCharge = amount * 15;
                chargeInventory = true;
                herbType = Herbs[LargeHerbs[item.type]];
            }

            if (herbCharge > 0)
            {
                if (modPlayer.herbTotal >= herbCharge)
                {
                    if (chargeInventory && herbType != ItemID.None && modPlayer.herbCounts[herbType] > herbCharge)
                    {
                        modPlayer.herbCounts[herbType] -= herbCharge;
                    }
                    else if (chargeInventory)
                    {
                        return false;
                    }
                    modPlayer.herbTotal -= herbCharge;
                    Main.mouseItem = item.Clone();
                    Main.mouseItem.stack = amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            int potionCharge = 0;
            if (Potions.Contains(item.type))
            {
                potionCharge = amount;
            }
            else if (AdvancedPotion.ContainsValue(item.type))
            {
                potionCharge = amount * 5;
            }
            else if (item.type == ModContent.ItemType<BlahPotion>())
            {
                potionCharge = amount * 2500;
            }

            if (potionCharge > 0)
            {
                if (modPlayer.potionTotal >= potionCharge)
                {
                    modPlayer.potionTotal -= potionCharge;
                    Main.mouseItem = item.Clone();
                    Main.mouseItem.stack = amount;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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

        private void FirstUpdate()
        {
            foreach (int itemID in Herbs.Values)
            {
                var herbItem = new UIItemSlot(Main.inventoryBack7Texture, itemID);
                herbItem.OnClick += (UIMouseEvent evt, UIElement listeningElement) =>
                {
                    contextAttachment.AttachTo(listeningElement);
                    contextInput.NumberInput.MaxNumber = herbItem.Item.maxStack;
                };
                herbList.InnerElement.Append(herbItem);
            }
            foreach (int itemID in Potions)
            {
                var potionItem = new UIItemSlot(Main.inventoryBack7Texture, itemID);
                potionItem.OnClick += (UIMouseEvent evt, UIElement listeningElement) =>
                {
                    contextAttachment.AttachTo(listeningElement);
                    contextInput.NumberInput.MaxNumber = potionItem.Item.maxStack;
                };
                potionList.InnerElement.Append(potionItem);
            }
            herbButton = new BetterUIImageButton(ExxoAvalonOrigins.mod.GetTexture("Sprites/HerbButton"))
            {
                HAlign = UIAlign.Center
            };
            herbButton.OnClick += OnButtonClick;
            herbTurnInContainer.InnerElement.Append(herbButton);
            herbItemSlot = new UIItemSlot(Main.inventoryBack7Texture, ItemID.None);
            herbItemSlot.OnClick += (evt, listeningElement) =>
            {
                if ((Main.mouseItem.type == ItemID.None && herbItemSlot.Item.type != ItemID.None) || (Main.mouseItem.stack >= 1 && (ExxoAvalonOriginsGlobalItem.IsHerb(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsPotion(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsAdvancedPotion(Main.mouseItem.Name))))
                {
                    Main.PlaySound(SoundID.Grab);
                    Item item6 = Main.mouseItem;
                    Main.mouseItem = herbItemSlot.Item;
                    herbItemSlot.Item = item6;
                    Recipe.FindRecipes();
                }
            };
            herbTurnInContainer.InnerElement.Append(herbItemSlot);
        }

        public override void Update(GameTime gameTime)
        {
            if (firstUpdate)
            {
                firstUpdate = false;
                FirstUpdate();
            }
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
            OnInitialize();
        }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            if (herbItemSlot.Item.stack <= 0 || herbItemSlot.Item.type == ItemID.None)
            {
                return;
            }

            int herbAddition = 0;
            int herbType = ItemID.None;
            if (Herbs.ContainsValue(herbItemSlot.Item.type))
            {
                herbAddition = 1;
                herbType = herbItemSlot.Item.type;
            }
            else if (LargeHerbSeeds.ContainsValue(herbItemSlot.Item.type))
            {
                herbAddition = 15;
                herbType = Herbs[LargeHerbs[herbItemSlot.Item.type]];
            }
            else if (LargeHerbs.ContainsValue(herbItemSlot.Item.type))
            {
                herbAddition = 20;
                herbType = Herbs[herbItemSlot.Item.type];
            }

            if (herbAddition > 0)
            {
                if (herbType != ItemID.None)
                {
                    if (!modPlayer.herbCounts.ContainsKey(herbType))
                    {
                        modPlayer.herbCounts.Add(herbType, 0);
                    }
                    modPlayer.herbCounts[herbType] += herbAddition * herbItemSlot.Item.stack;
                    modPlayer.herbTotal += herbAddition * herbItemSlot.Item.stack;
                }
            }

            int potionAddition = 0;
            if (Potions.Contains(herbItemSlot.Item.type))
            {
                potionAddition = 1;
            }
            else if (AdvancedPotion.ContainsValue(herbItemSlot.Item.type))
            {
                potionAddition = 10;
            }
            else if (herbItemSlot.Item.type == ModContent.ItemType<BlahPotion>())
            {
                potionAddition = 2500;
            }

            if (potionAddition > 0)
            {
                modPlayer.potionTotal += potionAddition * herbItemSlot.Item.stack;
            }

            herbItemSlot.Item.stack = 0;

            UpdateHerbTier(modPlayer);

            ItemText.NewText(herbItemSlot.Item, herbItemSlot.Item.stack, false, false);
            Main.PlaySound(SoundID.Item, -1, -1, ExxoAvalonOrigins.mod.GetSoundSlot(SoundType.Item, "Sounds/Item/HerbConsume"));
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
                Main.hoverItemName = "Consume Herb/Potion";
            }
        }
    }
}
