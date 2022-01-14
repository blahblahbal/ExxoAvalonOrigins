using log4net;
using Terraria;

namespace ExxoAvalonOrigins
{
    internal static class ExxoAvalonOriginsCall
    {
        internal static ILog logger = ExxoAvalonOrigins.mod.Logger;

        // HOW TO USE SPECIFIC CALLS
        //
        // Part 1: GetInZoneX
        // ModLoader.GetMod("ExxoAvalonOrigins") // Gets mod
        //      .Call(                           // Start using call
        //          "GetInZoneBooger",           // Method name, as example here "GetInZoneBooger" which provides us Booger Zone! :D
        //          player                       // Use player or player.whoAmI to get about which player it will get info
        //      );
        //                                      // As result, it will return true either false, depending on Zone's state

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
                    case "getinzonebooger":
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
                    default:
                        logger.Error("CALL ERROR: non-existing method name...?");
                        break;
                }
            }
            return null;
        }
    }
}
