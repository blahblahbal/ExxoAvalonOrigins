using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Consumables;
using ExxoAvalonOrigins.Items.Material;
using ExxoAvalonOrigins.Items.Placeable.Painting;
using ExxoAvalonOrigins.Items.Placeable.Tile;
using ExxoAvalonOrigins.Items.Placeable.Trophy;
using ExxoAvalonOrigins.Items.Vanity;
using ExxoAvalonOrigins.Items.Weapons.Magic;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using System.Collections.Generic;
using System;
using log4net;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ExxoAvalonOrigins.NPCs;
using static Terraria.ModLoader.ModContent;

namespace ExxoAvalonOrigins;

/// <summary>
/// Someone, set-up prices here for Fargo's Mod Support.
/// </summary>
public static class ExxoAvalonOriginsCall
{
    public static ILog Logger = ExxoAvalonOrigins.Mod.Logger;

    #region Mod Calls
    // The Great Dictionary about Mod Calls for Blahblahblah from Exxo Avalon Origins by Fox
    //
    // HOW TO USE SPECIFIC CALLS
    //
    // Part 1: GetInZoneX
    // ModLoader.GetMod("ExxoAvalonOrigins") // Gets mod
    //      .Call(                           // Start using call
    //          "GetInZoneBooger",           // Method name, as example here "GetInZoneBooger" which provides us Booger Zone! :D
    //          player                       // Use player or player.whoAmI to get about which player it will get info
    //      );
    //                                       // As result, it will return true either false, depending on Zone's state
    //
    // Part 2: GetWorldAltX
    // ModLoader.GetMod("ExxoAvalonOrigins") // Gets mod
    //      .Call(                           // Start using call
    //          "GetWorldAltCopper"          // Method name, as example here "GetWorldAltCopper" which provides us Copper/Tin/Bronze Ores! :D
    //      );
    //                                       // As result, it will return 1, 2 or 3. Correspondently it's: 1 = Copper, 2 = Tin, 3 = Bronze.
    //
    // Part 3: IsDownedX
    // ModLoader.GetMod("ExxoAvalonOrigins") // Gets mod
    //      .Call(                           // Start using call
    //          "IsDownedBacterium"          // Method name, as example here "IsDownedBacterium" which provides us boolean, ig?
    //      );
    //                                       // As result, it will return true either false, depending on if boss was downed or not.

