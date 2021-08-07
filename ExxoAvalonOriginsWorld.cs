﻿using System;using System.Collections.Generic;using ExxoAvalonOrigins.Items;using ExxoAvalonOrigins.Tiles;using Microsoft.Xna.Framework;using Terraria;using Terraria.GameContent.Generation;using Terraria.ID;using Terraria.ModLoader;using Terraria.World.Generation;using Terraria.Localization;using Terraria.ModLoader.IO;using CaesiumOre = ExxoAvalonOrigins.Tiles.CaesiumOre;using Heartstone = ExxoAvalonOrigins.Tiles.Heartstone;using HydrolythOre = ExxoAvalonOrigins.Tiles.HydrolythOre;using IckyAltar = ExxoAvalonOrigins.Tiles.IckyAltar;using OsmiumOre = ExxoAvalonOrigins.Tiles.OsmiumOre;using Peridot = ExxoAvalonOrigins.Tiles.Peridot;using RhodiumOre = ExxoAvalonOrigins.Tiles.RhodiumOre;using Tourmaline = ExxoAvalonOrigins.Tiles.Tourmaline;using Zircon = ExxoAvalonOrigins.Tiles.Zircon;using System.Threading;
using Terraria.Utilities;
using System.IO;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria.GameContent.Biomes;

namespace ExxoAvalonOrigins{    class ExxoAvalonOriginsWorld : ModWorld    {        public static GenPass corruptionPass;        public static GenPass altarPass;        public static byte blbTimer;        public static bool rhodium;        public static int rhodiumBar;        public static int shmOreTier1 = -1;        public static int shmOreTier2 = -1;        public static int hallowAltarCount;        public static bool contaigon = false;        public static int totalDark2;        public static int nilShrineCount;        public static int hallowedAltarCount;        public static bool stopCometDrops = false;        public static Vector2 hiddenTemplePos;        public static bool retroGenned = false;        public static int theBeak;        public static bool jungleLocationKnown = false;        public static bool generatingBaccilite = false;        public static int dungeonSide = 0;        public static int jungleX = 0;        public static int grassSpread = 0;        public static bool contaigonSet = false;        public static int hellcastleTiles = 0;        public static int ickyTiles = 0;        public static Vector2 LoK = Vector2.Zero;
        public static int wosT;
        public static int wosB;
        public static int wosF = 0;
        public static int wos = -1;
        public static bool downedPhantasm = false;        public override void ChooseWaterStyle(ref int style)
        {
            if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger)
                style = ModContent.GetInstance<Waters.ContagionWaterStyle>().Type;
        }        public override void TileCountsAvailable(int[] tileCounts)
        {
            Main.jungleTiles += tileCounts[ModContent.TileType<GreenIce>()];
            ickyTiles = tileCounts[ModContent.TileType<Tiles.Chunkstone>()] + tileCounts[ModContent.TileType<Tiles.HardenedSnotsand>()] + tileCounts[ModContent.TileType<Tiles.Snotsandstone>()] + tileCounts[ModContent.TileType<Tiles.Ickgrass>()] + tileCounts[ModContent.TileType<Tiles.Snotsand>()] + tileCounts[ModContent.TileType<Tiles.YellowIce>()];
            hellcastleTiles = tileCounts[ModContent.TileType<Tiles.ImperviousBrick>()];
            Main.sandTiles += tileCounts[ModContent.TileType<Tiles.Snotsand>()];
        }
        
