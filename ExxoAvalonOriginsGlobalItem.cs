using System.Collections.Generic;
using System.Linq;
using ExxoAvalonOrigins.Buffs;
using ExxoAvalonOrigins.Buffs.AdvancedBuffs;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.AdvancedPotions;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Potions;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using ExxoAvalonOrigins.Prefixes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins
{
    public class ExxoAvalonOriginsGlobalItem : GlobalItem
    {
        public static List<int> inaccurateGuns = new List<int>
        {
            ItemID.ChainGun,
            ItemID.Gatligator,
            ModContent.ItemType<Thompson>()
        };
        public static List<int> vanillaFastGuns = new List<int>
        {
            ItemID.ChainGun,
            ItemID.Gatligator,
            ItemID.SDMG,
            ItemID.Megashark,
            ItemID.Minishark,
            ItemID.Uzi,
            ItemID.VortexBeater
        };
        public static List<int> nonSolidExceptions = new List<int>
        {
            TileID.Cobweb,
            TileID.LivingCursedFire,
            TileID.LivingDemonFire,
            TileID.LivingFire,
            TileID.LivingFrostFire,
            TileID.LivingIchor,
            TileID.LivingUltrabrightFire,
            TileID.ChimneySmoke,
            TileID.Bubble,
            TileID.Rope,
            TileID.SilkRope,
            TileID.VineRope,
            TileID.WebRope,
            ModContent.TileType<Tiles.LivingLightning>(),
            ModContent.TileType<Tiles.VineRope>()
        };
        public static List<int> herbSeeds = new List<int>
        {
            ItemID.BlinkrootSeeds,
            ItemID.DaybloomSeeds,
            ItemID.WaterleafSeeds,
            ItemID.FireblossomSeeds,
            ItemID.DeathweedSeeds,
            ItemID.MoonglowSeeds,
            ItemID.ShiverthornSeeds,
            ModContent.ItemType<BarfbushSeeds>(),
            ModContent.ItemType<BloodberrySeeds>(),
            ModContent.ItemType<SweetstemSeeds>(),
            ModContent.ItemType<HolybirdSeeds>()
        };
        public static List<int> gems = new List<int>
        {
            ItemID.Topaz,
            ItemID.Ruby,
            ItemID.Amethyst,
            ItemID.Diamond,
            ItemID.Emerald,
            ItemID.Sapphire,
            ModContent.ItemType<Onyx>(),
            ModContent.ItemType<Zircon>(),
            ModContent.ItemType<Kunzite>(),
            ModContent.ItemType<Peridot>(),
            ModContent.ItemType<Tourmaline>(),
            ModContent.ItemType<Opal>()
        };

        public static List<string> potionNames = new List<string>()
        {
            "Ammo Reservation",
            "Archery",
            "Battle",
            "Blood Cast",
            "Builder",
            "Calming",
            "Crate",
            "Aura",
            "Dangersense",
            "Endurance",
            "Featherfall",
            "Fishing",
            "Flipper",
            "Force Field",
            "Fury",
            "Gauntlet",
            "Gills",
            "GPS",
            "Gravitation",
            "Heartreach",
            "Hunter",
            "Inferno",
            "Invisibility",
            "Ironskin",
            "Leaping",
            "Lifeforce",
            "Luck",
            "Magic Power",
            "Mana Regeneration",
            "Mining",
            "Night Owl",
            "Obsidian Skin",
            "Rage",
            "Regeneration",
            "Rogue",
            "Shadow",
            "Shine",
            "Shockwave",
            "Sonar",
            "Spelunker",
            "Starbright",
            "Strength",
            "Summoning",
            "Supersonic",
            "Swiftness",
            "Thorns",
            // Time Shift
            "Titan",
            "Titanskin",
            "Vision",
            "Warmth",
            "Water Walking",
            "Wisdom",
            "Wrath",
        };

        public static int GemToTile(int type)
        {
            if (type == ItemID.Amethyst) return TileID.Amethyst;
            else if (type == ItemID.Diamond) return TileID.Diamond;
            else if (type == ItemID.Emerald) return TileID.Emerald;
            else if (type == ModContent.ItemType<Kunzite>()) return ModContent.TileType<Tiles.Ores.Kunzite>();
            else if (type == ModContent.ItemType<Onyx>()) return ModContent.TileType<Tiles.Ores.Onyx>();
            else if (type == ModContent.ItemType<Opal>()) return ModContent.TileType<Tiles.Ores.Opal>();
            else if (type == ModContent.ItemType<Peridot>()) return ModContent.TileType<Tiles.Ores.Peridot>();
            else if (type == ItemID.Ruby) return TileID.Ruby;
            else if (type == ItemID.Sapphire) return TileID.Sapphire;
            else if (type == ItemID.Topaz) return TileID.Topaz;
            else if (type == ModContent.ItemType<Tourmaline>()) return ModContent.TileType<Tiles.Ores.Tourmaline>();
            else if (type == ModContent.ItemType<Zircon>()) return ModContent.TileType<Tiles.Ores.Zircon>();
            return 0;
        }
        public static int DungeonWallItemToBackwallID(int type)
        {
            if (type == ItemID.BlueBrickWall) return WallID.BlueDungeonUnsafe;
            else if (type == ItemID.BlueSlabWall) return WallID.BlueDungeonSlabUnsafe;
            else if (type == ItemID.BlueTiledWall) return WallID.BlueDungeonTileUnsafe;
            else if (type == ItemID.GreenBrickWall) return WallID.GreenDungeonUnsafe;
            else if (type == ItemID.GreenSlabWall) return WallID.GreenDungeonSlabUnsafe;
            else if (type == ItemID.GreenTiledWall) return WallID.GreenDungeonTileUnsafe;
            else if (type == ItemID.PinkBrickWall) return WallID.PinkDungeonUnsafe;
            else if (type == ItemID.PinkSlabWall) return WallID.PinkDungeonSlabUnsafe;
            else if (type == ItemID.PinkTiledWall) return WallID.PinkDungeonTileUnsafe;
            else if (type == ModContent.ItemType<Items.Placeable.Wall.OrangeBrickWall>()) return ModContent.WallType<Walls.OrangeBrickUnsafe>();
            else if (type == ModContent.ItemType<Items.Placeable.Wall.OrangeSlabWall>()) return ModContent.WallType<Walls.OrangeSlabUnsafe>();
            else if (type == ModContent.ItemType<Items.Placeable.Wall.OrangeTiledWall>()) return ModContent.WallType<Walls.OrangeTiledUnsafe>();
            return 0;
        }
        public override void SetDefaults(Item item)
        {
            int[] to2000 =
            {
                ItemID.WoodenArrow,
                ItemID.FlamingArrow,
                ItemID.UnholyArrow,
                ItemID.JestersArrow,
                ItemID.MusketBall,
                ItemID.MeteorShot,
                ItemID.HellfireArrow,
                ItemID.SilverBullet,
                ItemID.CrystalBullet,
                ItemID.HolyArrow,
                ItemID.CursedArrow,
                ItemID.CursedBullet,
                ItemID.RocketI,
                ItemID.RocketII,
                ItemID.RocketIII,
                ItemID.RocketIV,
                ItemID.FrostburnArrow,
                ItemID.ChlorophyteBullet,
                ItemID.StyngerBolt,
                ItemID.HighVelocityBullet,
                ItemID.IchorArrow,
                ItemID.IchorBullet,
                ItemID.VenomArrow,
                ItemID.VenomBullet,
                ItemID.PartyBullet,
                ItemID.NanoBullet,
                ItemID.ExplodingBullet,
                ItemID.GoldenBullet,
                ItemID.BlueSolution,
                ItemID.DarkBlueSolution,
                ItemID.GreenSolution,
                ItemID.PurpleSolution,
                ItemID.RedSolution
            };
            int[] to999 =
            {
                ItemID.Mushroom,
                ItemID.Torch,
                ItemID.GoldBar,
                ItemID.CopperBar,
                ItemID.SilverBar,
                ItemID.IronBar,
                ItemID.Acorn,
                ItemID.LifeCrystal,
                ItemID.Bottle,
                ItemID.Lens,
                ItemID.DemoniteBar,
                ItemID.CorruptSeeds,
                ItemID.VileMushroom,
                ItemID.GrassSeeds,
                ItemID.Sunflower,
                ItemID.PurificationPowder,
                ItemID.VilePowder,
                ItemID.RottenChunk,
                ItemID.WormTooth,
                ItemID.FallenStar,
                ItemID.ShadowScale,
                ItemID.WoodPlatform,
                ItemID.ManaCrystal,
                ItemID.MeteoriteBar,
                ItemID.Hook,
                ItemID.Book,
                ItemID.Bomb,
                ItemID.Grenade,
                ItemID.HellstoneBar,
                ItemID.MushroomGrassSeeds,
                ItemID.JungleGrassSeeds,
                ItemID.Stinger,
                ItemID.Vine,
                ItemID.StickyBomb,
                ItemID.BlackLens,
                ItemID.BlackThread,
                ItemID.GreenThread,
                ItemID.Leather,
                ItemID.Glowstick,
                ItemID.StickyGlowstick,
                ItemID.DaybloomSeeds,
                ItemID.MoonglowSeeds,
                ItemID.BlinkrootSeeds,
                ItemID.DeathweedSeeds,
                ItemID.WaterleafSeeds,
                ItemID.FireblossomSeeds,
                ItemID.Daybloom,
                ItemID.Moonglow,
                ItemID.Blinkroot,
                ItemID.Deathweed,
                ItemID.Waterleaf,
                ItemID.Fireblossom,
                ItemID.SharkFin,
                ItemID.Feather,
                ItemID.AntlionMandible,
                ItemID.IllegalGunParts,
                ItemID.GoldenKey,
                ItemID.JungleSpores,
                ItemID.TatteredCloth,
                ItemID.HallowedSeeds,
                ItemID.CobaltBar,
                ItemID.MythrilBar,
                ItemID.AdamantiteBar,
                ItemID.BlueTorch,
                ItemID.RedTorch,
                ItemID.GreenTorch,
                ItemID.PurpleTorch,
                ItemID.WhiteTorch,
                ItemID.YellowTorch,
                ItemID.DemonTorch,
                ItemID.PixieDust,
                ItemID.CursedFlame,
                ItemID.CursedTorch,
                ItemID.UnicornHorn,
                ItemID.DarkShard,
                ItemID.LightShard,
                ItemID.EbonwoodPlatform,
                ItemID.RichMahoganyPlatform,
                ItemID.PearlwoodPlatform,
                ItemID.BonePlatform,
                ItemID.TinBar,
                ItemID.LeadBar,
                ItemID.TungstenBar,
                ItemID.PlatinumBar,
                ItemID.ShadewoodPlatform,
                ItemID.Marshmallow,
                ItemID.IceTorch,
                ItemID.PinkThread,
                ItemID.ChlorophyteBar,
                ItemID.TealMushroom,
                ItemID.GreenMushroom,
                ItemID.SkyBlueFlower,
                ItemID.YellowMarigold,
                ItemID.BlueBerries,
                ItemID.LimeKelp,
                ItemID.PinkPricklyPear,
                ItemID.OrangeBloodroot,
                ItemID.RedHusk,
                ItemID.CyanHusk,
                ItemID.VioletHusk,
                ItemID.PurpleMucos,
                ItemID.BlackInk,
                ItemID.TempleKey,
                ItemID.PalladiumBar,
                ItemID.OrichalcumBar,
                ItemID.TitaniumBar,
                ItemID.HallowedBar,
                ItemID.ChlorophyteArrow,
                ItemID.OrangeTorch,
                ItemID.CrimtaneBar,
                ItemID.LifeFruit,
                ItemID.LihzahrdPowerCell,
                ItemID.TurtleShell,
                ItemID.TissueSample,
                ItemID.Vertebrae,
                ItemID.Ichor,
                ItemID.IchorTorch,
                ItemID.VialofVenom,
                ItemID.BlueBrickPlatform,
                ItemID.PinkBrickPlatform,
                ItemID.GreenBrickPlatform,
                ItemID.MetalShelf,
                ItemID.BrassShelf,
                ItemID.WoodShelf,
                ItemID.DungeonShelf,
                ItemID.ObsidianPlatform,
                ItemID.Ectoplasm,
                ItemID.GiantHarpyFeather,
                ItemID.BoneFeather,
                ItemID.FireFeather,
                ItemID.IceFeather,
                ItemID.BrokenBatWing,
                ItemID.TatteredBeeWing,
                ItemID.JungleKey,
                ItemID.CorruptionKey,
                ItemID.CrimsonKey,
                ItemID.HallowedKey,
                ItemID.FrozenKey,
                ItemID.ShroomiteBar,
                ItemID.BrokenHeroSword,
                ItemID.ButterflyDust,
                ItemID.GlassPlatform,
                ItemID.GoodieBag,
                ItemID.JungleKeyMold,
                ItemID.CorruptionKeyMold,
                ItemID.CrimsonKeyMold,
                ItemID.HallowedKeyMold,
                ItemID.FrozenKeyMold,
                ItemID.BlackFairyDust,
                ItemID.SpookyPlatform,
                ItemID.PumpkinSeed,
                ItemID.SpookyTwig,
                ItemID.Holly,
                ItemID.Coal,
                ItemID.CrimsonSeeds,
                ItemID.BeetleHusk,
                ItemID.UltrabrightTorch,
                ItemID.ShiverthornSeeds,
                ItemID.Shiverthorn,
                ItemID.BeeWax,
                ItemID.PalmWoodPlatform,
                ItemID.MushroomPlatform,
                ItemID.BorealWoodPlatform,
                ItemID.SlimePlatform,
                ItemID.StickyGrenade,
                ItemID.SpiderFang,
                ItemID.SteampunkPlatform,
                ItemID.SkywarePlatform,
                ItemID.LivingWoodPlatform,
                ItemID.HoneyPlatform,
                ItemID.CactusPlatform
            };
            int[] to100 =
            {
                ItemID.BottledWater,
                ItemID.Dynamite,
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
                ItemID.GreaterManaPotion,
                ItemID.CookedMarshmallow,
                ItemID.FlaskofVenom,
                ItemID.FlaskofCursedFlames,
                ItemID.FlaskofFire,
                ItemID.FlaskofGold,
                ItemID.FlaskofIchor,
                ItemID.FlaskofNanites,
                ItemID.FlaskofParty,
                ItemID.FlaskofPoison,
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
                ItemID.RecallPotion,
                ItemID.TeleportationPotion,
                ItemID.LovePotion,
                ItemID.StinkPotion,
                ItemID.FishingPotion,
                ItemID.SonarPotion,
                ItemID.CratePotion
            };
            int[] souls =
            {
                ItemID.SoulofLight,
                ItemID.SoulofNight,
                ItemID.SoulofFlight,
                ItemID.SoulofMight,
                ItemID.SoulofSight,
                ItemID.SoulofFright
            };

            switch (item.type)
            {
                case ItemID.Mushroom:
                    item.potion = false;
                    item.healLife = 0;
                    item.useAnimation = 15;
                    item.useTime = 10;
                    item.useTurn = item.autoReuse = true;
                    item.createTile = ModContent.TileType<Tiles.MushroomTile>();
                    item.useStyle = ItemUseStyleID.Swing;
                    item.UseSound = null;
                    break;
                case ItemID.Torch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 0;
                    item.notAmmo = true;
                    break;
                case ItemID.EnchantedBoomerang:
                    item.rare = ItemRarityID.Green;
                    break;
                case ItemID.RottenChunk:
                    item.useStyle = ItemUseStyleID.Swing;
                    item.useAnimation = 15;
                    item.useTime = 10;
                    item.consumable = true;
                    item.useTurn = true;
                    item.autoReuse = true;
                    item.createTile = ModContent.TileType<Tiles.RottenChunk>();
                    break;
                case ItemID.ShadowScale:
                    item.useTurn = true;
                    item.useStyle = ItemUseStyleID.Swing;
                    item.useAnimation = 15;
                    item.useTime = 10;
                    item.autoReuse = true;
                    item.consumable = true;
                    item.createTile = ModContent.TileType<Tiles.ShadowScale>();
                    break;
                case ItemID.NightmarePickaxe:
                    item.pick = 60;
                    break;
                case ItemID.LesserManaPotion:
                    item.maxStack = 50;
                    break;
                case ItemID.Spike:
                    item.ammo = 147;
                    item.notAmmo = true;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 0;
                    break;
                case ItemID.WoodenSpike:
                    item.ammo = 147;
                    item.notAmmo = true;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike = 4;
                    break;
                case ItemID.Hellstone:
                    item.value = Item.sellPrice(0, 0, 13, 30);
                    break;
                case ItemID.ManaPotion:
                    item.maxStack = 75;
                    break;
                case ItemID.Vine:
                    item.useStyle = ItemUseStyleID.Swing;
                    item.useTurn = true;
                    item.useAnimation = 15;
                    item.useTime = 8;
                    item.autoReuse = true;
                    item.consumable = true;
                    item.createTile = ModContent.TileType<Tiles.VineRope>();
                    item.tileBoost += 3;
                    break;
                case ItemID.LesserRestorationPotion:
                    item.rare = ItemRarityID.Green;
                    item.maxStack = 40;
                    break;
                case ItemID.RestorationPotion:
                    item.rare = ItemRarityID.Green;
                    item.maxStack = 40;
                    break;
                case ItemID.Goldfish:
                    item.makeNPC = (short)ModContent.NPCType<NPCs.ImpactWizard>();
                    break;
                case ItemID.DivingHelmet:
                    item.value = 10000;
                    break;
                case ItemID.MagicPowerPotion:
                    item.buffTime = 18000;
                    break;
                case ItemID.ThornsPotion:
                    item.buffTime = 10800;
                    break;
                case ItemID.GravitationPotion:
                    item.buffTime = 21600;
                    break;
                case ItemID.GoblinBattleStandard:
                    item.maxStack = 20;
                    break;
                case ItemID.BlueTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 1;
                    break;
                case ItemID.RedTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 2;
                    break;
                case ItemID.GreenTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 3;
                    break;
                case ItemID.PurpleTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 4;
                    break;
                case ItemID.WhiteTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 5;
                    break;
                case ItemID.YellowTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 6;
                    break;
                case ItemID.DemonTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 7;
                    break;
                case ItemID.PixieDust:
                    item.value = 1000;
                    break;
                case ItemID.Flamethrower:
                    item.damage = 35;
                    break;
                case ItemID.CursedTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 8;
                    break;
                case ItemID.SnowGlobe:
                    item.maxStack = 20;
                    break;
                case ItemID.RainbowBrick:
                    item.rare = 1;
                    break;
                case ItemID.RainbowBrickWall:
                    item.rare = 1;
                    break;
                case ItemID.UnholyTrident:
                    item.autoReuse = true;
                    break;
                case ItemID.FrostHelmet:
                    item.defense = 12;
                    break;
                case ItemID.FrostBreastplate:
                    item.defense = 22;
                    break;
                case ItemID.FrostLeggings:
                    item.defense = 15;
                    break;
                case ItemID.AmethystStaff:
                    item.damage = 15;
                    break;
                case ItemID.TopazStaff:
                    item.damage = 16;
                    break;
                case ItemID.SapphireStaff:
                    item.damage = 19;
                    break;
                case ItemID.EmeraldStaff:
                    item.damage = 20;
                    break;
                case ItemID.RubyStaff:
                    item.damage = 22;
                    break;
                case ItemID.DiamondStaff:
                    item.damage = 25;
                    break;
                case ItemID.TerraBlade:
                    item.noMelee = false;
                    item.UseSound = SoundID.Item1;
                    break;
                case ItemID.DeathbringerPickaxe:
                    item.pick = 64;
                    break;
                case ItemID.BlackBelt:
                    item.value = 150000;
                    break;
                case ItemID.IceTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 9;
                    break;
                case ItemID.ChlorophyteMask:
                    item.defense = 27;
                    break;
                case ItemID.ChlorophyteHelmet:
                    item.defense = 15;
                    break;
                case ItemID.ChlorophyteHeadgear:
                    item.defense = 9;
                    break;
                case ItemID.ChlorophytePlateMail:
                    item.defense = 20;
                    break;
                case ItemID.ChlorophyteGreaves:
                    item.defense = 15;
                    break;
                case ItemID.PossessedHatchet:
                    item.shootSpeed = 16f;
                    item.useAnimation = 12;
                    item.useTime = 12;
                    break;
                case ItemID.WaspGun:
                    item.damage = 23;
                    break;
                case ItemID.OrangeTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 10;
                    break;
                case ItemID.SniperRifle:
                    item.value = Item.sellPrice(0, 7, 0, 0);
                    break;
                case ItemID.Uzi:
                    item.value = 250000;
                    break;
                case ItemID.SkeletronMask:
                    item.value = Item.sellPrice(0, 2, 0, 0);
                    break;
                case ItemID.Picksaw:
                    item.tileBoost++;
                    break;
                case ItemID.HeatRay:
                    item.mana = 5;
                    break;
                case ItemID.TheAxe:
                    item.hammer = 95;
                    break;
                case ItemID.SlimeStaff:
                    item.damage = 11;
                    break;
                case ItemID.PirateMap:
                    item.maxStack = 20;
                    break;
                case ItemID.TurtleHelmet:
                    item.defense = 24;
                    break;
                case ItemID.TurtleScaleMail:
                    item.defense = 29;
                    break;
                case ItemID.TurtleLeggings:
                    item.defense = 20;
                    break;
                case ItemID.BonePickaxe:
                    item.pick = 55;
                    break;
                case ItemID.Vertebrae:
                    item.useStyle = ItemUseStyleID.Swing;
                    item.useAnimation = 15;
                    item.useTime = 10;
                    item.consumable = true;
                    item.useTurn = true;
                    item.autoReuse = true;
                    item.createTile = ModContent.TileType<Tiles.Vertebrae>();
                    break;
                case ItemID.IchorTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 11;
                    break;
                case ItemID.FlaskofGold:
                    item.value = 108000;
                    break;
                case ItemID.Ectoplasm:
                    item.useStyle = ItemUseStyleID.Swing;
                    item.useAnimation = 15;
                    item.useTime = 10;
                    item.consumable = true;
                    item.useTurn = true;
                    item.autoReuse = true;
                    item.createTile = ModContent.TileType<Tiles.Ectoplasm>();
                    break;
                case ItemID.AnkhCharm:
                    item.value = Item.sellPrice(0, 10, 0, 0);
                    break;
                case ItemID.AnkhShield:
                    item.value = Item.sellPrice(0, 13, 0, 0);
                    break;
                case ItemID.Coal:
                    item.value = 5;
                    item.rare = -1;
                    break;
                case ItemID.ShroomiteDiggingClaw:
                    item.pick = 205;
                    break;
                case ItemID.BeetleHelmet:
                    item.defense = 25;
                    break;
                case ItemID.BeetleScaleMail:
                    item.defense = 22;
                    break;
                case ItemID.BeetleShell:
                    item.defense = 33;
                    break;
                case ItemID.BeetleLeggings:
                    item.defense = 19;
                    break;
                case ItemID.SuperManaPotion:
                    item.maxStack = 150;
                    break;
                case ItemID.UltrabrightTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 12;
                    break;
                case ItemID.LifeforcePotion:
                    item.rare = ItemRarityID.Orange;
                    break;
                case ItemID.RagePotion:
                    item.rare = ItemRarityID.Green;
                    break;
                case ItemID.InfernoPotion:
                    item.rare = ItemRarityID.Orange;
                    break;
                case ItemID.TeleportationPotion:
                    item.rare = ItemRarityID.Green;
                    break;
                case ItemID.FishingPotion:
                    item.value = 1000;
                    break;
                case ItemID.SonarPotion:
                    item.buffTime = 19600;
                    break;
                case ItemID.CratePotion:
                    item.buffTime = 28800;
                    break;
                case ItemID.AnglerHat:
                    item.defense = 3;
                    break;
                case ItemID.AnglerVest:
                    item.defense = 5;
                    break;
                case ItemID.AnglerPants:
                    item.defense = 4;
                    break;
                case ItemID.SpiderMask:
                    item.defense = 6;
                    break;
                case ItemID.SpiderBreastplate:
                    item.defense = 9;
                    break;
                case ItemID.SpiderGreaves:
                    item.defense = 8;
                    break;
                case ItemID.KingSlimeMask:
                    item.value = Item.sellPrice(0, 2, 0, 0);
                    break;
                case ItemID.DukeFishronMask:
                    item.value = Item.sellPrice(0, 2, 0, 0);
                    break;
                case ItemID.Meowmere:
                    item.damage = 145;
                    break;
                case ItemID.SDMG:
                    item.damage = 49;
                    break;
                case ItemID.StarWrath:
                    item.damage = 85;
                    break;
                case ItemID.LastPrism:
                    item.damage = 72;
                    break;
                case ItemID.Terrarian:
                    item.damage = 144;
                    break;
                case ItemID.LunarFlareBook:
                    item.damage = 75;
                    break;
                case ItemID.RainbowCrystalStaff:
                    item.damage = 120;
                    break;
                case ItemID.BoneTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 19;
                    break;
                case ItemID.RainbowTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 20;
                    break;
                case ItemID.PinkTorch:
                    item.ammo = 8;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 21;
                    break;
            }
            if (item.type >= ItemID.BrainMask && item.type <= ItemID.DestroyerMask)
            {
                item.value = Item.sellPrice(0, 2, 0, 0);
            }
            if (to2000.Contains(item.type))
            {
                item.maxStack = 2000;
            }
            if (to999.Contains(item.type))
            {
                item.maxStack = 999;
            }
            if (to100.Contains(item.type))
            {
                item.maxStack = 100;
            }
            //if (souls.Contains(item.type))
            //{
            //    item.noUseGraphic = true;
            //}
            if (item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch > 0)
            {
                item.notAmmo = true;
            }
        }
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag")
            {
                if (Main.rand.Next(4) == 0)
                {
                    player.QuickSpawnItem(ModContent.ItemType<StaminaCrystal>());
                }
            }
            if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag)
            {
                NPCLoader.blockLoot.Add(ItemID.RangerEmblem);
                NPCLoader.blockLoot.Add(ItemID.SummonerEmblem);
                NPCLoader.blockLoot.Add(ItemID.WarriorEmblem);
                NPCLoader.blockLoot.Add(ItemID.SorcererEmblem);
                player.QuickSpawnItem(ModContent.ItemType<NullEmblem>());
            }
            if (context == "bossBag" && arg == ItemID.KingSlimeBossBag)
            {
                if (Main.rand.Next(3) == 0) player.QuickSpawnItem(ModContent.ItemType<BandofSlime>());
            }
            if (context == "bossBag" && arg == ItemID.PlanteraBossBag)
            {
                player.QuickSpawnItem(ModContent.ItemType<LifeDew>(), Main.rand.Next(15, 22));
                player.QuickSpawnItem(ItemID.ChlorophyteOre, Main.rand.Next(60, 121));
            }
            if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag) //keeping it this way because we might add unholy arrow alt
            {
                if (ExxoAvalonOriginsWorld.contagion)
                {
                    NPCLoader.blockLoot.Add(ItemID.UnholyArrow);
                    NPCLoader.blockLoot.Add(ItemID.DemoniteOre);
                    NPCLoader.blockLoot.Add(ItemID.CorruptSeeds);
                    player.QuickSpawnItem(ModContent.ItemType<BacciliteOre>(), Main.rand.Next(30, 81));
                    player.QuickSpawnItem(ModContent.ItemType<IckgrassSeeds>(), Main.rand.Next(1, 3));
                    //player.QuickSpawnItem(ModContent.ItemType<ShitArrow>(), Main.rand.Next(20, 50));
                }
                if (WorldGen.crimson)
                {
                    player.QuickSpawnItem(ModContent.ItemType<Items.Ammo.BloodyArrow>(), Main.rand.Next(20, 50));
                }
                if (!Main.hardMode && !ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.rand.Next(10) < 3)
                {
                    player.QuickSpawnItem(ModContent.ItemType<BloodyAmulet>());
                }
                else if (Main.hardMode && !ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.rand.Next(100) < 15)
                {
                    player.QuickSpawnItem(ModContent.ItemType<BloodyAmulet>());
                }
                else if (Main.hardMode && ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode && Main.rand.Next(100) < 7)
                {
                    player.QuickSpawnItem(ModContent.ItemType<BloodyAmulet>());
                }
            }
        }

        public override void HoldItem(Item item, Player player)
        {
            #region wire disable in sky fortress
            Item tempWireItem = new Item();
            tempWireItem.netDefaults(item.netID);
            tempWireItem = tempWireItem.CloneWithModdedDataFrom(item);
            tempWireItem.stack = item.stack;
            if (player.Avalon().ZoneSkyFortress && !ExxoAvalonOriginsWorld.downedDragonLord)
            {
                player.InfoAccMechShowWires = false;
                if (item.mech)
                {
                    item.mech = false;
                    item.useStyle = 0;
                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().wasMech = true;
                }
            }
            if (item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().wasMech && !player.Avalon().ZoneSkyFortress)
            {
                item.netDefaults(tempWireItem.netID);
                item.stack = tempWireItem.stack;
                item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().wasMech = false;
            }
            #endregion
            #region barbaric prefix logic
            Item tempItem = new Item();
            tempItem.netDefaults(item.netID);
            tempItem = tempItem.CloneWithModdedDataFrom(item);
            float kbDiff = 0f;
            if (item.prefix == PrefixID.Superior || item.prefix == PrefixID.Savage || item.prefix == PrefixID.Bulky ||
                item.prefix == PrefixID.Taboo || item.prefix == PrefixID.Celestial || item.prefix == ModContent.PrefixType<Horrific>()) kbDiff = 0.1f;
            else if (item.prefix == PrefixID.Forceful || item.prefix == PrefixID.Strong || item.prefix == PrefixID.Unpleasant ||
                item.prefix == PrefixID.Godly || item.prefix == PrefixID.Heavy || item.prefix == PrefixID.Legendary ||
                item.prefix == PrefixID.Intimidating || item.prefix == PrefixID.Staunch || item.prefix == PrefixID.Unreal ||
                item.prefix == PrefixID.Furious || item.prefix == PrefixID.Mythical) kbDiff = 0.15f;
            else if (item.prefix == PrefixID.Broken || item.prefix == PrefixID.Weak || item.prefix == PrefixID.Shameful ||
                item.prefix == PrefixID.Awkward) kbDiff = -0.2f;
            else if (item.prefix == PrefixID.Nasty || item.prefix == PrefixID.Ruthless || item.prefix == PrefixID.Unhappy ||
                item.prefix == PrefixID.Light || item.prefix == PrefixID.Awful || item.prefix == PrefixID.Deranged ||
                item.prefix == ModContent.PrefixType<Excited>()) kbDiff = -0.1f;
            else if (item.prefix == PrefixID.Shoddy || item.prefix == PrefixID.Terrible) kbDiff = -0.15f;
            else if (item.prefix == PrefixID.Deadly || item.prefix == PrefixID.Masterful) kbDiff = 0.05f;
            else if (item.prefix == ModContent.PrefixType<Fantastic>() || item.prefix == ModContent.PrefixType<Awestruck>() ||
                item.prefix == ModContent.PrefixType<Phantasmal>()) kbDiff = 0.2f;
            else if (item.prefix == ModContent.PrefixType<Drunken>() || item.prefix == ModContent.PrefixType<Hectic>()) kbDiff = -0.07f;
            else if (item.prefix == ModContent.PrefixType<Stupid>()) kbDiff = 0.16f;
            item.knockBack = tempItem.knockBack * (1 + kbDiff);
            item.knockBack *= player.Avalon().bonusKB;
            #endregion
            #region herb seed block swap
            if (herbSeeds.Contains(item.type))
            {
                Vector2 mousePosition = Main.MouseWorld;
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    player.Avalon().MousePosition = mousePosition;
                    Network.CursorPosition.SendPacket(mousePosition, player.whoAmI);
                }
                else if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    player.Avalon().MousePosition = mousePosition;
                }
                Point mpTile = player.Avalon().MousePosition.ToTileCoordinates();

                if ((Main.tile[mpTile.X, mpTile.Y].TileType == TileID.BloomingHerbs ||
                    Main.tile[mpTile.X, mpTile.Y].TileType == ModContent.TileType<Tiles.Herbs.Barfbush>() && Main.tile[mpTile.X, mpTile.Y].TileFrameX == 36 ||
                    Main.tile[mpTile.X, mpTile.Y].TileType == ModContent.TileType<Tiles.Herbs.Bloodberry>() && Main.tile[mpTile.X, mpTile.Y].TileFrameX == 36 ||
                    Main.tile[mpTile.X, mpTile.Y].TileType == ModContent.TileType<Tiles.Herbs.Sweetstem>() && Main.tile[mpTile.X, mpTile.Y].TileFrameX == 36 ||
                    Main.tile[mpTile.X, mpTile.Y].TileType == ModContent.TileType<Tiles.Herbs.Holybird>() && Main.tile[mpTile.X, mpTile.Y].TileFrameX == 36) &&
                    (Main.tile[mpTile.X, mpTile.Y + 1].TileType == TileID.ClayPot ||
                    Main.tile[mpTile.X, mpTile.Y + 1].TileType == TileID.PlanterBox) && Main.mouseLeft)
                {
                    WorldGen.KillTile(mpTile.X, mpTile.Y);
                    if (!Main.tile[mpTile.X, mpTile.Y].HasTile && Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, mpTile.X, mpTile.Y);
                    }
                    WorldGen.PlaceTile(mpTile.X, mpTile.Y, item.createTile, style: item.placeStyle);
                    if (Main.tile[mpTile.X, mpTile.Y].HasTile && Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, mpTile.X, mpTile.Y, item.createTile, item.placeStyle);
                    }
                    item.stack--;
                }
            }
            #endregion
            if (player.Avalon().ancientMinionGuide)
            {
                if (item.summon && ExxoAvalonOrigins.Mod.minionGuidingHotkey.Current)
                {
                    foreach (Projectile proj in Main.projectile)
                    {
                        if (proj.owner == player.whoAmI && proj.minion)
                        {
                            float posX = Main.mouseX + Main.screenPosition.X - proj.Center.X;
                            float posY = Main.mouseY + Main.screenPosition.Y - proj.Center.Y;
                            if (player.gravDir == -1)
                            {
                                posY = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - proj.Center.Y;
                            }
                            proj.velocity.X = posX;
                            proj.velocity.Y = posY;
                        }
                    }
                }
            }
            float num70 = Main.mouseX + Main.screenPosition.X - player.Center.X;
            float num71 = Main.mouseY + Main.screenPosition.Y - player.Center.Y;
            Vector2 center = player.Center;
            if (player.whoAmI == Main.myPlayer)
            {
                bool hasAmmo = false;
                var item2 = new Item();
                if (item.useAmmo > 0)
                {
                    bool hasAmmoInAmmoSlots = false;
                    for (int num67 = 54; num67 < 58; num67++)
                    {
                        if (player.inventory[num67].ammo == item.useAmmo && player.inventory[num67].stack > 0)
                        {
                            item2 = player.inventory[num67];
                            hasAmmo = true;
                            hasAmmoInAmmoSlots = true;
                            break;
                        }
                    }
                    if (!hasAmmoInAmmoSlots)
                    {
                        for (int num68 = 0; num68 < 54; num68++)
                        {
                            if (player.inventory[num68].ammo == item.useAmmo && player.inventory[num68].stack > 0)
                            {
                                item2 = player.inventory[num68];
                                hasAmmo = true;
                                break;
                            }
                        }
                    }
                }
                if (player.itemAnimation > 0 && player.whoAmI == Main.myPlayer && /*player.itemTime == 0 &&*/ hasAmmo && item2 != null)
                {
                    if (vanillaFastGuns.Contains(item.type))
                    {
                        Shoot(item, player, ref center, ref num70, ref num71, ref item2.shoot, ref item.damage, ref item.knockBack);
                    }
                }
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ModContent.ItemType<AdvAmmoReservationPotion>() && player.HasBuff(BuffID.AmmoReservation) ||
                item.type == ItemID.AmmoReservationPotion && player.HasBuff(ModContent.BuffType<AdvAmmoReservation>()) ||
                item.type == ModContent.ItemType<AdvArcheryPotion>() && player.HasBuff(BuffID.Archery) ||
                item.type == ItemID.ArcheryPotion && player.HasBuff(ModContent.BuffType<AdvArchery>()) ||
                item.type == ModContent.ItemType<AdvBattlePotion>() && player.HasBuff(BuffID.Battle) ||
                item.type == ItemID.BattlePotion && player.HasBuff(ModContent.BuffType<AdvBattle>()) ||
                item.type == ModContent.ItemType<AdvBuilderPotion>() && player.HasBuff(BuffID.Builder) ||
                item.type == ItemID.BuilderPotion && player.HasBuff(ModContent.BuffType<AdvBuilder>()) ||
                item.type == ModContent.ItemType<AdvCalmingPotion>() && player.HasBuff(BuffID.Calm) ||
                item.type == ItemID.CalmingPotion && player.HasBuff(ModContent.BuffType<AdvCalming>()) ||
                item.type == ModContent.ItemType<AdvCratePotion>() && player.HasBuff(BuffID.Crate) ||
                item.type == ItemID.CratePotion && player.HasBuff(ModContent.BuffType<AdvCrate>()) ||
                item.type == ModContent.ItemType<AdvDangersensePotion>() && player.HasBuff(BuffID.Dangersense) ||
                item.type == ItemID.TrapsightPotion && player.HasBuff(ModContent.BuffType<AdvDangersense>()) ||
                item.type == ModContent.ItemType<AdvEndurancePotion>() && player.HasBuff(BuffID.Endurance) ||
                item.type == ItemID.EndurancePotion && player.HasBuff(ModContent.BuffType<AdvEndurance>()) ||
                item.type == ModContent.ItemType<AdvFeatherfallPotion>() && player.HasBuff(BuffID.Featherfall) ||
                item.type == ItemID.FeatherfallPotion && player.HasBuff(ModContent.BuffType<AdvFeatherfall>()) ||
                item.type == ModContent.ItemType<AdvFishingPotion>() && player.HasBuff(BuffID.Fishing) ||
                item.type == ItemID.FishingPotion && player.HasBuff(ModContent.BuffType<AdvFishing>()) ||
                item.type == ModContent.ItemType<AdvFlipperPotion>() && player.HasBuff(BuffID.Flipper) ||
                item.type == ItemID.FlipperPotion && player.HasBuff(ModContent.BuffType<AdvFlipper>()) ||
                item.type == ModContent.ItemType<AdvGillsPotion>() && player.HasBuff(BuffID.Gills) ||
                item.type == ItemID.GillsPotion && player.HasBuff(ModContent.BuffType<AdvGills>()) ||
                item.type == ModContent.ItemType<AdvGravitationPotion>() && player.HasBuff(BuffID.Gravitation) ||
                item.type == ItemID.GravitationPotion && player.HasBuff(ModContent.BuffType<AdvGravitation>()) ||
                item.type == ModContent.ItemType<AdvHeartreachPotion>() && player.HasBuff(BuffID.Heartreach) ||
                item.type == ItemID.HeartreachPotion && player.HasBuff(ModContent.BuffType<AdvHeartreach>()) ||
                item.type == ModContent.ItemType<AdvHunterPotion>() && player.HasBuff(BuffID.Hunter) ||
                item.type == ItemID.HunterPotion && player.HasBuff(ModContent.BuffType<AdvHunter>()) ||
                item.type == ModContent.ItemType<AdvInfernoPotion>() && player.HasBuff(BuffID.Inferno) ||
                item.type == ItemID.InfernoPotion && player.HasBuff(ModContent.BuffType<AdvInferno>()) ||
                item.type == ModContent.ItemType<AdvInvisibilityPotion>() && player.HasBuff(BuffID.Invisibility) ||
                item.type == ItemID.InvisibilityPotion && player.HasBuff(ModContent.BuffType<AdvInvisibility>()) ||
                item.type == ModContent.ItemType<AdvIronskinPotion>() && player.HasBuff(BuffID.Ironskin) ||
                item.type == ItemID.IronskinPotion && player.HasBuff(ModContent.BuffType<AdvIronskin>()) ||
                item.type == ModContent.ItemType<AdvLifeforcePotion>() && player.HasBuff(BuffID.Lifeforce) ||
                item.type == ItemID.LifeforcePotion && player.HasBuff(ModContent.BuffType<AdvLifeforce>()) ||
                item.type == ModContent.ItemType<AdvMagicPowerPotion>() && player.HasBuff(BuffID.MagicPower) ||
                item.type == ItemID.MagicPowerPotion && player.HasBuff(ModContent.BuffType<AdvMagicPower>()) ||
                item.type == ModContent.ItemType<AdvManaRegenerationPotion>() && player.HasBuff(BuffID.ManaRegeneration) ||
                item.type == ItemID.ManaRegenerationPotion && player.HasBuff(ModContent.BuffType<AdvManaRegeneration>()) ||
                item.type == ModContent.ItemType<AdvMiningPotion>() && player.HasBuff(BuffID.Mining) ||
                item.type == ItemID.MiningPotion && player.HasBuff(ModContent.BuffType<AdvMining>()) ||
                item.type == ModContent.ItemType<AdvNightOwlPotion>() && player.HasBuff(BuffID.NightOwl) ||
                item.type == ItemID.NightOwlPotion && player.HasBuff(ModContent.BuffType<AdvNightOwl>()) ||
                item.type == ModContent.ItemType<AdvObsidianSkinPotion>() && player.HasBuff(BuffID.ObsidianSkin) ||
                item.type == ItemID.ObsidianSkinPotion && player.HasBuff(ModContent.BuffType<AdvObsidianSkin>()) ||
                item.type == ModContent.ItemType<AdvRagePotion>() && player.HasBuff(BuffID.Rage) ||
                item.type == ItemID.RagePotion && player.HasBuff(ModContent.BuffType<AdvRage>()) ||
                item.type == ModContent.ItemType<AdvRegenerationPotion>() && player.HasBuff(BuffID.Regeneration) ||
                item.type == ItemID.RegenerationPotion && player.HasBuff(ModContent.BuffType<AdvRegeneration>()) ||
                item.type == ModContent.ItemType<AdvShinePotion>() && player.HasBuff(BuffID.Shine) ||
                item.type == ItemID.ShinePotion && player.HasBuff(ModContent.BuffType<AdvShine>()) ||
                item.type == ModContent.ItemType<AdvSonarPotion>() && player.HasBuff(BuffID.Sonar) ||
                item.type == ItemID.SonarPotion && player.HasBuff(ModContent.BuffType<AdvSonar>()) ||
                item.type == ModContent.ItemType<AdvSpelunkerPotion>() && player.HasBuff(BuffID.Spelunker) ||
                item.type == ItemID.SpelunkerPotion && player.HasBuff(ModContent.BuffType<AdvSpelunker>()) ||
                item.type == ModContent.ItemType<AdvSummoningPotion>() && player.HasBuff(BuffID.Summoning) ||
                item.type == ItemID.SummoningPotion && player.HasBuff(ModContent.BuffType<AdvSummoning>()) ||
                item.type == ModContent.ItemType<AdvSwiftnessPotion>() && player.HasBuff(BuffID.Swiftness) ||
                item.type == ItemID.SwiftnessPotion && player.HasBuff(ModContent.BuffType<AdvSwiftness>()) ||
                item.type == ModContent.ItemType<AdvThornsPotion>() && player.HasBuff(BuffID.Thorns) ||
                item.type == ItemID.ThornsPotion && player.HasBuff(ModContent.BuffType<AdvThorns>()) ||
                item.type == ModContent.ItemType<AdvTitanPotion>() && player.HasBuff(BuffID.Titan) ||
                item.type == ItemID.TitanPotion && player.HasBuff(ModContent.BuffType<AdvTitan>()) ||
                item.type == ModContent.ItemType<AdvWarmthPotion>() && player.HasBuff(BuffID.Warmth) ||
                item.type == ItemID.WarmthPotion && player.HasBuff(ModContent.BuffType<AdvWarmth>()) ||
                item.type == ModContent.ItemType<AdvWaterWalkingPotion>() && player.HasBuff(BuffID.WaterWalking) ||
                item.type == ItemID.WaterWalkingPotion && player.HasBuff(ModContent.BuffType<AdvWaterWalking>()) ||
                item.type == ModContent.ItemType<AdvWrathPotion>() && player.HasBuff(BuffID.Wrath) ||
                item.type == ItemID.WrathPotion && player.HasBuff(ModContent.BuffType<AdvWrath>()) ||
                item.type == ModContent.ItemType<AdvBloodCastPotion>() && player.HasBuff(ModContent.BuffType<BloodCast>()) ||
                item.type == ModContent.ItemType<BloodCastPotion>() && player.HasBuff(ModContent.BuffType<AdvBloodCast>()) ||
                item.type == ModContent.ItemType<AdvCrimsonPotion>() && player.HasBuff(ModContent.BuffType<CrimsonDrain>()) ||
                item.type == ModContent.ItemType<CrimsonPotion>() && player.HasBuff(ModContent.BuffType<AdvCrimson>()) ||
                item.type == ModContent.ItemType<AdvForceFieldPotion>() && player.HasBuff(ModContent.BuffType<ForceField>()) ||
                item.type == ModContent.ItemType<ForceFieldPotion>() && player.HasBuff(ModContent.BuffType<AdvForceField>()) ||
                item.type == ModContent.ItemType<AdvFuryPotion>() && player.HasBuff(ModContent.BuffType<Fury>()) ||
                item.type == ModContent.ItemType<FuryPotion>() && player.HasBuff(ModContent.BuffType<AdvFury>()) ||
                item.type == ModContent.ItemType<AdvGauntletPotion>() && player.HasBuff(ModContent.BuffType<Gauntlet>()) ||
                item.type == ModContent.ItemType<GauntletPotion>() && player.HasBuff(ModContent.BuffType<AdvGauntlet>()) ||
                item.type == ModContent.ItemType<AdvGPSPotion>() && player.HasBuff(ModContent.BuffType<GPS>()) ||
                item.type == ModContent.ItemType<GPSPotion>() && player.HasBuff(ModContent.BuffType<AdvGPS>()) ||
                item.type == ModContent.ItemType<AdvLeapingPotion>() && player.HasBuff(ModContent.BuffType<Leaping>()) ||
                item.type == ModContent.ItemType<LeapingPotion>() && player.HasBuff(ModContent.BuffType<AdvLeaping>()) ||
                item.type == ModContent.ItemType<AdvLuckPotion>() && player.HasBuff(ModContent.BuffType<Luck>()) ||
                item.type == ModContent.ItemType<LuckPotion>() && player.HasBuff(ModContent.BuffType<AdvLuck>()) ||
                item.type == ModContent.ItemType<AdvRoguePotion>() && player.HasBuff(ModContent.BuffType<Rogue>()) ||
                item.type == ModContent.ItemType<RoguePotion>() && player.HasBuff(ModContent.BuffType<AdvRogue>()) ||
                item.type == ModContent.ItemType<AdvShadowPotion>() && player.HasBuff(ModContent.BuffType<Shadows>()) ||
                item.type == ModContent.ItemType<ShadowPotion>() && player.HasBuff(ModContent.BuffType<AdvShadow>()) ||
                item.type == ModContent.ItemType<AdvShockwavePotion>() && player.HasBuff(ModContent.BuffType<Shockwave>()) ||
                item.type == ModContent.ItemType<ShockwavePotion>() && player.HasBuff(ModContent.BuffType<AdvShockwave>()) ||
                item.type == ModContent.ItemType<AdvStarbrightPotion>() && player.HasBuff(ModContent.BuffType<Starbright>()) ||
                item.type == ModContent.ItemType<StarbrightPotion>() && player.HasBuff(ModContent.BuffType<AdvStarbright>()) ||
                item.type == ModContent.ItemType<AdvStrengthPotion>() && player.HasBuff(ModContent.BuffType<Strong>()) ||
                item.type == ModContent.ItemType<StrengthPotion>() && player.HasBuff(ModContent.BuffType<AdvStrength>()) ||
                item.type == ModContent.ItemType<AdvSupersonicPotion>() && player.HasBuff(ModContent.BuffType<Supersonic>()) ||
                item.type == ModContent.ItemType<SupersonicPotion>() && player.HasBuff(ModContent.BuffType<AdvSupersonic>()) ||
                item.type == ModContent.ItemType<AdvTitanskinPotion>() && player.HasBuff(ModContent.BuffType<Titanskin>()) ||
                item.type == ModContent.ItemType<TitanskinPotion>() && player.HasBuff(ModContent.BuffType<AdvTitanskin>()) ||
                item.type == ModContent.ItemType<AdvVisionPotion>() && player.HasBuff(ModContent.BuffType<Vision>()) ||
                item.type == ModContent.ItemType<VisionPotion>() && player.HasBuff(ModContent.BuffType<AdvVision>()) ||
                item.type == ModContent.ItemType<AdvWisdomPotion>() && player.HasBuff(ModContent.BuffType<Wisdom>()) ||
                item.type == ModContent.ItemType<WisdomPotion>() && player.HasBuff(ModContent.BuffType<AdvWisdom>()))
            {
                return false;
            }
            //for (int k = 0; k < 22; k++)
            //{
            //    string st;
            //    if (item.buffType >= Main.maxBuffTypes)
            //    {
            //        st = ModContent.GetModBuff(player.buffType[k]).Name;
            //    }
            //    else
            //    {
            //        st = Lang.GetBuffName(player.buffType[k]);
            //    }

            //    if (item.Name.Contains(potionNames[potionNames.FindIndex(s => s.Contains(st))]) && item.buffType != player.buffType[k] && item.buffType != 0)
            //    {
            //        return false;
            //    }
            //}
            

            if (item.type == ItemID.ManaCrystal && player.statManaMax >= 200)
            {
                return false;
            }
            if (item.type == ItemID.RodofDiscord && ((player.Avalon().ZoneSkyFortress && !ExxoAvalonOriginsWorld.downedDragonLord) || (player.Avalon().ZoneNearHellcastle && !ExxoAvalonOriginsWorld.downedPhantasm)))
            {
                return false;
            }
            return base.CanUseItem(item, player);
        }

        public override bool? UseItem(Item item, Player player)
        {
            //if (item.type == ModContent.ItemType<Items.Weapons.Summon.AdamantiteDaggerStaff>() || item.type == ModContent.ItemType<Items.Weapons.Summon.BismuthDaggerStaff>() ||
            //    item.type == ModContent.ItemType<Items.Weapons.Summon.GoldDaggerStaff>() || item.type == ModContent.ItemType<Items.Weapons.Summon.PlatinumDaggerStaff>() ||
            //    item.type == ModContent.ItemType<Items.Weapons.Summon.TitaniumDaggerStaff>() || item.type == ModContent.ItemType<Items.Weapons.Summon.TroxiniumDaggerStaff>())
            //{
            //    if (player.Avalon().daggerStaffActiveIDs.Count >= player.maxMinions)
            //    {
            //        player.Avalon().daggerStaffActiveIDs[0] = false;
            //        player.Avalon().daggerStaffActiveIDs.RemoveAt(0);
            //    }
            //}
            if (player.Avalon().cloudGloves && player.whoAmI == Main.myPlayer)
            {
                bool inrange = (player.position.X / 16f - Player.tileRangeX - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetX &&
                    (player.position.X + player.width) / 16f + Player.tileRangeX + player.inventory[player.selectedItem].tileBoost - 1f + player.blockRange >= Player.tileTargetX &&
                    player.position.Y / 16f - Player.tileRangeY - player.inventory[player.selectedItem].tileBoost - player.blockRange <= Player.tileTargetY &&
                    (player.position.Y + player.height) / 16f + Player.tileRangeY + player.inventory[player.selectedItem].tileBoost - 2f + player.blockRange >= Player.tileTargetY);
                if (item.createTile > -1 && (Main.tileSolid[item.createTile] || nonSolidExceptions.Contains(item.createTile)) &&
                    (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava() || player.HasItemInArmor(ModContent.ItemType<ObsidianGlove>())) &&
                    !Main.tile[Player.tileTargetX, Player.tileTargetY].HasTile && inrange)
                {
                    bool subtractFromStack = WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, item.createTile);
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].HasTile && Main.netMode != NetmodeID.SinglePlayer && subtractFromStack)
                    {
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 1, Player.tileTargetX, Player.tileTargetY, item.createTile);
                    }
                    if (subtractFromStack) item.stack--;
                }
                if (item.createWall > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].wall == 0 && inrange)
                {
                    WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, item.createWall);
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].wall != 0 && Main.netMode != NetmodeID.SinglePlayer)
                    {
                        NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 3, Player.tileTargetX, Player.tileTargetY, item.createWall);
                    }
                    //Main.PlaySound(0, Player.tileTargetX * 16, Player.tileTargetY * 16, 1);
                    item.stack--;
                }
            }
            return base.UseItem(item, player);
        }
        public bool IsArmor(Item item)
        {
            if (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1)
            {
                return !item.vanity;
            }
            return false;
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine tooltipLine = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName" && x.mod == "Terraria");
            if (tooltipLine != null)
            {
                if (item.type == ItemID.CoinGun)
                {
                    tooltipLine.text = "Spend Shot";
                }
                if (item.type == ItemID.PurpleMucos)
                {
                    tooltipLine.text = "Purple Mucus";
                }
                if (item.type == ItemID.HighTestFishingLine)
                {
                    tooltipLine.text = tooltipLine.text.Replace("Test", "Tensile");
                }
                if (item.type == ItemID.BlueSolution)
                {
                    tooltipLine.text = "Cyan Solution";
                }
                if (item.type == ItemID.DarkBlueSolution)
                {
                    tooltipLine.text = "Blue Solution";
                }
                if (item.type == ItemID.FrostsparkBoots)
                {
                    tooltipLine.text = tooltipLine.text.Replace("Frostspark", "Sparkfrost");
                }
                if (item.type == ItemID.BossMaskCultist)
                {
                    tooltipLine.text = "Lunatic Cultist Mask";
                }
                if (item.type == ItemID.AncientCultistTrophy)
                {
                    tooltipLine.text = "Lunatic Cultist Trophy";
                }
            }
            if (IsArmor(item) && !item.social)
            {
                if (item.prefix == ModContent.PrefixType<Fluidic>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+5% increased movement speed")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccMaxMana", "Free movement in liquids")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Barbaric>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+4% damage")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccMaxMana", "+6% knockback")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Boosted>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+4% increased movement speed")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Busted>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "-1 defense")
                        {
                            isModifier = true,
                            isModifierBad = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Disgusting>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "-2 defense")
                        {
                            isModifier = true,
                            isModifierBad = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccMaxMana", "Stink potion effect")
                        {
                            isModifier = true,
                            isModifierBad = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Glorious>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+4% damage")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccMaxMana", "+1 defense")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Insane>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "Increased placement speed")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Loaded>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+1 defense")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Messy>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "-5% damage")
                        {
                            isModifier = true,
                            isModifierBad = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Mythic>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+20 maximum mana")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Protective>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+2 defense")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Silly>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+2% critical strike chance")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Handy>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+1 block range")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Slimy>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "Reduces damage taken by 3%")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Confused>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+5% melee damage")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccMaxMana", "-2% melee speed")
                        {
                            isModifier = true,
                            isModifierBad = true
                        });
                    }
                }
            }
            if (item.accessory && !item.social)
            {
                if (item.prefix == ModContent.PrefixType<Magical>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+40 mana")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Enchanted>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMaxMana", "+20 maximum mana")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccMoveSpeed", "+3% movement speed")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 3, new TooltipLine(Mod, "PrefixAccDefense", "+1 defense")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Bogus>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccCritChance", "+6% critical strike chance")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Vigorous>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccMeleeSpeed", "+3% melee speed")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccDamage", "+3% damage")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Prefixes.Robust>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccDefense", "+3 defense")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccDamage", "+3% damage")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Lurid>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(Mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(Mod, "PrefixAccDefense", "+2 defense")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(Mod, "PrefixAccCritChance", "+2% critical strike chance")
                        {
                            isModifier = true
                        });
                    }
                }
            }
            switch (item.type)
            {
                case ItemID.Vine:
                    tooltips.Add(new TooltipLine(Mod, "Rope", "Can be climbed on"));
                    break;
                case ItemID.Seed:
                    for (int i = 0; i < tooltips.Count; i++)
                    {
                        if (tooltips[i].Name == "Tooltip0")
                        {
                            tooltips[i].text = "For use with Blowpipes";
                        }
                    }
                    break;
                case ItemID.PoisonDart:
                    for (int i = 0; i < tooltips.Count; i++)
                    {
                        if (tooltips[i].Name == "Tooltip1")
                        {
                            tooltips[i].text = "For use with Blowpipes and Blowgun";
                        }
                    }
                    break;
                case ItemID.CoinGun:
                    for (int i = 0; i < tooltips.Count; i++)
                    {
                        if (tooltips[i].Name == "Tooltip0")
                        {
                            tooltips[i].text = "Uses coins for ammo - Higher valued coins do more damage";
                        }
                        if (tooltips[i].Name == "Tooltip1")
                        {
                            tooltips[i].text = "'Knocks some cents into your enemies'";
                        }
                    }
                    break;
                case ItemID.PickaxeAxe:
                    for (int i = 0; i < tooltips.Count; i++)
                    {
                        if (tooltips[i].Name == "Tooltip0")
                        {
                            tooltips[i].text = "'Not to be confused with a hamdrill'";
                        }
                        if (tooltips[i].Name == "Tooltip1")
                        {
                            tooltips[i].text = "Can mine Chlorophyte, Xanthophyte, and Caesium Ore";
                        }
                    }
                    break;
                case ItemID.Drax:
                    for (int i = 0; i < tooltips.Count; i++)
                    {
                        if (tooltips[i].Name == "Tooltip0")
                        {
                            tooltips[i].text = "'Not to be confused with a picksaw'";
                        }
                        if (tooltips[i].Name == "Tooltip1")
                        {
                            tooltips[i].text = "Can mine Chlorophyte, Xanthophyte, and Caesium Ore";
                        }
                    }
                    break;
            }
        }
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.Avalon().splitProj &&
                item.ranged &&
                Main.rand.Next(7) == 0 &&
                type != ModContent.ProjectileType<Projectiles.EnchantedShuriken>())
            {
                for (int num221 = 0; num221 < 1; num221++)
                {
                    float num222 = speedX;
                    float num223 = speedY;
                    num222 += Main.rand.Next(-30, 31) * 0.05f;
                    num223 += Main.rand.Next(-30, 31) * 0.05f;
                    if (item.type == ModContent.ItemType<Items.Weapons.Blah.TacticalBlahncher>()) type = ModContent.ProjectileType<Projectiles.Blahcket>();
                    if (item.type == ModContent.ItemType<VorazylcumFusebow>()) type = ModContent.ProjectileType<Projectiles.ArrowBeam>();
                    if (item.type == ModContent.ItemType<UnvolanditeFusebow>()) type = ModContent.ProjectileType<Projectiles.UnvolanditeBolt>();
                    Projectile.NewProjectile(position.X, position.Y, num222, num223, type, damage, knockBack, player.whoAmI, 0f, 0f);
                }
            }

            /*if (player.Avalon().ancientGunslinger &&
                item.ranged &&
                inaccurateGuns.Contains(item.type))
            {
                float sX = Main.mouseX + Main.screenPosition.X - player.Center.X;
                float sY = Main.mouseY + Main.screenPosition.Y - player.Center.Y;
                Main.NewText(sX);
                Main.NewText(sY);
                speedX = sX;
                speedY = sY;
                //int proj = Projectile.NewProjectile(position.X, position.Y, sX, sY, type, damage, knockBack, player.whoAmI, 0f, 0f);
                return false;
            }*/

            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void PostUpdate(Item item)
        {
            if (item.lavaWet)
            {
                if (item.type == ModContent.ItemType<HellboundRemote>() && Main.hardMode && ExxoAvalonOriginsWorld.downedPhantasm)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        item.active = false;
                        item.type = ItemID.None;
                        item.stack = 0;
                        if (Main.hardMode && ExxoAvalonOriginsWorld.downedPhantasm)
                        {
                            ExxoAvalonOriginsGlobalNPC.SpawnWOS(item.position);
                            SoundEngine.PlaySound(SoundID.Item, -1, -1, Mod.GetSoundSlot(SoundType.Item, "Sounds/Item/WoS"), 0.75f);
                        }
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, NetworkText.Empty, item.whoAmI, 0f, 0f, 0f, 0);
                    }
                }
            }
        }

        public override void UpdateEquip(Item item, Player player)
        {
            if (item.prefix == ModContent.PrefixType<Prefixes.Lurid>())
            {
                player.GetCritChance(DamageClass.Magic) += 2;
                player.GetCritChance(DamageClass.Melee) += 2;
                player.GetCritChance(DamageClass.Ranged) += 2;
                player.GetCritChance(DamageClass.Throwing) += 2;
                player.statDefense += 2;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Robust>())
            {
                player.GetDamage(DamageClass.Magic) += 0.03f;
                player.GetDamage(DamageClass.Melee) += 0.03f;
                player.GetDamage(DamageClass.Ranged) += 0.03f;
                player.GetDamage(DamageClass.Throwing) += 0.03f;
                player.GetDamage(DamageClass.Summon) += 0.03f;
                player.statDefense += 3;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Vigorous>())
            {
                player.meleeSpeed += 0.03f;
                player.GetDamage(DamageClass.Melee) += 0.03f;
                player.GetDamage(DamageClass.Ranged) += 0.03f;
                player.GetDamage(DamageClass.Magic) += 0.03f;
                player.GetDamage(DamageClass.Summon) += 0.03f;
                player.GetDamage(DamageClass.Throwing) += 0.03f;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Magical>())
            {
                player.statManaMax2 += 40;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Bogus>())
            {
                player.GetCritChance(DamageClass.Magic) += 6;
                player.GetCritChance(DamageClass.Melee) += 6;
                player.GetCritChance(DamageClass.Ranged) += 6;
                player.GetCritChance(DamageClass.Throwing) += 6;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Enchanted>())
            {
                player.moveSpeed += 0.03f;
                player.statManaMax2 += 20;
                player.statDefense++;
            }
        }
        public static bool IsHerb(int t)
        {
            return (t == ItemID.Daybloom || t == ItemID.Moonglow || t == ItemID.Blinkroot || t == ItemID.Deathweed ||
                t == ItemID.Waterleaf || t == ItemID.Fireblossom || t == ItemID.Shiverthorn || t == ModContent.ItemType<LargeBarfbush>() ||
                t == ModContent.ItemType<LargeBarfbushSeed>() || t == ModContent.ItemType<LargeDaybloom>() || t == ModContent.ItemType<LargeDaybloomSeed>() ||
                t == ModContent.ItemType<LargeBlinkroot>() || t == ModContent.ItemType<LargeBlinkrootSeed>() || t == ModContent.ItemType<LargeBloodberry>() ||
                t == ModContent.ItemType<LargeBloodberrySeed>() || t == ModContent.ItemType<LargeDeathweed>() || t == ModContent.ItemType<LargeDeathweedSeed>() ||
                t == ModContent.ItemType<LargeFireblossom>() || t == ModContent.ItemType<LargeFireblossomSeed>() || t == ModContent.ItemType<LargeMoonglow>() ||
                t == ModContent.ItemType<LargeMoonglowSeed>() || t == ModContent.ItemType<LargeShiverthorn>() || t == ModContent.ItemType<LargeShiverthornSeed>() ||
                t == ModContent.ItemType<LargeSweetstem>() || t == ModContent.ItemType<LargeSweetstemSeed>() || t == ModContent.ItemType<LargeWaterleaf>() ||
                t == ModContent.ItemType<LargeWaterleafSeed>() || t == ModContent.ItemType<Bloodberry>() || t == ModContent.ItemType<Sweetstem>() ||
                t == ModContent.ItemType<Barfbush>() || t == ModContent.ItemType<LargeBloodberrySeed>() || t == ModContent.ItemType<LargeSweetstemSeed>() ||
                t == ModContent.ItemType<LargeBarfbushSeed>() || t == ModContent.ItemType<LargeBloodberry>() || t == ModContent.ItemType<LargeSweetstem>() ||
                t == ModContent.ItemType<LargeBarfbush>());
        }
        public static bool IsPotion(int t)
        {
            return ((t >= 288 && t <= 305) || (t >= 2322 && t <= 2329) ||
                (t >= 2344 && t <= 2349) || (t >= 2354 && t <= 2356) ||
                t == 2359 || t == ModContent.ItemType<CrimsonPotion>() || t == ModContent.ItemType<ShockwavePotion>() ||
                t == ModContent.ItemType<LuckPotion>() || t == ModContent.ItemType<BloodCastPotion>() || t == ModContent.ItemType<StarbrightPotion>() ||
                t == ModContent.ItemType<VisionPotion>() || t == ModContent.ItemType<StrengthPotion>() || t == ModContent.ItemType<GPSPotion>() ||
                /*t == ID.ItemID.TimeShiftPotion ||*/ t == ModContent.ItemType<ShadowPotion>() || t == ModContent.ItemType<RoguePotion>() ||
                t == ModContent.ItemType<WisdomPotion>() || t == ModContent.ItemType<GauntletPotion>() || t == ModContent.ItemType<TitanskinPotion>() ||
                t == ModContent.ItemType<InvincibilityPotion>() || t == ModContent.ItemType<ForceFieldPotion>() || t == ModContent.ItemType<BlahPotion>() ||
                t == ModContent.ItemType<FuryPotion>());
        }
        public static bool IsAdvancedPotion(string name)
        {
            return (name.Contains("Elixir") && name != "Elixir of Life");
        }
    }
}
