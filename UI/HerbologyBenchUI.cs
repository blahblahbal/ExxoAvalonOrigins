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
    internal class HerbologyBenchUI : UIState
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

        public static readonly int[] Herbs = new int[]
        {
            ItemID.Daybloom,
            ItemID.Moonglow,
            ItemID.Blinkroot,
            ItemID.Deathweed,
            ItemID.Waterleaf,
            ItemID.Fireblossom,
            ItemID.Shiverthorn,
            ModContent.ItemType<Bloodberry>(),
            ModContent.ItemType<Sweetstem>(),
            ModContent.ItemType<Barfbush>()
        };

        public static readonly int[] LargeHerbs = new int[]
        {
            ModContent.ItemType<LargeDaybloom>(),
            ModContent.ItemType<LargeMoonglow>(),
            ModContent.ItemType<LargeBlinkroot>(),
            ModContent.ItemType<LargeDeathweed>(),
            ModContent.ItemType<LargeWaterleaf>(),
            ModContent.ItemType<LargeFireblossom>(),
            ModContent.ItemType<LargeShiverthorn>(),
            ModContent.ItemType<LargeBloodberry>(),
            ModContent.ItemType<LargeSweetstem>(),
            ModContent.ItemType<LargeBarfbush>()
        };

        public static readonly int[] LargeHerbSeeds = new int[]
        {
            ModContent.ItemType<LargeDaybloomSeed>(),
            ModContent.ItemType<LargeMoonglowSeed>(),
            ModContent.ItemType<LargeBlinkrootSeed>(),
            ModContent.ItemType<LargeDeathweedSeed>(),
            ModContent.ItemType<LargeWaterleafSeed>(),
            ModContent.ItemType<LargeFireblossomSeed>(),
            ModContent.ItemType<LargeShiverthornSeed>(),
            ModContent.ItemType<LargeBloodberrySeed>(),
            ModContent.ItemType<LargeSweetstemSeed>(),
            ModContent.ItemType<LargeBarfbushSeed>()
        };

        public DraggableUIPanel MainPanel;
        private PanelWrapper<AdvancedUIList> herbContainer;
        private PanelWrapper<AdvancedUIList> herbStatsWrapper;
        private UITextPanel<string> rankTitleText;
        private UITextPanel<string> herbTierText;
        private UITextPanel<string> herbTotalText;
        private UITextPanel<string> potionTotalText;
        private PanelWrapper<AdvancedUIList> herbExchangeContainer;
        private BetterUIImageButton herbButton;
        private UIItemSlot herbItemSlot;
        private PanelWrapper<AdvancedUIList> herbListContainer;
        private ElementWrapper<AdvancedUIListGrid> herbList;
        private PanelWrapper<AdvancedUIList> potionsListContainer;
        private ElementWrapper<AdvancedUIListGrid> potionsList;
        private AttachmentManager contextAttachment;
        private PanelWrapper<AdvancedUIList> contextMenu;
        private bool mouseWasOver;
        private int oldFocusRecipe;

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
            MainPanel.Width.Set(700, 0);
            MainPanel.Height.Set(660, 0);
            MainPanel.VAlign = UIAlign.Center;
            MainPanel.HAlign = UIAlign.Center;
            MainPanel.OnMouseOver += (evt, listeningElement) =>
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
            mainContainer.Append(uITextPanel, new UIListItemParams(autoDimensions: false));

            var craftingContainer = new AdvancedUIList();
            mainContainer.Append(craftingContainer, new UIListItemParams(fillLength: true));

            herbContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            herbContainer.InnerElement.Direction = Direction.Horizontal;
            craftingContainer.Append(herbContainer, new UIListItemParams(fillLength: true));

            // Herb stats

            herbStatsWrapper = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            herbStatsWrapper.InnerElement.FitParentToContentOppDirection = true;
            herbStatsWrapper.InnerElement.Justification = Justification.Center;
            herbContainer.InnerElement.Append(herbStatsWrapper);

            rankTitleText = new UITextPanel<string>("", 1, false)
            {
                TextColor = Color.Gold
            };
            rankTitleText.HAlign = UIAlign.Center;
            herbStatsWrapper.InnerElement.Append(rankTitleText, new UIListItemParams(autoDimensions: false));

            herbTierText = new UITextPanel<string>("", 1, false)
            {
                HAlign = UIAlign.Center
            };
            herbStatsWrapper.InnerElement.Append(herbTierText, new UIListItemParams(autoDimensions: false));

            herbTotalText = new UITextPanel<string>("", 1, false)
            {
                HAlign = UIAlign.Center
            };
            herbStatsWrapper.InnerElement.Append(herbTotalText, new UIListItemParams(autoDimensions: false));

            potionTotalText = new UITextPanel<string>("", 1, false)
            {
                HAlign = UIAlign.Center
            };
            herbStatsWrapper.InnerElement.Append(potionTotalText, new UIListItemParams(autoDimensions: false));

            herbExchangeContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            herbExchangeContainer.InnerElement.Justification = Justification.Center;
            herbExchangeContainer.InnerElement.FitParentToContentOppDirection = true;
            herbContainer.InnerElement.Append(herbExchangeContainer);

            herbListContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            herbContainer.InnerElement.Append(herbListContainer, new UIListItemParams(fillLength: true));

            var herbExchangeTitle = new UIText("Herb Exchange", 1, false)
            {
                HAlign = UIAlign.Center,
            };
            herbListContainer.InnerElement.Append(herbExchangeTitle, new UIListItemParams(autoDimensions: false));

            var hr1 = new HorizontalRule
            {
                MarginBottom = 5,
            };
            herbListContainer.InnerElement.Append(hr1);

            herbList = new ElementWrapper<AdvancedUIListGrid>(new AdvancedUIListGrid())
            {
                OverflowHidden = true
            };
            herbListContainer.InnerElement.Append(herbList, new UIListItemParams(fillLength: true));

            herbList.OnScrollWheel += herbList.InnerElement.ScrollWheelListener;

            var herbScrollBar = new AdvancedUIScrollbar();
            herbScrollBar.Height.Set(0, 1);
            herbScrollBar.VAlign = UIAlign.Center;
            herbScrollBar.SetPadding(0);
            herbContainer.InnerElement.Append(herbScrollBar, new UIListItemParams(autoDimensions: false));
            herbList.InnerElement.SetScrollbar(herbScrollBar);

            var potionsContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            potionsContainer.InnerElement.Direction = Direction.Horizontal;
            craftingContainer.Append(potionsContainer, new UIListItemParams(fillLength: true));

            potionsListContainer = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            potionsContainer.InnerElement.Append(potionsListContainer, new UIListItemParams(fillLength: true));

            var potionExchangeTitle = new UIText("Potion Exchange", 1, false)
            {
                HAlign = UIAlign.Center,
            };
            potionsListContainer.InnerElement.Append(potionExchangeTitle, new UIListItemParams(autoDimensions: false));

            var hr2 = new HorizontalRule
            {
                MarginBottom = 5,
            };
            potionsListContainer.InnerElement.Append(hr2);

            potionsList = new ElementWrapper<AdvancedUIListGrid>(new AdvancedUIListGrid())
            {
                OverflowHidden = true
            };
            potionsListContainer.InnerElement.Append(potionsList, new UIListItemParams(fillLength: true));

            potionsList.OnScrollWheel += potionsList.InnerElement.ScrollWheelListener;

            var potionScrollBar = new AdvancedUIScrollbar();
            potionScrollBar.Height.Set(0, 1);
            potionScrollBar.VAlign = UIAlign.Center;
            potionScrollBar.SetPadding(0);
            potionsContainer.InnerElement.Append(potionScrollBar, new UIListItemParams(autoDimensions: false));
            potionsList.InnerElement.SetScrollbar(potionScrollBar);

            contextMenu = new PanelWrapper<AdvancedUIList>(new AdvancedUIList());
            contextMenu.InnerElement.FitParentToContentOppDirection = true;
            contextMenu.InnerElement.FitParentToContentDirection = true;
            contextMenu.BackgroundColor.A = 255;

            var randText = new UIText("Overlay stuff");
            contextMenu.InnerElement.Append(randText);

            contextAttachment = new AttachmentManager(MainPanel, contextMenu, (attachment, attachmentHolder) =>
            {
                attachment.Top.Set(attachment.Top.Pixels + attachmentHolder.GetOuterDimensions().Height, 0);
            });

            firstUpdate = true;
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
            foreach (int itemID in Herbs)
            {
                var herbItem = new UIItemSlot(Main.inventoryBack7Texture, itemID);
                herbItem.OnClick += (UIMouseEvent evt, UIElement listeningElement) =>
                {
                    contextAttachment.AttachTo(listeningElement);
                };
                herbList.InnerElement.Append(herbItem);
            }
            foreach (int itemID in Potions)
            {
                potionsList.InnerElement.Append(new UIItemSlot(Main.inventoryBack7Texture, itemID));
            }
            herbButton = new BetterUIImageButton(ExxoAvalonOrigins.mod.GetTexture("Sprites/HerbButton"))
            {
                HAlign = UIAlign.Center
            };
            herbButton.OnClick += OnButtonClick;
            herbExchangeContainer.InnerElement.Append(herbButton, new UIListItemParams(autoDimensions: false));
            herbItemSlot = new UIItemSlot(Main.inventoryBack7Texture, ItemID.None);
            herbItemSlot.OnClick += (evt, listeningElement) =>
            {
                if (Main.mouseItem.type == ItemID.None || (Main.mouseItem.stack >= 1 && (ExxoAvalonOriginsGlobalItem.IsHerb(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsPotion(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsAdvancedPotion(Main.mouseItem.Name))))
                {
                    Main.PlaySound(SoundID.Grab);
                    Item item6 = Main.mouseItem;
                    Main.mouseItem = herbItemSlot.Item;
                    herbItemSlot.Item = item6;
                    Recipe.FindRecipes();
                }
            };
            herbExchangeContainer.InnerElement.Append(herbItemSlot, new UIListItemParams(autoDimensions: false));
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

            if (herbItemSlot.Item.stack <= 0)
            {
                return;
            }
            else if (!Herbs.Contains(herbItemSlot.Item.type))
            {
                if (herbItemSlot.Item.type == ModContent.ItemType<BlahPotion>())
                {
                    herbItemSlot.Item.stack--;
                    modPlayer.potionTotal += 2500;
                }
                return;
            }

            if (!modPlayer.herbCounts.ContainsKey(herbItemSlot.Item.type))
            {
                modPlayer.herbCounts.Add(herbItemSlot.Item.type, 0);
            }
            modPlayer.herbCounts[herbItemSlot.Item.type] += herbItemSlot.Item.stack;
            modPlayer.herbTotal += herbItemSlot.Item.stack;
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
