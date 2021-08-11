using System;using System.Collections.Generic;using System.IO;
using System.Linq;using System.Text;using System.Threading.Tasks;using ExxoAvalonOrigins.UI;using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using Terraria;using Terraria.ID;using Terraria.Localization;
using Terraria.ModLoader;using Terraria.ModLoader.IO;
using Terraria.UI;namespace ExxoAvalonOrigins{    class ExxoAvalonOriginsGlobalItem : GlobalItem    {                public override void SetDefaults(Item item)        {            int[] to2000 =            {                ItemID.WoodenArrow,                ItemID.FlamingArrow,                ItemID.UnholyArrow,                ItemID.JestersArrow,                ItemID.MusketBall,                ItemID.MeteorShot,                ItemID.HellfireArrow,                ItemID.SilverBullet,                ItemID.CrystalBullet,                ItemID.HolyArrow,                ItemID.CursedArrow,                ItemID.CursedBullet,                ItemID.RocketI,                ItemID.RocketII,                ItemID.RocketIII,                ItemID.RocketIV,                ItemID.FrostburnArrow,                ItemID.ChlorophyteBullet,                ItemID.StyngerBolt,                ItemID.HighVelocityBullet,                ItemID.IchorArrow,                ItemID.IchorBullet,                ItemID.VenomArrow,                ItemID.VenomBullet,                ItemID.PartyBullet,                ItemID.NanoBullet,                ItemID.ExplodingBullet,                ItemID.GoldenBullet,                ItemID.BlueSolution,                ItemID.DarkBlueSolution,                ItemID.GreenSolution,                ItemID.PurpleSolution,                ItemID.RedSolution            };            int[] to999 =            {                ItemID.Mushroom,                ItemID.Torch,                ItemID.GoldBar,                ItemID.CopperBar,                ItemID.SilverBar,                ItemID.IronBar,                ItemID.Acorn,                ItemID.LifeCrystal,                ItemID.Bottle,                ItemID.Lens,                ItemID.DemoniteBar,                ItemID.CorruptSeeds,                ItemID.VileMushroom,                ItemID.GrassSeeds,                ItemID.Sunflower,                ItemID.PurificationPowder,                ItemID.VilePowder,                ItemID.RottenChunk,                ItemID.WormTooth,                ItemID.FallenStar,                ItemID.ShadowScale,                ItemID.WoodPlatform,                ItemID.ManaCrystal,                ItemID.MeteoriteBar,                ItemID.Hook,                ItemID.Book,                ItemID.Bomb,                ItemID.Grenade,                ItemID.HellstoneBar,                ItemID.MushroomGrassSeeds,                ItemID.JungleGrassSeeds,                ItemID.Stinger,                ItemID.Vine,                ItemID.StickyBomb,                ItemID.BlackLens,                ItemID.BlackThread,                ItemID.GreenThread,                ItemID.Leather,                ItemID.Glowstick,                ItemID.StickyGlowstick,                ItemID.DaybloomSeeds,                ItemID.MoonglowSeeds,                ItemID.BlinkrootSeeds,                ItemID.DeathweedSeeds,                ItemID.WaterleafSeeds,                ItemID.FireblossomSeeds,                ItemID.Daybloom,                ItemID.Moonglow,                ItemID.Blinkroot,                ItemID.Deathweed,                ItemID.Waterleaf,                ItemID.Fireblossom,                ItemID.SharkFin,                ItemID.Feather,                ItemID.AntlionMandible,                ItemID.IllegalGunParts,                ItemID.GoldenKey,                ItemID.JungleSpores,                ItemID.TatteredCloth,                ItemID.HallowedSeeds,                ItemID.CobaltBar,                ItemID.MythrilBar,                ItemID.AdamantiteBar,                ItemID.BlueTorch,                ItemID.RedTorch,                ItemID.GreenTorch,                ItemID.PurpleTorch,                ItemID.WhiteTorch,                ItemID.YellowTorch,                ItemID.DemonTorch,                ItemID.PixieDust,                ItemID.CursedFlame,                ItemID.CursedTorch,                ItemID.UnicornHorn,                ItemID.DarkShard,                ItemID.LightShard,                ItemID.EbonwoodPlatform,                ItemID.RichMahoganyPlatform,                ItemID.PearlwoodPlatform,                ItemID.BonePlatform,                ItemID.TinBar,                ItemID.LeadBar,                ItemID.TungstenBar,                ItemID.PlatinumBar,                ItemID.ShadewoodPlatform,                ItemID.Marshmallow,                ItemID.IceTorch,                ItemID.PinkThread,                ItemID.ChlorophyteBar,                ItemID.TealMushroom,                ItemID.GreenMushroom,                ItemID.SkyBlueFlower,                ItemID.YellowMarigold,                ItemID.BlueBerries,                ItemID.LimeKelp,                ItemID.PinkPricklyPear,                ItemID.OrangeBloodroot,                ItemID.RedHusk,                ItemID.CyanHusk,                ItemID.VioletHusk,                ItemID.PurpleMucos,                ItemID.BlackInk,                ItemID.TempleKey,                ItemID.PalladiumBar,                ItemID.OrichalcumBar,                ItemID.TitaniumBar,                ItemID.HallowedBar,                ItemID.ChlorophyteArrow,                ItemID.OrangeTorch,                ItemID.CrimtaneBar,                ItemID.LifeFruit,                ItemID.LihzahrdPowerCell,                ItemID.TurtleShell,                ItemID.TissueSample,                ItemID.Vertebrae,                ItemID.Ichor,                ItemID.IchorTorch,                ItemID.VialofVenom,                ItemID.BlueBrickPlatform,                ItemID.PinkBrickPlatform,                ItemID.GreenBrickPlatform,                ItemID.MetalShelf,                ItemID.BrassShelf,                ItemID.WoodShelf,                ItemID.DungeonShelf,                ItemID.ObsidianPlatform,                ItemID.Ectoplasm,                ItemID.GiantHarpyFeather,                ItemID.BoneFeather,                ItemID.FireFeather,                ItemID.IceFeather,                ItemID.BrokenBatWing,                ItemID.TatteredBeeWing,                ItemID.JungleKey,                ItemID.CorruptionKey,                ItemID.CrimsonKey,                ItemID.HallowedKey,                ItemID.FrozenKey,                ItemID.ShroomiteBar,                ItemID.BrokenHeroSword,                ItemID.ButterflyDust,                ItemID.GlassPlatform,                ItemID.GoodieBag,                ItemID.JungleKeyMold,                ItemID.CorruptionKeyMold,                ItemID.CrimsonKeyMold,                ItemID.HallowedKeyMold,                ItemID.FrozenKeyMold,                ItemID.BlackFairyDust,                ItemID.SpookyPlatform,                ItemID.PumpkinSeed,                ItemID.SpookyTwig,                ItemID.Holly,                ItemID.Coal,                ItemID.CrimsonSeeds,                ItemID.BeetleHusk,                ItemID.UltrabrightTorch,                ItemID.ShiverthornSeeds,                ItemID.Shiverthorn,                ItemID.BeeWax,                ItemID.PalmWoodPlatform,                ItemID.MushroomPlatform,                ItemID.BorealWoodPlatform,                ItemID.SlimePlatform,                ItemID.StickyGrenade,                ItemID.SpiderFang,                ItemID.SteampunkPlatform,                ItemID.SkywarePlatform,                ItemID.LivingWoodPlatform,                ItemID.HoneyPlatform,                ItemID.CactusPlatform            };            int[] to100 =            {                ItemID.BottledWater,                ItemID.Dynamite,                ItemID.ObsidianSkinPotion,                ItemID.RegenerationPotion,                ItemID.SwiftnessPotion,                ItemID.GillsPotion,                ItemID.IronskinPotion,                ItemID.ManaRegenerationPotion,                ItemID.MagicPowerPotion,                ItemID.FeatherfallPotion,                ItemID.SpelunkerPotion,                ItemID.InvisibilityPotion,                ItemID.ShinePotion,                ItemID.NightOwlPotion,                ItemID.BattlePotion,                ItemID.ThornsPotion,                ItemID.WaterWalkingPotion,                ItemID.ArcheryPotion,                ItemID.HunterPotion,                ItemID.GravitationPotion,                ItemID.GreaterManaPotion,                ItemID.CookedMarshmallow,                ItemID.FlaskofVenom,                ItemID.FlaskofCursedFlames,                ItemID.FlaskofFire,                ItemID.FlaskofGold,                ItemID.FlaskofIchor,                ItemID.FlaskofNanites,                ItemID.FlaskofParty,                ItemID.FlaskofPoison,                ItemID.MiningPotion,                ItemID.HeartreachPotion,                ItemID.CalmingPotion,                ItemID.BuilderPotion,                ItemID.TitanPotion,                ItemID.FlipperPotion,                ItemID.SummoningPotion,                ItemID.TrapsightPotion,                ItemID.AmmoReservationPotion,                ItemID.LifeforcePotion,                ItemID.EndurancePotion,                ItemID.RagePotion,                ItemID.InfernoPotion,                ItemID.WrathPotion,                ItemID.RecallPotion,                ItemID.TeleportationPotion,                ItemID.LovePotion,                ItemID.StinkPotion,                ItemID.FishingPotion,                ItemID.SonarPotion,                ItemID.CratePotion            };            switch (item.type)            {                case ItemID.Torch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 0;                    item.notAmmo = true;                    break;                case ItemID.EnchantedBoomerang:                    item.rare = 2;                        break;                    case ItemID.RottenChunk:                    item.useStyle = 1;                    item.useAnimation = 15;                    item.useTime = 10;                    item.consumable = true;                    item.useTurn = true;                    item.autoReuse = true;                    item.createTile = ModContent.TileType<Tiles.RottenChunk>();                    break;                case ItemID.ShadowScale:                    item.useTurn = true;                    item.useStyle = 1;                    item.useAnimation = 15;                    item.useTime = 10;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.ShadowScale>();                    break;                case ItemID.NightmarePickaxe:                    item.pick = 60;                    break;                case ItemID.LesserManaPotion:                    item.maxStack = 50;                    break;                case ItemID.Spike:                    item.ammo = 147;                    break;                case ItemID.Hellstone:                    item.value = Item.sellPrice(0, 0, 13, 30);                    break;                case ItemID.ManaPotion:                    item.maxStack = 75;                    break;                case ItemID.Vine:                    item.useStyle = 1;                    item.useTurn = true;                    item.useAnimation = 15;                    item.useTime = 8;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.VineRope>();                    item.tileBoost += 3;                    break;                case ItemID.LesserRestorationPotion:                    item.rare = 2;                    item.maxStack = 40;                    break;                case ItemID.RestorationPotion:                    item.rare = 2;                    item.maxStack = 40;                    break;                case ItemID.Goldfish:                    item.makeNPC = (short) ModContent.NPCType<NPCs.ImpactWizard>();                    break;                case ItemID.DivingHelmet:                    item.value = 10000;                    break;                case ItemID.MagicPowerPotion:                    item.buffTime = 18000;                    break;                case ItemID.ThornsPotion:                    item.buffTime = 10800;                    break;                case ItemID.GravitationPotion:                    item.buffTime = 21600;                    break;                case ItemID.GoblinBattleStandard:                    item.maxStack = 20;                    break;                case ItemID.BlueTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 1;                    break;                case ItemID.RedTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 2;                    break;                case ItemID.GreenTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 3;                    break;                case ItemID.PurpleTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 4;                    break;                case ItemID.WhiteTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 5;                    break;                case ItemID.YellowTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 6;                    break;                case ItemID.DemonTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 7;                    break;                case ItemID.PixieDust:                    item.value = 1000;                    break;                case ItemID.Flamethrower:                    item.damage = 35;                    break;                case ItemID.SoulofLight:                    item.useStyle = 1;                    item.useTurn = true;                    item.useAnimation = 15;                    item.useTime = 10;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.LightsoulBlock>();                    break;                case ItemID.SoulofNight:                    item.useStyle = 1;                    item.useTurn = true;                    item.useAnimation = 15;                    item.useTime = 10;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.NightsoulBlock>();                    break;                case ItemID.CursedTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 8;                    break;                case ItemID.SoulofFright:                    item.useStyle = 1;                    item.useTurn = true;                    item.useAnimation = 15;                    item.useTime = 10;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.FrightsoulBlock>();                    break;                case ItemID.SoulofMight:                    item.useStyle = 1;                    item.useTurn = true;                    item.useAnimation = 15;                    item.useTime = 10;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.MightsoulBlock>();                    break;                case ItemID.SoulofSight:                    item.useStyle = 1;                    item.useTurn = true;                    item.useAnimation = 15;                    item.useTime = 10;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.SightsoulBlock>();                    break;                case ItemID.SoulofFlight:                    item.useStyle = 1;                    item.useTurn = true;                    item.useAnimation = 15;                    item.useTime = 10;                    item.autoReuse = true;                    item.consumable = true;                    item.createTile = ModContent.TileType<Tiles.FlightsoulBlock>();                    break;                case ItemID.SnowGlobe:                    item.maxStack = 20;                    break;                case ItemID.RainbowBrick:                    item.rare = 12;                    break;                case ItemID.RainbowBrickWall:                    item.rare = 12;                    break;                case ItemID.UnholyTrident:                    item.autoReuse = true;                    break;                case ItemID.FrostHelmet:                    item.defense = 12;                    break;                case ItemID.FrostBreastplate:                    item.defense = 22;                    break;                case ItemID.FrostLeggings:                    item.defense = 15;                    break;                case ItemID.AmethystStaff:                    item.damage = 15;                    break;                case ItemID.TopazStaff:                    item.damage = 16;                    break;                case ItemID.SapphireStaff:                    item.damage = 19;                    break;                case ItemID.EmeraldStaff:                    item.damage = 20;                    break;                case ItemID.RubyStaff:                    item.damage = 22;                    break;                case ItemID.DiamondStaff:                    item.damage = 25;                    break;                case ItemID.TerraBlade:                    item.noMelee = false;                    break;                case ItemID.DeathbringerPickaxe:                    item.pick = 64;                    break;                case ItemID.BlackBelt:                    item.value = 150000;                    break;                case ItemID.IceTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 9;                    break;                case ItemID.ChlorophyteMask:                    item.defense = 27;                    break;                case ItemID.ChlorophyteHelmet:                    item.defense = 15;                    break;                case ItemID.ChlorophyteHeadgear:                    item.defense = 9;                    break;                case ItemID.ChlorophytePlateMail:                    item.defense = 20;                    break;                case ItemID.ChlorophyteGreaves:                    item.defense = 15;                    break;                case ItemID.PossessedHatchet:                    item.shootSpeed = 16f;                    item.useAnimation = 12;                    item.useTime = 12;                    break;                case ItemID.WaspGun:                    item.damage = 23;                    break;                case ItemID.OrangeTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 10;                    break;                case ItemID.SniperRifle:                    item.value = Item.sellPrice(0, 7, 0, 0);                    break;                case ItemID.Uzi:                    item.value = 250000;                    break;                case ItemID.SkeletronMask:                    item.value = Item.sellPrice(0, 2, 0, 0);                    break;                case ItemID.Picksaw:                    item.tileBoost++;                    break;                case ItemID.HeatRay:                    item.mana = 5;                    break;                case ItemID.TheAxe:                    item.hammer = 95;                    break;                case ItemID.SlimeStaff:                    item.damage = 11;                    break;                case ItemID.PirateMap:                    item.maxStack = 20;                    break;                case ItemID.TurtleHelmet:                    item.defense = 24;                    break;                case ItemID.TurtleScaleMail:                    item.defense = 29;                    break;                case ItemID.TurtleLeggings:                    item.defense = 20;                    break;                case ItemID.BonePickaxe:                    item.pick = 55;                        break;                    case ItemID.Vertebrae:                    item.useStyle = 1;                    item.useAnimation = 15;                    item.useTime = 10;                    item.consumable = true;                    item.useTurn = true;                    item.autoReuse = true;                    item.createTile = ModContent.TileType<Tiles.Vertebrae>();                    break;                case ItemID.IchorTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 11;                    break;                case ItemID.FlaskofGold:                    item.value = 108000;                    break;                case ItemID.Ectoplasm:                    item.useStyle = 1;                    item.useAnimation = 15;                    item.useTime = 10;                    item.consumable = true;                    item.useTurn = true;                    item.autoReuse = true;                    item.createTile = ModContent.TileType<Tiles.Ectoplasm>();                    break;                case ItemID.AnkhCharm:                    item.value = Item.sellPrice(0, 10, 0, 0);                    break;                case ItemID.AnkhShield:                    item.value = Item.sellPrice(0, 13, 0, 0);                    break;                case ItemID.Coal:                    item.value = 5;                    item.rare = -1;                    break;                case ItemID.ShroomiteDiggingClaw:                    item.pick = 205;                    break;                case ItemID.BeetleHelmet:                    item.defense = 25;                    break;                case ItemID.BeetleScaleMail:                    item.defense = 22;                    break;                case ItemID.BeetleShell:                    item.defense = 33;                    break;                case ItemID.BeetleLeggings:                    item.defense = 19;                    break;                case ItemID.SuperManaPotion:                    item.maxStack = 150;                    break;                case ItemID.UltrabrightTorch:                    item.ammo = 8;                    item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 12;                    break;                case ItemID.LifeforcePotion:                    item.rare = 3;                    break;                case ItemID.RagePotion:                    item.rare = 2;                    break;                case ItemID.InfernoPotion:                    item.rare = 3;                    break;                case ItemID.TeleportationPotion:                    item.rare = 2;                    break;                case ItemID.FishingPotion:                    item.value = 1000;                    break;                case ItemID.SonarPotion:                    item.buffTime = 19600;                    break;                case ItemID.CratePotion:                    item.buffTime = 28800;                    break;                case ItemID.AnglerHat:                    item.defense = 3;                    break;                case ItemID.AnglerVest:                    item.defense = 5;                    break;                case ItemID.AnglerPants:                    item.defense = 4;                    break;                case ItemID.SpiderMask:                    item.defense = 6;                    break;                case ItemID.SpiderBreastplate:                    item.defense = 9;                    break;                case ItemID.SpiderGreaves:                    item.defense = 8;                    break;                case ItemID.KingSlimeMask:                    item.value = Item.sellPrice(0, 2, 0, 0);                    break;                case ItemID.DukeFishronMask:                    item.value = Item.sellPrice(0, 2, 0, 0);                    break;            }            //if (item.type >= 1615 && item.type <= 1701)            //{            //    item.maxStack = 999;            //}            if (item.type >= 2104 && item.type <= 2113)            {                item.value = Item.sellPrice(0, 2, 0, 0);            }            if (to2000.Contains(item.type))            {                item.maxStack = 2000;            }            if (to999.Contains(item.type))            {                item.maxStack = 999;            }            if (to100.Contains(item.type))            {                item.maxStack = 100;            }            if (item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch > 0)            {                item.notAmmo = true;            }        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.GolemBossBag)
            {
                int drop = 0;
                switch (Main.rand.Next(3))
                {
                    case 0:
                        drop = ModContent.ItemType<Items.Sunstorm>();
                        break;
                    case 1:
                        drop = ModContent.ItemType<Items.HeartoftheGolem>();
                        break;
                    case 2:
                        drop = ModContent.ItemType<Items.EarthenInsignia>();
                        break;
                }
                player.QuickSpawnItem(drop);
            }
        }        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)        {            TooltipLine tooltipLine = tooltips.FirstOrDefault((TooltipLine x) => x.Name == "ItemName" && x.mod == "Terraria");            if (tooltipLine != null)
            {
                if (item.type == ItemID.CoinGun) tooltipLine.text = "Spend Shot";
                if (item.type == ItemID.HighTestFishingLine) tooltipLine.text = "High Tensile Fishing Line";
                if (item.type == ItemID.BlueSolution) tooltipLine.text = "Cyan Solution";
                if (item.type == ItemID.DarkBlueSolution) tooltipLine.text = "Blue Solution";
                if (item.type == ItemID.FrostsparkBoots) tooltipLine.text = "Sparkfrost Boots";
            }            if (item.accessory && !item.social)
            {
                if (item.prefix == ModContent.PrefixType<Prefixes.Magical>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(mod, "PrefixAccMaxMana", "+40 mana")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Prefixes.Enchanted>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(mod, "PrefixAccMaxMana", "+20 maximum mana")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(mod, "PrefixAccMoveSpeed", "+3% movement speed")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 3, new TooltipLine(mod, "PrefixAccDefense", "+1 defense")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Prefixes.Bogus>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(mod, "PrefixAccCritChance", "+6% critical strike chance")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Prefixes.Vigorous>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(mod, "PrefixAccMeleeSpeed", "+3% melee speed")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(mod, "PrefixAccDamage", "+3% damage")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Prefixes.Robust>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(mod, "PrefixAccDefense", "+3 defense")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(mod, "PrefixAccDamage", "+3% damage")
                        {
                            isModifier = true
                        });
                    }
                }
                if (item.prefix == ModContent.PrefixType<Prefixes.Lurid>())
                {
                    int index = tooltips.FindLastIndex(tt => (tt.mod.Equals("Terraria") || tt.mod.Equals(mod.Name))
                        && (tt.Name.Equals("Material") || tt.Name.StartsWith("Tooltip") || tt.Name.Equals("Defense") || tt.Name.Equals("Equipable")));
                    if (index != -1)
                    {
                        tooltips.Insert(index + 1, new TooltipLine(mod, "PrefixAccDefense", "+2 defense")
                        {
                            isModifier = true
                        });
                        tooltips.Insert(index + 2, new TooltipLine(mod, "PrefixAccCritChance", "+2% critical strike chance")
                        {
                            isModifier = true
                        });
                    }
                }
            }            switch (item.type)            {                case ItemID.Vine:                    tooltips.Add(new TooltipLine(mod, "Rope", "Can be climbed on"));                    break;                case ItemID.Seed:                    for (var i = 0; i < tooltips.Count; i++)                    {                        if (tooltips[i].Name == "Tooltip0")                        {                            tooltips[i].text = "For use with Blowpipes";                        }                    }                    break;                case ItemID.PoisonDart:                    for (var i = 0; i < tooltips.Count; i++)                    {                        if (tooltips[i].Name == "Tooltip1")                        {                            tooltips[i].text = "For use with Blowpipes and Blowgun";                        }                    }                    break;
                case ItemID.CoinGun:                    for (var i = 0; i < tooltips.Count; i++)                    {                        if (tooltips[i].Name == "Tooltip0")                        {                            tooltips[i].text = "Uses coins for ammo - Higher valued coins do more damage";                        }                        if (tooltips[i].Name == "Tooltip1")                        {                            tooltips[i].text = "'Knocks some cents into your enemies'";                        }                    }                    break;
                case ItemID.PickaxeAxe:                    for (var i = 0; i < tooltips.Count; i++)                    {                        if (tooltips[i].Name == "Tooltip0")                        {                            tooltips[i].text = "'Not to be confused with a hamdrill'";                        }                        if (tooltips[i].Name == "Tooltip1")                        {                            tooltips[i].text = "Can mine Chlorophyte and Caesium Ore";                        }                    }                    break;
                case ItemID.Drax:                    for (var i = 0; i < tooltips.Count; i++)                    {                        if (tooltips[i].Name == "Tooltip0")                        {                            tooltips[i].text = "'Not to be confused with a picksaw'";                        }                        if (tooltips[i].Name == "Tooltip1")                        {                            tooltips[i].text = "Can mine Chlorophyte and Caesium Ore";                        }                    }                    break;            }        }        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,            ref int damage, ref float knockBack)        {                if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().splitProj &&                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].ranged &&                Main.rand.Next(7) == 0 && type != ItemID.CursedTorch)            {                for (int num221 = 0; num221 < 2; num221++)                {                    float num222 = speedX;                    float num223 = speedY;                    num222 += (float) Main.rand.Next(-30, 31) * 0.05f;                    num223 += (float) Main.rand.Next(-30, 31) * 0.05f;                    Projectile.NewProjectile(position.X, position.Y, num222, num223, type, damage, knockBack,                        player.whoAmI, 0f, 0f);                }                return false;            }            return true;        }        public override void PostUpdate(Item item)
        {
            if (item.lavaWet)
            {
                if (item.type == ModContent.ItemType<Items.HellboundRemote>())
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        item.active = false;
                        item.type = 0;
                        item.stack = 0;
                        if (Main.hardMode && NPC.downedGolemBoss)
                        {
                            ExxoAvalonOriginsGlobalNPC.SpawnWOS(item.position);
                            Main.PlaySound(SoundID.Item, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/WoS"), 0.75f);
                        }
                        NetMessage.SendData(21, -1, -1, NetworkText.Empty, item.whoAmI, 0f, 0f, 0f, 0);
                    }
                }
            }
        }        public override void UpdateEquip(Item item, Player player)
        {
            if (item.prefix == ModContent.PrefixType<Prefixes.Lurid>())
            {
                player.magicCrit += 2;
                player.meleeCrit += 2;
                player.rangedCrit += 2;
                player.thrownCrit += 2;
                player.statDefense += 2;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Robust>())
            {
                player.magicDamage += 0.03f;
                player.meleeDamage += 0.03f;
                player.rangedDamage += 0.03f;
                player.thrownDamage += 0.03f;
                player.minionDamage += 0.03f;
                player.statDefense += 3;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Vigorous>())
            {
                player.meleeSpeed += 0.03f;
                player.meleeDamage += 0.03f;
                player.rangedDamage += 0.03f;
                player.magicDamage += 0.03f;
                player.minionDamage += 0.03f;
                player.thrownDamage += 0.03f;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Magical>())
            {
                player.statManaMax2 += 40;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Bogus>())
            {
                player.magicCrit += 6;
                player.meleeCrit += 6;
                player.rangedCrit += 6;
                player.thrownCrit += 6;
            }
            if (item.prefix == ModContent.PrefixType<Prefixes.Enchanted>())
            {
                player.moveSpeed += 0.03f;
                player.statManaMax2 += 20;
                player.statDefense++;
            }
        }        public static bool IsHerb(int t)
        {
            return (t == ItemID.Daybloom || t == ItemID.Moonglow || t == ItemID.Blinkroot || t == ItemID.Deathweed ||
                t == ItemID.Waterleaf || t == ItemID.Fireblossom || t == ItemID.Shiverthorn || t == ModContent.ItemType<Items.LargeBarfbush>() ||
                t == ModContent.ItemType<Items.LargeBarfbushSeed>() || t == ModContent.ItemType<Items.LargeDaybloom>() || t == ModContent.ItemType<Items.LargeDaybloomSeed>() ||
                t == ModContent.ItemType<Items.LargeBlinkroot>() || t == ModContent.ItemType<Items.LargeBlinkrootSeed>() || t == ModContent.ItemType<Items.LargeBloodberry>() ||
                t == ModContent.ItemType<Items.LargeBloodberrySeed>() || t == ModContent.ItemType<Items.LargeDeathweed>() || t == ModContent.ItemType<Items.LargeDeathweedSeed>() ||
                t == ModContent.ItemType<Items.LargeFireblossom>() || t == ModContent.ItemType<Items.LargeFireblossomSeed>() || t == ModContent.ItemType<Items.LargeMoonglow>() ||
                t == ModContent.ItemType<Items.LargeMoonglowSeed>() || t == ModContent.ItemType<Items.LargeShiverthorn>() || t == ModContent.ItemType<Items.LargeShiverthornSeed>() ||
                t == ModContent.ItemType<Items.LargeSweetstem>() || t == ModContent.ItemType<Items.LargeSweetstemSeed>() || t == ModContent.ItemType<Items.LargeWaterleaf>() ||
                t == ModContent.ItemType<Items.LargeWaterleafSeed>());// || t == ItemID.Sweetstem ||
                //t == ItemID.Bloodberry || t == ItemID.Barfbush || (t >= 3700 && t <= 3719));
        }        public static bool IsPotion(int t)
        {
            return ((t >= 288 && t <= 305) || (t >= 2322 && t <= 2329) ||
                                (t >= 2344 && t <= 2349) || (t >= 2354 && t <= 2356) ||
                                t == 2359 || t == ModContent.ItemType<Items.CrimsonPotion>() || t == ModContent.ItemType<Items.ShockwavePotion>() ||
                                t == ModContent.ItemType<Items.LuckPotion>() || t == ModContent.ItemType<Items.BloodCastPotion>() || t == ModContent.ItemType<Items.StarbrightPotion>() ||
                                t == ModContent.ItemType<Items.VisionPotion>() || t == ModContent.ItemType<Items.StrengthPotion>() || t == ModContent.ItemType<Items.GPSPotion>() ||
                                /*t == ID.ItemID.TimeShiftPotion ||*/ t == ModContent.ItemType<Items.ShadowPotion>() || t == ModContent.ItemType<Items.RoguePotion>() ||
                                t == ModContent.ItemType<Items.WisdomPotion>() || t == ModContent.ItemType<Items.GauntletPotion>() || t == ModContent.ItemType<Items.TitanskinPotion>() ||
                                t == ModContent.ItemType<Items.InvincibilityPotion>() || t == ModContent.ItemType<Items.ForceFieldPotion>() || t == ModContent.ItemType<Items.BlahPotion>());
        }        public static bool IsAdvancedPotion(string name)
        {
            return (name.Contains("Advanced") && name.Contains("Potion"));
        }    }}