﻿using System;
using System.Collections.Generic;
using System.IO;
using ExxoAvalonOrigins.Buffs;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Tools;
using ExxoAvalonOrigins.Items.Weapons.Melee;
using ExxoAvalonOrigins.Logic;
using ExxoAvalonOrigins.Prefixes;
using ExxoAvalonOrigins.Projectiles;
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

        public int statStamMax = 30;
        public int statStamMax2;
        public bool[] pSensor = new bool[6];
        public int statStam = 100;
        public int spiritPoppyUseCount;
        public bool shmAcc = false;
        public bool herb = false;
        public bool teleportVWasTriggered = false;
        public int screenShakeTimer;
        public bool astralProject;

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

        public static Texture2D[] lavaMermanTextures;
        public static Texture2D[] originalMermanTextures;

        public static Texture2D[] spectrumArmorTextures;

        public bool armorStealth = false;
        public int shadowCheckPointNum = 0;
        public int shadowPlayerNum = 0;
        public bool slimeImmune = false;
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
        public bool gastroMinion = false;
        public bool hungryMinion = false;
        public bool iceGolem = false;
        public int infectTimer = 0;
        public int infectDmg = 0;
        public bool weaponMinion = false;
        public bool primeMinion = false;
        public bool reflectorMinion = false;
        public int shadowPotCd = 0;
        public bool shockWave = false;
        public int fallStart_old = 0;
        public bool earthInsig = false;
        public bool vision = false;
        public const int deliriumFreq = 600;
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
        public bool luckTome;
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
        public bool releaseQuickStamina;
        public int stamRegen;
        public int stamRegenCount;
        public int stamRegenDelay;
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

        #endregion Stinger Probe Minion AI vars

        public Vector2 MousePosition = default(Vector2);

        #region Draggon's Bondage AI vars

        public bool dragonsBondage;

        #endregion Draggon's Bondage AI vars

        public int herbX;
        public int herbY;
        public int herbTier;
        public int potionTotal;
        public int herbTotal;
        public int[] herbCounts = new int[10];
        private int gemCount = 0;
        private bool[] ownedLargeGems = new bool[10];

        // Crit damage multiplyer vars
        public float critDamageMult = 1f;

        #endregion fields

        public override bool CloneNewInstances => false;

        public override void ResetEffects()
        {
            //Main.NewText("" + trapImmune.ToString());
            //Main.NewText("" + slimeBand.ToString());
            Player.defaultItemGrabRange = 38;
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
                    player.lifeRegen += HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) ? 6 : 4;
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
                    player.lifeRegen += HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) ? 3 : 2;
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

        public bool HasItemInArmor(int type)
        {
            for (int i = 0; i < player.armor.Length; i++)
            {
                if (type == player.armor[i].type)
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnEnterWorld(Player player)
        {
            if (tomeItem.type <= ItemID.None)
            {
                tomeItem.SetDefaults();
            }

            Main.NewText("You are using Exxo Avalon: Origins " + ExxoAvalonOrigins.mod.version.ToString());
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
            if (item.type == ModContent.ItemType<Items.Weapons.Ranged.SpikeCannon>())
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
                    if (player.inventory[player.selectedItem].useAmmo == ItemID.Spike)
                    {
                        int t = 0;
                        switch (item2.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().spike)
                        {
                            case 0:
                                t = ModContent.ProjectileType<SpikeCannon>();
                                break;
                            case 1:
                                t = ModContent.ProjectileType<DemonSpikeScale>();
                                break;
                            case 2:
                                t = ModContent.ProjectileType<BloodiedSpike>();
                                break;
                            case 3:
                                t = ModContent.ProjectileType<NastySpike>();
                                break;
                            case 4:
                                t = ModContent.ProjectileType<WoodenSpike>();
                                break;
                            case 5:
                                t = ModContent.ProjectileType<VenomSpike>();
                                break;
                            case 6:
                                t = ModContent.ProjectileType<PoisonSpike>();
                                break;
                        }
                        if (t > 0)
                        {
                            Projectile.NewProjectile(position, new Vector2(speedX, speedY), t, damage, knockBack);
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
                        switch (item2.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch)
                        {
                            case 0:
                                t = ModContent.ProjectileType<Projectiles.Torches.Torch>();
                                break;
                            case 1:
                                t = ModContent.ProjectileType<Projectiles.Torches.BlueTorch>();
                                break;
                            case 2:
                                t = ModContent.ProjectileType<Projectiles.Torches.RedTorch>();
                                break;
                            case 3:
                                t = ModContent.ProjectileType<Projectiles.Torches.GreenTorch>();
                                break;
                            case 4:
                                t = ModContent.ProjectileType<Projectiles.Torches.PurpleTorch>();
                                break;
                            case 5:
                                t = ModContent.ProjectileType<Projectiles.Torches.WhiteTorch>();
                                break;
                            case 6:
                                t = ModContent.ProjectileType<Projectiles.Torches.YellowTorch>();
                                break;
                            case 7:
                                t = ModContent.ProjectileType<Projectiles.Torches.DemonTorch>();
                                break;
                            case 8:
                                t = ModContent.ProjectileType<Projectiles.Torches.CursedTorch>();
                                break;
                            case 9:
                                t = ModContent.ProjectileType<Projectiles.Torches.IceTorch>();
                                break;
                            case 10:
                                t = ModContent.ProjectileType<Projectiles.Torches.OrangeTorch>();
                                break;
                            case 11:
                                t = ModContent.ProjectileType<Projectiles.Torches.IchorTorch>();
                                break;
                            case 12:
                                t = ModContent.ProjectileType<Projectiles.Torches.UltrabrightTorch>();
                                break;
                            case 13:
                                t = ModContent.ProjectileType<Projectiles.Torches.JungleTorch>();
                                break;
                            case 14:
                                t = ModContent.ProjectileType<Projectiles.Torches.PathogenTorch>();
                                break;
                            case 15:
                                t = ModContent.ProjectileType<Projectiles.Torches.SlimeTorch>();
                                break;
                            case 16:
                                t = ModContent.ProjectileType<Projectiles.Torches.CyanTorch>();
                                break;
                            case 17:
                                t = ModContent.ProjectileType<Projectiles.Torches.LimeTorch>();
                                break;
                            case 18:
                                t = ModContent.ProjectileType<Projectiles.Torches.BrownTorch>();
                                break;
                            case 19:
                                t = ModContent.ProjectileType<Projectiles.Torches.BoneTorch>();
                                break;
                            case 20:
                                t = ModContent.ProjectileType<Projectiles.Torches.RainbowTorch>();
                                break;
                            case 21:
                                t = ModContent.ProjectileType<Projectiles.Torches.PinkTorch>();
                                break;
                        }
                        if (t > 0)
                        {
                            Projectile.NewProjectile(position, new Vector2(speedX, speedY), t, 0, 0);
                            return false;
                        }
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
                herbTier = tag.GetAsInt("ExxoAvalonOrigins:HerbTier");
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
                herbCounts = tag.Get<int[]>("ExxoAvalonOrigins:HerbCounts");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:SpiritPoppyUseCount"))
            {
                spiritPoppyUseCount = tag.Get<int>("ExxoAvalonOrigins:SpiritPoppyUseCount");
            }
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
                        vampireHeal(damage / 2, target.Center);
                    }
                    else
                    {
                        vampireHeal(damage, target.Center);
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

        public void vampireHeal(int dmg, Vector2 Position)
        {
            float num = dmg * 0.075f;
            if ((int)num == 0)
            {
                return;
            }
            if (player.lifeSteal <= 0f)
            {
                return;
            }
            player.lifeSteal -= num;
            int num2 = player.whoAmI;
            Projectile.NewProjectile(Position.X, Position.Y, 0f, 0f, ProjectileID.VampireHeal, 0, 0f, player.whoAmI, num2, num);
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
                npc.AddBuff(ModContent.BuffType<Buffs.CurseofAvalon>(), 100);
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
            if (HasItemInArmor(ModContent.ItemType<ShadowRing>()))
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
                    if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                    {
                        num = 4;
                    }

                    player.lifeRegen += num + 4;
                }
                else if (player.venom || player.frostBurn || player.onFire2)
                {
                    int num2 = 2;
                    if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                    {
                        num2 = 4;
                    }
                    player.lifeRegen += num2 + 12;
                }
                else if (player.onFire)
                {
                    int num3 = 2;
                    if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                    {
                        num3 = 4;
                    }
                    player.lifeRegen += num3 + 8;
                }
                else if (darkInferno)
                {
                    int num6 = 4;
                    if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
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
                { "ExxoAvalonOrigins:HerbTier", herbTier },
                { "ExxoAvalonOrigins:HerbTotal", herbTotal },
                { "ExxoAvalonOrigins:PotionTotal", potionTotal },
                { "ExxoAvalonOrigins:HerbCounts", herbCounts },
                { "ExxoAvalonOrigins:SpiritPoppyUseCount", spiritPoppyUseCount }
            };
            return tag;
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

        public override void PreUpdateMovement()
        {

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

            if (herbTotal < 250)
            {
                herbTier = 0;
            }
            else if (herbTotal >= 250 && herbTotal < 750)
            {
                herbTier = 1;
            }
            else if (herbTotal >= 750 && herbTotal < 1500)
            {
                if (Main.hardMode)
                {
                    herbTier = 2;
                }
                else
                {
                    herbTier = 1;
                }
            }
            else
            {
                if (Main.hardMode)
                {
                    herbTier = 3;
                }
                else
                {
                    herbTier = 1;
                }
            }
            herbTier = 2;
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
                        player.AddBuff(ModContent.BuffType<Melting>(), 60);
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

            if (HasItemInArmor(ModContent.ItemType<ShadowRing>()))
            {
                player.shadow = 0f;
            }

            if (blahArmor)
            {
                player.shadow = 0f;
            }

            if (player.Avalon().herb)
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

        public static readonly PlayerLayer SpectrumArmorLayer = new PlayerLayer(ExxoAvalonOrigins.mod.Name, "SpectrumArmorLayer", PlayerLayer.Head, delegate (PlayerDrawInfo drawInfo)
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
            if (p.head == ExxoAvalonOrigins.mod.GetEquipSlot("SpectrumHelmet", EquipType.Head))
            {
                
                var value = default(DrawData);
                value = new DrawData(spectrumArmorTextures[0], new Vector2((int)(drawInfo.position.X - Main.screenPosition.X - p.bodyFrame.Width / 2 + p.width / 2), (int)(drawInfo.position.Y - Main.screenPosition.Y + p.height - p.bodyFrame.Height + 4f)) + p.headPosition + vector3, new Rectangle?(p.bodyFrame), rb, p.headRotation, vector3, 1f, spriteEffects, 0);
                Main.playerDrawData.Add(value);
            }
            if (p.body == ExxoAvalonOrigins.mod.GetEquipSlot("SpectrumBreastplate", EquipType.Body))
            {
                Rectangle bodyFrame2 = p.bodyFrame;
                int num55 = 0;
                bodyFrame2.X += num55;
                bodyFrame2.Width -= num55;
                var value = default(DrawData);
                value = new DrawData(spectrumArmorTextures[1], new Vector2((int)(drawInfo.position.X - Main.screenPosition.X - p.bodyFrame.Width / 2 + p.width / 2) + num55, (int)(drawInfo.position.Y - Main.screenPosition.Y + p.height - p.bodyFrame.Height + 4f)) + p.bodyPosition + new Vector2(p.bodyFrame.Width / 2, p.bodyFrame.Height / 2), new Rectangle?(bodyFrame2), rb, p.bodyRotation, origin, 1f, spriteEffects, 0);
                Main.playerDrawData.Add(value);
            }
            if (p.legs == ExxoAvalonOrigins.mod.GetEquipSlot("SpectrumGreaves", EquipType.Legs))
            {
                var value = new DrawData(spectrumArmorTextures[4], new Vector2((int)(drawInfo.position.X - Main.screenPosition.X - p.legFrame.Width / 2 + p.width / 2), (int)(drawInfo.position.Y - Main.screenPosition.Y + p.height - p.legFrame.Height + 4f)) + p.legPosition + vector2, new Rectangle?(p.legFrame), rb, p.legRotation, vector2, 1f, spriteEffects, 0);
                Main.playerDrawData.Add(value);
            }
        });

        // Large gem player layer logic
        public static readonly PlayerLayer LargeGemLayer = new PlayerLayer(ExxoAvalonOrigins.mod.Name, "LargeGemLayer", PlayerLayer.FrontAcc, delegate (PlayerDrawInfo drawInfo)
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

            if (HasItemInArmor(ModContent.ItemType<BlahsWings>()) || HasItemInArmor(ModContent.ItemType<InertiaBoots>()))
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

            if (bubbleBoost && activateBubble && !isOnGround() && !player.releaseJump && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>()))
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

        public bool isOnGround()
        {
            return (Main.tile[(int)(player.position.X / 16f), (int)(player.position.Y / 16f) + 3].active() && Main.tileSolid[Main.tile[(int)(player.position.X / 16f), (int)(player.position.Y / 16f) + 3].type]) || (Main.tile[(int)(player.position.X / 16f) + 1, (int)(player.position.Y / 16f) + 3].active() && Main.tileSolid[Main.tile[(int)(player.position.X / 16f) + 1, (int)(player.position.Y / 16f) + 3].type] && player.velocity.Y == 0f);
        }

        public override void PostUpdateMiscEffects()
        {
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
                if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.DragonBall>()] == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int newBall = Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.DragonBall>(), (player.HeldItem.damage / 2) * 3, 1f, player.whoAmI);
                        Main.projectile[newBall].localAI[0] = i;
                    }
                }
            }
            else
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.DragonBall>()] != 0)
                {
                    for (int i = 0; i < Main.maxProjectiles; i++)
                    {
                        if (Main.projectile[i].type == ModContent.ProjectileType<Projectiles.DragonBall>() && Main.projectile[i].owner == player.whoAmI)
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

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ExxoAvalonOrigins.mod.quickStaminaHotkey.JustPressed)
            {
                QuickStamina();
            }
            if (ExxoAvalonOrigins.mod.shadowHotkey.JustPressed && tpStam && statStam >= 90 && tpCD >= 300)
            {
                statStam -= 90;
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
            else if (ExxoAvalonOrigins.mod.shadowHotkey.JustPressed && (teleportV || teleportVWasTriggered) && tpCD >= 300)
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
            if (ExxoAvalonOrigins.mod.astralHotkey.JustPressed && astralProject)
            {
                if (astralStart)
                {
                    if (player.HasBuff(ModContent.BuffType<Buffs.AstralProjecting>()))
                    {
                        player.ClearBuff(ModContent.BuffType<Buffs.AstralProjecting>());
                    }
                }
                if (astralCD >= 3600)
                {
                    astralCD = 0;
                    if (!astralStart)
                    {
                        player.AddBuff(ModContent.BuffType<Buffs.AstralProjecting>(), 15 * 60);
                    }
                }
            }

            if (ExxoAvalonOrigins.mod.rocketJumpHotkey.JustPressed)
            {
                activateRocketJump = !activateRocketJump;
                Main.NewText(!activateRocketJump ? "Rocket Jump Off" : "Rocket Jump On");
            }

            if (ExxoAvalonOrigins.mod.sprintHotkey.JustPressed)
            {
                activateSprint = !activateSprint;
                Main.NewText(!activateSprint ? "Sprinting Off" : "Sprinting On");
            }

            if (ExxoAvalonOrigins.mod.dashHotkey.JustPressed)
            {
                stamDashKey = !stamDashKey;
                Main.NewText(!stamDashKey ? "Dashing Off" : "Dashing On");
            }

            if (ExxoAvalonOrigins.mod.quintupleHotkey.JustPressed)
            {
                quintJump = !quintJump;
                Main.NewText(!quintJump ? "Quintuple Jump Off" : "Quintuple Jump On");
            }

            if (ExxoAvalonOrigins.mod.swimHotkey.JustPressed)
            {
                activateSwim = !activateSwim;
                Main.NewText(!activateSwim ? "Swimming Off" : "Swimming On");
            }

            if (ExxoAvalonOrigins.mod.wallSlideHotkey.JustPressed)
            {
                activateSlide = !activateSlide;
                Main.NewText(!activateSlide ? "Wall Sliding Off" : "Wall Sliding On");
            }

            if (ExxoAvalonOrigins.mod.bubbleBoostHotkey.JustPressed)
            {
                activateBubble = !activateBubble;
                Main.NewText(!activateBubble ? "Bubble Boost Off" : "Bubble Boost On");
            }

            if (player.inventory[player.selectedItem].type == ModContent.ItemType<Items.Tools.AccelerationDrill>() && ExxoAvalonOrigins.mod.modeChangeHotkey.JustPressed)
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
                ExxoAvalonOrigins.mod.modeChangeHotkey.JustPressed)
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
                if (ExxoAvalonOrigins.mod.modeChangeHotkey.JustPressed)
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

        public override void PostUpdateRunSpeeds()
        {
            //Main.NewText("PostUpdateRunSpeeds " + slimeBand.ToString());
            FloorVisualsAvalon(player.velocity.Y > player.gravity);
            if (activateRocketJump)
            {
                if (player.controlUp && player.releaseUp && statStam >= 70)
                {
                    if (isOnGround())
                    {
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
                        statStam -= 70;
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
            if (statStam >= 1 && player.wet && player.velocity != Vector2.Zero && !player.accMerman && activateSwim)
            {
                bool flag15 = true;
                staminaCD += 1;
                stamRegenCount = 0;
                if (staminaCD >= 6)
                {
                    statStam--;
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
                if ((player.controlRight || player.controlLeft) && statStam >= 2 && !HasItemInArmor(ModContent.ItemType<Items.Accessories.InertiaBoots>()) && !HasItemInArmor(ModContent.ItemType<BlahsWings>()) && player.velocity.X != 0f)
                {
                    bool flag17 = true;
                    staminaCD2 += 1;
                    stamRegenCount = 0;
                    if (staminaCD2 >= 15)
                    {
                        statStam -= 2;
                        if (statStam <= 0)
                        {
                            statStam = 0;
                            flag17 = false;
                        }
                        staminaCD2 = 0;
                    }
                    if (flag17)
                    {
                        if (!HasItemInArmor(ItemID.HermesBoots) && !HasItemInArmor(ItemID.FlurryBoots) && !HasItemInArmor(ItemID.SpectreBoots) && !HasItemInArmor(ItemID.LightningBoots) && !HasItemInArmor(ItemID.FrostsparkBoots) && !HasItemInArmor(ItemID.SailfishBoots))
                        {
                            player.accRunSpeed = 6f;
                        }
                        else if (!HasItemInArmor(ItemID.LightningBoots) && !HasItemInArmor(ItemID.FrostsparkBoots))
                        {
                            player.accRunSpeed = 6.75f;
                        }
                        else
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
            while (stamRegenCount >= 1000)
            {
                bool flag = false;
                stamRegenCount -= 1000;
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
        public void QuickStamina()
        {
            if (player.noItems)
            {
                return;
            }
            if (statStam == statStamMax2 || player.potionDelay > 0)
            {
                return;
            }
            int num = statStamMax2 - statStam;
            Item item = null;
            int num2 = -statStamMax2;
            for (int i = 0; i < 58; i++)
            {
                Item item2 = player.inventory[i];
                if (item2.stack > 0 && item2.type > 0 && item2.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina > 0)
                {
                    int num3 = item2.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina - num;
                    if (num2 < 0)
                    {
                        if (num3 > num2)
                        {
                            item = item2;
                            num2 = num3;
                        }
                    }
                    else if (num3 < num2 && num3 >= 0)
                    {
                        item = item2;
                        num2 = num3;
                    }
                }
            }
            if (item == null)
            {
                return;
            }
            Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 3);
            statStam += item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina;
            if (statStam > statStamMax2)
            {
                statStam = statStamMax2;
            }
            if (item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina > 0 && Main.myPlayer == player.whoAmI)
            {
                StaminaHealEffect(item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina, true);
            }
            item.stack--;
            if (item.stack <= 0)
            {
                item.type = 0;
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
