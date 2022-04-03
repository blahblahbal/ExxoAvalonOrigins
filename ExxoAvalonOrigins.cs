using System;
using System.Collections.Generic;
using System.IO;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Items.Placeable.Painting;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Vanity;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using ExxoAvalonOrigins.Logic;
using ExxoAvalonOrigins.Projectiles.Torches;
using ExxoAvalonOrigins.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace ExxoAvalonOrigins;

public class ExxoAvalonOrigins : Mod
{
#if DEBUG
    public const bool DevMode = true;
#else
        public const bool DevMode = false;
#endif
    public const bool GodMode = false;
    public new readonly Version Version = new Version(0, 9, 8, 3, DevMode);

    public Mod MusicMod;

    // Hotkeys

    public ModHotKey ShadowHotkey;
    public ModHotKey SprintHotkey;
    public ModHotKey DashHotkey;
    public ModHotKey QuintupleHotkey;
    public ModHotKey SwimHotkey;
    public ModHotKey WallSlideHotkey;
    public ModHotKey BubbleBoostHotkey;
    public ModHotKey ModeChangeHotkey;
    public ModHotKey AstralHotkey;
    public ModHotKey minionGuidingHotkey;
    public ModHotKey RocketJumpHotkey;
    public ModHotKey QuickStaminaHotkey;
    public ModHotKey FlightTimeRestoreHotkey;

    // UI

    private UserInterface staminaInterface;
    private UserInterface tomeSlotUserInterface;
    private UserInterface herbologyUserInterface;
    private StaminaBar staminaBar;
    private TomeSlot tomeSlot;
    private UI.Herbology.HerbologyUIState herbology;
    public bool CheckPointer = true;

    // Reference to the main instance of the mod
    public static ExxoAvalonOrigins Mod { get; private set; }

    public static float CaesiumTransition;

