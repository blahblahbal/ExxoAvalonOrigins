using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExxoAvalonOrigins.Buffs;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Tomes;
using ExxoAvalonOrigins.Items.Tools;
using ExxoAvalonOrigins.Items.Weapons.Melee;
using ExxoAvalonOrigins.Logic;
using ExxoAvalonOrigins.Prefixes;
using ExxoAvalonOrigins.Projectiles;
using ExxoAvalonOrigins.Projectiles.Torches;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ExxoAvalonOrigins
{
    public class ExxoAvalonOriginsModPlayer : ModPlayer
    {
        #region fields

        // stamina abilities
        public bool sprintUnlocked = false;
        public bool rocketJumpUnlocked = false;
        public bool swimmingUnlocked = false;
        public bool teleportUnlocked = false;
        public bool flightRestoreUnlocked = false;

        public int stamFlightRestoreCD = 0;
        public bool releaseQuickStamina;
        public int stamRegen;
        public int stamRegenCount;
        public int stamRegenDelay;
        public int staminaRegen = 1000;
        public int statStamMax = 30;
        public int statStamMax2;
        public bool stamFlower = false;
        public bool staminaDrain = false;
        public int staminaDrainStacks = 1;
        public float staminaDrainMult = 1.2f;
        public int statStam = 100;
        public static int staminaDrainTime = 10 * 60;
        // end stamina stuff

        // buff stuff
        public bool beeRepel = false;
        public bool lucky = false;
        public bool melting = false;
        public bool enemySpawns2 = false;
        public int crimsonCount = 0;
        public bool darkInferno = false;
        public int deliriumCount = 0;
        public bool forceField = true;
        public int fAlevel = 0;
        public int fAlastRecord = 0;
        public int shadowPotCd = 0;
        public bool shockWave = false;
        public int fallStart_old = 0;
        public bool vision = false;
        public const int deliriumFreq = 600;
        // end buff stuff

        // minion stuff
        public bool gastroMinion = false;
        public bool hungryMinion = false;
        public bool iceGolem = false;
        public bool goldDagger = false;
        public bool platinumDagger = false;
        public bool bismuthDagger = false;
        public bool adamantiteDagger = false;
        public bool titaniumDagger = false;
        public bool troxiniumDagger = false;
        public bool primeMinion = false;
        public bool reflectorMinion = false;
        // end minion stuff
        public bool[] pSensor = new bool[6];
        public int spiritPoppyUseCount;
        public bool shmAcc = false;
        public bool herb = false;
        public bool teleportVWasTriggered = false;
        public int screenShakeTimer;
        public bool astralProject;
        public bool snotOrb;

        public enum ShadowMirrorModes
        {
            Spawn,
            Checkpoints,
            Team
        }

        public List<int> undead = new List<int>()
        {
            NPCID.Zombie,
            NPCID.Skeleton,
            NPCID.AngryBones,
            NPCID.DarkCaster,
            NPCID.CursedSkull,
            NPCID.UndeadMiner,
            NPCID.Tim,
            NPCID.DoctorBones,
            NPCID.TheGroom,
            NPCID.ArmoredSkeleton,
            NPCID.Mummy,
            NPCID.Wraith,
            NPCID.SkeletonArcher,
            NPCID.BaldZombie,
            NPCID.PossessedArmor,
            NPCID.VampireBat,
            NPCID.Vampire,
            NPCID.ZombieEskimo,
            NPCID.UndeadViking,
            NPCID.RuneWizard,
            NPCID.PincushionZombie,
            NPCID.SlimedZombie,
            NPCID.SwampZombie,
            NPCID.TwiggyZombie,
            NPCID.ArmoredViking,
            NPCID.FemaleZombie,
            NPCID.HeadacheSkeleton,
            NPCID.MisassembledSkeleton,
            NPCID.PantlessSkeleton,
            NPCID.ZombieRaincoat,
            NPCID.Eyezor,
            NPCID.Reaper,
            NPCID.ZombieMushroom,
            NPCID.ZombieMushroomHat,
            NPCID.ZombieDoctor,
            NPCID.ZombieSuperman,
            NPCID.ZombiePixie,
            NPCID.SkeletonTopHat,
            NPCID.SkeletonAstonaut,
            NPCID.SkeletonAlien,
            NPCID.ZombieXmas,
            NPCID.ZombieSweater
        };

        public List<int> flyer = new List<int>()
        {
            NPCID.DemonEye,
            NPCID.EaterofSouls,
            NPCID.Harpy,
            NPCID.CaveBat,
            NPCID.JungleBat,
            NPCID.Pixie,
            NPCID.WyvernHead,
            NPCID.GiantBat,
            NPCID.Crimera,
            NPCID.CataractEye,
            NPCID.SleepyEye,
            NPCID.DialatedEye,
            NPCID.GreenEye,
            NPCID.PurpleEye,
            NPCID.Moth,
            NPCID.FlyingFish,
            NPCID.FlyingSnake,
            NPCID.AngryNimbus,
            ModContent.NPCType<NPCs.VampireHarpy>(),
            ModContent.NPCType<NPCs.Dragonfly>()
        };

        public List<int> minionProjectile = new List<int>()
        {
            ProjectileID.HornetStinger,
            ProjectileID.ImpFireball,
            ProjectileID.MiniRetinaLaser,
            ProjectileID.PygmySpear,
            ProjectileID.UFOLaser,
            ProjectileID.MiniSharkron,
            ProjectileID.StardustCellMinionShot
        };
        public static Dictionary<int, int> torches;

        public static Texture2D[] lavaMermanTextures;
        public static Texture2D[] originalMermanTextures;

        public static Texture2D[] spectrumArmorTextures;

        public bool inertiaBoots = false;
        public bool blahWings = false;
        public bool spikeImmune = false;
        public bool luckTome = false;

        public bool quackJump;
        public bool jumpAgainQuack;
        public bool armorStealth = false;
        public int shadowCheckPointNum = 0;
        public int shadowPlayerNum = 0;
        public bool slimeImmune = false;
        public int infectTimer = 0;
        public int infectDmg = 0;
        public bool weaponMinion = false; // remove
        public bool earthInsig = false;
        public int crystalHealth = 0;
        public Item tomeItem = new Item();
        public int pl = -1;
        public bool openLocks;
        public bool chaosCharm;
        public short thunderTimer;
        public bool terraClaws;
        public bool thunderBolt;
        public bool incDef;
        public bool regenStrike;
        public bool bOfBacteria;
        public bool duraShield = false;
        public bool slimeBand;
        public bool defDebuff;
        public int defDebuffBonusDef;
        public float rot;
        public byte qsMode = 1;
        public byte qsTimer;
        public bool qsDone;
        public bool qsIsNDown;
        public bool trapImmune;
        public bool hyperMelee;
        public bool hyperMagic;
        public bool hyperRanged;
        public int hyperBar;
        public bool auraThorns;
        public bool speed;
        public bool Nd;
        public bool oldNd;
        public bool Fd;
        public bool oldFd;
        public bool Bud;
        public bool oldBud;
        public bool Ld;
        public bool oldLd;
        public bool Gd;
        public bool oldGd;
        public bool Brd;
        public bool oldBrd;
        public bool Kd;
        public bool oldKd;
        public bool activateBubble;
        public bool activateSprint;
        public bool activateSwim;
        public bool activateSlide;
        public bool activateRocketJump;
        public bool stamDashKey;
        public bool quintJump;
        public bool shadowRing;
        public static bool SpawnDL = false;
        public bool fleshLaser;
        public int teleportToPlayer = -1;
        public bool dashIntoMob;
        public bool dashTemp;
        public bool bubbleBoost;
        public bool bubbleBoostActive;
        public int teamLen;
        public bool rocketJumpRO = true;
        public bool heartGolem;
        public bool ethHeart;
        public byte staminaCD;
        public byte staminaCD2;
        public byte staminaCD3;
        public bool blahArmor;
        public bool shadowTele;
        public bool teleportV = false;
        public bool tpStam = true;
        public int tpCD;
        public int astralCD;
        public int bubbleCD;
        public bool ancientLessCost;
        public bool ancientGunslinger;
        public bool ancientMinionGuide;
        public bool ancientSandVortex;
        public int ancientGunslingerTimer;
        public int ancientGunslingerStatAdd;
        public int baseUseTime;
        public int baseUseAnim;
        public bool oldLeftClick;
        public bool oblivionKill;
        public bool goBerserk;
        public bool splitProj;
        public bool spectrumSpeed;
        public bool spectrumBlur;
        public bool minionFreeze;
        public bool leafStorm;
        public bool thornMagic;
        public bool roseMagic;
        public int roseMagicCooldown;
        public bool avalonRestoration;
        public bool avalonRetribution;
        public int deliriumDuration = 300;
        public bool mermanLava;
        public int quadroCount;
        public int shadowWP = 0;
        public bool confusionTal;
        public bool shadowRO;
        public bool isNDown;
        public bool magnet;
        public Item tome;
        public bool ghostSilence;
        public bool ZoneTime;
        public bool ZoneBlight;
        public bool ZoneFright;
        public bool ZoneMight;
        public bool ZoneNight;
        public bool ZoneTorture;
        public bool ZoneIceSoul;
        public bool ZoneFlight;
        public bool ZoneHumidity;
        public bool ZoneDelight;
        public bool ZoneSight;
        public bool ZoneBooger;
        public bool ZoneDark;
        public bool ZoneComet;
        public bool ZoneHellcastle;
        public bool ZoneNearHellcastle;
        public bool ZoneDarkMatter;
        public bool ZoneTropics;
        public bool ZoneCaesium;
        public bool ZoneOutpost;
        public bool ZoneSkyFortress;
        public bool ZoneCrystal;
        public bool meleeStealth;
        
        public bool ammoCost70;
        public bool LightningInABottle;
        public bool longInvince2;
        public float kbIncrease;
        public bool accDivingSuit;
        public bool accDivingPants;
        public bool doubleJump5;
        public bool jumpAgain5;
        public bool dJumpEffect5;
        public bool doubleDamage;
        public bool frozen;
        public Color baseSkinTone;
        public bool bloodCast;
        public bool necroticAura;
        public bool reckoning;
        public int reckoningLevel;
        public int reckoningTimeLeft;
        public bool curseOfIcarus;
        public bool undeadTalisman;
        public bool cOmega;
        public bool pOmega;
        public bool noSticky;
        public bool astralStart;
        public bool vampireTeeth;
        public bool riftGoggles;
        public bool malaria;
        public bool caesiumPoison;
        public int caesiumTimer;
        public bool cloudGloves;
        public bool crystalEdge;
        public float bonusKB = 1f;
        public bool stingerPack;
        public bool UltraHMinion = false;
        public bool UltraRMinion = false;
        public bool UltraLMinion = false;
        // Adv Buffs
        public bool advAmmoBuff;

        public bool advArcheryBuff;
        public bool advBattleBuff;
        public bool advCalmingBuff;
        public bool advCrateBuff;

        #region Stinger Probe Minion AI vars

        public float StingerProbeRotTimer = 0;
        public int StingerProbeTimer = 0;
        public List<bool> StingerProbeActiveIds = new List<bool>();

        #endregion Dagger Staff Minion AI vars

        #region dagger staff vars
        public float daggerStaffRotTimer = 0;
        public int daggerStaffTimer = 0;
        public List<bool> daggerStaffActiveIDs = new List<bool>();
        #endregion

        public Vector2 MousePosition = default(Vector2);

        #region Dragon's Bondage AI vars

        public bool dragonsBondage;

        #endregion Dragon's Bondage AI vars

        public int herbX;
        public int herbY;
        public int potionTotal;
        public int herbTotal;
        public Dictionary<int, int> herbCounts = new Dictionary<int, int>();
        private int gemCount = 0;
        private bool[] ownedLargeGems = new bool[10];

        // Crit damage multiplyer vars
        public float critDamageMult = 1f;

        public enum HerbTier
        {
            Novice,
            Apprentice,
            Expert,
            Master
        }

        public HerbTier herbTier;

        #endregion fields

        public override bool CloneNewInstances => false;

        public override void ResetEffects()
        {
            //Main.NewText("" + trapImmune.ToString());
            //Main.NewText("" + slimeBand.ToString());
            Player.defaultItemGrabRange = 38;
            inertiaBoots = false;
            luckTome = false;
            blahWings = false;
            spikeImmune = false;
            staminaDrain = false;
            snotOrb = false;
            shockWave = false;
            stamFlower = false;
            staminaRegen = 1000;
            quackJump = false;
            bOfBacteria = false;
            stingerPack = false;
            crystalEdge = false;
            tpStam = true;
            riftGoggles = false;
            trapImmune = false;
            undeadTalisman = false;
            vampireTeeth = false;
            astralStart = false;
            cOmega = false;
            pOmega = false;
            slimeBand = false;
            noSticky = false;
            astralProject = false;
            advAmmoBuff = false;
            advArcheryBuff = false;
            advBattleBuff = false;
            advCalmingBuff = false;
            advCrateBuff = false;
            lucky = false;
            enemySpawns2 = false;
            bloodCast = false;
            mermanLava = false;
            magnet = false;
            bubbleBoost = false;
            darkInferno = false;
            melting = false;
            dragonsBondage = false;
            necroticAura = false;
            defDebuff = false;
            defDebuffBonusDef = 0;
            frozen = false;
            LightningInABottle = false;
            reckoning = false;
            hyperMagic = false;
            hyperMelee = false;
            hyperRanged = false;
            ancientLessCost = false;
            ancientGunslinger = false;
            ancientMinionGuide = false;
            ancientSandVortex = false;
            oblivionKill = false;
            goBerserk = false;
            splitProj = false;
            spectrumSpeed = false;
            spectrumBlur = false;
            minionFreeze = false;
            leafStorm = false;
            thornMagic = false;
            roseMagic = false;
            avalonRestoration = false;
            avalonRetribution = false;
            curseOfIcarus = false;
            malaria = false;
            primeMinion = false;
            hungryMinion = false;
            gastroMinion = false;
            reflectorMinion = false;
            iceGolem = false;
            caesiumPoison = false;
            goldDagger = false;
            platinumDagger = false;
            bismuthDagger = false;
            adamantiteDagger = false;
            titaniumDagger = false;
            troxiniumDagger = false;
            UltraHMinion = false;
            UltraRMinion = false;
            UltraLMinion = false;
            cloudGloves = false;
            bonusKB = 1f;

            if (shmAcc)
            {
                player.extraAccessory = true;
                player.extraAccessorySlots++;
            }

            critDamageMult = 1f;

            statStamMax2 = statStamMax;
        }

        public override void ModifyScreenPosition()
        {
            if (screenShakeTimer > 0)
            {
                Main.screenPosition += Main.rand.NextVector2Circular(20, 20);
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (darkInferno)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                if (duraShield && Main.rand.Next(6) == 0)
                {
                    player.lifeRegen += player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) ? 6 : 4;
                }
                else
                {
                    player.lifeRegen -= 16;
                }
            }
            if (caesiumPoison)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                if (duraShield && Main.rand.Next(6) == 0)
                {
                    player.lifeRegen += player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) ? 3 : 2;
                }
                else
                {
                    player.lifeRegen -= 20;
                }
            }
            if (melting)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 32;
            }
            if (malaria)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 30;
            }
        }

        public override void UpdateBiomes()
        {
            ZoneHellcastle = false;
            if (ExxoAvalonOriginsWorld.hellcastleTiles >= 350)
            {
                int num = (int)player.position.X / 16;
                int num2 = (int)player.position.Y / 16;
                if (Main.tile[num, num2].wall == ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
                {
                    ZoneHellcastle = true;
                }
            }
            ZoneNearHellcastle = ExxoAvalonOriginsWorld.hellcastleTiles >= 350;
            Point tileC = player.position.ToTileCoordinates();
            ZoneBooger = ExxoAvalonOriginsWorld.ickyTiles > 200;
            ZoneDarkMatter = ExxoAvalonOriginsWorld.darkTiles > 300;
            ZoneTropics = ExxoAvalonOriginsWorld.tropicTiles > 50;
            ZoneOutpost = ExxoAvalonOriginsWorld.tropicTiles > 50 && Main.tile[tileC.X, tileC.Y].wall == ModContent.WallType<Walls.TuhrtlBrickWallUnsafe>() && player.ZoneRockLayerHeight;
            ZoneCaesium = ExxoAvalonOriginsWorld.caesiumTiles > 200 && player.position.Y / 16 > Main.maxTilesY - 200;
            ZoneSkyFortress = ExxoAvalonOriginsWorld.skyFortressTiles > 50 && player.position.Y / 16 < 300;
            ZoneBlight = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.BlightCandle>());
            ZoneDelight = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.DelightCandle>());
            ZoneFlight = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.FlightCandle>());
            ZoneFright = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.FrightCandle>());
            ZoneHumidity = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.HumidityCandle>());
            ZoneIceSoul = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.IceCandle>());
            ZoneMight = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.MightCandle>());
            ZoneNight = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.NightCandle>());
            ZoneSight = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.SightCandle>());
            ZoneTime = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.TimeCandle>());
            ZoneTorture = ExxoAvalonOriginsWorld.AnyTiles(player, (ushort)ModContent.TileType<Tiles.SoulCandles.TortureCandle>());
            ZoneCrystal = ExxoAvalonOriginsWorld.crystalTiles > 100;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = ZoneHellcastle;
            flags[1] = ZoneBooger;
            flags[2] = ZoneDarkMatter;
            flags[3] = ZoneTropics;
            flags[4] = ZoneCaesium;
            flags[5] = ZoneOutpost;
            flags[6] = ZoneSkyFortress;
            flags[7] = ZoneCrystal;
            writer.Write(flags);
            var flags2 = new BitsByte();
            flags2[0] = ZoneBlight;
            flags2[1] = ZoneDelight;
            flags2[2] = ZoneFlight;
            flags2[3] = ZoneFright;
            flags2[4] = ZoneHumidity;
            flags2[5] = ZoneIceSoul;
            flags2[6] = ZoneMight;
            flags2[7] = ZoneNight;
            writer.Write(flags2);
            var flags3 = new BitsByte();
            flags3[0] = ZoneTime;
            flags3[1] = ZoneTorture;
            flags3[2] = ZoneSight;
            flags3[3] = ZoneNearHellcastle;
            writer.Write(flags3);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneHellcastle = flags[0];
            ZoneBooger = flags[1];
            ZoneDarkMatter = flags[2];
            ZoneTropics = flags[3];
            ZoneCaesium = flags[4];
            ZoneOutpost = flags[5];
            ZoneSkyFortress = flags[6];
            ZoneCrystal = flags[7];
            BitsByte flags2 = reader.ReadByte();
            ZoneBlight = flags2[0];
            ZoneDelight = flags2[1];
            ZoneFlight = flags2[2];
            ZoneFright = flags2[3];
            ZoneHumidity = flags2[4];
            ZoneIceSoul = flags2[5];
            ZoneMight = flags2[6];
            ZoneNight = flags2[7];
            BitsByte flags3 = reader.ReadByte();
            ZoneTime = flags3[0];
            ZoneTorture = flags3[1];
            ZoneSight = flags3[2];
            ZoneNearHellcastle = flags3[3];
        }

        public override void OnEnterWorld(Player player)
        {
            if (tomeItem.type <= ItemID.None)
            {
                tomeItem.SetDefaults();
            }

            Main.NewText("You are using Exxo Avalon: Origins " + ExxoAvalonOrigins.Mod.Version.ToString());
            Main.NewText("Please note that Exxo Avalon: Origins is in Beta; it may have many bugs");
            Main.NewText("Please also note that Exxo Avalon: Origins will interact strangely with other large mods");
            astralCD = 3600;
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (tomeItem.stack > 0)
            {
                player.VanillaUpdateEquip(tomeItem);
                player.VanillaUpdateAccessory(player.whoAmI, tomeItem, true, ref wallSpeedBuff, ref tileSpeedBuff,
                    ref tileRangeBuff);
            }
        }
        
        public override void PreUpdateBuffs()
        {
            //int[] array = new int[Main.maxProjectileTypes];
            //for (int j = 0; j < Main.projectile.Length; j++)
            //{
            //    if (Main.projectile[j].active && Main.projectile[j].owner == player.whoAmI)
            //    {
            //        array[Main.projectile[j].type]++;
            //    }
            //}

            for (int k = 0; k < player.buffType.Length; k++)
            {
                //if (player.buffType[k] == ModContent.BuffType<Buffs.Hungry>())
                //{
                //    if (array[ModContent.ProjectileType<HungrySummon>()] > 0)
                //    {
                //        hungryMinion = true;
                //    }
                //    if (!hungryMinion)
                //    {
                //        player.DelBuff(k);
                //        k--;
                //    }
                //    else
                //    {
                //        player.buffTime[k] = 18000;
                //    }
                //}
                //if (player.buffType[k] == ModContent.BuffType<Buffs.PrimeArms>())
                //{
                //    if (array[ModContent.ProjectileType<PriminiCannon>()] > 0 ||
                //        array[ModContent.ProjectileType<PriminiLaser>()] > 0 ||
                //        array[ModContent.ProjectileType<PriminiSaw>()] > 0 ||
                //        array[ModContent.ProjectileType<PriminiVice>()] > 0)
                //    {
                //        primeMinion = true;
                //    }
                //    if (!primeMinion)
                //    {
                //        player.DelBuff(k);
                //        k--;
                //    }
                //    else
                //    {
                //        player.buffTime[k] = 18000;
                //    }
                //}

                if (player.buffType[k] == 37)
                {
                    if (Main.wof >= 0 && Main.npc[Main.wof].type == NPCID.WallofFlesh || ExxoAvalonOriginsWorld.wos >= 0 && Main.npc[ExxoAvalonOriginsWorld.wos].type == ModContent.NPCType<NPCs.Bosses.WallofSteel>())
                    {
                        player.gross = true;
                        player.buffTime[k] = 10;
                    }
                    else
                    {
                        player.DelBuff(k);
                        k--;
                    }
                }
            }
        }
        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            #region spike cannon logic
            if (item.type == ModContent.ItemType<Items.Weapons.Ranged.SpikeCannon>() || item.type == ModContent.ItemType<Items.Weapons.Ranged.SpikeRailgun>())
            {
                Item item2 = new Item();
                bool flag7 = false;
                bool inAmmoSlots = false;
                for (int i = 54; i < 58; i++)
                {
                    if (player.inventory[i].ammo == player.inventory[player.selectedItem].useAmmo && player.inventory[i].stack > 0)
                    {
                        item2 = player.inventory[i];
                        flag7 = true;
                        inAmmoSlots = true;
                        break;
                    }
                }
                if (!inAmmoSlots)
                {
                    for (int i = 0; i < 54; i++)
                    {
                        if (player.inventory[i].ammo == player.inventory[player.selectedItem].useAmmo && player.inventory[i].stack > 0)
                        {
                            item2 = player.inventory[i];
                            flag7 = true;
                            //Main.NewText(item2.Name);
                            break;
                        }
                    }
                }
                if (flag7)
                {
                    if (player.inventory[player.selectedItem].useAmmo == ItemID.Spike)
                    {
                        int t = 0;
                        int dmgAdd = 0;
                        //Main.NewText(item2.Name);
                        /*switch (item2.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike)
                        {
                            case 0:
                                t = ModContent.ProjectileType<SpikeCannon>();
                                dmgAdd = 11;
                                break;
                            case 1:
                                t = ModContent.ProjectileType<DemonSpikeScale>();
                                dmgAdd = 17;
                                break;
                            case 2:
                                t = ModContent.ProjectileType<BloodiedSpike>();
                                dmgAdd = 17;
                                break;
                            case 3:
                                t = ModContent.ProjectileType<NastySpike>();
                                dmgAdd = 18;
                                break;
                            case 4:
                                t = ModContent.ProjectileType<WoodenSpike>();
                                dmgAdd = 30;
                                break;
                            case 5:
                                t = ModContent.ProjectileType<VenomSpike>();
                                dmgAdd = 39;
                                break;
                            case 6:
                                t = ModContent.ProjectileType<PoisonSpike>();
                                dmgAdd = 15;
                                break;
                        }*/
                        if (item2.type == ItemID.Spike)
                        {
                            t = ModContent.ProjectileType<SpikeCannon>();
                            dmgAdd = 11;
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Tile.DemonSpikeScale>())
                        {
                            t = ModContent.ProjectileType<DemonSpikeScale>();
                            dmgAdd = 17;
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Tile.BloodiedSpike>())
                        {
                            t = ModContent.ProjectileType<BloodiedSpike>();
                            dmgAdd = 17;
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Tile.NastySpike>())
                        {
                            t = ModContent.ProjectileType<NastySpike>();
                            dmgAdd = 18;
                        }
                        else if (item2.type == ItemID.WoodenSpike)
                        {
                            t = ModContent.ProjectileType<WoodenSpike>();
                            dmgAdd = 30;
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Tile.VenomSpike>())
                        {
                            t = ModContent.ProjectileType<VenomSpike>();
                            dmgAdd = 39;
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Tile.PoisonSpike>())
                        {
                            t = ModContent.ProjectileType<PoisonSpike>();
                            dmgAdd = 15;
                        }
                        if (t > 0)
                        {
                            if (item.type == ModContent.ItemType<Items.Weapons.Ranged.SpikeRailgun>())
                            {
                                float num87 = MathHelper.Pi / 10;
                                int num88 = 3;
                                Vector2 vector2 = new Vector2(speedX, speedY);
                                vector2.Normalize();
                                vector2 *= 40f;
                                for (int num89 = 0; num89 < num88; num89++)
                                {
                                    float num90 = num89 - (num88 - 1f) / 2f;
                                    Vector2 vector3 = vector2.Rotate(num87 * num90, default);
                                    int num91 = Projectile.NewProjectile(position.X + vector3.X, position.Y + vector3.Y, speedX, speedY, t, damage + dmgAdd, knockBack, player.whoAmI, 0f, 0f);
                                }
                                Main.NewText(t);
                                return false;
                            }
                            Projectile.NewProjectile(position, new Vector2(speedX, speedY), t, damage + dmgAdd, knockBack, player.whoAmI);
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region torch launcher logic
            if (item.type == ModContent.ItemType<TorchLauncher>())
            {
                Item item2 = new Item();
                bool flag7 = false;
                bool inAmmoSlots = false;
                for (int i = 54; i < 58; i++)
                {
                    if (player.inventory[i].ammo == player.inventory[player.selectedItem].useAmmo && player.inventory[i].stack > 0)
                    {
                        item2 = player.inventory[i];
                        flag7 = true;
                        inAmmoSlots = true;
                        break;
                    }
                }
                if (!inAmmoSlots)
                {
                    for (int i = 0; i < 54; i++)
                    {
                        if (player.inventory[i].ammo == player.inventory[player.selectedItem].useAmmo && player.inventory[i].stack > 0)
                        {
                            item2 = player.inventory[i];
                            flag7 = true;
                            break;
                        }
                    }
                }
                if (flag7)
                {
                    if (player.inventory[player.selectedItem].useAmmo == 8)
                    {
                        int t = 0;
                        if (torches.TryGetValue(item2.type, out t))
                        {
                            Projectile.NewProjectile(position, new Vector2(speedX, speedY), t, 0, 0);
                            return false;
                        }
                        else return base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
                        /*if (item2.type == ItemID.Torch)
                        {
                            t = ModContent.ProjectileType<Torch>();
                        }
                        else if (item2.type == ItemID.BlueTorch)
                        {
                            t = ModContent.ProjectileType<BlueTorch>();
                        }
                        else if (item2.type == ItemID.RedTorch)
                        {
                            t = ModContent.ProjectileType<RedTorch>();
                        }
                        else if (item2.type == ItemID.GreenTorch)
                        {
                            t = ModContent.ProjectileType<GreenTorch>();
                        }
                        else if (item2.type == ItemID.PurpleTorch)
                        {
                            t = ModContent.ProjectileType<PurpleTorch>();
                        }
                        else if (item2.type == ItemID.WhiteTorch)
                        {
                            t = ModContent.ProjectileType<WhiteTorch>();
                        }
                        else if (item2.type == ItemID.YellowTorch)
                        {
                            t = ModContent.ProjectileType<YellowTorch>();
                        }
                        else if (item2.type == ItemID.DemonTorch)
                        {
                            t = ModContent.ProjectileType<DemonTorch>();
                        }
                        else if (item2.type == ItemID.CursedTorch)
                        {
                            t = ModContent.ProjectileType<CursedTorch>();
                        }
                        else if (item2.type == ItemID.IceTorch)
                        {
                            t = ModContent.ProjectileType<IceTorch>();
                        }
                        else if (item2.type == ItemID.OrangeTorch)
                        {
                            t = ModContent.ProjectileType<OrangeTorch>();
                        }
                        else if (item2.type == ItemID.IchorTorch)
                        {
                            t = ModContent.ProjectileType<IchorTorch>();
                        }
                        else if (item2.type == ItemID.UltrabrightTorch)
                        {
                            t = ModContent.ProjectileType<UltrabrightTorch>();
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Light.JungleTorch>())
                        {
                            t = ModContent.ProjectileType<JungleTorch>();
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Light.PathogenTorch>())
                        {
                            t = ModContent.ProjectileType<PathogenTorch>();
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Light.SlimeTorch>())
                        {
                            t = ModContent.ProjectileType<SlimeTorch>();
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Light.CyanTorch>())
                        {
                            t = ModContent.ProjectileType<CyanTorch>();
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Light.LimeTorch>())
                        {
                            t = ModContent.ProjectileType<LimeTorch>();
                        }
                        else if (item2.type == ModContent.ItemType<Items.Placeable.Light.BrownTorch>())
                        {
                            t = ModContent.ProjectileType<BrownTorch>();
                        }
                        else if (item2.type == ItemID.BoneTorch)
                        {
                            t = ModContent.ProjectileType<BoneTorch>();
                        }
                        else if (item2.type == ItemID.RainbowTorch)
                        {
                            t = ModContent.ProjectileType<RainbowTorch>();
                        }
                        else if (item2.type == ItemID.PinkTorch)
                        {
                            t = ModContent.ProjectileType<PinkTorch>();
                        }
                        */
                        //if (t > 0)
                        //{
                        //    Projectile.NewProjectile(position, new Vector2(speedX, speedY), t, 0, 0);
                        //    return false;
                        //}
                    }
                }
            }
            #endregion
            return base.Shoot(item, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public void WOSTongue()
        {
            if (ExxoAvalonOriginsWorld.wos >= 0 && Main.npc[ExxoAvalonOriginsWorld.wos].active)
            {
                float num = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + 40f;
                if (Main.npc[ExxoAvalonOriginsWorld.wos].direction > 0)
                {
                    num -= 96f;
                }
                if (player.position.X + player.width > num && player.position.X < num + 140f && player.gross)
                {
                    player.noKnockback = false;
                    player.Hurt(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 50, Main.npc[ExxoAvalonOriginsWorld.wos].direction);
                }
                if (!player.gross && player.position.Y > (Main.maxTilesY - 250) * 16 && player.position.X > num - 1920f && player.position.X < num + 1920f)
                {
                    player.AddBuff(37, 10, true);
                    //Main.PlaySound(4, (int)Main.npc[ExxoAvalonOriginsWorld.wos].position.X, (int)Main.npc[ExxoAvalonOriginsWorld.wos].position.Y, 10);
                }
                if (player.gross)
                {
                    if (player.position.Y < (Main.maxTilesY - 200) * 16)
                    {
                        player.AddBuff(38, 10, true);
                    }
                    if (Main.npc[ExxoAvalonOriginsWorld.wos].direction < 0)
                    {
                        if (player.position.X + player.width / 2 > Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2 + 40f)
                        {
                            player.AddBuff(38, 10, true);
                        }
                    }
                    else if (player.position.X + player.width / 2 < Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2 - 40f)
                    {
                        player.AddBuff(38, 10, true);
                    }
                }
                if (player.tongued)
                {
                    player.controlHook = false;
                    player.controlUseItem = false;
                    for (int i = 0; i < 1000; i++)
                    {
                        if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].aiStyle == 7)
                        {
                            Main.projectile[i].Kill();
                        }
                    }
                    var vector = new Vector2(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f);
                    float num2 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2 - vector.X;
                    float num3 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + Main.npc[ExxoAvalonOriginsWorld.wos].height / 2 - vector.Y;
                    float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
                    if (num4 > 3000f)
                    {
                        //player.lastPosBeforeDeath = this.position;
                        player.KillMe(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 1000.0, 0, false);
                        return;
                    }
                    if (Main.npc[ExxoAvalonOriginsWorld.wos].position.X < 608f || Main.npc[ExxoAvalonOriginsWorld.wos].position.X > (Main.maxTilesX - 38) * 16)
                    {
                        //this.lastPosBeforeDeath = this.position;
                        player.KillMe(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 1000.0, 0, false);
                    }
                }
            }
        }

        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            bool consume = true;
            // 30% chance to not consume ammo
            if (advAmmoBuff && Main.rand.Next(10) < 3)
            {
                consume = false;
            }

            if (tomeItem.type == ModContent.ItemType<CreatorsTome>() && Main.rand.Next(4) == 0)
            {
                consume = false;
            }

            if ((tomeItem.type == ModContent.ItemType<TomeofDistance>() || tomeItem.type == ModContent.ItemType<Dominance>() || tomeItem.type == ModContent.ItemType<LoveUpandDown>()) && Main.rand.Next(5) == 0)
            {
                consume = false;
            }

            if ((tomeItem.type == ModContent.ItemType<ThePlumHarvest>() || tomeItem.type == ModContent.ItemType<Emperor>()) && Main.rand.Next(10) < 3)
            {
                consume = false;
            }

            if (!consume)
            {
                return false;
            }
            else
            {
                return base.ConsumeAmmo(weapon, ammo);
            }
        }

        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            if (item.useAmmo == AmmoID.Arrow && advArcheryBuff)
            {
                mult *= 1.4f;
            }
            base.ModifyWeaponDamage(item, ref add, ref mult, ref flat);
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (terraClaws && item.melee)
            {
                switch (Main.rand.Next(5))
                {
                    case 0:
                        target.AddBuff(BuffID.OnFire, 9 * 60);
                        break;
                    case 1:
                        target.AddBuff(BuffID.Poisoned, 9 * 60);
                        break;
                    case 2:
                        target.AddBuff(BuffID.Venom, 9 * 60);
                        break;
                    case 3:
                        target.AddBuff(BuffID.Frostburn, 9 * 60);
                        break;
                    case 4:
                        target.AddBuff(BuffID.Ichor, 9 * 60);
                        break;
                }
            }
            if (ancientSandVortex && Main.rand.Next(10) == 0)
            {
                Projectile.NewProjectile(target.position, Vector2.Zero, ModContent.ProjectileType<AncientSandnado>(), 0, 0);
            }
            if (vampireTeeth)
            {
                if (item.melee)
                {
                    if (target.boss)
                    {
                        player.VampireHeal(damage / 2, target.Center);
                    }
                    else
                    {
                        player.VampireHeal(damage, target.Center);
                    }
                }
            }
            if (crit)
            {
                if (Main.rand.Next(8) == 0)
                {
                    if (player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                    {
                        reckoningLevel += 1;
                    }
                }

                if (avalonRestoration)
                {
                    player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (minionFreeze)
            {
                if (proj.minion || minionProjectile.Contains(proj.type))
                {
                    if (CanBeFrozen.CanFreeze(target))
                    {
                        target.AddBuff(ModContent.BuffType<Buffs.MinionFrozen>(), 60);
                    }
                }
            }

            if (roseMagic)
            {
                if (proj.magic)
                {
                    if (Main.rand.Next(8) == 0 && roseMagicCooldown <= 0)
                    {
                        int num36 = Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, ModContent.ItemType<Rosebud>());
                        Main.item[num36].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                        Main.item[num36].velocity.X = Main.rand.Next(10, 31) * 0.2f * player.direction;
                        roseMagicCooldown = 20;
                    }
                }
            }

            if (target.life <= 0)
            {
                if (ancientGunslinger)
                {
                    if (proj.owner == Main.myPlayer && proj.ranged)
                    {
                        Projectile.NewProjectile(target.position, Vector2.Zero, ModContent.ProjectileType<SandyExplosion>(), damage * 2, knockback);
                    }
                }
            }

            if (crit)
            {
                if (Main.rand.Next(8) == 0)
                {
                    if (player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                    {
                        reckoningLevel += 1;
                    }
                }

                if (avalonRestoration)
                {
                    player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
                }
            }
        }

        public override void OnHitPvp(Item item, Player target, int damage, bool crit)
        {
            if (crit)
            {
                if (Main.rand.Next(8) == 0)
                {
                    if (player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                    {
                        reckoningLevel += 1;
                    }
                }

                if (avalonRestoration)
                {
                    player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
                }
            }
        }

        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit)
        {
            if (minionFreeze)
            {
                if (proj.minion || minionProjectile.Contains(proj.type))
                {
                    target.AddBuff(ModContent.BuffType<Buffs.MinionFrozen>(), 60);
                }
            }

            if (crit)
            {
                if (Main.rand.Next(8) == 0)
                {
                    if (player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                    {
                        reckoningLevel += 1;
                    }
                }

                if (avalonRestoration)
                {
                    player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
                }
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (stingerPack)
            {
                float shootSpeed = 6f;
                Vector2 center = player.Center;
                Main.PlaySound(2, player.position, 17);
                float num572 = (float)Math.Atan2(center.Y - npc.Center.Y, center.X - npc.Center.X);
                for (float f = 0f; f <= 3.6f; f += 0.4f)
                {
                    int proj = Projectile.NewProjectile(center.X, center.Y, (float)(Math.Cos(num572 + f) * shootSpeed * -1), (float)(Math.Sin(num572 + f) * shootSpeed * -1.0), ProjectileID.Stinger, 60, 0f, 0, 0f, 0f);
                    Main.projectile[proj].timeLeft = 600;
                    Main.projectile[proj].tileCollide = false;
                    Main.projectile[proj].hostile = false;
                    Main.projectile[proj].friendly = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), proj, 0f, 0f, 0f, 0);
                    }
                    proj = Projectile.NewProjectile(center.X, center.Y, (float)(Math.Cos(num572 - f) * shootSpeed * -1), (float)(Math.Sin(num572 - f) * shootSpeed * -1.0), ProjectileID.Stinger, 60, 0f, 0, 0f, 0f);
                    Main.projectile[proj].timeLeft = 600;
                    Main.projectile[proj].tileCollide = false;
                    Main.projectile[proj].hostile = false;
                    Main.projectile[proj].friendly = true;
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), proj, 0f, 0f, 0f, 0);
                    }
                }
            }
            if (auraThorns && !player.immune && !npc.dontTakeDamage)
            {
                int x = (int)player.position.X;
                int y = (int)player.position.Y;
                foreach (NPC N2 in Main.npc)
                {
                    if (N2.position.X >= x - 620 && N2.position.X <= x + 620 && N2.position.Y >= y - 620 && N2.position.Y <= y + 620)
                    {
                        if (!N2.active || N2.dontTakeDamage || N2.townNPC || N2.life < 1 || N2.boss || N2.realLife >= 0 || N2.type == ModContent.NPCType<NPCs.Juggernaut>())
                        {
                            continue;
                        }

                        N2.StrikeNPC(damage, 5f, 1);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.StrikeNPC, -1, -1, NetworkText.FromLiteral(""), N2.whoAmI, damage, 0f, 0f, 0);
                        }
                    }
                }
            }
            if (doubleDamage && !player.immune && !npc.dontTakeDamage)
            {
                npc.StrikeNPC(npc.damage * 2, 2f, 1);
            }
            if (avalonRetribution && damage > 0)
            {
                npc.AddBuff(ModContent.BuffType<CurseofAvalon>(), 100);
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (crystalEdge)
            {
                damage += 15;
            }
            if (player.HasBuff(ModContent.BuffType<Buffs.BacteriaEndurance>()))
            {
                damage += 8;
            }
            if (target.HasBuff(ModContent.BuffType<Buffs.AstralCurse>()))
            {
                damage *= 3;
            }
            if (target.HasBuff(ModContent.BuffType<Buffs.CurseofAvalon>()))
            {
                damage *= 4;
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Buffs.CurseofAvalon>()));
            }

            if (hyperMelee)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25)
                    {
                        hyperBar = 0;
                    }
                }
            }
            if (confusionTal && Main.rand.Next(100) <= 12)
            {
                target.AddBuff(BuffID.Confused, 540);
            }
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<GoldSwordNet>() || player.inventory[player.selectedItem].type == ModContent.ItemType<ExcaliburNet>() || player.inventory[player.selectedItem].type == ModContent.ItemType<Oblivionet>() || player.inventory[player.selectedItem].type == ModContent.ItemType<PlatinumSwordNet>() || player.inventory[player.selectedItem].type == ModContent.ItemType<BismuthSwordNet>())
            {
                if (target.catchItem > 0)
                {
                    NPC.CatchNPC(target.whoAmI, player.whoAmI);
                }
            }
            if (crit)
            {
                damage += MultiplyCritDamage(damage);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (crystalEdge)
            {
                damage += 15;
            }
            if (player.HasBuff(ModContent.BuffType<Buffs.BacteriaEndurance>()))
            {
                damage += 8;
            }
            
            if (target.HasBuff(ModContent.BuffType<Buffs.AstralCurse>()))
            {
                damage *= 3;
            }
            if (target.HasBuff(ModContent.BuffType<Buffs.CurseofAvalon>()) &&
                proj.type != ProjectileID.HallowStar &&
                proj.type != ModContent.ProjectileType<Leaves>() &&
                proj.type != ModContent.ProjectileType<LightningBolt>() &&
                proj.type != ModContent.ProjectileType<LightningTrail>())
            {
                damage *= 4;
                target.DelBuff(target.FindBuffIndex(ModContent.BuffType<Buffs.CurseofAvalon>()));
            }

            if (hyperMelee && proj.melee)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25)
                    {
                        hyperBar = 0;
                    }
                }
            }
            if (hyperRanged && proj.ranged)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25)
                    {
                        hyperBar = 0;
                    }
                }
            }
            if (hyperMagic && proj.magic)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25)
                    {
                        hyperBar = 0;
                    }
                }
            }

            if (minionFreeze)
            {
                if (proj.minion || minionProjectile.Contains(proj.type))
                {
                    if (target.HasBuff(ModContent.BuffType<Buffs.MinionFrozen>()) || !CanBeFrozen.CanFreeze(target))
                    {
                        damage = (int)(damage * 1.10f);
                    }
                }
            }

            if (crit)
            {
                damage += MultiplyCritDamage(damage);
            }
        }

        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit)
        {
            if (crit)
            {
                damage += MultiplyCritDamage(damage);
            }
        }

        public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit)
        {
            if (minionFreeze)
            {
                if (proj.minion || minionProjectile.Contains(proj.type))
                {
                    if (target.HasBuff(ModContent.BuffType<Buffs.MinionFrozen>()))
                    {
                        damage = (int)(damage * 1.10f);
                    }
                }
            }

            if (crit)
            {
                damage += MultiplyCritDamage(damage);
            }
        }

        public int MultiplyCritDamage(int dmg) // dmg = damage befor crit application
        {
            int bonusDmg = -dmg;
            bonusDmg += (int)((dmg * (critDamageMult + 1f)) / 2);
            return bonusDmg;
        }

        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            if (player.HasItemInArmor(ModContent.ItemType<ShadowRing>()))
            {
                drawInfo.shadow = 0f;
            }
            if (blahArmor)
            {
                drawInfo.shadow = 0f;
            }
            if (spectrumBlur)
            {
                player.eocDash = 1;
            }
            if (mermanLava)
            {
                Main.armorHeadTexture[39] = lavaMermanTextures[0];
                Main.armorBodyTexture[22] = lavaMermanTextures[1];
                Main.armorArmTexture[22] = lavaMermanTextures[2];
                Main.femaleBodyTexture[22] = lavaMermanTextures[3];
                Main.armorLegTexture[21] = lavaMermanTextures[4];
            }
            else
            {
                Main.armorHeadTexture[39] = originalMermanTextures[0];
                Main.armorBodyTexture[22] = originalMermanTextures[1];
                Main.armorArmTexture[22] = originalMermanTextures[2];
                Main.femaleBodyTexture[22] = originalMermanTextures[3];
                Main.armorLegTexture[21] = originalMermanTextures[4];
            }
            //if (frozen)
            //{
            //    if (drawInfo.bodyColor == baseSkinTone)
            //        drawInfo.bodyColor = new Color(0f, baseSkinTone.G * 0.639f, default, default);
            //}
            //else
            //{
            //    if (drawInfo.bodyColor != baseSkinTone && baseSkinTone != new Color())
            //        drawInfo.bodyColor = baseSkinTone;
            //    else
            //        baseSkinTone = drawInfo.bodyColor;
            //}
        }

        public override void UpdateLifeRegen()
        {
            if (duraShield && Main.rand.Next(6) == 0)
            {
                if (player.poisoned)
                {
                    int num = 2;
                    if (player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                    {
                        num = 4;
                    }

                    player.lifeRegen += num + 4;
                }
                else if (player.venom || player.frostBurn || player.onFire2)
                {
                    int num2 = 2;
                    if (player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                    {
                        num2 = 4;
                    }
                    player.lifeRegen += num2 + 12;
                }
                else if (player.onFire)
                {
                    int num3 = 2;
                    if (player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                    {
                        num3 = 4;
                    }
                    player.lifeRegen += num3 + 8;
                }
                else if (darkInferno)
                {
                    int num6 = 4;
                    if (player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                    {
                        num6 = 8;
                    }
                    player.lifeRegen += num6 + 16;
                }
            }
            UpdateStaminaRegen();
        }

        public override TagCompound Save()
        {
            var tag = new TagCompound
            {
                { "ExxoAvalonOrigins:TomeSlot", ItemIO.Save(tomeItem) },
                { "ExxoAvalonOrigins:CrystalHealth", crystalHealth },
                { "ExxoAvalonOrigins:Stamina", statStamMax},
                { "ExxoAvalonOrigins:SHMAcc", shmAcc },
                { "ExxoAvalonOrigins:HerbTier", (int)herbTier },
                { "ExxoAvalonOrigins:HerbTotal", herbTotal },
                { "ExxoAvalonOrigins:PotionTotal", potionTotal },
                { "ExxoAvalonOrigins:HerbCounts", herbCounts.Save() },
                { "ExxoAvalonOrigins:SpiritPoppyUseCount", spiritPoppyUseCount },
                { "ExxoAvalonOrigins:RocketJumpUnlocked", rocketJumpUnlocked },
                { "ExxoAvalonOrigins:TeleportUnlocked", teleportUnlocked},
                { "ExxoAvalonOrigins:SwimmingUnlocked", swimmingUnlocked },
                { "ExxoAvalonOrigins:SprintUnlocked", sprintUnlocked },
                { "ExxoAvalonOrigins:FlightRestoreUnlocked", flightRestoreUnlocked },
            };
            return tag;
        }
        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("ExxoAvalonOrigins:TomeSlot"))
            {
                tomeItem = ItemIO.Load(tag.Get<TagCompound>("ExxoAvalonOrigins:TomeSlot"));
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:CrystalHealth"))
            {
                crystalHealth = tag.GetAsInt("ExxoAvalonOrigins:CrystalHealth");
                if (crystalHealth > 4)
                {
                    crystalHealth = 4;
                }

                if (player.statLifeMax == 500)
                {
                    player.statLifeMax += crystalHealth *= 25;
                    player.statLifeMax2 += crystalHealth *= 25;
                }
            }

            if (tag.ContainsKey("ExxoAvalonOrigins:Stamina"))
            {
                statStamMax = tag.GetAsInt("ExxoAvalonOrigins:Stamina");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:SHMAcc"))
            {
                shmAcc = tag.Get<bool>("ExxoAvalonOrigins:SHMAcc");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:HerbTier"))
            {
                herbTier = (HerbTier)tag.GetAsInt("ExxoAvalonOrigins:HerbTier");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:HerbTotal"))
            {
                herbTotal = tag.GetAsInt("ExxoAvalonOrigins:HerbTotal");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:PotionTotal"))
            {
                potionTotal = tag.GetAsInt("ExxoAvalonOrigins:PotionTotal");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:HerbCounts"))
            {
                try
                {
                    herbCounts.Load(tag.Get<TagCompound>("ExxoAvalonOrigins:HerbCounts"));
                }
                catch
                {
                    herbCounts = new Dictionary<int, int>();
                }
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:SpiritPoppyUseCount"))
            {
                spiritPoppyUseCount = tag.Get<int>("ExxoAvalonOrigins:SpiritPoppyUseCount");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:RocketJumpUnlocked"))
            {
                rocketJumpUnlocked = tag.Get<bool>("ExxoAvalonOrigins:RocketJumpUnlocked");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:TeleportUnlocked"))
            {
                teleportUnlocked = tag.Get<bool>("ExxoAvalonOrigins:TeleportUnlocked");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:SwimmingUnlocked"))
            {
                swimmingUnlocked = tag.Get<bool>("ExxoAvalonOrigins:SwimmingUnlocked");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:SprintUnlocked"))
            {
                sprintUnlocked = tag.Get<bool>("ExxoAvalonOrigins:SprintUnlocked");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:FlightRestoreUnlocked"))
            {
                flightRestoreUnlocked = tag.Get<bool>("ExxoAvalonOrigins:FlightRestoreUnlocked");
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (ExxoAvalonOrigins.GodMode)
            {
                return false;
            }

            if (spectrumBlur && player.whoAmI == Main.myPlayer && Main.rand.Next(10) == 0)
            {
                SpectrumDodge();
                return false;
            }
            return true;
        }

        public override void PostUpdate()
        {
            //Main.worldRate = 7;
            #region player sensor
            int pposX = (int)(player.position.X / 16);
            int pposY = (int)(player.position.Y / 16);
            int pposXOld = (int)(player.oldPosition.X / 16);
            int pposYOld = (int)(player.oldPosition.Y / 16);
            // x, y
            if (Main.tile[pposX, pposY].type == ModContent.TileType<Tiles.PlayerSensor>())
            {
                if (!pSensor[0])
                {
                    Main.PlaySound(28, pposX * 16, pposY * 16, 0);
                    Wiring.TripWire(pposX, pposY, 1, 1);
                    pSensor[0] = true;
                }
            }
            else pSensor[0] = false;
            // x + 1, y
            if (Main.tile[pposX + 1, pposY].type == ModContent.TileType<Tiles.PlayerSensor>())
            {
                if (!pSensor[1])
                {
                    Main.PlaySound(28, (pposX + 1) * 16, pposY * 16, 0);
                    Wiring.TripWire(pposX + 1, pposY, 1, 1);
                    pSensor[1] = true;
                }
            }
            else pSensor[1] = false;
            // x, y + 1
            if (Main.tile[pposX, pposY + 1].type == ModContent.TileType<Tiles.PlayerSensor>())
            {
                if (!pSensor[2])
                {
                    Main.PlaySound(28, pposX * 16, (pposY + 1) * 16, 0);
                    Wiring.TripWire(pposX, pposY + 1, 1, 1);
                    pSensor[2] = true;
                }
            }
            else pSensor[2] = false;
            // x + 1, y + 1
            if (Main.tile[pposX + 1, pposY + 1].type == ModContent.TileType<Tiles.PlayerSensor>())
            {
                if (!pSensor[3])
                {
                    Main.PlaySound(28, (pposX + 1) * 16, (pposY + 1) * 16, 0);
                    Wiring.TripWire(pposX + 1, pposY + 1, 1, 1);
                    pSensor[3] = true;
                }
            }
            else pSensor[3] = false;
            // x, y + 2
            if (Main.tile[pposX, pposY + 2].type == ModContent.TileType<Tiles.PlayerSensor>())
            {
                if (!pSensor[4])
                {
                    Main.PlaySound(28, pposX * 16, (pposY + 2) * 16, 0);
                    Wiring.TripWire(pposX, pposY + 2, 1, 1);
                    pSensor[4] = true;
                }
            }
            else pSensor[4] = false;
            // x + 1, y + 1
            if (Main.tile[pposX + 1, pposY + 2].type == ModContent.TileType<Tiles.PlayerSensor>())
            {
                if (!pSensor[5])
                {
                    Main.PlaySound(28, (pposX + 1) * 16, (pposY + 2) * 16, 0);
                    Wiring.TripWire(pposX + 1, pposY + 2, 1, 1);
                    pSensor[5] = true;
                }
            }
            else pSensor[5] = false;
            #endregion
            //for (int pposX = (int)(player.position.X / 16); pposX <= (int)(player.position.X / 16) + 1; pposX++)
            //{
            //    for (int pposY = (int)(player.position.Y / 16); pposY <= (int)(player.position.Y / 16) + 2; pposY++)
            //    {
            //        if (Main.tile[pposX, pposY].type == ModContent.TileType<Tiles.PlayerSensor>())
            //        {
            //            if (!pSensor)
            //            {
            //                Main.PlaySound(28, pposX * 16, pposY * 16, 0);
            //                Wiring.SkipWire(pposX, pposY);
            //                Wiring.TripWire(pposX, pposY, 1, 1);
            //                pSensor = true;
            //                break;
            //            }
            //        }
            //        else pSensor = false;
            //    }
            //}
            if (magnet)
            {
                Player.defaultItemGrabRange = 114;
            }

            //player.statMana = statMana;
            if (!astralProject && player.HasBuff(ModContent.BuffType<AstralProjecting>()))
            {
                player.DelBuff(ModContent.BuffType<AstralProjecting>());
            }
            if (screenShakeTimer == 1)
            {
                Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 14);
            }
            if (screenShakeTimer > 0)
            {
                screenShakeTimer--;
            }

            Vector2 pposTile = player.Center / 16;
            for (int xpos = (int)pposTile.X - 4; xpos <= (int)pposTile.X + 4; xpos++)
            {
                for (int ypos = (int)pposTile.Y - 4; ypos <= (int)pposTile.Y + 4; ypos++)
                {
                    if (Main.tile[xpos, ypos].type == (ushort)ModContent.TileType<Tiles.Ores.TritanoriumOre>() || Main.tile[xpos, ypos].type == (ushort)ModContent.TileType<Tiles.Ores.PyroscoricOre>())
                    {
                        if (!luckTome && !blahWings)
                        {
                            player.AddBuff(ModContent.BuffType<Melting>(), 60);
                        }
                    }
                }
            }

            if (ZoneFlight) player.slowFall = true; // doesn't work
            if (ZoneFright) player.statDefense += 5;
            if (ZoneIceSoul) slimeBand = true; // doesn't work
            if (ZoneMight) player.allDamage += 0.06f;
            if (ZoneNight) player.wolfAcc = true;
            if (ZoneTime) player.accWatch = 3;
            if (ZoneTorture) player.AllCrit(6);
            if (ZoneSight) player.detectCreature = player.dangerSense = player.nightVision = true;
            if (ZoneDelight) player.lifeRegen += 3;
            if (ZoneHumidity) player.resistCold = true;
            if (ZoneBlight) player.armorPenetration += 10;

            #region rift goggles

            if (player.ZoneCrimson || player.ZoneCorrupt || ZoneBooger)
            {
                if (Main.rand.Next(3000) == 0 && riftGoggles)
                {
                    Vector2 pposTile2 = player.position + new Vector2(Main.rand.Next(-20 * 16, 21 * 16), Main.rand.Next(-20 * 16, 21 * 16));
                    Point pt = pposTile2.ToTileCoordinates();
                    if (!Main.tile[pt.X, pt.Y].active())
                    {
                        int proj = NPC.NewNPC(pt.X * 16, pt.Y * 16, ModContent.NPCType<NPCs.Rift>(), 0);
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, proj);
                        }

                        for (int i = 0; i < 20; i++)
                        {
                            int num893 = Dust.NewDust(Main.npc[proj].position, Main.npc[proj].width, Main.npc[proj].height, DustID.Enchanted_Pink, 0f, 0f, 0, default, 1f);
                            Main.dust[num893].velocity *= 2f;
                            Main.dust[num893].scale = 0.9f;
                            Main.dust[num893].noGravity = true;
                            Main.dust[num893].fadeIn = 3f;
                        }
                    }
                }
            }
            if (riftGoggles && Main.rand.Next(5000) == 0)
            {
                if (player.ZoneRockLayerHeight)
                {
                    Vector2 pposTile2 = player.position + new Vector2(Main.rand.Next(-35 * 16, 35 * 16), Main.rand.Next(-35 * 16, 35 * 16));
                    Point pt = pposTile2.ToTileCoordinates();
                    int proj = NPC.NewNPC(pt.X * 16, pt.Y * 16, ModContent.NPCType<NPCs.Rift>(), ai1: 1);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, proj);
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        int num893 = Dust.NewDust(Main.npc[proj].position, Main.npc[proj].width, Main.npc[proj].height, DustID.Enchanted_Pink, 0f, 0f, 0, default, 1f);
                        Main.dust[num893].velocity *= 2f;
                        Main.dust[num893].scale = 0.9f;
                        Main.dust[num893].noGravity = true;
                        Main.dust[num893].fadeIn = 3f;
                    }
                }
            }

            #endregion rift goggles

            if (player.HasItemInArmor(ModContent.ItemType<ShadowRing>()))
            {
                player.shadow = 0f;
            }

            if (blahArmor)
            {
                player.shadow = 0f;
            }
            // Herbology bench distance check
            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb)
            {
                int num9 = (int)((player.position.X + player.width * 0.5) / 16.0);
                int num10 = (int)((player.position.Y + player.height * 0.5) / 16.0);
                if (num9 < herbX - Player.tileRangeX || num9 > herbX + Player.tileRangeX + 1 || num10 < herbY - Player.tileRangeY || num10 > herbY + Player.tileRangeY + 1)
                {
                    Main.PlaySound(SoundID.MenuClose, -1, -1, 1);
                    player.Avalon().herb = false;
                    player.dropItemCheck();
                }
            }
            if (!Main.playerInventory)
            {
                player.Avalon().herb = false;
            }
            if (chaosCharm)
            {
                int lvl = 9 - (int)Math.Floor((10.0 * player.statLife) / player.statLifeMax2);
                if (lvl < 0)
                {
                    lvl = 0;
                }

                player.meleeCrit += 2 * lvl;
                player.magicCrit += 2 * lvl;
                player.rangedCrit += 2 * lvl;
                player.thrownCrit += 2 * lvl;
            }
            chaosCharm = false;
            slimeImmune = false;
            if (player.tongued)
            {
                bool flag21 = false;
                if (ExxoAvalonOriginsWorld.wos >= 0)
                {
                    float num159 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2;
                    num159 += Main.npc[ExxoAvalonOriginsWorld.wos].direction * 200;
                    float num160 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + Main.npc[ExxoAvalonOriginsWorld.wos].height / 2;
                    var vector5 = new Vector2(player.position.X + player.width * 0.5f, player.position.Y + player.height * 0.5f);
                    float num161 = num159 - vector5.X;
                    float num162 = num160 - vector5.Y;
                    float num163 = (float)Math.Sqrt(num161 * num161 + num162 * num162);
                    float num164 = 11f;
                    float num165;
                    if (num163 > num164)
                    {
                        num165 = num164 / num163;
                    }
                    else
                    {
                        num165 = 1f;
                        flag21 = true;
                    }
                    num161 *= num165;
                    num162 *= num165;
                    player.velocity.X = num161;
                    player.velocity.Y = num162;
                    player.position += player.velocity;
                }
                if (flag21 && Main.myPlayer == player.whoAmI)
                {
                    for (int num166 = 0; num166 < 22; num166++)
                    {
                        if (player.buffType[num166] == 38)
                        {
                            player.DelBuff(num166);
                        }
                    }
                }
            }

            // Large gem inventory checking
            player.gemCount = 0;
            gemCount++;
            if (gemCount >= 10)
            {
                player.gem = -1;
                ownedLargeGems = new bool[10];
                gemCount = 0;
                for (int num27 = 0; num27 <= 58; num27++)
                {
                    if (player.inventory[num27].type == ItemID.None || player.inventory[num27].stack == 0)
                    {
                        player.inventory[num27].TurnToAir();
                    }
                    // Vanilla gems
                    if (player.inventory[num27].type >= ItemID.LargeAmethyst && player.inventory[num27].type <= ItemID.LargeDiamond)
                    {
                        player.gem = player.inventory[num27].type - 1522;
                        ownedLargeGems[player.gem] = true;
                    }
                    else if (player.inventory[num27].type == ItemID.LargeAmber)
                    {
                        player.gem = 6;
                        ownedLargeGems[player.gem] = true;
                    }
                    // Modded gems
                    else if (player.inventory[num27].type == ModContent.ItemType<Items.Other.LargeZircon>())
                    {
                        player.gem = 7;
                        ownedLargeGems[player.gem] = true;
                    }
                    else if (player.inventory[num27].type == ModContent.ItemType<Items.Other.LargeTourmaline>())
                    {
                        player.gem = 8;
                        ownedLargeGems[player.gem] = true;
                    }
                    else if (player.inventory[num27].type == ModContent.ItemType<Items.Other.LargePeridot>())
                    {
                        player.gem = 9;
                        ownedLargeGems[player.gem] = true;
                    }
                }
            }

            if (necroticAura)
            {
                for (int i = 0; i < Main.npc.Length; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.townNPC)
                    {
                        continue;
                    }

                    if (!npc.active ||
                        npc.dontTakeDamage ||
                        npc.friendly ||
                        npc.life < 1)
                    {
                        continue;
                    }

                    if (npc.Center.X >= player.Center.X - 320 &&
                        npc.Center.X <= player.Center.X + 320 &&
                        npc.Center.Y >= player.Center.Y - 320 &&
                        npc.Center.Y <= player.Center.Y + 320)
                    {
                        int count = 0;
                        if (count++ % 50 == 0)
                        {
                            foreach (NPC target in Main.npc)
                            {
                                if (target.Center.X >= player.Center.X - 320 &&
                                    target.Center.X <= player.Center.X + 320 &&
                                    target.Center.Y >= player.Center.Y - 320 &&
                                    target.Center.Y <= player.Center.Y + 320)
                                {
                                    if (!target.active ||
                                        target.dontTakeDamage ||
                                        target.townNPC ||
                                        target.life < 1 ||
                                        target.boss ||
                                        target.target == ModContent.NPCType<NPCs.Juggernaut>() ||
                                        target.realLife >= 0)
                                    {
                                        continue;
                                    }

                                    target.AddBuff(ModContent.BuffType<Buffs.NecroticDrain>(), 2);
                                    //target.StrikeNPCNoInteraction(3 + (int)(target.defense / 2), 0f, 1, default, true);
                                    //target.StrikeNPC(3 + (int)(target.defense / 2), 0f, 1, default, true);
                                }
                            }
                            count = 0;
                        }
                    }
                }
            }

            if (reckoning)
            {
                if (player.whoAmI == Main.myPlayer)
                {
                    if (reckoningTimeLeft > 0)
                    {
                        reckoningTimeLeft--;
                    }
                    else
                    {
                        if (reckoningLevel > 1)
                        {
                            reckoningLevel--;
                        }

                        reckoningTimeLeft = 120;
                    }

                    if (reckoningLevel < 1)
                    {
                        reckoningLevel = 1;
                    }

                    player.rangedCrit += 3 * reckoningLevel;
                }
                else
                {
                    Main.NewText("Good job dummy, you broke the Reckoning set bonus");
                }
            }
            else
            {
                reckoningLevel = 0;
                reckoningTimeLeft = 0;
            }
        }

        public static readonly PlayerLayer SpectrumArmorLayer = new PlayerLayer(ExxoAvalonOrigins.Mod.Name, "SpectrumArmorLayer", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player p = drawInfo.drawPlayer;
            Color rb = new Color(Items.Armor.SpectrumHelmet.R, Items.Armor.SpectrumHelmet.G, Items.Armor.SpectrumHelmet.B, drawInfo.bodyColor.A);
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (p.gravDir == 1f)
            {
                if (p.direction == 1)
                {
                    spriteEffects = SpriteEffects.None;
                }
                else
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                if (!p.dead)
                {
                    p.legPosition.Y = 0f;
                    p.headPosition.Y = 0f;
                    p.bodyPosition.Y = 0f;
                }
            }
            else
            {
                if (p.direction == 1)
                {
                    spriteEffects = SpriteEffects.FlipVertically;
                }
                else
                {
                    spriteEffects = (SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);
                }
                if (!p.dead)
                {
                    p.legPosition.Y = 6f;
                    p.headPosition.Y = 6f;
                    p.bodyPosition.Y = 6f;
                }
            }
            Vector2 vector2 = new Vector2(p.legFrame.Width * 0.5f, p.legFrame.Height * 0.75f);
            Vector2 origin = new Vector2(p.legFrame.Width * 0.5f, p.legFrame.Height * 0.5f);
            Vector2 vector3 = new Vector2(p.legFrame.Width * 0.5f, p.legFrame.Height * 0.4f);
            if (p.head == ExxoAvalonOrigins.Mod.GetEquipSlot("SpectrumHelmet", EquipType.Head))
            {
                
                var value = default(DrawData);
                value = new DrawData(spectrumArmorTextures[0], new Vector2((int)(drawInfo.position.X - Main.screenPosition.X - p.bodyFrame.Width / 2 + p.width / 2), (int)(drawInfo.position.Y - Main.screenPosition.Y + p.height - p.bodyFrame.Height + 4f)) + p.headPosition + vector3, new Rectangle?(p.bodyFrame), rb, p.headRotation, vector3, 1f, spriteEffects, 0);
                Main.playerDrawData.Add(value);
            }
            if (p.body == ExxoAvalonOrigins.Mod.GetEquipSlot("SpectrumBreastplate", EquipType.Body))
            {
                Rectangle bodyFrame2 = p.bodyFrame;
                int num55 = 0;
                bodyFrame2.X += num55;
                bodyFrame2.Width -= num55;
                var value = default(DrawData);
                value = new DrawData(spectrumArmorTextures[1], new Vector2((int)(drawInfo.position.X - Main.screenPosition.X - p.bodyFrame.Width / 2 + p.width / 2) + num55, (int)(drawInfo.position.Y - Main.screenPosition.Y + p.height - p.bodyFrame.Height + 4f)) + p.bodyPosition + new Vector2(p.bodyFrame.Width / 2, p.bodyFrame.Height / 2), new Rectangle?(bodyFrame2), rb, p.bodyRotation, origin, 1f, spriteEffects, 0);
                Main.playerDrawData.Add(value);
            }
            if (p.legs == ExxoAvalonOrigins.Mod.GetEquipSlot("SpectrumGreaves", EquipType.Legs))
            {
                var value = new DrawData(spectrumArmorTextures[4], new Vector2((int)(drawInfo.position.X - Main.screenPosition.X - p.legFrame.Width / 2 + p.width / 2), (int)(drawInfo.position.Y - Main.screenPosition.Y + p.height - p.legFrame.Height + 4f)) + p.legPosition + vector2, new Rectangle?(p.legFrame), rb, p.legRotation, vector2, 1f, spriteEffects, 0);
                Main.playerDrawData.Add(value);
            }
        });

        // Large gem player layer logic
        public static readonly PlayerLayer LargeGemLayer = new PlayerLayer(ExxoAvalonOrigins.Mod.Name, "LargeGemLayer", PlayerLayer.FrontAcc, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            bool[] ownedLargeGems = drawPlayer.Avalon().ownedLargeGems;
            if (ownedLargeGems.Length > 0)
            {
                bool flag2 = false;
                var value = default(DrawData);
                float numGems = 0f;
                for (int num23 = 0; num23 < 10; num23++)
                {
                    if (ownedLargeGems[num23])
                    {
                        numGems += 1f;
                    }
                }
                float num25 = 1f - numGems * 0.06f;
                float num26 = (numGems - 1f) * 4f;
                switch ((int)numGems)
                {
                    case 2:
                        num26 += 10f;
                        break;

                    case 3:
                        num26 += 8f;
                        break;

                    case 4:
                        num26 += 6f;
                        break;

                    case 5:
                        num26 += 6f;
                        break;

                    case 6:
                        num26 += 2f;
                        break;

                    case 7:
                        num26 += 0f;
                        break;

                    case 8:
                        num26 += 0f;
                        break;

                    case 9:
                        num26 += 0f;
                        break;

                    case 10:
                        num26 += 0f;
                        break;
                }
                float rotSpeed = drawPlayer.miscCounter / 300f * ((float)Math.PI * 2f);
                if (numGems > 0f)
                {
                    float spacing = (float)Math.PI * 2f / numGems;
                    float num29 = 0f;
                    var ringSize = new Vector2(1.5f, 0.85f);
                    var list = new List<DrawData>();
                    for (int num30 = 0; num30 < 10; num30++)
                    {
                        if (!ownedLargeGems[num30])
                        {
                            num29 += 1f;
                            continue;
                        }
                        Vector2 value14 = (rotSpeed + spacing * (num30 - num29)).ToRotationVector2();
                        float num31 = num25;
                        if (flag2)
                        {
                            num31 = MathHelper.Lerp(num25 * 0.7f, 1f, value14.Y / 2f + 0.5f);
                        }

                        Texture2D texture2D4 = null;
                        if (num30 < 7)
                        {
                            texture2D4 = Main.gemTexture[num30];
                        }
                        else
                        {
                            switch (num30)
                            {
                                case 7:
                                    texture2D4 = ModContent.GetModItem(ModContent.ItemType<Items.Other.LargeZircon>()).GetTexture();
                                    num31 *= 1.5f;
                                    break;

                                case 8:
                                    texture2D4 = ModContent.GetModItem(ModContent.ItemType<Items.Other.LargeTourmaline>()).GetTexture();
                                    num31 *= 1.5f;
                                    break;

                                case 9:
                                    texture2D4 = ModContent.GetModItem(ModContent.ItemType<Items.Other.LargePeridot>()).GetTexture();
                                    num31 *= 1.5f;
                                    break;
                            }
                        }

                        value = new DrawData(texture2D4, new Vector2((int)(drawInfo.position.X - Main.screenPosition.X + drawPlayer.width / 2), (int)(drawInfo.position.Y - Main.screenPosition.Y + drawPlayer.height - 80f)) + value14 * ringSize * num26, null, new Color(250, 250, 250, Main.mouseTextColor / 2), 0f, texture2D4.Size() / 2f, (Main.mouseTextColor / 1000f + 0.8f) * num31, SpriteEffects.None, 0);
                        list.Add(value);
                    }
                    if (flag2)
                    {
                        list.Sort(DelegateMethods.CompareDrawSorterByYScale);
                    }
                    Main.playerDrawData.AddRange(list);
                }
            }
        });

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            LargeGemLayer.visible = true;
            layers.Add(LargeGemLayer);
            SpectrumArmorLayer.visible = true;
            layers.Add(SpectrumArmorLayer);
        }

        // Large gem drop on death logic
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                player.trashItem.SetDefaults();
                if (player.difficulty == 0)
                {
                    for (int i = 0; i < 59; i++)
                    {
                        if (player.inventory[i].stack > 0 &&
                            (player.inventory[i].type == ModContent.ItemType<Items.Other.LargeZircon>() ||
                            player.inventory[i].type == ModContent.ItemType<Items.Other.LargeTourmaline>() ||
                            player.inventory[i].type == ModContent.ItemType<Items.Other.LargePeridot>()))
                        {
                            int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, player.inventory[i].type);
                            Main.item[num].netDefaults(player.inventory[i].netID);
                            Main.item[num].Prefix(player.inventory[i].prefix);
                            Main.item[num].stack = player.inventory[i].stack;
                            Main.item[num].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                            Main.item[num].velocity.X = Main.rand.Next(-20, 21) * 0.2f;
                            Main.item[num].noGrabDelay = 100;
                            Main.item[num].favorited = false;
                            Main.item[num].newAndShiny = false;
                            if (Main.netMode == NetmodeID.MultiplayerClient)
                            {
                                NetMessage.SendData(MessageID.SyncItem, -1, -1, null, num);
                            }
                            player.inventory[i].SetDefaults();
                        }
                    }
                }
            }
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (player.whoAmI == Main.myPlayer && incDef)
            {
                int time = 300;
                if (cOmega)
                {
                    time = 600;
                }
                player.AddBuff(BuffID.Ironskin, time, true);
            }

            if (player.whoAmI == Main.myPlayer && regenStrike)
            {
                int hpHealed = 5;
                if (pOmega)
                {
                    hpHealed = 10;
                }

                player.statLife += hpHealed;
                player.HealEffect(hpHealed, true);
            }
            if (player.whoAmI == Main.myPlayer && bOfBacteria)
            {
                player.AddBuff(ModContent.BuffType<BacteriaEndurance>(), 6 * 60, true);
            }
        }

        public override void PostUpdateEquips()
        {
            for (int i = 0; i < 3; i++)
            {
                ArmorPrefix prefix;
                if ((prefix = ModPrefix.GetPrefix(player.armor[i].prefix) as ArmorPrefix) != null)
                {
                    //int kb = prefix.PreUpdateEquip(player);
                    prefix.UpdateEquip(player);
                }
            }
            //player.statMana = statManaMax3;
            //statManaMax2 = player.statManaMax2;
            if (meleeStealth && armorStealth)
            {
                if (player.itemAnimation > 0)
                {
                    player.stealthTimer = 5;
                }
                if (player.velocity.X > -0.1 && player.velocity.X < 0.1 && player.velocity.Y > -0.1 && player.velocity.Y < 0.1)
                {
                    if (player.stealthTimer == 0)
                    {
                        player.stealth -= 0.015f;
                        if (player.stealth < 0.0)
                        {
                            player.stealth = 0f;
                        }
                    }
                }
                else
                {
                    float num23 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
                    player.stealth += num23 * 0.0075f;
                    if (player.stealth > 1f)
                    {
                        player.stealth = 1f;
                    }
                }
                player.meleeDamage += (1f - player.stealth) * 0.4f;
                player.meleeCrit += (int)((1f - player.stealth) * 8f);
                player.rangedDamage += (1f - player.stealth) * 0.6f;
                player.rangedCrit += (int)((1f - player.stealth) * 10f);
                player.aggro -= (int)((1f - player.stealth) * 750f);
                if (player.stealthTimer > 0)
                {
                    player.stealthTimer--;
                }
            }
            else if (armorStealth)
            {
                if (player.itemAnimation > 0)
                {
                    player.stealthTimer = 5;
                }
                if (player.velocity.X > -0.1 && player.velocity.X < 0.1 && player.velocity.Y > -0.1 && player.velocity.Y < 0.1)
                {
                    if (player.stealthTimer == 0)
                    {
                        player.stealth -= 0.015f;
                        if (player.stealth < 0.0)
                        {
                            player.stealth = 0f;
                        }
                    }
                }
                else
                {
                    float num24 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
                    player.stealth += num24 * 0.0075f;
                    if (player.stealth > 1f)
                    {
                        player.stealth = 1f;
                    }
                }
                player.rangedDamage += (1f - player.stealth) * 0.6f;
                player.rangedCrit += (int)((1f - player.stealth) * 10f);
                player.aggro -= (int)((1f - player.stealth) * 750f);
                if (player.stealthTimer > 0)
                {
                    player.stealthTimer--;
                }
            }
            else if (meleeStealth)
            {
                if (player.itemAnimation > 0)
                {
                    player.stealthTimer = 5;
                }
                if (player.velocity.X > -0.1 && player.velocity.X < 0.1 && player.velocity.Y > -0.1 && player.velocity.Y < 0.1)
                {
                    if (player.stealthTimer == 0)
                    {
                        player.stealth -= 0.015f;
                        if (player.stealth < 0.0)
                        {
                            player.stealth = 0f;
                        }
                    }
                }
                else
                {
                    float num25 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
                    player.stealth += num25 * 0.0075f;
                    if (player.stealth > 1f)
                    {
                        player.stealth = 1f;
                    }
                }
                player.meleeDamage += (1f - player.stealth) * 0.4f;
                player.meleeCrit += (int)((1f - player.stealth) * 8f);
                player.aggro -= (int)((1f - player.stealth) * 750f);
                if (player.stealthTimer > 0)
                {
                    player.stealthTimer--;
                }
            }
            else
            {
                player.stealth = 1f;
            }

            if (inertiaBoots || blahWings)
            {
                if (player.controlUp && player.controlJump)
                {
                    player.wingsLogic = 0;
                    player.velocity.Y = player.velocity.Y - 0.7f * player.gravDir;
                    if (player.gravDir == 1f)
                    {
                        if (player.velocity.Y > 0f)
                        {
                            player.velocity.Y = player.velocity.Y - 1f;
                        }
                        else if (player.velocity.Y > -Player.jumpSpeed)
                        {
                            player.velocity.Y = player.velocity.Y - 0.5f;
                        }
                        if (player.velocity.Y < -Player.jumpSpeed * 3f)
                        {
                            player.velocity.Y = -Player.jumpSpeed * 3f;
                        }
                    }
                    else
                    {
                        if (player.velocity.Y < 0f)
                        {
                            player.velocity.Y = player.velocity.Y + 1f;
                        }
                        else if (player.velocity.Y < Player.jumpSpeed)
                        {
                            player.velocity.Y = player.velocity.Y + 0.5f;
                        }
                        if (player.velocity.Y > Player.jumpSpeed * 3f)
                        {
                            player.velocity.Y = Player.jumpSpeed * 3f;
                        }
                    }
                }
            }

            #region bubble boost

            if (bubbleBoost && activateBubble && !player.isOnGround() && !player.releaseJump && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>()))
            {
                #region bubble timer and spawn bubble gores/sound

                bubbleCD++;
                if (bubbleCD == 20)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int g1 = Gore.NewGore(player.Center + new Vector2(Main.rand.Next(-32, 33), Main.rand.Next(-32, 33)), player.velocity, mod.GetGoreSlot("Gores/Bubble"), 1f);
                        Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/Bubbles"));
                    }
                }
                if (bubbleCD == 30)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int g1 = Gore.NewGore(player.Center + new Vector2(Main.rand.Next(-32, 33), Main.rand.Next(-32, 33)), player.velocity, mod.GetGoreSlot("Gores/LargeBubble"), 1f);
                    }
                }
                if (bubbleCD == 40)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int g1 = Gore.NewGore(player.Center + new Vector2(Main.rand.Next(-32, 33), Main.rand.Next(-32, 33)), player.velocity, mod.GetGoreSlot("Gores/SmallBubble"), 1f);
                    }
                    bubbleCD = 0;
                }

                #endregion bubble timer and spawn bubble gores/sound

                #region down

                if (player.controlDown && player.controlJump)
                {
                    player.wingsLogic = 0;
                    player.rocketBoots = 0;
                    if (player.controlLeft)
                    {
                        player.velocity.X = -15f;
                    }
                    else if (player.controlRight)
                    {
                        player.velocity.X = 15f;
                    }
                    else
                    {
                        player.velocity.X = 0f;
                    }
                    player.velocity.Y = 15f;
                    bubbleBoostActive = true;
                }

                #endregion down

                #region up

                else if (player.controlUp && player.controlJump)
                {
                    player.wingsLogic = 0;
                    player.rocketBoots = 0;
                    if (player.controlLeft)
                    {
                        player.velocity.X = -15f;
                    }
                    else if (player.controlRight)
                    {
                        player.velocity.X = 15f;
                    }
                    else
                    {
                        player.velocity.X = 0f;
                    }
                    player.velocity.Y = -15f;
                    bubbleBoostActive = true;
                }

                #endregion up

                #region left

                else if (player.controlLeft && player.controlJump)
                {
                    player.velocity.X = -15f;
                    player.wingsLogic = 0;
                    player.rocketBoots = 0;
                    if (player.gravDir == 1f && player.velocity.Y > -player.gravity)
                    {
                        player.velocity.Y = -(player.gravity + 1E-06f);
                    }
                    else if (player.gravDir == -1f && player.velocity.Y < player.gravity)
                    {
                        player.velocity.Y = player.gravity + 1E-06f;
                    }
                    bubbleBoostActive = true;
                }

                #endregion left

                #region right

                else if (player.controlRight && player.controlJump)
                {
                    player.velocity.X = 15f;
                    player.wingsLogic = 0;
                    player.rocketBoots = 0;
                    if (player.gravDir == 1f && player.velocity.Y > -player.gravity)
                    {
                        player.velocity.Y = -(player.gravity + 1E-06f);
                    }
                    else if (player.gravDir == -1f && player.velocity.Y < player.gravity)
                    {
                        player.velocity.Y = player.gravity + 1E-06f;
                    }
                    bubbleBoostActive = true;
                }

                #endregion right

                stayInBounds(player.position);
            }

            #endregion bubble boost

            if (chaosCharm)
            {
                int modCrit = 2 * (int)Math.Floor((player.statLifeMax2 - (double)player.statLife) /
                              player.statLifeMax2 * 10.0);
                player.meleeCrit += modCrit;
                player.magicCrit += modCrit;
                player.rangedCrit += modCrit;
            }

            if (defDebuff)
            {
                bool flag = false;
                for (int num22 = 0; num22 < 22; num22++)
                {
                    if (Main.debuff[player.buffType[num22]] && player.buffType[num22] != BuffID.Horrified &&
                        player.buffType[num22] != BuffID.PotionSickness && player.buffType[num22] != BuffID.Merfolk &&
                        player.buffType[num22] != BuffID.Werewolf && player.buffType[num22] != BuffID.TheTongue &&
                        player.buffType[num22] != BuffID.ManaSickness && player.buffType[num22] != BuffID.Wet &&
                        player.buffType[num22] != BuffID.Slimed)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    defDebuffBonusDef = 12; // defDebuffBonusDef is here to avoid the def buff sticking around 24/7 because of terraria code jank
                }
                else
                {
                    defDebuffBonusDef = 0;
                }
            }
            player.statDefense += defDebuffBonusDef; // outside of the if statement to remove extra defense

            if (teleportV || tpStam)
            {
                if (tpCD > 300)
                {
                    tpCD = 300;
                }
                tpCD++;
            }
            stamFlightRestoreCD++;
            if (stamFlightRestoreCD > 3600)
            {
                stamFlightRestoreCD = 3600;
            }
            
            if (astralProject)
            {
                if (astralCD > 3600)
                {
                    astralCD = 3600;
                }

                astralCD++;
            }

            if (curseOfIcarus)
            {
                player.wingsLogic = 0;
                if (player.mount.CanFly || player.mount.CanHover) // Setting player.mount._flyTime does not work for all mounts. Bye-bye mounts!
                {
                    player.mount.Dismount(player);
                }

                // Alternative code which limits flight time instead of disabling it
                /*
                if (player.wingTime > 30)
                    player.wingTime = 30;
                */
            }
        }

        public static void stayInBounds(Vector2 pos)
        {
            if (pos.X > Main.maxTilesX - 100)
            {
                pos.X = Main.maxTilesX - 100;
            }
            if (pos.X < 100f)
            {
                pos.X = 100f;
            }
            if (pos.Y > Main.maxTilesY)
            {
                pos.Y = Main.maxTilesY;
            }
            if (pos.Y < 100f)
            {
                pos.Y = 100f;
            }
        }

        public void DoubleJumps()
        {
            if (NumHookProj() > 0 || player.sliding || (player.autoJump && player.justJumped))
            {
                jumpAgainQuack = true;
                return;
            }
            bool flag = true;
            if (player.mount != null && player.mount.Active)
            {
                flag = player.mount.BlockExtraJumps;
            }
            bool flag2 = (player.carpet ? player.carpetTime <= 0 && player.canCarpet : true);
            if (player.position.Y == player.oldPosition.Y && flag && flag2)
            {
                jumpAgainQuack = true;
            }
        }
        public override void PostUpdateMiscEffects()
        {
            DashMovement();
            DoubleJumps();
            if (noSticky)
            {
                player.sticky = false;
            }
            if (player.HasItem(ModContent.ItemType<SonicScrewdriverMkI>()))
            {
                player.findTreasure = player.detectCreature = true;
            }
            if (player.HasItem(ModContent.ItemType<SonicScrewdriverMkII>()))
            {
                player.findTreasure = player.detectCreature = true;
                player.accWatch = 3;
                player.accDepthMeter = 1;
                player.accCompass = 1;
            }
            if (player.HasItem(ModContent.ItemType<SonicScrewdriverMkIII>()))
            {
                player.findTreasure = player.detectCreature = player.dangerSense = openLocks = true;
                player.accWatch = 3;
                player.accDepthMeter = 1;
                player.accCompass = 1;
            }
            if (bloodCast)
            {
                player.statManaMax2 += player.statLifeMax2;
            }
            if (dragonsBondage)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Melee.DragonBall>()] == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int newBall = Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Melee.DragonBall>(), (player.HeldItem.damage / 2) * 3, 1f, player.whoAmI);
                        Main.projectile[newBall].localAI[0] = i;
                    }
                }
            }
            else
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Melee.DragonBall>()] != 0)
                {
                    for (int i = 0; i < Main.maxProjectiles; i++)
                    {
                        if (Main.projectile[i].type == ModContent.ProjectileType<Projectiles.Melee.DragonBall>() && Main.projectile[i].owner == player.whoAmI)
                        {
                            Main.projectile[i].Kill();
                        }
                    }
                }
            }
            if (spectrumSpeed)
            {
                float damagePercent;
                float maxSpeed;

                if (noSticky)
                {
                    maxSpeed = 10f;
                }
                else
                {
                    maxSpeed = player.maxRunSpeed;
                }

                damagePercent = (-25f * (float)(Math.Abs(player.velocity.X) / maxSpeed)) + 25f;

                if (damagePercent < 0)
                {
                    damagePercent = 0;
                }

                if (Math.Abs(player.velocity.X) >= maxSpeed)
                {
                    player.AddBuff(ModContent.BuffType<Buffs.SpectrumBlur>(), 5);
                }

                player.rangedDamage += damagePercent / 100f;
            }
            if (roseMagic)
            {
                if (roseMagicCooldown > 0)
                {
                    roseMagicCooldown--;
                }
                else
                {
                    roseMagicCooldown = 0;
                }
            }

            // Broken completely. If you wanna fix be my guest.
            /*
            if (ancientGunslinger)
            {
                if (player.controlUseItem && !oldLeftClick) // acts as justPressed
                {
                    baseUseTime = player.HeldItem.useTime;
                    baseUseAnim = player.HeldItem.useAnimation;
                }
                oldLeftClick = player.controlUseItem;
                if (player.controlUseItem && baseUseTime != -1)
                {
                    if (player.HeldItem.ranged)
                    {
                        ancientGunslingerTimer++;

                        ancientGunslingerStatAdd = ancientGunslingerTimer / 30;

                        if (ancientGunslingerStatAdd > player.HeldItem.useTime - 5)
                            ancientGunslingerStatAdd = player.HeldItem.useTime - 5;

                        if (ancientGunslingerTimer > 600)
                            ancientGunslingerTimer = 600;
                    }
                }
                if (!player.controlUseItem)
                {
                    player.HeldItem.useTime = baseUseTime;
                    player.HeldItem.useAnimation = baseUseAnim;
                    baseUseTime = -1;
                    baseUseAnim = -1;
                    ancientGunslingerStatAdd = 0;
                    ancientGunslingerTimer = 0;
                }

                player.HeldItem.useTime -= ancientGunslingerStatAdd;
                player.HeldItem.useAnimation -= ancientGunslingerStatAdd;
            }
            else
            {
                player.HeldItem.useTime = baseUseTime;
                player.HeldItem.useAnimation += baseUseAnim;
                baseUseTime = -1;
                baseUseAnim = -1;
                ancientGunslingerStatAdd = 0;
                ancientGunslingerTimer = 0;
            }
            Main.NewText(player.HeldItem.useTime);
            Main.NewText(player.HeldItem.useAnimation);
            */
            UpdateMana();
        }

        public void UpdateMana()
        {
            player.statManaMax2 += (spiritPoppyUseCount * 20);
        }
        //public override void PostUpdateBuffs()
        //{
        //    for (int k = 0; k < 22; k++)
        //    {
        //        if (player.buffType[k] == ModContent.BuffType<StaminaDrain>())
        //        {

        //        }
        //    }
        //}
        
        public override void PreUpdate()
        {
            WOSTongue();
            tpStam = !teleportV;
            if (teleportV)
            {
                teleportV = false;
                teleportVWasTriggered = true;
            }

            player.breathMax = 200;
            if (ZoneFlight) player.slowFall = true;
            // Large gem trashing logic
            if (player.whoAmI == Main.myPlayer)
            {
                if (
                    player.trashItem.type == ModContent.ItemType<Items.Other.LargeZircon>() ||
                    player.trashItem.type == ModContent.ItemType<Items.Other.LargeTourmaline>() ||
                    player.trashItem.type == ModContent.ItemType<Items.Other.LargePeridot>()
                )
                {
                    player.trashItem.SetDefaults();
                }
            }
        }
        public static int NumHookProj()
        {
            return Main.projectile.Count((Projectile p) => Main.projHook[p.type] && p.active && p.ai[0] == 2f && p.owner == Main.myPlayer);
        }
        public void DashMovement()
        {
            if (player.dashDelay > 0)
            {
                player.dashDelay--;
                return;
            }
            int amt = 60;
            if (staminaDrain)
            {
                amt *= (int)(staminaDrainStacks * staminaDrainMult);
            }
            if (stamDashKey && player.dash == 0 && player.dashDelay >= 0)
            {
                if (statStam > amt)
                {
                    int num2 = 0;
                    bool flag = false;
                    if (player.dashTime > 0)
                    {
                        player.dashTime--;
                    }
                    if (player.dashTime < 0)
                    {
                        player.dashTime++;
                    }
                    if (player.controlRight && player.releaseRight)
                    {
                        if (player.dashTime > 0)
                        {
                            num2 = 1;
                            flag = true;
                            player.dashTime = 0;
                            statStam -= amt;
                        }
                        else
                        {
                            player.dashTime = 15;
                        }
                    }
                    else if (player.controlLeft && player.releaseLeft)
                    {
                        if (player.dashTime < 0)
                        {
                            num2 = -1;
                            flag = true;
                            player.dashTime = 0;
                            statStam -= amt;
                        }
                        else
                        {
                            player.dashTime = -15;
                        }
                    }
                    if (flag)
                    {
                        player.velocity.X = 15.9f * num2;
                        player.dashDelay = -1;
                        for (int j = 0; j < 20; j++)
                        {
                            int num3 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                            Dust expr_336_cp_0 = Main.dust[num3];
                            expr_336_cp_0.position.X = expr_336_cp_0.position.X + Main.rand.Next(-5, 6);
                            Dust expr_35D_cp_0 = Main.dust[num3];
                            expr_35D_cp_0.position.Y = expr_35D_cp_0.position.Y + Main.rand.Next(-5, 6);
                            Main.dust[num3].velocity *= 0.2f;
                            Main.dust[num3].scale *= 1f + Main.rand.Next(20) * 0.01f;
                        }
                        int num4 = Gore.NewGore(new Vector2(player.position.X + player.width / 2 - 24f, player.position.Y + player.height / 2 - 34f), default, Main.rand.Next(61, 64), 1f);
                        Main.gore[num4].velocity.X = Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num4].velocity.Y = Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num4].velocity *= 0.4f;
                        num4 = Gore.NewGore(new Vector2(player.position.X + player.width / 2 - 24f, player.position.Y + player.height / 2 - 14f), default, Main.rand.Next(61, 64), 1f);
                        Main.gore[num4].velocity.X = Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num4].velocity.Y = Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num4].velocity *= 0.4f;
                    }
                }
                else if (stamFlower)
                {
                    QuickStamina(amt);
                    if (statStam > amt)
                    {
                        int num2 = 0;
                        bool flag = false;
                        if (player.dashTime > 0)
                        {
                            player.dashTime--;
                        }
                        if (player.dashTime < 0)
                        {
                            player.dashTime++;
                        }
                        if (player.controlRight && player.releaseRight)
                        {
                            if (player.dashTime > 0)
                            {
                                num2 = 1;
                                flag = true;
                                player.dashTime = 0;
                                statStam -= amt;
                            }
                            else
                            {
                                player.dashTime = 15;
                            }
                        }
                        else if (player.controlLeft && player.releaseLeft)
                        {
                            if (player.dashTime < 0)
                            {
                                num2 = -1;
                                flag = true;
                                player.dashTime = 0;
                                statStam -= amt;
                            }
                            else
                            {
                                player.dashTime = -15;
                            }
                        }
                        if (flag)
                        {
                            player.velocity.X = 15.9f * num2;
                            player.dashDelay = -1;
                            for (int j = 0; j < 20; j++)
                            {
                                int num3 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                                Dust expr_336_cp_0 = Main.dust[num3];
                                expr_336_cp_0.position.X = expr_336_cp_0.position.X + Main.rand.Next(-5, 6);
                                Dust expr_35D_cp_0 = Main.dust[num3];
                                expr_35D_cp_0.position.Y = expr_35D_cp_0.position.Y + Main.rand.Next(-5, 6);
                                Main.dust[num3].velocity *= 0.2f;
                                Main.dust[num3].scale *= 1f + Main.rand.Next(20) * 0.01f;
                            }
                            int num4 = Gore.NewGore(new Vector2(player.position.X + player.width / 2 - 24f, player.position.Y + player.height / 2 - 34f), default, Main.rand.Next(61, 64), 1f);
                            Main.gore[num4].velocity.X = Main.rand.Next(-50, 51) * 0.01f;
                            Main.gore[num4].velocity.Y = Main.rand.Next(-50, 51) * 0.01f;
                            Main.gore[num4].velocity *= 0.4f;
                            num4 = Gore.NewGore(new Vector2(player.position.X + player.width / 2 - 24f, player.position.Y + player.height / 2 - 14f), default, Main.rand.Next(61, 64), 1f);
                            Main.gore[num4].velocity.X = Main.rand.Next(-50, 51) * 0.01f;
                            Main.gore[num4].velocity.Y = Main.rand.Next(-50, 51) * 0.01f;
                            Main.gore[num4].velocity *= 0.4f;
                        }
                    }
                }
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ExxoAvalonOrigins.Mod.QuickStaminaHotkey.JustPressed)
            {
                QuickStamina();
            }
            if (ExxoAvalonOrigins.Mod.FlightTimeRestoreHotkey.JustPressed && player.wingsLogic > 0 && player.wingTime == 0 && flightRestoreUnlocked && stamFlightRestoreCD >= 60 * 60)
            {
                int amt = 150;
                if (staminaDrain)
                {
                    amt *= (int)(staminaDrainStacks * staminaDrainMult);
                }
                if (statStam >= amt)
                {
                    statStam -= amt;
                    stamFlightRestoreCD = 0;
                    player.wingTime = player.wingTimeMax;
                }
                else if (stamFlower)
                {
                    QuickStamina(amt);
                    if (statStam >= amt)
                    {
                        statStam -= amt;
                        stamFlightRestoreCD = 0;
                        player.wingTime = player.wingTimeMax;
                    }
                }
            }
            if (ExxoAvalonOrigins.Mod.ShadowHotkey.JustPressed && tpStam && tpCD >= 300 && teleportUnlocked)
            {
                int amt = 90;
                if (staminaDrain)
                {
                    amt *= (int)(staminaDrainStacks * staminaDrainMult);
                }
                if (statStam >= amt)
                {
                    statStam -= amt;
                    tpCD = 0;
                    if (Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].wall != ModContent.WallType<Walls.ImperviousBrickWallUnsafe>() &&
                        Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].wall != WallID.LihzahrdBrickUnsafe)
                    {
                        for (int m = 0; m < 70; m++)
                        {
                            Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.1f);
                        }
                        player.position.X = Main.mouseX + Main.screenPosition.X;
                        player.position.Y = Main.mouseY + Main.screenPosition.Y;
                        for (int n = 0; n < 70; n++)
                        {
                            Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
                        }
                    }
                }
                else if (stamFlower)
                {
                    QuickStamina(amt);
                    if (statStam >= amt)
                    {
                        statStam -= amt;
                        tpCD = 0;
                        if (Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].wall != ModContent.WallType<Walls.ImperviousBrickWallUnsafe>() &&
                            Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].wall != WallID.LihzahrdBrickUnsafe &&
                            !Main.wallDungeon[Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].wall])
                        {
                            for (int m = 0; m < 70; m++)
                            {
                                Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.1f);
                            }
                            player.position.X = Main.mouseX + Main.screenPosition.X;
                            player.position.Y = Main.mouseY + Main.screenPosition.Y;
                            for (int n = 0; n < 70; n++)
                            {
                                Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
                            }
                        }
                    }
                }
            }
            else if (ExxoAvalonOrigins.Mod.ShadowHotkey.JustPressed && (teleportV || teleportVWasTriggered) && tpCD >= 300)
            {
                teleportVWasTriggered = false;
                tpCD = 0;
                if (Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].wall != ModContent.WallType<Walls.ImperviousBrickWallUnsafe>() &&
                    Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].wall != WallID.LihzahrdBrickUnsafe)
                {
                    for (int m = 0; m < 70; m++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default, 1.1f);
                    }
                    player.position.X = Main.mouseX + Main.screenPosition.X;
                    player.position.Y = Main.mouseY + Main.screenPosition.Y;
                    for (int n = 0; n < 70; n++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
                    }
                }
            }
            if (ExxoAvalonOrigins.Mod.AstralHotkey.JustPressed && astralProject)
            {
                if (astralStart)
                {
                    if (player.HasBuff(ModContent.BuffType<AstralProjecting>()))
                    {
                        player.ClearBuff(ModContent.BuffType<AstralProjecting>());
                    }
                }
                if (astralCD >= 3600)
                {
                    astralCD = 0;
                    if (!astralStart)
                    {
                        player.AddBuff(ModContent.BuffType<AstralProjecting>(), 15 * 60);
                    }
                }
            }

            #region other hotkeys
            if (ExxoAvalonOrigins.Mod.RocketJumpHotkey.JustPressed && rocketJumpUnlocked)
            {
                activateRocketJump = !activateRocketJump;
                Main.NewText(!activateRocketJump ? "Rocket Jump Off" : "Rocket Jump On");
            }

            if (ExxoAvalonOrigins.Mod.SprintHotkey.JustPressed && sprintUnlocked)
            {
                activateSprint = !activateSprint;
                Main.NewText(!activateSprint ? "Sprinting Off" : "Sprinting On");
            }

            if (ExxoAvalonOrigins.Mod.DashHotkey.JustPressed)
            {
                stamDashKey = !stamDashKey;
                Main.NewText(!stamDashKey ? "Dashing Off" : "Dashing On");
            }

            if (ExxoAvalonOrigins.Mod.QuintupleHotkey.JustPressed)
            {
                quintJump = !quintJump;
                Main.NewText(!quintJump ? "Quintuple Jump Off" : "Quintuple Jump On");
            }

            if (ExxoAvalonOrigins.Mod.SwimHotkey.JustPressed && swimmingUnlocked)
            {
                activateSwim = !activateSwim;
                Main.NewText(!activateSwim ? "Swimming Off" : "Swimming On");
            }

            if (ExxoAvalonOrigins.Mod.WallSlideHotkey.JustPressed)
            {
                activateSlide = !activateSlide;
                Main.NewText(!activateSlide ? "Wall Sliding Off" : "Wall Sliding On");
            }

            if (ExxoAvalonOrigins.Mod.BubbleBoostHotkey.JustPressed)
            {
                activateBubble = !activateBubble;
                Main.NewText(!activateBubble ? "Bubble Boost Off" : "Bubble Boost On");
            }
            #endregion
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<Items.Tools.AccelerationDrill>() && ExxoAvalonOrigins.Mod.ModeChangeHotkey.JustPressed)
            {
                speed = !speed;
                if (!speed)
                {
                    Main.NewText("Acceleration Drill Mode: Normal");
                }
                else
                {
                    Main.NewText("Acceleration Drill Mode: Speed");
                }
            }

            if (Main.netMode != NetmodeID.SinglePlayer && player.inventory[player.selectedItem].type == ModContent.ItemType<EideticMirror>() &&
                ExxoAvalonOrigins.Mod.ModeChangeHotkey.JustPressed)
            {
                int newPlayer = teleportToPlayer;
                int numPlayersCounted = 0;
                while (true)
                {
                    newPlayer++;
                    if (newPlayer >= 255)
                    {
                        newPlayer -= 255;
                    }
                    if (Main.player[newPlayer].active && player.whoAmI != newPlayer && !Main.player[newPlayer].dead && Main.player[Main.myPlayer].team > 0 && Main.player[Main.myPlayer].team == Main.player[newPlayer].team)
                    {
                        Main.NewText("Teleporting to " + Main.player[newPlayer].name + " ready.", 250, 250, 0);
                        teleportToPlayer = newPlayer;
                        break;
                    }
                    numPlayersCounted++;
                    if (numPlayersCounted >= 255)
                    {
                        Main.NewText("There are no valid players on your team.", 250, 0, 0);
                        teleportToPlayer = -1;
                        break;
                    }
                }
            }

            if (player.inventory[player.selectedItem].type == ModContent.ItemType<ShadowMirror>())
            {
                player.noFallDmg = true; //TODO: Replace with better anti-fall-damage mechanism.
                if (ExxoAvalonOrigins.Mod.ModeChangeHotkey.JustPressed)
                {
                    shadowWP++;
                    shadowWP %= 7;
                    switch (shadowWP)
                    {
                        case 0:
                            Main.NewText("Mirror Mode: Spawn point");
                            break;

                        case 1:
                            Main.NewText("Mirror Mode: Dungeon");
                            break;

                        case 2:
                            Main.NewText("Mirror Mode: Jungle/Tropics" + (ExxoAvalonOriginsWorld.jungleLocationKnown ? "" : " (approx. pos)"));
                            break;

                        case 3:
                            Main.NewText("Mirror Mode: Left Ocean");
                            break;

                        case 4:
                            Main.NewText("Mirror Mode: Right Ocean");
                            break;

                        case 5:
                            Main.NewText("Mirror Mode: Underworld");
                            break;

                        case 6:
                            Main.NewText("Mirror Mode: Random");
                            break;

                        default:
                            throw new IndexOutOfRangeException("Not quite sure how you've managed this, but your shadow mirror's teleportation function is just wrong. Please contact the devs of Endo Avalon, and give a full bug report of all the details of the circumstances leading up to this error.");
                    }
                }
            }
            bool flag = true;
            if (player.mount != null && player.mount.Active)
            {
                flag = player.mount.BlockExtraJumps;
            }
            bool flag2 = (!player.doubleJumpCloud || !player.jumpAgainCloud) && (!player.doubleJumpSandstorm || !player.jumpAgainSandstorm) && (!player.doubleJumpBlizzard || !player.jumpAgainBlizzard) && (!player.doubleJumpFart || !player.jumpAgainFart) && (!player.doubleJumpSail || !player.jumpAgainSail) && (!player.doubleJumpUnicorn || !player.jumpAgainUnicorn) && NumHookProj() <= 0 && flag;
            if (!(PlayerInput.Triggers.JustPressed.Jump && player.position.Y != player.oldPosition.Y && flag2))
            {
                return;
            }
            if (quackJump && jumpAgainQuack)
            {
                jumpAgainQuack = false;
                int h = player.height;
                if (player.gravDir == -1)
                {
                    h = -6;
                }
                Main.PlaySound(SoundID.Zombie, player.position, 12);
                player.velocity.Y = -Player.jumpSpeed * player.gravDir;
                player.jump = (int)(Player.jumpHeight * 1.25);
                int num8 = Dust.NewDust(new Vector2(player.position.X - 4f, player.position.Y + h), player.width + 8, 4, 188, -player.velocity.X * 0.5f, player.velocity.Y * 0.5f, DustID.FartInAJar, default, 1.5f);
                Main.dust[num8].velocity.X = Main.dust[num8].velocity.X * 0.5f - player.velocity.X * 0.1f;
                Main.dust[num8].velocity.Y = Main.dust[num8].velocity.Y * 0.5f - player.velocity.Y * 0.3f;
                Main.dust[num8].velocity *= 0.5f;

                int g = Main.rand.Next(2);
                if (g == 0) g = mod.GetGoreSlot("Gores/QuackGore1");
                if (g == 1) g = mod.GetGoreSlot("Gores/QuackGore2");
                int g2 = Main.rand.Next(2);
                if (g2 == 0) g2 = mod.GetGoreSlot("Gores/QuackGore1");
                if (g2 == 1) g2 = mod.GetGoreSlot("Gores/QuackGore2");
                int g3 = Main.rand.Next(2);
                if (g3 == 0) g3 = mod.GetGoreSlot("Gores/QuackGore1");
                if (g3 == 1) g3 = mod.GetGoreSlot("Gores/QuackGore2");
                int num3 = Gore.NewGore(new Vector2(player.position.X + player.width / 2 - 16f, player.position.Y + h - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), g, 1f);
                Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - player.velocity.X * 0.1f;
                Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                Main.gore[num3].sticky = false;
                Main.gore[num3].rotation += 0.1f;
                num3 = Gore.NewGore(new Vector2(player.position.X - 36f, player.position.Y + h - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), g2, 1f);
                Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - player.velocity.X * 0.1f;
                Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                Main.gore[num3].sticky = false;
                Main.gore[num3].rotation += 0.1f;
                num3 = Gore.NewGore(new Vector2(player.position.X + player.width + 4f, player.position.Y + h - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), g3, 1f);
                Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - player.velocity.X * 0.1f;
                Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                Main.gore[num3].sticky = false;
                Main.gore[num3].rotation += 0.1f;
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (damage > 0)
            {
                if (LightningInABottle)
                {
                    var cloudPosition = new Vector2(player.Center.X + 0f, player.Center.Y - 150f);
                    var targetPosition = new Vector2(player.Center.X/* + (-20f * hitDirection)*/, player.Center.Y);
                    var targetPosition2 = new Vector2(player.Center.X + Main.rand.Next(-40, -20), player.Center.Y);
                    var targetPosition3 = new Vector2(player.Center.X + Main.rand.Next(-40, -20), player.Center.Y);
                    if (Main.rand.Next(2) == 0)
                    {
                        targetPosition2 = new Vector2(player.Center.X + Main.rand.Next(20, 40), player.Center.Y);
                    }
                    if (Main.rand.Next(2) == 0)
                    {
                        targetPosition3 = new Vector2(player.Center.X + Main.rand.Next(20, 40), player.Center.Y);
                    }

                    Projectile.NewProjectile(cloudPosition, Vector2.Zero, ModContent.ProjectileType<LightningCloud>(), 0, 0f, player.whoAmI);

                    for (int i = 0; i < 1; i++)
                    {
                        Vector2 vectorBetween = targetPosition - cloudPosition;
                        float randomSeed = Main.rand.Next(100);
                        Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                        Projectile.NewProjectile(cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), 47, 0f, Main.myPlayer, vectorBetween.ToRotation(), randomSeed);
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        Vector2 vectorBetween = targetPosition2 - cloudPosition;
                        float randomSeed = Main.rand.Next(100);
                        Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                        Projectile.NewProjectile(cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), 47, 0f, Main.myPlayer, vectorBetween.ToRotation(), randomSeed);
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        Vector2 vectorBetween = targetPosition3 - cloudPosition;
                        float randomSeed = Main.rand.Next(100);
                        Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                        Projectile.NewProjectile(cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), 47, 0f, Main.myPlayer, vectorBetween.ToRotation(), randomSeed);
                    }
                }

                if (goBerserk)
                {
                    if (damage > 50)
                    {
                        player.AddBuff(ModContent.BuffType<Buffs.Berserk>(), 180);
                    }
                }

                if (leafStorm)
                {
                    if (damage > 0 && Main.rand.Next(5) == 0)
                    {
                        var pos = new Vector2(player.Center.X + Main.rand.Next(-500, 501), player.Center.Y);
                        while (Main.tile[(int)(pos.X / 16), (int)(pos.Y / 16)].active())
                        {
                            pos.Y--;
                        }
                        Projectile.NewProjectile(pos, Vector2.Zero, ModContent.ProjectileType<Projectiles.LeafStorm>(), 80, 0.6f, Main.myPlayer);
                    }
                }
            }
        }
        public override void UpdateDead()
        {
            jumpAgainQuack = false;
        }
        public override void PostUpdateRunSpeeds()
        {
            //Main.NewText("PostUpdateRunSpeeds " + slimeBand.ToString());
            FloorVisualsAvalon(player.velocity.Y > player.gravity);
            if (activateRocketJump && rocketJumpUnlocked)
            {
                if (player.controlUp && player.releaseUp)
                {
                    if (player.isOnGround())
                    {
                        int amt = 70;
                        if (staminaDrain)
                        {
                            amt *= (int)(staminaDrainStacks * staminaDrainMult);
                        }
                        if (statStam >= amt)
                        {
                            statStam -= amt;
                            float yDestination = player.position.Y - 360f;
                            int num6 = Gore.NewGore(new Vector2(player.position.X + (player.width / 2) - 16f, player.position.Y + (player.gravDir == -1 ? 0 : player.height) - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                            num6 = Gore.NewGore(new Vector2(player.position.X - 36f, player.position.Y + (player.gravDir == -1 ? 0 : player.height) - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                            num6 = Gore.NewGore(new Vector2(player.position.X + player.width + 4f, player.position.Y + (player.gravDir == -1 ? 0 : player.height) - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - player.velocity.X * 0.1f;
                            Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                            Main.PlaySound(2, player.Center, 11);
                            player.velocity.Y -= 16.5f;
                        }
                        else if (stamFlower)
                        {
                            QuickStamina(amt);
                            if (statStam >= amt)
                            {
                                statStam -= amt;
                                float yDestination = player.position.Y - 360f;
                                int num6 = Gore.NewGore(new Vector2(player.position.X + (player.width / 2) - 16f, player.position.Y + (player.gravDir == -1 ? 0 : player.height) - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                                Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - player.velocity.X * 0.1f;
                                Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                                num6 = Gore.NewGore(new Vector2(player.position.X - 36f, player.position.Y + (player.gravDir == -1 ? 0 : player.height) - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                                Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - player.velocity.X * 0.1f;
                                Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                                num6 = Gore.NewGore(new Vector2(player.position.X + player.width + 4f, player.position.Y + (player.gravDir == -1 ? 0 : player.height) - 16f), new Vector2(-player.velocity.X, -player.velocity.Y), Main.rand.Next(11, 14), 1f);
                                Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - player.velocity.X * 0.1f;
                                Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                                Main.PlaySound(2, player.Center, 11);
                                player.velocity.Y -= 16.5f;
                            }
                        }
                    }
                }
                if (player.velocity.Y < 0)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        int d = Dust.NewDust(new Vector2(player.Center.X, player.position.Y + player.height), 10, 10, DustID.Smoke);
                    }
                }
            }
            if (player.wet && player.velocity != Vector2.Zero && !player.accMerman && activateSwim && swimmingUnlocked)
            {
                bool flag15 = true;
                staminaCD++;
                stamRegenCount = 0;
                if (staminaCD >= 10)
                {
                    int amt = 1;
                    if (staminaDrain)
                    {
                        amt *= (int)(staminaDrainStacks * staminaDrainMult);
                    }
                    if (statStam >= amt)
                    {
                        statStam -= amt;
                    }
                    else if (stamFlower)
                    {
                        QuickStamina();
                        if (statStam >= amt)
                        {
                            statStam -= amt;
                        }
                    }
                    if (statStam <= 0)
                    {
                        statStam = 0;
                        flag15 = false;
                    }
                    staminaCD = 0;
                }
                if (flag15)
                {
                    player.accFlipper = true;
                }
            }
            if (activateSprint)
            {
                if ((player.controlRight || player.controlLeft) && player.velocity.X != 0f)
                {
                    bool flag17 = true;
                    staminaCD2++;
                    stamRegenCount = 0;
                    if (staminaCD2 >= 30)
                    {
                        int amt = 2;
                        if (staminaDrain)
                        {
                            amt *= (int)(staminaDrainStacks * staminaDrainMult);
                        }
                        if (statStam >= amt)
                        {
                            statStam -= amt;
                        }
                        else if (stamFlower)
                        {
                            QuickStamina();
                            if (statStam >= amt)
                            {
                                statStam -= amt;
                            }
                        }
                        if (statStam <= 0)
                        {
                            statStam = 0;
                            flag17 = false;
                        }
                        staminaCD2 = 0;
                    }
                    if (flag17)
                    {
                        if (!player.HasItemInArmor(ItemID.HermesBoots) && !player.HasItemInArmor(ItemID.FlurryBoots) && !player.HasItemInArmor(ItemID.SpectreBoots) &&
                            !player.HasItemInArmor(ItemID.LightningBoots) && !player.HasItemInArmor(ItemID.FrostsparkBoots) && !player.HasItemInArmor(ItemID.SailfishBoots) &&
                            !inertiaBoots && !blahWings)
                        {
                            player.accRunSpeed = 6f;
                        }
                        else if (!player.HasItemInArmor(ItemID.LightningBoots) && !player.HasItemInArmor(ItemID.FrostsparkBoots) &&
                            !inertiaBoots && !blahWings)
                        {
                            player.accRunSpeed = 6.75f;
                        }
                        else if (!inertiaBoots && !blahWings)
                        {
                            player.accRunSpeed = 10.29f;
                            if ((player.velocity.X < 4f && player.controlRight) || (player.velocity.X > -4f && player.controlLeft))
                            {
                                player.velocity.X = player.velocity.X + (player.controlRight ? 0.31f : -0.31f);
                            }
                            else if ((player.velocity.X < 8f && player.controlRight) || (player.velocity.X > -8f && player.controlLeft))
                            {
                                player.velocity.X = player.velocity.X + (player.controlRight ? 0.29f : -0.29f);
                            }
                        }
                        else
                        {
                            player.accRunSpeed = 14.29f;
                            if ((player.velocity.X < 5f && player.controlRight) || (player.velocity.X > -5f && player.controlLeft))
                            {
                                player.velocity.X = player.velocity.X + (player.controlRight ? 0.41f : -0.41f);
                            }
                            else if ((player.velocity.X < 14f && player.controlRight) || (player.velocity.X > -14f && player.controlLeft))
                            {
                                player.velocity.X = player.velocity.X + (player.controlRight ? 0.39f : -0.39f);
                            }
                        }
                    }
                }
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                return;
            }

            #region Contagion Fish

            if (ZoneBooger && Main.rand.NextBool(10))
            {
                caughtType = ModContent.ItemType<Items.Fish.NauSeaFish>();
            }

            #endregion Contagion Fish
        }

        public void UpdateStaminaRegen()
        {
            if (stamRegenDelay > 0)
            {
                stamRegenDelay--;
                if ((player.velocity.X == 0f && player.velocity.Y == 0f) || player.grappling[0] >= 0)
                {
                    stamRegenDelay--;
                }
            }
            if (stamRegenDelay <= 0)
            {
                stamRegenDelay = 0;
                stamRegen = statStamMax2 / 7 + 1;
                if ((player.velocity.X == 0f && player.velocity.Y == 0f) || player.grappling[0] >= 0)
                {
                    stamRegen += statStamMax2 / 2;
                }
                float num = statStam / (float)statStamMax2 * 0.8f + 0.2f;
                stamRegen = (int)(stamRegen * num * 1.15);
            }
            else
            {
                stamRegen = 0;
            }
            stamRegenCount += stamRegen;

            while (stamRegenCount >= staminaRegen)
            {
                bool flag = false;
                stamRegenCount -= staminaRegen;
                if (statStam < statStamMax2)
                {
                    statStam++;
                    flag = true;
                }
                if (statStam >= statStamMax2)
                {
                    if (player.whoAmI == Main.myPlayer && flag)
                    {
                        Main.PlaySound(SoundID.MaxMana, -1, -1, 1);
                        for (int i = 0; i < 5; i++)
                        {
                            int num2 = Dust.NewDust(player.position, player.width, player.height, DustID.ManaRegeneration, 0f, 0f, 255, default(Color), Main.rand.Next(20, 26) * 0.1f);
                            Main.dust[num2].noLight = true;
                            Main.dust[num2].noGravity = true;
                            Main.dust[num2].velocity *= 0.5f;
                        }
                    }
                    statStam = statStamMax2;
                }
            }
        }

        public void FloorVisualsAvalon(bool falling)
        {
            int num = (int)((player.position.X + player.width / 2) / 16f);
            int num2 = (int)((player.position.Y + player.height) / 16f);
            int num3 = -1;
            if (Main.tile[num - 1, num2] == null)
            {
                Main.tile[num - 1, num2] = new Tile();
            }
            if (Main.tile[num + 1, num2] == null)
            {
                Main.tile[num + 1, num2] = new Tile();
            }
            if (Main.tile[num, num2] == null)
            {
                Main.tile[num, num2] = new Tile();
            }
            if (Main.tile[num, num2].nactive() && Main.tileSolid[Main.tile[num, num2].type])
            {
                num3 = Main.tile[num, num2].type;
            }
            else if (Main.tile[num - 1, num2].nactive() && Main.tileSolid[Main.tile[num - 1, num2].type])
            {
                num3 = Main.tile[num - 1, num2].type;
            }
            else if (Main.tile[num + 1, num2].nactive() && Main.tileSolid[Main.tile[num + 1, num2].type])
            {
                num3 = Main.tile[num + 1, num2].type;
            }
            if (num3 > -1)
            {
                if (num3 == 229 && !noSticky)
                {
                    player.sticky = true;
                }
                else
                {
                    player.sticky = false;
                }
                if (slimeBand || ZoneIceSoul)
                {
                    player.slippy = true;
                    player.slippy2 = true;
                }
                else
                {
                    player.slippy = false;
                    player.slippy2 = false;
                }
            }
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (undeadTalisman)
            {
                int dmgPlaceholder = npc.damage;
                if (undead.Contains(npc.type))
                {
                    if (damage - (player.statDefense / 2 - 10) <= 0)
                    {
                        damage = 0;
                        player.immune = true;
                        player.immuneAlpha = 0;
                    }
                    else
                    {
                        damage = dmgPlaceholder - (player.statDefense / 2 - 10);
                    }
                }
            }

            if (player.HasBuff(ModContent.BuffType<Buffs.ShadowCurse>()))
            {
                damage *= 2;
            }
            if (caesiumPoison)
            {
                damage = (int)(damage * 1.15f);
            }
        }

        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.ShadowCurse>()))
            {
                damage *= 2;
            }
        }

        /// <summary>
        /// Teleports the player to the given mode's teleport. Used for the Shadow Mirror, Magic Conch, and Demon Conch.
        /// Kills the player if they have the Horrified debuff from Wall of Flesh or Wall of Steel.
        /// </summary>
        /// <param name="mode">The mode of the teleport - 0: Spawnpoint, 1: Dungeon, 2: Jungle/Tropics, 3: Left Ocean, 4: Right Ocean,
        /// 5: Underworld, 6: Random.</param>
        /// <param name="pid">Unused.</param>
        public void ShadowTP(int mode, int pid)
        {
            if (player.HasBuff(37))
            {
                player.KillMe(PlayerDeathReason.ByCustomReason(" tried to escape..."), 3000000, 0);
                return;
            }
            switch (mode)
            {
                case 0:
                    player.Spawn();
                    break;

                case 1: // dungeon
                    player.noFallDmg = true;
                    player.immuneTime = 100;
                    Logic.ShadowTeleport.Teleport(0);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;

                case 2: // jungle
                    player.noFallDmg = true;
                    player.immuneTime = 100;
                    Vector2 prePos = player.position;
                    Vector2 pos = prePos;
                    Logic.ShadowTeleport.Teleport(1);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;

                case 3: // left ocean
                    player.noFallDmg = true;
                    player.immuneTime = 300;
                    Logic.ShadowTeleport.Teleport(2);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;

                case 4: // right ocean
                    player.noFallDmg = true;
                    player.immuneTime = 300;
                    Logic.ShadowTeleport.Teleport(3);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;

                case 5: // hell
                    player.noFallDmg = true;
                    player.immuneTime = 100;
                    Logic.ShadowTeleport.Teleport(4);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;

                case 6: // random
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                        {
                            player.TeleportationPotion();
                        }
                        else if (Main.netMode == NetmodeID.MultiplayerClient && player.whoAmI == Main.myPlayer)
                        {
                            NetMessage.SendData(MessageID.TeleportationPotion, -1, -1, NetworkText.Empty, 0, 0f, 0f, 0f, 0);
                        }

                        break;
                    }
            }
            int d = 15;
            switch (mode)
            {
                case 0:
                    d = DustID.MagicMirror;
                    break;

                case 1:
                    d = ModContent.DustType<Dusts.DungeonTeleportDust>();
                    break;

                case 2:
                    d = ModContent.DustType<Dusts.JungleTeleportDust>();
                    break;

                case 3:
                case 4:
                    d = ModContent.DustType<Dusts.OceanTeleportDust>();
                    break;

                case 5:
                    d = ModContent.DustType<Dusts.DemonConchDust>();
                    break;

                default:
                    d = DustID.MagicMirror;
                    break;
            }

            for (int i = 0; i < 70; i++)
            {
                Dust.NewDust(player.position, player.width, player.height, d, 0f, 0f, 150, default(Color), 1.5f);
            }
        }
        public void QuickStamina(int stamNeeded = 0) // todo: make stamina flower not allow you to consume stam pots that wouldn't allow you to continue using stamina
        {
            if (player.noItems)
            {
                return;
            }
            if (statStam == statStamMax2)
            {
                return;
            }
            int num = statStamMax2 - statStam;
            Item potionToBeUsed = null;
            int num2 = -statStamMax2;
            for (int i = 0; i < 58; i++)
            {
                Item potionChecked = player.inventory[i];
                if (potionChecked.stack > 0 && potionChecked.type > 0 && potionChecked.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina > 0)
                {
                    int num3 = potionChecked.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina - num;
                    if (num2 < 0)
                    {
                        if (num3 > num2)
                        {
                            potionToBeUsed = potionChecked;
                            num2 = num3;
                        }
                    }
                    else if (num3 < num2 && num3 >= 0)
                    {
                        potionToBeUsed = potionChecked;
                        num2 = num3;
                    }
                }
            }
            if (potionToBeUsed == null)
            {
                return;
            }
            if (potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina < stamNeeded && stamNeeded != 0)
            {
                return;
            }
            Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 3);
            statStam += potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina;
            if (statStam > statStamMax2)
            {
                statStam = statStamMax2;
            }
            if (potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina > 0 && Main.myPlayer == player.whoAmI)
            {
                player.AddBuff(ModContent.BuffType<StaminaDrain>(), 8 * 60);
                StaminaHealEffect(potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina, true);
            }
            potionToBeUsed.stack--;
            if (potionToBeUsed.stack <= 0)
            {
                potionToBeUsed.type = 0;
            }
        }
        public void StaminaHealEffect(int healAmount, bool broadcast = true)
        {
            CombatText.NewText(player.getRect(), new Color(5, 200, 255, 255), string.Concat(healAmount), false, false);
            if (broadcast && Main.netMode == 1 && player.whoAmI == Main.myPlayer)
            {
                ModPacket packet = Network.MessageHandler.GetPacket(Network.MessageID.StaminaHeal);
                packet.Write(player.whoAmI);
                packet.Write(healAmount);
                packet.Send();
            }
        }
        public void SpectrumDodge()
        {
            player.immune = true;
            if (player.longInvince)
            {
                player.immuneTime = 60;
            }
            else
            {
                player.immuneTime = 30;
            }

            Main.PlaySound(SoundID.Item, player.position, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/SpectrumDodge"));
            for (int i = 0; i < player.hurtCooldowns.Length; i++)
            {
                player.hurtCooldowns[i] = player.immuneTime;
            }
            if (player.whoAmI == Main.myPlayer)
            {
                NetMessage.SendData(MessageID.Dodge, -1, -1, null, player.whoAmI, 1f, 0f, 0f, 0, 0, 0);
            }
        }
    }
}
