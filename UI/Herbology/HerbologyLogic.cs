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
        public const int HerbTier4Threshold = 1500;
        public const int HerbTier3Threshold = 750;
        public const int HerbTier2Threshold = 250;

        public static Dictionary<int, int> ElixirIdByPotionId = new Dictionary<int, int>
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

        public static bool PurchaseItem(Item item, int amount)
        {
            Player player = Main.LocalPlayer;
            ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

            int herbCharge = 0;
            int herbType = ItemID.None;
            bool chargeInventory = false;
            if (LargeHerbSeedIdByHerbSeedId.ContainsKey(item.type))
            {
                herbCharge = amount;
                herbType = HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[LargeHerbSeedIdByHerbSeedId[item.type]]];
            }
            else if (LargeHerbSeedIdByHerbSeedId.ContainsValue(item.type))
            {
                herbCharge = amount * 15;
                chargeInventory = true;
                herbType = HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[item.type]];
            }

            if (herbCharge > 0)
            {
                if (modPlayer.herbTotal >= herbCharge)
                {
                    if (chargeInventory && herbType != ItemID.None && modPlayer.herbCounts.ContainsKey(herbType) && modPlayer.herbCounts[herbType] > herbCharge)
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
            if (PotionIds.Contains(item.type))
            {
                potionCharge = amount;
            }
            else if (ElixirIdByPotionId.ContainsValue(item.type))
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
                herbAddition = 1;
                herbType = item.type;
            }
            else if (LargeHerbSeedIdByHerbId.ContainsValue(item.type))
            {
                herbAddition = 15;
                herbType = HerbIdByLargeHerbId[LargeHerbIdByLargeHerbSeedId[item.type]];
            }
            else if (LargeHerbIdByLargeHerbSeedId.ContainsValue(item.type))
            {
                herbAddition = 20;
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
                potionAddition = 1;
            }
            else if (ElixirIdByPotionId.ContainsValue(item.type))
            {
                potionAddition = 10;
            }
            else if (item.type == ModContent.ItemType<BlahPotion>())
            {
                potionAddition = 2500;
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