    public static object Call(params object[] args)
    {
        if (args.Length == 0 || args[0] is not string)
        {
            Logger.Error("CALL ERROR: NO METHOD NAME! First param MUST be a method name!");
            return null;
        }
        if (args.Length >= 1)
        {
            switch ((args[0] as string)?.ToLower())
            {
                #region GetInZoneX
                case "getinzonebooger":
                case "getinzonecontagion":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneContagion;
                }
                case "getinzonecomet":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneComet;
                }
                case "getinzonehellcastle":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneHellcastle;
                }
                case "getinzonedark":
                case "getinzonedarkmatter":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneDarkMatter;
                }
                case "getinzonejunglealt":
                case "getinzonetropics":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneTropics;
                }
                case "getinzonecaesium":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneCaesium;
                }
                case "getinzoneoutpost":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneOutpost;
                }
                case "getinzonefortress":
                case "getinzoneskyfortress":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneSkyFortress;
                }
                case "getinzonemines":
                case "getinzonecrystal":
                case "getinzonecrystalmine":
                case "getinzonecrystalmines":
                {
                    Player player = null;
                    if (args[1] is int num)
                        player = Main.player[num];
                    else if (args[1] is Player player1)
                        player = player1;

                    if (player == null)
                    {
                        Logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                        return null;
                    }

                    return player.Avalon().ZoneCrystal;
                }
                #endregion

                #region GetWorldAltX
                case "getworldaltcopper":
                case "getworldalttin":
                case "getworldaltbronze":
                case "getworldaltprehm1":
                case "getworldaltprehmtier1":
                case "getworldaltprehmtierone":
                    return (int)ExxoAvalonOriginsWorld.copperOre + 1;
                case "getworldaltiron":
                case "getworldaltlead":
                case "getworldaltnickel":
                case "getworldaltprehm2":
                case "getworldaltprehmtier2":
                case "getworldaltprehmtiertwo":
                    return (int)ExxoAvalonOriginsWorld.ironOre + 1;
                case "getworldaltsilver":
                case "getworldalttungsten":
                case "getworldaltzinc":
                case "getworldaltprehm3":
                case "getworldaltprehmtier3":
                case "getworldaltprehmtierthree":
                    return (int)ExxoAvalonOriginsWorld.silverOre + 1;
                case "getworldaltgold":
                case "getworldaltplatinum":
                case "getworldaltbismuth":
                case "getworldaltprehm4":
                case "getworldaltprehmtier4":
                case "getworldaltprehmtierfour":
                    return (int)ExxoAvalonOriginsWorld.goldOre + 1;
                case "getworldaltrhodium":
                case "getworldaltosmium":
                case "getworldaltiridium":
                case "getworldaltprehm5":
                case "getworldaltprehmtier5":
                case "getworldaltprehmtierfive":
                    return (int)ExxoAvalonOriginsWorld.rhodiumOre + 1;
                case "getworldaltcobalt":
                case "getworldaltpaladium":
                case "getworldaltduratanium":
                case "getworldalthm1":
                case "getworldalthmtier1":
                case "getworldalthmtierone":
                    return (int)ExxoAvalonOriginsWorld.cobaltOre + 1;
                case "getworldaltmythril":
                case "getworldaltorichalcum":
                case "getworldaltnaquadah":
                case "getworldalthm2":
                case "getworldalthmtier2":
                case "getworldalthmtiertwo":
                    return (int)ExxoAvalonOriginsWorld.mythrilOre + 1;
                case "getworldaltadamantite":
                case "getworldalttitanium":
                case "getworldalttroxinium":
                case "getworldalthm3":
                case "getworldalthmtier3":
                case "getworldalthmtierthree":
                    return (int)ExxoAvalonOriginsWorld.adamantiteOre + 1;
                case "getworldalttritanorium":
                case "getworldaltpyroscoric":
                case "getworldaltshm1":
                case "getworldaltshmtier1":
                case "getworldaltshmtierone":
                    return (int)ExxoAvalonOriginsWorld.shmTier1Ore + 1;
                case "getworldaltunvolandite":
                case "getworldaltvorazylcum":
                case "getworldaltshm2":
                case "getworldaltshmtier2":
                case "getworldaltshmtiertwo":
                    return (int)ExxoAvalonOriginsWorld.shmTier2Ore + 1;
                #endregion

                #region IsDownedX
                case "isdownedbacterium":
                case "isdownedbacteriumprime":
                    return ExxoAvalonOriginsWorld.downedBacteriumPrime;
                case "isdownedbeak":
                case "isdowneddesertbeak":
                    return ExxoAvalonOriginsWorld.downedDesertBeak;
                case "isdownedphantasm":
                    return ExxoAvalonOriginsWorld.downedPhantasm;
                case "isdownedwos":
                case "superhardmode":
                case "issuperhardmode":
                    return GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode;
                case "isdownedarma":
                case "isdownedarmageddon":
                case "isdownedarmageddonslime":
                    return ExxoAvalonOriginsWorld.stoppedArmageddon;
                case "isdownedlord":
                case "isdowneddragon":
                case "isdowneddragonlord":
                    return ExxoAvalonOriginsWorld.downedDragonLord;
                case "isdownedmechasting":
                    return ExxoAvalonOriginsWorld.downedMechasting;
                case "isdownedoblivion":
                    return ExxoAvalonOriginsWorld.oblivionDead;
                #endregion

                default:
                    Logger.Error("CALL ERROR: non-existing method name...?");
                    break;
            }
        }
        return null;
    }
    #endregion

    #region Mod Support (Boss Checklist, etc)
    public static void Support()
    {
        Mod mod = ExxoAvalonOrigins.Mod;

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
                NPCType<NPCs.BacteriumPrime>(),
                mod,
                "Bacterium Prime",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.downedBacteriumPrime),
                ItemType<BacterialTotem>(),
                new List<int> {ItemType<BacteriumPrimeTrophy>(),
                    ItemType<BacteriumPrimeMask>()},
                new List<int> {ItemType<BacciliteOre>(),
                    ItemType<Booger>()},
                "Use [i:" + ItemType<BacterialTotem>() + "] or break three Snot Orbs in a Contagion ring",
                "Bacterium Prime melts back into the ick",
                "ExxoAvalonOrigins/Sprites/BossChecklist/BacteriumPrimeBossChecklist",
                "ExxoAvalonOrigins/NPCs/Bosses/BacteriumPrime_Head_Boss",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.contagion)
            );
            #endregion BacteriumPrime

            #region DesertBeak
            bossChecklist.Call
            (
                "AddBoss",
                3.5f,
                NPCType<NPCs.Bosses.DesertBeak>(),
                mod,
                "Desert Beak",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.downedDesertBeak),
                ItemType<TheBeak>(),
                new List<int> {ItemType < DesertBeakTrophy >(),
                    ItemType < DesertBeakMask >()},
                new List<int> {ItemID.SandBlock,
                    ItemType < DesertFeather >(),
                    ItemType < RhodiumOre >(),
                    ItemType < OsmiumOre >(),
                    ItemType < IridiumOre >(),
                    ItemType < TomeoftheDistantPast >()},
                "Use [i:" + ItemType<TheBeak>() + "] in the desert",
                "Desert Beak has retreated into the sky",
                "ExxoAvalonOrigins/Sprites/BossChecklist/DesertBeakBossChecklist",
                "ExxoAvalonOrigins/NPCs/Bosses/DesertBeak_Head_Boss"
            );
            #endregion DesertBeak

            #region Phantasm
            bossChecklist.Call
            (
                "AddBoss",
                15f,
                NPCType<NPCs.Bosses.Phantasm>(),
                mod,
                "Phantasm",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.downedPhantasm),
                ItemType<EctoplasmicBeacon>(),
                new List<int> { ItemType<PhantasmTrophy>() },
                new List<int> { ItemType<PhantomKnives>(),
                    ItemType<EtherealHeart>(),
                    ItemType<VampireTeeth>(),
                    ItemType<GhostintheMachine>()},
                "Use an [i:" + ItemType<EctoplasmicBeacon>() + "] on the Library Altar in the Library of Knowledge",
                "Phantasm fades away",
                "ExxoAvalonOrigins/Sprites/BossChecklist/PhantasmBossChecklist",
                "ExxoAvalonOrigins/NPCs/Bosses/Phantasm_Head_Boss"
            );
            #endregion Phantasm

            #region Wall of Steel
            bossChecklist.Call
            (
                "AddBoss",
                16f,
                NPCType<NPCs.Bosses.WallofSteel>(),
                mod,
                "Wall of Steel",
                (Func<bool>)(() => GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode),
                ItemType<HellboundRemote>(),
                new List<int> { ItemType<WallofSteelTrophy>() },
                new List<int> {ItemType<MechanicalHeart>(),
                    ItemType<FleshBoiler>(),
                    ItemType<MagicCleaver>(),
                    ItemType<SoulofBlight>()},
                "Throw a [i:" + ItemType<HellboundRemote>() + "] into lava",
                "The Wall of Steel hisses steam and sinks into the lava",
                "ExxoAvalonOrigins/Sprites/BossChecklist/WallofSteelBossChecklist",
                "ExxoAvalonOrigins/NPCs/Bosses/WallofSteel_Head_Boss"
            );
            #endregion Wall of Steel

            #region Armageddon Slime
            bossChecklist.Call
            (
                "AddBoss",
                17f,
                NPCType<NPCs.Bosses.ArmageddonSlime>(),
                mod,
                "Armageddon Slime",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.stoppedArmageddon),
                ItemType<DarkMatterChunk>(),
                new List<int> {ItemType < ArmageddonSlimeTrophy >(),
                    ItemType < ArmageddonSlimeMask >()},
                new List<int> { ItemType<DarkMatterSoilBlock>() },
                "Use a [i:" + ItemType<DarkMatterChunk>() + "]",
                "Armageddon Slime melts into the earth",
                "ExxoAvalonOrigins/Sprites/BossChecklist/ArmageddonSlimeBossChecklist",
                "ExxoAvalonOrigins/NPCs/Bosses/ArmageddonSlime_Head_Boss"
            );
            #endregion Armageddon Slime

            #region Dragon Lord
            bossChecklist.Call
            (
                "AddBoss",
                18f,
                NPCType<NPCs.DragonLordHead>(),
                mod,
                "Dragon Lord",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.downedDragonLord),
                ItemType<DragonSpine>(),
                new List<int> { ItemType<DragonLordTrophy>() },
                new List<int> { ItemType < DragonScale >(),
                    ItemType < MagmafrostBolt >(),
                    ItemType < QuadroCannon >(),
                    ItemType < Items.Weapons.Summon.ReflectorStaff >(),
                    ItemType < DragonStone >(),
                    ItemType < Items.Weapons.Melee.Infernasword >()
                },
                "Use a [i:" + ItemType<DragonSpine>() + "]",
                "The Dragon Lord flies away",
                "ExxoAvalonOrigins/Sprites/BossChecklist/DragonLordBossChecklist",
                "ExxoAvalonOrigins/NPCs/DragonLordHead_Head_Boss"
            );
            #endregion Dragon Lord

            #region Mechasting
            bossChecklist.Call
            (
                "AddBoss",
                19f,
                NPCType<NPCs.Bosses.Mechasting>(),
                mod,
                "Mechasting",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.downedMechasting),
                ItemType<MechanicalWasp>(),
                new List<int> { ItemType<MechastingTrophy>() },
                new List<int> { ItemType < SoulofDelight >(),
                    ItemType < Mechazapinator >(),
                    ItemType < HeatSeeker >()
                },
                "Use a [i:" + ItemType<MechanicalWasp>() + "]",
                "Mechasting retreats to its mechanical hive",
                "ExxoAvalonOrigins/Sprites/BossChecklist/MechastingBossChecklist"
                //"ExxoAvalonOrigins/NPCs/Mechasting_Head_Boss"
            );
            #endregion Mechasting

            #region Oblivion
            bossChecklist.Call
            (
                "AddBoss",
                20f,
                NPCType<NPCs.AncientOblivionHead1>(),
                mod,
                "Oblivion",
                (Func<bool>)(() => ExxoAvalonOriginsWorld.oblivionDead),
                ItemType<EyeofOblivionAncient>(),
                new List<int> { ItemType<OblivionTrophy>() },
                new List<int> {ItemType < VictoryPiece >(),
                    ItemType < OblivionOre >(),
                    ItemType < SoulofTorture >(),
                    ItemType < Items.Tools.AccelerationDrill >(),
                    ItemType < CurseofOblivion >()},
                "Use a [i:" + ItemType<EyeofOblivionAncient>() + "] at night",
                "Oblivion retreats into the night",
                "ExxoAvalonOrigins/Sprites/BossChecklist/OblivionBossChecklist"
                //"ExxoAvalonOrigins/NPCs/Oblivion_Head_Boss",
            );
            #endregion Oblivion
        }
        #endregion BossChecklist
        #region Census
        Mod census = ModLoader.GetMod("Census");
        if (census != null)
        {
            census.Call("TownNPCCondition", NPCType<Librarian>(), "Defeat the Eye of Cthulhu");
            //census.Call("TownNPCCondition", ModContent.NPCType<Iceman>(), "Save the Iceman"); // Is there more townies???
        }
        #endregion
        #region Fargo's Mod
        Mod fargos = ModLoader.GetMod("Fargowiltas");
        if (fargos != null)
        {
            fargos.Call("AddSummon", 3f, ItemType<BacterialTotem>(), (Func<bool>)(() => ExxoAvalonOriginsWorld.downedBacteriumPrime), 10000);
            fargos.Call("AddSummon", 3.5f, ItemType<TheBeak>(), (Func<bool>)(() => ExxoAvalonOriginsWorld.downedDesertBeak), 10000);
            fargos.Call("AddSummon", 15f, ItemType<EctoplasmicBeacon>(), (Func<bool>)(() => ExxoAvalonOriginsWorld.downedPhantasm), 10000);
            fargos.Call("AddSummon", 16f, ItemType<HellboundRemote>(), (Func<bool>)(() => GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode), 10000);
            fargos.Call("AddSummon", 17f, ItemType<DarkMatterChunk>(), (Func<bool>)(() => ExxoAvalonOriginsWorld.stoppedArmageddon), 10000);
            fargos.Call("AddSummon", 18f, ItemType<DragonSpine>(), (Func<bool>)(() => ExxoAvalonOriginsWorld.downedDragonLord), 10000);
            fargos.Call("AddSummon", 19f, ItemType<MechanicalWasp>(), (Func<bool>)(() => ExxoAvalonOriginsWorld.downedMechasting), 10000);
            fargos.Call("AddSummon", 20f, ItemType<EyeofOblivionAncient>(), (Func<bool>)(() => ExxoAvalonOriginsWorld.oblivionDead), 10000);
        }
        #endregion
    }
    #endregion
}
