using System.Collections.Generic;
using System.Linq;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Items.Potions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.UI.Herbology
{
    internal static class HerbologyLogic
    {
        public const int HerbTier2Threshold = 250;
        public const int HerbTier3Threshold = 750;
        public const int HerbTier4Threshold = 1500;

        public const int HerbSellPrice = 1;
        public const int LargeHerbSeedSellPrice = 15;
        public const int LargeHerbSellPrice = 20;

        public const int PotionSellPrice = 1;
        public const int ElixirSellPrice = 5;
        public const int BlahPotionSellPrice = 2500;

        public const int HerbSeedCost = 1;
        public const int LargeHerbSeedCost = 15;

        public const int PotionCost = 1;
        public const int ElixirCost = 5;
        public const int BlahPotionCost = 2500;

        public static readonly int[] PotionIds = new int[]
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

        public static readonly int[] ElixirIds = new int[]
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
            ModContent.ItemType<Items.AdvancedPotions.AdvWarmthPotion>()
        };

        public static readonly Dictionary<int, int> HerbIdByLargeHerbId = new Dictionary<int, int>
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

        public static readonly Dictionary<int, int> LargeHerbIdByLargeHerbSeedId = new Dictionary<int, int>
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

        public static readonly Dictionary<int, int> LargeHerbSeedIdByHerbId = new Dictionary<int, int>
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

        public static readonly Dictionary<int, int> LargeHerbSeedIdByHerbSeedId = new Dictionary<int, int>
        {
            { ItemID.DaybloomSeeds, ModContent.ItemType<LargeDaybloomSeed>() },
            { ItemID.MoonglowSeeds, ModContent.ItemType<LargeMoonglowSeed>() },
            { ItemID.BlinkrootSeeds, ModContent.ItemType<LargeBlinkrootSeed>() },
            { ItemID.DeathweedSeeds, ModContent.ItemType<LargeDeathweedSeed>() },
            { ItemID.WaterleafSeeds, ModContent.ItemType<LargeWaterleafSeed>() },
            { ItemID.FireblossomSeeds, ModContent.ItemType<LargeFireblossomSeed>() },
            { ItemID.ShiverthornSeeds, ModContent.ItemType<LargeShiverthornSeed>() },
            { ModContent.ItemType<BloodberrySeeds>(), ModContent.ItemType<LargeBloodberrySeed>() },
            { ModContent.ItemType<SweetstemSeeds>(), ModContent.ItemType<LargeSweetstemSeed>() },
            { ModContent.ItemType<BarfbushSeeds>(), ModContent.ItemType<LargeBarfbushSeed>() }
        };

        public static void UpdateHerbTier(ExxoAvalonOriginsModPlayer modPlayer)
        {
            ExxoAvalonOriginsModPlayer.HerbTier newHerbTier;
            if (modPlayer.herbTotal >= HerbTier4Threshold && Main.hardMode)
            {
                newHerbTier = ExxoAvalonOriginsModPlayer.HerbTier.Master; // tier 4; Blah Potion exchange
            }
            else if (modPlayer.herbTotal >= HerbTier3Threshold && Main.hardMode)
            {
                newHerbTier = ExxoAvalonOriginsModPlayer.HerbTier.Expert; // tier 3; allows you to obtain advanced potions
            }
            else if (modPlayer.herbTotal >= HerbTier2Threshold)
            {
                newHerbTier = ExxoAvalonOriginsModPlayer.HerbTier.Apprentice; // tier 2; allows for large herb seeds
            }
            else
            {
                newHerbTier = ExxoAvalonOriginsModPlayer.HerbTier.Novice; // tier 1; allows for exchanging one herb for another
            }
            if (newHerbTier > modPlayer.herbTier)
            {
                modPlayer.herbTier = newHerbTier;
            }
        }

        public static int GetBaseHerbType(Item item)
        {
            if (HerbIdByLargeHerbId.ContainsValue(item.type))
            {
                return item.type;
            }
            else if (LargeHerbSeedIdByHerbSeedId.ContainsKey(item.type))
            {
                return HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[LargeHerbSeedIdByHerbSeedId[item.type]]];
            }
            else if (LargeHerbIdByLargeHerbSeedId.ContainsKey(item.type))
            {
                return HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[item.type]];
            }
            return -1;
        }

        public static int GetItemCost(Item item, int amount)
        {
            if (LargeHerbSeedIdByHerbSeedId.ContainsKey(item.type))
            {
                return amount * HerbSeedCost;
            }
            else if (LargeHerbSeedIdByHerbSeedId.ContainsValue(item.type))
            {
                return amount * LargeHerbSeedCost;
            }

            if (PotionIds.Contains(item.type))
            {
                return amount * PotionCost;
            }
            else if (ElixirIds.Contains(item.type))
            {
                return amount * ElixirCost;
            }
            else if (item.type == ModContent.ItemType<BlahPotion>())
            {
                return amount * BlahPotionCost;
            }

            return 0;
        }

        public static bool ItemIsPotion(Item item)
        {
            return PotionIds.Contains(item.type) || ElixirIds.Contains(item.type) || item.type == ModContent.ItemType<BlahPotion>();
        }

        public static bool ItemIsHerb(Item item)
        {
            return LargeHerbSeedIdByHerbSeedId.ContainsValue(item.type) || LargeHerbIdByLargeHerbSeedId.ContainsValue(item.type) || LargeHerbIdByLargeHerbSeedId.ContainsKey(item.type) || HerbIdByLargeHerbId.ContainsValue(item.type);
        }

        public static bool PurchaseItem(Item item, int amount)
        {
            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            int charge = GetItemCost(item, amount);

            if (charge <= 0)
            {
                return false;
            }

            if (ItemIsHerb(item))
            {
                int herbType = ItemID.None;
                bool chargeInventory = false;
                if (LargeHerbSeedIdByHerbSeedId.ContainsKey(item.type))
                {
                    herbType = HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[LargeHerbSeedIdByHerbSeedId[item.type]]];
                }
                else if (LargeHerbSeedIdByHerbSeedId.ContainsValue(item.type))
                {
                    chargeInventory = true;
                    herbType = HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[item.type]];
                }

                if (modPlayer.herbTotal < charge)
                {
                    return false;
                }

                if (chargeInventory)
                {
                    if (herbType != ItemID.None && modPlayer.herbCounts.ContainsKey(herbType) && modPlayer.herbCounts[herbType] > charge)
                    {
                        modPlayer.herbCounts[herbType] -= charge;
                    }
                    else
                    {
                        return false;
                    }
                }

                modPlayer.herbTotal -= charge;
                Main.mouseItem = item.Clone();
                Main.mouseItem.stack = amount;
                return true;
            }
            else
            {
                if (modPlayer.potionTotal < charge)
                {
                    return false;
                }

                modPlayer.potionTotal -= charge;
                Main.mouseItem = item.Clone();
                Main.mouseItem.stack = amount;
                return true;
            }
        }

        public static bool SellItem(Item item)
        {
            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            if (item.stack <= 0 || item.type == ItemID.None)
            {
                return false;
            }

            int herbAddition = 0;
            int herbType = ItemID.None;
            if (HerbIdByLargeHerbId.ContainsValue(item.type))
            {
                herbAddition = HerbSellPrice;
                herbType = item.type;
            }
            else if (LargeHerbSeedIdByHerbId.ContainsValue(item.type))
            {
                herbAddition = LargeHerbSeedSellPrice;
                herbType = HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[item.type]];
            }
            else if (LargeHerbIdByLargeHerbSeedId.ContainsValue(item.type))
            {
                herbAddition = LargeHerbSellPrice;
                herbType = HerbIdByLargeHerbId[item.type];
            }

            if (herbAddition > 0 && herbType != ItemID.None)
            {
                if (!modPlayer.herbCounts.ContainsKey(herbType))
                {
                    modPlayer.herbCounts.Add(herbType, 0);
                }
                modPlayer.herbCounts[herbType] += herbAddition * item.stack;
                modPlayer.herbTotal += herbAddition * item.stack;
            }

            int potionAddition = 0;
            if (PotionIds.Contains(item.type))
            {
                potionAddition = PotionSellPrice;
            }
            else if (ElixirIds.Contains(item.type))
            {
                potionAddition = ElixirSellPrice;
            }
            else if (item.type == ModContent.ItemType<BlahPotion>())
            {
                potionAddition = BlahPotionSellPrice;
            }

            if (potionAddition > 0)
            {
                modPlayer.potionTotal += potionAddition * item.stack;
            }

            UpdateHerbTier(modPlayer);

            ItemText.NewText(item, item.stack, false, false);
            Main.PlaySound(SoundID.Item, -1, -1, ExxoAvalonOrigins.mod.GetSoundSlot(SoundType.Item, "Sounds/Item/HerbConsume"));
            return true;
        }
    }
}
