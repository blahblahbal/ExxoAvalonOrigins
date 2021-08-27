using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class Setup
    {
        public static void Method(GenerationProgress progress)
        {
            progress.Message = "Setting up Avalonian World Gen";

            if (ExxoAvalonOriginsWorld.copperOre == ExxoAvalonOriginsWorld.CopperVariant.random)
            {
                ExxoAvalonOriginsWorld.copperOre = (ExxoAvalonOriginsWorld.CopperVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.copperOre)
            {
                case ExxoAvalonOriginsWorld.CopperVariant.copper:
                    WorldGen.CopperTierOre = TileID.Copper;
                    WorldGen.copperBar = ItemID.CopperBar;
                    break;

                case ExxoAvalonOriginsWorld.CopperVariant.tin:
                    WorldGen.CopperTierOre = TileID.Tin;
                    WorldGen.copperBar = ItemID.TinBar;
                    break;

                case ExxoAvalonOriginsWorld.CopperVariant.bronze:
                    WorldGen.CopperTierOre = (ushort)ModContent.TileType<Tiles.BronzeOre>();
                    WorldGen.copperBar = ModContent.ItemType<Items.BronzeBar>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.ironOre == ExxoAvalonOriginsWorld.IronVariant.random)
            {
                ExxoAvalonOriginsWorld.ironOre = (ExxoAvalonOriginsWorld.IronVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.ironOre)
            {
                case ExxoAvalonOriginsWorld.IronVariant.iron:
                    WorldGen.IronTierOre = TileID.Iron;
                    WorldGen.ironBar = ItemID.IronBar;
                    break;

                case ExxoAvalonOriginsWorld.IronVariant.lead:
                    WorldGen.IronTierOre = TileID.Lead;
                    WorldGen.ironBar = ItemID.LeadBar;
                    break;

                case ExxoAvalonOriginsWorld.IronVariant.nickel:
                    WorldGen.IronTierOre = (ushort)ModContent.TileType<Tiles.NickelOre>();
                    WorldGen.ironBar = ModContent.ItemType<Items.NickelBar>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.silverOre == ExxoAvalonOriginsWorld.SilverVariant.random)
            {
                ExxoAvalonOriginsWorld.silverOre = (ExxoAvalonOriginsWorld.SilverVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.silverOre)
            {
                case ExxoAvalonOriginsWorld.SilverVariant.silver:
                    WorldGen.SilverTierOre = TileID.Silver;
                    WorldGen.silverBar = ItemID.SilverBar;
                    break;

                case ExxoAvalonOriginsWorld.SilverVariant.tungsten:
                    WorldGen.SilverTierOre = TileID.Tungsten;
                    WorldGen.silverBar = ItemID.TungstenBar;
                    break;

                case ExxoAvalonOriginsWorld.SilverVariant.zinc:
                    WorldGen.SilverTierOre = (ushort)ModContent.TileType<Tiles.ZincOre>();
                    WorldGen.silverBar = ModContent.ItemType<Items.ZincBar>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.goldOre == ExxoAvalonOriginsWorld.GoldVariant.random)
            {
                ExxoAvalonOriginsWorld.goldOre = (ExxoAvalonOriginsWorld.GoldVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.goldOre)
            {
                case ExxoAvalonOriginsWorld.GoldVariant.gold:
                    WorldGen.GoldTierOre = TileID.Gold;
                    WorldGen.goldBar = ItemID.GoldBar;
                    break;

                case ExxoAvalonOriginsWorld.GoldVariant.platinum:
                    WorldGen.GoldTierOre = TileID.Platinum;
                    WorldGen.goldBar = ItemID.PlatinumBar;
                    break;

                case ExxoAvalonOriginsWorld.GoldVariant.bismuth:
                    WorldGen.GoldTierOre = (ushort)ModContent.TileType<Tiles.BismuthOre>();
                    WorldGen.goldBar = ModContent.ItemType<Items.BismuthBar>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.rhodiumOre == ExxoAvalonOriginsWorld.RhodiumVariant.random)
            {
                ExxoAvalonOriginsWorld.rhodiumOre = (ExxoAvalonOriginsWorld.RhodiumVariant)WorldGen.genRand.Next(3);
            }

            if (ExxoAvalonOriginsWorld.cobaltOre == ExxoAvalonOriginsWorld.CobaltVariant.random)
            {
                ExxoAvalonOriginsWorld.cobaltOre = (ExxoAvalonOriginsWorld.CobaltVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.cobaltOre)
            {
                case ExxoAvalonOriginsWorld.CobaltVariant.cobalt:
                    WorldGen.oreTier1 = TileID.Cobalt;
                    break;

                case ExxoAvalonOriginsWorld.CobaltVariant.palladium:
                    WorldGen.oreTier1 = TileID.Palladium;
                    break;

                case ExxoAvalonOriginsWorld.CobaltVariant.duratanium:
                    WorldGen.oreTier1 = ModContent.TileType<Tiles.DurataniumOre>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.cobaltOre == ExxoAvalonOriginsWorld.CobaltVariant.random)
            {
                ExxoAvalonOriginsWorld.cobaltOre = (ExxoAvalonOriginsWorld.CobaltVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.cobaltOre)
            {
                case ExxoAvalonOriginsWorld.CobaltVariant.cobalt:
                    WorldGen.oreTier1 = TileID.Cobalt;
                    break;

                case ExxoAvalonOriginsWorld.CobaltVariant.palladium:
                    WorldGen.oreTier1 = TileID.Palladium;
                    break;

                case ExxoAvalonOriginsWorld.CobaltVariant.duratanium:
                    WorldGen.oreTier1 = ModContent.TileType<Tiles.DurataniumOre>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.mythrilOre == ExxoAvalonOriginsWorld.MythrilVariant.random)
            {
                ExxoAvalonOriginsWorld.mythrilOre = (ExxoAvalonOriginsWorld.MythrilVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.mythrilOre)
            {
                case ExxoAvalonOriginsWorld.MythrilVariant.mythril:
                    WorldGen.oreTier2 = TileID.Mythril;
                    break;

                case ExxoAvalonOriginsWorld.MythrilVariant.orichalcum:
                    WorldGen.oreTier2 = TileID.Orichalcum;
                    break;

                case ExxoAvalonOriginsWorld.MythrilVariant.naquadah:
                    WorldGen.oreTier2 = ModContent.TileType<Tiles.NaquadahOre>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.adamantiteOre == ExxoAvalonOriginsWorld.AdamantiteVariant.random)
            {
                ExxoAvalonOriginsWorld.adamantiteOre = (ExxoAvalonOriginsWorld.AdamantiteVariant)WorldGen.genRand.Next(3);
            }

            switch (ExxoAvalonOriginsWorld.adamantiteOre)
            {
                case ExxoAvalonOriginsWorld.AdamantiteVariant.adamantite:
                    WorldGen.oreTier3 = TileID.Adamantite;
                    break;

                case ExxoAvalonOriginsWorld.AdamantiteVariant.titanium:
                    WorldGen.oreTier3 = TileID.Titanium;
                    break;

                case ExxoAvalonOriginsWorld.AdamantiteVariant.troxinium:
                    WorldGen.oreTier3 = ModContent.TileType<Tiles.TroxiniumOre>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.shmTier1Ore == ExxoAvalonOriginsWorld.SHMTier1Variant.random)
            {
                ExxoAvalonOriginsWorld.shmTier1Ore = (ExxoAvalonOriginsWorld.SHMTier1Variant)WorldGen.genRand.Next(2);
            }

            switch (ExxoAvalonOriginsWorld.shmTier1Ore)
            {
                case ExxoAvalonOriginsWorld.SHMTier1Variant.tritanorium:
                    ExxoAvalonOriginsWorld.shmOreTier1 = ModContent.TileType<Tiles.TritanoriumOre>();
                    break;

                case ExxoAvalonOriginsWorld.SHMTier1Variant.pyroscoric:
                    ExxoAvalonOriginsWorld.shmOreTier1 = ModContent.TileType<Tiles.PyroscoricOre>();
                    break;
            }

            if (ExxoAvalonOriginsWorld.shmTier2Ore == ExxoAvalonOriginsWorld.SHMTier2Variant.random)
            {
                ExxoAvalonOriginsWorld.shmTier2Ore = (ExxoAvalonOriginsWorld.SHMTier2Variant)WorldGen.genRand.Next(2);
            }

            switch (ExxoAvalonOriginsWorld.shmTier2Ore)
            {
                case ExxoAvalonOriginsWorld.SHMTier2Variant.unvolandite:
                    ExxoAvalonOriginsWorld.shmOreTier2 = ModContent.TileType<Tiles.UnvolanditeOre>();
                    break;

                case ExxoAvalonOriginsWorld.SHMTier2Variant.vorazylcum:
                    ExxoAvalonOriginsWorld.shmOreTier2 = ModContent.TileType<Tiles.VorazylcumOre>();
                    break;
            }
        }
    }
}