    public ExxoAvalonOrigins()
    {
        Mod = this;
    }
    public override void Load()
    {
        Hooks.HooksManager.ApplyHooks();

        ExxoAvalonOriginsModPlayer.torches = new Dictionary<int, int>()
        {
            { ItemID.Torch, ModContent.ProjectileType<Torch>() },
            { ItemID.BlueTorch, ModContent.ProjectileType<BlueTorch>() },
            { ItemID.RedTorch, ModContent.ProjectileType<RedTorch>() },
            { ItemID.GreenTorch, ModContent.ProjectileType<GreenTorch>() },
            { ItemID.PurpleTorch, ModContent.ProjectileType<PurpleTorch>() },
            { ItemID.WhiteTorch, ModContent.ProjectileType<WhiteTorch>() },
            { ItemID.YellowTorch, ModContent.ProjectileType<YellowTorch>() },
            { ItemID.DemonTorch, ModContent.ProjectileType<DemonTorch>() },
            { ItemID.CursedTorch, ModContent.ProjectileType<CursedTorch>() },
            { ItemID.IceTorch, ModContent.ProjectileType<IceTorch>() },
            { ItemID.OrangeTorch, ModContent.ProjectileType<OrangeTorch>() },
            { ItemID.IchorTorch, ModContent.ProjectileType<IchorTorch>() },
            { ItemID.UltrabrightTorch, ModContent.ProjectileType<UltrabrightTorch>() },
            { ModContent.ItemType<Items.Placeable.Light.JungleTorch>(), ModContent.ProjectileType<JungleTorch>() },
            { ModContent.ItemType<Items.Placeable.Light.PathogenTorch>(), ModContent.ProjectileType<PathogenTorch>() },
            { ModContent.ItemType<Items.Placeable.Light.SlimeTorch>(), ModContent.ProjectileType<SlimeTorch>() },
            { ModContent.ItemType<Items.Placeable.Light.CyanTorch>(), ModContent.ProjectileType<CyanTorch>() },
            { ModContent.ItemType<Items.Placeable.Light.LimeTorch>(), ModContent.ProjectileType<LimeTorch>() },
            { ModContent.ItemType<Items.Placeable.Light.BrownTorch>(), ModContent.ProjectileType<BrownTorch>() },
            { ItemID.BoneTorch, ModContent.ProjectileType<BoneTorch>() },
            { ItemID.RainbowTorch, ModContent.ProjectileType<RainbowTorch>() },
            { ItemID.PinkTorch, ModContent.ProjectileType<PinkTorch>() },
        };

        if (Main.netMode != NetmodeID.Server)
        {
            Mod imkTokensMod = ModLoader.GetMod("imkSushisMod");
            if (imkTokensMod != null)
            {
                ExxoAvalonOriginsGlobalNPC.imkCompat = true;
            }
            if (ModLoader.GetMod("AvalonMusic") != null)
            {
                MusicMod = ModLoader.GetMod("AvalonMusic");
            }

            ExxoAvalonOriginsModPlayer.lavaMermanTextures = new ReLogic.Content.Asset<Texture2D>[]
            {
                Mod.Assets.Request<Texture2D>("Sprites/LavaMerman_Head"),
                Mod.Assets.Request<Texture2D>("Sprites/LavaMerman_Body"),
                Mod.Assets.Request<Texture2D>("Sprites/LavaMerman_Arms"),
                Mod.Assets.Request<Texture2D>("Sprites/LavaMerman_FemaleBody"),
                Mod.Assets.Request<Texture2D>("Sprites/LavaMerman_Legs")
            };
            ExxoAvalonOriginsModPlayer.spectrumArmorTextures = new Texture2D[]
            {
                Mod.Assets.Request<Texture2D>("Items/Armor/SpectrumHelmet_Glow_Head").Value,
                Mod.Assets.Request<Texture2D>("Items/Armor/SpectrumBreastplate_Body_Glow").Value,
                Mod.Assets.Request<Texture2D>("Items/Armor/SpectrumBreastplate_Arms_Glow").Value,
                Mod.Assets.Request<Texture2D>("Items/Armor/SpectrumBreastplate_FemaleBody_Glow").Value,
                Mod.Assets.Request<Texture2D>("Items/Armor/SpectrumGreaves_Legs_Glow").Value,
            };
            ExxoAvalonOriginsModPlayer.originalMermanTextures = new ReLogic.Content.Asset<Texture2D>[]
            {
                Mod.Assets.Request<Texture2D>("Images" + Path.DirectorySeparatorChar + "Armor_Head_39"),
                Mod.Assets.Request<Texture2D>("Images" + Path.DirectorySeparatorChar + "Armor_Body_22"),
                Mod.Assets.Request<Texture2D>("Images" + Path.DirectorySeparatorChar + "Armor_Arm_22"),
                Mod.Assets.Request<Texture2D>("Images" + Path.DirectorySeparatorChar + "Female_Body_22"),
                Mod.Assets.Request<Texture2D>("Images" + Path.DirectorySeparatorChar + "Armor_Legs_21")
            };

            // Vanilla Texture replacements
            TextureAssets.Logo = ModContent.Request<Texture2D>("Sprites/EAOLogo");
            TextureAssets.Logo2 = ModContent.Request<Texture2D>("Sprites/EAOLogo");
            if (DateTime.Now.Month == 4 && DateTime.Now.Day == 1)
            {
                TextureAssets.Logo = ModContent.Request<Texture2D>("Sprites/EAOLogoAprilFools");
                TextureAssets.Logo2 = ModContent.Request<Texture2D>("Sprites/EAOLogoAprilFools");
            }

            TextureAssets.Item[ItemID.HallowedKey] = ModContent.Request<Texture2D>("Sprites/HallowedKey");
            TextureAssets.Item[ItemID.MagicDagger] = ModContent.Request<Texture2D>("Sprites/MagicDagger");
            TextureAssets.Tile[TileID.CopperCoinPile] = ModContent.Request<Texture2D>("Sprites/CopperCoin");
            TextureAssets.Tile[TileID.SilverCoinPile] = ModContent.Request<Texture2D>("Sprites/SilverCoin");
            TextureAssets.Tile[TileID.GoldCoinPile] = ModContent.Request<Texture2D>("Sprites/GoldCoin");
            TextureAssets.Tile[TileID.PlatinumCoinPile] = ModContent.Request<Texture2D>("Sprites/PlatinumCoin");
            TextureAssets.Item[ItemID.PaladinBanner] = ModContent.Request<Texture2D>("Sprites/PaladinBanner");
            TextureAssets.Item[ItemID.PossessedArmorBanner] = ModContent.Request<Texture2D>("Sprites/PossessedArmorBanner");
            TextureAssets.Item[ItemID.BoneLeeBanner] = ModContent.Request<Texture2D>("Sprites/BoneLeeBanner");
            TextureAssets.Item[ItemID.AngryTrapperBanner] = ModContent.Request<Texture2D>("Sprites/AngryTrapperBanner");
            TextureAssets.Item[ItemID.Deathweed] = ModContent.Request<Texture2D>("Sprites/Deathweed");
            TextureAssets.Item[ItemID.WaterleafSeeds] = ModContent.Request<Texture2D>("Sprites/WaterleafSeeds");
            TextureAssets.Projectile[ProjectileID.MagicDagger] = ModContent.Request<Texture2D>("Sprites/MagicDagger");
            TextureAssets.Tile[91] = ModContent.Request<Texture2D>("Sprites/VanillaBanners");
            TextureAssets.Tile[21] = ModContent.Request<Texture2D>("Sprites/VanillaChests");

            NPCs.Bosses.WallofSteel.Load();
            Projectiles.PhantasmLaser.Load();

            Effects.EffectsManager.Load();
            Hooks.HooksManager.Load();

            // Hotkeys

            ShadowHotkey = RegisterHotKey("Shadow/Stamina Teleport", "V");
            SprintHotkey = RegisterHotKey("Toggle Stamina Sprinting", "F");
            DashHotkey = RegisterHotKey("Toggle Stamina Stamina Dash", "K");
            QuintupleHotkey = RegisterHotKey("Toggle Quintuple Jump", "RightControl");
            SwimHotkey = RegisterHotKey("Toggle Stamina Swimming", "L");//implemented?
            WallSlideHotkey = RegisterHotKey("Toggle Stamina Wall Sliding", "Z");
            FlightTimeRestoreHotkey = RegisterHotKey("Stamina Restore Flight Time", "G");
            BubbleBoostHotkey = RegisterHotKey("Toggle Bubble Boost", "U");
            ModeChangeHotkey = RegisterHotKey("Change Modes", "N");
            AstralHotkey = RegisterHotKey("Activate Astral Projecting", "OemPipe");
            minionGuidingHotkey = RegisterHotKey("Ancient Minion Guiding", "Mouse2");
            RocketJumpHotkey = RegisterHotKey("Stamina Rocket Jump", "C");
            QuickStaminaHotkey = RegisterHotKey("Quick Stamina", "X");

            // UI

            tomeSlot = new TomeSlot();
            tomeSlot.Activate();
            tomeSlotUserInterface = new UserInterface();
            tomeSlotUserInterface.SetState(tomeSlot);
            herbology = new UI.Herbology.HerbologyUIState();
            herbologyUserInterface = new UserInterface();
            staminaInterface = new UserInterface();
            staminaBar = new StaminaBar();
            staminaInterface.SetState(staminaBar);

            Main.chTitle = true;
        }

        //AddAvalonAlts();
    }

    public override void Unload()
    {
        ExxoAvalonOriginsModPlayer.torches = null;
        if (Main.netMode != NetmodeID.Server)
        {
            TextureAssets.Logo = ModContent.Request<Texture2D>("Images" + Path.DirectorySeparatorChar + "Logo");
            TextureAssets.Logo2 = ModContent.Request<Texture2D>("Images" + Path.DirectorySeparatorChar + "Logo2");
        }
    }

    public override void HandlePacket(BinaryReader reader, int whoAmI)
    {
        Network.MessageHandler.HandlePacket(reader, whoAmI);
    }
    public override void PreUpdateEntities()
    {
        if (Main.netMode == NetmodeID.MultiplayerClient)
        {
            Main.tileSolidTop[ModContent.TileType<Tiles.FallenStarTile>()] = Main.dayTime;
        }
    }

    public override void PostUpdateEverything()
    {
        Tiles.CoolGemsparkBlock.StaticUpdate();
        Tiles.WarmGemsparkBlock.StaticUpdate();
        Items.Armor.SpectrumHelmet.StaticUpdate();
    }