        public void RetroGen()        {            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 1, 0, 0))            {
                //Rhodium/Osmium
                rhodium = WorldGen.genRand.Next(2) == 0;                rhodiumBar = rhodium ? ModContent.TileType<RhodiumOre>() : ModContent.TileType<OsmiumOre>();                for (var num156 = 0; num156 < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); num156++)                {                    var i10 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);                    var rockLayer3 = Main.rockLayer;                    var j10 = WorldGen.genRand.Next((int)rockLayer3, Main.maxTilesY - 150);                    WorldGen.OreRunner(i10, j10, WorldGen.genRand.Next(4, 5), WorldGen.genRand.Next(5, 7), (ushort)rhodiumBar);                }                Main.NewText("Retrogenned Rhodium/Osmium");
                //Caesium
                for (var num179 = 0; num179 < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0008); num179++)                {                    WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), (ushort)ModContent.TileType<CaesiumOre>());                    //WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), ModContent.TileType<CaesiumOre>(), false, 0f, 0f, false, true);                }                Main.NewText("Retrogenned Caesium");            }            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 1, 1, 0))            {                for (var num284 = 69; num284 < 72; num284++)                {                    var type8 = 0;                    float num285 = 0;                    if (num284 == 69)                    {                        type8 = ModContent.TileType<Tourmaline>();                        num285 = Main.maxTilesX * 0.2f;                    }                    else if (num284 == 70)                    {                        type8 = ModContent.TileType<Peridot>();                        num285 = Main.maxTilesX * 0.2f;                    }                    else if (num284 == 71)                    {                        type8 = ModContent.TileType<Zircon>();                        num285 = Main.maxTilesX * 0.2f;                    }                    num285 *= 0.2f;                    var num286 = 0;                    while (num286 < num285)                    {                        var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                        var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                        while (Main.tile[num287, num288].type != 1)                        {                            num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                            num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                        }                        WorldGen.TileRunner(num287, num288, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type8, false, 0f, 0f, false, true);                        num286++;                    }                }                Main.NewText("Retrogenned Tourmaline, Peridot and Zircon");            }            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 3, 0, 0))            {                for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)                {                    var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);                    var rockLayer = Main.rockLayer;                    var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);                    GenerateHearts(i8, j8, ModContent.TileType<Heartstone>());                }                Main.NewText("Retrogenned Heartstone");            }            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 3, 0, 0))            {                for (var num721 = 0; num721 < 3; num721++)                {                    var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);                    var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);                    IceShrine2(x10, y6);                }                Main.NewText("Retrogenned Ice Shrines");            }        }        public static void SmashHallowAltar(int i, int j)
        {
            if (Main.netMode == 1)
            {
                return;
            }
            if (!ExxoAvalonOrigins.superHardmode)
            {
                return;
            }
            if (WorldGen.noTileActions)
            {
                return;
            }
            if (WorldGen.gen)
            {
                return;
            }
            int num = hallowAltarCount % 2;
            int num2 = hallowAltarCount / 2 + 1;
            float num3 = (float)(Main.maxTilesX / 4200);
            int num4 = 1 - num;
            num3 = num3 * 310f - (float)(85 * num);
            num3 *= 0.85f;
            num3 /= (float)num2;
            if (num == 0)
            {
                if (shmOreTier1 == -1)
                {
                    shmOreTier1 = ModContent.TileType<Tiles.TritanoriumOre>();
                    int num5 = WorldGen.genRand.Next(2);
                    if (num5 == 0)
                    {
                        shmOreTier1 = ModContent.TileType<Tiles.PyroscoricOre>();
                    }
                }
                if (Main.netMode == 0)
                {
                    if (shmOreTier1 == ModContent.TileType<Tiles.TritanoriumOre>()) Main.NewText("Your world has been invigorated with Tritanorium!", 117, 158, 107, false);
                    else Main.NewText("Your world has been melted with Pyroscoric!", 187, 35, 0, false);
                }
                else if (Main.netMode == 2)
                {
                    if (shmOreTier1 == ModContent.TileType<Tiles.TritanoriumOre>()) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been invigorated with Tritanorium!"), new Color(117f, 158f, 107f));
                    else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been melted with Pyroscoric!"), new Color(187f, 35f, 0f));
                }
                num = shmOreTier1;
                num3 *= 1.05f;
            }
            else if (num == 1)
            {
                if (shmOreTier2 == -1)
                {
                    shmOreTier2 = ModContent.TileType<Tiles.UnvolanditeOre>();
                    int num7 = WorldGen.genRand.Next(2);
                    if (num7 == 0)
                    {
                        shmOreTier2 = ModContent.TileType<Tiles.VorazylcumOre>();
                    }
                }
                if (Main.netMode == 0)
                {
                    if (shmOreTier2 == ModContent.TileType<Tiles.UnvolanditeOre>()) Main.NewText("Your world has been blessed with Unvolandite!", 171, 119, 75, false);
                    else Main.NewText("Your world has been blessed with Vorazylcum!", 123, 95, 126, false);
                }
                else if (Main.netMode == 2)
                {
                    if (shmOreTier2 == ModContent.TileType<Tiles.UnvolanditeOre>())
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Unvolandite!"), new Color(171f, 119f, 75f));
                    }
                    else
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Vorazylcum!"), new Color(123f, 95f, 126f));
                    }
                }
                num = shmOreTier2;
            }
            int num11 = 0;
            while ((float)num11 < num3)
            {
                int i2 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                double num12 = Main.worldSurface;
                if (num == ModContent.TileType<Tiles.PyroscoricOre>())
                {
                    num12 = Main.rockLayer;
                }
                if (num == ModContent.TileType<Tiles.UnvolanditeOre>() || num == ModContent.TileType<Tiles.VorazylcumOre>())
                {
                    num12 = (Main.rockLayer + Main.rockLayer + (double)Main.maxTilesY) / 3.0;
                }
                int j2 = WorldGen.genRand.Next((int)num12, Main.maxTilesY - 150);
                WorldGen.OreRunner(i2, j2, (double)WorldGen.genRand.Next(5, 9 + num4), WorldGen.genRand.Next(5, 9 + num4), (ushort)num);
                num11++;
            }
            hallowAltarCount++;
        }        public static void ConvertFromThings(int x, int y, int convert, bool tileframe = true)
        {
            Tile tile = Main.tile[x, y];
            int type = tile.type;
            int wall = tile.wall;
            if (!WorldGen.InWorld(x, y, 1))
            {
                return;
            }
            if (convert == 0)
            {
                if (Main.tile[x, y] != null)
                {
                    if (wall == ModContent.WallType<Walls.ContagionGrassWall>())
                    {
                        Main.tile[x, y].wall = WallID.GrassUnsafe;
                    }
                    else if (wall == ModContent.WallType<Walls.ChunkstoneWall>())
                    {
                        Main.tile[x, y].wall = WallID.Stone;
                    }
                }
                if (Main.tile[x, y] != null)
                {
                    if (type == ModContent.TileType<Ickgrass>())
                    {
                        tile.type = TileID.Grass;
                    }
                    else if (type == ModContent.TileType<YellowIce>())
                    {
                        tile.type = TileID.IceBlock;
                    }
                    else if (type == ModContent.TileType<Snotsand>())
                    {
                        tile.type = TileID.Sand;
                    }
                    else if (type == ModContent.TileType<Chunkstone>())
                    {
                        tile.type = TileID.Stone;
                    }
                    if (TileID.Sets.Conversion.Grass[type] || type == 0)
                    {
                        WorldGen.SquareTileFrame(x, y);
                    }
                }
            }
            if (convert == 1)
            {
                if (Main.tile[x, y] != null)
                {
                    if (wall == ModContent.WallType<Walls.ContagionGrassWall>() || wall == WallID.CrimsonGrassUnsafe || wall == WallID.CorruptGrassUnsafe || wall == WallID.HallowedGrassUnsafe)
                    {
                        Main.tile[x, y].wall = WallID.JungleUnsafe;
                    }
                    else if (wall == WallID.DirtUnsafe)
                    {
                        Main.tile[x, y].wall = WallID.MudUnsafe;
                    }
                }
                if (Main.tile[x, y] != null)
                {
                    if (type == ModContent.TileType<Ickgrass>() || type == TileID.FleshGrass || type == TileID.CorruptGrass || type == TileID.Grass || type == TileID.HallowedGrass)
                    {
                        tile.type = TileID.JungleGrass;
                    }
                    else if (type == TileID.Dirt)
                    {
                        tile.type = TileID.Mud;
                    }
                    else if (type == ModContent.TileType<Snotsand>() || type == TileID.Sand || type == TileID.Crimsand || type == TileID.Ebonsand || type == TileID.Pearlsand)
                    {
                        tile.type = TileID.Sand;
                    }
                    else if (type == ModContent.TileType<Chunkstone>() || type == TileID.Pearlstone || type == TileID.Crimstone || type == TileID.Ebonstone)
                    {
                        tile.type = TileID.Stone;
                    }
                    else if (type == ModContent.TileType<YellowIce>() || type == TileID.HallowedIce || type == TileID.FleshIce || type == TileID.CorruptIce || type == TileID.IceBlock)
                    {
                        tile.type = (ushort)ModContent.TileType<GreenIce>();
                    }
                    if (TileID.Sets.Conversion.Grass[type] || type == 0)
                    {
                        WorldGen.SquareTileFrame(x, y);
                    }
                }
            }
            if (tileframe)
            {
                if (Main.netMode == 0)
                {
                    WorldGen.SquareTileFrame(x, y);
                }
                else if (Main.netMode == 2)
                {
                    NetMessage.SendTileSquare(-1, x, y, 1);
                }
            }
        }        public override void ModifyHardmodeTasks(List<GenPass> list)
        {
            int index = list.FindIndex(genpass => ((string)genpass.Name).Equals("Hardmode Good"));
            int index2 = list.FindIndex(genpass => ((string)genpass.Name).Equals("Hardmode Evil"));
            if (contaigon)
            {
                list.Insert(index + 1, (GenPass)new PassLegacy("Exxo Avalon Origins: Hardmode Contagion", new WorldGenLegacyMethod(GenerateContagion)));
                list.RemoveAt(index);
                list.RemoveAt(index2);
            }
        }        private static void GenerateContagion(GenerationProgress progress)
        {
            GenerateHardmodeContagion();
        }        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = ExxoAvalonOrigins.superHardmode;
            flags[1] = downedPhantasm;
            flags[2] = contaigon;
            writer.Write(flags);
            writer.WriteVector2(LoK);
            writer.Write(ExxoAvalonOrigins.dungeonEx);
            writer.Write(shmOreTier1);
            writer.Write(shmOreTier2);
            writer.Write(hallowAltarCount);
        }        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ExxoAvalonOrigins.superHardmode = flags[0];
            downedPhantasm = flags[1];
            contaigon = flags[2];
            LoK = reader.ReadVector2();
            ExxoAvalonOrigins.dungeonEx = reader.ReadInt32();
            shmOreTier1 = reader.ReadInt32();
            shmOreTier2 = reader.ReadInt32();
            hallowAltarCount = reader.ReadInt32();
        }        public static void GenerateHardmodeContagion()
        {
            WorldGen.IsGeneratingHardMode = true;
            if (Main.rand == null)
                Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
            float num1 = (float)Main.rand.Next(300, 400) * (1f / 1000f);
            float num2 = (float)Main.rand.Next(200, 300) * (1f / 1000f);
            int i1 = (int)((double)Main.maxTilesX * (double)num1);
            int i2 = (int)((double)Main.maxTilesX * (1.0 - (double)num1));
            int num3 = 1;
            if (Main.rand.Next(2) == 0)
            {
                i2 = (int)((double)Main.maxTilesX * (double)num1);
                i1 = (int)((double)Main.maxTilesX * (1.0 - (double)num1));
                num3 = -1;
            }
            int num4 = 1;
            if (WorldGen.dungeonX < Main.maxTilesX / 2)
                num4 = -1;
            if (num4 < 0)
            {
                if (i2 < i1)
                    i2 = (int)((double)Main.maxTilesX * num2);
                else
                    i1 = (int)((double)Main.maxTilesX * num2);
            }
            else if (i2 > i1)
                i2 = (int)(Main.maxTilesX * (1.0 - num2));
            else
                i1 = (int)(Main.maxTilesX * (1.0 - num2));
            GERunner(i1, 0, (3 * num3), 5f, true);
            GERunner(i2, 0, (3 * -num3), 5f, false);
        }        public static void GERunner(int i, int j, float speedX = 0f, float speedY = 0f, bool good = true)
        {
            if (Main.rand == null)
            {
                Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
            }
            int num = Main.rand.Next(200, 250);
            float num2 = Main.maxTilesX / 4200;
            num = (int)((float)num * num2);
            double num3 = num;
            Vector2 vector = default(Vector2);
            vector.X = i;
            vector.Y = j;
            Vector2 vector2 = default(Vector2);
            vector2.X = (float)Main.rand.Next(-10, 11) * 0.1f;
            vector2.Y = (float)Main.rand.Next(-10, 11) * 0.1f;
            if (speedX != 0f || speedY != 0f)
            {
                vector2.X = speedX;
                vector2.Y = speedY;
            }
            bool flag = true;
            while (flag)
            {
                int num4 = (int)((double)vector.X - num3 * 0.5);
                int num5 = (int)((double)vector.X + num3 * 0.5);
                int num6 = (int)((double)vector.Y - num3 * 0.5);
                int num7 = (int)((double)vector.Y + num3 * 0.5);
                if (num4 < 0)
                {
                    num4 = 0;
                }
                if (num5 > Main.maxTilesX)
                {
                    num5 = Main.maxTilesX;
                }
                if (num6 < 0)
                {
                    num6 = 0;
                }
                if (num7 > Main.maxTilesY)
                {
                    num7 = Main.maxTilesY;
                }
                for (int k = num4; k < num5; k++)
                {
                    for (int l = num6; l < num7; l++)
                    {
                        if (!((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < (double)num * 0.5 * (1.0 + (double)Main.rand.Next(-10, 11) * 0.015)))
                        {
                            continue;
                        }
                        if (good)
                        {
                            if (Main.tile[k, l].wall == 63 || Main.tile[k, l].wall == 65 || Main.tile[k, l].wall == 66 || Main.tile[k, l].wall == 68 || Main.tile[k, l].wall == 69 || Main.tile[k, l].wall == 81)
                            {
                                Main.tile[k, l].wall = 70;
                            }
                            else if (Main.tile[k, l].wall == 216)
                            {
                                Main.tile[k, l].wall = 219;
                            }
                            else if (Main.tile[k, l].wall == 187)
                            {
                                Main.tile[k, l].wall = 222;
                            }
                            if (Main.tile[k, l].wall == 3 || Main.tile[k, l].wall == 83)
                            {
                                Main.tile[k, l].wall = 28;
                            }
                            if (Main.tile[k, l].type == 2)
                            {
                                Main.tile[k, l].type = 109;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 1)
                            {
                                Main.tile[k, l].type = 117;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 123)
                            {
                                Main.tile[k, l].type = 116;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 23 || Main.tile[k, l].type == 199)
                            {
                                Main.tile[k, l].type = 109;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 25 || Main.tile[k, l].type == 203)
                            {
                                Main.tile[k, l].type = 117;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 112 || Main.tile[k, l].type == 234)
                            {
                                Main.tile[k, l].type = 116;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 161 || Main.tile[k, l].type == 163 || Main.tile[k, l].type == 200)
                            {
                                Main.tile[k, l].type = 164;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 396)
                            {
                                Main.tile[k, l].type = 403;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 397)
                            {
                                Main.tile[k, l].type = 402;
                                SquareTileFrame(k, l);
                            }
                        }
                        else if (contaigon)
                        {
                            if (Main.tile[k, l].wall == 63 || Main.tile[k, l].wall == 65 || Main.tile[k, l].wall == 66 || Main.tile[k, l].wall == 68)
                            {
                                Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();
                            }
                            else if (Main.tile[k, l].wall == 216)
                            {
                                Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ContagionNaturalWall1>();
                            }
                            else if (Main.tile[k, l].wall == 187)
                            {
                                Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ContagionNaturalWall1>();
                            }
                            if (Main.tile[k, l].type == 2)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Ickgrass>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 1)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Chunkstone>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 123)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsand>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 109)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Ickgrass>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 117)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Chunkstone>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 116)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsand>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 161 || Main.tile[k, l].type == 164)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<YellowIce>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 396)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<Snotsandstone>();
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 397)
                            {
                                Main.tile[k, l].type = (ushort)ModContent.TileType<HardenedSnotsand>();
                                SquareTileFrame(k, l);
                            }
                        }
                        else
                        {
                            if (Main.tile[k, l].wall == 63 || Main.tile[k, l].wall == 65 || Main.tile[k, l].wall == 66 || Main.tile[k, l].wall == 68)
                            {
                                Main.tile[k, l].wall = 69;
                            }
                            else if (Main.tile[k, l].wall == 216)
                            {
                                Main.tile[k, l].wall = 217;
                            }
                            else if (Main.tile[k, l].wall == 187)
                            {
                                Main.tile[k, l].wall = 220;
                            }
                            if (Main.tile[k, l].type == 2)
                            {
                                Main.tile[k, l].type = 23;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 1)
                            {
                                Main.tile[k, l].type = 25;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 123)
                            {
                                Main.tile[k, l].type = 112;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 109)
                            {
                                Main.tile[k, l].type = 23;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 117)
                            {
                                Main.tile[k, l].type = 25;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 116)
                            {
                                Main.tile[k, l].type = 112;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 161 || Main.tile[k, l].type == 164)
                            {
                                Main.tile[k, l].type = 163;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 396)
                            {
                                Main.tile[k, l].type = 400;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 397)
                            {
                                Main.tile[k, l].type = 398;
                                SquareTileFrame(k, l);
                            }
                        }
                    }
                }
                vector += vector2;
                vector2.X += (float)Main.rand.Next(-10, 11) * 0.05f;
                if (vector2.X > speedX + 1f)
                {
                    vector2.X = speedX + 1f;
                }
                if (vector2.X < speedX - 1f)
                {
                    vector2.X = speedX - 1f;
                }
                if (vector.X < (float)(-num) || vector.Y < (float)(-num) || vector.X > (float)(Main.maxTilesX + num) || vector.Y > (float)(Main.maxTilesX + num))
                {
                    flag = false;
                }
            }
        }        public override void PostUpdate()
        {
            float num2 = 3E-05f * (float)Main.worldRate;
            float num3 = 1.5E-05f * (float)Main.worldRate;
            bool flag = false;
            int num4 = 0;
            while ((float)num4 < (float)(Main.maxTilesX * Main.maxTilesY) * num2)
            {
                int num5 = WorldGen.genRand.Next(10, Main.maxTilesX - 10);
                int num6 = WorldGen.genRand.Next(10, (int)Main.worldSurface - 1);
                int num7 = num5 - 1;
                int num8 = num5 + 2;
                int num9 = num6 - 1;
                int num10 = num6 + 2;
                if (num7 < 10)
                {
                    num7 = 10;
                }
                if (num8 > Main.maxTilesX - 10)
                {
                    num8 = Main.maxTilesX - 10;
                }
                if (num9 < 10)
                {
                    num9 = 10;
                }
                if (num10 > Main.maxTilesY - 10)
                {
                    num10 = Main.maxTilesY - 10;
                }
                if (Main.tile[num5, num6] != null)
                {
                    if (Main.tile[num5, num6].type == ModContent.TileType<Ickgrass>())
                    {
                        int num14 = (int)Main.tile[num5, num6].type;
                        bool flag2 = false;
                        for (int m = num7; m < num8; m++)
                        {
                            for (int n = num9; n < num10; n++)
                            {
                                if ((num5 != m || num6 != n) && Main.tile[m, n].active())
                                {
                                    if (Main.tile[m, n].type == 0 || (num14 == ModContent.TileType<Ickgrass>() && Main.tile[m, n].type == TileID.Grass))
                                    {
                                        WorldGen.SpreadGrass(m, n, 0, num14, false, Main.tile[num5, num6].color());
                                        if (num14 == ModContent.TileType<Ickgrass>())
                                        {
                                            WorldGen.SpreadGrass(m, n, TileID.Grass, num14, false, Main.tile[num5, num6].color());
                                        }
                                        if (num14 == ModContent.TileType<Ickgrass>())
                                        {
                                            WorldGen.SpreadGrass(m, n, TileID.HallowedGrass, num14, false, Main.tile[num5, num6].color());
                                        }
                                        if ((int)Main.tile[m, n].type == num14)
                                        {
                                            WorldGen.SquareTileFrame(m, n, true);
                                            flag2 = true;
                                        }
                                    }
                                    if (Main.tile[m, n].type == 0 || (num14 == 109 && Main.tile[m, n].type == 2) || (num14 == 109 && Main.tile[m, n].type == 23) || (num14 == 109 && Main.tile[m, n].type == 199))
                                    {
                                        if (num14 == TileID.HallowedGrass)
                                        {
                                            WorldGen.SpreadGrass(m, n, ModContent.TileType<Ickgrass>(), num14, false, Main.tile[num5, num6].color());
                                        }
                                    }
                                }
                            }
                        }
                        if (Main.netMode == 2 && flag2)
                        {
                            NetMessage.SendTileSquare(-1, num5, num6, 3);
                        }
                    }
                    if ((Main.tile[num5, num6].type == ModContent.TileType<Impgrass>() || Main.tile[num5, num6].type == ModContent.TileType<Impvines>()) && WorldGen.genRand.Next(15) == 0 && !Main.tile[num5, num6 + 1].active() && !Main.tile[num5, num6 + 1].lava())
                    {
                        bool flag10 = false;
                        for (int num47 = num6; num47 > num6 - 10; num47--)
                        {
                            if (Main.tile[num5, num47].bottomSlope())
                            {
                                flag10 = false;
                                break;
                            }
                            if (Main.tile[num5, num47].active() && Main.tile[num5, num47].type == 477 && !Main.tile[num5, num47].bottomSlope())
                            {
                                flag10 = true;
                                break;
                            }
                        }
                        if (flag10)
                        {
                            int num48 = num5;
                            int num49 = num6 + 1;
                            Main.tile[num48, num49].type = (ushort)ModContent.TileType<Impvines>();
                            Main.tile[num48, num49].active(true);
                            WorldGen.SquareTileFrame(num48, num49, true);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, num48, num49, 3);
                            }
                        }
                    }
                }
                num4++;
            }
            if (!Main.dayTime && Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.AdvancedBuffs.AdvStarbright>()) || Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.Starbright>()))
            {
                float num66 = (float)(Main.maxTilesX / 4200);
                if ((float)Main.rand.Next(4000) < 10f * num66)
                {
                    int num67 = 12;
                    int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
                    num68 *= 16;
                    int num69 = Main.rand.Next((int)((double)Main.maxTilesY * 0.05));
                    num69 *= 16;
                    Vector2 vector = new Vector2((float)num68, (float)num69);
                    float num70 = (float)Main.rand.Next(-100, 101);
                    float num71 = (float)(Main.rand.Next(200) + 100);
                    float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
                    num72 = (float)num67 / num72;
                    num70 *= num72;
                    num71 *= num72;
                    Projectile.NewProjectile(vector.X, vector.Y, num70, num71, ProjectileID.FallingStar, 1000, 10f, Main.myPlayer);
                }
            }
            if (!Main.dayTime && Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<Buffs.AdvancedBuffs.AdvStarbright>()))
            {
                float num66 = (float)(Main.maxTilesX / 4200);
                if ((float)Main.rand.Next(4000) < 10f * num66)
                {
                    int num67 = 12;
                    int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
                    num68 *= 16;
                    int num69 = Main.rand.Next((int)((double)Main.maxTilesY * 0.05));
                    num69 *= 16;
                    Vector2 vector = new Vector2((float)num68, (float)num69);
                    float num70 = (float)Main.rand.Next(-100, 101);
                    float num71 = (float)(Main.rand.Next(200) + 100);
                    float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
                    num72 = (float)num67 / num72;
                    num70 *= num72;
                    num71 *= num72;
                    Projectile.NewProjectile(vector.X, vector.Y, num70, num71, ProjectileID.FallingStar, 1000, 10f, Main.myPlayer);
                }
            }
            if (!Main.dayTime && Main.bloodMoon)
            {
                float num66 = (float)(Main.maxTilesX / 4200);
                if ((float)Main.rand.Next(9000) < 10f * num66)
                {
                    int num67 = 12;
                    int num68 = Main.rand.Next(Main.maxTilesX - 50) + 100;
                    num68 *= 16;
                    int num69 = Main.rand.Next((int)((double)Main.maxTilesY * 0.05));
                    num69 *= 16;
                    Vector2 vector = new Vector2((float)num68, (float)num69);
                    float num70 = (float)Main.rand.Next(-100, 101);
                    float num71 = (float)(Main.rand.Next(200) + 100);
                    float num72 = (float)Math.Sqrt((double)(num70 * num70 + num71 * num71));
                    num72 = (float)num67 / num72;
                    num70 *= num72;
                    num71 *= num72;
                    Projectile.NewProjectile(vector.X, vector.Y, num70, num71, 12, 1000, 10f, Main.myPlayer);
                }
            }
        }        public override void PreUpdate()        {            if (!retroGenned)            {                if (ExxoAvalonOrigins.lastOpenedVersion == null || ExxoAvalonOrigins.lastOpenedVersion < ExxoAvalonOrigins.version)                {                    RetroGen();                    retroGenned = true;                }            }            if (Main.time == 16200.0 && Main.rand.Next(4) == 0 && NPC.downedGolemBoss && ExxoAvalonOriginsGlobalNPC.stoppedArmageddon && ExxoAvalonOrigins.superHardmode && Main.hardMode)            {                DropComet(ModContent.TileType<HydrolythOre>());            }        }        public static bool AddManaCrystal(int i, int j)
        {
            int k = j;
            while (k < Main.maxTilesY)
            {
                if (Main.tile[i, k].active() && Main.tileSolid[(int)Main.tile[i, k].type])
                {
                    int num = k - 1;
                    if (Main.tile[i, num - 1].lava() || Main.tile[i - 1, num - 1].lava())
                    {
                        return false;
                    }
                    if (!WorldGen.EmptyTileCheck(i - 1, i, num - 1, num, -1))
                    {
                        return false;
                    }
                    if (!Main.tileSolid[(int)Main.tile[i, num].type] || !Main.tileSolid[(int)Main.tile[i - 1, num].type])
                    {
                        return false;
                    }
                    if (!Main.wallDungeon[(int)Main.tile[i, num].wall])
                    {
                        return false;
                    }
                    Main.tile[i - 1, num - 1].active(true);
                    Main.tile[i - 1, num - 1].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i - 1, num - 1].frameX = 0;
                    Main.tile[i - 1, num - 1].frameY = 0;
                    Main.tile[i, num - 1].active(true);
                    Main.tile[i, num - 1].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i, num - 1].frameX = 18;
                    Main.tile[i, num - 1].frameY = 0;
                    Main.tile[i - 1, num].active(true);
                    Main.tile[i - 1, num].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i - 1, num].frameX = 0;
                    Main.tile[i - 1, num].frameY = 18;
                    Main.tile[i, num].active(true);
                    Main.tile[i, num].type = (ushort)ModContent.TileType<Tiles.ManaCrystal>();
                    Main.tile[i, num].frameX = 18;
                    Main.tile[i, num].frameY = 18;
                    return true;
                }
                else
                {
                    k++;
                }
            }
            return false;
        }        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)        {            theBeak = ModContent.ItemType<TheBeak>();            blbTimer = 0;            rhodium = true;            rhodiumBar = ModContent.TileType<RhodiumOre>();            shmOreTier1 = -1;            shmOreTier2 = -1;            contaigon = contaigonSet;            contaigonSet = false;            totalDark2 = 0;            nilShrineCount = 0;            hallowedAltarCount = 0;            ExxoAvalonOrigins.superHardmode = false;            ExxoAvalonOrigins.nilMode = false;            ExxoAvalonOriginsGlobalNPC.stoppedArmageddon = false;            ExxoAvalonOriginsGlobalNPC.oblivionDead = false;            ExxoAvalonOriginsGlobalNPC.oblivionTimes = 0;            hiddenTemplePos = Vector2.Zero;            int rhod = WorldGen.genRand.Next(3);            if (rhod == 0)            {                rhodium = false;                rhodiumBar = ModContent.TileType<Tiles.OsmiumOre>();            }            else if (rhod == 1)            {                rhodium = false;                rhodiumBar = ModContent.TileType<Tiles.IridiumOre>();            }            var reset = tasks.FindIndex(genpass => genpass.Name == "Reset");            if (reset != -1)            {                tasks.Insert(reset + 1, new PassLegacy("Avalon Setup", delegate(GenerationProgress progress)                {                    progress.Message = "Setting up Avalonian World Gen";                    if (!contaigon && WorldGen.WorldGenParam_Evil == -1)                    {                        contaigon = WorldGen.genRand.Next(3) == 0;                        if (contaigon) WorldGen.crimson = false;                    }                    if (WorldGen.WorldGenParam_Evil == 2)                    {                        contaigon = true;                        WorldGen.crimson = false;                    }                    int phmOreTier1 = WorldGen.genRand.Next(3);
                    int phmOreTier2 = WorldGen.genRand.Next(3);
                    int phmOreTier3 = WorldGen.genRand.Next(3);
                    int phmOreTier4 = WorldGen.genRand.Next(3);                    if (phmOreTier1 == 0)
                    {
                        WorldGen.CopperTierOre = (ushort)ModContent.TileType<Tiles.BronzeOre>();
                        WorldGen.copperBar = ModContent.ItemType<Items.BronzeBar>();
                    }
                    if (phmOreTier2 == 0)
                    {
                        WorldGen.IronTierOre = (ushort)ModContent.TileType<Tiles.NickelOre>();
                        WorldGen.ironBar = ModContent.ItemType<Items.NickelBar>();
                    }
                    if (phmOreTier3 == 0)
                    {
                        WorldGen.SilverTierOre = (ushort)ModContent.TileType<Tiles.ZincOre>();
                        WorldGen.silverBar = ModContent.ItemType<Items.ZincBar>();
                    }
                    if (phmOreTier4 == 0)
                    {
                        WorldGen.GoldTierOre = (ushort)ModContent.TileType<Tiles.BismuthOre>();
                        WorldGen.goldBar = ModContent.ItemType<Items.BismuthBar>();
                    }                }));            }            var shinies = tasks.FindIndex(genpass => genpass.Name == "Shinies");            if (shinies != -1)            {                tasks.RemoveAt(shinies);                tasks.Insert(shinies, new PassLegacy("Avalon Shinies", delegate(GenerationProgress progress)                {                    progress.Message = "Signalling Avalon Hooks";                    generatingBaccilite = contaigon; //Signals ExxoAvalonOrigins.BacciliteReplacement() to replace a demonite ore type with baccilite.                }));                tasks.Insert(shinies + 1, new PassLegacy("Avalon PHM Ore Gen", delegate (GenerationProgress progress)                {
                    progress.Message = Lang.gen[16].Value;
                    for (int num559 = 0; num559 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); num559++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)WorldGen.worldSurfaceHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), WorldGen.CopperTierOre);
                    }
                    for (int num560 = 0; num560 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num560++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), WorldGen.CopperTierOre);
                    }
                    for (int num561 = 0; num561 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num561++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.CopperTierOre);
                    }
                    for (int num562 = 0; num562 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); num562++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, (int)WorldGen.worldSurfaceHigh), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), WorldGen.IronTierOre);
                    }
                    for (int num563 = 0; num563 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num563++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), WorldGen.IronTierOre);
                    }
                    for (int num564 = 0; num564 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num564++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.IronTierOre);
                    }
                    for (int num565 = 0; num565 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05); num565++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceHigh, (int)WorldGen.rockLayerHigh), WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), WorldGen.SilverTierOre);
                    }
                    for (int num566 = 0; num566 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00015); num566++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SilverTierOre);
                    }
                    for (int num567 = 0; num567 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00017); num567++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow), WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), WorldGen.SilverTierOre);
                    }
                    for (int num568 = 0; num568 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num568++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), WorldGen.GoldTierOre);
                    }
                    for (int num569 = 0; num569 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num569++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)WorldGen.worldSurfaceLow - 20), WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), WorldGen.GoldTierOre);
                    }
                    if (WorldGen.crimson)
                    {
                        for (int num570 = 0; num570 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num570++)
                        {
                            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), 204);
                        }
                    }
                    else if (contaigon)
                    {
                        for (int num571 = 0; num571 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num571++)
                        {
                            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), (ushort)ModContent.TileType<Tiles.BacciliteOre>());
                        }
                    }
                    else if (!contaigon && !WorldGen.crimson)
                    {
                        for (int num571 = 0; num571 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num571++)
                        {
                            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), 22);
                        }
                    }
                }));                tasks.Insert(shinies + 2, new PassLegacy("Avalon Shinies", delegate(GenerationProgress progress)                {                    progress.Message = "Adding Avalonian Shinies";                    generatingBaccilite = false;                    for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); i++)                    {                        WorldGen.TileRunner(                            WorldGen.genRand.Next(100, Main.maxTilesX - 100), // Xcoord of tile                            WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 150), // Ycoord of tile                            WorldGen.genRand.Next(4, 5), // Quantity                            WorldGen.genRand.Next(5, 7),                            rhodiumBar, //Tile to spawn                            false, 0f, 0f, false, true); //last input overrides existing tiles                    }                    for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)                    {                        var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);                        var rockLayer = Main.rockLayer;                        var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);                        GenerateHearts(i8, j8, ModContent.TileType<Heartstone>());                    }                }));            }            var underworld = tasks.FindIndex(genpass => genpass.Name == "Underworld");            if (underworld != -1)            {                tasks.Insert(underworld + 1, new PassLegacy("Avalon Underworld", delegate (GenerationProgress progress)                {                    progress.Message = "Avalonifying Underworld";                    for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0008); i++)                    {                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), (ushort)ModContent.TileType<CaesiumOre>());                    }                    GenerateHellcastle2(Main.maxTilesX / 3, Main.maxTilesY - 140);
                    for (int hbx = Main.maxTilesX / 3 - 170; hbx < Main.maxTilesX / 3 + 380; hbx++)
                    {
                        for (int hby = Main.maxTilesY - 200; hby < Main.maxTilesY - 50; hby++)
                        {
                            if (Main.tile[hbx, hby].active() && !Main.tile[hbx, hby - 1].active() ||
                                Main.tile[hbx, hby].active() && !Main.tile[hbx, hby + 1].active() ||
                                Main.tile[hbx, hby].active() && !Main.tile[hbx - 1, hby].active() ||
                                Main.tile[hbx, hby].active() && !Main.tile[hbx + 1, hby].active())
                            {
                                if (Main.tile[hbx, hby].type == TileID.Ash)
                                {
                                    Main.tile[hbx, hby].type = (ushort)ModContent.TileType<Impgrass>();
                                    if (WorldGen.genRand.Next(2) == 0)
                                    {
                                        WorldGen.GrowTree(hbx, hby - 1);
                                    }
                                }
                            }
                            if (WorldGen.genRand.Next(70) == 0)
                            {
                                WorldGen.OreRunner(hbx, hby, 4, 4, (ushort)ModContent.TileType<Tiles.BrimstoneBlock>());
                            }
                        }
                    }
                }));            }                        var dungeonSideTask = tasks.FindIndex(genpass => genpass.Name == "Dungeon");            if (dungeonSideTask != -1)            {                tasks.Insert(underworld + 1, new PassLegacy("Avalon Finding Dungeon",                    delegate(GenerationProgress progress)                    {                        dungeonSide = WorldGen.dungeonX < Main.maxTilesX * 0.5 ? -1 : 1;                        ExxoAvalonOrigins.dungeonEx = WorldGen.dungeonX;                    }));            }            var corruptionTask = tasks.FindIndex(genpass => genpass.Name == "Corruption");            if (corruptionTask != -1)            {                corruptionPass = tasks[corruptionTask];                tasks[corruptionTask] =                 new PassLegacy("Corruption", delegate (GenerationProgress progress)                {                    if (contaigon)                    {                        progress.Message = "Making the world gross";                        int num208 = 0;                        while (num208 < Main.maxTilesX * 0.00045)                        {                            float num209 = (float)(num208 / (Main.maxTilesX * 0.00045));                            bool flag12 = false;                            int num210 = 0;                            int num211 = 0;                            int num212 = 0;                            while (!flag12)                            {                                int num213 = 0;                                flag12 = true;                                int num214 = Main.maxTilesX / 2;                                int num215 = 200;                                if (WorldGen.dungeonX < Main.maxTilesX * 0.5)                                {                                    num210 = WorldGen.genRand.Next(600, Main.maxTilesX - 320);                                }                                else                                {                                    num210 = WorldGen.genRand.Next(320, Main.maxTilesX - 600);                                }                                num211 = num210 - WorldGen.genRand.Next(200) - 100;                                num212 = num210 + WorldGen.genRand.Next(200) + 100;                                if (num211 < 285)                                {                                    num211 = 285;                                }                                if (num212 > Main.maxTilesX - 285)                                {                                    num212 = Main.maxTilesX - 285;                                }                                if (dungeonSide < 0 && num211 < 400)                                {                                    num211 = 400;                                }                                else if (dungeonSide > 0 && num211 > Main.maxTilesX - 400)                                {                                    num211 = Main.maxTilesX - 400;                                }                                if (num210 > num214 - num215 && num210 < num214 + num215)                                {                                    flag12 = false;                                }                                if (num211 > num214 - num215 && num211 < num214 + num215)                                {                                    flag12 = false;                                }                                if (num212 > num214 - num215 && num212 < num214 + num215)                                {                                    flag12 = false;                                }                                for (int num216 = num211; num216 < num212; num216++)                                {                                    for (int num217 = 0; num217 < (int)Main.worldSurface; num217 += 5)                                    {                                        if (Main.tile[num216, num217].active() && Main.tileDungeon[Main.tile[num216, num217].type])                                        {                                            flag12 = false;                                            break;                                        }                                        if (!flag12)                                        {                                            break;                                        }                                    }                                }                                if (num213 < 200 && jungleX > num211 && jungleX < num212)                                {                                    num213++;                                    flag12 = false;                                }                            }                           ContagionRunner(num210, (int)WorldGen.worldSurfaceLow - 10 + (Main.maxTilesY / 8));                            for (int num218 = num211; num218 < num212; num218++)                            {                                int num219 = (int)WorldGen.worldSurfaceLow;                                while (num219 < Main.worldSurface - 1.0)                                {                                    if (Main.tile[num218, num219].active())                                    {                                        int num220 = num219 + WorldGen.genRand.Next(10, 14);                                        for (int num221 = num219; num221 < num220; num221++)                                        {                                            if ((Main.tile[num218, num221].type == TileID.Mud || Main.tile[num218, num221].type == TileID.JungleGrass) && num218 >= num211 + WorldGen.genRand.Next(5) && num218 < num212 - WorldGen.genRand.Next(5))                                            {                                                Main.tile[num218, num221].type = TileID.Dirt;                                            }                                        }                                        break;                                    }                                    num219++;                                }                            }                            double num222 = Main.worldSurface + 40.0;                            for (int num223 = num211; num223 < num212; num223++)                            {                                num222 += WorldGen.genRand.Next(-2, 3);                                if (num222 < Main.worldSurface + 30.0)                                {                                    num222 = Main.worldSurface + 30.0;                                }                                if (num222 > Main.worldSurface + 50.0)                                {                                    num222 = Main.worldSurface + 50.0;                                }                                int num57 = num223;                                bool flag13 = false;                                int num224 = (int)WorldGen.worldSurfaceLow;                                while (num224 < num222)                                {                                    if (Main.tile[num57, num224].active())                                    {                                        if (Main.tile[num57, num224].type == TileID.Sand && num57 >= num211 + WorldGen.genRand.Next(5) && num57 <= num212 - WorldGen.genRand.Next(5))                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<Snotsand>();                                        }                                        if (Main.tile[num57, num224].type == TileID.Dirt && num224 < Main.worldSurface - 1.0 && !flag13)                                        {                                            grassSpread = 0;                                            WorldGen.SpreadGrass(num57, num224, 0, ModContent.TileType<Ickgrass>(), true, 0);                                        }                                        flag13 = true;                                        if (Main.tile[num57, num224].type == TileID.Stone && num57 >= num211 + WorldGen.genRand.Next(5) && num57 <= num212 - WorldGen.genRand.Next(5))                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<Chunkstone>();                                        }                                        if (Main.tile[num57, num224].type == TileID.Grass)                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<Ickgrass>();                                        }                                        if (Main.tile[num57, num224].type == TileID.IceBlock)                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<YellowIce>();                                        }                                    }                                    num224++;                                }                            }                            int num225 = WorldGen.genRand.Next(10, 15);                            for (int num226 = 0; num226 < num225; num226++)                            {                                int num227 = 0;                                bool flag14 = false;                                int num228 = 0;                                while (!flag14)                                {                                    num227++;                                    int num229 = WorldGen.genRand.Next(num211 - num228, num212 + num228);                                    int num230 = WorldGen.genRand.Next((int)(Main.worldSurface - num228 / 2), (int)(Main.worldSurface + 100.0 + num228));                                    if (num227 > 100)                                    {                                        num228++;                                        num227 = 0;                                    }                                    if (!Main.tile[num229, num230].active())                                    {                                        while (!Main.tile[num229, num230].active())                                        {                                            num230++;                                        }                                        num230--;                                    }                                    else                                    {                                        while (Main.tile[num229, num230].active() && num230 > Main.worldSurface)                                        {                                            num230--;                                        }                                    }                                    if (num228 > 10 || (Main.tile[num229, num230 + 1].active() && Main.tile[num229, num230 + 1].type == TileID.Crimstone))                                    {                                        WorldGen.Place3x2(num229, num230, (ushort) ModContent.TileType<IckyAltar>());                                        if (Main.tile[num229, num230].type == (ushort) ModContent.TileType<IckyAltar>())                                        {                                            flag14 = true;                                        }                                    }                                    if (num228 > 100)                                    {                                        flag14 = true;                                    }                                }                            }                            num208++;                        }                    }                    else                    {                        corruptionPass.Apply(progress);                    }                });            }            var gems = tasks.FindIndex(genpass => genpass.Name == "Gems");            if (gems != -1)            {                tasks.Insert(gems + 1, new PassLegacy("Avalon Gems", delegate (GenerationProgress progress)                {                    for (var num284 = 69; num284 < 72; num284++)                    {                        var type8 = 0;                        float num285 = 0;                        if (num284 == 69)                        {                            type8 = ModContent.TileType<Tourmaline>();                            num285 = Main.maxTilesX * 0.2f;                        }                        else if (num284 == 70)                        {                            type8 = ModContent.TileType<Peridot>();                            num285 = Main.maxTilesX * 0.2f;                        }                        else if (num284 == 71)                        {                            type8 = ModContent.TileType<Zircon>();                            num285 = Main.maxTilesX * 0.2f;                        }                        num285 *= 0.2f;                        var num286 = 0;                        while (num286 < num285)                        {                            var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                            var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                            while (Main.tile[num287, num288].type != 1)                            {                                num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                                num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                            }                            WorldGen.TileRunner(num287, num288, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type8, false, 0f, 0f, false, true);                            num286++;                        }                    }                }));            }            var altarsTask = tasks.FindIndex(genpass => genpass.Name == "Altars");            if (altarsTask != -1)            {                altarPass = tasks[altarsTask];                tasks.RemoveAt(altarsTask);                tasks.Insert(altarsTask, new PassLegacy("Altars", delegate(GenerationProgress progress)                {                    if (contaigon)                    {                        progress.Message = Lang.gen[26].Value;                        int num = (int) (Main.maxTilesX * Main.maxTilesY * 1.99999994947575E-05);                        for (int index1 = 0; index1 < num; ++index1)                        {                            progress.Set(index1 / (float) num);                            for (int index2 = 0; index2 < 10000; ++index2)                            {                                int x = WorldGen.genRand.Next(1, Main.maxTilesX - 3);                                int y = (int) (WorldGen.worldSurfaceHigh + 20.0);                                WorldGen.Place3x2(x, y, ModContent.GetInstance<Tiles.IckyAltar>().Type);                                if (Main.tile[x, y].type == ModContent.GetInstance<Tiles.IckyAltar>().Type)                                    break;                            }                        }                    }                    else                    {                        altarPass.Apply(progress);                    }                    int num2 = (int)(Main.maxTilesX * Main.maxTilesY * 1.99999994947575E-05);
                    for (int index1 = 0; index1 < num2; ++index1)
                    {
                        progress.Set(index1 / (float)num2);
                        for (int index2 = 0; index2 < 10000; ++index2)
                        {
                            int x = WorldGen.genRand.Next(1, Main.maxTilesX - 3);
                            int y = (int)(WorldGen.worldSurfaceHigh + 20.0);
                            WorldGen.Place3x2(x, y, (ushort)ModContent.TileType<Tiles.HallowedAltar>());
                            if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.HallowedAltar>())
                                break;
                        }
                    }                }));                tasks.Insert(altarsTask + 1, new PassLegacy("Hallowed Altars", delegate (GenerationProgress progress)                {                    int num = (int)(Main.maxTilesX * Main.maxTilesY * 1.99999994947575E-05);
                    for (int index1 = 0; index1 < num; ++index1)
                    {
                        progress.Set(index1 / (float)num);
                        for (int index2 = 0; index2 < 10000; ++index2)
                        {
                            int x = WorldGen.genRand.Next(1, Main.maxTilesX - 3);
                            int y = (int)(WorldGen.worldSurfaceHigh + 20.0);
                            WorldGen.Place3x2(x, y, (ushort)ModContent.TileType<Tiles.HallowedAltar>());
                            if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.HallowedAltar>())
                                break;
                        }
                    }
                }));            }            var smoothWorld = tasks.FindIndex(genpass => genpass.Name == "Smooth World");            if (smoothWorld != -1)            {                tasks.Insert(smoothWorld + 1, new PassLegacy("Unsmoothing Hellcastle", delegate (GenerationProgress progress)                {                    int x = Main.maxTilesX / 3;                    int y = Main.maxTilesY - 140;                    for (int i = x; i <= x + 210; i++)
                    {
                        for (int j = y; j <= y + 90; j++)
                        {
                            Main.tile[i, j].slope(0);
                            Main.tile[i, j].halfBrick(false);
                        }
                    }                    // unsmoothing hellcastle                }));            }            var lifecrystals = tasks.FindIndex(genpass => genpass.Name == "Life Crystals");            if (lifecrystals != -1)            {                tasks.Insert(lifecrystals + 1, new PassLegacy("Adding Mana Crystals", delegate (GenerationProgress progress)                {                    for (int num381 = 0; num381 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-06); num381++)
                    {
                        float num382 = (float)((double)num381 / ((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05));
                        Main.statusText = string.Concat(new object[]
                        {
                            "Adding mana crystals:",
                            " ",
                            (int)(num382 * 100f + 1f),
                            "%"
                        });
                        bool flag27 = false;
                        int num383 = 0;
                        while (!flag27)
                        {
                            if (AddManaCrystal(WorldGen.genRand.Next(1, Main.maxTilesX), WorldGen.genRand.Next((int)(WorldGen.worldSurfaceLow + 20.0), Main.maxTilesY - 300)))
                            {
                                flag27 = true;
                            }
                            else
                            {
                                num383++;
                                if (num383 >= 10000)
                                {
                                    flag27 = true;
                                }
                            }
                        }
                    }                }));            }            var iceWalls = tasks.FindIndex(genpass => genpass.Name == "Ice Walls");            if (iceWalls != -1)            {                tasks.Insert(iceWalls + 1, new PassLegacy("Avalon Ice Shrines", delegate (GenerationProgress progress)                {                    for (var num721 = 0; num721 < 3; num721++)                    {                        var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);                        var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);                        IceShrine2(x10, y6);                    }                }));            }

            var impvines = tasks.FindIndex(genpass => genpass.Name == "Vines");            if (impvines != -1)            {                tasks.Insert(impvines + 1, new PassLegacy("Impvines", delegate (GenerationProgress progress)                {
                    for (int num586 = 0; num586 < Main.maxTilesX; num586++)
                    {
                        int num587 = 0;
                        for (int num589 = 0; num589 < Main.maxTilesY; num589++)
                        {
                            if (num587 > 0 && !Main.tile[num586, num589].active())
                            {
                                Main.tile[num586, num589].active(true);
                                Main.tile[num586, num589].type = (ushort)ModContent.TileType<Impvines>();
                                num587--;
                            }
                            else
                            {
                                num587 = 0;
                            }
                            if (Main.tile[num586, num589].active() && Main.tile[num586, num589].type == (ushort)ModContent.TileType<Impgrass>() && !Main.tile[num586, num589].bottomSlope() && WorldGen.genRand.Next(5) < 3)
                            {
                                num587 = WorldGen.genRand.Next(1, 10);
                            }
                        }                    }                }));            }            var microBiomes = tasks.FindIndex(genpass => genpass.Name == "Micro Biomes");            if (microBiomes != -1)            {                tasks.RemoveAt(microBiomes);                tasks.Insert(microBiomes, new PassLegacy("Avalon Contaigon fix 1", delegate (GenerationProgress progress)
                {
                    if (contaigon) WorldGen.crimson = true;
                }));                tasks.Insert(microBiomes + 1, new PassLegacy("Avalon Micro Biomes Fix", delegate (GenerationProgress progress)                {
                    progress.Message = Lang.gen[76].Value + "..Thin Ice";
                    float num = (float)(Main.maxTilesX * Main.maxTilesY) / 5040000f;
                    float num2 = (float)Main.maxTilesX / 4200f;
                    int num3 = (int)((float)WorldGen.genRand.Next(3, 6) * num);
                    int num4 = 0;
                    while (num4 < num3)
                    {
                        if (Biomes<ThinIceBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface + 20, 50, 200, 50), WorldGen.structures))
                        {
                            num4++;
                        }
                    }
                    progress.Set(0.1f);
                    progress.Message = Lang.gen[76]?.ToString() + "..Enchanted Swords";
                    int num5 = (int)Math.Ceiling(num);
                    int num6 = 0;
                    Point origin = default(Point);
                    while (num6 < num5)
                    {
                        origin.Y = (int)WorldGen.worldSurface + WorldGen.genRand.Next(50, 100);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            origin.X = WorldGen.genRand.Next(50, (int)((float)Main.maxTilesX * 0.3f));
                        }
                        else
                        {
                            origin.X = WorldGen.genRand.Next((int)((float)Main.maxTilesX * 0.7f), Main.maxTilesX - 50);
                        }
                        if (Biomes<Terraria.GameContent.Biomes.EnchantedSwordBiome>.Place(origin, WorldGen.structures))
                        {
                            num6++;
                        }
                    }
                    progress.Set(0.2f);
                    progress.Message = Lang.gen[76]?.ToString() + "..Campsites";
                    int num7 = (int)((float)WorldGen.genRand.Next(6, 12) * num);
                    int num8 = 0;
                    while (num8 < num7)
                    {
                        if (Biomes<CampsiteBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface, 50, 200, 50), WorldGen.structures))
                        {
                            num8++;
                        }
                    }
                    progress.Message = Lang.gen[76]?.ToString() + "..Mining Explosives";
                    progress.Set(0.25f);
                    int num9 = (int)((float)WorldGen.genRand.Next(14, 30) * num);
                    int num10 = 0;
                    while (num10 < num9)
                    {
                        if (Biomes<MiningExplosivesBiome>.Place(WorldGen.RandomWorldPoint((int)WorldGen.rockLayer, 50, 200, 50), WorldGen.structures))
                        {
                            num10++;
                        }
                    }
                    progress.Message = Lang.gen[76]?.ToString() + "..Mahogany Trees";
                    progress.Set(0.3f);
                    int num11 = (int)((float)WorldGen.genRand.Next(6, 12) * num2);
                    int num12 = 0;
                    int num13 = 0;
                    while (num12 < num11 && num13 < 20000)
                    {
                        if (Biomes<MahoganyTreeBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface + 50, 50, 500, 50), WorldGen.structures))
                        {
                            num12++;
                        }
                        num13++;
                    }
                    progress.Message = Lang.gen[76]?.ToString() + "..Corruption Pits";
                    progress.Set(0.4f);
                    if (!WorldGen.crimson)
                    {
                        int num14 = (int)((float)WorldGen.genRand.Next(1, 3) * num);
                        int num15 = 0;
                        while (num15 < num14)
                        {
                            if (Biomes<CorruptionPitBiome>.Place(WorldGen.RandomWorldPoint((int)Main.worldSurface, 50, 500, 50), WorldGen.structures))
                            {
                                num15++;
                            }
                        }
                    }
                    progress.Message = Lang.gen[76]?.ToString() + "..Minecart Tracks";
                    progress.Set(0.5f);
                    TrackGenerator.Run((int)(10f * num), (int)(num * 25f) + 250);
                    progress.Set(1f);
                }));                tasks.Insert(microBiomes + 2, new PassLegacy("Avalon Contaigon fix 2", delegate (GenerationProgress progress)                {                    if (contaigon) WorldGen.crimson = false;                }));            }        }        public void DropComet(int tile)        {            var flag = true;            var num = 0;            if (Main.netMode == 1)            {                return;            }            for (var i = 0; i < 255; i++)            {                if (Main.player[i].active)                {                    flag = false;                    break;                }            }            var num2 = 0;            float num3 = Main.maxTilesX / 4200;            var num4 = (int)(400f * num3);            for (var j = 5; j < Main.maxTilesX - 5; j++)            {                var num5 = 5;                while (num5 < Main.worldSurface)                {                    if (Main.tile[j, num5].active() && Main.tile[j, num5].type == tile)                    {                        num2++;                        if (num2 > num4)                        {                            return;                        }                    }                    num5++;                }            }            while (!flag)            {                var num6 = Main.maxTilesX * 0.08f;                var num7 = Main.rand.Next(50, Main.maxTilesX - 50);                while (num7 > Main.spawnTileX - num6 && num7 < Main.spawnTileX + num6)                {                    num7 = Main.rand.Next(50, Main.maxTilesX - 50);                }                for (var k = Main.rand.Next(100); k < Main.maxTilesY; k++)                {                    if (Main.tile[num7, k].active() && Main.tileSolid[Main.tile[num7, k].type])                    {                        flag = Comet(num7, k, tile);                        break;                    }                }                num++;                if (num >= 100)                {                    return;                }            }        }        public static void GenerateHellcastle2(int x, int y)
        {
            WorldGen.destroyObject = true;
            ushort brick = (ushort)ModContent.TileType<Tiles.ImperviousBrick>();
            ushort spike = (ushort)ModContent.TileType<Tiles.VenomSpike>();
            byte wallUnsafe = (byte)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
            byte wallSafe = (byte)ModContent.WallType<Walls.ImperviousBrickWall>();
            ushort platform = (ushort)ModContent.TileType<Tiles.ResistantWoodPlatform>();

            // turn liquid in an area around the gen area to 0, and make it not lava
            for (int noLiquidX = x - 45; noLiquidX <= x + 210 + 45; noLiquidX++)
            {
                for (int noLiquidY = y - 20; noLiquidY <= y + 90; noLiquidY++)
                {
                    if (Main.tile[noLiquidX, noLiquidY] == null) Main.tile[noLiquidX, noLiquidY] = new Tile();
                    Main.tile[noLiquidX, noLiquidY].liquid = 0;
                    Main.tile[noLiquidX, noLiquidY].lava(false);
                    if (noLiquidX >= x && noLiquidX <= x + 210 && noLiquidY >= y && noLiquidY <= y + 90)
                    {
                        Main.tile[noLiquidX, noLiquidY].slope(0);
                        Main.tile[noLiquidX, noLiquidY].halfBrick(false);
                    }
                    if (Main.tile[noLiquidX, noLiquidY].type == TileID.LargePiles || Main.tile[noLiquidX, noLiquidY].type == TileID.LargePiles2 ||
                        Main.tile[noLiquidX, noLiquidY].type == TileID.SmallPiles)
                    {
                        Main.tile[noLiquidX, noLiquidY].active(false);
                    }
                }
            }
            for (int noHellHousesX = x; noHellHousesX <= x + 210; noHellHousesX++)
            {
                for (int noHellHousesY = y - 40; noHellHousesY <= y + 90; noHellHousesY++)
                {
                    if (Main.tile[noHellHousesX, noHellHousesY] == null) Main.tile[noHellHousesX, noHellHousesY] = new Tile();
                    if (Main.tile[noHellHousesX, noHellHousesY].type == TileID.ObsidianBrick || Main.tile[noHellHousesX, noHellHousesY].type == TileID.HellstoneBrick ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Painting3X2 || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Painting2X3 ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Painting4X3 || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Painting3X3 ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Painting6X4 || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Torches ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Statues || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Banners ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Platforms || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Chairs ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.WorkBenches || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Tables ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Lampposts || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Lamps ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Pianos || Main.tile[noHellHousesX, noHellHousesY].type == TileID.GrandfatherClocks ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Chandeliers || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Hellforge ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Pots || Main.tile[noHellHousesX, noHellHousesY].type == TileID.HangingLanterns ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Bookcases)
                    {
                        Main.tile[noHellHousesX, noHellHousesY].active(false);
                        Main.tile[noHellHousesX, noHellHousesY].wall = 0;
                    }
                    if (Main.tile[noHellHousesX, noHellHousesY].wall == WallID.ObsidianBrickUnsafe || Main.tile[noHellHousesX, noHellHousesY].wall == WallID.HellstoneBrickUnsafe)
                    {
                        Main.tile[noHellHousesX, noHellHousesY].wall = 0;
                    }
                    Main.tile[noHellHousesX, noHellHousesY].lava(false);
                    if (noHellHousesX >= x && noHellHousesX <= x + 210 && noHellHousesY >= y && noHellHousesY <= y + 90)
                    {
                        Main.tile[noHellHousesX, noHellHousesY].slope(0);
                        Main.tile[noHellHousesX, noHellHousesY].halfBrick(false);
                    }
                }
            }
            MakeWallRectangle(x + 1, y + 3, 187, 95, wallUnsafe);
            MakeWallRectangle(x + 185, y + 37, 23, 61, wallUnsafe);
            MakeRectangle(x, y, 210, 100, brick);
            MakeRectangle(x + 2, y, 186, 2);
            for (int c = x + 4; c <= x + 184; c += 4)
            {
                MakeRectangle(c, y + 1, 1, 1, brick);
                //MakeRectangle(c + 1, y + 1, 1, 1, brick);
            }
            MakeRectangle(x + 187, y + 12, 1, 1, brick);
            // front
            MakeRectangle(x + 190, y, 14, 4);
            MakeRectangle(x + 192, y + 3, 2, 1, brick);
            MakeRectangle(x + 196, y + 3, 2, 1, brick);
            MakeRectangle(x + 200, y + 3, 2, 1, brick);
            MakeRectangle(x + 204, y, 6, 16);
            MakeRectangle(x + 204, y + 2, 2, 6, brick);
            MakeRectangle(x + 185, y + 4, 19, 6, brick);
            MakeRectangle(x + 186, y + 10, 5, 1, brick);
            MakeRectangle(x + 187, y + 11, 3, 1, brick);
            MakeRectangle(x + 188, y + 12, 1, 1, brick);
            MakeRectangle(x + 204, y + 8, 1, 1, brick);
            // end front

            MakeRectangle(x, y + 9, 210, 91, brick);

            // top
            MakeRectangle(x, y + 2, 190, 7, brick);
            MakeRectangle(x + 122, y + 9, 51, 1, brick);
            MakeRectangle(x + 123, y + 10, 49, 1, brick);
            MakeRectangle(x + 124, y + 11, 47, 1, brick);
            MakeRectangle(x + 125, y + 12, 45, 1, brick);
            MakeRectangle(x + 126, y + 13, 43, 1, brick);
            MakeRectangle(x + 127, y + 14, 41, 1, brick);
            MakeRectangle(x + 128, y + 15, 39, 1, brick);
            MakeRectangle(x + 129, y + 16, 37, 1, brick);
            MakeRectangle(x + 130, y + 17, 35, 1, brick);
            MakeRectangle(x + 131, y + 18, 33, 1, brick);
            MakeRectangle(x + 132, y + 19, 31, 1, brick);
            MakeRectangle(x + 133, y + 20, 29, 1, brick);
            // spikes
            MakeRectangle(x + 135, y + 20, 11, 1, brick);
            MakeRectangle(x + 149, y + 20, 11, 1, brick);
            MakeRectangle(x + 136, y + 20, 1, 1, brick);
            MakeRectangle(x + 138, y + 20, 1, 1, brick);
            MakeRectangle(x + 140, y + 20, 1, 1, brick);
            MakeRectangle(x + 142, y + 20, 1, 1, brick);
            MakeRectangle(x + 144, y + 20, 1, 1, brick);
            MakeRectangle(x + 150, y + 20, 1, 1, brick);
            MakeRectangle(x + 152, y + 20, 1, 1, brick);
            MakeRectangle(x + 154, y + 20, 1, 1, brick);
            MakeRectangle(x + 156, y + 20, 1, 1, brick);
            MakeRectangle(x + 158, y + 20, 1, 1, brick);
            // end spikes
            MakeRectangle(x + 170, y + 12, 18, 4);
            MakeRectangle(x + 173, y + 9, 12, 3);
            MakeRectangle(x + 185, y + 10, 1, 2);
            MakeRectangle(x + 186, y + 11, 1, 1);
            MakeRectangle(x + 172, y + 10, 2, 7);
            MakeRectangle(x + 171, y + 11, 2, 7);
            MakeRectangle(x + 170, y + 12, 2, 7);
            MakeRectangle(x + 169, y + 13, 2, 7);
            MakeRectangle(x + 168, y + 14, 2, 7);
            MakeRectangle(x + 167, y + 15, 2, 7);
            MakeRectangle(x + 166, y + 16, 2, 7);
            MakeRectangle(x + 165, y + 17, 2, 7);
            MakeRectangle(x + 164, y + 18, 2, 7);
            MakeRectangle(x + 163, y + 19, 2, 7);
            MakeRectangle(x + 162, y + 20, 2, 7);
            MakeRectangle(x + 159, y + 21, 4, 7);

            MakeRectangle(x + 145, y + 21, 5, 1);

            MakeRectangle(x + 132, y + 21, 4, 7);
            MakeRectangle(x + 131, y + 20, 2, 7);
            MakeRectangle(x + 130, y + 19, 2, 7);
            MakeRectangle(x + 129, y + 18, 2, 7);
            MakeRectangle(x + 128, y + 17, 2, 7);
            MakeRectangle(x + 127, y + 16, 2, 7);
            MakeRectangle(x + 126, y + 15, 2, 7);
            MakeRectangle(x + 125, y + 14, 2, 7);
            MakeRectangle(x + 124, y + 13, 2, 7);
            MakeRectangle(x + 123, y + 12, 2, 7);
            MakeRectangle(x + 122, y + 11, 2, 7);
            MakeRectangle(x + 121, y + 10, 2, 7);

            MakeRectangle(x + 100, y + 9, 22, 7);

            MakeRectangle(x + 107, y + 16, 8, 4);
            MakeRectangle(x + 106, y + 20, 10, 1);
            MakeRectangle(x + 105, y + 21, 12, 1);
            MakeRectangle(x + 104, y + 22, 14, 1);

            MakeRectangle(x + 103, y + 23, 16, 10);

            MakeRectangle(x + 99, y + 10, 2, 7);
            MakeRectangle(x + 98, y + 11, 2, 7);
            MakeRectangle(x + 97, y + 12, 2, 7);
            MakeRectangle(x + 96, y + 13, 2, 7);
            MakeRectangle(x + 95, y + 14, 2, 7);
            MakeRectangle(x + 94, y + 15, 2, 7);
            MakeRectangle(x + 93, y + 16, 2, 7);
            MakeRectangle(x + 92, y + 17, 2, 7);
            MakeRectangle(x + 91, y + 18, 2, 7);
            MakeRectangle(x + 90, y + 19, 2, 7);
            MakeRectangle(x + 89, y + 20, 2, 7);
            MakeRectangle(x + 88, y + 21, 2, 7);
            MakeRectangle(x + 87, y + 22, 2, 7);
            MakeRectangle(x + 86, y + 23, 2, 7);
            MakeRectangle(x + 49, y + 24, 36, 6);
            MakeRectangle(x + 58, y + 23, 26, 1);
            MakeRectangle(x + 59, y + 22, 24, 1);
            MakeRectangle(x + 57, y + 21, 22, 1);
            MakeRectangle(x + 53, y + 22, 5, 1, spike);

            MakeRectangle(x + 54, y + 23, 1, 1);
            MakeRectangle(x + 56, y + 23, 26, 1);
            MakeRectangle(x + 48, y + 22, 4, 7);
            MakeRectangle(x + 47, y + 13, 4, 15);
            MakeRectangle(x + 39, y + 12, 11, 9);
            MakeRectangle(x + 40, y + 11, 9, 1);
            MakeRectangle(x + 38, y + 13, 4, 15);
            MakeRectangle(x + 30, y + 20, 11, 9);
            MakeRectangle(x + 33, y + 19, 5, 1, spike);
            MakeRectangle(x + 29, y + 13, 4, 15);
            MakeRectangle(x + 21, y + 12, 11, 9);
            MakeRectangle(x + 22, y + 11, 9, 1);
            MakeRectangle(x + 20, y + 13, 4, 15);
            MakeRectangle(x + 24, y + 21, 5, 1, spike);
            MakeRectangle(x + 15, y + 20, 8, 9);
            MakeRectangle(x + 15, y + 29, 7, 1);
            MakeRectangle(x + 15, y + 30, 1, 1);
            MakeRectangle(x + 6, y + 13, 9, 56);
            MakeRectangle(x + 8, y + 11, 5, 1);
            MakeRectangle(x + 7, y + 12, 7, 1);
            for (int c = y + 56; c <= y + 66; c += 2)
            {
                MakeRectangle(x + 6, c, 1, 1, spike);
                MakeRectangle(x + 14, c, 1, 1, spike);
            }
            MakeRectangle(x + 5, y + 55, 1, 15, spike);
            MakeRectangle(x + 15, y + 55, 1, 15, spike);
            MakeRectangle(x + 6, y + 69, 9, 1, spike);
            for (int c = x + 7; c <= x + 13; c += 2)
            {
                MakeRectangle(c, y + 68, 1, 1, spike);
            }
            MakeRectangle(x + 15, y + 41, 1, 10);
            MakeRectangle(x + 16, y + 42, 1, 8);
            MakeRectangle(x + 17, y + 43, 60, 7);
            MakeRectangle(x + 20, y + 42, 56, 1);
            MakeRectangle(x + 21, y + 41, 54, 1);
            MakeRectangle(x + 22, y + 40, 52, 1);
            MakeRectangle(x + 41, y + 50, 16, 3);
            MakeRectangle(x + 40, y + 53, 18, 1);
            MakeRectangle(x + 39, y + 54, 20, 1);
            MakeRectangle(x + 38, y + 55, 22, 17);
            MakeRectangle(x + 37, y + 67, 6, 6);
            MakeRectangle(x + 36, y + 68, 6, 6);
            MakeRectangle(x + 35, y + 69, 6, 6);
            MakeRectangle(x + 34, y + 70, 6, 6);
            MakeRectangle(x + 33, y + 71, 6, 6);
            MakeRectangle(x + 32, y + 72, 6, 6);
            MakeRectangle(x + 31, y + 73, 6, 6);
            MakeRectangle(x + 30, y + 74, 6, 6);
            MakeRectangle(x + 29, y + 75, 6, 6);
            MakeRectangle(x + 28, y + 76, 6, 6);
            MakeRectangle(x + 27, y + 77, 6, 6);
            MakeRectangle(x + 26, y + 78, 6, 6);
            MakeRectangle(x + 8, y + 79, 23, 6);
            MakeRectangle(x + 9, y + 78, 15, 1);
            MakeRectangle(x + 10, y + 77, 13, 1);
            MakeRectangle(x + 11, y + 76, 11, 1);
            MakeRectangle(x + 60, y + 63, 1, 9);
            MakeRectangle(x + 61, y + 64, 1, 8);
            MakeRectangle(x + 62, y + 65, 12, 7);
            MakeRectangle(x + 71, y + 64, 4, 7);
            MakeRectangle(x + 72, y + 63, 4, 7);
            MakeRectangle(x + 74, y + 61, 4, 7);
            MakeRectangle(x + 75, y + 60, 3, 1);
            MakeRectangle(x + 76, y + 59, 2, 1);
            MakeRectangle(x + 77, y + 68, 1, 1);

            MakeRectangle(x + 78, y + 57, 45, 12);
            // pits near big room
            MakeRectangle(x + 84, y + 69, 13, 1);
            MakeRectangle(x + 104, y + 69, 13, 1);
            MakeRectangle(x + 85, y + 70, 11, 24);
            MakeRectangle(x + 105, y + 70, 11, 24);
            for (int c = y + 81; c <= y + 91; c += 2)
            {
                MakeRectangle(x + 85, c, 1, 1, spike);
                MakeRectangle(x + 95, c, 1, 1, spike);
                MakeRectangle(x + 105, c, 1, 1, spike);
                MakeRectangle(x + 115, c, 1, 1, spike);
            }
            MakeRectangle(x + 84, y + 80, 1, 15, spike);
            MakeRectangle(x + 96, y + 80, 1, 15, spike);
            MakeRectangle(x + 85, y + 94, 11, 1, spike);
            MakeRectangle(x + 104, y + 80, 1, 15, spike);
            MakeRectangle(x + 116, y + 80, 1, 15, spike);
            MakeRectangle(x + 105, y + 94, 11, 1, spike);
            for (int c = x + 86; c <= x + 94; c += 2)
            {
                MakeRectangle(c, y + 93, 1, 1, spike);
            }
            for (int c = x + 106; c <= x + 114; c += 2)
            {
                MakeRectangle(c, y + 93, 1, 1, spike);
            }
            // end pits
            MakeRectangle(x + 123, y + 57, 1, 11);
            MakeRectangle(x + 124, y + 56, 1, 11);
            MakeRectangle(x + 125, y + 55, 1, 11);
            MakeRectangle(x + 126, y + 54, 1, 11);
            MakeRectangle(x + 127, y + 53, 1, 11);
            MakeRectangle(x + 128, y + 52, 1, 11);
            MakeRectangle(x + 129, y + 51, 1, 11);
            MakeRectangle(x + 130, y + 50, 1, 12);
            // big room
            MakeRectangle(x + 131, y + 44, 73, 51);
            MakeRectangle(x + 159, y + 93, 17, 1, brick);
            MakeRectangle(x + 160, y + 92, 15, 1, brick);
            MakeRectangle(x + 161, y + 91, 13, 1, brick);

            // platforms
            for (int i2 = x + 107; i2 < x + 107 + 8; i2++)
            {
                WorldGen.PlaceTile(i2, y + 16, platform);
            }
            for (int i2 = x + 103; i2 < x + 103 + 4; i2++)
            {
                WorldGen.PlaceTile(i2, y + 26, platform);
            }
            for (int i2 = x + 115; i2 < x + 115 + 4; i2++)
            {
                WorldGen.PlaceTile(i2, y + 26, platform);
            }
            for (int i2 = x + 41; i2 < x + 41 + 16; i2++)
            {
                WorldGen.PlaceTile(i2, y + 50, platform);
            }
            for (int i2 = x + 38; i2 < x + 38 + 5; i2++)
            {
                WorldGen.PlaceTile(i2, y + 58, platform);
            }
            for (int i2 = x + 54; i2 < x + 54 + 6; i2++)
            {
                WorldGen.PlaceTile(i2, y + 57, platform);
            }
            for (int i2 = x + 38; i2 < x + 38 + 3; i2++)
            {
                WorldGen.PlaceTile(i2, y + 64, platform);
            }
            for (int i2 = x + 58; i2 < x + 58 + 2; i2++)
            {
                WorldGen.PlaceTile(i2, y + 60, platform);
            }
            for (int i2 = x + 131; i2 < x + 131 + 14; i2++)
            {
                WorldGen.PlaceTile(i2, y + 45, platform);
            }
            for (int i2 = x + 131; i2 < x + 131 + 7; i2++)
            {
                WorldGen.PlaceTile(i2, y + 49, platform);
            }
            for (int i2 = x + 156; i2 < x + 156 + 10; i2++)
            {
                WorldGen.PlaceTile(i2, y + 47, platform);
            }
            for (int i2 = x + 171; i2 < x + 171 + 5; i2++)
            {
                WorldGen.PlaceTile(i2, y + 47, platform);
            }
            for (int i2 = x + 161; i2 < x + 161 + 20; i2++)
            {
                WorldGen.PlaceTile(i2, y + 54, platform);
            }
            for (int i2 = x + 188; i2 < x + 188 + 16; i2++)
            {
                WorldGen.PlaceTile(i2, y + 46, platform);
            }
            for (int i2 = x + 199; i2 < x + 199 + 5; i2++)
            {
                WorldGen.PlaceTile(i2, y + 50, platform);
            }
            for (int i2 = x + 192; i2 < x + 192 + 12; i2++)
            {
                WorldGen.PlaceTile(i2, y + 54, platform);
            }
            for (int i2 = x + 131; i2 < x + 131 + 20; i2++)
            {
                WorldGen.PlaceTile(i2, y + 65, platform);
            }
            for (int i2 = x + 131; i2 < x + 131 + 7; i2++)
            {
                WorldGen.PlaceTile(i2, y + 72, platform);
            }
            for (int i2 = x + 131; i2 < x + 131 + 13; i2++)
            {
                WorldGen.PlaceTile(i2, y + 79, platform);
            }
            for (int i2 = x + 185; i2 < x + 185 + 19; i2++)
            {
                WorldGen.PlaceTile(i2, y + 66, platform);
            }
            for (int i2 = x + 193; i2 < x + 193 + 11; i2++)
            {
                WorldGen.PlaceTile(i2, y + 73, platform);
            }
            for (int i2 = x + 197; i2 < x + 197 + 7; i2++)
            {
                WorldGen.PlaceTile(i2, y + 80, platform);
            }
            for (int i2 = x + 191; i2 < x + 191 + 13; i2++)
            {
                WorldGen.PlaceTile(i2, y + 87, platform);
            }
            //MakeRectangle(x + 107, y + 16, 8, 1, platform);
            //MakeRectangle(x + 103, y + 26, 4, 1, platform);
            //MakeRectangle(x + 115, y + 26, 4, 1, platform);
            //MakeRectangle(x + 41, y + 50, 16, 1, platform);
            //MakeRectangle(x + 38, y + 58, 5, 1, platform);
            //MakeRectangle(x + 54, y + 57, 6, 1, platform);
            //MakeRectangle(x + 38, y + 64, 3, 1, platform);
            //MakeRectangle(x + 58, y + 60, 2, 1, platform);
            //MakeRectangle(x + 131, y + 45, 14, 1, platform);
            //MakeRectangle(x + 131, y + 49, 7, 1, platform);
            //MakeRectangle(x + 156, y + 47, 10, 1, platform);
            //MakeRectangle(x + 171, y + 47, 5, 1, platform);
            //MakeRectangle(x + 161, y + 54, 20, 1, platform);
            //MakeRectangle(x + 188, y + 46, 16, 1, platform);
            //MakeRectangle(x + 199, y + 50, 5, 1, platform);
            //MakeRectangle(x + 192, y + 54, 12, 1, platform);
            //MakeRectangle(x + 131, y + 65, 20, 1, platform);
            //MakeRectangle(x + 131, y + 72, 7, 1, platform);
            //MakeRectangle(x + 131, y + 79, 13, 1, platform);
            //MakeRectangle(x + 185, y + 66, 19, 1, platform);
            //MakeRectangle(x + 193, y + 73, 11, 1, platform);
            //MakeRectangle(x + 197, y + 80, 7, 1, platform);
            //MakeRectangle(x + 191, y + 87, 13, 1, platform);
            // end platforms

            // books
            MakeRectangle(x + 103, y + 25, 1, 1, 50);
            MakeRectangle(x + 105, y + 25, 2, 1, 50);
            MakeRectangle(x + 116, y + 25, 3, 1, 50);
            MakeRectangle(x + 39, y + 57, 3, 1, 50);
            MakeRectangle(x + 55, y + 56, 2, 1, 50);
            MakeRectangle(x + 58, y + 56, 2, 1, 50);
            MakeRectangle(x + 39, y + 63, 2, 1, 50);
            MakeRectangle(x + 59, y + 59, 1, 1, 50);
            MakeRectangle(x + 132, y + 44, 3, 1, 50);
            MakeRectangle(x + 137, y + 44, 5, 1, 50);
            MakeRectangle(x + 143, y + 44, 1, 1, 50);
            MakeRectangle(x + 132, y + 48, 3, 1, 50);
            MakeRectangle(x + 136, y + 48, 1, 1, 50);
            MakeRectangle(x + 190, y + 45, 5, 1, 50);
            MakeRectangle(x + 197, y + 45, 4, 1, 50);
            MakeRectangle(x + 202, y + 45, 2, 1, 50);
            MakeRectangle(x + 200, y + 49, 3, 1, 50);
            MakeRectangle(x + 194, y + 53, 2, 1, 50);
            MakeRectangle(x + 197, y + 53, 1, 1, 50);
            MakeRectangle(x + 199, y + 53, 5, 1, 50);
            // end books

            MakeRectangle(x + 131, y + 43, 73, 1);
            MakeRectangle(x + 132, y + 42, 71, 1);
            MakeRectangle(x + 133, y + 41, 69, 1);
            MakeRectangle(x + 134, y + 40, 67, 1);
            MakeRectangle(x + 135, y + 39, 65, 1);

            // bookcases
            WorldGen.Place3x4(x + 59, y + 29, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 65, y + 29, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 70, y + 29, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 75, y + 29, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 81, y + 29, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 105, y + 32, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 116, y + 32, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 25, y + 49, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 30, y + 29, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 59, y + 49, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 64, y + 49, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 73, y + 49, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 10, y + 84, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 16, y + 84, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 22, y + 84, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 78, y + 68, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 82, y + 68, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 100, y + 68, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 119, y + 68, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 158, y + 46, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 163, y + 46, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 173, y + 46, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 163, y + 53, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 169, y + 53, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 177, y + 53, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 134, y + 64, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 140, y + 64, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 145, y + 64, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 133, y + 71, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 134, y + 78, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 140, y + 78, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 188, y + 65, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 194, y + 65, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 199, y + 65, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 196, y + 72, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 201, y + 72, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 200, y + 79, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 194, y + 86, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            WorldGen.Place3x4(x + 200, y + 86, (ushort)ModContent.TileType<Tiles.ImperviousBookcase>(), 0);
            // end bookcases

            MakeRectangle(x + 187, y + 12, 1, 1, brick);
            MakeRectangle(x + 188, y + 13, 1, 3);
            // doors
            WorldGen.PlaceTile(x + 188, y + 15, ModContent.TileType<Tiles.LockedImperviousDoor>());
            WorldGen.PlaceTile(x + 187, y + 15, ModContent.TileType<Tiles.LockedImperviousDoor>());
            // end doors
            WorldGen.PlaceTile(x + 167, y + 90, (ushort)ModContent.TileType<Tiles.LibraryAltar>());

            MakeRectangle(x + 189, y + 12, 1, 4);
            MakeRectangle(x + 190, y + 11, 1, 5);
            MakeRectangle(x + 191, y + 10, 13, 6);
            MakeRectangle(x + 204, y + 9, 1, 8);
            MakeRectangle(x + 205, y + 8, 1, 10);
            MakeRectangle(x + 206, y + 8, 4, 11);
            MakeRectangle(x + 207, y + 19, 3, 1);
            MakeRectangle(x + 208, y + 20, 2, 1);
            MakeRectangle(x + 209, y + 21, 1, 1);
            for (int c = x; c < x + 210; c++)
            {
                for (int v = y; v < y + 5; v++)
                {
                    SquareTileFrame(c, v, resetSlope: true);
                }
            }
            MakeRectangle(x + 135, y + 21, 25, 7);
            for (int c = x + 136; c <= x + 144; c += 2)
            {
                MakeRectangle(c, y + 21, 1, 1, spike);
                MakeRectangle(c, y + 27, 1, 1, spike);
            }
            for (int c = x + 150; c <= x + 158; c += 2)
            {
                MakeRectangle(c, y + 21, 1, 1, spike);
                MakeRectangle(c, y + 27, 1, 1, spike);
            }



            AddHellcastleChest(x + 111, y + 31);

            MakeWallRectangle(x + 192, y + 9, 2, 8, wallSafe);
            MakeWallRectangle(x + 196, y + 9, 2, 8, wallSafe);
            MakeWallRectangle(x + 200, y + 9, 2, 8, wallSafe);
            MakeRectangle(x + 15, y + 19, 5, 1, spike);
            MakeRectangle(x + 16, y + 20, 1, 1, spike);
            MakeRectangle(x + 18, y + 20, 1, 1, spike);
            MakeRectangle(x + 25, y + 20, 1, 1, spike);
            MakeRectangle(x + 27, y + 20, 1, 1, spike);
            MakeRectangle(x + 34, y + 20, 1, 1, spike);
            MakeRectangle(x + 36, y + 20, 1, 1, spike);
            MakeRectangle(x + 43, y + 20, 1, 1, spike);
            MakeRectangle(x + 45, y + 20, 1, 1, spike);
            MakeRectangle(x + 135, y + 20, 11, 1, spike);
            MakeRectangle(x + 135, y + 28, 11, 1, spike);
            MakeRectangle(x + 149, y + 20, 11, 1, spike);
            MakeRectangle(x + 149, y + 28, 11, 1, spike);
            MakeRectangle(x + 84, y + 24, 4, 6);
            MakeRectangle(x + 75, y + 67, 2, 2);
            MakeRectangle(x + 53, y + 23, 1, 1, spike);
            MakeRectangle(x + 55, y + 23, 1, 1, spike);
            MakeRectangle(x + 57, y + 23, 1, 1, spike);
            MakeRectangle(x + 131, y + 94, 73, 1, brick);
            MakeRectangle(x + 139, y + 94, 15, 1, spike);
            MakeRectangle(x + 181, y + 94, 15, 1, spike);
            MakeRectangle(x + 42, y + 21, 5, 1, spike);
            MakeRectangle(x + 59, y + 21, 1, 1, brick);


            //MakeRectangle(x + 141, y + 93, 1, 1, spike);
            //MakeRectangle(x + 143, y + 93, 1, 1, spike);
            //MakeRectangle(x + 145, y + 93, 1, 1, spike);
            //MakeRectangle(x + 147, y + 93, 1, 1, spike);
            //MakeRectangle(x + 149, y + 93, 1, 1, spike);
            //MakeRectangle(x + 151, y + 93, 1, 1, spike);

            //MakeRectangle(x + 183, y + 93, 1, 1, spike);
            //MakeRectangle(x + 185, y + 93, 1, 1, spike);
            //MakeRectangle(x + 187, y + 93, 1, 1, spike);
            //MakeRectangle(x + 189, y + 93, 1, 1, spike);
            //MakeRectangle(x + 191, y + 93, 1, 1, spike);
            //MakeRectangle(x + 193, y + 93, 1, 1, spike);
            for (int c = x + 140; c <= x + 152; c += 2)
            {
                if (c != x + 140) MakeRectangle(c, y + 93, 1, 1, spike);
            }
            for (int c = x + 182; c <= x + 194; c += 2)
            {
                if (c != x + 182) MakeRectangle(c, y + 93, 1, 1, spike);
            }

            //MakeRectangle(x + 140, y + 93, 1, 1, spike);
            //MakeRectangle(x + 142, y + 93, 1, 1, spike);
            //MakeRectangle(x + 144, y + 93, 1, 1, spike);
            //MakeRectangle(x + 146, y + 93, 1, 1, spike);
            //MakeRectangle(x + 148, y + 93, 1, 1, spike);
            //MakeRectangle(x + 150, y + 93, 1, 1, spike);
            //MakeRectangle(x + 152, y + 93, 1, 1, spike);

            //MakeRectangle(x + 182, y + 93, 1, 1, spike);
            //MakeRectangle(x + 184, y + 93, 1, 1, spike);
            //MakeRectangle(x + 186, y + 93, 1, 1, spike);
            //MakeRectangle(x + 188, y + 93, 1, 1, spike);
            //MakeRectangle(x + 190, y + 93, 1, 1, spike);
            //MakeRectangle(x + 192, y + 93, 1, 1, spike);
            //MakeRectangle(x + 194, y + 93, 1, 1, spike);

            //MakeRectangle(x + 136, y + 27, 1, 1, spike);
            //MakeRectangle(x + 138, y + 27, 1, 1, spike);
            //MakeRectangle(x + 140, y + 27, 1, 1, spike);
            //MakeRectangle(x + 142, y + 27, 1, 1, spike);
            //MakeRectangle(x + 144, y + 27, 1, 1, spike);

            //MakeRectangle(x + 150, y + 27, 1, 1, spike);
            //MakeRectangle(x + 152, y + 27, 1, 1, spike);
            //MakeRectangle(x + 154, y + 27, 1, 1, spike);
            //MakeRectangle(x + 156, y + 27, 1, 1, spike);
            //MakeRectangle(x + 158, y + 27, 1, 1, spike);

            // +21
            //MakeRectangle(x + 136, y + 21, 1, 1, spike);
            //MakeRectangle(x + 138, y + 21, 1, 1, spike);
            //MakeRectangle(x + 140, y + 21, 1, 1, spike);
            //MakeRectangle(x + 142, y + 21, 1, 1, spike);
            //MakeRectangle(x + 144, y + 21, 1, 1, spike);

            //MakeRectangle(x + 150, y + 21, 1, 1, spike);
            //MakeRectangle(x + 152, y + 21, 1, 1, spike);
            //MakeRectangle(x + 154, y + 21, 1, 1, spike);
            //MakeRectangle(x + 156, y + 21, 1, 1, spike);
            //MakeRectangle(x + 158, y + 21, 1, 1, spike);
            // end +21
            //MakeRectangle(x + 139, y + 93, 1, 1);
            //MakeRectangle(x + 153, y + 93, 1, 1);
            //MakeRectangle(x + 181, y + 93, 1, 1);
            //MakeRectangle(x + 195, y + 93, 1, 1);

            //MakeRectangle(x + 139, y + 94, 1, 1, spike);
            //MakeRectangle(x + 153, y + 94, 1, 1, spike);
            //MakeRectangle(x + 181, y + 94, 1, 1, spike);
            //MakeRectangle(x + 195, y + 94, 1, 1, spike);

            MakeRectangle(x + 52, y + 22, 1, 1, brick);
            MakeRectangle(x + 58, y + 22, 1, 1, brick);
            MakeRectangle(x + 58, y + 21, 2, 1, brick);

            MakeRectangle(x + 51, y + 21, 9, 3);
            MakeRectangle(x + 51, y + 21, 9, 1, brick);
            MakeRectangle(x + 52, y + 22, 7, 1, brick);
            MakeRectangle(x + 53, y + 22, 5, 1, spike);
            MakeRectangle(x + 53, y + 23, 1, 1, spike);
            MakeRectangle(x + 55, y + 23, 1, 1, spike);
            MakeRectangle(x + 57, y + 23, 1, 1, spike);

            //MakeRectangle(x + 135, y + 27, 1, 1);
            //MakeRectangle(x + 145, y + 27, 1, 1);
            //MakeRectangle(x + 149, y + 27, 1, 1);
            //MakeRectangle(x + 159, y + 27, 1, 1);

            //MakeRectangle(x + 135, y + 28, 1, 1, spike);
            //MakeRectangle(x + 145, y + 28, 1, 1, spike);
            //MakeRectangle(x + 149, y + 28, 1, 1, spike);
            //MakeRectangle(x + 159, y + 28, 1, 1, spike);



            MakeRectangle(x + 138, y + 44, 1, 1);
            WorldGen.PlaceTile(x + 138, y + 44, ModContent.TileType<Tiles.DevilsScythe>()); // devil's scythe
            LoK = new Vector2(x + 168, y + 57);
            WorldGen.destroyObject = false;
        }
        public static void MakeWallRectangle(int x, int y, int width, int height, byte type)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    Main.tile[i, j].wall = type;
                    WorldGen.SquareWallFrame(i, j);
                }
            }
        }        public static void MakeRectangle(int x, int y, int width, int height, int type = -1)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    Main.tile[i, j].liquid = 0;
                    Main.tile[i, j].lava(false);
                    if (type == -1) WorldGen.KillTile(i, j, false, false, true);
                    else
                    {
                        Main.tile[i, j].active(true);
                        Main.tile[i, j].type = (ushort)type;
                        if (type == 50) Main.tile[i, j].frameX = (short)(WorldGen.genRand.Next(0, 5) * 18);
                        if (type == 4) Main.tile[i, j].frameY = 176;
                        //if (type == 19)
                        //{
                        //    Main.tile[i, j].type = (ushort)ModContent.TileType<Tiles.ResistantWoodPlatform>();
                        //}
                        SquareTileFrame(i, j, resetSlope: true);
                    }
                }
            }
        }        public static bool AddHellcastleChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
        {
            //if (WorldGen.genRand == null)
            //{
            //    WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
            //}
            int k = j;
            while (k < Main.maxTilesY)
            {
                if (Main.tile[i, k].active() && Main.tileSolid[(int)Main.tile[i, k].type])
                {
                    int num = k;
                    int num2 = WorldGen.PlaceChest(i - 1, num - 1, (ushort)ModContent.TileType<LockedUnderworldChest>(), notNearOtherChests);
                    if (num2 >= 0)
                    {
                        int num3 = 0;
                        while (num3 == 0)
                        {
                            Main.chest[num2].item[0].SetDefaults(ModContent.ItemType<Items.Boomlash>(), false);
                            Main.chest[num2].item[0].Prefix(-1);
                            Main.chest[num2].item[1].SetDefaults(ModContent.ItemType<Items.EctoplasmicBeacon>(), false);
                            Main.chest[num2].item[1].stack = 1;
                            int rand = WorldGen.genRand.Next(3);
                            if (rand == 0)
                            {
                                Main.chest[num2].item[2].SetDefaults(ItemID.Ectoplasm, false);
                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(5, 11);
                            }
                            if (rand == 1)
                            {
                                Main.chest[num2].item[2].SetDefaults(ModContent.ItemType<Items.ImperviousBrick>(), false);
                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(200, 451);
                            }
                            if (rand == 2)
                            {
                                Main.chest[num2].item[2].SetDefaults(ModContent.ItemType<Items.Vortex>(), false);
                                Main.chest[num2].item[2].Prefix(-2);
                            }
                            int n2 = WorldGen.genRand.Next(5);
                            if (n2 == 0)
                            {
                                Main.chest[num2].item[3].SetDefaults(ModContent.ItemType<Items.BloodCastPotion>(), false);
                                Main.chest[num2].item[3].stack = WorldGen.genRand.Next(2, 4);
                            }
                            if (n2 == 1)
                            {
                                Main.chest[num2].item[3].SetDefaults(ModContent.ItemType<Items.LuckPotion>(), false);
                                Main.chest[num2].item[3].stack = WorldGen.genRand.Next(2, 4);
                            }
                            if (n2 == 2)
                            {
                                Main.chest[num2].item[3].SetDefaults(ModContent.ItemType<Items.WisdomPotion>(), false);
                                Main.chest[num2].item[3].stack = WorldGen.genRand.Next(2, 4);
                            }
                            if (n2 == 3)
                            {
                                Main.chest[num2].item[3].SetDefaults(ModContent.ItemType<Items.RoguePotion>(), false);
                                Main.chest[num2].item[3].stack = WorldGen.genRand.Next(2, 4);
                            }
                            if (n2 == 4)
                            {
                                Main.chest[num2].item[3].SetDefaults(ModContent.ItemType<Items.GauntletPotion>(), false);
                                Main.chest[num2].item[3].stack = WorldGen.genRand.Next(2, 4);
                            }
                            if (WorldGen.genRand.Next(10) == 0)
                            {
                                //Main.chest[num2].item[4].SetDefaults(ID.ItemID.VampireTeeth, false);
                                //Main.chest[num2].item[4].Prefix(-2);
                                Main.chest[num2].item[5].SetDefaults(ItemID.GoldCoin, false);
                                Main.chest[num2].item[5].stack = WorldGen.genRand.Next(10, 33);
                            }
                            else
                            {
                                Main.chest[num2].item[4].SetDefaults(ItemID.GoldCoin, false);
                                Main.chest[num2].item[4].stack = WorldGen.genRand.Next(10, 33);
                            }
                            num3++;
                        }
                        return true;
                    }
                    return false;
                }
                else
                {
                    k++;
                }
            }
            return false;
        }        public bool Comet(int i, int j, int tile)        {            if (i < 50 || i > Main.maxTilesX - 50)            {                return false;            }            if (j < 50 || j > Main.maxTilesY - 50)            {                return false;            }            var num = 25;            var rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);            for (var k = 0; k < 255; k++)            {                if (Main.player[k].active)                {                    var value = new Rectangle((int)(Main.player[k].position.X + Main.player[k].width / 2 - NPC.sWidth / 2 - NPC.safeRangeX), (int)(Main.player[k].position.Y + Main.player[k].height / 2 - NPC.sHeight / 2 - NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);                    if (rectangle.Intersects(value))                    {                        return false;                    }                }            }            for (var l = 0; l < 200; l++)            {                if (Main.npc[l].active)                {                    var value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);                    if (rectangle.Intersects(value2))                    {                        return false;                    }                }            }            for (var m = i - num; m < i + num; m++)            {                for (var n = j - num; n < j + num; n++)                {                    if (Main.tile[m, n].active() && Main.tile[m, n].type == 21 || Main.tile[m, n].type == TileID.Containers2)                    {                        return false;                    }                }            }            stopCometDrops = true;            num = 15;            for (var num2 = i - num; num2 < i + num; num2++)            {                for (var num3 = j - num; num3 < j + num; num3++)                {                    if (num3 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num2) + Math.Abs(j - num3) < num * 1.5 + Main.rand.Next(-5, 5))                    {                        if (!Main.tileSolid[Main.tile[num2, num3].type])                        {                            Main.tile[num2, num3].active(false);                        }                        Main.tile[num2, num3].type = (ushort) tile;                    }                }            }            num = 10;            for (var num4 = i - num; num4 < i + num; num4++)            {                for (var num5 = j - num; num5 < j + num; num5++)                {                    if (num5 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num4) + Math.Abs(j - num5) < num + Main.rand.Next(-3, 4))                    {                        Main.tile[num4, num5].active(false);                    }                }            }            num = 16;            for (var num6 = i - num; num6 < i + num; num6++)            {                for (var num7 = j - num; num7 < j + num; num7++)                {                    if (Main.tile[num6, num7].type == 5 || Main.tile[num6, num7].type == 32)                    {                        WorldGen.KillTile(num6, num7, false, false, false);                    }                    WorldGen.SquareTileFrame(num6, num7, true);                    WorldGen.SquareWallFrame(num6, num7, true);                }            }            num = 23;            for (var num8 = i - num; num8 < i + num; num8++)            {                for (var num9 = j - num; num9 < j + num; num9++)                {                    if (Main.tile[num8, num9].active() && Main.rand.Next(10) == 0 && Math.Abs(i - num8) + Math.Abs(j - num9) < num * 1.3)                    {                        if (Main.tile[num8, num9].type == 5 || Main.tile[num8, num9].type == 32)                        {                            WorldGen.KillTile(num8, num9, false, false, false);                        }                        Main.tile[num8, num9].type = (ushort) tile;                        WorldGen.SquareTileFrame(num8, num9, true);                    }                }            }            stopCometDrops = false;            if (Main.netMode == 0)            {                Main.NewText("A comet has struck ground!", 0, 201, 190, false);            }            else if (Main.netMode == 2)            {                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("A comet has struck ground!"), new Color(0, 201, 190));            }            if (Main.netMode != 1)            {                NetMessage.SendTileSquare(-1, i, j, 30);            }            return true;        }        public static void InitiateSuperHardmode()        {            ThreadPool.QueueUserWorkItem(new WaitCallback(shmCallback), 1);        }
        public static void shmCallback(object threadContext)
        {
            if (ExxoAvalonOrigins.superHardmode) return;
            SpawnOblivionOreAndOpals();
            ExxoAvalonOrigins.superHardmode = true;            if (Main.netMode == 0)
            {
                Main.NewText("The ancient souls have been disturbed...", 255, 60, 0);
                Main.NewText("The heavens above are rumbling...", 50, 255, 130);
                Main.NewText("Your world has been blessed with the elements!", 0, 255, 0);
            }
            else if (Main.netMode == 2)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The ancient souls have been disturbed..."), new Color(255, 60, 0));
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The heavens above are rumbling..."), new Color(50, 255, 130));
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with the elements!"), new Color(0, 255, 0));
            }            if (Main.netMode == 2)
            {
                Netplay.ResetSections();
            }
        }        public static void SpawnOblivionOreAndOpals()
        {
            if (Main.rand == null)
            {
                Main.rand = new UnifiedRandom((int)DateTime.Now.Ticks);
            }
            // oblivion ore
            for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
            {
                int x = Main.rand.Next(100, Main.maxTilesX - 100);
                int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                WorldGen.OreRunner(x, y, Main.rand.Next(3, 6), Main.rand.Next(2, 7), (ushort)ModContent.TileType<Tiles.OblivionOre>());
            }
            // opals
            for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
            {
                int x = Main.rand.Next(100, Main.maxTilesX - 100);
                int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                WorldGen.OreRunner(x, y, Main.rand.Next(4, 7), Main.rand.Next(1, 4), (ushort)ModContent.TileType<Tiles.Opal>());
            }
            // onyx
            for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
            {
                int x = Main.rand.Next(100, Main.maxTilesX - 100);
                int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                WorldGen.OreRunner(x, y, Main.rand.Next(3, 5), Main.rand.Next(1, 4), (ushort)ModContent.TileType<Tiles.Onyx>());
            }
            // kunzite
            for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
            {
                int x = Main.rand.Next(100, Main.maxTilesX - 100);
                int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                WorldGen.OreRunner(x, y, Main.rand.Next(3, 5), Main.rand.Next(1, 4), (ushort)ModContent.TileType<Tiles.Kunzite>());
            }
            // primordial ore
            for (int a = 0; a < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); a++)
            {
                int x = Main.rand.Next(100, Main.maxTilesX - 100);
                int y = Main.rand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                WorldGen.OreRunner(x, y, Main.rand.Next(3, 6), Main.rand.Next(5, 8), (ushort)ModContent.TileType<Tiles.PrimordialOre>());
            }
        }        public override TagCompound Save()        {            var toSave = new TagCompound            {                { "ExxoAvalonOrigins:LastOpenedVersion", ExxoAvalonOrigins.version.ToString() },                { "ExxoAvalonOrigins:SuperHardMode", ExxoAvalonOrigins.superHardmode },                { "ExxoAvalonOrigins:DownedPhantasm", downedPhantasm },                { "ExxoAvalonOrigins:LibraryofKnowledge", LoK },                { "ExxoAvalonOrigins:Contagion", contaigon },                { "ExxoAvalonOrigins:DungeonSide", dungeonSide },                { "ExxoAvalonOrigins:DungeonX", ExxoAvalonOrigins.dungeonEx },                { "ExxoAvalonOrigins:SHMOreTier1", shmOreTier1 },                { "ExxoAvalonOrigins:SHMOreTier2", shmOreTier2 },
                { "ExxoAvalonOrigins:HallowAltarCount", hallowAltarCount }            };            return toSave;        }        public override void Load(TagCompound tag)        {            if (tag.ContainsKey("ExxoAvalonOrigins:LastOpenedVersion"))            {                ExxoAvalonOrigins.lastOpenedVersion = new Version(tag["ExxoAvalonOrigins:LastOpenedVersion"].ToString());            }            if (tag.ContainsKey("ExxoAvalonOrigins:SuperHardMode"))            {                ExxoAvalonOrigins.superHardmode = tag.Get<bool>("ExxoAvalonOrigins:SuperHardMode");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DownedPhantasm"))            {                downedPhantasm = tag.Get<bool>("ExxoAvalonOrigins:DownedPhantasm");            }            if (tag.ContainsKey("ExxoAvalonOrigins:LibraryofKnowledge"))            {                LoK = tag.Get<Vector2>("ExxoAvalonOrigins:LibraryofKnowledge");            }            if (tag.ContainsKey("ExxoAvalonOrigins:Contagion"))            {                contaigon = tag.Get<bool>("ExxoAvalonOrigins:Contagion");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DungeonSide"))
            {
                dungeonSide = tag.GetAsInt("ExxoAvalonOrigins:DungeonSide");
            }            else            {
                dungeonSide = -1;
            }            if (tag.ContainsKey("ExxoAvalonOrigins:DungeonX"))            {                ExxoAvalonOrigins.dungeonEx = tag.GetAsInt("ExxoAvalonOrigins:DungeonX");            }            else
            {
                ExxoAvalonOrigins.dungeonEx = dungeonSide == -1 ? Main.maxTilesX / 3 : Main.maxTilesX - Main.maxTilesX / 3;
            }            if (tag.ContainsKey("ExxoAvalonOrigins:SHMOreTier1"))            {                shmOreTier1 = tag.GetAsInt("ExxoAvalonOrigins:SHMOreTier1");            }            if (tag.ContainsKey("ExxoAvalonOrigins:SHMOreTier2"))            {                shmOreTier2 = tag.GetAsInt("ExxoAvalonOrigins:SHMOreTier2");            }            if (tag.ContainsKey("ExxoAvalonOrigins:HallowAltarCount"))            {                hallowAltarCount = tag.GetAsInt("ExxoAvalonOrigins:HallowAltarCount");            }        }        public static void GenerateHearts(int i, int j, int tile)        {            var num = WorldGen.genRand.Next(2);            if (num == 0)            {                num = 1;            }            else if (num == 1)            {                num = 3;            }            if (WorldGen.genRand.Next(20) == 0)            {                num = 5;            }            var num2 = 1;            Main.tile[i, j + 1].active(true);            Main.tile[i, j + 1].type = (ushort) tile;            WorldGen.SquareTileFrame(i, j + 1);            for (var k = j; k >= j - num; k--)            {                for (var l = i - num2; l <= i + num2; l++)                {                    if ((l != i - num2 && l != i + num2) || num2 != num + 1)                    {                        Main.tile[l, k].active(true);                        Main.tile[l, k].type = (ushort) tile;                        WorldGen.SquareTileFrame(l, k);                    }                }                num2++;            }            for (var m = i - num2 + 1; m <= i + num2 - 1; m++)            {                Main.tile[m, j - num - 1].active(true);                Main.tile[m, j - num - 1].type = (ushort) tile;                WorldGen.SquareTileFrame(m, j + num + 1);            }            for (var n = i - num2 + 2; n <= i + num2 - 2; n++)            {                if (n != i)                {                    Main.tile[n, j - num - 2].active(true);                    Main.tile[n, j - num - 2].type = (ushort) tile;                    WorldGen.SquareTileFrame(n, j + num + 2);                }            }            for (var num3 = i - num2 + 3; num3 <= i + num2 - 3; num3++)            {                if (num3 != i && num3 != i + 1 && num3 != i - 1)                {                    Main.tile[num3, j - num - 3].active(true);                    Main.tile[num3, j - num - 3].type = (ushort) tile;                    WorldGen.SquareTileFrame(num3, j + num + 3);                }            }        }        public static void IceShrine2(int x, int y)        {            var num = 2;            var num2 = WorldGen.genRand.Next(3);            var num3 = 0;            var num4 = WorldGen.genRand.Next(9, 13);            switch (num2)            {                case 0:                    num3 = 6;                    break;                case 1:                    num3 = 8;                    break;                case 2:                    num3 = 10;                    break;            }            for (var i = x - num3 - num * 4 + 3; i <= x + num * 4 + 1 + num3; i++)            {                for (var j = y + num + 4; j <= y + 13 + num4; j++)                {                    Main.tile[i, j].liquid = 0;                    Main.tile[i, j].lava(false);                    Main.tile[i, j].honey(false);                    Main.tile[i, j].active(false);                    if (j <= y + 10 + num4 && j >= y + 7)                    {                        if ((i > x + num * 4 + 6 - num3 && i < x + num * 4 + 6) || (i > x - num * 4 - 1 && i < x - num * 4 + num3 - 2))                        {                            Main.tile[i, j].type = 0;                            Main.tile[i, j].wall = 84;                            WorldGen.SquareWallFrame(i, j, true);                        }                        if ((i > x + num * 4 + 6 - 2 * num3 + 2 && i < x + num * 4 + 6 - num3 + 2) || (i > x - num * 4 + num3 - 3 && i < x - num * 4 + 2 * num3 - 4))                        {                            Main.tile[i, j].type = 0;                            Main.tile[i, j].wall = 84;                            WorldGen.SquareWallFrame(i, j, true);                        }                        if (i <= x + num * 4 + 6 - 2 * num3 + 2 && i >= x - num * 4 + 2 * num3 - 4)                        {                            Main.tile[i, j].type = 0;                            Main.tile[i, j].wall = 84;                            WorldGen.SquareWallFrame(i, j, true);                        }                    }                }            }            for (var k = x - num3 - num * 4 + 2; k <= x + num * 4 + 1 + num3; k++)            {                for (var l = y + num + 4; l <= y + 13 + num4; l++)                {                    if (Main.tile[k, l].type > 0)                    {                        Main.tile[k, l].active(true);                    }                }            }            for (var m = x - num * 4; m >= x - num3 - num * 4; m--)            {                if (m % 2 == 0)                {                    Main.tile[m, y].active(true);                    Main.tile[m, y].type = TileID.IceBrick;                    var resetSlope = true;                    SquareTileFrame(m, y, true, resetSlope);                }                if (m > x - num3 - num * 4 && m < x - num * 4)                {                    Main.tile[m, y + 4].active(true);                    Main.tile[m, y + 4].type = TileID.IceBrick;                    var resetSlope2 = true;                    SquareTileFrame(m, y + 4, true, resetSlope2);                }                if (m > x - num3 - num * 4 + 1 && m < x - num * 4)                {                    for (var n = y + 9; n <= y + 9 + num4; n++)                    {                        if (m > x - num3 - num * 4 && m < x - num * 4 + 1)                        {                            Main.tile[m, n].active(false);                            Main.tile[m, n].wall = WallID.IceBrick;                            WorldGen.SquareWallFrame(m, n, true);                        }                    }                    Main.tile[m, y + 5].active(true);                    Main.tile[m, y + 5].type = TileID.IceBrick;                    var resetSlope3 = true;                    SquareTileFrame(m, y + 5, true, resetSlope3);                    Main.tile[m, y + 8].active(true);                    Main.tile[m, y + 8].type = TileID.IceBrick;                    var resetSlope4 = true;                    SquareTileFrame(m, y + 8, true, resetSlope4);                    if (m < x - num * 4 - 1)                    {                        Main.tile[m, y + 9].active(true);                        Main.tile[m, y + 9].type = TileID.IceBrick;                        var resetSlope5 = true;                        SquareTileFrame(m, y + 9, true, resetSlope5);                    }                    if (m < x - num * 4 - 2)                    {                        Main.tile[m, y + 10].active(true);                        Main.tile[m, y + 10].type = TileID.IceBrick;                        var resetSlope6 = true;                        SquareTileFrame(m, y + 10, true, resetSlope6);                    }                    Main.tile[m, y + 9 + num4].active(true);                    Main.tile[m, y + 9 + num4].type = TileID.IceBrick;                    var resetSlope7 = true;                    SquareTileFrame(m, y + 9 + num4, true, resetSlope7);                    Main.tile[m, y + 10 + num4].active(true);                    Main.tile[m, y + 10 + num4].type = TileID.IceBrick;                    var resetSlope8 = true;                    SquareTileFrame(m, y + 10 + num4, true, resetSlope8);                }                for (var num5 = y + 1; num5 <= y + 1 + num; num5++)                {                    Main.tile[m, num5].active(true);                    Main.tile[m, num5].type = TileID.IceBrick;                    var resetSlope9 = true;                    SquareTileFrame(m, num5, true, resetSlope9);                }            }            for (var num6 = x + num * 4 + 4; num6 <= x + num3 + num * 4 + 4; num6++)            {                if (num6 % 2 == 0)                {                    Main.tile[num6, y].active(true);                    Main.tile[num6, y].type = TileID.IceBrick;                    var resetSlope10 = true;                    SquareTileFrame(num6, y, true, resetSlope10);                }                if (num6 < x + num3 + num * 4 + 4 && num6 > x + 4 + num * 4)                {                    Main.tile[num6, y + 4].active(true);                    Main.tile[num6, y + 4].type = TileID.IceBrick;                    var resetSlope11 = true;                    SquareTileFrame(num6, y + 4, true, resetSlope11);                }                if (num6 < x + num3 + num * 4 + 3 && num6 > x + num * 4 + 4)                {                    for (var num7 = y + 10; num7 <= y + 10 + num4 - 1; num7++)                    {                        if (num6 < x + num3 + num * 4 + 2 && num6 > x + num * 4 + 5)                        {                            Main.tile[num6, num7].active(false);                            Main.tile[num6, num7].wall = WallID.IceBrick;                            WorldGen.SquareWallFrame(num6, num7, true);                        }                    }                    Main.tile[num6, y + 5].active(true);                    Main.tile[num6, y + 5].type = TileID.IceBrick;                    var resetSlope12 = true;                    SquareTileFrame(num6, y + 5, true, resetSlope12);                    Main.tile[num6, y + 8].active(true);                    Main.tile[num6, y + 8].type = TileID.IceBrick;                    var resetSlope13 = true;                    SquareTileFrame(num6, y + 8, true, resetSlope13);                    if (num6 > x + num * 4 + 5)                    {                        Main.tile[num6, y + 9].active(true);                        Main.tile[num6, y + 9].type = TileID.IceBrick;                        var resetSlope14 = true;                        SquareTileFrame(num6, y + 9, true, resetSlope14);                    }                    if (num6 > x + num * 4 + 6)                    {                        Main.tile[num6, y + 10].active(true);                        Main.tile[num6, y + 10].type = TileID.IceBrick;                        var resetSlope15 = true;                        SquareTileFrame(num6, y + 10, true, resetSlope15);                    }                    Main.tile[num6, y + 9 + num4].active(true);                    Main.tile[num6, y + 9 + num4].type = TileID.IceBrick;                    var resetSlope16 = true;                    SquareTileFrame(num6, y + 9 + num4, true, resetSlope16);                    Main.tile[num6, y + 10 + num4].active(true);                    Main.tile[num6, y + 10 + num4].type = TileID.IceBrick;                    var resetSlope17 = true;                    SquareTileFrame(num6, y + 10 + num4, true, resetSlope17);                }                for (var num8 = y + 1; num8 <= y + 1 + num; num8++)                {                    Main.tile[num6, num8].active(true);                    Main.tile[num6, num8].type = TileID.IceBrick;                    var resetSlope18 = true;                    SquareTileFrame(num6, num8, true, resetSlope18);                }            }            var num9 = 1;            for (var num10 = y; num10 <= y + num + 4; num10++)            {                for (var num11 = x - num9 + 1; num11 <= x + num9 + 1; num11++)                {                    Main.tile[num11 + 1, num10].active(true);                    Main.tile[num11 + 1, num10].type = TileID.IceBrick;                    var resetSlope19 = true;                    SquareTileFrame(num11 + 1, num10, true, resetSlope19);                    if (num10 >= y + num + 4 && num10 <= y + num + 8 + num4 && (num11 == x - num9 + 3 || num11 == x + num9 + 1))                    {                        Main.tile[num11, num10 + num4].active(true);                        Main.tile[num11, num10 + num4].type = TileID.WoodenBeam;                        var resetSlope20 = true;                        SquareTileFrame(num11, num10 + num4, true, resetSlope20);                        if (num10 == y + num + 4)                        {                            Main.tile[num11, num10 + num4].active(true);                            Main.tile[num11, num10 + num4].type = TileID.IceBrick;                            var resetSlope21 = true;                            SquareTileFrame(num11, num10 + num4, true, resetSlope21);                        }                    }                    if (num10 == y + num + 4 && num11 == x - num9 + 2)                    {                        Main.tile[num11, num10 + num4].active(true);                        Main.tile[num11, num10 + num4].type = TileID.Torches;                        Main.tile[num11, num10 + num4].frameY = 198;                        var resetSlope22 = true;                        SquareTileFrame(num11, num10 + num4, true, resetSlope22);                    }                    if (num10 == y + num + 4 && num11 >= x - num9 + 4 && num11 <= x + num9)                    {                        Main.tile[num11, num10 + num4].active(true);                        Main.tile[num11, num10 + num4].type = TileID.Platforms;                        Main.tile[num11, num10 + num4].frameY = 0;                        var resetSlope23 = true;                        SquareTileFrame(num11, num10 + num4, true, resetSlope23);                    }                    if (num10 >= y + 3 && num10 <= y + 4 && num11 >= x - 1 && num11 <= x + 5)                    {                        Main.tile[num11, num10].type = TileID.IceBlock;                        var resetSlope24 = true;                        SquareTileFrame(num11, num10, true, resetSlope24);                    }                }                num9++;            }            Main.tile[x + 9, y + num + 4 + num4].active(true);            Main.tile[x + 9, y + num + 4 + num4].type = TileID.Torches;            Main.tile[x + 9, y + num + 4 + num4].frameY = 198;            var resetSlope25 = true;            SquareTileFrame(x + 12, y + num + 4 + num4, true, resetSlope25);            for (var num12 = x - num3 - num * 4 + 2; num12 <= x + num * 4 + 2 + num3; num12++)            {                Main.tile[num12, y + 6].active(true);                Main.tile[num12, y + 6].type = TileID.IceBrick;                var resetSlope26 = true;                SquareTileFrame(num12, y + 6, true, resetSlope26);                Main.tile[num12, y + 7].active(true);                Main.tile[num12, y + 7].type = TileID.IceBrick;                var resetSlope27 = true;                SquareTileFrame(num12, y + 7, true, resetSlope27);                if ((num12 > x + num * 4 + 6 - num3 && num12 < x + num * 4 + 6) || (num12 > x - num * 4 - 2 && num12 < x - num * 4 + num3 - 2))                {                    Main.tile[num12, y + 10 + num4].active(true);                    Main.tile[num12, y + 10 + num4].type = TileID.IceBrick;                    var resetSlope28 = true;                    SquareTileFrame(num12, y + 10 + num4, true, resetSlope28);                    Main.tile[num12, y + 11 + num4].active(true);                    Main.tile[num12, y + 11 + num4].type = TileID.IceBrick;                    var resetSlope29 = true;                    SquareTileFrame(num12, y + 11 + num4, true, resetSlope29);                }                if ((num12 > x + num * 4 + 6 - 2 * num3 + 2 && num12 < x + num * 4 + 6 - num3 + 2) || (num12 > x - num * 4 + num3 - 4 && num12 < x - num * 4 + 2 * num3 - 4))                {                    Main.tile[num12, y + 11 + num4].active(true);                    Main.tile[num12, y + 11 + num4].type = TileID.IceBrick;                    Main.tile[num12, y + 11 + num4].liquid = 0;                    var resetSlope30 = true;                    SquareTileFrame(num12, y + 11 + num4, true, resetSlope30);                    Main.tile[num12, y + 12 + num4].active(true);                    Main.tile[num12, y + 12 + num4].type = TileID.IceBrick;                    var resetSlope31 = true;                    SquareTileFrame(num12, y + 12 + num4, true, resetSlope31);                }                if (num12 < x + num * 4 + 8 - 2 * num3 + 2 && num12 > x - num * 4 + 2 * num3 - 6)                {                    Main.tile[num12, y + 12 + num4].active(true);                    Main.tile[num12, y + 12 + num4].type = TileID.IceBrick;                    var resetSlope32 = true;                    SquareTileFrame(num12, y + 12 + num4, true, resetSlope32);                    Main.tile[num12, y + 13 + num4].wall = 0;                    Main.tile[num12, y + 13 + num4].active(true);                    Main.tile[num12, y + 13 + num4].type = TileID.IceBrick;                    var resetSlope33 = true;                    SquareTileFrame(num12, y + 13 + num4, true, resetSlope33);                }                if (num12 == x - num3 - num * 4 + 2 || num12 == x + num * 4 + 2 + num3)                {                    for (var num13 = 6; num13 <= 6 + num4; num13++)                    {                        Main.tile[num12, y + num + num13].wall = 0;                        Main.tile[num12, y + num + num13].active(true);                        Main.tile[num12, y + num + num13].type = TileID.IceBrick;                        Main.tile[num12, y + num + num13].halfBrick(false);                        Main.tile[num12, y + num + num13].slope(0);                        SquareTileFrame(num12, y + num + num13, true, false);                    }                }                if (num12 == x - num3 - num * 4 + 3 || num12 == x + num * 4 + 2 + num3 - 1)                {                    for (var num14 = 6; num14 <= 6 + num4 - 3; num14++)                    {                        Main.tile[num12, y + num + num14].wall = 0;                        Main.tile[num12, y + num + num14].active(true);                        Main.tile[num12, y + num + num14].type = TileID.IceBrick;                        Main.tile[num12, y + num + num14].halfBrick(false);                        Main.tile[num12, y + num + num14].slope(0);                        SquareTileFrame(num12, y + num + num14, true, false);                    }                }            }            var num15 = Main.rand.Next(5);            if (num15 == 0)            {                num15 = 4;            }            else if (num15 == 1)            {                num15 = 6;            }            else if (num15 == 2)            {                num15 = 11;            }            else if (num15 == 3)            {                num15 = 15;            }            else if (num15 == 4)            {                num15 = 35;            }            var num16 = Main.rand.Next(5);            if (num16 == 0)            {                num16 = 12;            }            else if (num16 == 1)            {                num16 = 10;            }            else if (num16 == 2)            {                num16 = 9;            }            else if (num16 == 3)            {                num16 = 27;            }            else if (num16 == 4)            {                num16 = 32;            }            var style = 27;            WorldGen.PlaceTile(x - 7, y + 9 + num4, TileID.Benches, false, false, -1, style);            var style2 = 27;            WorldGen.PlaceTile(x + 11, y + 9 + num4, TileID.Benches, false, false, -1, style2);            var style3 = 5;            WorldGen.PlaceTile(x + 1, y + 10 + num4, TileID.Lamps, false, false, -1, style3);            var style4 = 5;            WorldGen.PlaceTile(x + 3, y + 10 + num4, TileID.Lamps, false, false, -1, style4);            AddIceShrineChest(x, y + num + 4 + num4 - 2, 0, false, 1);            AddIceShrineChest(x + 5, y + num + 4 + num4 - 2, 0, false, 1);            var style5 = 54;            WorldGen.PlaceTile(x - 2, y + num + 4 + num4 - 3, TileID.Statues, false, false, -1, style5);            var style6 = 54;            WorldGen.PlaceTile(x + 7, y + num + 4 + num4 - 3, TileID.Statues, false, false, -1, style6);            WorldGen.Place6x4Wall(x + 8, y + 10, 242, num15);            WorldGen.Place6x4Wall(x - 5, y + 10, 242, num16);            WorldGen.PlaceDoor(x - num3 - num * 4 + 2, y + 6 + num4 + 1, 10, 30);            WorldGen.PlaceDoor(x + num3 + num * 4 + 2, y + 6 + num4 + 1, 10, 30);        }        public static void IceShrine(int x, int y)        {            var type = (byte) TileID.IceBrick;            var type2 = (byte) TileID.IceBlock;            var type3 = (byte) TileID.IceBlock;            Main.tile[x, y].active(true);            Main.tile[x + 2, y].active(true);            Main.tile[x + 4, y].active(true);            Main.tile[x + 18, y].active(true);            Main.tile[x + 20, y].active(true);            Main.tile[x + 22, y].active(true);            Main.tile[x, y].type = type;            Main.tile[x + 2, y].type = type;            Main.tile[x + 4, y].type = type;            Main.tile[x + 18, y].type = type;            Main.tile[x + 20, y].type = type;            Main.tile[x + 22, y].type = type;            for (var i = x; i <= x + 22; i++)            {                if ((i <= x + 4 || i >= x + 10) && (i <= x + 12 || i >= x + 18))                {                    Main.tile[i, y + 1].active(true);                    Main.tile[i, y + 1].type = type;                    Main.tile[i, y + 1].halfBrick(false);                    Main.tile[i, y + 1].slope(0);                }            }            for (var j = x; j <= x + 22; j++)            {                if (j == x + 2 || j == x + 20)                {                    Main.tile[j, y + 2].active(true);                    Main.tile[j, y + 2].type = type3;                }                if (j >= x && j <= x + 4 && j != x + 2)                {                    Main.tile[j, y + 2].active(true);                    Main.tile[j, y + 2].type = type;                }                if (j >= x + 9 && j <= x + 13)                {                    Main.tile[j, y + 2].active(true);                    Main.tile[j, y + 2].type = type;                }                if (j >= x + 18 && j <= x + 22 && j != x + 20)                {                    Main.tile[j, y + 2].active(true);                    Main.tile[j, y + 2].type = type;                }            }            for (var k = x + 1; k <= x + 21; k++)            {                if ((k >= x + 1 && k <= x + 3) || (k >= x + 19 && k <= x + 21))                {                    Main.tile[k, y + 3].active(true);                    Main.tile[k, y + 3].type = type;                }                if (k >= x + 10 && k <= x + 12)                {                    Main.tile[k, y + 3].active(true);                    Main.tile[k, y + 3].type = type3;                }            }            Main.tile[x + 8, y + 3].active(true);            Main.tile[x + 9, y + 3].active(true);            Main.tile[x + 13, y + 3].active(true);            Main.tile[x + 14, y + 3].active(true);            Main.tile[x + 8, y + 3].type = type;            Main.tile[x + 9, y + 3].type = type;            Main.tile[x + 13, y + 3].type = type;            Main.tile[x + 14, y + 3].type = type;            Main.tile[x + 2, y + 4].active(true);            Main.tile[x + 3, y + 4].active(true);            Main.tile[x + 19, y + 4].active(true);            Main.tile[x + 20, y + 4].active(true);            Main.tile[x + 2, y + 4].type = type;            Main.tile[x + 3, y + 4].type = type;            Main.tile[x + 19, y + 4].type = type;            Main.tile[x + 20, y + 4].type = type;            for (var l = x + 7; l <= x + 15; l++)            {                if (l >= x + 10 && l <= x + 12)                {                    Main.tile[l, y + 4].active(true);                    Main.tile[l, y + 4].type = type3;                }                if ((l >= x + 7 && l <= x + 9) || (l >= x + 13 && l <= x + 15))                {                    Main.tile[l, y + 4].active(true);                    Main.tile[l, y + 4].type = type;                }            }            for (var m = x + 2; m <= x + 20; m++)            {                Main.tile[m, y + 5].active(true);                Main.tile[m, y + 5].type = type;            }            for (var n = x + 2; n <= x + 20; n++)            {                for (var num = y + 6; num <= y + 14; num++)                {                    Main.tile[n, num].active(false);                    Main.tile[n, num].liquid = 0;                }            }            Main.tile[x + 2, y + 6].active(true);            Main.tile[x + 20, y + 6].active(true);            Main.tile[x + 2, y + 6].type = type;            Main.tile[x + 20, y + 6].type = type;            Main.tile[x + 2, y + 10].active(true);            Main.tile[x + 3, y + 10].active(true);            Main.tile[x + 4, y + 10].active(true);            Main.tile[x + 18, y + 10].active(true);            Main.tile[x + 19, y + 10].active(true);            Main.tile[x + 20, y + 10].active(true);            Main.tile[x + 2, y + 10].type = type;            Main.tile[x + 3, y + 10].type = type;            Main.tile[x + 4, y + 10].type = TileID.Platforms;            Main.tile[x + 18, y + 10].type = TileID.Platforms;            Main.tile[x + 4, y + 10].wall = WallID.ObsidianBrickUnsafe;            Main.tile[x + 18, y + 10].wall = WallID.ObsidianBrickUnsafe;            Main.tile[x + 19, y + 10].type = type;            Main.tile[x + 20, y + 10].type = type;            WorldGen.PlaceTile(x + 2, y + 7, TileID.ClosedDoor, false, false, -1, 0);            WorldGen.PlaceTile(x + 20, y + 7, TileID.ClosedDoor, false, false, -1, 0);            for (var num2 = x + 3; num2 <= x + 19; num2++)            {                if (num2 >= x + 3 && num2 <= x + 5)                {                    Main.tile[num2, y + 11].active(true);                    Main.tile[num2, y + 11].type = type;                }                if (num2 >= x + 17 && num2 <= x + 19)                {                    Main.tile[num2, y + 11].active(true);                    Main.tile[num2, y + 11].type = type;                }                if (num2 == x + 6 && num2 == x + 16)                {                    Main.tile[num2, y + 11].active(true);                    Main.tile[num2, y + 11].type = TileID.Platforms;                    Main.tile[num2, y + 11].wall = WallID.ObsidianBrickUnsafe;                }            }            for (var num3 = x + 5; num3 <= x + 17; num3++)            {                if (num3 == x + 5 || num3 == x + 6 || num3 == x + 16 || num3 == x + 17)                {                    Main.tile[num3, y + 12].active(true);                    Main.tile[num3, y + 12].type = type;                }                else                {                    Main.tile[num3, y + 12].wall = WallID.ObsidianBrickUnsafe;                }                if (num3 == x + 7 || num3 == x + 15)                {                    Main.tile[num3, y + 12].active(true);                    Main.tile[num3, y + 12].type = TileID.Platforms;                    Main.tile[num3, y + 12].wall = WallID.ObsidianBrickUnsafe;                }            }            for (var num4 = x + 6; num4 <= x + 16; num4++)            {                if ((num4 >= x + 6 && num4 <= x + 8) || (num4 >= x + 14 && num4 <= x + 16))                {                    Main.tile[num4, y + 13].active(true);                    Main.tile[num4, y + 13].type = type;                }                else                {                    Main.tile[num4, y + 13].wall = WallID.ObsidianBrickUnsafe;                }            }            for (var num5 = x + 8; num5 <= x + 14; num5++)            {                Main.tile[num5, y + 14].active(true);                Main.tile[num5, y + 14].type = type;                Main.tile[num5, y + 9].active(true);                Main.tile[num5, y + 9].type = TileID.Platforms;            }            Main.tile[x + 7, y + 9].active(true);            Main.tile[x + 7, y + 9].type = type2;            Main.tile[x + 15, y + 9].active(true);            Main.tile[x + 15, y + 9].type = type2;            for (var num6 = x + 3; num6 <= x + 19; num6++)            {                for (var num7 = y + 6; num7 <= y + 9; num7++)                {                    Main.tile[num6, num7].wall = WallID.ObsidianBrickUnsafe;                }            }            for (var num8 = x + 6; num8 <= x + 16; num8++)            {                for (var num9 = y + 10; num9 <= y + 12; num9++)                {                    Main.tile[num8, num9].wall = WallID.ObsidianBrickUnsafe;                }            }            Main.tile[x + 5, y + 10].wall = WallID.ObsidianBrickUnsafe;            Main.tile[x + 17, y + 10].wall = WallID.ObsidianBrickUnsafe;            AddIceShrineChest(x + 10, y + 13, 0, false, 1);            AddIceShrineChest(x + 13, y + 13, 0, false, 1);            Main.tile[x + 6, y + 12].wall = 0;            Main.tile[x + 16, y + 12].wall = 0;            for (var num10 = x + 2; num10 <= x + 4; num10++)            {                for (var num11 = y + 12; num11 <= y + 14; num11++)                {                    if (Main.tile[num10, num11].type > 0)                    {                        Main.tile[num10, num11].active(true);                    }                }            }            for (var num12 = x + 18; num12 <= x + 20; num12++)            {                for (var num13 = y + 12; num13 <= y + 14; num13++)                {                    if (Main.tile[num12, num13].type > 0)                    {                        Main.tile[num12, num13].active(true);                    }                }            }            for (var num14 = x + 5; num14 <= x + 7; num14++)            {                for (var num15 = y + 13; num15 <= y + 14; num15++)                {                    if (Main.tile[num14, num15].type > 0)                    {                        Main.tile[num14, num15].active(true);                    }                }            }            for (var num16 = x + 15; num16 <= x + 17; num16++)            {                for (var num17 = y + 13; num17 <= y + 14; num17++)                {                    if (Main.tile[num16, num17].type > 0)                    {                        Main.tile[num16, num17].active(true);                    }                }            }            for (var num18 = x; num18 <= x + 22; num18++)            {                for (var num19 = y; num19 <= y + 14; num19++)                {                    Main.tile[num18, num19].slope(0);                    Main.tile[num18, num19].halfBrick(false);                }            }            if (Main.tile[x + 2, y + 10].type > 0)            {                Main.tile[x + 2, y + 10].active(true);            }            if (Main.tile[x + 20, y + 10].type > 0)            {                Main.tile[x + 20, y + 10].active(true);            }            SquareTileFrameArea(x, y, 40);        }        public static bool AddIceShrineChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)        {            var k = j;            while (k < Main.maxTilesY)            {                if (Main.tile[i, k].active() && Main.tileSolid[Main.tile[i, k].type])                {                    var num = k;                    var num2 = WorldGen.PlaceChest(i - 1, num - 1, 21, notNearOtherChests, 11);                    if (num2 >= 0)                    {                        for (var num3 = 0; num3 == 0; num3++)                        {                            var num4 = WorldGen.genRand.Next(19);                            if (num4 >= 0 && num4 <= 6)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.BlizzardinaBottle, false);                                Main.chest[num2].item[0].Prefix(-1);                            }                            else if (num4 >= 7 && num4 <= 13)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.PoisonedKnife, false);                                Main.chest[num2].item[0].stack = WorldGen.genRand.Next(34, 79);                            }                            else if (num4 >= 14 && num4 <= 16)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.IceSickle, false);                                Main.chest[num2].item[0].stack = WorldGen.genRand.Next(34, 79);                            }                            else if (num4 == 17)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.IceBlade, false);                                Main.chest[num2].item[0].Prefix(-2);                            }                            else if (num4 == 18)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.IceSkates, false);                                Main.chest[num2].item[0].Prefix(-2);                            }                            Main.chest[num2].item[1].SetDefaults(ItemID.GoldCoin, false);                            Main.chest[num2].item[1].stack = WorldGen.genRand.Next(60, 82);                            var num5 = WorldGen.genRand.Next(5);                            if (num5 == 0)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.LesserRestorationPotion, false);                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(3, 7);                            }                            if (num5 == 1)                            {                                Main.chest[num2].item[2].SetDefaults(theBeak, false);                                Main.chest[num2].item[2].stack = 1;                            }                            if (num5 == 2)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.SlushBlock, false);                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(200, 451);                            }                            if (num5 == 3)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.IceBrick, false);                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(30, 73);                            }                            if (num5 == 4)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.HandWarmer, false);                                Main.chest[num2].item[2].Prefix(-2);                            }                        }                        return true;                    }                    return false;                }                else                {                    k++;                }            }            return false;        }        public static void SquareTileFrame(int i, int j, bool resetFrame = true, bool resetSlope = false)        {            if (resetSlope)            {                Main.tile[i, j].slope(0);                Main.tile[i, j].halfBrick(false);            }            WorldGen.TileFrame(i - 1, j - 1, false, false);            WorldGen.TileFrame(i - 1, j, false, false);            WorldGen.TileFrame(i - 1, j + 1, false, false);            WorldGen.TileFrame(i, j - 1, false, false);            WorldGen.TileFrame(i, j, resetFrame, false);            WorldGen.TileFrame(i, j + 1, false, false);            WorldGen.TileFrame(i + 1, j - 1, false, false);            WorldGen.TileFrame(i + 1, j, false, false);            WorldGen.TileFrame(i + 1, j + 1, false, false);        }        public static void SquareTileFrameArea(int x, int y, int r)        {            for (var i = x - r; i < x + r; i++)            {                for (var j = y - r; j < y + r; j++)                {                    SquareTileFrame(i, j, true, false);                }            }        }        public static void AvalonSpreadGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true, byte color = 0)        {            try            {                if (WorldGen.InWorld(i, j, 1))                {                    if ((int)Main.tile[i, j].type == dirt && Main.tile[i, j].active() && ((double)j < Main.worldSurface || dirt != 0))                    {                        int num = i - 1;                        int num2 = i + 2;                        int num3 = j - 1;                        int num4 = j + 2;                        if (num < 0)                        {                            num = 0;                        }                        if (num2 > Main.maxTilesX)                        {                            num2 = Main.maxTilesX;                        }                        if (num3 < 0)                        {                            num3 = 0;                        }                        if (num4 > Main.maxTilesY)                        {                            num4 = Main.maxTilesY;                        }                        bool flag = true;                        for (int k = num; k < num2; k++)                        {                            for (int l = num3; l < num4; l++)                            {                                if (!Main.tile[k, l].active() || !Main.tileSolid[(int)Main.tile[k, l].type])                                {                                    flag = false;                                }                                if (Main.tile[k, l].lava() && Main.tile[k, l].liquid > 0)                                {                                    flag = true;                                    break;                                }                            }                        }                        if (!flag && TileID.Sets.CanBeClearedDuringGeneration[(int)Main.tile[i, j].type])                        {                            if (grass != 23 || Main.tile[i, j - 1].type != 27)                            {                                if (grass != 199 || Main.tile[i, j - 1].type != 27)                                {                                    Main.tile[i, j].type = (ushort)grass;                                    Main.tile[i, j].color(color);                                    for (int m = num; m < num2; m++)                                    {                                        for (int n = num3; n < num4; n++)                                        {                                            if (Main.tile[m, n].active() && (int)Main.tile[m, n].type == dirt)                                            {                                                try                                                {                                                    if (repeat && grassSpread < 1000)                                                    {                                                        grassSpread++;                                                        AvalonSpreadGrass(m, n, dirt, grass, true, 0);                                                        grassSpread--;                                                    }                                                }                                                catch                                                {                                                }                                            }                                        }                                    }                                }                            }                        }                    }                }            }            catch            {            }        }        private static int tileCheck(int positionX)        {            for (int i = (int)(WorldGen.worldSurfaceLow - 30); i < Main.maxTilesY; i++)            {                Tile tile = Framing.GetTileSafely(positionX, i);                if ((tile.type == TileID.Dirt || tile.type == TileID.Stone || tile.type == TileID.Sand || tile.type == ModContent.TileType<Snotsand>() || tile.type == TileID.Mud || tile.type == TileID.SnowBlock || tile.type == TileID.IceBlock) && tile.active())                {                    return i;                }            }            return 0;        }        public void ContagionRunner(int i, int j)		{            int j2 = j;            int num = WorldGen.genRand.Next(100, 151);            j = tileCheck(i) + num + 30;			Vector2 vector = new Vector2((float)i, (float)j);			List<Vector2> list = new List<Vector2>();			List<Vector2> list2 = new List<Vector2>();			List<double> list3 = new List<double>();			new List<Vector2>();			for (int k = i - num; k <= i + num; k++)			{				for (int l = j - num; l <= j + num; l++)				{					float num2 = Vector2.Distance(new Vector2((float)k, (float)l), new Vector2((float)i, (float)j));					if (num2 <= (float)num && num2 >= (float)(num - 29))					{						Main.tile[k, l].active(false);					}					if (((num2 <= num && num2 >= num - 7) || (num2 <= (float)(num - 22) && num2 >= (float)(num - 29))) && Main.tile[k, l].type != TileID.ShadowOrbs)					{						Main.tile[k, l].active(true);						Main.tile[k, l].halfBrick(false);						Main.tile[k, l].slope(0);						Main.tile[k, l].type = (ushort) ModContent.TileType<Chunkstone>();					}					if (num2 <= num - 6 && num2 >= num - 23)					{						Main.tile[k, l].wall = (ushort) ModContent.WallType<Walls.ChunkstoneWall>();					}				}			}			int num3 = num - 20;			for (int m = 0; m < 6; m++)			{				double num4 = (double)(WorldGen.genRand.Next(0, 62831852) / 10000000);				Vector2 item = new Vector2(vector.X + (float)((int)Math.Round((double)num3 * Math.Cos(num4))), vector.Y + (float)((int)Math.Round((double)num3 * Math.Sin(num4))));				Vector2 item2 = vector;				if (item.X > vector.X)				{					if (item.X > vector.X + (float)(num / 2))					{						if (item.Y > vector.Y)						{							if (item.Y > vector.Y + (float)(num / 2))							{								item2 = new Vector2(item.X - 50f, item.Y - 50f);							}							else							{								item2 = new Vector2(item.X - 50f, item.Y - 25f);							}						}						else if (item.Y < vector.Y - (float)(num / 2))						{							item2 = new Vector2(item.X - 50f, item.Y + 50f);						}						else						{							item2 = new Vector2(item.X - 50f, item.Y + 25f);						}					}					else if (item.Y > vector.Y)					{						if (item.Y > vector.Y + (float)(num / 2))						{							item2 = new Vector2(item.X - 25f, item.Y - 50f);						}						else						{							item2 = new Vector2(item.X - 25f, item.Y - 25f);						}					}					else if (item.Y < vector.Y - (float)(num / 2))					{						item2 = new Vector2(item.X - 25f, item.Y + 50f);					}					else					{						item2 = new Vector2(item.X - 25f, item.Y + 25f);					}				}				else if (item.X < vector.X - (float)(num / 2))				{					if (item.Y > vector.Y)					{						if (item.Y > vector.Y + (float)(num / 2))						{							item2 = new Vector2(item.X + 50f, item.Y - 50f);						}						else						{							item2 = new Vector2(item.X + 50f, item.Y - 25f);						}					}					else if (item.Y < vector.Y - (float)(num / 2))					{						item2 = new Vector2(item.X + 50f, item.Y + 50f);					}					else					{						item2 = new Vector2(item.X + 50f, item.Y + 25f);					}				}				else if (item.Y > vector.Y)				{					if (item.Y > vector.Y + (float)(num / 2))					{						item2 = new Vector2(item.X + 25f, item.Y - 50f);					}					else					{						item2 = new Vector2(item.X + 25f, item.Y - 25f);					}				}				else if (item.Y < vector.Y - (float)(num / 2))				{					item2 = new Vector2(item.X + 25f, item.Y + 50f);				}				else				{					item2 = new Vector2(item.X + 25f, item.Y + 25f);				}				list.Add(item);				list2.Add(item2);				list3.Add(num4);			}			for (int n = 0; n < 6; n++)			{			    BoreTunnel2((int)list[n].X, (int)list[n].Y, (int)list2[n].X, (int)list2[n].Y, 9f, (ushort)ModContent.TileType<Chunkstone>());				BoreTunnel2((int)list[n].X, (int)list[n].Y, (int)list2[n].X, (int)list2[n].Y, 4f, 65535);				MakeCircle((int)list2[n].X, (int)list2[n].Y, 11f, (ushort)ModContent.TileType<Chunkstone>());				MakeCircle((int)list2[n].X, (int)list2[n].Y, 6f, 65535);			}			for (int num5 = i - num; num5 <= i + num; num5++)			{				for (int num6 = j - num; num6 <= j + num; num6++)				{					float num7 = Vector2.Distance(new Vector2((float)num5, (float)num6), new Vector2((float)i, (float)j));					if (num7 < (float)(num - 7) && num7 > (float)(num - 22))					{						Main.tile[num5, num6].active(false);					}				}			}			int num8 = num - 7;			for (int num9 = 0; num9 < 20; num9++)			{				double d = (double)(WorldGen.genRand.Next(0, 62831852) / 10000000);				Vector2 vector2 = new Vector2(vector.X + (float)((int)Math.Round((double)num8 * Math.Cos(d))), vector.Y + (float)((int)Math.Round((double)num8 * Math.Sin(d))));				MakeCircle((int)vector2.X, (int)vector2.Y, 4f, (ushort) ModContent.TileType<Chunkstone>());			}			for (int num10 = 0; num10 < 6; num10++)			{				WorldGen.AddShadowOrb((int)list2[num10].X, (int)list2[num10].Y);			}            BoreTunnel2(i, j - num - 30, i, j - num + 7, 10, ushort.MaxValue);            for (int x = i - 17; x < i + 17; x++)            {                for (int y = j - num - 30; y < j - num + 8; y++)                {                    if (x >= i + 12 || x <= i - 12)                    {                        Main.tile[x, y].active(true);                        Main.tile[x, y].halfBrick(false);                        Main.tile[x, y].slope(0);                        Main.tile[x, y].type = (ushort)ModContent.TileType<Chunkstone>();                    }                    if (x <= i + 12 && x >= i - 12)                    {                        Main.tile[x, y].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();                        Main.tile[x, y].active(false);                    }                }            }            for (int x = i - 17; x < i + 17; x++)            {                for (int y = j - num - 30; y < j - num + 8; y++)                {                    if (x == i + 12 || x == i - 12)                    {                        int rn = WorldGen.genRand.Next(13, 17);                        if (y % rn == 0)                        {                            MakeCircle(x, y, 3, (ushort)ModContent.TileType<Chunkstone>());                        }                    }                }            }        }        public void BoreTunnel2(int x0, int y0, int x1, int y1, float r, ushort type)        {            bool flag = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);            if (flag)            {                Swap<int>(ref x0, ref y0);                Swap<int>(ref x1, ref y1);            }            if (x0 > x1)            {                Swap<int>(ref x0, ref x1);                Swap<int>(ref y0, ref y1);            }            int num = x1 - x0;            int num2 = Math.Abs(y1 - y0);            int num3 = num / 2;            int num4 = (y0 < y1) ? 1 : -1;            int num5 = y0;            for (int i = x0; i <= x1; i++)            {                if (flag)                {                    MakeCircle(num5, i, r, type);                }                else                {                    MakeCircle(i, num5, r, type);                }                num3 -= num2;                if (num3 < 0)                {                    num5 += num4;                    num3 += num;                }            }        }                public void MakeCircle(int x, int y, float r, ushort type)        {            int num = (int)((float)x - r);            int num2 = (int)((float)y - r);            int num3 = (int)((float)x + r);            int num4 = (int)((float)y + r);            for (int i = num; i < num3 + 1; i++)            {                for (int j = num2; j < num4 + 1; j++)                {                    if (Vector2.Distance(new Vector2((float)i, (float)j), new Vector2((float)x, (float)y)) <= r && Main.tile[i, j].type != TileID.ShadowOrbs)                    {                        if (type == 65535)                        {                            Main.tile[i, j].active(false);                        }                        else                        {                            Main.tile[i, j].active(true);                            Main.tile[i, j].type = type;                            Main.tile[i, j].wall = (ushort) ModContent.WallType<Walls.ChunkstoneWall>();                            WorldGen.SquareTileFrame(i, j, true);                        }                    }                }            }        }        private static void Swap<T>(ref T lhs, ref T rhs)        {            T t = lhs;            lhs = rhs;            rhs = t;        }        // IL modification of hardmode world updates        public static void HookHardUpdateWorld(ILContext il)
        {
            var c = new ILCursor(il);

            // --- CONTAGION SPREAD HARDMODE ---

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdsfld<NPC>(nameof(NPC.downedPlantBoss))))
                return;
            if (!c.TryGotoNext(MoveType.After, i => i.MatchRet()))
                return;

            // Automatically shift cursor after each emit
            c.MoveAfterLabels();

            // Load local variables to stack
            c.Emit(OpCodes.Ldloc_0);
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);

            // Emit custom logic
            c.EmitDelegate<Action<int, int, int>>((type, i, j) =>
            {
                if (type == ModContent.TileType<Tiles.Chunkstone>() || type == ModContent.TileType<Ickgrass>() || type == ModContent.TileType<Snotsand>() || type == ModContent.TileType<HardenedSnotsand>() || type == ModContent.TileType<Snotsandstone>() || type == ModContent.TileType<YellowIce>())
                {
                    bool flag5 = true;
                    while (flag5)
                    {
                        flag5 = false;
                        int num6 = i + WorldGen.genRand.Next(-3, 4);
                        int num7 = j + WorldGen.genRand.Next(-3, 4);
                        //bool flag6 = NearbyChlorophyte(num6, num7);
                        if (Main.tile[num6, num7 - 1].type == 27)
                        {
                            continue;
                        }
                        if (Main.tile[num6, num7].type == 2)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Ickgrass>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 1 || Main.tileMoss[Main.tile[num6, num7].type])
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Chunkstone>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 53)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Snotsand>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 396)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<Snotsandstone>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 397)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<HardenedSnotsand>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                        else if (Main.tile[num6, num7].type == 161)
                        {
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                flag5 = true;
                            }
                            Main.tile[num6, num7].type = (ushort)ModContent.TileType<YellowIce>();
                            WorldGen.SquareTileFrame(num6, num7);
                            NetMessage.SendTileSquare(-1, num6, num7, 1);
                        }
                    }
                }
            });
            // --- END OF CONTAGION SPREAD HARDMODE ---
        }    }}