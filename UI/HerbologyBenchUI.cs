using System;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Items.Potions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI
{
    public class HerbologyBenchUI : UIState
    {
        public static readonly int[] Potions = new int[]
        {
            ModContent.ItemType<Items.AdvancedPotions.AdvObsidianSkinPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvRegenerationPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvSwiftnessPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvGillsPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvIronskinPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvManaRegenerationPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvMagicPowerPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvFeatherfallPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvSpelunkerPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvInvisibilityPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvShinePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvNightOwlPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvBattlePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvThornsPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvWaterWalkingPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvArcheryPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvHunterPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvGravitationPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvMiningPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvHeartreachPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvCalmingPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvBuilderPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvTitanPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvFlipperPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvSummoningPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvDangersensePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvAmmoReservationPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvLifeforcePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvEndurancePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvRagePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvInfernoPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvWrathPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvFishingPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvSonarPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvCratePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvWarmthPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvCrimsonPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvShockwavePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvLuckPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvBloodCastPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvStarbrightPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvVisionPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvStrengthPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvGPSPotion>(),
            ModContent.ItemType<TimeShiftPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvShadowPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvRoguePotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvGauntletPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvWisdomPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvTitanskinPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvInvincibilityPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvForceFieldPotion>(),
            ModContent.ItemType<Items.AdvancedPotions.AdvFuryPotion>()
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

        private Item herbItem = new Item();
        public UIPanel herbologyBenchDisplay;
        public UIPanel button;
        public UIText text;
        public float scale = 1f;
        private readonly Texture2D background = TomeSlot.BackgroundTexture;
        private readonly Texture2D herbButton = ExxoAvalonOrigins.mod.GetTexture("Sprites/HerbButton");

        public event Action<Item, Item> OnItemChange;

        public event Func<Item, bool> CanPutIntoSlot;

        private readonly Item[] ssa = new Item[1];
        private bool itemInSlot = false;
        public UIText place;

        public override void OnInitialize()
        {
            int xpos = 200;
            int ypos = 350;
            int xpos2 = 200;
            int ypos2 = 510;
            int xpos3 = 200;
            int ypos3 = 810;
            string tier = "Novice";
            itemInSlot = false;
            //if (Main.player[Main.myPlayer].Avalon().herbTier == 1) tier = "Apprentice";
            //if (Main.player[Main.myPlayer].Avalon().herbTier == 2) tier = "Expert";
            //if (Main.player[Main.myPlayer].Avalon().herbTier == 3) tier = "Mastery";

            herbologyBenchDisplay = new UIPanel();
            herbologyBenchDisplay.SetPadding(0);
            herbologyBenchDisplay.Left.Set(-100f, 1f);
            herbologyBenchDisplay.Top.Set(-100f, 1f);
            herbologyBenchDisplay.Width.Set(background.Width * scale, 0f);
            herbologyBenchDisplay.Height.Set(background.Height * scale, 0f);
            herbologyBenchDisplay.BackgroundColor = new Color(73, 94, 171);
            Append(herbologyBenchDisplay);

            var header = new UIText("Herbology " + tier);
            header.Left.Set(xpos - 260 + Main.fontMouseText.MeasureString("Herbology Apprentice").X, 0);
            header.Top.Set(ypos - 90, 0);
            header.HAlign = 0.5f;
            header.Top.Set(15, 0);
            herbologyBenchDisplay.Append(header);

            place = new UIText("Place an herb or potion here");
            place.Left.Set(xpos + 50 + 286, 0);
            place.Top.Set(ypos + 30 + 26 - 40, 0);
            place.HAlign = 0.5f;
            place.Top.Set(15, 0);
            herbologyBenchDisplay.Append(place);

            button = new UIPanel(); // 1

            button.Width.Set(herbButton.Width, 0);
            button.Height.Set(herbButton.Height, 0);
            button.HAlign = 0.5f;
            button.Left.Set(xpos + 50 + 286, 0);
            button.Top.Set(ypos + 30 + 26, 0); // 2
            button.OnClick += OnButtonClick; // 3
            herbologyBenchDisplay.Append(button);
        }

        public override void Update(GameTime gameTime)
        {
            if (button.IsMouseHovering)
            {
                Main.hoverItemName = "Consume Herb/Potion";
            }
            if (!itemInSlot)
            {
                place.SetText("");
            }
            else
            {
                place.SetText("Place an herb or potion here");
            }
        }

        private void OnButtonClick(UIMouseEvent evt, UIElement listeningElement)
        {
            int xpos = 200;
            int ypos = 350;
            int xpos2 = 200;
            int ypos2 = 510;
            int xpos3 = 200;
            int ypos3 = 810;
            int num67 = xpos + 50 + 286;
            int num68 = ypos + 30 + 26;
            if (herbItem.type > ItemID.None)
            {
                if (herbItem.type == ItemID.Daybloom)
                {
                    Main.player[Main.myPlayer].Avalon().herbCounts[0] += herbItem.stack;
                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                }
                if (herbItem.type == ItemID.Moonglow)
                {
                    Main.player[Main.myPlayer].Avalon().herbCounts[1] += herbItem.stack;
                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                }
                if (herbItem.type == ItemID.Blinkroot)
                {
                    Main.player[Main.myPlayer].Avalon().herbCounts[2] += herbItem.stack;
                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                }
                if (herbItem.type == ItemID.Deathweed)
                {
                    Main.player[Main.myPlayer].Avalon().herbCounts[3] += herbItem.stack;
                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                }
                if (herbItem.type == ItemID.Waterleaf)
                {
                    Main.player[Main.myPlayer].Avalon().herbCounts[4] += herbItem.stack;
                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                }
                if (herbItem.type == ItemID.Fireblossom)
                {
                    Main.player[Main.myPlayer].Avalon().herbCounts[5] += herbItem.stack;
                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                }
                if (herbItem.type == ItemID.Shiverthorn)
                {
                    Main.player[Main.myPlayer].Avalon().herbCounts[6] += herbItem.stack;
                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                }
                if (herbItem.type == ModContent.ItemType<BlahPotion>())
                {
                    Main.player[Main.myPlayer].Avalon().potionTotal += 2500;
                }
                if (Main.player[Main.myPlayer].Avalon().herbTotal < 250)
                {
                    Main.player[Main.myPlayer].Avalon().herbTier = 0; // tier 1; allows for exchanging one herb for another
                }
                if (Main.player[Main.myPlayer].Avalon().herbTotal >= 250 && Main.player[Main.myPlayer].Avalon().herbTotal < 750)
                {
                    Main.player[Main.myPlayer].Avalon().herbTier = 1; // tier 2; allows for large herb seeds
                }
                if (Main.player[Main.myPlayer].Avalon().herbTotal >= 750 && Main.player[Main.myPlayer].Avalon().herbTotal < 1500)
                {
                    if (Main.hardMode)
                    {
                        Main.player[Main.myPlayer].Avalon().herbTier = 2; // tier 3; allows you to obtain advanced potions
                    }
                    else
                    {
                        Main.player[Main.myPlayer].Avalon().herbTier = 1;
                    }
                }
                if (Main.player[Main.myPlayer].Avalon().herbTotal >= 1500)
                {
                    if (Main.hardMode)
                    {
                        Main.player[Main.myPlayer].Avalon().herbTier = 3; // tier 4; Blah Potion exchange
                    }
                    else
                    {
                        Main.player[Main.myPlayer].Avalon().herbTier = 1;
                    }
                }
                ItemText.NewText(herbItem, herbItem.stack, false, false);
                herbItem = new Item
                {
                    stack = 0
                };
                Main.PlaySound(SoundID.Item, -1, -1, ExxoAvalonOrigins.mod.GetSoundSlot(SoundType.Item, "Sounds/Item/HerbConsume"));
            }
        }

        public void DrawHerbologyInterface(SpriteBatch spriteBatch)
        {
            int xpos = 200;
            int ypos = 350;
            int xpos2 = 200;
            int ypos2 = 510;
            int xpos3 = 200;
            int ypos3 = 810;
            if (Main.playerInventory && Main.LocalPlayer.Avalon().herb)
            {
                if (Main.player[Main.myPlayer].chest != -1 || Main.npcShop != 0)
                {
                    Main.LocalPlayer.Avalon().herb = false;
                    Main.player[Main.myPlayer].dropItemCheck();
                    Recipe.FindRecipes();
                }
                else
                {
                    string tier = "Novice";
                    if (Main.player[Main.myPlayer].Avalon().herbTier == 1)
                    {
                        tier = "Apprentice";
                    }

                    if (Main.player[Main.myPlayer].Avalon().herbTier == 2)
                    {
                        tier = "Expert";
                    }

                    if (Main.player[Main.myPlayer].Avalon().herbTier == 3)
                    {
                        tier = "Mastery";
                    }

                    spriteBatch.DrawOutlinedString(Main.fontMouseText, "Herbology " + tier, new Vector2(xpos - 260 + Main.fontMouseText.MeasureString("Herbology Apprentice").X, (float)ypos - 90), Color.Goldenrod, Color.Black, 1f, 1f);
                    spriteBatch.DrawOutlinedString(Main.fontMouseText, "Herb Total: " + Main.player[Main.myPlayer].Avalon().herbTotal, new Vector2(xpos - 50 + Main.fontMouseText.MeasureString("Herb Total:      ").X, (float)ypos - 90), Color.White, Color.Black, 1f, 1f);
                    spriteBatch.DrawOutlinedString(Main.fontMouseText, "Herb Tier: " + (Main.player[Main.myPlayer].Avalon().herbTier + 1).ToString(), new Vector2(xpos - 50 + Main.fontMouseText.MeasureString("Herb Total:      ").X, (float)ypos - 60), Color.White, Color.Black, 1f, 1f);
                    if (Main.player[Main.myPlayer].Avalon().herbTier >= 1)
                    {
                        spriteBatch.DrawOutlinedString(Main.fontMouseText, "Right click to obtain a Large Herb Seed if you have 15 or more of that herb", new Vector2(xpos - 200 + Main.fontMouseText.MeasureString("Herbology Bench").X, (float)ypos + 100), Color.White, Color.Black, 1.2f, 1f);
                    }

                    spriteBatch.DrawOutlinedString(Main.fontMouseText, "Potion Total: " + Main.player[Main.myPlayer].Avalon().potionTotal, new Vector2(xpos - 260 + Main.fontMouseText.MeasureString("Herbology Apprentice").X, (float)ypos - 60), Color.White, Color.Black, 1.2f, 1f);
                    if (Main.player[Main.myPlayer].Avalon().herbTier >= 2)
                    {
                        spriteBatch.DrawOutlinedString(Main.fontMouseText, "Click to obtain a potion (Requires 1 Potion credit); Right-click to obtain an Advanced Potion (requires 5 Potion credits); Hold left shift to get 5", new Vector2(xpos - 200 + Main.fontMouseText.MeasureString("Herbology Bench").X, (float)ypos + 405), Color.White, Color.Black, 1.2f, 1f);
                    }

                    if (Main.player[Main.myPlayer].Avalon().herbTier >= 3 && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
                    {
                        spriteBatch.DrawOutlinedString(Main.fontMouseText, "Click to obtain a Blah Potion (requires 2500 Potion credits)", new Vector2(xpos - 200 + Main.fontMouseText.MeasureString("Herbology Bench").X, (float)ypos + 493), Color.White, Color.Black, 1.2f, 1f);
                    }
                    //spriteBatch.Draw(Main.inventoryBack3Texture, new Vector2((float)(xpos + 10 + 286), (float)ypos + 26), null, Color.White, 0f, new Vector2((float)(Main.inventoryBack4Texture.Width / 2), (float)(Main.inventoryBack4Texture.Height / 2)), 1f, SpriteEffects.None, 0f);
                    var mouseLoc = new Point(Main.mouseX, Main.mouseY);
                    var r = new Rectangle(0, 0, (int)(Main.inventoryBackTexture.Width * 0.9), (int)(Main.inventoryBackTexture.Height * 0.9));
                    Main.inventoryScale = 0.85f;
                    Item tmpItem = herbItem;
                    //var mH = 0;
                    itemInSlot = herbItem.type > ItemID.None;
                    r.X = xpos + 286;
                    r.Y = ypos + 16;
                    if (r.Contains(mouseLoc))
                    {
                        Main.LocalPlayer.mouseInterface = true;
                        Main.armorHide = true;
                        if (Main.mouseLeftRelease && Main.mouseLeft)
                        {
                            if (Main.mouseItem.stack >= 1 && (ExxoAvalonOriginsGlobalItem.IsHerb(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsPotion(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsAdvancedPotion(Main.mouseItem.Name)) && herbItem.type == ItemID.None)
                            {
                                Main.PlaySound(SoundID.Grab, -1, -1, 1);
                                Item item6 = Main.mouseItem;
                                Main.mouseItem = herbItem;
                                herbItem = item6;
                            }
                            else if (Main.mouseItem.type == ItemID.None && herbItem.type > ItemID.None)
                            {
                                Item item7 = Main.mouseItem;
                                Main.mouseItem = herbItem;
                                herbItem = item7;
                                if (herbItem.type == ItemID.None || herbItem.stack < 1)
                                {
                                    herbItem = new Item();
                                }
                                if (Main.mouseItem.type == ItemID.None || Main.mouseItem.stack < 1)
                                {
                                    Main.mouseItem = new Item();
                                }
                                if (Main.mouseItem.type > ItemID.None || herbItem.type > ItemID.None)
                                {
                                    Recipe.FindRecipes();
                                    Main.PlaySound(SoundID.Grab, -1, -1, 1);
                                }
                            }
                        }
                        Main.hoverItemName = herbItem.type > ItemID.None ? herbItem.Name : "";
                        Main.HoverItem = herbItem.Clone();
                    }
                    ssa[0] = tmpItem;
                    ItemSlot.Draw(spriteBatch, ssa, 10, 0, new Vector2(r.X, r.Y));
                    tmpItem = ssa[0];

                    int num67 = xpos + 50 + 295;
                    int num68 = ypos + 30 + 30;

                    #region adding to herb/potion total

                    if (herbItem.type > ItemID.None)
                    {
                        spriteBatch.Draw(herbButton, new Vector2(num67, num68), new Rectangle?(new Rectangle(0, 0, herbButton.Width, herbButton.Height)), Color.White, 0f, new Vector2(herbButton.Width / 2, herbButton.Height / 2), 1f, SpriteEffects.None, 0f);
                        if (Main.mouseX > num67 - herbButton.Width / 2 && Main.mouseX < num67 + herbButton.Width / 2 && Main.mouseY > num68 - herbButton.Height / 2 && Main.mouseY < num68 + herbButton.Height / 2)
                        {
                            Main.hoverItemName = "Consume Herb/Potion";
                            Main.player[Main.myPlayer].mouseInterface = true;
                            if (Main.mouseLeftRelease && Main.mouseLeft)
                            {
                                if (herbItem.type == ItemID.Daybloom)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[0] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ItemID.Moonglow)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[1] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ItemID.Blinkroot)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[2] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ItemID.Deathweed)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[3] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ItemID.Waterleaf)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[4] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ItemID.Fireblossom)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[5] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ItemID.Shiverthorn)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[6] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ModContent.ItemType<Bloodberry>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[7] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ModContent.ItemType<Sweetstem>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[8] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ModContent.ItemType<Barfbush>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[9] += herbItem.stack;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeDaybloom>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[0] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeDaybloomSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[0] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeMoonglow>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[1] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeMoonglowSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[1] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeBlinkroot>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[2] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeBlinkrootSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[2] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeDeathweed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[3] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeDeathweedSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[3] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeWaterleaf>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[4] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeWaterleafSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[4] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeFireblossom>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[5] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeFireblossomSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[5] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeShiverthorn>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[6] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeShiverthornSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[6] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeBloodberry>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[7] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeBloodberrySeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[7] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeSweetstem>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[8] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeSweetstemSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[8] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeBarfbush>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[9] += herbItem.stack * 20;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 20;
                                }
                                if (herbItem.type == ModContent.ItemType<LargeBarfbushSeed>())
                                {
                                    Main.player[Main.myPlayer].Avalon().herbCounts[9] += herbItem.stack * 15;
                                    Main.player[Main.myPlayer].Avalon().herbTotal += herbItem.stack * 15;
                                }
                                if ((herbItem.type >= ItemID.ObsidianSkinPotion && herbItem.type <= ItemID.GravitationPotion) || (herbItem.type >= ItemID.MiningPotion && herbItem.type <= ItemID.TrapsightPotion) ||
                                    (herbItem.type >= ItemID.AmmoReservationPotion && herbItem.type <= ItemID.WrathPotion) || (herbItem.type >= ItemID.FishingPotion && herbItem.type <= ItemID.CratePotion) ||
                                    herbItem.type == ItemID.WarmthPotion || herbItem.type == ModContent.ItemType<CrimsonPotion>() || herbItem.type == ModContent.ItemType<ShockwavePotion>() ||
                                    herbItem.type == ModContent.ItemType<LuckPotion>() || herbItem.type == ModContent.ItemType<BloodCastPotion>() || herbItem.type == ModContent.ItemType<StarbrightPotion>() ||
                                    herbItem.type == ModContent.ItemType<VisionPotion>() || herbItem.type == ModContent.ItemType<StrengthPotion>() || herbItem.type == ModContent.ItemType<GPSPotion>() ||
                                    herbItem.type == ModContent.ItemType<TimeShiftPotion>() || herbItem.type == ModContent.ItemType<ShadowPotion>() || herbItem.type == ModContent.ItemType<RoguePotion>() ||
                                    herbItem.type == ModContent.ItemType<WisdomPotion>() || herbItem.type == ModContent.ItemType<GauntletPotion>() || herbItem.type == ModContent.ItemType<TitanskinPotion>() ||
                                    herbItem.type == ModContent.ItemType<InvincibilityPotion>() || herbItem.type == ModContent.ItemType<ForceFieldPotion>()) // || herbItem.type == ModContent.ItemType<Items.MagnetPotion>())
                                {
                                    Main.player[Main.myPlayer].Avalon().potionTotal += herbItem.stack;
                                }
                                if (herbItem.Name.Contains("Elixir") && herbItem.type != ModContent.ItemType<Items.Potions.ElixirofLife>())
                                {
                                    Main.player[Main.myPlayer].Avalon().potionTotal += herbItem.stack * 10;
                                }
                                if (herbItem.type == ModContent.ItemType<BlahPotion>())
                                {
                                    Main.player[Main.myPlayer].Avalon().potionTotal += 2500;
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTotal < 250)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbTier = 0; // tier 1; allows for exchanging one herb for another
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTotal >= 250 && Main.player[Main.myPlayer].Avalon().herbTotal < 750)
                                {
                                    Main.player[Main.myPlayer].Avalon().herbTier = 1; // tier 2; allows for large herb seeds
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTotal >= 750 && Main.player[Main.myPlayer].Avalon().herbTotal < 1500)
                                {
                                    if (Main.hardMode)
                                    {
                                        Main.player[Main.myPlayer].Avalon().herbTier = 2; // tier 3; allows you to obtain advanced potions
                                    }
                                    else
                                    {
                                        Main.player[Main.myPlayer].Avalon().herbTier = 1;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTotal >= 1500)
                                {
                                    if (Main.hardMode)
                                    {
                                        Main.player[Main.myPlayer].Avalon().herbTier = 3; // tier 4; Blah Potion exchange
                                    }
                                    else
                                    {
                                        Main.player[Main.myPlayer].Avalon().herbTier = 1;
                                    }
                                }
                                ItemText.NewText(herbItem, herbItem.stack, false, false);
                                herbItem = new Item
                                {
                                    stack = 0
                                };
                                Main.PlaySound(SoundID.Item, -1, -1, ExxoAvalonOrigins.mod.GetSoundSlot(SoundType.Item, "Sounds/Item/HerbConsume"));
                            }
                        }
                        //else
                        //{
                        //    Main.mouseReforge = false;
                        //}
                    }

                    #endregion adding to herb/potion total

                    else
                    {
                        spriteBatch.DrawOutlinedString(Main.fontMouseText, "Place an herb or potion here", new Vector2(num67, num68 - 40), Color.White, Color.Black, 1.2f, 1f);
                    }
                    //if (Main.mouseX >= xpos + 10 + 286 - Main.inventoryBack4Texture.Width / 2 && (float)Main.mouseX <= (float)xpos + 10 + 286 + (float)Main.inventoryBack4Texture.Width / 2 && Main.mouseY >= ypos + 26 - Main.inventoryBack4Texture.Height / 2 && (float)Main.mouseY <= (float)ypos + 26 + (float)Main.inventoryBack4Texture.Height / 2)
                    //{
                    //    Main.player[Main.myPlayer].mouseInterface = true;
                    //    Main.craftingHide = true;
                    //    if (ExxoAvalonOriginsGlobalItem.IsHerb(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsPotion(Main.mouseItem.type) || Main.mouseItem.type == 0)
                    //    {
                    //        if (Main.mouseLeftRelease && Main.mouseLeft && Main.player[Main.myPlayer].itemTime == 0)
                    //        {
                    //            Item item9 = Main.mouseItem;
                    //            Main.mouseItem = herbItem;
                    //            herbItem = item9;
                    //            if (herbItem.type == 0 || herbItem.stack < 1)
                    //            {
                    //                herbItem = new Item();
                    //            }
                    //            if (Main.mouseItem.IsTheSameAs(Main.reforgeItem) && herbItem.stack != herbItem.maxStack && Main.mouseItem.stack != Main.mouseItem.maxStack)
                    //            {
                    //                if (Main.mouseItem.stack + herbItem.stack <= Main.mouseItem.maxStack)
                    //                {
                    //                    herbItem.stack += Main.mouseItem.stack;
                    //                    Main.mouseItem.stack = 0;
                    //                }
                    //                else
                    //                {
                    //                    int num69 = Main.mouseItem.maxStack - herbItem.stack;
                    //                    herbItem.stack += num69;
                    //                    Main.mouseItem.stack -= num69;
                    //                }
                    //            }
                    //            if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
                    //            {
                    //                Main.mouseItem = new Item();
                    //            }
                    //            if (Main.mouseItem.type > 0 || herbItem.type > 0)
                    //            {
                    //                Recipe.FindRecipes();
                    //                Main.PlaySound(7, -1, -1, 1);
                    //            }
                    //        }
                    //        else if (Main.stackSplit <= 1 && Main.mouseRight && (Main.mouseItem.IsTheSameAs(herbItem) || Main.mouseItem.type == 0) && (Main.mouseItem.stack < Main.mouseItem.maxStack || Main.mouseItem.type == 0))
                    //        {
                    //            if (Main.mouseItem.type == 0)
                    //            {
                    //                Main.mouseItem = herbItem.Clone();
                    //                Main.mouseItem.stack = 0;
                    //            }
                    //            Main.mouseItem.stack++;
                    //            herbItem.stack--;
                    //            if (herbItem.stack <= 0)
                    //            {
                    //                herbItem = new Item();
                    //            }
                    //            Recipe.FindRecipes();
                    //            Main.soundInstanceMenuTick.Stop();
                    //            Main.soundInstanceMenuTick = Main.soundMenuTick.CreateInstance();
                    //            Main.PlaySound(12, -1, -1, 1);
                    //            if (Main.stackSplit == 0)
                    //            {
                    //                Main.stackSplit = 15;
                    //            }
                    //            else
                    //            {
                    //                Main.stackSplit = Main.stackDelay;
                    //            }
                    //        }
                    //    }
                    //    Main.hoverItemName = herbItem.Name;
                    //    Main.HoverItem = herbItem.Clone();
                    //    if (herbItem.stack > 1)
                    //    {
                    //        object obj = Main.hoverItemName;
                    //        Main.hoverItemName = string.Concat(new object[]
                    //        {
                    //            obj,
                    //            " (",
                    //            herbItem.stack,
                    //            ")"
                    //        });
                    //    }
                    //}
                    if (Main.player[Main.myPlayer].Avalon().herbTier >= 3 && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode)
                    {
                        spriteBatch.Draw(Main.inventoryBack7Texture, new Vector2(xpos3 + 10, ypos3), null, Color.White, 0f, new Vector2(Main.inventoryBack4Texture.Width / 2, Main.inventoryBack4Texture.Height / 2), 1f, SpriteEffects.None, 0f);
                        spriteBatch.Draw(ExxoAvalonOrigins.mod.GetTexture("Items/BlahPotion"), new Vector2(xpos3 + 10, ypos3), null, Color.White, 0f, new Vector2(ExxoAvalonOrigins.mod.GetTexture("Items/BlahPotion").Width / 2, ExxoAvalonOrigins.mod.GetTexture("Items/BlahPotion").Height / 2), 1f, SpriteEffects.None, 0f);
                        if (Main.mouseX > xpos3 + 10 - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos3 + 10 + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos3 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos3 + Main.inventoryBack4Texture.Height / 2)
                        {
                            Main.player[Main.myPlayer].mouseInterface = true;
                            Main.hoverItemName = "Blah Potion";
                        }
                        if (Main.player[Main.myPlayer].Avalon().potionTotal > 2500)
                        {
                            if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos3 + 10 - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos3 + 10 + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos3 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos3 + Main.inventoryBack4Texture.Height / 2)
                            {
                                int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<BlahPotion>(), 1);
                                Main.item[x].owner = Main.myPlayer;
                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                {
                                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                }
                                Main.player[Main.myPlayer].Avalon().potionTotal -= 2500;
                            }
                        }
                    }

                    #region Advanced Potions

                    if (Main.player[Main.myPlayer].Avalon().herbTier >= 2)
                    {
                        for (int p = 0; p < 53; p++)
                        {
                            spriteBatch.Draw(Main.inventoryBack7Texture, new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.inventoryBack4Texture.Width / 2, Main.inventoryBack4Texture.Height / 2), 1f, SpriteEffects.None, 0f);
                            if (Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                            {
                                Main.player[Main.myPlayer].mouseInterface = true;
                                Main.hoverItemName = Lang.GetItemName(Potions[p]).Value;
                            }
                            switch (p)
                            {
                                case 0:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            if (Main.player[Main.myPlayer].Avalon().potionTotal >= 5 && Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
                                            {
                                                int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.ObsidianSkinPotion, 5);
                                                Main.item[x].owner = Main.myPlayer;
                                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                                {
                                                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                                }
                                                Main.player[Main.myPlayer].Avalon().potionTotal -= 5;
                                            }
                                            else
                                            {
                                                int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.ObsidianSkinPotion, 1);
                                                Main.item[x].owner = Main.myPlayer;
                                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                                {
                                                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                                }
                                                Main.player[Main.myPlayer].Avalon().potionTotal--;
                                            }
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            if (Main.player[Main.myPlayer].Avalon().potionTotal >= 50 && Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift))
                                            {
                                                int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvObsidianSkinPotion>(), 5);
                                                Main.item[x].owner = Main.myPlayer;
                                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                                {
                                                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                                }
                                                Main.player[Main.myPlayer].Avalon().potionTotal -= 50;
                                            }
                                            else
                                            {
                                                int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvObsidianSkinPotion>(), 1);
                                                Main.item[x].owner = Main.myPlayer;
                                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                                {
                                                    NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                                }
                                                Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                            }
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.ObsidianSkinPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.ObsidianSkinPotion].Width / 2, Main.itemTexture[ItemID.ObsidianSkinPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 1:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.RegenerationPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvRegenerationPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.RegenerationPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.RegenerationPotion].Width / 2, Main.itemTexture[ItemID.RegenerationPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 2:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.SwiftnessPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvSwiftnessPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.SwiftnessPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.SwiftnessPotion].Width / 2, Main.itemTexture[ItemID.SwiftnessPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 3:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.GillsPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvGillsPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.GillsPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.GillsPotion].Width / 2, Main.itemTexture[ItemID.GillsPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 4:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.IronskinPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvIronskinPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.IronskinPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.IronskinPotion].Width / 2, Main.itemTexture[ItemID.IronskinPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 5:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.ManaRegenerationPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvManaRegenerationPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.ManaRegenerationPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.ManaRegenerationPotion].Width / 2, Main.itemTexture[ItemID.ManaRegenerationPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 6:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.MagicPowerPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvMagicPowerPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.MagicPowerPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.MagicPowerPotion].Width / 2, Main.itemTexture[ItemID.MagicPowerPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 7:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.FeatherfallPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvFeatherfallPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.FeatherfallPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.FeatherfallPotion].Width / 2, Main.itemTexture[ItemID.FeatherfallPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 8:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.SpelunkerPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvSpelunkerPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.SpelunkerPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.SpelunkerPotion].Width / 2, Main.itemTexture[ItemID.SpelunkerPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 9:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.InvisibilityPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvInvisibilityPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.InvisibilityPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.InvisibilityPotion].Width / 2, Main.itemTexture[ItemID.InvisibilityPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 10:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.ShinePotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvShinePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.ShinePotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.ShinePotion].Width / 2, Main.itemTexture[ItemID.ShinePotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 11:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.NightOwlPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvNightOwlPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.NightOwlPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.NightOwlPotion].Width / 2, Main.itemTexture[ItemID.NightOwlPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 12:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.BattlePotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvBattlePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.BattlePotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.BattlePotion].Width / 2, Main.itemTexture[ItemID.BattlePotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 13:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.ThornsPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvThornsPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.ThornsPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.ThornsPotion].Width / 2, Main.itemTexture[ItemID.ThornsPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 14:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.WaterWalkingPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvWaterWalkingPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.WaterWalkingPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.WaterWalkingPotion].Width / 2, Main.itemTexture[ItemID.WaterWalkingPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 15:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.ArcheryPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvArcheryPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.ArcheryPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.ArcheryPotion].Width / 2, Main.itemTexture[ItemID.ArcheryPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 16:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.HunterPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvHunterPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.HunterPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.HunterPotion].Width / 2, Main.itemTexture[ItemID.HunterPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 17:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.GravitationPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvGravitationPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.GravitationPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.GravitationPotion].Width / 2, Main.itemTexture[ItemID.GravitationPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 18:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.MiningPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvMiningPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.MiningPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.MiningPotion].Width / 2, Main.itemTexture[ItemID.MiningPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 19:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.HeartreachPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvHeartreachPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.HeartreachPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.HeartreachPotion].Width / 2, Main.itemTexture[ItemID.HeartreachPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 20:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.CalmingPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvCalmingPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.CalmingPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.CalmingPotion].Width / 2, Main.itemTexture[ItemID.CalmingPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 21:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.BuilderPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvBuilderPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.BuilderPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.BuilderPotion].Width / 2, Main.itemTexture[ItemID.BuilderPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 22:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.TitanPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvTitanPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.TitanPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.TitanPotion].Width / 2, Main.itemTexture[ItemID.TitanPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 23:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.FlipperPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvFlipperPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.FlipperPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.FlipperPotion].Width / 2, Main.itemTexture[ItemID.FlipperPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 24:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.SummoningPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvSummoningPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.SummoningPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.SummoningPotion].Width / 2, Main.itemTexture[ItemID.SummoningPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 25:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.TrapsightPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvDangersensePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.TrapsightPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.TrapsightPotion].Width / 2, Main.itemTexture[ItemID.TrapsightPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 26:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.AmmoReservationPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvAmmoReservationPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.AmmoReservationPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.AmmoReservationPotion].Width / 2, Main.itemTexture[ItemID.AmmoReservationPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 27:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LifeforcePotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvLifeforcePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.LifeforcePotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.LifeforcePotion].Width / 2, Main.itemTexture[ItemID.LifeforcePotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 28:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.EndurancePotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvEndurancePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.EndurancePotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.EndurancePotion].Width / 2, Main.itemTexture[ItemID.EndurancePotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 29:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.RagePotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvRagePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.RagePotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.RagePotion].Width / 2, Main.itemTexture[ItemID.RagePotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 30:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.InfernoPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvInfernoPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.InfernoPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.InfernoPotion].Width / 2, Main.itemTexture[ItemID.InfernoPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 31:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.WrathPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvWrathPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.WrathPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.WrathPotion].Width / 2, Main.itemTexture[ItemID.WrathPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 32:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.FishingPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvFishingPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.FishingPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.FishingPotion].Width / 2, Main.itemTexture[ItemID.FishingPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 33:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.SonarPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvSonarPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.SonarPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.SonarPotion].Width / 2, Main.itemTexture[ItemID.SonarPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 34:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.CratePotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvCratePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.CratePotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.CratePotion].Width / 2, Main.itemTexture[ItemID.CratePotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 35:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.WarmthPotion, 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvWarmthPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ItemID.WarmthPotion], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.WarmthPotion].Width / 2, Main.itemTexture[ItemID.WarmthPotion].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 36:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<CrimsonPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvCrimsonPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<CrimsonPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<CrimsonPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<CrimsonPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 37:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<ShockwavePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvShockwavePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<ShockwavePotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<ShockwavePotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<ShockwavePotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 38:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LuckPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvLuckPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<LuckPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<LuckPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<LuckPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 39:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<BloodCastPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvBloodCastPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<BloodCastPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<BloodCastPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<BloodCastPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 40:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<StarbrightPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvStarbrightPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<StarbrightPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<StarbrightPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<StarbrightPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 41:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<VisionPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvVisionPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<VisionPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<VisionPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<VisionPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 42:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<StrengthPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvStrengthPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<StrengthPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<StrengthPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<StrengthPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 43:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<GPSPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvGPSPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<GPSPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<GPSPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<GPSPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 44:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<TimeShiftPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    //if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    //{
                                    //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                    //    {
                                    //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvTimeShiftPotion>(), 1);
                                    //        Main.item[x].owner = Main.myPlayer;
                                    //        if (Main.netMode == NetmodeID.MultiplayerClient)
                                    //        {
                                    //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                    //        }
                                    //        Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                    //    }
                                    //}
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<TimeShiftPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<TimeShiftPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<TimeShiftPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 45:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<ShadowPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvShadowPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<ShadowPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<ShadowPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<ShadowPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 46:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<RoguePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvRoguePotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<RoguePotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<RoguePotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<RoguePotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 47:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<GauntletPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvGauntletPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<GauntletPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<GauntletPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<GauntletPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 48:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<WisdomPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvWisdomPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<WisdomPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<WisdomPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<WisdomPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 49:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<TitanskinPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvTitanskinPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<TitanskinPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<TitanskinPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<TitanskinPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 50:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            Main.NewText("This potion is unobtainable.", 230, 230, 25);
                                            //int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, 3873 + p, 1);
                                            //Main.item[x].owner = Main.myPlayer;
                                            //if (Main.netMode == NetmodeID.MultiplayerClient)
                                            //{
                                            //    NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            //}
                                            //Main.player[Main.myPlayer].Avalon().potionTotal -= 5;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            Main.NewText("This potion is unobtainable.", 230, 230, 25);
                                            //    int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvShockwavePotion>(), 1);
                                            //    Main.item[x].owner = Main.myPlayer;
                                            //    if (Main.netMode == NetmodeID.MultiplayerClient)
                                            //    {
                                            //        NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            //    }
                                            //    Main.player[Main.myPlayer].Avalon().potionTotal -= 5;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<InvincibilityPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<InvincibilityPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<InvincibilityPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 51:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<ForceFieldPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvForceFieldPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<ForceFieldPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<ForceFieldPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<ForceFieldPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;

                                case 52:
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 1)
                                    {
                                        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.Potions.FuryPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal--;
                                        }
                                    }
                                    if (Main.player[Main.myPlayer].Avalon().potionTotal >= 10)
                                    {
                                        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos2 + 10 + (p * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos2 + 10 + (p * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos2 - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos2 + Main.inventoryBack4Texture.Height / 2)
                                        {
                                            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Items.AdvancedPotions.AdvFuryPotion>(), 1);
                                            Main.item[x].owner = Main.myPlayer;
                                            if (Main.netMode == NetmodeID.MultiplayerClient)
                                            {
                                                NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                            }
                                            Main.player[Main.myPlayer].Avalon().potionTotal -= 10;
                                        }
                                    }
                                    spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<Items.Potions.FuryPotion>()], new Vector2(xpos2 + 10 + (p * 52), ypos2), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<Items.Potions.FuryPotion>()].Width / 2, Main.itemTexture[ModContent.ItemType<Items.Potions.FuryPotion>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                    break;
                            }
                            if (p % 13 == 12)
                            {
                                ypos2 += 52;
                                xpos2 -= 676;
                            }
                        }
                    }

                    #endregion Advanced Potions

                    #region herb exchange

                    for (int xoff = 0; xoff < 10; xoff++)
                    {
                        spriteBatch.Draw(Main.inventoryBack7Texture, new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.inventoryBack4Texture.Width / 2, Main.inventoryBack4Texture.Height / 2), 1f, SpriteEffects.None, 0f);
                        if (Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                        {
                            Main.player[Main.myPlayer].mouseInterface = true;
                            Main.hoverItemName = Lang.GetItemName(Herbs[xoff]).Value + ": " + Main.player[Main.myPlayer].Avalon().herbCounts[xoff].ToString() + "\nClick to exchange";
                        }
                        switch (xoff)
                        {
                            case 0:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Daybloom, 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[0]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[0] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeDaybloomSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[0] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ItemID.Daybloom], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.Daybloom].Width / 2, Main.itemTexture[ItemID.Daybloom].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 1:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Moonglow, 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[1]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[1] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeMoonglowSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[1] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ItemID.Moonglow], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.Moonglow].Width / 2, Main.itemTexture[ItemID.Moonglow].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 2:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Blinkroot, 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[2]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[2] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeBlinkrootSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[2] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ItemID.Blinkroot], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.Blinkroot].Width / 2, Main.itemTexture[ItemID.Blinkroot].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 3:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Deathweed, 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[3]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[3] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeDeathweedSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[3] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ItemID.Deathweed], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.Deathweed].Width / 2, Main.itemTexture[ItemID.Deathweed].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 4:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Waterleaf, 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[4]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[4] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeWaterleafSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[4] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ItemID.Waterleaf], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.Waterleaf].Width / 2, Main.itemTexture[ItemID.Waterleaf].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 5:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Fireblossom, 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[5]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[5] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeFireblossomSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[5] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ItemID.Fireblossom], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.Fireblossom].Width / 2, Main.itemTexture[ItemID.Fireblossom].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 6:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Shiverthorn, 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[6]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[6] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeShiverthornSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[6] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ItemID.Shiverthorn], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ItemID.Shiverthorn].Width / 2, Main.itemTexture[ItemID.Shiverthorn].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 7:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Bloodberry>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[7]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[7] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeBloodberrySeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[7] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<Bloodberry>()], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<Bloodberry>()].Width / 2, Main.itemTexture[ModContent.ItemType<Bloodberry>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 8:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Sweetstem>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[8]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[8] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeSweetstemSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[8] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<Sweetstem>()], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<Sweetstem>()].Width / 2, Main.itemTexture[ModContent.ItemType<Sweetstem>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;

                            case 9:
                                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<Barfbush>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbTotal--;
                                        Main.player[Main.myPlayer].Avalon().herbCounts[9]--;
                                    }
                                }
                                if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[9] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
                                {
                                    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
                                    {
                                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ModContent.ItemType<LargeBarfbushSeed>(), 1);
                                        Main.item[x].owner = Main.myPlayer;
                                        if (Main.netMode == NetmodeID.MultiplayerClient)
                                        {
                                            NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
                                        }
                                        Main.player[Main.myPlayer].Avalon().herbCounts[9] -= 15;
                                        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
                                    }
                                }
                                spriteBatch.Draw(Main.itemTexture[ModContent.ItemType<Barfbush>()], new Vector2(xpos + 10 + (xoff * 52), ypos), null, Color.White, 0f, new Vector2(Main.itemTexture[ModContent.ItemType<Barfbush>()].Width / 2, Main.itemTexture[ModContent.ItemType<Barfbush>()].Height / 2), 1f, SpriteEffects.None, 0f);
                                break;
                        }
                        if (xoff % 5 == 4)
                        {
                            ypos += 52;
                            xpos -= 260;
                        }
                    }

                    #endregion herb exchange
                }
            }
        }

        //if (Main.playerInventory && ExxoAvalonOrigins.herb)
        //{
        //int xpos = 200;
        //int ypos = 350;
        //int xpos2 = 200;
        //int ypos2 = 510;
        //int xpos3 = 200;
        //int ypos3 = 810;
        //    var mouseLoc = new Point(Main.mouseX, Main.mouseY);
        //    var r = new Rectangle(0, 0, (int)(Main.inventoryBackTexture.Width * 0.9), (int)(Main.inventoryBackTexture.Height * 0.9));
        //    Main.inventoryScale = 0.85f;
        //    var tmpItem = herbItem;
        //    var mH = 0;
        //    itemInSlot = herbItem.type > 0;
        //    r.X = xpos + 10 + 286;
        //    r.Y = ypos + 26;
        //    if (r.Contains(mouseLoc))
        //    {
        //        Main.LocalPlayer.mouseInterface = true;
        //        Main.armorHide = true;
        //        if (Main.mouseLeftRelease && Main.mouseLeft)
        //        {
        //            if (Main.mouseItem.stack >= 1 && (ExxoAvalonOriginsGlobalItem.IsHerb(Main.mouseItem.type) || ExxoAvalonOriginsGlobalItem.IsPotion(Main.mouseItem.type)) && herbItem.type == 0)
        //            {
        //                Main.PlaySound(7, -1, -1, 1);
        //                Item item6 = Main.mouseItem;
        //                Main.mouseItem = herbItem;
        //                herbItem = item6;
        //            }
        //            else if (Main.mouseItem.type == 0 && herbItem.type > 0)
        //            {
        //                Item item7 = Main.mouseItem;
        //                Main.mouseItem = herbItem;
        //                herbItem = item7;
        //                if (herbItem.type == 0 || herbItem.stack < 1)
        //                {
        //                    herbItem = new Item();
        //                }
        //                if (Main.mouseItem.type == 0 || Main.mouseItem.stack < 1)
        //                {
        //                    Main.mouseItem = new Item();
        //                }
        //                if (Main.mouseItem.type > 0 || herbItem.type > 0)
        //                {
        //                    Recipe.FindRecipes();
        //                    Main.PlaySound(7, -1, -1, 1);
        //                }
        //            }
        //        }
        //        Main.hoverItemName = herbItem.type > 0 ? herbItem.Name : "";
        //        Main.HoverItem = herbItem.Clone();
        //    }
        //    ssa[0] = tmpItem;
        //    ItemSlot.Draw(spriteBatch, ssa, 10, 0, new Vector2(r.X, r.Y));
        //    tmpItem = ssa[0];

        //    for (int xoff = 0; xoff < 10; xoff++)
        //    {
        //        spriteBatch.Draw(Main.inventoryBack7Texture, new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.inventoryBack4Texture.Width / 2), (float)(Main.inventoryBack4Texture.Height / 2)), 1f, SpriteEffects.None, 0f);
        //        if (Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //        {
        //            Main.player[Main.myPlayer].mouseInterface = true;
        //            Main.hoverItemName = ExxoAvalonOrigins.herbNames[xoff] + ": " + Main.player[Main.myPlayer].Avalon().herbCounts[xoff].ToString() + "\nClick to exchange";
        //        }
        //        switch (xoff)
        //        {
        //            case 0:
        //                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                {
        //                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                    {
        //                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Daybloom, 1);
        //                        Main.item[x].owner = Main.myPlayer;
        //                        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                        {
        //                            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                        }
        //                        Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                    }
        //                }
        //                //if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[0] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //{
        //                //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //    {
        //                //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeDaybloomSeed, 1);
        //                //        Main.item[x].owner = Main.myPlayer;
        //                //        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //        {
        //                //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //        }
        //                //        Main.player[Main.myPlayer].Avalon().herbCounts[0] -= 15;
        //                //        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //    }
        //                //}
        //                spriteBatch.Draw(Main.itemTexture[ItemID.Daybloom], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Daybloom].Width / 2), (float)(Main.itemTexture[ItemID.Daybloom].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                break;
        //            case 1:
        //                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                {
        //                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                    {
        //                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Moonglow, 1);
        //                        Main.item[x].owner = Main.myPlayer;
        //                        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                        {
        //                            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                        }
        //                        Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                    }
        //                }
        //                //if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[1] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //{
        //                //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //    {
        //                //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeMoonglowSeed, 1);
        //                //        Main.item[x].owner = Main.myPlayer;
        //                //        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //        {
        //                //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //        }
        //                //        Main.player[Main.myPlayer].Avalon().herbCounts[1] -= 15;
        //                //        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //    }
        //                //}
        //                spriteBatch.Draw(Main.itemTexture[ItemID.Moonglow], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Moonglow].Width / 2), (float)(Main.itemTexture[ItemID.Moonglow].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                break;
        //            case 2:
        //                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                {
        //                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                    {
        //                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Blinkroot, 1);
        //                        Main.item[x].owner = Main.myPlayer;
        //                        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                        {
        //                            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                        }
        //                        Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                    }
        //                }
        //                //if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[2] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //{
        //                //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //    {
        //                //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeBlinkrootSeed, 1);
        //                //        Main.item[x].owner = Main.myPlayer;
        //                //        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //        {
        //                //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //        }
        //                //        Main.player[Main.myPlayer].Avalon().herbCounts[2] -= 15;
        //                //        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //    }
        //                //}
        //                spriteBatch.Draw(Main.itemTexture[ItemID.Blinkroot], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Blinkroot].Width / 2), (float)(Main.itemTexture[ItemID.Blinkroot].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                break;
        //            case 3:
        //                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                {
        //                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                    {
        //                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Deathweed, 1);
        //                        Main.item[x].owner = Main.myPlayer;
        //                        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                        {
        //                            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                        }
        //                        Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                    }
        //                }
        //                //if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[3] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //{
        //                //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //    {
        //                //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeDeathweedSeed, 1);
        //                //        Main.item[x].owner = Main.myPlayer;
        //                //        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //        {
        //                //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //        }
        //                //        Main.player[Main.myPlayer].Avalon().herbCounts[3] -= 15;
        //                //        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //    }
        //                //}
        //                spriteBatch.Draw(Main.itemTexture[ItemID.Deathweed], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Deathweed].Width / 2), (float)(Main.itemTexture[ItemID.Deathweed].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                break;
        //            case 4:
        //                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                {
        //                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                    {
        //                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Waterleaf, 1);
        //                        Main.item[x].owner = Main.myPlayer;
        //                        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                        {
        //                            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                        }
        //                        Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                    }
        //                }
        //                //if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[4] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //{
        //                //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //    {
        //                //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeWaterleafSeed, 1);
        //                //        Main.item[x].owner = Main.myPlayer;
        //                //        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //        {
        //                //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //        }
        //                //        Main.player[Main.myPlayer].Avalon().herbCounts[4] -= 15;
        //                //        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //    }
        //                //}
        //                spriteBatch.Draw(Main.itemTexture[ItemID.Waterleaf], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Waterleaf].Width / 2), (float)(Main.itemTexture[ItemID.Waterleaf].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                break;
        //            case 5:
        //                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                {
        //                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                    {
        //                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Fireblossom, 1);
        //                        Main.item[x].owner = Main.myPlayer;
        //                        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                        {
        //                            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                        }
        //                        Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                    }
        //                }
        //                //if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[5] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //{
        //                //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //    {
        //                //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeFireblossomSeed, 1);
        //                //        Main.item[x].owner = Main.myPlayer;
        //                //        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //        {
        //                //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //        }
        //                //        Main.player[Main.myPlayer].Avalon().herbCounts[5] -= 15;
        //                //        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //    }
        //                //}
        //                spriteBatch.Draw(Main.itemTexture[ItemID.Fireblossom], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Fireblossom].Width / 2), (float)(Main.itemTexture[ItemID.Fireblossom].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                break;
        //            case 6:
        //                if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                {
        //                    if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                    {
        //                        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Shiverthorn, 1);
        //                        Main.item[x].owner = Main.myPlayer;
        //                        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                        {
        //                            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                        }
        //                        Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                    }
        //                }
        //                //if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[6] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //{
        //                //    if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //    {
        //                //        int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeShiverthornSeed, 1);
        //                //        Main.item[x].owner = Main.myPlayer;
        //                //        if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //        {
        //                //            NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //        }
        //                //        Main.player[Main.myPlayer].Avalon().herbCounts[6] -= 15;
        //                //        Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //    }
        //                //}
        //                spriteBatch.Draw(Main.itemTexture[ItemID.Shiverthorn], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Shiverthorn].Width / 2), (float)(Main.itemTexture[ItemID.Shiverthorn].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                break;
        //                //case 7:
        //                //    if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //    {
        //                //        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //        {
        //                //            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Bloodberry, 1);
        //                //            Main.item[x].owner = Main.myPlayer;
        //                //            if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //            {
        //                //                NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //            }
        //                //            Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                //        }
        //                //    }
        //                //    if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[7] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //    {
        //                //        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //        {
        //                //            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeBloodberrySeed, 1);
        //                //            Main.item[x].owner = Main.myPlayer;
        //                //            if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //            {
        //                //                NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //            }
        //                //            Main.player[Main.myPlayer].Avalon().herbCounts[7] -= 15;
        //                //            Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //        }
        //                //    }
        //                //    spriteBatch.Draw(Main.itemTexture[ItemID.Bloodberry], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Bloodberry].Width / 2), (float)(Main.itemTexture[ItemID.Bloodberry].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                //    break;
        //                //case 8:
        //                //    if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //    {
        //                //        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //        {
        //                //            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Sweetstem, 1);
        //                //            Main.item[x].owner = Main.myPlayer;
        //                //            if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //            {
        //                //                NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //            }
        //                //            Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                //        }
        //                //    }
        //                //    if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[8] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //    {
        //                //        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //        {
        //                //            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeSweetstemSeed, 1);
        //                //            Main.item[x].owner = Main.myPlayer;
        //                //            if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //            {
        //                //                NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //            }
        //                //            Main.player[Main.myPlayer].Avalon().herbCounts[8] -= 15;
        //                //            Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //        }
        //                //    }
        //                //    spriteBatch.Draw(Main.itemTexture[ItemID.Sweetstem], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Sweetstem].Width / 2), (float)(Main.itemTexture[ItemID.Sweetstem].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                //    break;
        //                //case 9:
        //                //    if (Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //    {
        //                //        if (Main.mouseLeftRelease && Main.mouseLeft && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //        {
        //                //            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.Barfbush, 1);
        //                //            Main.item[x].owner = Main.myPlayer;
        //                //            if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //            {
        //                //                NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //            }
        //                //            Main.player[Main.myPlayer].Avalon().herbTotal--;
        //                //        }
        //                //    }
        //                //    if (Main.player[Main.myPlayer].Avalon().herbTier >= 1 && Main.player[Main.myPlayer].Avalon().herbCounts[9] >= 15 && Main.player[Main.myPlayer].Avalon().herbTotal > 0)
        //                //    {
        //                //        if (Main.mouseRightRelease && Main.mouseRight && Main.mouseX > xpos + 10 + (xoff * 52) - Main.inventoryBack4Texture.Width / 2 && Main.mouseX < xpos + 10 + (xoff * 52) + Main.inventoryBack4Texture.Width / 2 && Main.mouseY > ypos - Main.inventoryBack4Texture.Height / 2 && Main.mouseY < ypos + Main.inventoryBack4Texture.Height / 2)
        //                //        {
        //                //            int x = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, 16, 16, ItemID.LargeBarfbushSeed, 1);
        //                //            Main.item[x].owner = Main.myPlayer;
        //                //            if (Main.netMode == NetmodeID.MultiplayerClient)
        //                //            {
        //                //                NetMessage.SendData(21, -1, -1, NetworkText.Empty, x, 1f, 0f, 0f, 0);
        //                //            }
        //                //            Main.player[Main.myPlayer].Avalon().herbCounts[9] -= 15;
        //                //            Main.player[Main.myPlayer].Avalon().herbTotal -= 15;
        //                //        }
        //                //    }
        //                //    spriteBatch.Draw(Main.itemTexture[ItemID.Barfbush], new Vector2((float)(xpos + 10 + (xoff * 52)), (float)ypos), null, Color.White, 0f, new Vector2((float)(Main.itemTexture[ItemID.Barfbush].Width / 2), (float)(Main.itemTexture[ItemID.Barfbush].Height / 2)), 1f, SpriteEffects.None, 0f);
        //                //    break;
        //        }
        //        if (xoff % 5 == 4)
        //        {
        //            ypos += 52;
        //            xpos -= 260;
        //        }
        //    }
        //}
    }
}