    public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
    {
        float ickyStrength = ExxoAvalonOriginsWorld.ickyTiles / 800f;
        ickyStrength = Math.Min(ickyStrength, 1f);
        if (ickyStrength > 0)
        {
            int sunR = Main.bgColor.R;
            int sunG = Main.bgColor.G;
            int sunB = Main.bgColor.B;
            sunR -= (int)(100f * ickyStrength * (Main.bgColor.R / 255f));
            sunG -= (int)(50f * ickyStrength * (Main.bgColor.G / 255f));
            sunB -= (int)(80f * ickyStrength * (Main.bgColor.G / 255f));
            sunR = Utils.Clamp(sunR, 15, 255);
            sunG = Utils.Clamp(sunG, 15, 255);
            sunB = Utils.Clamp(sunB, 15, 255);
            Main.bgColor.R = (byte)sunR;
            Main.bgColor.G = (byte)sunG;
            Main.bgColor.B = (byte)sunB;
        }
    }

    /*public override void UpdateMusic(ref int music, ref MusicPriority priority)
    {
        Mod musicMod = ModLoader.GetMod("AvalonMusic");
        if (Main.musicVolume == 0f || Main.myPlayer == -1 || Main.gameMenu)
        {
            return;
        }

        Player player = Main.LocalPlayer;
        if (!player.active)
        {
            return;
        }

        if (player.Avalon().ZoneTropics)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Tropics");
            }
            else
            {
                music = MusicID.Jungle;
            }

            priority = MusicPriority.BiomeMedium;
        }
        if (player.Avalon().ZoneContagion)
        {
            if (Main.player[Main.myPlayer].position.Y > (Main.worldSurface * 16.0) + (Main.screenHeight / 2))
            {
                if (musicMod != null)
                {
                    music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/UndergroundContagion");
                }
                else
                {
                    music = MusicID.UndergroundCrimson;
                }

                priority = MusicPriority.BiomeHigh;
            }
            else
            {
                if (musicMod != null)
                {
                    music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Contagion");
                }
                else
                {
                    music = MusicID.Crimson;
                }

                priority = MusicPriority.BiomeHigh;
            }
        }
        if (Main.tile[(int)player.position.X / 16, (int)player.position.Y / 16].WallType == ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>() && ExxoAvalonOriginsWorld.tropicTiles > 50)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/TuhrtlOutpost");
            }
            else
            {
                music = MusicID.Temple;
            }

            priority = MusicPriority.BiomeHigh;
        }
        if (player.Avalon().ZoneHellcastle)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Hellcastle");
            }
            else
            {
                music = MusicID.Dungeon;
            }

            priority = MusicPriority.Environment;
        }
        if (player.Avalon().ZoneSkyFortress)
        {
            if (musicMod != null)
            {
                music = MusicID.Dungeon; // musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/SkyFortress"); //ADD MUSIC LATER
            }
            else
            {
                music = MusicID.Dungeon;
            }

            priority = MusicPriority.Environment;
        }
        if (player.Avalon().ZoneDarkMatter)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/DarkMatter");
            }
            else
            {
                music = MusicID.Eclipse;
            }

            priority = MusicPriority.Environment;
        }
        var rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
        const int dist = 5000;
        bool phantasm = false;
        bool bactprime = false;
        bool desertbeak = false;
        bool wallofsteel = false;
        bool armageddon = false;
        foreach (NPC n in Main.npc)
        {
            if (n.type == ModContent.NPCType<NPCs.BacteriumPrime>() && n.active)
            {
                var bact = new Rectangle((int)(n.position.X + (n.width / 2)) - dist, (int)(n.position.Y + (n.height / 2)) - dist, dist * 2, dist * 2);
                if (bact.Intersects(rectangle))
                {
                    bactprime = true;
                    break;
                }
            }
            if (n.type == ModContent.NPCType<NPCs.Bosses.Phantasm>() && n.active)
            {
                var phant = new Rectangle((int)(n.position.X + (n.width / 2)) - dist, (int)(n.position.Y + (n.height / 2)) - dist, dist * 2, dist * 2);
                if (phant.Intersects(rectangle))
                {
                    phantasm = true;
                    break;
                }
            }
            if (n.type == ModContent.NPCType<NPCs.Bosses.DesertBeak>() && n.active)
            {
                var db = new Rectangle((int)(n.position.X + (n.width / 2)) - dist, (int)(n.position.Y + (n.height / 2)) - dist, dist * 2, dist * 2);
                if (db.Intersects(rectangle))
                {
                    desertbeak = true;
                    break;
                }
            }
            if (n.type == ModContent.NPCType<NPCs.Bosses.WallofSteel>() && n.active)
            {
                var wos = new Rectangle((int)(n.position.X + (n.width / 2)) - dist, (int)(n.position.Y + (n.height / 2)) - dist, dist * 2, dist * 2);
                if (wos.Intersects(rectangle))
                {
                    wallofsteel = true;
                    break;
                }
            }
            if (n.type == ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>() && n.active)
            {
                var arma = new Rectangle((int)(n.position.X + (n.width / 2)) - dist, (int)(n.position.Y + (n.height / 2)) - dist, dist * 2, dist * 2);
                if (arma.Intersects(rectangle))
                {
                    armageddon = true;
                    break;
                }
            }
        }
        if (bactprime)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/BacteriumPrime");
            }
            else
            {
                music = MusicID.Boss3;
            }

            priority = MusicPriority.BossLow;
        }
        if (desertbeak)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/DesertBeak");
            }
            else
            {
                music = MusicID.Boss4;
            }

            priority = MusicPriority.BossLow;
        }
        if (phantasm)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Phantasm");
            }
            else
            {
                music = MusicID.Boss3;
            }

            priority = MusicPriority.BossLow;
        }
        if (wallofsteel)
        {
            music = MusicID.Boss2;
            priority = MusicPriority.BossLow;
        }
        if (armageddon)
        {
            if (musicMod != null)
            {
                music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/ArmageddonSlime");
            }
            else
            {
                music = MusicID.Boss5;
            }

            priority = MusicPriority.BossLow;
        }
    }*/

