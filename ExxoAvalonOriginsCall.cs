using log4net;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins
{
    internal static class ExxoAvalonOriginsCall
    {
        internal static ILog logger = ExxoAvalonOrigins.mod.Logger;

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

        internal static object Call(params object[] args)
        {
            if (args.Length == 0 || !(args[0] is string))
            {
                logger.Error("CALL ERROR: NO METHOD NAME! First param MUST be a method name!");
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneBooger;
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneComet;
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneHellcastle;
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneDarkMatter;
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneTropics;
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneCaesium;
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneOutpost;
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
                                logger.Error("CALL ERROR: Second param MUST be a player or integer!");
                                return null;
                            }

                            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ZoneSkyFortress;
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

                    #region
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
                        return ModContent.GetInstance<ExxoAvalonOriginsWorld>().SuperHardmode;
                    case "isdownedarma":
                    case "isdownedarmageddon":
                    case "isdownedarmageddonslime":
                        return ExxoAvalonOriginsGlobalNPC.stoppedArmageddon;
                    case "isdownedlord":
                    case "isdowneddragon":
                    case "isdowneddragonlord":
                        return ExxoAvalonOriginsWorld.downedDragonLord;
                    case "isdownedmechasting":
                        return ExxoAvalonOriginsWorld.downedMechasting;
                    case "isdownedoblivion":
                        return ExxoAvalonOriginsWorld.downedOblivion;
                    #endregion

                    default:
                        logger.Error("CALL ERROR: non-existing method name...?");
                        break;
                }
            }
            return null;
        }
    }
}
