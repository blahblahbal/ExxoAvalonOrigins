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
using Terraria.Audio;
using Terraria.GameContent;
using ExxoAvalonOrigins.PlayerDrawLayers;
using ReLogic.Content;
using ExxoAvalonOrigins.Systems;

namespace ExxoAvalonOrigins.Players;
public partial class ExxoModPlayer : ModPlayer
{
    public override bool CloneNewInstances => false;
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

    public static Asset<Texture2D>[] spectrumArmorTextures;

    public bool inertiaBoots = false;
    public bool blahWings = false;
    public bool spikeImmune = false;
    public bool luckTome = false;
    public bool thornHeartAmulet = false;
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
    public bool hadesCross;
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
    public bool bloodyWhetstone;
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
    public bool[] ownedLargeGems = new bool[10];

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
        hadesCross = false;
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
            Player.extraAccessory = true;
            Player.extraAccessorySlots++;
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
    public override void FrameEffects()
    {
        // TODO: Need new hook, FrameEffects doesn't run while paused.
        if (hadesCross)
        {
            var exampleCostume = ModContent.GetInstance<HadesCross>();
            Player.head = Mod.GetEquipSlot(exampleCostume.Name, EquipType.Head);
            Player.body = Mod.GetEquipSlot(exampleCostume.Name, EquipType.Body);
            Player.legs = Mod.GetEquipSlot(exampleCostume.Name, EquipType.Legs);
        }
    }
    public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        #region spike cannon logic
        if (item.type == ModContent.ItemType<Items.Weapons.Ranged.SpikeCannon>() || item.type == ModContent.ItemType<Items.Weapons.Ranged.SpikeRailgun>())
        {
            Item item2 = new Item();
            bool flag7 = false;
            bool inAmmoSlots = false;
            for (int i = 54; i < 58; i++)
            {
                if (Player.inventory[i].ammo == Player.inventory[Player.selectedItem].useAmmo && Player.inventory[i].stack > 0)
                {
                    item2 = Player.inventory[i];
                    flag7 = true;
                    inAmmoSlots = true;
                    break;
                }
            }
            if (!inAmmoSlots)
            {
                for (int i = 0; i < 54; i++)
                {
                    if (Player.inventory[i].ammo == Player.inventory[Player.selectedItem].useAmmo && Player.inventory[i].stack > 0)
                    {
                        item2 = Player.inventory[i];
                        flag7 = true;
                        //Main.NewText(item2.Name);
                        break;
                    }
                }
            }
            if (flag7)
            {
                if (Player.inventory[Player.selectedItem].useAmmo == ItemID.Spike)
                {
                    int t = 0;
                    int dmgAdd = 0;
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
                            Vector2 vector2 = velocity;
                            vector2.Normalize();
                            vector2 *= 40f;
                            for (int num89 = 0; num89 < num88; num89++)
                            {
                                float num90 = num89 - (num88 - 1f) / 2f;
                                Vector2 vector3 = vector2.Rotate(num87 * num90, default);
                                int num91 = Projectile.NewProjectile(Player.GetProjectileSource_Item(new Item(ModContent.ItemType<Items.Weapons.Ranged.SpikeRailgun>())), position.X + vector3.X, position.Y + vector3.Y, velocity.X, velocity.Y, t, damage + dmgAdd, knockback, Player.whoAmI, 0f, 0f);
                            }
                            Main.NewText(t);
                            return false;
                        }
                        Projectile.NewProjectile(Player.GetProjectileSource_Item(new Item(ModContent.ItemType<Items.Weapons.Ranged.SpikeCannon>())), position, velocity, t, damage + dmgAdd, knockback, Player.whoAmI);
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
                if (Player.inventory[i].ammo == Player.inventory[Player.selectedItem].useAmmo && Player.inventory[i].stack > 0)
                {
                    item2 = Player.inventory[i];
                    flag7 = true;
                    inAmmoSlots = true;
                    break;
                }
            }
            if (!inAmmoSlots)
            {
                for (int i = 0; i < 54; i++)
                {
                    if (Player.inventory[i].ammo == Player.inventory[Player.selectedItem].useAmmo && Player.inventory[i].stack > 0)
                    {
                        item2 = Player.inventory[i];
                        flag7 = true;
                        break;
                    }
                }
            }
            if (flag7)
            {
                if (Player.inventory[Player.selectedItem].useAmmo == 8)
                {
                    int t = 0;
                    if (torches.TryGetValue(item2.type, out t))
                    {
                        Projectile.NewProjectile(Player.GetProjectileSource_Item(new Item(ModContent.ItemType<TorchLauncher>())), position, new Vector2(velocity.X, velocity.Y), t, 0, 0);
                        return false;
                    }
                    else return base.Shoot(item, source, position, velocity, type, damage, knockback);
                }
            }
        }
        #endregion
        return base.Shoot(item, source, position, velocity, type, damage, knockback);
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
            if (Player.position.X + Player.width > num && Player.position.X < num + 140f && Player.gross)
            {
                Player.noKnockback = false;
                Player.Hurt(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 50, Main.npc[ExxoAvalonOriginsWorld.wos].direction);
            }
            if (!Player.gross && Player.position.Y > (Main.maxTilesY - 250) * 16 && Player.position.X > num - 1920f && Player.position.X < num + 1920f)
            {
                Player.AddBuff(37, 10, true);
                //Main.PlaySound(4, (int)Main.npc[ExxoAvalonOriginsWorld.wos].position.X, (int)Main.npc[ExxoAvalonOriginsWorld.wos].position.Y, 10);
            }
            if (Player.gross)
            {
                if (Player.position.Y < (Main.maxTilesY - 200) * 16)
                {
                    Player.AddBuff(38, 10, true);
                }
                if (Main.npc[ExxoAvalonOriginsWorld.wos].direction < 0)
                {
                    if (Player.position.X + Player.width / 2 > Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2 + 40f)
                    {
                        Player.AddBuff(38, 10, true);
                    }
                }
                else if (Player.position.X + Player.width / 2 < Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2 - 40f)
                {
                    Player.AddBuff(38, 10, true);
                }
            }
            if (Player.tongued)
            {
                Player.controlHook = false;
                Player.controlUseItem = false;
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].aiStyle == 7)
                    {
                        Main.projectile[i].Kill();
                    }
                }
                var vector = new Vector2(Player.position.X + Player.width * 0.5f, Player.position.Y + Player.height * 0.5f);
                float num2 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2 - vector.X;
                float num3 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + Main.npc[ExxoAvalonOriginsWorld.wos].height / 2 - vector.Y;
                float num4 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
                if (num4 > 3000f)
                {
                    //player.lastPosBeforeDeath = this.position;
                    Player.KillMe(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 1000.0, 0, false);
                    return;
                }
                if (Main.npc[ExxoAvalonOriginsWorld.wos].position.X < 608f || Main.npc[ExxoAvalonOriginsWorld.wos].position.X > (Main.maxTilesX - 38) * 16)
                {
                    //this.lastPosBeforeDeath = this.position;
                    Player.KillMe(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 1000.0, 0, false);
                }
            }
        }
    }
    public override bool CanConsumeAmmo(Item weapon, Item ammo)
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
            return base.CanConsumeAmmo(weapon, ammo);
        }
    }
    public override void ModifyWeaponDamage(Item item, ref StatModifier damage, ref float flat)
    {
        if (item.useAmmo == AmmoID.Arrow && advArcheryBuff)
        {
            damage = new StatModifier(0, 1.4f);
        }
        base.ModifyWeaponDamage(item, ref damage, ref flat);
    }
    public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
    {
        if (terraClaws && item.DamageType == DamageClass.Melee)
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
            Projectile.NewProjectile(Player.GetProjectileSource_OnHit(target, ProjectileSourceID.None), target.position, Vector2.Zero, ModContent.ProjectileType<AncientSandnado>(), 0, 0);
        }
        if (vampireTeeth)
        {
            if (item.DamageType == DamageClass.Melee)
            {
                if (target.boss)
                {
                    Player.VampireHeal(damage / 2, target.Center);
                }
                else
                {
                    Player.VampireHeal(damage, target.Center);
                }
            }
        }
        if (crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                if (Player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                {
                    reckoningLevel += 1;
                }
            }

            if (avalonRestoration)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
            }
        }
        if (Player.inventory[Player.selectedItem].DamageType == DamageClass.Melee && bloodyWhetstone)
        {
            target.AddBuff(ModContent.BuffType<Bleeding>(), 120);
            target.GetGlobalNPC<ExxoAvalonOriginsGlobalNPCInstance>().isBleedingHMBleed = true;
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
            if (proj.DamageType == DamageClass.Magic)
            {
                if (Main.rand.Next(8) == 0 && roseMagicCooldown <= 0)
                {
                    int num36 = Item.NewItem(Player.GetProjectileSource_OnHit(target, ProjectileSourceID.None), (int)target.position.X, (int)target.position.Y, target.width, target.height, ModContent.ItemType<Rosebud>());
                    Main.item[num36].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                    Main.item[num36].velocity.X = Main.rand.Next(10, 31) * 0.2f * Player.direction;
                    roseMagicCooldown = 20;
                }
            }
        }

        if (target.life <= 0)
        {
            if (ancientGunslinger)
            {
                if (proj.owner == Main.myPlayer && proj.DamageType == DamageClass.Ranged)
                {
                    Projectile.NewProjectile(Player.GetProjectileSource_OnHit(target, ProjectileSourceID.None), target.position, Vector2.Zero, ModContent.ProjectileType<SandyExplosion>(), damage * 2, knockback);
                }
            }
        }

        if (crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                if (Player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                {
                    reckoningLevel += 1;
                }
            }

            if (avalonRestoration)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
            }
        }
    }
    public override void OnHitPvp(Item item, Player target, int damage, bool crit)
    {
        if (crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                if (Player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                {
                    reckoningLevel += 1;
                }
            }

            if (avalonRestoration)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
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
                if (Player.whoAmI == Main.myPlayer && reckoningTimeLeft > 0 && reckoningLevel < 10)
                {
                    reckoningLevel += 1;
                }
            }

            if (avalonRestoration)
            {
                Player.AddBuff(ModContent.BuffType<Buffs.BlessingofAvalon>(), 120);
            }
        }
    }
    public override void OnHitByNPC(NPC npc, int damage, bool crit)
    {
        if (stingerPack)
        {
            float shootSpeed = 6f;
            Vector2 center = Player.Center;
            SoundEngine.PlaySound(2, Player.position, 17);
            float num572 = (float)Math.Atan2(center.Y - npc.Center.Y, center.X - npc.Center.X);
            for (float f = 0f; f <= 3.6f; f += 0.4f)
            {
                int proj = Projectile.NewProjectile(npc.GetSpawnSource_ForProjectile(), center.X, center.Y, (float)(Math.Cos(num572 + f) * shootSpeed * -1), (float)(Math.Sin(num572 + f) * shootSpeed * -1.0), ProjectileID.Stinger, 60, 0f, 0, 0f, 0f);
                Main.projectile[proj].timeLeft = 600;
                Main.projectile[proj].tileCollide = false;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.SyncProjectile, -1, -1, NetworkText.FromLiteral(""), proj, 0f, 0f, 0f, 0);
                }
                proj = Projectile.NewProjectile(npc.GetSpawnSource_ForProjectile(), center.X, center.Y, (float)(Math.Cos(num572 - f) * shootSpeed * -1), (float)(Math.Sin(num572 - f) * shootSpeed * -1.0), ProjectileID.Stinger, 60, 0f, 0, 0f, 0f);
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
        if (auraThorns && !Player.immune && !npc.dontTakeDamage)
        {
            int x = (int)Player.position.X;
            int y = (int)Player.position.Y;
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
                        NetMessage.SendData(MessageID.DamageNPC, -1, -1, NetworkText.FromLiteral(""), N2.whoAmI, damage, 0f, 0f, 0);
                    }
                }
            }
        }
        if (doubleDamage && !Player.immune && !npc.dontTakeDamage)
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
        if (Player.HasBuff(ModContent.BuffType<BacteriaEndurance>()))
        {
            damage += 8;
        }
        if (target.HasBuff(ModContent.BuffType<AstralCurse>()))
        {
            damage *= 3;
        }
        if (target.HasBuff(ModContent.BuffType<CurseofAvalon>()))
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
        if (Player.inventory[Player.selectedItem].type == ModContent.ItemType<GoldSwordNet>() || Player.inventory[Player.selectedItem].type == ModContent.ItemType<ExcaliburNet>() || Player.inventory[Player.selectedItem].type == ModContent.ItemType<Oblivionet>() || Player.inventory[Player.selectedItem].type == ModContent.ItemType<PlatinumSwordNet>() || Player.inventory[Player.selectedItem].type == ModContent.ItemType<BismuthSwordNet>())
        {
            if (target.catchItem > 0)
            {
                NPC.CatchNPC(target.whoAmI, Player.whoAmI);
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
        if (Player.HasBuff(ModContent.BuffType<Buffs.BacteriaEndurance>()))
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
            target.DelBuff(target.FindBuffIndex(ModContent.BuffType<CurseofAvalon>()));
        }

        if (hyperMelee && proj.DamageType == DamageClass.Melee)
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
        if (hyperRanged && proj.DamageType == DamageClass.Ranged)
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
        if (hyperMagic && proj.DamageType == DamageClass.Magic)
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
    public override void SaveData(TagCompound tag)
    {
        tag = new TagCompound
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
    }
    public override void LoadData(TagCompound tag)
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

            if (Player.statLifeMax == 500)
            {
                Player.statLifeMax += crystalHealth *= 25;
                Player.statLifeMax2 += crystalHealth *= 25;
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
    public override void PostUpdate()
    {
        //Main.worldRate = 7;
        #region player sensor
        int pposX = (int)(Player.position.X / 16);
        int pposY = (int)(Player.position.Y / 16);
        int pposXOld = (int)(Player.oldPosition.X / 16);
        int pposYOld = (int)(Player.oldPosition.Y / 16);
        // x, y
        if (Main.tile[pposX, pposY].TileType == ModContent.TileType<Tiles.PlayerSensor>())
        {
            if (!pSensor[0])
            {
                SoundEngine.PlaySound(28, pposX * 16, pposY * 16, 0);
                Wiring.TripWire(pposX, pposY, 1, 1);
                pSensor[0] = true;
            }
        }
        else pSensor[0] = false;
        // x + 1, y
        if (Main.tile[pposX + 1, pposY].TileType == ModContent.TileType<Tiles.PlayerSensor>())
        {
            if (!pSensor[1])
            {
                SoundEngine.PlaySound(28, (pposX + 1) * 16, pposY * 16, 0);
                Wiring.TripWire(pposX + 1, pposY, 1, 1);
                pSensor[1] = true;
            }
        }
        else pSensor[1] = false;
        // x, y + 1
        if (Main.tile[pposX, pposY + 1].TileType == ModContent.TileType<Tiles.PlayerSensor>())
        {
            if (!pSensor[2])
            {
                SoundEngine.PlaySound(28, pposX * 16, (pposY + 1) * 16, 0);
                Wiring.TripWire(pposX, pposY + 1, 1, 1);
                pSensor[2] = true;
            }
        }
        else pSensor[2] = false;
        // x + 1, y + 1
        if (Main.tile[pposX + 1, pposY + 1].TileType == ModContent.TileType<Tiles.PlayerSensor>())
        {
            if (!pSensor[3])
            {
                SoundEngine.PlaySound(28, (pposX + 1) * 16, (pposY + 1) * 16, 0);
                Wiring.TripWire(pposX + 1, pposY + 1, 1, 1);
                pSensor[3] = true;
            }
        }
        else pSensor[3] = false;
        // x, y + 2
        if (Main.tile[pposX, pposY + 2].TileType == ModContent.TileType<Tiles.PlayerSensor>())
        {
            if (!pSensor[4])
            {
                SoundEngine.PlaySound(28, pposX * 16, (pposY + 2) * 16, 0);
                Wiring.TripWire(pposX, pposY + 2, 1, 1);
                pSensor[4] = true;
            }
        }
        else pSensor[4] = false;
        // x + 1, y + 1
        if (Main.tile[pposX + 1, pposY + 2].TileType == ModContent.TileType<Tiles.PlayerSensor>())
        {
            if (!pSensor[5])
            {
                SoundEngine.PlaySound(28, (pposX + 1) * 16, (pposY + 2) * 16, 0);
                Wiring.TripWire(pposX + 1, pposY + 2, 1, 1);
                pSensor[5] = true;
            }
        }
        else pSensor[5] = false;
        #endregion

        if (!astralProject && Player.HasBuff(ModContent.BuffType<AstralProjecting>()))
        {
            Player.DelBuff(ModContent.BuffType<AstralProjecting>());
        }
        if (screenShakeTimer == 1)
        {
            SoundEngine.PlaySound(SoundLoader.GetLegacySoundSlot(Mod, "Sounds/Item/Stomp"), (int)Player.position.X, (int)Player.position.Y);
        }
        if (screenShakeTimer > 0)
        {
            screenShakeTimer--;
        }

        Vector2 pposTile = Player.Center / 16;
        for (int xpos = (int)pposTile.X - 4; xpos <= (int)pposTile.X + 4; xpos++)
        {
            for (int ypos = (int)pposTile.Y - 4; ypos <= (int)pposTile.Y + 4; ypos++)
            {
                if (Main.tile[xpos, ypos].TileType == (ushort)ModContent.TileType<Tiles.Ores.TritanoriumOre>() || Main.tile[xpos, ypos].TileType == (ushort)ModContent.TileType<Tiles.Ores.PyroscoricOre>())
                {
                    if (!luckTome && !blahWings)
                    {
                        Player.AddBuff(ModContent.BuffType<Melting>(), 60);
                    }
                }
            }
        }

        if (ZoneFlight) Player.slowFall = true; // doesn't work
        if (ZoneFright) Player.statDefense += 5;
        if (ZoneIceSoul) slimeBand = true; // doesn't work
        if (ZoneMight) Player.GetDamage(DamageClass.Generic) += 0.06f;
        if (ZoneNight) Player.wolfAcc = true;
        if (ZoneTime) Player.accWatch = 3;
        if (ZoneTorture) Player.AllCrit(6);
        if (ZoneSight) Player.detectCreature = Player.dangerSense = Player.nightVision = true;
        if (ZoneDelight) Player.lifeRegen += 3;
        if (ZoneHumidity) Player.resistCold = true;
        if (ZoneBlight) Player.armorPenetration += 10;

        #region rift goggles

        if (Player.ZoneCrimson || Player.ZoneCorrupt || ZoneContagion)
        {
            if (Main.rand.Next(3000) == 0 && riftGoggles)
            {
                Vector2 pposTile2 = Player.position + new Vector2(Main.rand.Next(-20 * 16, 21 * 16), Main.rand.Next(-20 * 16, 21 * 16));
                Point pt = pposTile2.ToTileCoordinates();
                if (!Main.tile[pt.X, pt.Y].HasTile)
                {
                    int proj = NPC.NewNPC(Player.GetNPCSource_TileInteraction(pt.X, pt.Y), pt.X * 16, pt.Y * 16, ModContent.NPCType<NPCs.Rift>(), 0);
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
            if (Player.ZoneRockLayerHeight)
            {
                Vector2 pposTile2 = Player.position + new Vector2(Main.rand.Next(-35 * 16, 35 * 16), Main.rand.Next(-35 * 16, 35 * 16));
                Point pt = pposTile2.ToTileCoordinates();
                int proj = NPC.NewNPC(Player.GetNPCSource_TileInteraction(pt.X, pt.Y), pt.X * 16, pt.Y * 16, ModContent.NPCType<NPCs.Rift>(), ai1: 1);
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

        // Herbology bench distance check
        if (herb)
        {
            int num9 = (int)((Player.position.X + Player.width * 0.5) / 16.0);
            int num10 = (int)((Player.position.Y + Player.height * 0.5) / 16.0);
            if (num9 < herbX - Player.tileRangeX || num9 > herbX + Player.tileRangeX + 1 || num10 < herbY - Player.tileRangeY || num10 > herbY + Player.tileRangeY + 1)
            {
                SoundEngine.PlaySound(SoundID.MenuClose, -1, -1, 1);
                Player.Avalon().herb = false;
                Player.dropItemCheck();
            }
        }
        if (!Main.playerInventory)
        {
            Player.Avalon().herb = false;
        }
        slimeImmune = false;
        if (Player.tongued)
        {
            bool flag21 = false;
            if (ExxoAvalonOriginsWorld.wos >= 0)
            {
                float num159 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + Main.npc[ExxoAvalonOriginsWorld.wos].width / 2;
                num159 += Main.npc[ExxoAvalonOriginsWorld.wos].direction * 200;
                float num160 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + Main.npc[ExxoAvalonOriginsWorld.wos].height / 2;
                var vector5 = new Vector2(Player.position.X + Player.width * 0.5f, Player.position.Y + Player.height * 0.5f);
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
                Player.velocity.X = num161;
                Player.velocity.Y = num162;
                Player.position += Player.velocity;
            }
            if (flag21 && Main.myPlayer == Player.whoAmI)
            {
                for (int num166 = 0; num166 < 22; num166++)
                {
                    if (Player.buffType[num166] == 38)
                    {
                        Player.DelBuff(num166);
                    }
                }
            }
        }

        // Large gem inventory checking
        Player.gemCount = 0;
        gemCount++;
        if (gemCount >= 10)
        {
            Player.gem = -1;
            ownedLargeGems = new bool[10];
            gemCount = 0;
            for (int num27 = 0; num27 <= 58; num27++)
            {
                if (Player.inventory[num27].type == ItemID.None || Player.inventory[num27].stack == 0)
                {
                    Player.inventory[num27].TurnToAir();
                }
                // Vanilla gems
                if (Player.inventory[num27].type >= ItemID.LargeAmethyst && Player.inventory[num27].type <= ItemID.LargeDiamond)
                {
                    Player.gem = Player.inventory[num27].type - 1522;
                    ownedLargeGems[Player.gem] = true;
                }
                else if (Player.inventory[num27].type == ItemID.LargeAmber)
                {
                    Player.gem = 6;
                    ownedLargeGems[Player.gem] = true;
                }
                // Modded gems
                else if (Player.inventory[num27].type == ModContent.ItemType<Items.Other.LargeZircon>())
                {
                    Player.gem = 7;
                    ownedLargeGems[Player.gem] = true;
                }
                else if (Player.inventory[num27].type == ModContent.ItemType<Items.Other.LargeTourmaline>())
                {
                    Player.gem = 8;
                    ownedLargeGems[Player.gem] = true;
                }
                else if (Player.inventory[num27].type == ModContent.ItemType<Items.Other.LargePeridot>())
                {
                    Player.gem = 9;
                    ownedLargeGems[Player.gem] = true;
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

                if (npc.Center.X >= Player.Center.X - 320 &&
                    npc.Center.X <= Player.Center.X + 320 &&
                    npc.Center.Y >= Player.Center.Y - 320 &&
                    npc.Center.Y <= Player.Center.Y + 320)
                {
                    int count = 0;
                    if (count++ % 50 == 0)
                    {
                        foreach (NPC target in Main.npc)
                        {
                            if (target.Center.X >= Player.Center.X - 320 &&
                                target.Center.X <= Player.Center.X + 320 &&
                                target.Center.Y >= Player.Center.Y - 320 &&
                                target.Center.Y <= Player.Center.Y + 320)
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

                                target.AddBuff(ModContent.BuffType<NecroticDrain>(), 2);
                            }
                        }
                        count = 0;
                    }
                }
            }
        }

        if (reckoning)
        {
            if (Player.whoAmI == Main.myPlayer)
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

                Player.GetCritChance(DamageClass.Ranged) += 3 * reckoningLevel;
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
    public override void ModifyDrawInfo(ref PlayerDrawSet drawInfo)
    {
        if (Player.HasItemInArmor(ModContent.ItemType<ShadowRing>()))
        {
            drawInfo.shadow = 0f;
        }
        if (blahArmor)
        {
            drawInfo.shadow = 0f;
        }
        if (spectrumBlur)
        {
            Player.eocDash = 1;
        }
    }
    public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
        if (ExxoAvalonOrigins.GodMode)
        {
            return false;
        }

        if (spectrumBlur && Player.whoAmI == Main.myPlayer && Main.rand.Next(10) == 0)
        {
            SpectrumDodge();
            return false;
        }
        return true;
    }
    public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
    {
        if (Main.myPlayer == Player.whoAmI)
        {
            Player.trashItem.SetDefaults();
            if (Player.difficulty == 0)
            {
                for (int i = 0; i < 59; i++)
                {
                    if (Player.inventory[i].stack > 0 &&
                        (Player.inventory[i].type == ModContent.ItemType<Items.Other.LargeZircon>() ||
                         Player.inventory[i].type == ModContent.ItemType<Items.Other.LargeTourmaline>() ||
                         Player.inventory[i].type == ModContent.ItemType<Items.Other.LargePeridot>()))
                    {
                        int num = Item.NewItem(Player.GetItemSource_Death(), (int)Player.position.X, (int)Player.position.Y, Player.width, Player.height, Player.inventory[i].type);
                        Main.item[num].netDefaults(Player.inventory[i].netID);
                        Main.item[num].Prefix(Player.inventory[i].prefix);
                        Main.item[num].stack = Player.inventory[i].stack;
                        Main.item[num].velocity.Y = Main.rand.Next(-20, 1) * 0.2f;
                        Main.item[num].velocity.X = Main.rand.Next(-20, 21) * 0.2f;
                        Main.item[num].noGrabDelay = 100;
                        Main.item[num].favorited = false;
                        Main.item[num].newAndShiny = false;
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.SyncItem, -1, -1, null, num);
                        }
                        Player.inventory[i].SetDefaults();
                    }
                }
            }
        }
    }
    public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
    {
        if (Player.whoAmI == Main.myPlayer && incDef)
        {
            int time = 300;
            if (cOmega)
            {
                time = 600;
            }
            Player.AddBuff(BuffID.Ironskin, time, true);
        }

        if (Player.whoAmI == Main.myPlayer && regenStrike)
        {
            int hpHealed = 5;
            if (pOmega)
            {
                hpHealed = 10;
            }

            Player.statLife += hpHealed;
            Player.HealEffect(hpHealed, true);
        }
        if (Player.whoAmI == Main.myPlayer && bOfBacteria)
        {
            Player.AddBuff(ModContent.BuffType<BacteriaEndurance>(), 6 * 60, true);
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
        if (NumHookProj() > 0 || Player.sliding || (Player.autoJump && Player.justJumped))
        {
            jumpAgainQuack = true;
            return;
        }
        bool flag = true;
        if (Player.mount != null && Player.mount.Active)
        {
            flag = Player.mount.BlockExtraJumps;
        }
        bool flag2 = (Player.carpet ? Player.carpetTime <= 0 && Player.canCarpet : true);
        if (Player.position.Y == Player.oldPosition.Y && flag && flag2)
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
            Player.sticky = false;
        }
        if (Player.HasItem(ModContent.ItemType<SonicScrewdriverMkI>()))
        {
            Player.findTreasure = Player.detectCreature = true;
        }
        if (Player.HasItem(ModContent.ItemType<SonicScrewdriverMkII>()))
        {
            Player.findTreasure = Player.detectCreature = true;
            Player.accWatch = 3;
            Player.accDepthMeter = 1;
            Player.accCompass = 1;
        }
        if (Player.HasItem(ModContent.ItemType<SonicScrewdriverMkIII>()))
        {
            Player.findTreasure = Player.detectCreature = Player.dangerSense = openLocks = true;
            Player.accWatch = 3;
            Player.accDepthMeter = 1;
            Player.accCompass = 1;
        }
        if (bloodCast)
        {
            Player.statManaMax2 += Player.statLifeMax2;
        }
        if (dragonsBondage)
        {
            if (Player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Melee.DragonBall>()] == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    int newBall = Projectile.NewProjectile(Player.GetProjectileSource_Accessory(new Item(ModContent.ItemType<DragonsBondage>())), Player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Melee.DragonBall>(), (Player.HeldItem.damage / 2) * 3, 1f, Player.whoAmI);
                    Main.projectile[newBall].localAI[0] = i;
                }
            }
        }
        else
        {
            if (Player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Melee.DragonBall>()] != 0)
            {
                for (int i = 0; i < Main.maxProjectiles; i++)
                {
                    if (Main.projectile[i].type == ModContent.ProjectileType<Projectiles.Melee.DragonBall>() && Main.projectile[i].owner == Player.whoAmI)
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
                maxSpeed = Player.maxRunSpeed;
            }

            damagePercent = (-25f * (float)(Math.Abs(Player.velocity.X) / maxSpeed)) + 25f;

            if (damagePercent < 0)
            {
                damagePercent = 0;
            }

            if (Math.Abs(Player.velocity.X) >= maxSpeed)
            {
                Player.AddBuff(ModContent.BuffType<SpectrumBlur>(), 5);
            }

            Player.GetDamage(DamageClass.Ranged) += damagePercent / 100f;
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
        Player.statManaMax2 += (spiritPoppyUseCount * 20);
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

        Player.breathMax = 200;
        if (ZoneFlight) Player.slowFall = true;
        // Large gem trashing logic
        if (Player.whoAmI == Main.myPlayer)
        {
            if (
                Player.trashItem.type == ModContent.ItemType<Items.Other.LargeZircon>() ||
                Player.trashItem.type == ModContent.ItemType<Items.Other.LargeTourmaline>() ||
                Player.trashItem.type == ModContent.ItemType<Items.Other.LargePeridot>()
            )
            {
                Player.trashItem.SetDefaults();
            }
        }
    }
    public static int NumHookProj()
    {
        return Main.projectile.Count((Projectile p) => Main.projHook[p.type] && p.active && p.ai[0] == 2f && p.owner == Main.myPlayer);
    }
    public void DashMovement()
    {
        if (Player.dashDelay > 0)
        {
            Player.dashDelay--;
            return;
        }
        int amt = 60;
        if (staminaDrain)
        {
            amt *= (int)(staminaDrainStacks * staminaDrainMult);
        }
        if (stamDashKey && Player.dash == 0 && Player.dashDelay >= 0)
        {
            if (statStam > amt)
            {
                int num2 = 0;
                bool flag = false;
                if (Player.dashTime > 0)
                {
                    Player.dashTime--;
                }
                if (Player.dashTime < 0)
                {
                    Player.dashTime++;
                }
                if (Player.controlRight && Player.releaseRight)
                {
                    if (Player.dashTime > 0)
                    {
                        num2 = 1;
                        flag = true;
                        Player.dashTime = 0;
                        statStam -= amt;
                    }
                    else
                    {
                        Player.dashTime = 15;
                    }
                }
                else if (Player.controlLeft && Player.releaseLeft)
                {
                    if (Player.dashTime < 0)
                    {
                        num2 = -1;
                        flag = true;
                        Player.dashTime = 0;
                        statStam -= amt;
                    }
                    else
                    {
                        Player.dashTime = -15;
                    }
                }
                if (flag)
                {
                    Player.velocity.X = 15.9f * num2;
                    Player.dashDelay = -1;
                    for (int j = 0; j < 20; j++)
                    {
                        int num3 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                        Dust expr_336_cp_0 = Main.dust[num3];
                        expr_336_cp_0.position.X = expr_336_cp_0.position.X + Main.rand.Next(-5, 6);
                        Dust expr_35D_cp_0 = Main.dust[num3];
                        expr_35D_cp_0.position.Y = expr_35D_cp_0.position.Y + Main.rand.Next(-5, 6);
                        Main.dust[num3].velocity *= 0.2f;
                        Main.dust[num3].scale *= 1f + Main.rand.Next(20) * 0.01f;
                    }
                    int num4 = Gore.NewGore(new Vector2(Player.position.X + Player.width / 2 - 24f, Player.position.Y + Player.height / 2 - 34f), default, Main.rand.Next(61, 64), 1f);
                    Main.gore[num4].velocity.X = Main.rand.Next(-50, 51) * 0.01f;
                    Main.gore[num4].velocity.Y = Main.rand.Next(-50, 51) * 0.01f;
                    Main.gore[num4].velocity *= 0.4f;
                    num4 = Gore.NewGore(new Vector2(Player.position.X + Player.width / 2 - 24f, Player.position.Y + Player.height / 2 - 14f), default, Main.rand.Next(61, 64), 1f);
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
                    if (Player.dashTime > 0)
                    {
                        Player.dashTime--;
                    }
                    if (Player.dashTime < 0)
                    {
                        Player.dashTime++;
                    }
                    if (Player.controlRight && Player.releaseRight)
                    {
                        if (Player.dashTime > 0)
                        {
                            num2 = 1;
                            flag = true;
                            Player.dashTime = 0;
                            statStam -= amt;
                        }
                        else
                        {
                            Player.dashTime = 15;
                        }
                    }
                    else if (Player.controlLeft && Player.releaseLeft)
                    {
                        if (Player.dashTime < 0)
                        {
                            num2 = -1;
                            flag = true;
                            Player.dashTime = 0;
                            statStam -= amt;
                        }
                        else
                        {
                            Player.dashTime = -15;
                        }
                    }
                    if (flag)
                    {
                        Player.velocity.X = 15.9f * num2;
                        Player.dashDelay = -1;
                        for (int j = 0; j < 20; j++)
                        {
                            int num3 = Dust.NewDust(new Vector2(Player.position.X, Player.position.Y), Player.width, Player.height, DustID.Smoke, 0f, 0f, 100, default, 2f);
                            Dust expr_336_cp_0 = Main.dust[num3];
                            expr_336_cp_0.position.X = expr_336_cp_0.position.X + Main.rand.Next(-5, 6);
                            Dust expr_35D_cp_0 = Main.dust[num3];
                            expr_35D_cp_0.position.Y = expr_35D_cp_0.position.Y + Main.rand.Next(-5, 6);
                            Main.dust[num3].velocity *= 0.2f;
                            Main.dust[num3].scale *= 1f + Main.rand.Next(20) * 0.01f;
                        }
                        int num4 = Gore.NewGore(new Vector2(Player.position.X + Player.width / 2 - 24f, Player.position.Y + Player.height / 2 - 34f), default, Main.rand.Next(61, 64), 1f);
                        Main.gore[num4].velocity.X = Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num4].velocity.Y = Main.rand.Next(-50, 51) * 0.01f;
                        Main.gore[num4].velocity *= 0.4f;
                        num4 = Gore.NewGore(new Vector2(Player.position.X + Player.width / 2 - 24f, Player.position.Y + Player.height / 2 - 14f), default, Main.rand.Next(61, 64), 1f);
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
        if (KeybindSystem.QuickStaminaHotkey.JustPressed)
        {
            QuickStamina();
        }
        if (KeybindSystem.FlightTimeRestoreHotkey.JustPressed && Player.wingsLogic > 0 && Player.wingTime == 0 && flightRestoreUnlocked && stamFlightRestoreCD >= 60 * 60)
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
                Player.wingTime = Player.wingTimeMax;
            }
            else if (stamFlower)
            {
                QuickStamina(amt);
                if (statStam >= amt)
                {
                    statStam -= amt;
                    stamFlightRestoreCD = 0;
                    Player.wingTime = Player.wingTimeMax;
                }
            }
        }
        if (KeybindSystem.ShadowHotkey.JustPressed && tpStam && tpCD >= 300 && teleportUnlocked)
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
                if (Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].WallType != ModContent.WallType<Walls.ImperviousBrickWallUnsafe>() &&
                    Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].WallType != WallID.LihzahrdBrickUnsafe)
                {
                    for (int m = 0; m < 70; m++)
                    {
                        Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, Player.velocity.X * 0.5f, Player.velocity.Y * 0.5f, 150, default, 1.1f);
                    }
                    Player.position.X = Main.mouseX + Main.screenPosition.X;
                    Player.position.Y = Main.mouseY + Main.screenPosition.Y;
                    for (int n = 0; n < 70; n++)
                    {
                        Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
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
                    if (Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].WallType != ModContent.WallType<Walls.ImperviousBrickWallUnsafe>() &&
                        Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].WallType != WallID.LihzahrdBrickUnsafe &&
                        !Main.wallDungeon[Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].WallType])
                    {
                        for (int m = 0; m < 70; m++)
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, Player.velocity.X * 0.5f, Player.velocity.Y * 0.5f, 150, default, 1.1f);
                        }
                        Player.position.X = Main.mouseX + Main.screenPosition.X;
                        Player.position.Y = Main.mouseY + Main.screenPosition.Y;
                        for (int n = 0; n < 70; n++)
                        {
                            Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
                        }
                    }
                }
            }
        }
        else if (KeybindSystem.ShadowHotkey.JustPressed && (teleportV || teleportVWasTriggered) && tpCD >= 300)
        {
            teleportVWasTriggered = false;
            tpCD = 0;
            if (Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].WallType != ModContent.WallType<Walls.ImperviousBrickWallUnsafe>() &&
                Main.tile[(int)(Main.mouseX + Main.screenPosition.X) / 16, (int)(Main.mouseY + Main.screenPosition.Y) / 16].WallType != WallID.LihzahrdBrickUnsafe)
            {
                for (int m = 0; m < 70; m++)
                {
                    Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, Player.velocity.X * 0.5f, Player.velocity.Y * 0.5f, 150, default, 1.1f);
                }
                Player.position.X = Main.mouseX + Main.screenPosition.X;
                Player.position.Y = Main.mouseY + Main.screenPosition.Y;
                for (int n = 0; n < 70; n++)
                {
                    Dust.NewDust(Player.position, Player.width, Player.height, DustID.MagicMirror, 0f, 0f, 150, default, 1.1f);
                }
            }
        }
        if (KeybindSystem.AstralHotkey.JustPressed && astralProject)
        {
            if (astralStart)
            {
                if (Player.HasBuff(ModContent.BuffType<AstralProjecting>()))
                {
                    Player.ClearBuff(ModContent.BuffType<AstralProjecting>());
                }
            }
            if (astralCD >= 3600)
            {
                astralCD = 0;
                if (!astralStart)
                {
                    Player.AddBuff(ModContent.BuffType<AstralProjecting>(), 15 * 60);
                }
            }
        }

        #region other hotkeys
        if (KeybindSystem.RocketJumpHotkey.JustPressed && rocketJumpUnlocked)
        {
            activateRocketJump = !activateRocketJump;
            Main.NewText(!activateRocketJump ? "Rocket Jump Off" : "Rocket Jump On");
        }

        if (KeybindSystem.SprintHotkey.JustPressed && sprintUnlocked)
        {
            activateSprint = !activateSprint;
            Main.NewText(!activateSprint ? "Sprinting Off" : "Sprinting On");
        }

        if (KeybindSystem.DashHotkey.JustPressed)
        {
            stamDashKey = !stamDashKey;
            Main.NewText(!stamDashKey ? "Dashing Off" : "Dashing On");
        }

        if (KeybindSystem.QuintupleHotkey.JustPressed)
        {
            quintJump = !quintJump;
            Main.NewText(!quintJump ? "Quintuple Jump Off" : "Quintuple Jump On");
        }

        if (KeybindSystem.SwimHotkey.JustPressed && swimmingUnlocked)
        {
            activateSwim = !activateSwim;
            Main.NewText(!activateSwim ? "Swimming Off" : "Swimming On");
        }

        if (KeybindSystem.WallSlideHotkey.JustPressed)
        {
            activateSlide = !activateSlide;
            Main.NewText(!activateSlide ? "Wall Sliding Off" : "Wall Sliding On");
        }

        if (KeybindSystem.BubbleBoostHotkey.JustPressed)
        {
            activateBubble = !activateBubble;
            Main.NewText(!activateBubble ? "Bubble Boost Off" : "Bubble Boost On");
        }
        #endregion
        if (Player.inventory[Player.selectedItem].type == ModContent.ItemType<Items.Tools.AccelerationDrill>() && KeybindSystem.ModeChangeHotkey.JustPressed)
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

        if (Main.netMode != NetmodeID.SinglePlayer && Player.inventory[Player.selectedItem].type == ModContent.ItemType<EideticMirror>() &&
            KeybindSystem.ModeChangeHotkey.JustPressed)
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
                if (Main.player[newPlayer].active && Player.whoAmI != newPlayer && !Main.player[newPlayer].dead && Main.player[Main.myPlayer].team > 0 && Main.player[Main.myPlayer].team == Main.player[newPlayer].team)
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

        if (Player.inventory[Player.selectedItem].type == ModContent.ItemType<ShadowMirror>())
        {
            Player.noFallDmg = true; //TODO: Replace with better anti-fall-damage mechanism.
            if (KeybindSystem.ModeChangeHotkey.JustPressed)
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
        if (Player.mount != null && Player.mount.Active)
        {
            flag = Player.mount.BlockExtraJumps;
        }
        bool flag2 = (!Player.hasJumpOption_Cloud || !Player.canJumpAgain_Cloud) && (!Player.hasJumpOption_Sandstorm || !Player.canJumpAgain_Sandstorm) && (!Player.hasJumpOption_Blizzard || !Player.canJumpAgain_Blizzard) && (!Player.hasJumpOption_Fart || !Player.canJumpAgain_Fart) && (!Player.hasJumpOption_Sail || !Player.canJumpAgain_Sail) && (!Player.hasJumpOption_Unicorn || !Player.canJumpAgain_Unicorn) && NumHookProj() <= 0 && flag;
        if (!(PlayerInput.Triggers.JustPressed.Jump && Player.position.Y != Player.oldPosition.Y && flag2))
        {
            return;
        }
        if (quackJump && jumpAgainQuack)
        {
            jumpAgainQuack = false;
            int h = Player.height;
            if (Player.gravDir == -1)
            {
                h = -6;
            }
            SoundEngine.PlaySound(SoundID.Zombie, Player.position, 12);
            Player.velocity.Y = -Player.jumpSpeed * Player.gravDir;
            Player.jump = (int)(Player.jumpHeight * 1.25);
            int num8 = Dust.NewDust(new Vector2(Player.position.X - 4f, Player.position.Y + h), Player.width + 8, 4, 188, -Player.velocity.X * 0.5f, Player.velocity.Y * 0.5f, DustID.FartInAJar, default, 1.5f);
            Main.dust[num8].velocity.X = Main.dust[num8].velocity.X * 0.5f - Player.velocity.X * 0.1f;
            Main.dust[num8].velocity.Y = Main.dust[num8].velocity.Y * 0.5f - Player.velocity.Y * 0.3f;
            Main.dust[num8].velocity *= 0.5f;

            int g = Main.rand.Next(2);
            if (g == 0) g = Mod.Find<ModGore>("QuackGore1").Type;
            if (g == 1) g = Mod.Find<ModGore>("QuackGore2").Type;
            int g2 = Main.rand.Next(2);
            if (g2 == 0) g2 = Mod.Find<ModGore>("QuackGore1").Type;
            if (g2 == 1) g2 = Mod.Find<ModGore>("QuackGore2").Type;
            int g3 = Main.rand.Next(2);
            if (g3 == 0) g3 = Mod.Find<ModGore>("QuackGore1").Type;
            if (g3 == 1) g3 = Mod.Find<ModGore>("QuackGore2").Type;
            int num3 = Gore.NewGore(new Vector2(Player.position.X + Player.width / 2 - 16f, Player.position.Y + h - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), g, 1f);
            Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - Player.velocity.X * 0.1f;
            Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
            Main.gore[num3].sticky = false;
            Main.gore[num3].rotation += 0.1f;
            num3 = Gore.NewGore(new Vector2(Player.position.X - 36f, Player.position.Y + h - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), g2, 1f);
            Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - Player.velocity.X * 0.1f;
            Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
            Main.gore[num3].sticky = false;
            Main.gore[num3].rotation += 0.1f;
            num3 = Gore.NewGore(new Vector2(Player.position.X + Player.width + 4f, Player.position.Y + h - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), g3, 1f);
            Main.gore[num3].velocity.X = Main.gore[num3].velocity.X * 0.1f - Player.velocity.X * 0.1f;
            Main.gore[num3].velocity.Y = Main.gore[num3].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
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
                var cloudPosition = new Vector2(Player.Center.X + 0f, Player.Center.Y - 150f);
                var targetPosition = new Vector2(Player.Center.X/* + (-20f * hitDirection)*/, Player.Center.Y);
                var targetPosition2 = new Vector2(Player.Center.X + Main.rand.Next(-40, -20), Player.Center.Y);
                var targetPosition3 = new Vector2(Player.Center.X + Main.rand.Next(-40, -20), Player.Center.Y);
                if (Main.rand.Next(2) == 0)
                {
                    targetPosition2 = new Vector2(Player.Center.X + Main.rand.Next(20, 40), Player.Center.Y);
                }
                if (Main.rand.Next(2) == 0)
                {
                    targetPosition3 = new Vector2(Player.Center.X + Main.rand.Next(20, 40), Player.Center.Y);
                }

                Projectile.NewProjectile(Player.GetProjectileSource_Accessory(new Item(ModContent.ItemType<LightninginaBottle>())), cloudPosition, Vector2.Zero, ModContent.ProjectileType<LightningCloud>(), 0, 0f, Player.whoAmI);

                for (int i = 0; i < 1; i++)
                {
                    Vector2 vectorBetween = targetPosition - cloudPosition;
                    float randomSeed = Main.rand.Next(100);
                    Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                    Projectile.NewProjectile(Player.GetProjectileSource_Accessory(new Item(ModContent.ItemType<LightninginaBottle>())), cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), 47, 0f, Main.myPlayer, vectorBetween.ToRotation(), randomSeed);
                }
                for (int i = 0; i < 1; i++)
                {
                    Vector2 vectorBetween = targetPosition2 - cloudPosition;
                    float randomSeed = Main.rand.Next(100);
                    Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                    Projectile.NewProjectile(Player.GetProjectileSource_Accessory(new Item(ModContent.ItemType<LightninginaBottle>())), cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), 47, 0f, Main.myPlayer, vectorBetween.ToRotation(), randomSeed);
                }
                for (int i = 0; i < 1; i++)
                {
                    Vector2 vectorBetween = targetPosition3 - cloudPosition;
                    float randomSeed = Main.rand.Next(100);
                    Vector2 startVelocity = Vector2.Normalize(vectorBetween.RotatedByRandom(0.78539818525314331)) * 27f;
                    Projectile.NewProjectile(Player.GetProjectileSource_Accessory(new Item(ModContent.ItemType<LightninginaBottle>())), cloudPosition, startVelocity, ModContent.ProjectileType<Lightning>(), 47, 0f, Main.myPlayer, vectorBetween.ToRotation(), randomSeed);
                }
            }

            if (goBerserk)
            {
                if (damage > 50)
                {
                    Player.AddBuff(ModContent.BuffType<Berserk>(), 180);
                }
            }

            if (leafStorm)
            {
                if (damage > 0 && Main.rand.Next(5) == 0)
                {
                    var pos = new Vector2(Player.Center.X + Main.rand.Next(-500, 501), Player.Center.Y);
                    while (Main.tile[(int)(pos.X / 16), (int)(pos.Y / 16)].HasTile)
                    {
                        pos.Y--;
                    }
                    Projectile.NewProjectile(Player.GetProjectileSource_SetBonus(ProjectileSourceID.None), pos, Vector2.Zero, ModContent.ProjectileType<LeafStorm>(), 80, 0.6f, Main.myPlayer);
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
        FloorVisualsAvalon(Player.velocity.Y > Player.gravity);
        if (activateRocketJump && rocketJumpUnlocked)
        {
            if (Player.controlUp && Player.releaseUp)
            {
                if (Player.isOnGround())
                {
                    int amt = 70;
                    if (staminaDrain)
                    {
                        amt *= (int)(staminaDrainStacks * staminaDrainMult);
                    }
                    if (statStam >= amt)
                    {
                        statStam -= amt;
                        float yDestination = Player.position.Y - 360f;
                        int num6 = Gore.NewGore(new Vector2(Player.position.X + (Player.width / 2) - 16f, Player.position.Y + (Player.gravDir == -1 ? 0 : Player.height) - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), Main.rand.Next(11, 14), 1f);
                        Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - Player.velocity.X * 0.1f;
                        Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
                        num6 = Gore.NewGore(new Vector2(Player.position.X - 36f, Player.position.Y + (Player.gravDir == -1 ? 0 : Player.height) - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), Main.rand.Next(11, 14), 1f);
                        Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - Player.velocity.X * 0.1f;
                        Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
                        num6 = Gore.NewGore(new Vector2(Player.position.X + Player.width + 4f, Player.position.Y + (Player.gravDir == -1 ? 0 : Player.height) - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), Main.rand.Next(11, 14), 1f);
                        Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - Player.velocity.X * 0.1f;
                        Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
                        SoundEngine.PlaySound(2, Player.Center, 11);
                        Player.velocity.Y -= 16.5f;
                    }
                    else if (stamFlower)
                    {
                        QuickStamina(amt);
                        if (statStam >= amt)
                        {
                            statStam -= amt;
                            float yDestination = Player.position.Y - 360f;
                            int num6 = Gore.NewGore(new Vector2(Player.position.X + (Player.width / 2) - 16f, Player.position.Y + (Player.gravDir == -1 ? 0 : Player.height) - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - Player.velocity.X * 0.1f;
                            Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
                            num6 = Gore.NewGore(new Vector2(Player.position.X - 36f, Player.position.Y + (Player.gravDir == -1 ? 0 : Player.height) - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - Player.velocity.X * 0.1f;
                            Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
                            num6 = Gore.NewGore(new Vector2(Player.position.X + Player.width + 4f, Player.position.Y + (Player.gravDir == -1 ? 0 : Player.height) - 16f), new Vector2(-Player.velocity.X, -Player.velocity.Y), Main.rand.Next(11, 14), 1f);
                            Main.gore[num6].velocity.X = Main.gore[num6].velocity.X * 0.1f - Player.velocity.X * 0.1f;
                            Main.gore[num6].velocity.Y = Main.gore[num6].velocity.Y * 0.1f - Player.velocity.Y * 0.05f;
                            SoundEngine.PlaySound(2, Player.Center, 11);
                            Player.velocity.Y -= 16.5f;
                        }
                    }
                }
            }
            if (Player.velocity.Y < 0)
            {
                for (int x = 0; x < 5; x++)
                {
                    int d = Dust.NewDust(new Vector2(Player.Center.X, Player.position.Y + Player.height), 10, 10, DustID.Smoke);
                }
            }
        }
        if (Player.wet && Player.velocity != Vector2.Zero && !Player.accMerman && activateSwim && swimmingUnlocked)
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
                Player.accFlipper = true;
            }
        }
        if (activateSprint)
        {
            if ((Player.controlRight || Player.controlLeft) && Player.velocity.X != 0f)
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
                    if (!Player.HasItemInArmor(ItemID.HermesBoots) && !Player.HasItemInArmor(ItemID.FlurryBoots) && !Player.HasItemInArmor(ItemID.SpectreBoots) &&
                        !Player.HasItemInArmor(ItemID.LightningBoots) && !Player.HasItemInArmor(ItemID.FrostsparkBoots) && !Player.HasItemInArmor(ItemID.SailfishBoots) &&
                        !inertiaBoots && !blahWings)
                    {
                        Player.accRunSpeed = 6f;
                    }
                    else if (!Player.HasItemInArmor(ItemID.LightningBoots) && !Player.HasItemInArmor(ItemID.FrostsparkBoots) &&
                             !inertiaBoots && !blahWings)
                    {
                        Player.accRunSpeed = 6.75f;
                    }
                    else if (!inertiaBoots && !blahWings)
                    {
                        Player.accRunSpeed = 10.29f;
                        if ((Player.velocity.X < 4f && Player.controlRight) || (Player.velocity.X > -4f && Player.controlLeft))
                        {
                            Player.velocity.X = Player.velocity.X + (Player.controlRight ? 0.31f : -0.31f);
                        }
                        else if ((Player.velocity.X < 8f && Player.controlRight) || (Player.velocity.X > -8f && Player.controlLeft))
                        {
                            Player.velocity.X = Player.velocity.X + (Player.controlRight ? 0.29f : -0.29f);
                        }
                    }
                    else
                    {
                        Player.accRunSpeed = 14.29f;
                        if ((Player.velocity.X < 5f && Player.controlRight) || (Player.velocity.X > -5f && Player.controlLeft))
                        {
                            Player.velocity.X = Player.velocity.X + (Player.controlRight ? 0.41f : -0.41f);
                        }
                        else if ((Player.velocity.X < 14f && Player.controlRight) || (Player.velocity.X > -14f && Player.controlLeft))
                        {
                            Player.velocity.X = Player.velocity.X + (Player.controlRight ? 0.39f : -0.39f);
                        }
                    }
                }
            }
        }
    }
    public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
    {
        #region Contagion Fish

        if (ZoneContagion && Main.rand.NextBool(10))
        {
            itemDrop = ModContent.ItemType<Items.Fish.NauSeaFish>();
        }

        #endregion Contagion Fish
    }
    public void FloorVisualsAvalon(bool falling)
    {
        int num = (int)((Player.position.X + Player.width / 2) / 16f);
        int num2 = (int)((Player.position.Y + Player.height) / 16f);
        int num3 = -1;
        if (Main.tile[num, num2].HasUnactuatedTile && Main.tileSolid[Main.tile[num, num2].TileType])
        {
            num3 = Main.tile[num, num2].TileType;
        }
        else if (Main.tile[num - 1, num2].HasUnactuatedTile && Main.tileSolid[Main.tile[num - 1, num2].TileType])
        {
            num3 = Main.tile[num - 1, num2].TileType;
        }
        else if (Main.tile[num + 1, num2].HasUnactuatedTile && Main.tileSolid[Main.tile[num + 1, num2].TileType])
        {
            num3 = Main.tile[num + 1, num2].TileType;
        }
        if (num3 > -1)
        {
            if (num3 == 229 && !noSticky)
            {
                Player.sticky = true;
            }
            else
            {
                Player.sticky = false;
            }
            if (slimeBand || ZoneIceSoul)
            {
                Player.slippy = true;
                Player.slippy2 = true;
            }
            else
            {
                Player.slippy = false;
                Player.slippy2 = false;
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
                if (damage - (Player.statDefense / 2 - 10) <= 0)
                {
                    damage = 0;
                    Player.immune = true;
                    Player.immuneAlpha = 0;
                }
                else
                {
                    damage = dmgPlaceholder - (Player.statDefense / 2 - 10);
                }
            }
        }

        if (Player.HasBuff(ModContent.BuffType<Buffs.ShadowCurse>()))
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
        if (Player.HasBuff(ModContent.BuffType<Buffs.ShadowCurse>()))
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
        if (Player.HasBuff(37))
        {
            Player.KillMe(PlayerDeathReason.ByCustomReason(" tried to escape..."), 3000000, 0);
            return;
        }
        switch (mode)
        {
            case 0:
                Player.Spawn(PlayerSpawnContext.RecallFromItem);
                break;
            case 1: // dungeon
                Player.noFallDmg = true;
                Player.immuneTime = 100;
                Logic.ShadowTeleport.Teleport(0);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.PlayerControls, number: Player.whoAmI);
                }
                Player.noFallDmg = false;
                break;

            case 2: // jungle
                Player.noFallDmg = true;
                Player.immuneTime = 100;
                Vector2 prePos = Player.position;
                Vector2 pos = prePos;
                Logic.ShadowTeleport.Teleport(1);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.PlayerControls, number: Player.whoAmI);
                }
                Player.noFallDmg = false;
                break;

            case 3: // left ocean
                Player.noFallDmg = true;
                Player.immuneTime = 300;
                Logic.ShadowTeleport.Teleport(2);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.PlayerControls, number: Player.whoAmI);
                }
                Player.noFallDmg = false;
                break;

            case 4: // right ocean
                Player.noFallDmg = true;
                Player.immuneTime = 300;
                Logic.ShadowTeleport.Teleport(3);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.PlayerControls, number: Player.whoAmI);
                }
                Player.noFallDmg = false;
                break;

            case 5: // hell
                Player.noFallDmg = true;
                Player.immuneTime = 100;
                Logic.ShadowTeleport.Teleport(4);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.PlayerControls, number: Player.whoAmI);
                }
                Player.noFallDmg = false;
                break;

            case 6: // random
                {
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        Player.TeleportationPotion();
                    }
                    else if (Main.netMode == NetmodeID.MultiplayerClient && Player.whoAmI == Main.myPlayer)
                    {
                        NetMessage.SendData(MessageID.Teleport, -1, -1, NetworkText.Empty, 0, 0f, 0f, 0f, 0);
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
            Dust.NewDust(Player.position, Player.width, Player.height, d, 0f, 0f, 150, default(Color), 1.5f);
        }
    }
    public void SpectrumDodge()
    {
        Player.immune = true;
        if (Player.longInvince)
        {
            Player.immuneTime = 60;
        }
        else
        {
            Player.immuneTime = 30;
        }

        SoundEngine.PlaySound(SoundID.Item, Player.position, SoundLoader.GetSoundSlot(Mod, "Sounds/Item/SpectrumDodge"));
        for (int i = 0; i < Player.hurtCooldowns.Length; i++)
        {
            Player.hurtCooldowns[i] = Player.immuneTime;
        }
        if (Player.whoAmI == Main.myPlayer)
        {
            NetMessage.SendData(MessageID.Dodge, -1, -1, null, Player.whoAmI, 1f, 0f, 0f, 0, 0, 0);
        }
    }
}