    public override void PostSetupContent()
    {
        ExxoAvalonOriginsCall.Support();
    }
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
        layers.Insert(0, new LegacyGameInterfaceLayer(
            "ExxoAvalonOrigins: Update Interfaces",
            delegate
            {
                if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb && Main.playerInventory && herbologyUserInterface.CurrentState == null)
                {
                    herbologyUserInterface.SetState(herbology);
                    typeof(UserInterface).GetField("_clickDisabledTimeRemaining", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(herbologyUserInterface, 10);
                }
                else if (!(Main.playerInventory && Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb) && herbologyUserInterface.CurrentState != null)
                {
                    herbologyUserInterface.SetState(null);
                }

                herbologyUserInterface.Update(Main._drawInterfaceGameTime);
                staminaInterface.Update(Main._drawInterfaceGameTime);
                return true;
            },
            InterfaceScaleType.UI)
        );

        int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Radial Hotbars"));
        if (inventoryIndex >= 0)
        {
            layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                "ExxoAvalonOrigins: Tome Slot",
                delegate
                {
                    tomeSlot.DrawTomes(Main.spriteBatch);
                    return true;
                },
                InterfaceScaleType.UI)
            );

            layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                "ExxoAvalonOrigins: Herbology Bench",
                delegate
                {
                    herbologyUserInterface.Draw(Main.spriteBatch, Main._drawInterfaceGameTime);
                    return true;
                },
                InterfaceScaleType.UI)
            );
        }

        int resourceBarsIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
        if (resourceBarsIndex >= 0)
        {
            layers.Insert(resourceBarsIndex, new LegacyGameInterfaceLayer(
                "ExxoAvalonOrigins: Stamina Bar",
                delegate
                {
                    staminaInterface.Draw(Main.spriteBatch, Main._drawInterfaceGameTime);
                    return true;
                },
                InterfaceScaleType.UI)
            );
        }
    }

    public override void AddRecipeGroups()
    {
        if (RecipeGroup.recipeGroupIDs.ContainsKey("Wood"))
        {
            int index = RecipeGroup.recipeGroupIDs["Wood"];
            RecipeGroup group0 = RecipeGroup.recipeGroups[index];
            group0.ValidItems.Add(ModContent.ItemType<DarkMatterWood>());
            group0.ValidItems.Add(ModContent.ItemType<Coughwood>());
            group0.ValidItems.Add(ModContent.ItemType<TropicalWood>());
        }

        var groupWings = new RecipeGroup(() => "Any Wings", new int[]
        {
            ItemID.DemonWings,
            ItemID.AngelWings,
            ItemID.ButterflyWings,
            ItemID.FairyWings,
            ItemID.HarpyWings,
            ItemID.BoneWings,
            ItemID.FlameWings,
            ItemID.FrozenWings,
            ItemID.GhostWings,
            ItemID.LeafWings,
            ItemID.BatWings,
            ItemID.BeeWings,
            ItemID.TatteredFairyWings,
            ItemID.SpookyWings,
            ItemID.FestiveWings,
            ItemID.BeetleWings,
            ItemID.FinWings,
            ItemID.FishronWings,
            ItemID.WingsNebula,
            ItemID.WingsSolar,
            ItemID.WingsStardust,
            ItemID.WingsVortex,
            ItemID.FinWings,
            ItemID.MothronWings,
            ItemID.BetsyWings,
            ItemID.SteampunkWings,
            ModContent.ItemType<ContagionWings>(),
            ModContent.ItemType<CrimsonWings>(),
            ModContent.ItemType<CorruptionWings>(),
            ModContent.ItemType<HolyWings>(),
            ModContent.ItemType<EtherealWings>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Wings", groupWings);
        var groupWorkBenches = new RecipeGroup(() => "Any Work Bench", new int[]
        {
            ItemID.WorkBench,
            ItemID.EbonwoodWorkBench,
            ItemID.BlueDungeonWorkBench,
            ItemID.SteampunkWorkBench,
            ItemID.SpookyWorkBench,
            ItemID.SlimeWorkBench,
            ItemID.SkywareWorkbench,
            ItemID.ShadewoodWorkBench,
            ItemID.RichMahoganyWorkBench,
            ItemID.PumpkinWorkBench,
            ItemID.PinkDungeonWorkBench,
            ItemID.PearlwoodWorkBench,
            ItemID.PalmWoodWorkBench,
            ItemID.ObsidianWorkBench,
            ItemID.MushroomWorkBench,
            ItemID.MeteoriteWorkBench,
            ItemID.MartianWorkBench,
            ItemID.MarbleWorkBench,
            ItemID.LivingWoodWorkBench,
            ItemID.LihzahrdWorkBench,
            ItemID.HoneyWorkBench,
            ItemID.GreenDungeonWorkBench,
            ItemID.GraniteWorkBench,
            ItemID.GoldenWorkbench,
            ItemID.GlassWorkBench,
            ItemID.FrozenWorkBench,
            ItemID.FleshWorkBench,
            ItemID.DynastyWorkBench,
            ItemID.CrystalWorkbench,
            ItemID.CactusWorkBench,
            ItemID.BorealWoodWorkBench,
            ItemID.BoneWorkBench,
            ItemID.GothicWorkBench,
            ModContent.ItemType<Items.Placeable.Crafting.CoughwoodWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.DarkSlimeWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.HeartstoneWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.OrangeDungeonWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.ResistantWoodWorkBench>(),
            ModContent.ItemType<Items.Placeable.Crafting.VertebraeWorkBench>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:WorkBenches", groupWorkBenches);

        var groupHerbs = new RecipeGroup(() => "Any Herb", new int[]
        {
            ItemID.Blinkroot,
            ItemID.Fireblossom,
            ItemID.Deathweed,
            ItemID.Shiverthorn,
            ItemID.Waterleaf,
            ItemID.Moonglow,
            ItemID.Daybloom,
            ModContent.ItemType<Bloodberry>(),
            ModContent.ItemType<Sweetstem>(),
            ModContent.ItemType<Barfbush>(),
            ModContent.ItemType<Holybird>(),
            //ModContent.ItemType<Items.TwilightPlume>(),
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Herbs", groupHerbs);

        var groupTier1Watch = new RecipeGroup(() => "Any Copper Watch", new int[]
        {
            ItemID.CopperWatch,
            ItemID.TinWatch,
            ModContent.ItemType<BronzeWatch>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Tier1Watch", groupTier1Watch);

        var groupTier2Watch = new RecipeGroup(() => "Any Silver Watch", new int[]
        {
            ItemID.SilverWatch,
            ItemID.TungstenWatch,
            ModContent.ItemType<ZincWatch>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Tier2Watch", groupTier2Watch);

        var groupTier3Watch = new RecipeGroup(() => "Any Gold Watch", new int[]
        {
            ItemID.GoldWatch,
            ItemID.PlatinumWatch,
            ModContent.ItemType<BismuthWatch>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Tier3Watch", groupTier3Watch);

        var groupGoldBar = new RecipeGroup(() => "Any Gold Bar", new int[]
        {
            ItemID.GoldBar,
            ItemID.PlatinumBar,
            ModContent.ItemType<BismuthBar>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:GoldBar", groupGoldBar);

        if (RecipeGroup.recipeGroupIDs.ContainsKey("IronBar"))
        {
            int index = RecipeGroup.recipeGroupIDs["IronBar"];
            RecipeGroup groupWood = RecipeGroup.recipeGroups[index];
            groupWood.ValidItems.Add(ModContent.ItemType<NickelBar>());
        }

        var groupCopperBar = new RecipeGroup(() => "Any Copper Bar", new int[]
        {
            ItemID.CopperBar,
            ItemID.TinBar,
            ModContent.ItemType<BronzeBar>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:CopperBar", groupCopperBar);

        var groupSilverBar = new RecipeGroup(() => "Any Silver Bar", new int[]
        {
            ItemID.SilverBar,
            ItemID.TungstenBar,
            ModContent.ItemType<ZincBar>()
        });
        RecipeGroup.RegisterGroup("ExxoAvalonOrigins:SilverBar", groupSilverBar);
    }

    public override void AddRecipes()
    {
        RecipeChanger.ChangeRecipes();
        RecipeCreator.CreateRecipes(this);
        VanillaItemRecipeCreator.CreateRecipes(this);
        Mod imkTokensMod = ModLoader.GetMod("imkSushisMod");
        if (imkTokensMod != null)
        {
            ExxoAvalonOriginsGlobalNPC.imkCompat = true;
            SushiRecipes.CreateRecipes(Mod, imkTokensMod);
        }
    }

    public static Vector2 LavaCollision(Vector2 position, Vector2 velocity, int width, int height, bool fallThrough = false)
    {
        Vector2 result = velocity;
        Vector2 vector = position + velocity;
        Vector2 vector2 = position;
        int num = (int)(position.X / 16f) - 1;
        int num2 = (int)((position.X + width) / 16f) + 2;
        int num3 = (int)(position.Y / 16f) - 1;
        int num4 = (int)((position.Y + height) / 16f) + 2;
        if (num < 0)
        {
            num = 0;
        }
        if (num2 > Main.maxTilesX)
        {
            num2 = Main.maxTilesX;
        }
        if (num3 < 0)
        {
            num3 = 0;
        }
        if (num4 > Main.maxTilesY)
        {
            num4 = Main.maxTilesY;
        }
        for (int i = num; i < num2; i++)
        {
            for (int j = num3; j < num4; j++)
            {
                if (Main.tile[i, j]?.liquid > 0 && Main.tile[i, j - 1].LiquidAmount == 0 && Main.tile[i, j].LiquidType == LiquidID.Lava)
                {
                    int num5 = (Main.tile[i, j].LiquidAmount / 32 * 2) + 2;
                    Vector2 vector3;
                    vector3.X = i * 16;
                    vector3.Y = (j * 16) + 16 - num5;
                    if (vector.X + width > vector3.X && vector.X < vector3.X + 16f && vector.Y + height > vector3.Y && vector.Y < vector3.Y + num5 && vector2.Y + height <= vector3.Y && !fallThrough)
                    {
                        result.Y = vector3.Y - (vector2.Y + height);
                    }
                }
            }
        }
        return result;
    }

    public static Rectangle NewRectVector2(Vector2 v, Vector2 wH)
    {
        return new Rectangle((int)v.X, (int)v.Y, (int)wH.X, (int)wH.Y);
    }

    public static void StopRain()
    {
        Main.rainTime = 0;
        Main.raining = false;
        Main.maxRaining = 0f;
    }

    public static void StartRain()
    {
        const int num = 86400;
        const int num2 = num / 24;
        Main.rainTime = Main.rand.Next(num2 * 8, num);
        if (Main.rand.Next(3) == 0)
        {
            Main.rainTime += Main.rand.Next(0, num2);
        }
        if (Main.rand.Next(4) == 0)
        {
            Main.rainTime += Main.rand.Next(0, num2 * 2);
        }
        if (Main.rand.Next(5) == 0)
        {
            Main.rainTime += Main.rand.Next(0, num2 * 2);
        }
        if (Main.rand.Next(6) == 0)
        {
            Main.rainTime += Main.rand.Next(0, num2 * 3);
        }
        if (Main.rand.Next(7) == 0)
        {
            Main.rainTime += Main.rand.Next(0, num2 * 4);
        }
        if (Main.rand.Next(8) == 0)
        {
            Main.rainTime += Main.rand.Next(0, num2 * 5);
        }
        float num3 = 1f;
        if (Main.rand.Next(2) == 0)
        {
            num3 += 0.05f;
        }
        if (Main.rand.Next(3) == 0)
        {
            num3 += 0.1f;
        }
        if (Main.rand.Next(4) == 0)
        {
            num3 += 0.15f;
        }
        if (Main.rand.Next(5) == 0)
        {
            num3 += 0.2f;
        }
        Main.rainTime = (int)(Main.rainTime * num3);
        ChangeRain();
        Main.raining = true;
    }

    public static void ChangeRain()
    {
        if (Main.cloudBGActive >= 1f || Main.numClouds > 150.0)
        {
            if (Main.rand.Next(3) == 0)
            {
                Main.maxRaining = Main.rand.Next(20, 90) * 0.01f;
                return;
            }
            Main.maxRaining = Main.rand.Next(40, 90) * 0.01f;
        }
        else if (Main.numClouds > 100.0)
        {
            if (Main.rand.Next(3) == 0)
            {
                Main.maxRaining = Main.rand.Next(10, 70) * 0.01f;
                return;
            }
            Main.maxRaining = Main.rand.Next(20, 60) * 0.01f;
            return;
        }
        else
        {
            if (Main.rand.Next(3) == 0)
            {
                Main.maxRaining = Main.rand.Next(5, 40) * 0.01f;
                return;
            }
            Main.maxRaining = Main.rand.Next(5, 30) * 0.01f;
        }
    }

    public static Rectangle GetDims(string loc)
    {
        if (Main.netMode == NetmodeID.Server)
        {
            return new Rectangle(0, 0, 1, 1);
        }

        return Mod.Assets.Request<Texture2D>(loc).Value.Bounds;
    }

    public enum Similarity
    {
        None,
        Same,
        Merge
    }

    public static Similarity GetSimilarity(Tile check, int myType, int mergeType)
    {
        if (check?.HasTile != true)
        {
            return Similarity.None;
        }
        if (check.TileType == myType || Main.tileMerge[myType][check.TileType])
        {
            return Similarity.Same;
        }
        if (check.TileType == mergeType)
        {
            return Similarity.Merge;
        }
        return Similarity.None;
    }

    public static void MergeWith(int type1, int type2, bool merge = true)
    {
        if (type1 != type2)
        {
            Main.tileMerge[type1][type2] = merge;
            Main.tileMerge[type2][type1] = merge;
        }
    }

    private static void SetFrame(int x, int y, int frameX, int frameY)
    {
        Tile tile = Main.tile[x, y];
        if (tile != null)
        {
            tile.TileFrameX = (short)frameX;
            tile.TileFrameY = (short)frameY;
        }
    }

    public static void MergeWithFrameExplicit(int x, int y, int myType, int mergeType, out bool mergedUp, out bool mergedLeft, out bool mergedRight, out bool mergedDown, bool forceSameDown = false, bool forceSameUp = false, bool forceSameLeft = false, bool forceSameRight = false, bool resetFrame = true)
    {
        if (Main.tile[x, y] == null || x < 0 || x >= Main.maxTilesX || y < 0 || y >= Main.maxTilesY)
        {
            mergedUp = (mergedLeft = (mergedRight = (mergedDown = false)));
            return;
        }
        Main.tileMerge[myType][mergeType] = false;
        Tile tileLeft = Main.tile[x - 1, y];
        Tile tileRight = Main.tile[x + 1, y];
        Tile tileUp = Main.tile[x, y - 1];
        Tile tileDown = Main.tile[x, y + 1];
        Tile tileTopLeft = Main.tile[x - 1, y - 1];
        Tile tileTopRight = Main.tile[x + 1, y - 1];
        Tile tileBottomLeft = Main.tile[x - 1, y + 1];
        Tile check = Main.tile[x + 1, y + 1];
        Similarity leftSim = ((!forceSameLeft) ? GetSimilarity(tileLeft, myType, mergeType) : Similarity.Same);
        Similarity rightSim = ((!forceSameRight) ? GetSimilarity(tileRight, myType, mergeType) : Similarity.Same);
        Similarity upSim = ((!forceSameUp) ? GetSimilarity(tileUp, myType, mergeType) : Similarity.Same);
        Similarity downSim = ((!forceSameDown) ? GetSimilarity(tileDown, myType, mergeType) : Similarity.Same);
        Similarity topLeftSim = GetSimilarity(tileTopLeft, myType, mergeType);
        Similarity topRightSim = GetSimilarity(tileTopRight, myType, mergeType);
        Similarity bottomLeftSim = GetSimilarity(tileBottomLeft, myType, mergeType);
        Similarity bottomRightSim = GetSimilarity(check, myType, mergeType);
        int randomFrame;
        if (resetFrame)
        {
            randomFrame = WorldGen.genRand.Next(3);
            Main.tile[x, y].TileFrameNumber = (byte)randomFrame;
        }
        else
        {
            randomFrame = Main.tile[x, y].TileFrameNumber;
        }
        mergedDown = (mergedLeft = (mergedRight = (mergedUp = false)));
        switch (leftSim)
        {
            case Similarity.None:
                switch (upSim)
                {
                    case Similarity.Same:
                        switch (downSim)
                        {
                            case Similarity.Same:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        SetFrame(x, y, 0, 18 * randomFrame);
                                        break;

                                    case Similarity.Merge:
                                        mergedRight = true;
                                        SetFrame(x, y, 234 + (18 * randomFrame), 36);
                                        break;

                                    default:
                                        SetFrame(x, y, 90, 18 * randomFrame);
                                        break;
                                }
                                break;

                            case Similarity.Merge:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        mergedDown = true;
                                        SetFrame(x, y, 72, 90 + (18 * randomFrame));
                                        break;

                                    case Similarity.Merge:
                                        SetFrame(x, y, 108 + (18 * randomFrame), 54);
                                        break;

                                    default:
                                        mergedDown = true;
                                        SetFrame(x, y, 126, 90 + (18 * randomFrame));
                                        break;
                                }
                                break;

                            default:
                                if (rightSim == Similarity.Same)
                                {
                                    SetFrame(x, y, 36 * randomFrame, 72);
                                }
                                else
                                {
                                    SetFrame(x, y, 108 + (18 * randomFrame), 54);
                                }
                                break;
                        }
                        break;

                    case Similarity.Merge:
                        switch (downSim)
                        {
                            case Similarity.Same:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        mergedUp = true;
                                        SetFrame(x, y, 72, 144 + (18 * randomFrame));
                                        break;

                                    case Similarity.Merge:
                                        SetFrame(x, y, 108 + (18 * randomFrame), 0);
                                        break;

                                    default:
                                        mergedUp = true;
                                        SetFrame(x, y, 126, 144 + (18 * randomFrame));
                                        break;
                                }
                                break;

                            case Similarity.Merge:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        SetFrame(x, y, 162, 18 * randomFrame);
                                        break;

                                    case Similarity.Merge:
                                        SetFrame(x, y, 162 + (18 * randomFrame), 54);
                                        break;

                                    default:
                                        mergedUp = true;
                                        mergedDown = true;
                                        SetFrame(x, y, 108, 216 + (18 * randomFrame));
                                        break;
                                }
                                break;

                            default:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        SetFrame(x, y, 162, 18 * randomFrame);
                                        break;

                                    case Similarity.Merge:
                                        SetFrame(x, y, 162 + (18 * randomFrame), 54);
                                        break;

                                    default:
                                        mergedUp = true;
                                        SetFrame(x, y, 108, 144 + (18 * randomFrame));
                                        break;
                                }
                                break;
                        }
                        break;

                    default:
                        switch (downSim)
                        {
                            case Similarity.Same:
                                if (rightSim == Similarity.Same)
                                {
                                    SetFrame(x, y, 36 * randomFrame, 54);
                                    break;
                                }
                                _ = 1;
                                SetFrame(x, y, 108 + (18 * randomFrame), 0);
                                break;

                            case Similarity.Merge:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        SetFrame(x, y, 162, 18 * randomFrame);
                                        break;

                                    case Similarity.Merge:
                                        SetFrame(x, y, 162 + (18 * randomFrame), 54);
                                        break;

                                    default:
                                        mergedDown = true;
                                        SetFrame(x, y, 108, 90 + (18 * randomFrame));
                                        break;
                                }
                                break;

                            default:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        SetFrame(x, y, 162, 18 * randomFrame);
                                        break;

                                    case Similarity.Merge:
                                        mergedRight = true;
                                        SetFrame(x, y, 54 + (18 * randomFrame), 234);
                                        break;

                                    default:
                                        SetFrame(x, y, 162 + (18 * randomFrame), 54);
                                        break;
                                }
                                break;
                        }
                        break;
                }
                return;

            case Similarity.Merge:
                switch (upSim)
                {
                    case Similarity.Same:
                        switch (downSim)
                        {
                            case Similarity.Same:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        mergedLeft = true;
                                        SetFrame(x, y, 162, 126 + (18 * randomFrame));
                                        break;

                                    case Similarity.Merge:
                                        mergedLeft = true;
                                        mergedRight = true;
                                        SetFrame(x, y, 180, 126 + (18 * randomFrame));
                                        break;

                                    default:
                                        mergedLeft = true;
                                        SetFrame(x, y, 234 + (18 * randomFrame), 54);
                                        break;
                                }
                                break;

                            case Similarity.Merge:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        mergedLeft = (mergedDown = true);
                                        SetFrame(x, y, 36, 108 + (36 * randomFrame));
                                        break;

                                    case Similarity.Merge:
                                        mergedLeft = (mergedRight = (mergedDown = true));
                                        SetFrame(x, y, 198, 144 + (18 * randomFrame));
                                        break;

                                    default:
                                        SetFrame(x, y, 108 + (18 * randomFrame), 54);
                                        break;
                                }
                                break;

                            default:
                                if (rightSim == Similarity.Same)
                                {
                                    mergedLeft = true;
                                    SetFrame(x, y, 18 * randomFrame, 216);
                                }
                                else
                                {
                                    SetFrame(x, y, 108 + (18 * randomFrame), 54);
                                }
                                break;
                        }
                        break;

                    case Similarity.Merge:
                        switch (downSim)
                        {
                            case Similarity.Same:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        mergedUp = (mergedLeft = true);
                                        SetFrame(x, y, 36, 90 + (36 * randomFrame));
                                        break;

                                    case Similarity.Merge:
                                        mergedLeft = (mergedRight = (mergedUp = true));
                                        SetFrame(x, y, 198, 90 + (18 * randomFrame));
                                        break;

                                    default:
                                        SetFrame(x, y, 108 + (18 * randomFrame), 0);
                                        break;
                                }
                                break;

                            case Similarity.Merge:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        mergedUp = (mergedLeft = (mergedDown = true));
                                        SetFrame(x, y, 216, 90 + (18 * randomFrame));
                                        break;

                                    case Similarity.Merge:
                                        mergedDown = (mergedLeft = (mergedRight = (mergedUp = true)));
                                        SetFrame(x, y, 108 + (18 * randomFrame), 198);
                                        break;

                                    default:
                                        SetFrame(x, y, 162 + (18 * randomFrame), 54);
                                        break;
                                }
                                break;

                            default:
                                if (rightSim == Similarity.Same)
                                {
                                    SetFrame(x, y, 162, 18 * randomFrame);
                                }
                                else
                                {
                                    SetFrame(x, y, 162 + (18 * randomFrame), 54);
                                }
                                break;
                        }
                        break;

                    default:
                        switch (downSim)
                        {
                            case Similarity.Same:
                                if (rightSim == Similarity.Same)
                                {
                                    mergedLeft = true;
                                    SetFrame(x, y, 18 * randomFrame, 198);
                                }
                                else
                                {
                                    _ = 1;
                                    SetFrame(x, y, 108 + (18 * randomFrame), 0);
                                }
                                break;

                            case Similarity.Merge:
                                if (rightSim == Similarity.Same)
                                {
                                    SetFrame(x, y, 162, 18 * randomFrame);
                                    break;
                                }
                                _ = 1;
                                SetFrame(x, y, 162 + (18 * randomFrame), 54);
                                break;

                            default:
                                switch (rightSim)
                                {
                                    case Similarity.Same:
                                        mergedLeft = true;
                                        SetFrame(x, y, 18 * randomFrame, 252);
                                        break;

                                    case Similarity.Merge:
                                        mergedRight = (mergedLeft = true);
                                        SetFrame(x, y, 162 + (18 * randomFrame), 198);
                                        break;

                                    default:
                                        mergedLeft = true;
                                        SetFrame(x, y, 18 * randomFrame, 234);
                                        break;
                                }
                                break;
                        }
                        break;
                }
                return;
        }
        switch (upSim)
        {
            case Similarity.Same:
                switch (downSim)
                {
                    case Similarity.Same:
                        switch (rightSim)
                        {
                            case Similarity.Same:
                                if (topLeftSim == Similarity.Merge || topRightSim == Similarity.Merge || bottomLeftSim == Similarity.Merge || bottomRightSim == Similarity.Merge)
                                {
                                    if (bottomRightSim == Similarity.Merge)
                                    {
                                        SetFrame(x, y, 0, 90 + (36 * randomFrame));
                                    }
                                    else if (bottomLeftSim == Similarity.Merge)
                                    {
                                        SetFrame(x, y, 18, 90 + (36 * randomFrame));
                                    }
                                    else if (topRightSim == Similarity.Merge)
                                    {
                                        SetFrame(x, y, 0, 108 + (36 * randomFrame));
                                    }
                                    else
                                    {
                                        SetFrame(x, y, 18, 108 + (36 * randomFrame));
                                    }
                                    break;
                                }
                                switch (topLeftSim)
                                {
                                    case Similarity.Same:
                                        if (topRightSim == Similarity.Same)
                                        {
                                            if (bottomLeftSim == Similarity.Same)
                                            {
                                                SetFrame(x, y, 18 + (18 * randomFrame), 18);
                                            }
                                            else if (bottomRightSim == Similarity.Same)
                                            {
                                                SetFrame(x, y, 18 + (18 * randomFrame), 18);
                                            }
                                            else
                                            {
                                                SetFrame(x, y, 108 + (18 * randomFrame), 36);
                                            }
                                            return;
                                        }
                                        if (bottomLeftSim != 0)
                                        {
                                            break;
                                        }
                                        if (bottomRightSim == Similarity.Same)
                                        {
                                            if (topRightSim == Similarity.Merge)
                                            {
                                                SetFrame(x, y, 0, 108 + (36 * randomFrame));
                                            }
                                            else
                                            {
                                                SetFrame(x, y, 18 + (18 * randomFrame), 18);
                                            }
                                        }
                                        else
                                        {
                                            SetFrame(x, y, 198, 18 * randomFrame);
                                        }
                                        return;

                                    case Similarity.None:
                                        if (topRightSim == Similarity.Same)
                                        {
                                            if (bottomRightSim == Similarity.Same)
                                            {
                                                SetFrame(x, y, 18 + (18 * randomFrame), 18);
                                            }
                                            else
                                            {
                                                SetFrame(x, y, 18 + (18 * randomFrame), 18);
                                            }
                                        }
                                        else
                                        {
                                            SetFrame(x, y, 18 + (18 * randomFrame), 18);
                                        }
                                        return;
                                }
                                SetFrame(x, y, 18 + (18 * randomFrame), 18);
                                break;

                            case Similarity.Merge:
                                mergedRight = true;
                                SetFrame(x, y, 144, 126 + (18 * randomFrame));
                                break;

                            default:
                                SetFrame(x, y, 72, 18 * randomFrame);
                                break;
                        }
                        break;

                    case Similarity.Merge:
                        switch (rightSim)
                        {
                            case Similarity.Same:
                                mergedDown = true;
                                SetFrame(x, y, 144 + (18 * randomFrame), 90);
                                break;

                            case Similarity.Merge:
                                mergedDown = (mergedRight = true);
                                SetFrame(x, y, 54, 108 + (36 * randomFrame));
                                break;

                            default:
                                mergedDown = true;
                                SetFrame(x, y, 90, 90 + (18 * randomFrame));
                                break;
                        }
                        break;

                    default:
                        switch (rightSim)
                        {
                            case Similarity.Same:
                                SetFrame(x, y, 18 + (18 * randomFrame), 36);
                                break;

                            case Similarity.Merge:
                                mergedRight = true;
                                SetFrame(x, y, 54 + (18 * randomFrame), 216);
                                break;

                            default:
                                SetFrame(x, y, 18 + (36 * randomFrame), 72);
                                break;
                        }
                        break;
                }
                return;

            case Similarity.Merge:
                switch (downSim)
                {
                    case Similarity.Same:
                        switch (rightSim)
                        {
                            case Similarity.Same:
                                mergedUp = true;
                                SetFrame(x, y, 144 + (18 * randomFrame), 108);
                                break;

                            case Similarity.Merge:
                                mergedRight = (mergedUp = true);
                                SetFrame(x, y, 54, 90 + (36 * randomFrame));
                                break;

                            default:
                                mergedUp = true;
                                SetFrame(x, y, 90, 144 + (18 * randomFrame));
                                break;
                        }
                        break;

                    case Similarity.Merge:
                        switch (rightSim)
                        {
                            case Similarity.Same:
                                mergedUp = (mergedDown = true);
                                SetFrame(x, y, 144 + (18 * randomFrame), 180);
                                break;

                            case Similarity.Merge:
                                mergedUp = (mergedRight = (mergedDown = true));
                                SetFrame(x, y, 216, 144 + (18 * randomFrame));
                                break;

                            default:
                                SetFrame(x, y, 216, 18 * randomFrame);
                                break;
                        }
                        break;

                    default:
                        if (rightSim == Similarity.Same)
                        {
                            mergedUp = true;
                            SetFrame(x, y, 234 + (18 * randomFrame), 18);
                        }
                        else
                        {
                            SetFrame(x, y, 216, 18 * randomFrame);
                        }
                        break;
                }
                return;
        }
        switch (downSim)
        {
            case Similarity.Same:
                switch (rightSim)
                {
                    case Similarity.Same:
                        SetFrame(x, y, 18 + (18 * randomFrame), 0);
                        break;

                    case Similarity.Merge:
                        mergedRight = true;
                        SetFrame(x, y, 54 + (18 * randomFrame), 198);
                        break;

                    default:
                        SetFrame(x, y, 18 + (36 * randomFrame), 54);
                        break;
                }
                break;

            case Similarity.Merge:
                if (rightSim == Similarity.Same)
                {
                    mergedDown = true;
                    SetFrame(x, y, 234 + (18 * randomFrame), 0);
                }
                else
                {
                    SetFrame(x, y, 216, 18 * randomFrame);
                }
                break;

            default:
                switch (rightSim)
                {
                    case Similarity.Same:
                        SetFrame(x, y, 108 + (18 * randomFrame), 72);
                        break;

                    case Similarity.Merge:
                        mergedRight = true;
                        SetFrame(x, y, 54 + (18 * randomFrame), 252);
                        break;

                    default:
                        SetFrame(x, y, 216, 18 * randomFrame);
                        break;
                }
                break;
        }
    }

    public static void MergeWithFrame(int x, int y, int myType, int mergeType, bool forceSameDown = false, bool forceSameUp = false, bool forceSameLeft = false, bool forceSameRight = false, bool resetFrame = true)
    {
        MergeWithFrameExplicit(x, y, myType, mergeType, out _, out _, out _, out _, forceSameDown, forceSameUp, forceSameLeft, forceSameRight, resetFrame);
    }

    public override object Call(params object[] args)
    {
        return ExxoAvalonOriginsCall.Call(args);
    }
}
