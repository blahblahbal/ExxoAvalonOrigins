using Terraria;using Terraria.ModLoader;using Terraria.ID;using System.Collections.Generic;using Microsoft.Xna.Framework;using Microsoft.Xna.Framework.Graphics;using System;using Terraria.UI;using ExxoAvalonOrigins.UI;using System.Security.Cryptography;using System.Text;using System.IO;using Terraria.IO;namespace ExxoAvalonOrigins{    class ExxoAvalonOrigins : Mod    {        public static bool devMode = true; //TODO: Disable dev mode for release                public static bool godMode = false;        //public static int[] minPick = new int[Main.maxTileSets];        public static ModHotKey shadowHotkey;        public static ModHotKey sprintHotkey;        public static ModHotKey dashHotkey;        public static ModHotKey quintupleHotkey;        public static ModHotKey swimHotkey;        public static ModHotKey wallSlideHotkey;        public static ModHotKey bubbleBoostHotkey;        public static ModHotKey accDrillModeHotkey;        public static ModHotKey mirrorModeHotkey;        public static ModHotKey astralHotkey;        public static ModHotKey minionGuidingHotkey;        public static bool armaRO = false;        public static int dungeonEx = 0; //TODO: implement X catch in worldgen        public static int jungleEx = 0; //TODO: implement X catch in worldgen        public static bool superHardmode;        public static Texture2D BeamVTexture;        public static Texture2D BeamStartTexture;        public static Texture2D BeamEndTexture;        public static Texture2D wosTexture;        public static Texture2D mechaHungryChainTexture;        public static Texture2D[] lavaMermanTextures = new Texture2D[5];        public static Texture2D[] originalMermanTextures = new Texture2D[5];
        //public static Texture2D impTreeTexture;
        public static readonly Version version = new Version(0, 9, 4, 0);        public static Version lastOpenedVersion = null;        public static Texture2D heart3Texture;        public static Texture2D mana2Texture;        public static Texture2D mana3Texture;        public static Texture2D mana4Texture;        public static Texture2D mana5Texture;        public static Texture2D mana6Texture;        public static Texture2D stamTexture;        public static Texture2D tomeSlotBackgroundTexture;        public static Texture2D herbButtonTexture;        private UserInterface tomeSlotUserInterface;        private UserInterface herbologyUserInterface;        public int royStyle;
        public static int royG = 0;        public int gbvStyle;
        public static int gbvR = 160;
        public static int gbvG = 0;
        public static int gbvB = 0;        public static Item herbItem;        public static string[] herbNames = new string[10] { "Daybloom", "Moonglow", "Blinkroot", "Deathweed", "Waterleaf", "Fireblossom", "Shiverthorn", "Bloodberry", "Sweetstem", "Barfbush" };        public static string[] potionNames = new string[54]
        {
            "Obsidian Skin",
            "Regeneration",
            "Swiftness",
            "Gills",
            "Ironskin",
            "Mana Regeneration",
            "Magic Power",
            "Featherfall",
            "Spelunker",
            "Invisibility",
            "Shine",
            "Night Owl",
            "Battle",
            "Thorns",
            "Water Walking",
            "Archery",
            "Hunter",
            "Gravitation",
            "Mining",
            "Heartreach",
            "Calming",
            "Builder",
            "Titan",
            "Flipper",
            "Summoning",
            "Dangersense",
            "Ammo Reservation",
            "Lifeforce",
            "Endurance",
            "Rage",
            "Inferno",
            "Wrath",
            "Fishing",
            "Sonar",
            "Crate",
            "Warmth",
            "Crimson",
            "Shockwave",
            "Luck",
            "Blood Cast",
            "Starbright",
            "Vision",
            "Strength",
            "GPS",
            "Time Shift",
            "Shadow",
            "Rogue",
            "Gauntlet",
            "Wisdom",
            "Titanskin",
            "Invincibility",
            "Force Field",
            "Fury",
            "Magnet"
        };        public static List<int> beams = new List<int>()
        {
            TileID.WoodenBeam,
            ModContent.TileType<Tiles.BorealWoodBeam>(),
            ModContent.TileType<Tiles.PearlwoodBeam>(),
            ModContent.TileType<Tiles.ChunkstoneColumn>(),
            ModContent.TileType<Tiles.PearlstoneColumn>(),
            ModContent.TileType<Tiles.CrimstoneColumn>(),
            ModContent.TileType<Tiles.EbonstoneColumn>(),
            ModContent.TileType<Tiles.EbonwoodBeam>(),
            ModContent.TileType<Tiles.SandstoneColumn>(),
            ModContent.TileType<Tiles.CoughwoodBeam>(),
            ModContent.TileType<Tiles.RichMahoganyBeam>(),
            ModContent.TileType<Tiles.ShadewoodBeam>()
        };        internal TomeSlot tomeSlot;        internal HerbologyBenchUI herbology;        public static bool subInterface = false;        public static int barStamina = 20;        public static int sX = Main.screenWidth - 800;        public static ExxoAvalonOrigins mod;        public ExxoAvalonOrigins()        {            mod = this;        }        public override void Load()        {            //Validate();            if (!Main.dedServ)            {                Mod musicMod = ModLoader.GetMod("AvalonMusic");                if (musicMod != null)
                {
                    AddMusicBox(musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Contagion"), ItemType("MusicBoxContagion"), TileType("MusicBoxes"));
                    AddMusicBox(musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/BacteriumPrime"), ItemType("MusicBoxBacteriumPrime"), TileType("MusicBoxes"), 36);
                    AddMusicBox(musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/ArmageddonSlime"), ItemType("MusicBoxArmageddonSlime"), TileType("MusicBoxes"), 36 * 2);
                    AddMusicBox(musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/DesertBeak"), ItemType("MusicBoxDesertBeak"), TileType("MusicBoxes"), 36 * 3);
                    AddMusicBox(musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/UndergroundContagion"), ItemType("MusicBoxUndergroundContagion"), TileType("MusicBoxes"), 36 * 4);
                    AddMusicBox(musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Tropics"), ItemType("MusicBoxTropics"), TileType("MusicBoxes"), 36 * 5);
                    AddMusicBox(musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Phantasm"), ItemType("MusicBoxPhantasm"), TileType("MusicBoxes"), 36 * 6);
                }                                Main.tileTexture[91] = GetTexture("Sprites/VanillaBanners");                Main.tileTexture[21] = GetTexture("Sprites/VanillaChests");                Main.logoTexture = GetTexture("Sprites/EAOLogo");                Main.logo2Texture = GetTexture("Sprites/EAOLogo");                Main.itemTexture[ItemID.HallowedKey] = GetTexture("Sprites/HallowedKey");                Main.tileTexture[TileID.CopperCoinPile] = GetTexture("Sprites/CopperCoin");                Main.tileTexture[TileID.SilverCoinPile] = GetTexture("Sprites/SilverCoin");                Main.tileTexture[TileID.GoldCoinPile] = GetTexture("Sprites/GoldCoin");                Main.tileTexture[TileID.PlatinumCoinPile] = GetTexture("Sprites/PlatinumCoin");                Main.itemTexture[ItemID.PaladinBanner] = GetTexture("Sprites/PaladinBanner");                Main.itemTexture[ItemID.PossessedArmorBanner] = GetTexture("Sprites/PossessedArmorBanner");                Main.itemTexture[ItemID.BoneLeeBanner] = GetTexture("Sprites/BoneLeeBanner");                Main.itemTexture[ItemID.AngryTrapperBanner] = GetTexture("Sprites/AngryTrapperBanner");                Main.itemTexture[ItemID.Deathweed] = GetTexture("Sprites/Deathweed");                Main.itemTexture[ItemID.WaterleafSeeds] = GetTexture("Sprites/WaterleafSeeds");                lavaMermanTextures[0] = GetTexture("Sprites/LavaMerman_Head");                lavaMermanTextures[1] = GetTexture("Sprites/LavaMerman_Body");                lavaMermanTextures[2] = GetTexture("Sprites/LavaMerman_Arms");                lavaMermanTextures[3] = GetTexture("Sprites/LavaMerman_FemaleBody");                lavaMermanTextures[4] = GetTexture("Sprites/LavaMerman_Legs");                originalMermanTextures[0] = GetTexture("Sprites/Armor_Head_39");                originalMermanTextures[1] = GetTexture("Sprites/Armor_Body_22");                originalMermanTextures[2] = GetTexture("Sprites/Armor_Arm_22");                originalMermanTextures[3] = GetTexture("Sprites/Female_Body_22");                originalMermanTextures[4] = GetTexture("Sprites/Armor_Legs_21");                heart3Texture = GetTexture("Sprites/Heart3");                mana2Texture = GetTexture("Sprites/Mana2");                mana3Texture = GetTexture("Sprites/Mana3");                mana4Texture = GetTexture("Sprites/Mana4");                mana5Texture = GetTexture("Sprites/Mana5");                mana6Texture = GetTexture("Sprites/Mana6");                stamTexture = GetTexture("Sprites/Stamina");                BeamVTexture = GetTexture("Sprites/BeamVenoshock");                BeamStartTexture = GetTexture("Sprites/BeamStart");                BeamEndTexture = GetTexture("Sprites/BeamEnd");                wosTexture = GetTexture("Sprites/WallofSteel");                mechaHungryChainTexture = GetTexture("Sprites/MechaHungryChain");                tomeSlotBackgroundTexture = GetTexture("Sprites/TomeSlotBackground");                //impTreeTexture = GetTexture("Sprites/ResistantTree");                herbButtonTexture = GetTexture("Sprites/HerbButton");                shadowHotkey = RegisterHotKey("Shadow Teleport", "V");//implemented TODO: Fix implementation of hotkeys                sprintHotkey = RegisterHotKey("Toggle Sprinting", "F");//implemented?                dashHotkey = RegisterHotKey("Toggle Stamina Dash", "K");                quintupleHotkey = RegisterHotKey("Toggle Quintuple Jump", "RightControl");                swimHotkey = RegisterHotKey("Toggle Swimming", "L");//implemented?                wallSlideHotkey = RegisterHotKey("Toggle Wall Sliding", "G");                bubbleBoostHotkey = RegisterHotKey("Toggle Bubble Boost", "U");                accDrillModeHotkey = RegisterHotKey("Change Acceleration Drill Mode", "N");                mirrorModeHotkey = RegisterHotKey("Change Mirror Modes", "N");                astralHotkey = RegisterHotKey("Activate Astral Projecting", "OemPipe");                minionGuidingHotkey = RegisterHotKey("Ancient Minion Guiding", "MouseRight");                tomeSlot = new TomeSlot();                tomeSlot.Activate();                tomeSlotUserInterface = new UserInterface();                tomeSlotUserInterface.SetState(tomeSlot);                herbItem = new Item();                herbology = new HerbologyBenchUI();                herbology.Activate();                herbologyUserInterface = new UserInterface();                herbologyUserInterface.SetState(herbology);            }
            /*for (int i = 0; i < Main.maxTileSets; i++)            {                minPick[i] = 0;            }            minPick[211] = 200;            minPick[mod.TileType("ShroomiteOre")] = 205;            minPick[TileID.Ebonstone] = minPick[TileID.Crimstone] = minPick[TileID.Pearlstone] = minPick[mod.TileType("Chunkstone")] =            minPick[TileID.Obsidian] = minPick[mod.TileType("RhodiumOre")] = minPick[mod.TileType("OsmiumOre")] = 60;            minPick[TileID.Meteorite] = 50;            minPick[TileID.Demonite] = minPick[TileID.Crimtane] = minPick[mod.TileType("BacciliteOre")] = minPick[mod.TileType("Tourmaline")] = minPick[mod.TileType("Peridot")] = minPick[mod.TileType("Zircon")] = 55;            minPick[TileID.LihzahrdBrick] = minPick[TileID.LihzahrdAltar] = minPick[mod.TileType("TritanoriumOre")] = minPick[mod.TileType("PyroscoricOre")] = minPick[mod.TileType("SolariumOre")] = 210;            minPick[TileID.Hellstone] = 65;            minPick[TileID.Cobalt] = minPick[TileID.Palladium] = minPick[mod.TileType("DurataniumOre")] = 100;            minPick[mod.TileType("BlueLihzahrdBrick")] = 400;            minPick[mod.TileType("UnvolanditeOre")] = minPick[mod.TileType("VorazylcumOre")] = 250;            minPick[TileID.Mythril] = minPick[TileID.Orichalcum] = minPick[mod.TileType("NaquadahOre")] = 110;            minPick[TileID.Adamantite] = minPick[TileID.Titanium] = minPick[mod.TileType("TroxiniumOre")] = 150;            minPick[mod.TileType("SolariumShrine")] = 9999;            minPick[mod.TileType("CaesiumOre")] = minPick[mod.TileType("Opal")] = 200;            minPick[mod.TileType("OblivionOre")] = minPick[mod.TileType("HydrolythOre")] = 300;            minPick[mod.TileType("FeroziumOre")] = 180;*/
            if (devMode)                Debug.Debug.DebugHooks();            Hooks.Hooks.AddHooks();            Main.chTitle = true;            //AddAvalonAlts();        }        public override void Unload()        {            Main.logoTexture = Main.instance.OurLoad<Texture2D>("Images" + Path.DirectorySeparatorChar + "Logo");            Main.logo2Texture = Main.instance.OurLoad<Texture2D>("Images" + Path.DirectorySeparatorChar + "Logo2");            base.Unload();            Main.chTitle = true;        }        public ModPacket GetPacket(AvalonMessageID type, int capacity)
        {
            ModPacket packet = GetPacket(capacity + 1);
            packet.Write((byte)type);
            return packet;
        }

        public static ModPacket WriteToPacket(ModPacket packet, byte msg, params object[] param)
        {
            packet.Write(msg);

            for (int m = 0; m < param.Length; m++)
            {
                object obj = param[m];
                if (obj is bool) packet.Write((bool)obj);
                else
                if (obj is byte) packet.Write((byte)obj);
                else
                if (obj is int) packet.Write((int)obj);
                else
                if (obj is float) packet.Write((float)obj);
            }
            return packet;
        }        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            AvalonMessageID id = (AvalonMessageID)reader.ReadByte();
            switch (id)
            {
                case AvalonMessageID.ShadowTeleport:
                    ShadowTeleport.Teleport(reader.ReadInt32(), true, whoAmI);
                    break;
                case AvalonMessageID.PhantasmRelocate:
                    NPCs.Phantasm.Teleport(reader.ReadVector2(), true, whoAmI);
                    break;
            }
        }        public override void PostUpdateEverything()
        {
            if (royStyle == 0)
            {
                royG += 5;
                if (royG >= 255)
                {
                    royG = 255;
                    royStyle = 1;
                }
            }
            if (royStyle == 1)
            {
                royG -= 5;
                if (royG <= 0)
                {
                    royG = 0;
                    royStyle = 0;
                }
            }
            if (gbvStyle == 0)
            {
                gbvR -= 5;
                if (gbvR <= 0)
                {
                    gbvR = 0;
                    gbvStyle = 1;
                }
            }
            if (gbvStyle == 1)
            {
                gbvG += 5;
                if (gbvG >= 255)
                {
                    gbvG = 255;
                }
                if (gbvG >= 160)
                {
                    gbvB -= 5;
                    if (gbvB <= 0)
                    {
                        gbvB = 0;
                        gbvStyle = 2;
                    }
                }
            }
            if (gbvStyle == 2)
            {
                gbvG -= 5;
                if (gbvG <= 0)
                {
                    gbvG = 0;
                }
                if (gbvG <= 160)
                {
                    gbvB += 5;
                    if (gbvB >= 255)
                    {
                        gbvB = 255;
                        gbvStyle = 3;
                    }
                }
            }
            if (gbvStyle == 3)
            {
                gbvR += 5;
                if (gbvR >= 160)
                {
                    gbvR = 160;
                    gbvStyle = 0;
                }
            }
        }        public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
        {
            float ickyStrength = ExxoAvalonOriginsWorld.ickyTiles / 800f;
            ickyStrength = Math.Min(ickyStrength, 1f);
            if (ickyStrength <= 0) return;

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
        }        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            Mod musicMod = ModLoader.GetMod("AvalonMusic");
            if (Main.musicVolume == 0f || Main.myPlayer == -1 || Main.gameMenu) return;
            Terraria.Player player = Main.LocalPlayer;
            if (!player.active) return;
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneTropics)
            {
                if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Tropics");
                else music = MusicID.Jungle;
                priority = MusicPriority.BiomeMedium;
            }
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger)
            {
                if (Main.player[Main.myPlayer].position.Y > Main.worldSurface * 16.0 + (Main.screenHeight / 2))
                {
                    if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/UndergroundContagion");
                    else music = MusicID.UndergroundCrimson;
                    priority = MusicPriority.BiomeHigh;
                }
                else
                {
                    if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Contagion");
                    else music = MusicID.Crimson;
                    priority = MusicPriority.BiomeHigh;
                }
            }
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneHellcastle)
            {
                if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Hellcastle");
                else music = MusicID.Dungeon;
                priority = MusicPriority.Environment;
            }
            Rectangle rectangle = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
            int dist = 5000;
            bool phantasm = false;
            bool bactprime = false;
            bool desertbeak = false;
            bool wallofsteel = false;
            bool armageddon = false;
            foreach (NPC n in Main.npc)
            {
                if (n.type == ModContent.NPCType<NPCs.BacteriumPrime>() && n.active)
                {
                    Rectangle bact = new Rectangle((int)(n.position.X + (float)(n.width / 2)) - dist, (int)(n.position.Y + (float)(n.height / 2)) - dist, dist * 2, dist * 2);
                    if (bact.Intersects(rectangle))
                    {
                        bactprime = true;
                        break;
                    }
                }
                if (n.type == ModContent.NPCType<NPCs.Phantasm>() && n.active)
                {
                    Rectangle phant = new Rectangle((int)(n.position.X + (float)(n.width / 2)) - dist, (int)(n.position.Y + (float)(n.height / 2)) - dist, dist * 2, dist * 2);
                    if (phant.Intersects(rectangle))
                    {
                        phantasm = true;
                        break;
                    }
                }
                if (n.type == ModContent.NPCType<NPCs.DesertBeak>() && n.active)
                {
                    Rectangle db = new Rectangle((int)(n.position.X + (float)(n.width / 2)) - dist, (int)(n.position.Y + (float)(n.height / 2)) - dist, dist * 2, dist * 2);
                    if (db.Intersects(rectangle))
                    {
                        desertbeak = true;
                        break;
                    }
                }
                if (n.type == ModContent.NPCType<NPCs.WallofSteel>() && n.active)
                {
                    Rectangle wos = new Rectangle((int)(n.position.X + (float)(n.width / 2)) - dist, (int)(n.position.Y + (float)(n.height / 2)) - dist, dist * 2, dist * 2);
                    if (wos.Intersects(rectangle))
                    {
                        wallofsteel = true;
                        break;
                    }
                }
                if (n.type == ModContent.NPCType<NPCs.ArmageddonSlime>() && n.active)
                {
                    Rectangle arma = new Rectangle((int)(n.position.X + (float)(n.width / 2)) - dist, (int)(n.position.Y + (float)(n.height / 2)) - dist, dist * 2, dist * 2);
                    if (arma.Intersects(rectangle))
                    {
                        armageddon = true;
                        break;
                    }
                }
            }
            if (bactprime)
            {
                if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/BacteriumPrime");
                else music = MusicID.Boss3;
                priority = MusicPriority.BossLow;
            }
            if (desertbeak)
            {
                if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/DesertBeak");
                else music = MusicID.Boss4;
                priority = MusicPriority.BossLow;
            }
            if (phantasm)
            {
                if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/Phantasm");
                else music = MusicID.Boss3;
                priority = MusicPriority.BossLow;
            }
            if (wallofsteel)
            {
                music = MusicID.Boss2;
                priority = MusicPriority.BossLow;
            }
            if (armageddon)
            {
                if (musicMod != null) music = musicMod.GetSoundSlot(SoundType.Music, "Sounds/Music/ArmageddonSlime");
                else music = MusicID.Boss5;
                priority = MusicPriority.BossLow;
            }
        }

        public override void PostSetupContent()
        {
            #region BossChecklist
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                /*
                // Boss checklist documentation can be found here: https://github.com/JavidPack/BossChecklist/wiki/Support-using-Mod-Call

                // Vanilla boss progression floats:
                KingSlime = 1f;
                EyeOfCthulhu = 2f;
                EaterOfWorlds = 3f;
                QueenBee = 4f;
                Skeletron = 5f;
                WallOfFlesh = 6f;
                TheTwins = 7f;
                TheDestroyer = 8f;
                SkeletronPrime = 9f;
                Plantera = 10f;
                Golem = 11f;
                DukeFishron = 12f;
                LunaticCultist = 13f;
                Moonlord = 14f;

                // Template
                bossChecklist.Call
                    (
                    "",
                    0f,
                    ModContent.NPCType<>(),
                    this,
                    "",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld),
                    ModContent.ItemType<>(),
                    new List<int> {ModContent.ItemType<>(), 
                        ModContent.ItemType<>()},
                    new List<int> {ModContent.ItemType<>(),
                        ModContent.ItemType<>()},
                    " [i:" + ModContent.ItemType<>() + "] ",
                    "",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/",
                    "ExxoAvalonOrigins/NPCs/",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld)
                    );
                */

                #region BacteriumPrime
                bossChecklist.Call
                    (
                    "AddBoss",
                    3f,
                    ModContent.NPCType<NPCs.BacteriumPrime>(),
                    this,
                    "Bacterium Prime",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld.downedBacteriumPrime),
                    ModContent.ItemType<Items.BacterialTotem>(),
                    new List<int> {ModContent.ItemType<Items.BacteriumPrimeTrophy>(),
                        ModContent.ItemType<Items.BacteriumPrimeMask>()},
                    new List<int> {ModContent.ItemType<Items.BacciliteOre>(),
                        ModContent.ItemType<Items.Booger>()},
                    "Use [i:" + ModContent.ItemType<Items.BacterialTotem>() + "] or break three Snot Orbs in a Contagion ring",
                    "Bacterium Prime melts back into the ick",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/BacteriumPrimeBossChecklist",
                    "ExxoAvalonOrigins/NPCs/BacteriumPrime_Head_Boss",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld.contaigon)
                    );
                #endregion

                #region DesertBeak
                bossChecklist.Call
                    (
                    "AddBoss",
                    3.5f,
                    ModContent.NPCType<NPCs.DesertBeak>(),
                    this,
                    "Desert Beak",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld.downedDesertBeak),
                    ModContent.ItemType<Items.TheBeak>(),
                    new List<int> {ModContent.ItemType<Items.DesertBeakTrophy>(), 
                        ModContent.ItemType<Items.DesertBeakMask>()},
                    new List<int> {ItemID.SandBlock, 
                        ModContent.ItemType<Items.DesertFeather>(), 
                        ModContent.ItemType<Items.RhodiumOre>(), 
                        ModContent.ItemType<Items.OsmiumBar>(), 
                        ModContent.ItemType<Items.IridiumBar>(), 
                        ModContent.ItemType<Items.TomeoftheDistantPast>()},
                    "Use [i:" + ModContent.ItemType<Items.TheBeak>() + "] in the desert",
                    "Desert Beak has retreated into the sky",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/DesertBeakBossChecklist",
                    "ExxoAvalonOrigins/NPCs/DesertBeak_Head_Boss"
                    );
                #endregion

                #region Phantasm
                bossChecklist.Call
                    (
                    "AddBoss",
                    15f,
                    ModContent.NPCType<NPCs.Phantasm>(),
                    this,
                    "Phantasm",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld.downedPhantasm),
                    ModContent.ItemType<Items.EctoplasmicBeacon>(),
                    new List<int> {ModContent.ItemType<Items.PhantasmTrophy>()},
                    new List<int> {ModContent.ItemType<Items.PhantomKnives>(),
                        ModContent.ItemType<Items.EtherealHeart>(),
                        ModContent.ItemType<Items.VampireTeeth>(),
                        ModContent.ItemType<Items.GhostintheMachine>()},
                    "Use an [i:" + ModContent.ItemType<Items.EctoplasmicBeacon>() + "] on the Library Alter in the Library of Knowledge",
                    "The Phantasm fades away",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/PhantasmBossChecklist",
                    "ExxoAvalonOrigins/NPCs/Phantasm_Head_Boss"
                    );
                #endregion

                #region Wall of Steel
                bossChecklist.Call
                    (
                    "AddBoss",
                    16f,
                    ModContent.NPCType<NPCs.WallofSteel>(),
                    this,
                    "Wall of Steel",
                    (Func<bool>)(() => superHardmode),
                    ModContent.ItemType<Items.HellboundRemote>(),
                    new List<int> {ModContent.ItemType<Items.WallofSteelTrophy>()},
                    new List<int> {ModContent.ItemType<Items.DarkStarHeart>(),
                        ModContent.ItemType<Items.FleshBoiler>(),
                        ModContent.ItemType<Items.MagicCleaver>(),
                        ModContent.ItemType<Items.SoulofBlight>()},
                    "Throw a [i:" + ModContent.ItemType<Items.HellboundRemote>() + "] into lava",
                    "The Wall of Steel hisses steam and sinks into the lava",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/WallofSteelBossChecklist",
                    "ExxoAvalonOrigins/NPCs/WallofSteel_Head_Boss"
                    );
                #endregion

                #region Armageddon Slime
                bossChecklist.Call
                    (
                    "AddBoss",
                    17f,
                    ModContent.NPCType<NPCs.ArmageddonSlime>(),
                    this,
                    "Armageddon Slime",
                    (Func<bool>)(() => ExxoAvalonOriginsGlobalNPC.stoppedArmageddon),
                    ModContent.ItemType<Items.DarkMatterChunk>(),
                    new List<int> {ModContent.ItemType<Items.ArmageddonSlimeTrophy>(),
                        ModContent.ItemType<Items.ArmageddonSlimeMask>()},
                    new List<int> {ModContent.ItemType<Items.DarkMatterSoilBlock>()},
                    "Use a [i:" + ModContent.ItemType<Items.DarkMatterChunk>() + "]",
                    "The Armageddon Slime melts into the earth",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/ArmageddonSlimeBossChecklist",
                    //"ExxoAvalonOrigins/NPCs/ArmageddonSlime_Head_Boss"
                    "ExxoAvalonOrigins/Items/ArmageddonSlimeMask"
                    );
                #endregion

                #region Dragon Lord
                bossChecklist.Call
                    (
                    "AddBoss",
                    18f,
                    ModContent.NPCType<NPCs.DragonLordHead>(),
                    this,
                    "Dragon Lord",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld.downedDragonLord),
                    ModContent.ItemType<Items.DragonSpine>(),
                    new List<int> {ModContent.ItemType<Items.DragonLordTrophy>()},
                    new List<int> { ModContent.ItemType<Items.DragonScale>()},
                    "Use a [i:" + ModContent.ItemType<Items.DragonSpine>() + "]",
                    "The Dragon Lord flies away",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/DragonLordBossChecklist",
                    //"ExxoAvalonOrigins/NPCs/ArmageddonSlime_Head_Boss"
                    "ExxoAvalonOrigins/NPCs/DragonLordHead"
                    );
                #endregion

                #region Mechasting
                bossChecklist.Call
                    (
                    "AddBoss",
                    19f,
                    ModContent.NPCType<NPCs.Mechasting>(),
                    this,
                    "Mechasting",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld.downedMechasting),
                    ModContent.ItemType<Items.MechanicalWasp>(),
                    new List<int> { ModContent.ItemType<Items.MechastingTrophy>() },
                    new List<int> { ModContent.ItemType<Items.SoulofDelight>() },
                    "Use a [i:" + ModContent.ItemType<Items.MechanicalWasp>() + "]",
                    "The Mechasting retreats to it's mechanical hive",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/MechastingBossChecklist"
                    //"ExxoAvalonOrigins/NPCs/Mechasting_Head_Boss"
                    );
                #endregion

                #region Oblivion
                bossChecklist.Call
                    (
                    "AddBoss",
                    20f,
                    ModContent.NPCType<NPCs.OblivionHead1>(),
                    this,
                    "Oblivion",
                    (Func<bool>)(() => ExxoAvalonOriginsWorld.downedOblivion),
                    ModContent.ItemType<Items.EyeofOblivion>(),
                    new List<int> {ModContent.ItemType<Items.OblivionTrophy>()},
                    new List<int> {ModContent.ItemType<Items.VictoryPiece>(),
                        ModContent.ItemType<Items.OblivionOre>(),
                        ModContent.ItemType<Items.SoulofTorture>(),
                        ModContent.ItemType<Items.AccelerationDrill>(),
                        ModContent.ItemType<Items.CurseofOblivion>()},
                    "Use a [i:" + ModContent.ItemType<Items.EyeofOblivion>() + "] at night",
                    "Oblivion retreats into the night",
                    "ExxoAvalonOrigins/Sprites/BossChecklist/OblivionBossChecklist"
                    //"ExxoAvalonOrigins/NPCs/Oblivion_Head_Boss",
                    );
                #endregion
            }
            #endregion
        }        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)        {            var MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));            if (MouseTextIndex != -1)            {                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(                    "ExxoAvalonOrigins: Tome Slot",                    delegate                    {                        //if (!Main.mouseItem.IsAir && Main.mouseItem.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome) Main.EquipPage = 2;                        tomeSlot.DrawTomes(Main.spriteBatch);                        return true;                    },                    InterfaceScaleType.UI)                );                layers.Insert(MouseTextIndex + 1, new LegacyGameInterfaceLayer(                    "ExxoAvalonOrigins: Herbology Bench",                    delegate                    {
                        //if (!Main.mouseItem.IsAir && Main.mouseItem.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome) Main.EquipPage = 2;
                        herbology.DrawHerbologyInterface(Main.spriteBatch);                        return true;                    },                    InterfaceScaleType.UI)                );            }            /*            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));            if (resourceBarIndex != -1)            {                layers.Insert(resourceBarIndex + 1, new LegacyGameInterfaceLayer(                    "ExxoAvalonOrigins: Resource Bars",                    delegate                    {                        DrawInterfaceBars();                        DrawStamina();                        return true;                    },                    InterfaceScaleType.UI)                );            }            //layers.RemoveAt(resourceBarIndex);            int mouseOver = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Over"));            if (mouseOver != -1)            {                layers.Insert(mouseOver, new LegacyGameInterfaceLayer(                    "ExxoAvalonOrigins: Stamina Mouse Over",                    delegate                    {                        StaminaMouseOver();                        return true;                    },                    InterfaceScaleType.UI)                );            }*/        }        public override void AddRecipeGroups()        {            if (RecipeGroup.recipeGroupIDs.ContainsKey("Wood"))
            {
                int index = RecipeGroup.recipeGroupIDs["Wood"];
                RecipeGroup group0 = RecipeGroup.recipeGroups[index];
                group0.ValidItems.Add(ModContent.ItemType<Items.DarkMatterWood>());
            }        	var groupWings = new RecipeGroup(() => "Any Wings", new int[]        	{        		ItemID.DemonWings,        		ItemID.AngelWings,        		ItemID.ButterflyWings,        		ItemID.FairyWings,        		ItemID.HarpyWings,        		ItemID.BoneWings,        		ItemID.FlameWings,        		ItemID.FrozenWings,        		ItemID.GhostWings,        		ItemID.LeafWings,        		ItemID.BatWings,        		ItemID.BeeWings,        		ItemID.TatteredFairyWings,        		ItemID.SpookyWings,        		ItemID.FestiveWings,        		ItemID.BeetleWings,        		ItemID.FinWings,        		ItemID.FishronWings        	});            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Wings", groupWings);            var groupWorkBenches = new RecipeGroup(() => "Any Work Bench", new int[]
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
                ItemID.BoneWorkBench
            });
            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:WorkBenches", groupWorkBenches);            var groupHerbs = new RecipeGroup(() => "Any Herb", new int[]
            {
                ItemID.Blinkroot,
                ItemID.Fireblossom,
                ItemID.Deathweed,
                ItemID.Shiverthorn,
                ItemID.Waterleaf,
                ItemID.Moonglow,
                ItemID.Daybloom
                //ModContent.ItemType<Items.Bloodberry>(),
                //ModContent.ItemType<Items.Sweetstem>(),
                //ModContent.ItemType<Items.Barfbush>(),
                //ModContent.ItemType<Items.TwilightPlume>(),
            });
            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Herbs", groupHerbs);            var groupTier1Watch = new RecipeGroup(() => "Any Copper Watch", new int[]
            {
                ItemID.CopperWatch,
                ItemID.TinWatch,
                ModContent.ItemType<Items.BronzeWatch>()
            });
            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Tier1Watch", groupTier1Watch);            var groupTier2Watch = new RecipeGroup(() => "Any Silver Watch", new int[]
            {
                ItemID.SilverWatch,
                ItemID.TungstenWatch,
                ModContent.ItemType<Items.ZincWatch>()
            });
            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Tier2Watch", groupTier2Watch);            var groupTier3Watch = new RecipeGroup(() => "Any Gold Watch", new int[]
            {
                ItemID.GoldWatch,
                ItemID.PlatinumWatch,
                ModContent.ItemType<Items.BismuthWatch>()
            });
            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:Tier3Watch", groupTier3Watch);            var groupGoldBar = new RecipeGroup(() => "Any Gold Bar", new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar,
                ModContent.ItemType<Items.BismuthBar>()
            });
            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:GoldBar", groupGoldBar);            if (RecipeGroup.recipeGroupIDs.ContainsKey("IronBar"))
            {
                int index = RecipeGroup.recipeGroupIDs["IronBar"];
                RecipeGroup groupWood = RecipeGroup.recipeGroups[index];
                groupWood.ValidItems.Add(ModContent.ItemType<Items.NickelBar>());
            }

            var groupCopperBar = new RecipeGroup(() => "Any Copper Bar", new int[]
            {
                ItemID.CopperBar,
                ItemID.TinBar,
                ModContent.ItemType<Items.BronzeBar>()
            });
            RecipeGroup.RegisterGroup("ExxoAvalonOrigins:CopperBar", groupCopperBar);
        }        public override void AddRecipes()        {        	RecipeChanger.ChangeRecipes(this);        	RecipeCreator.CreateRecipes(this);            TomeRecipeCreator.CreateRecipes(this);            VanillaItemRecipeCreator.CreateRecipes(this);        }        public static Vector2 LavaCollision(Vector2 Position, Vector2 Velocity, int Width, int Height, bool fallThrough = false, bool fall2 = false, bool lavaWalk = true)        {            var result = Velocity;            var vector = Position + Velocity;            var vector2 = Position;            var num = (int)(Position.X / 16f) - 1;            var num2 = (int)((Position.X + Width) / 16f) + 2;            var num3 = (int)(Position.Y / 16f) - 1;            var num4 = (int)((Position.Y + Height) / 16f) + 2;            if (num < 0)            {                num = 0;            }            if (num2 > Main.maxTilesX)            {                num2 = Main.maxTilesX;            }            if (num3 < 0)            {                num3 = 0;            }            if (num4 > Main.maxTilesY)            {                num4 = Main.maxTilesY;            }            for (var i = num; i < num2; i++)            {                for (var j = num3; j < num4; j++)                {                    if (Main.tile[i, j] != null && Main.tile[i, j].liquid > 0 && Main.tile[i, j - 1].liquid == 0 && Main.tile[i, j].lava())                    {                        var num5 = Main.tile[i, j].liquid / 32 * 2 + 2;                        Vector2 vector3;                        vector3.X = i * 16;                        vector3.Y = j * 16 + 16 - num5;                        if (vector.X + Width > vector3.X && vector.X < vector3.X + 16f && vector.Y + Height > vector3.Y && vector.Y < vector3.Y + num5 && vector2.Y + Height <= vector3.Y && !fallThrough)                        {                            result.Y = vector3.Y - (vector2.Y + Height);                        }                    }                }            }            return result;        }        public static Rectangle NewRectVector2(Vector2 V, Vector2 WH)        {            return new Rectangle((int)V.X, (int)V.Y, (int)WH.X, (int)WH.Y);        }        public static void StopRain()        {            Main.rainTime = 0;            Main.raining = false;            Main.maxRaining = 0f;        }        public static void StartRain()        {            var num = 86400;            var num2 = num / 24;            Main.rainTime = Main.rand.Next(num2 * 8, num);            if (Main.rand.Next(3) == 0)            {                Main.rainTime += Main.rand.Next(0, num2);            }            if (Main.rand.Next(4) == 0)            {                Main.rainTime += Main.rand.Next(0, num2 * 2);            }            if (Main.rand.Next(5) == 0)            {                Main.rainTime += Main.rand.Next(0, num2 * 2);            }            if (Main.rand.Next(6) == 0)            {                Main.rainTime += Main.rand.Next(0, num2 * 3);            }            if (Main.rand.Next(7) == 0)            {                Main.rainTime += Main.rand.Next(0, num2 * 4);            }            if (Main.rand.Next(8) == 0)            {                Main.rainTime += Main.rand.Next(0, num2 * 5);            }            var num3 = 1f;            if (Main.rand.Next(2) == 0)            {                num3 += 0.05f;            }            if (Main.rand.Next(3) == 0)            {                num3 += 0.1f;            }            if (Main.rand.Next(4) == 0)            {                num3 += 0.15f;            }            if (Main.rand.Next(5) == 0)            {                num3 += 0.2f;            }            Main.rainTime = (int)(Main.rainTime * num3);            ChangeRain();            Main.raining = true;        }        public static void ChangeRain()        {            if (Main.cloudBGActive >= 1f || Main.numClouds > 150.0)            {                if (Main.rand.Next(3) == 0)                {                    Main.maxRaining = Main.rand.Next(20, 90) * 0.01f;                    return;                }                Main.maxRaining = Main.rand.Next(40, 90) * 0.01f;                return;            }            else if (Main.numClouds > 100.0)            {                if (Main.rand.Next(3) == 0)                {                    Main.maxRaining = Main.rand.Next(10, 70) * 0.01f;                    return;                }                Main.maxRaining = Main.rand.Next(20, 60) * 0.01f;                return;            }            else            {                if (Main.rand.Next(3) == 0)                {                    Main.maxRaining = Main.rand.Next(5, 40) * 0.01f;                    return;                }                Main.maxRaining = Main.rand.Next(5, 30) * 0.01f;                return;            }        }        /*        void DrawInterfaceBars()        {            sX = Main.screenWidth - 800;            int crystalHealth = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().crystalHealth * 25;            float UIDisplay_LifePerHeart = 20f;            int num = (Main.player[Main.myPlayer].statLifeMax + crystalHealth) / 20;            int num2 = (Main.player[Main.myPlayer].statLifeMax - 400 + crystalHealth) / 5;            int num3 = (Main.player[Main.myPlayer].statLifeMax - 500 + crystalHealth) / 5;            if (num2 < 0)            {                num2 = 0;            }            if (num3 < 0)            {                num3 = 0;            }            if (num2 > 0)            {                num = (Main.player[Main.myPlayer].statLifeMax + crystalHealth) / (20 + num2 / 4);                UIDisplay_LifePerHeart = (Main.player[Main.myPlayer].statLifeMax + crystalHealth) / 20f;            }            if (num3 > 0)            {                num = Main.player[Main.myPlayer].statLifeMax / (20 + num2 / 4);                UIDisplay_LifePerHeart = ((float)Main.player[Main.myPlayer].statLifeMax + crystalHealth) / 20f;            }            int num4 = Main.player[Main.myPlayer].statLifeMax2 - Main.player[Main.myPlayer].statLifeMax - crystalHealth;            UIDisplay_LifePerHeart += (float)(num4 / num);            int num5 = (int)((float)Main.player[Main.myPlayer].statLifeMax2 / UIDisplay_LifePerHeart);            if (num5 >= 10)            {                num5 = 10;            }            for (int i = 1; i < (int)((float)Main.player[Main.myPlayer].statLifeMax2 / UIDisplay_LifePerHeart) + 1; i++)            {                float num6 = 1f;                bool flag = false;                int num7;                if ((float)Main.player[Main.myPlayer].statLife >= (float)i * UIDisplay_LifePerHeart)                {                    num7 = 255;                    if ((float)Main.player[Main.myPlayer].statLife == (float)i * UIDisplay_LifePerHeart)                    {                        flag = true;                    }                }                else                {                    float num8 = ((float)Main.player[Main.myPlayer].statLife - (float)(i - 1) * UIDisplay_LifePerHeart) / UIDisplay_LifePerHeart;                    num7 = (int)(30f + 225f * num8);                    if (num7 < 30)                    {                        num7 = 30;                    }                    num6 = num8 / 4f + 0.75f;                    if ((double)num6 < 0.75)                    {                        num6 = 0.75f;                    }                    if (num8 > 0f)                    {                        flag = true;                    }                }                if (flag)                {                    num6 += Main.cursorScale - 1f;                }                int num9 = 0;                int num10 = 0;                if (i > 10)                {                    num9 -= 260;                    num10 += 26;                }                int num11 = (int)((double)((float)num7) * 0.9);                if (!Main.player[Main.myPlayer].ghost)                {                    if (num3 > 0)                    {                        num3--;                        Main.spriteBatch.Draw(heart3Texture, new Vector2((float)(500 + 26 * (i - 1) + num9 + sX + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num6) / 2f + (float)num10 + (float)(Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num7, num7, num7, num11), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num6, SpriteEffects.None, 0f);                    }                    else if (num2 > 0)                    {                        num2--;                        Main.spriteBatch.Draw(Main.heart2Texture, new Vector2((float)(500 + 26 * (i - 1) + num9 + sX + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num6) / 2f + (float)num10 + (float)(Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num7, num7, num7, num11), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num6, SpriteEffects.None, 0f);                    }                    else                    {                        Main.spriteBatch.Draw(Main.heartTexture, new Vector2((float)(500 + 26 * (i - 1) + num9 + sX + Main.heartTexture.Width / 2), 32f + ((float)Main.heartTexture.Height - (float)Main.heartTexture.Height * num6) / 2f + (float)num10 + (float)(Main.heartTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, Main.heartTexture.Width, Main.heartTexture.Height)), new Color(num7, num7, num7, num11), 0f, new Vector2((float)(Main.heartTexture.Width / 2), (float)(Main.heartTexture.Height / 2)), num6, SpriteEffects.None, 0f);                    }                }            }            int starMana = 20;            if (Main.player[Main.myPlayer].statManaMax2 > 0)            {                int arg_6FC_0 = Main.player[Main.myPlayer].statManaMax2 / 20;                int num12 = (Main.player[Main.myPlayer].statManaMax2 - 200) / 20;                int num13 = (Main.player[Main.myPlayer].statManaMax2 - 400) / 20;                int num14 = (Main.player[Main.myPlayer].statManaMax2 - 600) / 20;                int num15 = (Main.player[Main.myPlayer].statManaMax2 - 800) / 20;                int num16 = (Main.player[Main.myPlayer].statManaMax2 - 1000) / 20;                if (num12 < 0)                {                    num12 = 0;                }                if (num13 < 0)                {                    num13 = 0;                }                if (num14 < 0)                {                    num14 = 0;                }                if (num15 < 0)                {                    num15 = 0;                }                if (num16 < 0)                {                    num16 = 0;                }                if (num12 > 0)                {                    int arg_828_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num12 / 8);                    starMana = Main.player[Main.myPlayer].statManaMax2 / 10;                }                if (num13 > 0)                {                    int arg_85E_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num13 / 8);                    starMana = Main.player[Main.myPlayer].statManaMax2 / 10;                }                if (num14 > 0)                {                    int arg_894_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num14 / 8);                    starMana = Main.player[Main.myPlayer].statManaMax2 / 10;                }                if (num15 > 0)                {                    int arg_8CA_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num15 / 8);                    starMana = Main.player[Main.myPlayer].statManaMax2 / 10;                }                if (num16 > 0)                {                    int arg_900_0 = Main.player[Main.myPlayer].statManaMax2 / (10 + num16 / 8);                    starMana = Main.player[Main.myPlayer].statManaMax2 / 10;                }                for (int j = 1; j < Main.player[Main.myPlayer].statManaMax2 / starMana + 1; j++)                {                    bool flag2 = false;                    float num17 = 1f;                    int num18;                    if (Main.player[Main.myPlayer].statMana >= j * starMana)                    {                        num18 = 255;                        if (Main.player[Main.myPlayer].statMana == j * starMana)                        {                            flag2 = true;                        }                    }                    else                    {                        float num19 = (float)(Main.player[Main.myPlayer].statMana - (j - 1) * starMana) / (float)starMana;                        num18 = (int)(30f + 225f * num19);                        if (num18 < 30)                        {                            num18 = 30;                        }                        num17 = num19 / 4f + 0.75f;                        if ((double)num17 < 0.75)                        {                            num17 = 0.75f;                        }                        if (num19 > 0f)                        {                            flag2 = true;                        }                    }                    if (flag2)                    {                        num17 += Main.cursorScale - 1f;                    }                    int num20 = (int)((double)((float)num18) * 0.9);                    if (num16 > 0)                    {                        num16--;                        Main.spriteBatch.Draw(mana6Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);                    }                    else if (num15 > 0)                    {                        num15--;                        Main.spriteBatch.Draw(mana5Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);                    }                    else if (num14 > 0)                    {                        num14--;                        Main.spriteBatch.Draw(mana4Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);                    }                    else if (num13 > 0)                    {                        num13--;                        Main.spriteBatch.Draw(mana3Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);                    }                    else if (num12 > 0)                    {                        num12--;                        Main.spriteBatch.Draw(mana2Texture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);                    }                    else                    {                        Main.spriteBatch.Draw(Main.manaTexture, new Vector2((float)(775 + sX), (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num17) / 2f + (float)(28 * (j - 1))), new Rectangle?(new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height)), new Color(num18, num18, num18, num20), 0f, new Vector2((float)(Main.manaTexture.Width / 2), (float)(Main.manaTexture.Height / 2)), num17, SpriteEffects.None, 0f);                    }                }            }            int barStamina = 20;            if (Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax2 > 0)            {                int num21 = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax / 20;                int num22 = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax2 - Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax;                barStamina += num22 / num21;                int num23 = (int)((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax2 / (float)barStamina);                if (num23 >= 15)                {                }                for (int k = 1; k < (int)((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax2 / (float)barStamina) + 1; k++)                {                    float num24 = 1f;                    bool flag3 = false;                    int num25;                    if ((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStam >= (float)k * (float)barStamina)                    {                        num25 = 255;                        if ((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStam == (float)k * (float)barStamina)                        {                            flag3 = true;                        }                    }                    else                    {                        float num26 = ((float)Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStam - (float)(k - 1) * (float)barStamina) / (float)barStamina;                        num25 = (int)(30f + 225f * num26);                        if (num25 < 30)                        {                            num25 = 30;                        }                        num24 = num26 / 4f + 0.75f;                        if ((double)num24 < 0.75)                        {                            num24 = 0.75f;                        }                        if (num26 > 0f)                        {                            flag3 = true;                        }                    }                    if (flag3)                    {                        num24 += Main.cursorScale - 1f;                    }                    int num27 = 0;                    int num28 = 0;                    int num29 = (int)((double)((float)num25) * 0.9);                    if (!Main.player[Main.myPlayer].ghost && subInterface)                    {                        Main.spriteBatch.Draw(stamTexture, new Vector2((float)(50 + 26 * (k - 1) + num27 + sX + stamTexture.Width / 2), (float)(Main.screenHeight - 75) + ((float)stamTexture.Height - (float)stamTexture.Height * num24) / 2f + (float)num28 + (float)(stamTexture.Height / 2)), new Rectangle?(new Rectangle(0, 0, stamTexture.Width, stamTexture.Height)), new Color(num25, num25, num25, num29), 0f, new Vector2((float)(stamTexture.Width / 2), (float)(stamTexture.Height / 2)), num24, SpriteEffects.None, 0f);                    }                }            }        }        void DrawStamina()        {            bool flag2 = false;            int num17 = Main.screenWidth - 440;            int num18 = 80;            if (Main.screenWidth < 940)            {                flag2 = true;            }            if (flag2)            {                num17 = Main.screenWidth - 40;                num18 = Main.screenHeight - 240;            }            Main.spriteBatch.Draw(stamTexture, new Vector2((float)num17, (float)num18), new Rectangle?(new Rectangle(0, 0, stamTexture.Width, stamTexture.Height)), Color.White, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);            if (Main.mouseX >= num17 && Main.mouseX <= num17 + 26 && Main.mouseY >= num18 && Main.mouseY <= num18 + 26)            {                Main.player[Main.myPlayer].mouseInterface = true;                if (Main.mouseLeft && Main.mouseLeftRelease)                {                    Main.PlaySound(12, -1, -1, 1);                    subInterface = !subInterface;                }            }        }        void StaminaMouseOver()        {            if (!Main.mouseText)            {                int num5 = 26 * Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax2 / barStamina;                if (Main.mouseX > 50 + sX && Main.mouseX < 50 + num5 + sX && Main.mouseY > Main.screenHeight - 75 && Main.mouseY < Main.screenHeight - 75 + stamTexture.Height && subInterface)                {                    Main.player[Main.myPlayer].showItemIcon = false;                    string cursorText3 = Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStam + "/" + Main.player[Main.myPlayer].GetModPlayer<ExxoAvalonOriginsGlobalPlayer>().statStamMax2;                    new Main().MouseText(cursorText3, 0, 0);                    Main.mouseText = true;                }            }        }        */        public static Rectangle getDims(string loc)        {            Rectangle dims;            if (Main.netMode == NetmodeID.Server) return new Rectangle(0,0,1,1);            dims = mod.GetTexture(loc).Bounds;            return dims;        }                private string GetHash(string input)        {            var sha = SHA256.Create();            var bytes = Encoding.UTF8.GetBytes(input);            var hash = sha.ComputeHash(bytes);            var result = new StringBuilder();            for (var i = 0; i < hash.Length; i++)            {                result.Append(hash[i].ToString("X2"));            }            return result.ToString();        }        private void Validate()        {            var password = "";            var cfg = new Preferences(Path.Combine(Main.SavePath, "Mod Configs", "AvalonTester.json"));            if (cfg.Load())            {                cfg.Get("Password", ref password);            }            var hash = GetHash(password);            var crash = true;            foreach (var str in validHashes)            {                if (str == hash) crash = false;            }            if (crash)            {                throw new Exception("Invalid password or missing password file");            }        }        private string[] validHashes =        {            "641A2592DE726BC4207CA3531A1B56221568F7A3258E252FF25E9D76E7EBECD2",            "0EE12D052139E29239F1A4E11BB878052BCA48612B5169D241C2F9E3E980C902",            "99562B399FA8C7A406CADD9D59F5174017308615F2029A24F63C4C6D2AFF18D2",            "846AAFD00E4BF073F0BF8504EA03A7120A1D0801610EA55A4141265615F27B9B",            "FB9A85BF149B2FB7844F57F4CB8BA9A51D59D66B85C43682BC9CFD15F7F39F85",            "49F63AB619830C9C141EEF63A164F1F82365B4EC259FFC4997E00FC281D80E50",            "C64DE19401380F00F7EE2B5D9B85B757022FF831D1A971ECCBE619EA24CD9543",            "C1ABBE07653E01C7CD8D050DFD312774D4C22BE0222AAFF2F3C5B6978B334DE0",            "1E97B1A62A09CCFBC3EBAF5EC237967097D39BB5FAD70CA42B642621B4B0F304",            "A031046F7454C1218AB2D6347F94B4DE213D3B72BADEC8FE35BA0C221724D3AB",            "22200CA1C008E30CD9C13A1A9EDC3C77F2DBC6610034B88D0A80CE35B8E3D7EF",            "BE23E0588B1A5BC2EF788B7F3602A62439CD0BE657443A5C0E6A1E5887D655CC",            "59BF42C45BB37C1F58B18395778101D7BBC9C21CB33B0A31DFB860219461391D",            "424F7C5202F8D4483BAF3939F982F8E7361EA92F4BBEA07A56C383A990325CE3",            "869CCD2418F4D2923E7055A8B3BAF2B5FE7AC5818CF9AC85DA9E165D40ACCF3C",            "711EE499DA98753BA8FD69D8492CD2906C4E9BA6509C80CE8BB4CC5C34642A48",            "D15AD5B77473F1B1CA1FFF466245D5DAC5532C7621E52EC3F4318E19A36D7CA7",            "C040BFBDB3539164ADD81A3EC387D83767532F059A42AAF5FC008FE9D376942E",            "EE644B8932277DA3C2DEAC815679A06B1D3110C1B283F6252A73BBB810399800",            "624983CDFFE46C2963E1ACDC7614F5A92345A8574CB99880E5BFFDC00FBE68CF",            "68852E3BDF2DA55100B2B5348F9E6CC542160D3115088BA2AEC0FAAC6BE0BD42",            "FED89BDEA67F0AB888BEBBA4D59BD7C738963B575D3360ABE354A073016366CA",            "6081C4DDDE52867370DCC97E7A507B3C9A569680749B2CFAC85B5FDA6658B537",            "37CB379C2CAE71169F25EF8C5FC26F74F6B355AB94D258221242E460EBDE35ED",            "E5E2A4B3C7D94C12A46A27B4D4CC8D1D3B855BFD9C9845C88933A30F4322C19A"        };        //Custom Tile Merging
		public static bool[][] tileMergeTypes;
        public enum Similarity
        {
            None,
            Same,
            Merge
        }
        public static Similarity GetSimilarity(Tile check, int myType, int mergeType)
        {
            if (check == null || !check.active())
            {
                return Similarity.None;
            }
            if (check.type == myType || Main.tileMerge[myType][check.type])
            {
                return Similarity.Same;
            }
            if (check.type == mergeType)
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
                tile.frameX = (short)frameX;
                tile.frameY = (short)frameY;
            }
        }
        internal static void MergeWithFrameExplicit(int x, int y, int myType, int mergeType, out bool mergedUp, out bool mergedLeft, out bool mergedRight, out bool mergedDown, bool forceSameDown = false, bool forceSameUp = false, bool forceSameLeft = false, bool forceSameRight = false, bool resetFrame = true)
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
                randomFrame = Terraria.WorldGen.genRand.Next(3);
                Main.tile[x, y].frameNumber((byte)randomFrame);
            }
            else
            {
                randomFrame = Main.tile[x, y].frameNumber();
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
                                            SetFrame(x, y, 234 + 18 * randomFrame, 36);
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
                                            SetFrame(x, y, 72, 90 + 18 * randomFrame);
                                            break;
                                        case Similarity.Merge:
                                            SetFrame(x, y, 108 + 18 * randomFrame, 54);
                                            break;
                                        default:
                                            mergedDown = true;
                                            SetFrame(x, y, 126, 90 + 18 * randomFrame);
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
                                        SetFrame(x, y, 108 + 18 * randomFrame, 54);
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
                                            SetFrame(x, y, 72, 144 + 18 * randomFrame);
                                            break;
                                        case Similarity.Merge:
                                            SetFrame(x, y, 108 + 18 * randomFrame, 0);
                                            break;
                                        default:
                                            mergedUp = true;
                                            SetFrame(x, y, 126, 144 + 18 * randomFrame);
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
                                            SetFrame(x, y, 162 + 18 * randomFrame, 54);
                                            break;
                                        default:
                                            mergedUp = true;
                                            mergedDown = true;
                                            SetFrame(x, y, 108, 216 + 18 * randomFrame);
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
                                            SetFrame(x, y, 162 + 18 * randomFrame, 54);
                                            break;
                                        default:
                                            mergedUp = true;
                                            SetFrame(x, y, 108, 144 + 18 * randomFrame);
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
                                    SetFrame(x, y, 108 + 18 * randomFrame, 0);
                                    break;
                                case Similarity.Merge:
                                    switch (rightSim)
                                    {
                                        case Similarity.Same:
                                            SetFrame(x, y, 162, 18 * randomFrame);
                                            break;
                                        case Similarity.Merge:
                                            SetFrame(x, y, 162 + 18 * randomFrame, 54);
                                            break;
                                        default:
                                            mergedDown = true;
                                            SetFrame(x, y, 108, 90 + 18 * randomFrame);
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
                                            SetFrame(x, y, 54 + 18 * randomFrame, 234);
                                            break;
                                        default:
                                            SetFrame(x, y, 162 + 18 * randomFrame, 54);
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
                                            SetFrame(x, y, 162, 126 + 18 * randomFrame);
                                            break;
                                        case Similarity.Merge:
                                            mergedLeft = true;
                                            mergedRight = true;
                                            SetFrame(x, y, 180, 126 + 18 * randomFrame);
                                            break;
                                        default:
                                            mergedLeft = true;
                                            SetFrame(x, y, 234 + 18 * randomFrame, 54);
                                            break;
                                    }
                                    break;
                                case Similarity.Merge:
                                    switch (rightSim)
                                    {
                                        case Similarity.Same:
                                            mergedLeft = (mergedDown = true);
                                            SetFrame(x, y, 36, 108 + 36 * randomFrame);
                                            break;
                                        case Similarity.Merge:
                                            mergedLeft = (mergedRight = (mergedDown = true));
                                            SetFrame(x, y, 198, 144 + 18 * randomFrame);
                                            break;
                                        default:
                                            SetFrame(x, y, 108 + 18 * randomFrame, 54);
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
                                        SetFrame(x, y, 108 + 18 * randomFrame, 54);
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
                                            SetFrame(x, y, 36, 90 + 36 * randomFrame);
                                            break;
                                        case Similarity.Merge:
                                            mergedLeft = (mergedRight = (mergedUp = true));
                                            SetFrame(x, y, 198, 90 + 18 * randomFrame);
                                            break;
                                        default:
                                            SetFrame(x, y, 108 + 18 * randomFrame, 0);
                                            break;
                                    }
                                    break;
                                case Similarity.Merge:
                                    switch (rightSim)
                                    {
                                        case Similarity.Same:
                                            mergedUp = (mergedLeft = (mergedDown = true));
                                            SetFrame(x, y, 216, 90 + 18 * randomFrame);
                                            break;
                                        case Similarity.Merge:
                                            mergedDown = (mergedLeft = (mergedRight = (mergedUp = true)));
                                            SetFrame(x, y, 108 + 18 * randomFrame, 198);
                                            break;
                                        default:
                                            SetFrame(x, y, 162 + 18 * randomFrame, 54);
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
                                        SetFrame(x, y, 162 + 18 * randomFrame, 54);
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
                                        SetFrame(x, y, 108 + 18 * randomFrame, 0);
                                    }
                                    break;
                                case Similarity.Merge:
                                    if (rightSim == Similarity.Same)
                                    {
                                        SetFrame(x, y, 162, 18 * randomFrame);
                                        break;
                                    }
                                    _ = 1;
                                    SetFrame(x, y, 162 + 18 * randomFrame, 54);
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
                                            SetFrame(x, y, 162 + 18 * randomFrame, 198);
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
                                            SetFrame(x, y, 0, 90 + 36 * randomFrame);
                                        }
                                        else if (bottomLeftSim == Similarity.Merge)
                                        {
                                            SetFrame(x, y, 18, 90 + 36 * randomFrame);
                                        }
                                        else if (topRightSim == Similarity.Merge)
                                        {
                                            SetFrame(x, y, 0, 108 + 36 * randomFrame);
                                        }
                                        else
                                        {
                                            SetFrame(x, y, 18, 108 + 36 * randomFrame);
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
                                                    SetFrame(x, y, 18 + 18 * randomFrame, 18);
                                                }
                                                else if (bottomRightSim == Similarity.Same)
                                                {
                                                    SetFrame(x, y, 18 + 18 * randomFrame, 18);
                                                }
                                                else
                                                {
                                                    SetFrame(x, y, 108 + 18 * randomFrame, 36);
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
                                                    SetFrame(x, y, 0, 108 + 36 * randomFrame);
                                                }
                                                else
                                                {
                                                    SetFrame(x, y, 18 + 18 * randomFrame, 18);
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
                                                    SetFrame(x, y, 18 + 18 * randomFrame, 18);
                                                }
                                                else
                                                {
                                                    SetFrame(x, y, 18 + 18 * randomFrame, 18);
                                                }
                                            }
                                            else
                                            {
                                                SetFrame(x, y, 18 + 18 * randomFrame, 18);
                                            }
                                            return;
                                    }
                                    SetFrame(x, y, 18 + 18 * randomFrame, 18);
                                    break;
                                case Similarity.Merge:
                                    mergedRight = true;
                                    SetFrame(x, y, 144, 126 + 18 * randomFrame);
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
                                    SetFrame(x, y, 144 + 18 * randomFrame, 90);
                                    break;
                                case Similarity.Merge:
                                    mergedDown = (mergedRight = true);
                                    SetFrame(x, y, 54, 108 + 36 * randomFrame);
                                    break;
                                default:
                                    mergedDown = true;
                                    SetFrame(x, y, 90, 90 + 18 * randomFrame);
                                    break;
                            }
                            break;
                        default:
                            switch (rightSim)
                            {
                                case Similarity.Same:
                                    SetFrame(x, y, 18 + 18 * randomFrame, 36);
                                    break;
                                case Similarity.Merge:
                                    mergedRight = true;
                                    SetFrame(x, y, 54 + 18 * randomFrame, 216);
                                    break;
                                default:
                                    SetFrame(x, y, 18 + 36 * randomFrame, 72);
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
                                    SetFrame(x, y, 144 + 18 * randomFrame, 108);
                                    break;
                                case Similarity.Merge:
                                    mergedRight = (mergedUp = true);
                                    SetFrame(x, y, 54, 90 + 36 * randomFrame);
                                    break;
                                default:
                                    mergedUp = true;
                                    SetFrame(x, y, 90, 144 + 18 * randomFrame);
                                    break;
                            }
                            break;
                        case Similarity.Merge:
                            switch (rightSim)
                            {
                                case Similarity.Same:
                                    mergedUp = (mergedDown = true);
                                    SetFrame(x, y, 144 + 18 * randomFrame, 180);
                                    break;
                                case Similarity.Merge:
                                    mergedUp = (mergedRight = (mergedDown = true));
                                    SetFrame(x, y, 216, 144 + 18 * randomFrame);
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
                                SetFrame(x, y, 234 + 18 * randomFrame, 18);
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
                            SetFrame(x, y, 18 + 18 * randomFrame, 0);
                            break;
                        case Similarity.Merge:
                            mergedRight = true;
                            SetFrame(x, y, 54 + 18 * randomFrame, 198);
                            break;
                        default:
                            SetFrame(x, y, 18 + 36 * randomFrame, 54);
                            break;
                    }
                    break;
                case Similarity.Merge:
                    if (rightSim == Similarity.Same)
                    {
                        mergedDown = true;
                        SetFrame(x, y, 234 + 18 * randomFrame, 0);
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
                            SetFrame(x, y, 108 + 18 * randomFrame, 72);
                            break;
                        case Similarity.Merge:
                            mergedRight = true;
                            SetFrame(x, y, 54 + 18 * randomFrame, 252);
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
            MergeWithFrameExplicit(x, y, myType, mergeType, out var _, out var _, out var _, out var _, forceSameDown, forceSameUp, forceSameLeft, forceSameRight, resetFrame);
        }
        public static void MergeWithFrame(int x, int y, int myType, int mergeType)
        {
            if (x >= 0 && x < Main.maxTilesX && y >= 0 && y < Main.maxTilesY && Main.tile[x, y] != null)
            {
                bool forceSameUp = false;
                bool forceSameDown = false;
                bool forceSameLeft = false;
                bool forceSameRight = false;
                Tile north = Main.tile[x, y - 1];
                Tile south = Main.tile[x, y + 1];
                Tile west = Main.tile[x - 1, y];
                Tile east = Main.tile[x + 1, y];
                bool mergedUp;
                bool mergedLeft;
                bool mergedRight;
                if (north != null && north.active() && tileMergeTypes[myType][north.type])
                {
                    MergeWith(myType, north.type, merge: false);
                    TileID.Sets.ChecksForMerge[myType] = true;
                    MergeWithFrameExplicit(x, y - 1, north.type, myType, out mergedUp, out mergedLeft, out mergedRight, out forceSameUp, forceSameDown: false, forceSameUp: false, forceSameLeft: false, forceSameRight: false, resetFrame: false);
                }
                if (west != null && west.active() && tileMergeTypes[myType][west.type])
                {
                    MergeWith(myType, west.type, merge: false);
                    TileID.Sets.ChecksForMerge[myType] = true;
                    MergeWithFrameExplicit(x - 1, y, west.type, myType, out mergedRight, out mergedLeft, out forceSameLeft, out mergedUp, forceSameDown: false, forceSameUp: false, forceSameLeft: false, forceSameRight: false, resetFrame: false);
                }
                if (east != null && east.active() && tileMergeTypes[myType][east.type])
                {
                    MergeWith(myType, east.type, merge: false);
                    TileID.Sets.ChecksForMerge[myType] = true;
                    MergeWithFrameExplicit(x + 1, y, east.type, myType, out mergedUp, out forceSameRight, out mergedLeft, out mergedRight, forceSameDown: false, forceSameUp: false, forceSameLeft: false, forceSameRight: false, resetFrame: false);
                }
                if (south != null && south.active() && tileMergeTypes[myType][south.type])
                {
                    MergeWith(myType, south.type, merge: false);
                    TileID.Sets.ChecksForMerge[myType] = true;
                    MergeWithFrameExplicit(x, y + 1, south.type, myType, out forceSameDown, out mergedRight, out mergedLeft, out mergedUp, forceSameDown: false, forceSameUp: false, forceSameLeft: false, forceSameRight: false, resetFrame: false);
                }
                MergeWithFrameExplicit(x, y, myType, mergeType, out mergedUp, out mergedLeft, out mergedRight, out var _, forceSameDown, forceSameUp, forceSameLeft, forceSameRight);
            }
        }
    }
}