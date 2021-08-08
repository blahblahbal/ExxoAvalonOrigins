using ExxoAvalonOrigins.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using WG = On.Terraria.WorldGen;

namespace ExxoAvalonOrigins.Altair
{
    public class Altair
    {
        public static void AltairHooks()
        {
            WG.SmashAltar += catchSmashAltar;
        }

        public static void catchSmashAltar(WG.orig_SmashAltar orig, int i, int j)
        {
            //if (WorldGen.oreTier3 != -1)
            //{
            //    orig(i, j);
            //    return;
            //}
            if (Main.netMode == 1 || !Main.hardMode || (WorldGen.noTileActions || WorldGen.gen))
            {
                orig(i, j);
                return;
            }

            var num1 = WorldGen.altarCount % 3;
            //int typeOfOre = WorldGen.genRand.Next(3);
            int num6 = WorldGen.altarCount / 3 + 1;
            float num7 = Main.maxTilesX / 4200;
            int num8 = 1 - num1;
            num7 = num7 * 310f - (float)(85 * num1);
            num7 *= 0.85f;
            num7 /= (float)num6;
            switch (num1)
            {
                case 0:
                    if (WorldGen.oreTier1 == -1)
                    {
                        WorldGen.oreTier1 = 107;
                        int ore = WorldGen.genRand.Next(3);
                        if (ore == 0) WorldGen.oreTier1 = 221;
                        else if (ore == 1) WorldGen.oreTier1 = ModContent.TileType<DurataniumOre>();
                    }
                    int num11 = 12;
                    if (WorldGen.oreTier1 == 221 || WorldGen.oreTier1 == ModContent.TileType<DurataniumOre>())
                    {
                        num11 += 9;
                        num7 *= 0.9f;
                    }
                    if (Main.netMode == 0)
                    {
                        if (WorldGen.oreTier1 == 107) Main.NewText("Your world has been blessed with Cobalt!", 26, 105, 161, false);
                        else if (WorldGen.oreTier1 == 221) Main.NewText("Your world has been blessed with Palladium!", 235, 87, 47, false);
                        else Main.NewText("Your world has been blessed with Duratanium!", 137, 81, 89, false);
                        if (WorldGen.altarCount == 0) Main.NewText("The underground smells like rotten eggs...", 210, 183, 4, false);
                    }
                    else if (Main.netMode == 2)
                    {
                        if (WorldGen.oreTier1 == 107) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Cobalt!"), new Color(26, 105, 161));
                        if (WorldGen.oreTier1 == 221) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Palladium!"), new Color(235, 87, 47));
                        else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Duratanium!"), new Color(137, 81, 89));
                        if (WorldGen.altarCount == 0) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The underground smells like rotten eggs..."), new Color(210, 183, 4));
                    }
                    num1 = WorldGen.oreTier1;
                    num7 *= 1.05f;
                    break;
                case 1:
                    if (WorldGen.oreTier2 == -1)
                    {
                        WorldGen.oreTier2 = 108;
                        int ore = WorldGen.genRand.Next(3);
                        if (ore == 0) WorldGen.oreTier2 = 222;
                        else if (ore == 1) WorldGen.oreTier2 = ModContent.TileType<NaquadahOre>();
                    }
                    int num10 = 13;
                    if (WorldGen.oreTier2 == 222 || WorldGen.oreTier2 == ModContent.TileType<NaquadahOre>())
                    {
                        num10 += 9;
                        num7 *= 0.9f;
                    }
                    if (Main.netMode == 0)
                    {
                        if (WorldGen.oreTier2 == 108) Main.NewText("Your world has been blessed with Mythril!", 93, 147, 88, false);
                        else if (WorldGen.oreTier2 == 222) Main.NewText("Your world has been blessed with Orichalcum!", 163, 22, 158, false);
                        else if (WorldGen.oreTier2 == ModContent.TileType<NaquadahOre>()) Main.NewText("Your world has been blessed with Naquadah!", 0, 38, 255, false);
                    }
                    else if (Main.netMode == 2)
                    {
                        if (WorldGen.oreTier2 == 108) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Mythril!"), new Color(93, 147, 88));
                        if (WorldGen.oreTier2 == 222) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Orichalcum!"), new Color(163, 22, 158));
                        else if (WorldGen.oreTier2 == ModContent.TileType<NaquadahOre>()) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Naquadah!"), new Color(0, 38, 255));
                    }
                    num1 = WorldGen.oreTier2;
                    break;
                case 2:
                    if (WorldGen.oreTier3 == -1)
                    {
                        WorldGen.oreTier3 = 111;
                        int ore = WorldGen.genRand.Next(3);
                        if (ore == 0) WorldGen.oreTier3 = 223;
                        else if (ore == 1) WorldGen.oreTier3 = ModContent.TileType<TroxiniumOre>();
                    }
                    int num9 = 14;
                    if (WorldGen.oreTier3 == 223 || WorldGen.oreTier3 == ModContent.TileType<TroxiniumOre>())
                    {
                        num9 += 9;
                        num7 *= 0.9f;
                    }
                    if (Main.netMode == 0)
                    {
                        if (WorldGen.oreTier3 == 111) Main.NewText("Your world has been blessed with Adamantite!", 221, 85, 152, false);
                        else if (WorldGen.oreTier3 == 223) Main.NewText("Your world has been blessed with Titanium!", 185, 194, 215, false);
                        else if (WorldGen.oreTier3 == ModContent.TileType<TroxiniumOre>()) Main.NewText("Your world has been blessed with Troxinium!", 193, 218, 72, false);
                    }
                    else if (Main.netMode == 2)
                    {
                        if (WorldGen.oreTier3 == 111) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Adamantite!"), new Color(221, 85, 152));
                        else if (WorldGen.oreTier3 == 223) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Titanium!"), new Color(185, 194, 215));
                        else if (WorldGen.oreTier3 == ModContent.TileType<TroxiniumOre>()) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Troxinium!"), new Color(193, 218, 72));
                    }
                    num1 = WorldGen.oreTier3;
                    break;
            }
            for (int k = 0; (float)k < num7; k++)
            {
                int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                double num12 = Main.worldSurface;
                if (num1 == 108 || num1 == 222 || num1 == ModContent.TileType<NaquadahOre>())
                {
                    num12 = Main.rockLayer;
                }
                if (num1 == 111 || num1 == 223 || num1 == ModContent.TileType<TroxiniumOre>())
                {
                    num12 = (Main.rockLayer + Main.rockLayer + (double)Main.maxTilesY) / 3.0;
                }
                int j2 = WorldGen.genRand.Next((int)num12, Main.maxTilesY - 150);
                WorldGen.OreRunner(i2, j2, WorldGen.genRand.Next(5, 9 + num8), WorldGen.genRand.Next(5, 9 + num8), (ushort)num1);
                if (WorldGen.altarCount < 9)
                {
                    WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(5, 9 + num8), WorldGen.genRand.Next(5, 9 + num8), (ushort)ModContent.TileType<Tiles.SulphurOre>());
                }
            }
            int num13 = WorldGen.genRand.Next(3);
            int num2 = 0;
            while (num13 != 2 && num2++ < 1000)
            {
                int num3 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int num4 = WorldGen.genRand.Next((int)Main.rockLayer + 50, Main.maxTilesY - 300);
                if (!Main.tile[num3, num4].active() || Main.tile[num3, num4].type != 1)
                {
                    continue;
                }
                if (num13 == 0)
                {
                    if (WorldGen.crimson)
                    {
                        Main.tile[num3, num4].type = 203;
                    }
                    else if (ExxoAvalonOriginsWorld.contaigon)
                    {
                        Main.tile[num3, num4].type = (ushort)ModContent.TileType<Chunkstone>();  
                    }
                    else if (!WorldGen.crimson && !ExxoAvalonOriginsWorld.contaigon)
                    {
                        Main.tile[num3, num4].type = 25;
                    }
                }
                else
                {
                    Main.tile[num3, num4].type = 117;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendTileSquare(-1, num3, num4, 1);
                }
                break;
            }
            if (Main.netMode != 1)
            {
                int num5 = Main.rand.Next(2) + 1;
                for (int l = 0; l < num5; l++)
                {
                    NPC.SpawnOnPlayer(Player.FindClosest(new Vector2(i * 16, j * 16), 16, 16), 82);
                }
            }
            WorldGen.altarCount++;

            //orig(i, j);
        }
    }
}