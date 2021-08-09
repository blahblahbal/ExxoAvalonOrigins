using ExxoAvalonOrigins.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    public class EvilAltar
    {
        public static void OnSmashAltar(On.Terraria.WorldGen.orig_SmashAltar orig, int i, int j)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient || !Main.hardMode || WorldGen.noTileActions || WorldGen.gen)
            {
                orig(i, j);
                return;
            }

            var currentOreTier = WorldGen.altarCount % 3;
            int num6 = WorldGen.altarCount / 3 + 1;
            int num8 = 1 - currentOreTier;

            // Arbitrary ore amount calculation used by the game
            float amountOreToSpawn = Main.maxTilesX / 4200;
            amountOreToSpawn = amountOreToSpawn * 310f - (float)(85 * amountOreToSpawn);
            amountOreToSpawn *= 0.85f;
            // Spawn less ore when more altars are broken
            amountOreToSpawn /= (float)num6;

            switch (currentOreTier)
            {
                case 0:
                    // Set ore tier if not set
                    if (WorldGen.oreTier1 == -1)
                    {
                        WorldGen.oreTier1 = TileID.Cobalt;
                        int ore = WorldGen.genRand.Next(3);
                        if (ore == 0) 
                            WorldGen.oreTier1 = TileID.Palladium;
                        else if (ore == 1) 
                            WorldGen.oreTier1 = ModContent.TileType<DurataniumOre>();
                    }

                    if (WorldGen.oreTier1 == TileID.Palladium || WorldGen.oreTier1 == ModContent.TileType<DurataniumOre>())
                    {
                        amountOreToSpawn *= 0.9f;
                    }

                    // Message players
                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        if (WorldGen.oreTier1 == TileID.Cobalt) 
                            Main.NewText("Your world has been blessed with Cobalt!", 26, 105, 161, false);
                        else if (WorldGen.oreTier1 == TileID.Palladium) 
                            Main.NewText("Your world has been blessed with Palladium!", 235, 87, 47, false);
                        else if (WorldGen.oreTier1 == ModContent.TileType<DurataniumOre>())
                            Main.NewText("Your world has been blessed with Duratanium!", 137, 81, 89, false);

                        if (WorldGen.altarCount == 0) 
                            Main.NewText("The underground smells like rotten eggs...", 210, 183, 4, false);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        if (WorldGen.oreTier1 == TileID.Cobalt) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Cobalt!"), new Color(26, 105, 161));
                        else if (WorldGen.oreTier1 == TileID.Palladium) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Palladium!"), new Color(235, 87, 47));
                        else if (WorldGen.oreTier1 == ModContent.TileType<DurataniumOre>())
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Duratanium!"), new Color(137, 81, 89));

                        if (WorldGen.altarCount == 0) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The underground smells like rotten eggs..."), new Color(210, 183, 4));
                    }

                    currentOreTier = WorldGen.oreTier1;
                    // Spawn slightly more tier1 ore
                    amountOreToSpawn *= 1.05f;
                    break;
                case 1:
                    // Set ore tier if not set
                    if (WorldGen.oreTier2 == -1)
                    {
                        WorldGen.oreTier2 = TileID.Mythril;
                        int ore = WorldGen.genRand.Next(3);
                        if (ore == 0) 
                            WorldGen.oreTier2 = TileID.Orichalcum;
                        else if (ore == 1) 
                            WorldGen.oreTier2 = ModContent.TileType<NaquadahOre>();
                    }

                    if (WorldGen.oreTier2 == TileID.Orichalcum || WorldGen.oreTier2 == ModContent.TileType<NaquadahOre>())
                    {
                        amountOreToSpawn *= 0.9f;
                    }

                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        if (WorldGen.oreTier2 == TileID.Mythril) 
                            Main.NewText("Your world has been blessed with Mythril!", 93, 147, 88, false);
                        else if (WorldGen.oreTier2 == TileID.Orichalcum) 
                            Main.NewText("Your world has been blessed with Orichalcum!", 163, 22, 158, false);
                        else if (WorldGen.oreTier2 == ModContent.TileType<NaquadahOre>()) 
                            Main.NewText("Your world has been blessed with Naquadah!", 0, 38, 255, false);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        if (WorldGen.oreTier2 == TileID.Mythril) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Mythril!"), new Color(93, 147, 88));
                        else if (WorldGen.oreTier2 == TileID.Orichalcum) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Orichalcum!"), new Color(163, 22, 158));
                        else if (WorldGen.oreTier2 == ModContent.TileType<NaquadahOre>()) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Naquadah!"), new Color(0, 38, 255));
                    }

                    currentOreTier = WorldGen.oreTier2;
                    break;
                case 2:
                    // Set ore tier if not set
                    if (WorldGen.oreTier3 == -1)
                    {
                        WorldGen.oreTier3 = TileID.Adamantite;
                        int ore = WorldGen.genRand.Next(3);
                        if (ore == 0) 
                            WorldGen.oreTier3 = TileID.Titanium;
                        else if (ore == 1) 
                            WorldGen.oreTier3 = ModContent.TileType<TroxiniumOre>();
                    }

                    if (WorldGen.oreTier3 == TileID.Titanium || WorldGen.oreTier3 == ModContent.TileType<TroxiniumOre>())
                    {
                        amountOreToSpawn *= 0.9f;
                    }

                    if (Main.netMode == NetmodeID.SinglePlayer)
                    {
                        if (WorldGen.oreTier3 == TileID.Adamantite) 
                            Main.NewText("Your world has been blessed with Adamantite!", 221, 85, 152, false);
                        else if (WorldGen.oreTier3 == TileID.Titanium) 
                            Main.NewText("Your world has been blessed with Titanium!", 185, 194, 215, false);
                        else if (WorldGen.oreTier3 == ModContent.TileType<TroxiniumOre>()) 
                            Main.NewText("Your world has been blessed with Troxinium!", 193, 218, 72, false);
                    }
                    else if (Main.netMode == NetmodeID.Server)
                    {
                        if (WorldGen.oreTier3 == TileID.Adamantite) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Adamantite!"), new Color(221, 85, 152));
                        else if (WorldGen.oreTier3 == TileID.Titanium) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Titanium!"), new Color(185, 194, 215));
                        else if (WorldGen.oreTier3 == ModContent.TileType<TroxiniumOre>()) 
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Troxinium!"), new Color(193, 218, 72));
                    }

                    currentOreTier = WorldGen.oreTier3;
                    break;
            }

            // Spawn ores
            for (int k = 0; k < amountOreToSpawn; k++)
            {
                // Set max height to spawn ore
                double maxHeightToSpawn = Main.worldSurface;
                if  (currentOreTier == TileID.Mythril || currentOreTier == TileID.Orichalcum || currentOreTier == ModContent.TileType<NaquadahOre>())
                {
                    maxHeightToSpawn = Main.rockLayer;
                }
                if  (currentOreTier == TileID.Adamantite || currentOreTier == TileID.Titanium || currentOreTier == ModContent.TileType<TroxiniumOre>())
                {
                    maxHeightToSpawn = (Main.rockLayer + Main.rockLayer + (double)Main.maxTilesY) / 3.0;
                }

                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)maxHeightToSpawn, Main.maxTilesY - 150);

                WorldGen.OreRunner(x, y, WorldGen.genRand.Next(5, 9 + num8), WorldGen.genRand.Next(5, 9 + num8), (ushort)currentOreTier);

                // For first 9 altars broken, spawn sulphur ore as well
                if (WorldGen.altarCount < 9)
                {
                    x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                    y = WorldGen.genRand.Next((int)maxHeightToSpawn, Main.maxTilesY - 150);

                    WorldGen.OreRunner(x, y, (double)WorldGen.genRand.Next(5, 9 + num8), WorldGen.genRand.Next(5, 9 + num8), (ushort)ModContent.TileType<Tiles.SulphurOre>());
                }
            }

            // Spawn evil or hallow blocks
            int randomNum = WorldGen.genRand.Next(3);
            int attempts = 0;
            while (randomNum != 2 && attempts++ < 1000)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)Main.rockLayer + 50, Main.maxTilesY - 300);

                // Tile must be active or stone
                if (!Main.tile[x, y].active() || Main.tile[x, y].type != 1)
                {
                    continue;
                }
                // Place evil
                if (randomNum == 0)
                {
                    if (WorldGen.crimson)
                    {
                        Main.tile[x, y].type = TileID.Crimstone;
                    }
                    else if (ExxoAvalonOriginsWorld.contaigon)
                    {
                        Main.tile[x, y].type = (ushort)ModContent.TileType<Chunkstone>();  
                    }
                    else
                    {
                        Main.tile[x, y].type = TileID.Ebonstone;
                    }
                }
                // Place hallow
                else
                {
                    Main.tile[x, y].type = TileID.Pearlstone;
                }
                // Update clients
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendTileSquare(-1, x, y, 1);
                }
                break;
            }

            // Place wraiths next to nearest player
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int amountWraiths = Main.rand.Next(2) + 1; // Min 1, Max 2 wraiths
                for (int l = 0; l < amountWraiths; l++)
                {
                    NPC.SpawnOnPlayer(Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16), NPCID.Wraith);
                }
            }
            WorldGen.altarCount++;

            // Do not run original logic
            //orig(i, j);
        }
    }
}