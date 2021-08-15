﻿using System;using System.Collections.Generic;using ExxoAvalonOrigins.Items;using ExxoAvalonOrigins.Tiles;using Microsoft.Xna.Framework;using Terraria;using Terraria.GameContent.Generation;using Terraria.ID;using Terraria.ModLoader;using Terraria.World.Generation;using Terraria.Localization;using Terraria.ModLoader.IO;using CaesiumOre = ExxoAvalonOrigins.Tiles.CaesiumOre;using Heartstone = ExxoAvalonOrigins.Tiles.Heartstone;using HydrolythOre = ExxoAvalonOrigins.Tiles.HydrolythOre;using IckyAltar = ExxoAvalonOrigins.Tiles.IckyAltar;using OsmiumOre = ExxoAvalonOrigins.Tiles.OsmiumOre;using Peridot = ExxoAvalonOrigins.Tiles.Peridot;using RhodiumOre = ExxoAvalonOrigins.Tiles.RhodiumOre;using Tourmaline = ExxoAvalonOrigins.Tiles.Tourmaline;using Zircon = ExxoAvalonOrigins.Tiles.Zircon;using System.Threading;
using Terraria.Utilities;
using System.IO;
using System.Reflection;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using Terraria.GameContent.Biomes;
using System.Linq;

namespace ExxoAvalonOrigins{    class ExxoAvalonOriginsWorld : ModWorld    {        public static GenPass corruptionPass;        public static GenPass junglePass;        public static GenPass altarPass;        public static byte blbTimer;        public static bool rhodium;        public static int rhodiumBar;        public static int shmOreTier1 = -1;        public static int shmOreTier2 = -1;        public static int hallowAltarCount;        public static bool contaigon = false;        public static int totalDark2;        public static int nilShrineCount;        public static int hallowedAltarCount;        public static bool stopCometDrops = false;        public static Vector2 hiddenTemplePos;        public static bool retroGenned = false;        public static int theBeak;        public static bool jungleLocationKnown = false;        public static bool generatingBaccilite = false;        public static int dungeonSide = 0;        public static int jungleX = 0;        public static int grassSpread = 0;        public static bool contaigonSet = false;        public static int hellcastleTiles = 0;        public static int ickyTiles = 0;        public static int darkTiles = 0;        public static Vector2 LoK = Vector2.Zero;
        public static int wosT;
        public static int wosB;
        public static int wosF = 0;
        public static int wos = -1;
        public static bool mudWall = false;
        public static bool downedBacteriumPrime = false;
        public static bool downedDesertBeak = false;
        public static bool downedPhantasm = false;        public static bool downedDragonLord = false;        public static bool downedMechasting = false;        public static bool downedOblivion = false;        public enum JungleVariant
        {
            jungle,
            tropics,
            random
        }        public enum OsmiumVariant
        {
            rhodium,
            osmium,
            iridium,
            random
        }        public static JungleVariant jungleMenuSelection;        public static OsmiumVariant osmiumMenuSelection;        public override void ChooseWaterStyle(ref int style)
        {
            if (Main.LocalPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().zoneBooger)
                style = ModContent.GetInstance<Waters.ContagionWaterStyle>().Type;
        }        public override void TileCountsAvailable(int[] tileCounts)
        {
            Main.jungleTiles += tileCounts[ModContent.TileType<GreenIce>()];
            ickyTiles = tileCounts[ModContent.TileType<Chunkstone>()] + tileCounts[ModContent.TileType<HardenedSnotsand>()] + tileCounts[ModContent.TileType<Snotsandstone>()] + tileCounts[ModContent.TileType<Ickgrass>()] + tileCounts[ModContent.TileType<Snotsand>()] + tileCounts[ModContent.TileType<YellowIce>()];
            hellcastleTiles = tileCounts[ModContent.TileType<Tiles.ImperviousBrick>()];
            darkTiles = tileCounts[ModContent.TileType<Tiles.DarkMatter>()] + tileCounts[ModContent.TileType<Tiles.DarkMatterSand>()] + tileCounts[ModContent.TileType<Tiles.BlackIce>()] + tileCounts[ModContent.TileType<Tiles.DarkMatterSoil>()] + tileCounts[ModContent.TileType<Tiles.HardenedDarkSand>()] + tileCounts[ModContent.TileType<Tiles.Darksandstone>()] + tileCounts[ModContent.TileType<Tiles.DarkMatterGrass>()];
            Main.sandTiles += tileCounts[ModContent.TileType<Snotsand>()];
        }
        
        public void RetroGen()        {            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 1, 0, 0))            {
                //Rhodium/Osmium
                rhodium = WorldGen.genRand.Next(2) == 0;                rhodiumBar = rhodium ? ModContent.TileType<RhodiumOre>() : ModContent.TileType<OsmiumOre>();                for (var num156 = 0; num156 < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); num156++)                {                    var i10 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);                    var rockLayer3 = Main.rockLayer;                    var j10 = WorldGen.genRand.Next((int)rockLayer3, Main.maxTilesY - 150);                    WorldGen.OreRunner(i10, j10, WorldGen.genRand.Next(4, 5), WorldGen.genRand.Next(5, 7), (ushort)rhodiumBar);                }                Main.NewText("Retrogenned Rhodium/Osmium");
                //Caesium
                for (var num179 = 0; num179 < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0008); num179++)                {                    WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), (ushort)ModContent.TileType<CaesiumOre>());                    //WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), ModContent.TileType<CaesiumOre>(), false, 0f, 0f, false, true);                }                Main.NewText("Retrogenned Caesium");            }            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 1, 1, 0))            {                for (var num284 = 69; num284 < 72; num284++)                {                    var type8 = 0;                    float num285 = 0;                    if (num284 == 69)                    {                        type8 = ModContent.TileType<Tourmaline>();                        num285 = Main.maxTilesX * 0.2f;                    }                    else if (num284 == 70)                    {                        type8 = ModContent.TileType<Peridot>();                        num285 = Main.maxTilesX * 0.2f;                    }                    else if (num284 == 71)                    {                        type8 = ModContent.TileType<Zircon>();                        num285 = Main.maxTilesX * 0.2f;                    }                    num285 *= 0.2f;                    var num286 = 0;                    while (num286 < num285)                    {                        var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                        var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                        while (Main.tile[num287, num288].type != 1)                        {                            num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                            num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                        }                        WorldGen.TileRunner(num287, num288, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type8, false, 0f, 0f, false, true);                        num286++;                    }                }                Main.NewText("Retrogenned Tourmaline, Peridot and Zircon");            }            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 3, 0, 0))            {                for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)                {                    var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);                    var rockLayer = Main.rockLayer;                    var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);                    GenerateHearts(i8, j8, ModContent.TileType<Heartstone>());                }                Main.NewText("Retrogenned Heartstone");            }            if (ExxoAvalonOrigins.lastOpenedVersion < new Version(0, 3, 0, 0))            {                for (var num721 = 0; num721 < 3; num721++)                {                    var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);                    var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);                    IceShrine(x10, y6);                }                Main.NewText("Retrogenned Ice Shrines");            }        }        public static void RemoveLavaAndHellHousesFromHellcastleArea(int x, int y)
        {
            // turn liquid in an area around the gen area to 0, and make it not lava
            for (int noLiquidX = x - 45; noLiquidX <= x + 444 + 45; noLiquidX++)
            {
                for (int noLiquidY = y - 30; noLiquidY <= y + 100; noLiquidY++)
                {
                    if (Main.tile[noLiquidX, noLiquidY] == null) Main.tile[noLiquidX, noLiquidY] = new Tile();
                    Main.tile[noLiquidX, noLiquidY].liquid = 0;
                    Main.tile[noLiquidX, noLiquidY].lava(false);
                    if (Main.tile[noLiquidX, noLiquidY].type == TileID.LargePiles || Main.tile[noLiquidX, noLiquidY].type == TileID.LargePiles2 ||
                        Main.tile[noLiquidX, noLiquidY].type == TileID.SmallPiles)
                    {
                        Main.tile[noLiquidX, noLiquidY].active(false);
                    }
                }
            }
            for (int noHellHousesX = x; noHellHousesX <= x + 420; noHellHousesX++)
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
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Bookcases || Main.tile[noHellHousesX, noHellHousesY].type == 89 ||
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Candelabras || Main.tile[noHellHousesX, noHellHousesY].type == TileID.Candles)
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
        }        public static void GenerateHellcastle(int x, int y)
        {
            int[,] _structure = GetStructure("ExxoAvalonOrigins.Structures.HellCastle.txt");

            int PosX = x;  //spawnX and spawnY is where you want the anchor to be when this generates
            int PosY = y;
            ushort impBrick = (ushort)ModContent.TileType<Tiles.ImperviousBrick>();
            ushort spike = (ushort)ModContent.TileType<Tiles.VenomSpike>();
            ushort wallSafe = (ushort)ModContent.WallType<Walls.ImperviousBrickWall>();
            RemoveLavaAndHellHousesFromHellcastleArea(x, y);
            //i = vertical, j = horizontal
            for (int confirmPlatforms = 0; confirmPlatforms < 2; confirmPlatforms++)    //Increase the iterations on this outermost for loop if tabletop-objects are not properly spawning
            {
                for (int i = 0; i < _structure.GetLength(0); i++)
                {
                    for (int j = _structure.GetLength(1) - 1; j >= 0; j--)
                    {
                        int k = PosX + j;
                        int l = PosY + i;
                        if (WorldGen.InWorld(k, l, 30))
                        {
                            Tile tile = Framing.GetTileSafely(k, l);
                            switch (_structure[i, j])
                            {
                                case 0:
                                    tile.active(true);
                                    tile.type = impBrick;
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    break;
                                case 1:
                                    if (confirmPlatforms == 0)
                                    {
                                        tile.active(false);
                                        tile.halfBrick(false);
                                        tile.slope(0);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 2:
                                    tile.active(true);
                                    tile.type = spike;
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 3:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, TileID.Banners, true, true, -1, 20);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 4:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, TileID.Books, true, true, -1, 2);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    break;
                                case 5:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, TileID.Books, true, true, -1, 4);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 6:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, TileID.Books, true, true, -1, 1);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 7:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, TileID.Books, true, true, -1, 0);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 8:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.ResistantWoodPlatform>());
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 9:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.ImperviousBookcase>(), true, true, -1, 0);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 10:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, TileID.Books, true, true, -1, 3);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 11:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.LockedImperviousDoor>(), true, true, -1, 0);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 12:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, TileID.Statues, true, true, -1, 49);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 13:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        int item = WorldGen.genRand.Next(9);
                                        if (item == 0)
                                        {
                                            item = ModContent.ItemType<Items.Boomlash>();
                                        }
                                        if (item == 1)
                                        {
                                            item = ModContent.ItemType<Items.EctoplasmicBeacon>();
                                        }
                                        if (item == 2 || item == 3 || item == 4)
                                        {
                                            item = ItemID.PlatinumCoin;
                                        }
                                        if (item == 5)
                                        {
                                            item = ModContent.ItemType<Items.CaesiumBar>();
                                        }
                                        if (item == 6)
                                        {
                                            item = ModContent.ItemType<Items.SolariumStar>();
                                        }
                                        if (item == 7)
                                        {
                                            item = ModContent.ItemType<Items.EarthStone>();
                                        }
                                        if (item == 8)
                                        {
                                            item = ModContent.ItemType<Items.Hellrazer>();
                                        }
                                        AddHellcastleChest(k, l, contain: item);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 14:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodSofa>()); // sofas
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 15:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodWorkBench>()); // workbenches
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 16:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.ResistantWoodPlatform>());
                                    tile.slope(2);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 17:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodClock>()); // clocks
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 18:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodDresser>()); // dressers
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 19:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodChair>()); // chairs
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 20:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodTable>()); // tables
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 21:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodPiano>()); // pianos
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 22:
                                    if (confirmPlatforms == 0)
                                        tile.active(false);
                                    WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.ResistantWoodPlatform>());
                                    tile.slope(1);
                                    tile.halfBrick(false);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 23:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodBed>()); // beds
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 24:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, (ushort)ModContent.TileType<Tiles.ResistantWoodBathtub>());
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 25:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, TileID.Sinks, true, true, -1, 13);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 26:
                                    tile.active(true);
                                    tile.type = impBrick;
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    break;
                                case 27:
                                    if (confirmPlatforms == 1)
                                    {
                                        tile.active(false);
                                        tile.slope(0);
                                        tile.halfBrick(false);
                                        WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.LibraryAltar>(), true, true, -1, 0);
                                        tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    }
                                    break;
                                case 28:
                                    tile.active(false);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.Paintings>(), true, true, -1, 1);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 29:
                                    tile.active(false);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.Paintings>(), true, true, -1, 5);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 30:
                                    tile.active(false);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.Paintings>(), true, true, -1, 2);
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                                case 31:
                                    tile.active(false);
                                    tile.slope(0);
                                    tile.halfBrick(false);
                                    WorldGen.PlaceTile(k, l, ModContent.TileType<Tiles.DevilsScythe>());
                                    tile.wall = (ushort)ModContent.WallType<Walls.ImperviousBrickWallUnsafe>();
                                    break;
                            }
                        }
                    }
                }
            }
            for (int q = x + 420; q <= x + 444; q++)
            {
                for (int z = y; z <= y + 21; z++)
                {
                    Tile t = Framing.GetTileSafely(q, z);
                    t.wall = 0;
                }
            }
            MakeWallRectangle(x + 192 + 234, y + 8, 2, 9, wallSafe);
            MakeWallRectangle(x + 196 + 234, y + 8, 2, 9, wallSafe);
            MakeWallRectangle(x + 200 + 234, y + 8, 2, 9, wallSafe);
        }        public static void SmashHallowAltar(int i, int j)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                return;
            }
            if (!ExxoAvalonOrigins.superHardmode && !Main.hardMode)
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
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    if (shmOreTier1 == ModContent.TileType<Tiles.TritanoriumOre>()) Main.NewText("Your world has been invigorated with Tritanorium!", 117, 158, 107, false);
                    else Main.NewText("Your world has been melted with Pyroscoric!", 187, 35, 0, false);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    if (shmOreTier1 == ModContent.TileType<Tiles.TritanoriumOre>()) NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been invigorated with Tritanorium!"), new Color(117, 158, 107));
                    else NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been melted with Pyroscoric!"), new Color(187, 35, 0));
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
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    if (shmOreTier2 == ModContent.TileType<Tiles.UnvolanditeOre>()) Main.NewText("Your world has been blessed with Unvolandite!", 171, 119, 75, false);
                    else Main.NewText("Your world has been blessed with Vorazylcum!", 123, 95, 126, false);
                }
                else if (Main.netMode == NetmodeID.Server)
                {
                    if (shmOreTier2 == ModContent.TileType<Tiles.UnvolanditeOre>())
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Unvolandite!"), new Color(171, 119, 75));
                    }
                    else
                    {
                        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with Vorazylcum!"), new Color(123, 95, 126));
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
        }        public static void CheckLargeHerb(int x, int y, int type)
        {
            if (WorldGen.destroyObject)
            {
                return;
            }
            Tile t = Main.tile[x, y];
            int style = (int)(t.frameX / 18);
            bool destroy = false;
            int fixedY = y;
            int yframe = (int)Main.tile[x, y].frameY;
            fixedY -= yframe / 18;
            if (!WorldGen.SolidTile2(x, fixedY + 3) || !Main.tile[x, fixedY].active() ||
                !Main.tile[x, fixedY + 1].active() || !Main.tile[x, fixedY + 2].active())
            {
                destroy = true;
            }
            if (destroy)
            {
                WorldGen.destroyObject = true;
                for (int u = fixedY; u < fixedY + 3; u++)
                {
                    WorldGen.KillTile(x, u, false, false, false);
                }
                if (type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>() || type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>() ||
                    type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>()) // 469 through 471 are the immature tiles of the large herb; 472 is the mature version
                {
                    int item = 0;
                    switch (style)
                    {
                        case 0:
                            item = ModContent.ItemType<Items.LargeDaybloomSeed>();
                            break;
                        case 1:
                            item = ModContent.ItemType<Items.LargeMoonglowSeed>();
                            break;
                        case 2:
                            item = ModContent.ItemType<Items.LargeBlinkrootSeed>();
                            break;
                        case 3:
                            item = ModContent.ItemType<Items.LargeDeathweedSeed>();
                            break;
                        case 4:
                            item = ModContent.ItemType<Items.LargeWaterleafSeed>();
                            break;
                        case 5:
                            item = ModContent.ItemType<Items.LargeFireblossomSeed>();
                            break;
                        case 6:
                            item = ModContent.ItemType<Items.LargeShiverthornSeed>();
                            break;
                        case 7:
                            item = ModContent.ItemType<Items.LargeBloodberrySeed>();
                            break;
                        case 8:
                            item = ModContent.ItemType<Items.LargeSweetstemSeed>();
                            break;
                        case 9:
                            item = ModContent.ItemType<Items.LargeBarfbushSeed>();
                            break;
                    }// 3710 through 3719 are the seeds
                    if (item > 0) Item.NewItem(x * 16, fixedY * 16, 16, 48, item);
                }
                else
                {
                    int item = 0;
                    switch (style)
                    {
                        case 0:
                            item = ModContent.ItemType<Items.LargeDaybloom>();
                            break;
                        case 1:
                            item = ModContent.ItemType<Items.LargeMoonglow>();
                            break;
                        case 2:
                            item = ModContent.ItemType<Items.LargeBlinkroot>();
                            break;
                        case 3:
                            item = ModContent.ItemType<Items.LargeDeathweed>();
                            break;
                        case 4:
                            item = ModContent.ItemType<Items.LargeWaterleaf>();
                            break;
                        case 5:
                            item = ModContent.ItemType<Items.LargeFireblossom>();
                            break;
                        case 6:
                            item = ModContent.ItemType<Items.LargeShiverthorn>();
                            break;
                        case 7:
                            item = ModContent.ItemType<Items.LargeBloodberry>();
                            break;
                        case 8:
                            item = ModContent.ItemType<Items.LargeSweetstem>();
                            break;
                        case 9:
                            item = ModContent.ItemType<Items.LargeBarfbush>();
                            break;
                    }
                    if (item > 0) Item.NewItem(x * 16, fixedY * 16, 16, 48, item);
                    // 3700 through 3709 are the large herbs
                }
                WorldGen.destroyObject = false;
            }
        }        public static void ConvertFromThings(int x, int y, int convert, bool tileframe = true)
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
                    else if (type == ModContent.TileType<Snotsandstone>())
                    {
                        tile.type = TileID.Sandstone;
                    }
                    else if (type == ModContent.TileType<HardenedSnotsand>())
                    {
                        tile.type = TileID.HardenedSand;
                    }
                    //else if (type == ModContent.TileType<ContagionShortGrass>())
                    //{
                    //    tile.type = TileID.Plants;
                    //}
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
                    else if (type == ModContent.TileType<Snotsandstone>() || type == TileID.HallowSandstone || type == TileID.CrimsonSandstone || type == TileID.CorruptSandstone)
                    {
                        tile.type = TileID.Sandstone;
                    }
                    else if (type == ModContent.TileType<HardenedSnotsand>() || type == TileID.HallowHardenedSand || type == TileID.CrimsonHardenedSand || type == TileID.CorruptHardenedSand)
                    {
                        tile.type = TileID.HardenedSand;
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
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    WorldGen.SquareTileFrame(x, y);
                }
                else if (Main.netMode == NetmodeID.Server)
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
        }        public static void AddPlants()
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 1; j < Main.maxTilesY; j++)
                {
                    if (Main.tile[i, j].type == (ushort)ModContent.TileType<Ickgrass>() && Main.tile[i, j].nactive() && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].halfBrick() && Main.rand.Next(3) == 0)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            //WorldGen.PlaceTile(i, j - 1, ModContent.TileType<ContagionShortGrass>(), true, false, style: Main.rand.Next(0, 8));
                            Main.tile[i, j - 1].type = (ushort)ModContent.TileType<ContagionShortGrass>();
                            Main.tile[i, j - 1].frameX = (short)(WorldGen.genRand.Next(0, 11) * 18);
                        }
                    }
                    //else if (Main.tile[i, j].type == 23 && Main.tile[i, j].nactive())
                    //{
                    //    if (!Main.tile[i, j - 1].active())
                    //    {
                    //        WorldGen.PlaceTile(i, j - 1, 24, true, false, -1, 0);
                    //    }
                    //}
                    //else if (Main.tile[i, j].type == 199 && Main.tile[i, j].nactive() && !Main.tile[i, j - 1].active())
                    //{
                    //    WorldGen.PlaceTile(i, j - 1, 201, true, false, -1, 0);
                    //}
                }
            }
        }        private static void GenerateContagion(GenerationProgress progress)
        {
            GenerateHardmodeContagion();
        }        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = ExxoAvalonOrigins.superHardmode;
            flags[1] = downedPhantasm;
            flags[2] = contaigon;
            flags[3] = downedBacteriumPrime;
            flags[4] = downedDesertBeak;
            flags[5] = downedDragonLord;
            flags[6] = downedMechasting;
            flags[7] = downedOblivion;
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
            downedBacteriumPrime = flags[3];
            downedDesertBeak = flags[4];
            downedPhantasm = flags[1];
            downedDragonLord = flags[5];
            downedMechasting = flags[6];
            downedOblivion = flags[7];
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
            for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); i++)
            {
                IceSnowOreRunner(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 200), WorldGen.genRand.Next(6, 9), WorldGen.genRand.Next(6, 9), (ushort)ModContent.TileType<Tiles.FeroziumOre>());
            }
        }        public static void GrowLargeHerb(int x, int y)
        {
            if (Main.tile[x, y].active())
            {
                if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>() && WorldGen.genRand.Next(8) == 0) // phase 1 to 2
                {
                    bool grow = false;
                    if (Main.tile[x, y].frameX == 108) // shiverthorn check
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            grow = true;
                        }
                    }
                    else
                    {
                        grow = true;
                    }
                    if (grow)
                    {
                        Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                        if (Main.tile[x, y + 1].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>()) Main.tile[x, y + 1].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                        if (Main.tile[x, y + 2].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>()) Main.tile[x, y + 2].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                        if (Main.tile[x, y - 1].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>()) Main.tile[x, y - 1].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                        if (Main.tile[x, y - 2].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>()) Main.tile[x, y - 2].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>();
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, x, y, 2);
                            NetMessage.SendTileSquare(-1, x, y + 1, 2);
                            NetMessage.SendTileSquare(-1, x, y + 2, 2);
                            NetMessage.SendTileSquare(-1, x, y - 1, 2);
                            NetMessage.SendTileSquare(-1, x, y - 2, 2);
                        }
                        SquareTileFrameArea(x, y, 4, true);
                        return;
                    }
                }
                else if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>() && WorldGen.genRand.Next(7) == 0) // phase 2 to 3
                {
                    bool grow = false;
                    if (Main.tile[x, y].frameX == 108) // shiverthorn check
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            grow = true;
                        }
                    }
                    else
                    {
                        grow = true;
                    }
                    if (grow)
                    {
                        Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                        if (Main.tile[x, y + 1].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>()) Main.tile[x, y + 1].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                        if (Main.tile[x, y + 2].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>()) Main.tile[x, y + 2].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                        if (Main.tile[x, y - 1].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>()) Main.tile[x, y - 1].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                        if (Main.tile[x, y - 2].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>()) Main.tile[x, y - 2].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>();
                        if (Main.netMode == NetmodeID.Server)
                        {
                            NetMessage.SendTileSquare(-1, x, y, 2);
                            NetMessage.SendTileSquare(-1, x, y + 1, 2);
                            NetMessage.SendTileSquare(-1, x, y + 2, 2);
                            NetMessage.SendTileSquare(-1, x, y - 1, 2);
                            NetMessage.SendTileSquare(-1, x, y - 2, 2);
                        }
                        SquareTileFrameArea(x, y, 4, true);
                        return;
                    }
                }
                else if (Main.tile[x, y].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>() && WorldGen.genRand.Next(5) == 0) // phase 3 to 4
                {
                    Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                    if (Main.tile[x, y + 1].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>()) Main.tile[x, y + 1].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                    if (Main.tile[x, y + 2].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>()) Main.tile[x, y + 2].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                    if (Main.tile[x, y - 1].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>()) Main.tile[x, y - 1].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                    if (Main.tile[x, y - 2].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>()) Main.tile[x, y - 2].type = (ushort)ModContent.TileType<Tiles.LargeHerbsStage4>();
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, x, y, 2);
                        NetMessage.SendTileSquare(-1, x, y + 1, 2);
                        NetMessage.SendTileSquare(-1, x, y + 2, 2);
                        NetMessage.SendTileSquare(-1, x, y - 1, 2);
                        NetMessage.SendTileSquare(-1, x, y - 2, 2);
                    }
                    SquareTileFrameArea(x, y, 4, true);
                    return;
                }
            }
        }        public static void TropicalRunner(int i, int j)
        {
            double num = WorldGen.genRand.Next(5, 11);
            Vector2 vector = default(Vector2);
            vector.X = i;
            vector.Y = j;
            Vector2 vector2 = default(Vector2);
            vector2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            vector2.Y = (float)WorldGen.genRand.Next(10, 20) * 0.1f;
            int num2 = 0;
            bool flag = true;
            while (flag)
            {
                if ((double)vector.Y < Main.worldSurface)
                {
                    int value = (int)vector.X;
                    int value2 = (int)vector.Y;
                    value = Utils.Clamp(value, 10, Main.maxTilesX - 10);
                    value2 = Utils.Clamp(value2, 10, Main.maxTilesY - 10);
                    if (value2 < 5)
                    {
                        value2 = 5;
                    }
                    if (Main.tile[value, value2].wall == 0 && !Main.tile[value, value2].active() && Main.tile[value, value2 - 3].wall == 0 && !Main.tile[value, value2 - 3].active() && Main.tile[value, value2 - 1].wall == 0 && !Main.tile[value, value2 - 1].active() && Main.tile[value, value2 - 4].wall == 0 && !Main.tile[value, value2 - 4].active() && Main.tile[value, value2 - 2].wall == 0 && !Main.tile[value, value2 - 2].active() && Main.tile[value, value2 - 5].wall == 0 && !Main.tile[value, value2 - 5].active())
                    {
                        flag = false;
                    }
                }
                //WorldGen.JungleX = (int)vector.X;
                num += (double)((float)WorldGen.genRand.Next(-20, 21) * 0.1f);
                if (num < 5.0)
                {
                    num = 5.0;
                }
                if (num > 10.0)
                {
                    num = 10.0;
                }
                int value6 = (int)((double)vector.X - num * 0.5);
                int value3 = (int)((double)vector.X + num * 0.5);
                int value4 = (int)((double)vector.Y - num * 0.5);
                int value5 = (int)((double)vector.Y + num * 0.5);
                int num4 = Utils.Clamp(value6, 10, Main.maxTilesX - 10);
                value3 = Utils.Clamp(value3, 10, Main.maxTilesX - 10);
                value4 = Utils.Clamp(value4, 10, Main.maxTilesY - 10);
                value5 = Utils.Clamp(value5, 10, Main.maxTilesY - 10);
                for (int k = num4; k < value3; k++)
                {
                    for (int l = value4; l < value5; l++)
                    {
                        if ((double)(Math.Abs((float)k - vector.X) + Math.Abs((float)l - vector.Y)) < num * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
                        {
                            WorldGen.KillTile(k, l);
                        }
                    }
                }
                num2++;
                if (num2 > 10 && WorldGen.genRand.Next(50) < num2)
                {
                    num2 = 0;
                    int num3 = -2;
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        num3 = 2;
                    }
                    TileRunner((int)vector.X, (int)vector.Y, WorldGen.genRand.Next(3, 20), WorldGen.genRand.Next(10, 100), -1, addTile: false, num3);
                }
                vector += vector2;
                vector2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.01f;
                if (vector2.Y > 0f)
                {
                    vector2.Y = 0f;
                }
                if (vector2.Y < -2f)
                {
                    vector2.Y = -2f;
                }
                vector2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
                if (vector.X < (float)(i - 200))
                {
                    vector2.X += (float)WorldGen.genRand.Next(5, 21) * 0.1f;
                }
                if (vector.X > (float)(i + 200))
                {
                    vector2.X -= (float)WorldGen.genRand.Next(5, 21) * 0.1f;
                }
                if ((double)vector2.X > 1.5)
                {
                    vector2.X = 1.5f;
                }
                if ((double)vector2.X < -1.5)
                {
                    vector2.X = -1.5f;
                }
            }
        }        public static void GERunner(int i, int j, float speedX = 0f, float speedY = 0f, bool good = true)
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
                            if (Main.tile[k, l].wall == 63 || Main.tile[k, l].wall == 65 || Main.tile[k, l].wall == 66 || Main.tile[k, l].wall == 68 || Main.tile[k, l].wall == 69 || Main.tile[k, l].wall == 81 || Main.tile[k, l].wall == (ushort)ModContent.WallType<Walls.ChunkstoneWall>())
                            {
                                Main.tile[k, l].wall = 70;
                            }
                            else if (Main.tile[k, l].wall == 216 || Main.tile[k, l].wall == (ushort)ModContent.WallType<Walls.ContagionNaturalWall1>())
                            {
                                Main.tile[k, l].wall = 219;
                            }
                            else if (Main.tile[k, l].wall == 187 || Main.tile[k, l].wall == (ushort)ModContent.WallType<Walls.ContagionNaturalWall2>())
                            {
                                Main.tile[k, l].wall = 222;
                            }
                            if (Main.tile[k, l].active() && !Main.tile[k, l - 1].active() && !Main.tile[k, l - 1].lava() && Main.tile[k, l - 1].type != TileID.Containers && Main.tile[k, l - 1].type != TileID.Containers2 && l < Main.maxTilesY - 200 && Main.rand.Next(150) == 0) // hallowed altar gen
                            {
                                WorldGen.Place3x2(k, l - 1, (ushort)ModContent.TileType<Tiles.HallowedAltar>());
                            }
                            if (Main.tile[k, l].wall == 3 || Main.tile[k, l].wall == 83)
                            {
                                Main.tile[k, l].wall = 28;
                            }
                            if (Main.tile[k, l].type == 2 || Main.tile[k, l].type == (ushort)ModContent.TileType<Ickgrass>())
                            {
                                Main.tile[k, l].type = 109;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 1 || Main.tile[k, l].type == (ushort)ModContent.TileType<Chunkstone>())
                            {
                                Main.tile[k, l].type = 117;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 53 || Main.tile[k, l].type == 123 || Main.tile[k, l].type == (ushort)ModContent.TileType<Snotsand>())
                            {
                                Main.tile[k, l].type = 116;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 23 || Main.tile[k, l].type == 199 || Main.tile[k, l].type == (ushort)ModContent.TileType<Ickgrass>())
                            {
                                Main.tile[k, l].type = 109;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 25 || Main.tile[k, l].type == 203 || Main.tile[k, l].type == (ushort)ModContent.TileType<Chunkstone>())
                            {
                                Main.tile[k, l].type = 117;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 112 || Main.tile[k, l].type == 234 || Main.tile[k, l].type == (ushort)ModContent.TileType<Snotsand>())
                            {
                                Main.tile[k, l].type = 116;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 161 || Main.tile[k, l].type == 163 || Main.tile[k, l].type == 200 || Main.tile[k, l].type == (ushort)ModContent.TileType<YellowIce>())
                            {
                                Main.tile[k, l].type = 164;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 396 || Main.tile[k, l].type == (ushort)ModContent.TileType<Snotsandstone>())
                            {
                                Main.tile[k, l].type = 403;
                                SquareTileFrame(k, l);
                            }
                            else if (Main.tile[k, l].type == 397 || Main.tile[k, l].type == (ushort)ModContent.TileType<HardenedSnotsand>())
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
                                Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ContagionNaturalWall2>();
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
        }        public override void PostUpdate()
        {
            float num2 = 3E-05f * (float)Main.worldRate;
            float num3 = 1.5E-05f * (float)Main.worldRate;
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
                    if (Main.tile[num5, num6].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage1>() || Main.tile[num5, num6].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage2>() ||
                        Main.tile[num5, num6].type == (ushort)ModContent.TileType<Tiles.LargeHerbsStage3>())
                    {
                        GrowLargeHerb(num5, num6);
                    }
                    if (Main.tile[num5, num6].type == ModContent.TileType<Ickgrass>())
                    {
                        int num14 = (int)Main.tile[num5, num6].type;
                        if (!Main.tile[num5, num9].active() && !Main.tile[num5, num6].halfBrick() && Main.tile[num5, num6].slope() == 0 && WorldGen.genRand.Next(5) == 0 && num14 == ModContent.TileType<Ickgrass>())
                        {
                            WorldGen.PlaceTile(num5, num9, ModContent.TileType<ContagionShortGrass>(), true, false, -1, 0);
                            Main.tile[num5, num9].frameX = (short)(WorldGen.genRand.Next(0, 11) * 18);
                            if (Main.tile[num5, num9].active())
                            {
                                Main.tile[num5, num9].color(Main.tile[num5, num6].color());
                            }
                            if (Main.netMode == 2 && Main.tile[num5, num9].active())
                            {
                                NetMessage.SendTileSquare(-1, num5, num9, 1);
                            }
                        }
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
                        if (Main.netMode == NetmodeID.Server && flag2)
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
                            if (Main.tile[num5, num47].active() && Main.tile[num5, num47].type == ModContent.TileType<Impgrass>() && !Main.tile[num5, num47].bottomSlope())
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
                            if (Main.netMode == NetmodeID.Server)
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
        }        public static void TileRunner(int i, int j, double strength, int steps, int type, bool addTile = false, float speedX = 0f, float speedY = 0f, bool noYChange = false, bool overRide = true)
        {
            double num = strength;
            float num2 = (float)steps;
            Vector2 value;
            value.X = (float)i;
            value.Y = (float)j;
            Vector2 value2;
            value2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            value2.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            if (speedX != 0f || speedY != 0f)
            {
                value2.X = speedX;
                value2.Y = speedY;
            }
            while (num > 0.0 && num2 > 0f)
            {
                if (value.Y < 0f && num2 > 0f && type == 59)
                {
                    num2 = 0f;
                }
                num = strength * (double)(num2 / (float)steps);
                num2 -= 1f;
                int num3 = (int)((double)value.X - num * 0.5);
                int num4 = (int)((double)value.X + num * 0.5);
                int num5 = (int)((double)value.Y - num * 0.5);
                int num6 = (int)((double)value.Y + num * 0.5);
                if (num3 < 1)
                {
                    num3 = 1;
                }
                if (num4 > Main.maxTilesX - 1)
                {
                    num4 = Main.maxTilesX - 1;
                }
                if (num5 < 1)
                {
                    num5 = 1;
                }
                if (num6 > Main.maxTilesY - 1)
                {
                    num6 = Main.maxTilesY - 1;
                }
                for (int k = num3; k < num4; k++)
                {
                    for (int l = num5; l < num6; l++)
                    {
                        if ((double)(Math.Abs((float)k - value.X) + Math.Abs((float)l - value.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015))
                        {
                            if (mudWall && (double)l > Main.worldSurface && Main.tile[k, l - 1].wall != 2 && l < Main.maxTilesY - 210 - WorldGen.genRand.Next(3))
                            {
                                if (l > WorldGen.lavaLine - WorldGen.genRand.Next(0, 4) - 50)
                                {
                                    if (jungleMenuSelection == JungleVariant.tropics)
                                    {
                                        if (Main.tile[k, l - 1].wall != 220 && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>() && Main.tile[k - 1, l].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>() && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>())
                                        {
                                            WorldGen.PlaceWall(k, l, (ushort)ModContent.WallType<Walls.TropicalMudWall>(), true);
                                        }
                                    }
                                    else
                                    {
                                        if (Main.tile[k, l - 1].wall != 64 && Main.tile[k, l + 1].wall != 64 && Main.tile[k - 1, l].wall != 64 && Main.tile[k, l + 1].wall != 64)
                                        {
                                            WorldGen.PlaceWall(k, l, 15, true);
                                        }
                                    }
                                }
                                else
                                {
                                    if (jungleMenuSelection == JungleVariant.tropics)
                                    {
                                        if (Main.tile[k, l - 1].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>() && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>() && Main.tile[k - 1, l].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>() && Main.tile[k, l + 1].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>())
                                        {
                                            WorldGen.PlaceWall(k, l, (ushort)ModContent.WallType<Walls.TropicalGrassWall>(), true);
                                        }
                                    }
                                    else
                                    {
                                        if (Main.tile[k, l - 1].wall != 15 && Main.tile[k, l + 1].wall != 15 && Main.tile[k - 1, l].wall != 15 && Main.tile[k, l + 1].wall != 15)
                                        {
                                            WorldGen.PlaceWall(k, l, 64, true);
                                        }
                                    }
                                }
                            }
                            if (type < 0)
                            {
                                if (type == -2 && Main.tile[k, l].active() && (l < WorldGen.waterLine || l > WorldGen.lavaLine))
                                {
                                    Main.tile[k, l].liquid = 255;
                                    if (l > WorldGen.lavaLine)
                                    {
                                        Main.tile[k, l].lava(true);
                                    }
                                }
                                Main.tile[k, l].active(false);
                            }
                            else
                            {
                                if ((overRide || !Main.tile[k, l].active()) && (type != 40 || Main.tile[k, l].type != 53) && (!Main.tileStone[type] || Main.tile[k, l].type == 1) && Main.tile[k, l].type != 189 && Main.tile[k, l].type != 196 && Main.tile[k, l].type != 45 && Main.tile[k, l].type != 147 && Main.tile[k, l].type != 190 && (Main.tile[k, l].type != 1 || type != 59 || (double)l >= Main.worldSurface + (double)WorldGen.genRand.Next(-50, 50)))
                                {
                                    if (Main.tile[k, l].type != 53 || (double)l >= Main.worldSurface)
                                    {
                                        Main.tile[k, l].type = (ushort)type;
                                    }
                                }
                                if (addTile)
                                {
                                    Main.tile[k, l].active(true);
                                    Main.tile[k, l].liquid = 0;
                                    Main.tile[k, l].lava(false);
                                }
                                if (noYChange && (double)l < Main.worldSurface && type != 59)
                                {
                                    Main.tile[k, l].wall = 2;
                                }
                                if (type == 59 && l > WorldGen.waterLine && Main.tile[k, l].liquid > 0)
                                {
                                    Main.tile[k, l].lava(false);
                                    Main.tile[k, l].liquid = 0;
                                }
                            }
                        }
                    }
                }
                value += value2;
                if (num > 50.0)
                {
                    value += value2;
                    num2 -= 1f;
                    value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (num > 100.0)
                    {
                        value += value2;
                        num2 -= 1f;
                        value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                        if (num > 150.0)
                        {
                            value += value2;
                            num2 -= 1f;
                            value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                            if (num > 200.0)
                            {
                                value += value2;
                                num2 -= 1f;
                                value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                if (num > 250.0)
                                {
                                    value += value2;
                                    num2 -= 1f;
                                    value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                    if (num > 300.0)
                                    {
                                        value += value2;
                                        num2 -= 1f;
                                        value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                        if (num > 400.0)
                                        {
                                            value += value2;
                                            num2 -= 1f;
                                            value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                            if (num > 500.0)
                                            {
                                                value += value2;
                                                num2 -= 1f;
                                                value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                if (num > 600.0)
                                                {
                                                    value += value2;
                                                    num2 -= 1f;
                                                    value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                    if (num > 700.0)
                                                    {
                                                        value += value2;
                                                        num2 -= 1f;
                                                        value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                        if (num > 800.0)
                                                        {
                                                            value += value2;
                                                            num2 -= 1f;
                                                            value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            if (num > 900.0)
                                                            {
                                                                value += value2;
                                                                num2 -= 1f;
                                                                value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                                value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (value2.X > 1f)
                {
                    value2.X = 1f;
                }
                if (value2.X < -1f)
                {
                    value2.X = -1f;
                }
                if (!noYChange)
                {
                    value2.Y += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                    if (value2.Y > 1f)
                    {
                        value2.Y = 1f;
                    }
                    if (value2.Y < -1f)
                    {
                        value2.Y = -1f;
                    }
                }
                else if (type != 59 && num < 3.0)
                {
                    if (value2.Y > 1f)
                    {
                        value2.Y = 1f;
                    }
                    if (value2.Y < -1f)
                    {
                        value2.Y = -1f;
                    }
                }
                if (type == 59 && !noYChange)
                {
                    if ((double)value2.Y > 0.5)
                    {
                        value2.Y = 0.5f;
                    }
                    if ((double)value2.Y < -0.5)
                    {
                        value2.Y = -0.5f;
                    }
                    if ((double)value.Y < Main.rockLayer + 100.0)
                    {
                        value2.Y = 1f;
                    }
                    if (value.Y > (float)(Main.maxTilesY - 300))
                    {
                        value2.Y = -1f;
                    }
                }
            }
        }        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)        {            theBeak = ModContent.ItemType<TheBeak>();            blbTimer = 0;            rhodium = true;            rhodiumBar = ModContent.TileType<RhodiumOre>();            shmOreTier1 = -1;            shmOreTier2 = -1;            contaigon = contaigonSet;            contaigonSet = false;            totalDark2 = 0;            nilShrineCount = 0;            hallowedAltarCount = 0;            ExxoAvalonOrigins.superHardmode = false;            ExxoAvalonOrigins.nilMode = false;            ExxoAvalonOriginsGlobalNPC.stoppedArmageddon = false;            ExxoAvalonOriginsGlobalNPC.oblivionDead = false;            ExxoAvalonOriginsGlobalNPC.oblivionTimes = 0;            hiddenTemplePos = Vector2.Zero;            if (osmiumMenuSelection == OsmiumVariant.random)
            {
                osmiumMenuSelection = (OsmiumVariant)WorldGen.genRand.Next(3);
            }
            if (jungleMenuSelection == JungleVariant.random)
            {
                jungleMenuSelection = (JungleVariant)WorldGen.genRand.Next(2);
            }

            switch (osmiumMenuSelection)
            {
                case OsmiumVariant.osmium:
                    {
                        rhodiumBar = ModContent.TileType<Tiles.OsmiumOre>();
                        break;
                    }
                case OsmiumVariant.rhodium:
                    {
                        rhodiumBar = ModContent.TileType<Tiles.RhodiumOre>();
                        break;
                    }
                case OsmiumVariant.iridium:
                    {
                        rhodiumBar = ModContent.TileType<Tiles.IridiumOre>();
                        break;
                    }
            }                   var reset = tasks.FindIndex(genpass => genpass.Name == "Reset");            if (reset != -1)            {                tasks.Insert(reset + 1, new PassLegacy("Avalon Setup", delegate(GenerationProgress progress)                {                    progress.Message = "Setting up Avalonian World Gen";                    if (!contaigon && WorldGen.WorldGenParam_Evil == -1)                    {                        contaigon = WorldGen.genRand.Next(3) == 0;                        if (contaigon) WorldGen.crimson = false;                    }                    if (WorldGen.WorldGenParam_Evil == 2)                    {                        contaigon = true;                        WorldGen.crimson = false;                    }                    int phmOreTier1 = WorldGen.genRand.Next(3);
                    int phmOreTier2 = WorldGen.genRand.Next(3);
                    int phmOreTier3 = WorldGen.genRand.Next(3);
                    int phmOreTier4 = WorldGen.genRand.Next(3);                    // Set altenative prehard ores                    if (phmOreTier1 == 0)
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
                    }                }));            }            var jungle = tasks.FindIndex(genpass => genpass.Name == "Jungle");            if (jungle != -1)
            {
                junglePass = tasks[jungle];                tasks[jungle] = new PassLegacy("Jungle or Tropics", delegate (GenerationProgress progress)                {
                    if (jungleMenuSelection == JungleVariant.tropics)
                    {
                        junglePass.Apply(progress);
                        //progress.Message = "Generating Tropics";
                        //float num616 = Main.maxTilesX / 4200;
                        //num616 *= 1.5f;
                        //int num617 = 0;
                        //float num618 = (float)WorldGen.genRand.Next(15, 30) * 0.01f;
                        //dungeonSide = ((WorldGen.genRand.Next(2) != 0) ? 1 : (-1));
                        //if (dungeonSide == -1)
                        //{
                        //    num618 = 1f - num618;
                        //    num617 = (int)((float)Main.maxTilesX * num618);
                        //}
                        //else
                        //{
                        //    num617 = (int)((float)Main.maxTilesX * num618);
                        //}
                        //int num619 = (int)((double)Main.maxTilesY + Main.rockLayer) / 2;
                        //num617 += WorldGen.genRand.Next((int)(-100f * num616), (int)(101f * num616));
                        //num619 += WorldGen.genRand.Next((int)(-100f * num616), (int)(101f * num616));
                        //int num620 = num617;
                        //int num621 = num619;
                        //WorldGen.TileRunner(num617, num619, WorldGen.genRand.Next((int)(250f * num616), (int)(500f * num616)), WorldGen.genRand.Next(50, 150), (ushort)ModContent.TileType<Tiles.TropicalMud>(), addTile: false, dungeonSide * 3);
                        //for (int num622 = 0; (float)num622 < 6f * num616; num622++)
                        //{
                        //    WorldGen.TileRunner(num617 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), num619 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(63, 65));
                        //}
                        ////mudWall = true;
                        //progress.Set(0.15f);
                        //num617 += WorldGen.genRand.Next((int)(-250f * num616), (int)(251f * num616));
                        //num619 += WorldGen.genRand.Next((int)(-150f * num616), (int)(151f * num616));
                        //int num623 = num617;
                        //int num624 = num619;
                        //int num625 = num617;
                        //int num626 = num619;
                        //WorldGen.TileRunner(num617, num619, WorldGen.genRand.Next((int)(250f * num616), (int)(500f * num616)), WorldGen.genRand.Next(50, 150), (ushort)ModContent.TileType<Tiles.TropicalMud>());
                        ////mudWall = false;
                        //for (int num627 = 0; (float)num627 < 6f * num616; num627++)
                        //{
                        //    WorldGen.TileRunner(num617 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), num619 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(65, 67));
                        //}
                        ////mudWall = true;
                        //progress.Set(0.3f);
                        //num617 += WorldGen.genRand.Next((int)(-400f * num616), (int)(401f * num616));
                        //num619 += WorldGen.genRand.Next((int)(-150f * num616), (int)(151f * num616));
                        //int num628 = num617;
                        //int num629 = num619;
                        //WorldGen.TileRunner(num617, num619, WorldGen.genRand.Next((int)(250f * num616), (int)(500f * num616)), WorldGen.genRand.Next(50, 150), (ushort)ModContent.TileType<Tiles.TropicalMud>(), addTile: false, dungeonSide * -3);
                        ////mudWall = false;
                        //for (int num630 = 0; (float)num630 < 6f * num616; num630++)
                        //{
                        //    WorldGen.TileRunner(num617 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), num619 + WorldGen.genRand.Next(-(int)(125f * num616), (int)(125f * num616)), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(67, 69));
                        //}
                        ////mudWall = true;
                        //progress.Set(0.45f);
                        //num617 = (num620 + num623 + num628) / 3;
                        //num619 = (num621 + num624 + num629) / 3;
                        //WorldGen.TileRunner(num617, num619, WorldGen.genRand.Next((int)(400f * num616), (int)(600f * num616)), 1000, (ushort)ModContent.TileType<Tiles.TropicalMud>(), addTile: false, 0f, -20f, noYChange: true);
                        //WorldGen.JungleRunner(num617, num619);
                        //progress.Set(0.6f);
                        ////mudWall = false;
                        //for (int num631 = 0; num631 < Main.maxTilesX / 4; num631++)
                        //{
                        //    num617 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                        //    num619 = WorldGen.genRand.Next((int)WorldGen.worldSurface + 10, Main.maxTilesY - 200);
                        //    while (Main.tile[num617, num619].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>() && Main.tile[num617, num619].wall != (ushort)ModContent.WallType<Walls.TropicalMudWall>())
                        //    {
                        //        num617 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                        //        num619 = WorldGen.genRand.Next((int)WorldGen.worldSurface + 10, Main.maxTilesY - 200);
                        //    }
                        //    WorldGen.MudWallRunner(num617, num619);
                        //}
                        //num617 = num625;
                        //num619 = num626;
                        //for (int num632 = 0; (float)num632 <= 20f * num616; num632++)
                        //{
                        //    progress.Set((60f + (float)num632 / num616) * 0.01f);
                        //    num617 += WorldGen.genRand.Next((int)(-5f * num616), (int)(6f * num616));
                        //    num619 += WorldGen.genRand.Next((int)(-5f * num616), (int)(6f * num616));
                        //    WorldGen.TileRunner(num617, num619, WorldGen.genRand.Next(40, 100), WorldGen.genRand.Next(300, 500), (ushort)ModContent.TileType<Tiles.TropicalMud>());
                        //}
                        //for (int num633 = 0; (float)num633 <= 10f * num616; num633++)
                        //{
                        //    progress.Set((80f + (float)num633 / num616 * 2f) * 0.01f);
                        //    num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                        //    num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                        //    while (num617 < 1 || num617 >= Main.maxTilesX - 1 || num619 < 1 || num619 >= Main.maxTilesY - 1 || Main.tile[num617, num619].type != (ushort)ModContent.TileType<Tiles.TropicalMud>())
                        //    {
                        //        num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                        //        num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                        //    }
                        //    for (int num634 = 0; (float)num634 < 8f * num616; num634++)
                        //    {
                        //        num617 += WorldGen.genRand.Next(-30, 31);
                        //        num619 += WorldGen.genRand.Next(-30, 31);
                        //        int type5 = -1;
                        //        if (WorldGen.genRand.Next(7) == 0)
                        //        {
                        //            type5 = -2;
                        //        }
                        //        WorldGen.TileRunner(num617, num619, WorldGen.genRand.Next(10, 20), WorldGen.genRand.Next(30, 70), type5);
                        //    }
                        //}
                        //for (int num635 = 0; (float)num635 <= 300f * num616; num635++)
                        //{
                        //    num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                        //    num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                        //    while (num617 < 1 || num617 >= Main.maxTilesX - 1 || num619 < 1 || num619 >= Main.maxTilesY - 1 || Main.tile[num617, num619].type != (ushort)ModContent.TileType<Tiles.TropicalMud>())
                        //    {
                        //        num617 = num625 + WorldGen.genRand.Next((int)(-600f * num616), (int)(600f * num616));
                        //        num619 = num626 + WorldGen.genRand.Next((int)(-200f * num616), (int)(200f * num616));
                        //    }
                        //    WorldGen.TileRunner(num617, num619, WorldGen.genRand.Next(4, 10), WorldGen.genRand.Next(5, 30), (ushort)ModContent.TileType<Tiles.TropicalStone>());
                        //    if (WorldGen.genRand.Next(4) == 0)
                        //    {
                        //        int type6 = WorldGen.genRand.Next(63, 69);
                        //        WorldGen.TileRunner(num617 + WorldGen.genRand.Next(-1, 2), num619 + WorldGen.genRand.Next(-1, 2), WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(4, 8), type6);
                        //    }
                        //}
                        //for (int num106 = 0; num106 < Main.maxTilesX; num106++)
                        //{
                        //    for (int num107 = 0; num107 < Main.maxTilesY; num107++)
                        //    {
                        //        if (Main.tile[num106, num107].active())
                        //        {
                        //            try
                        //            {
                        //                grassSpread = 0;
                        //                AvalonSpreadGrass(num106, num107, (ushort)ModContent.TileType<Tiles.TropicalMud>(), (ushort)ModContent.TileType<Tiles.TropicalGrass>(), true, 0);
                        //            }
                        //            catch
                        //            {
                        //                grassSpread = 0;
                        //                AvalonSpreadGrass(num106, num107, (ushort)ModContent.TileType<Tiles.TropicalMud>(), (ushort)ModContent.TileType<Tiles.TropicalGrass>(), false, 0);
                        //            }
                        //        }
                        //    }
                        //}
                    }
                    else junglePass.Apply(progress);
                });
            }            var shinies = tasks.FindIndex(genpass => genpass.Name == "Shinies");            if (shinies != -1)            {                tasks.RemoveAt(shinies);                tasks.Insert(shinies, new PassLegacy("Avalon Shinies", delegate(GenerationProgress progress)                {                    progress.Message = "Signalling Avalon Hooks";                    generatingBaccilite = contaigon; //Signals ExxoAvalonOrigins.BacciliteReplacement() to replace a demonite ore type with baccilite.                }));                tasks.Insert(shinies + 1, new PassLegacy("Avalon PHM Ore Gen", delegate (GenerationProgress progress)                {
                    progress.Message = Lang.gen[16].Value;
                    // prehardmode ores
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
                    // Evil ores
                    if (WorldGen.crimson)
                    {
                        for (int num570 = 0; num570 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05); num570++)
                        {
                            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), TileID.Crimtane);
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
                            WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayerLow, Main.maxTilesY), WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(3, 6), TileID.Demonite);
                        }
                    }
                }));                tasks.Insert(shinies + 2, new PassLegacy("Avalon Shinies", delegate(GenerationProgress progress)                {                    progress.Message = "Adding Avalonian Shinies";                    generatingBaccilite = false;                    for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.00012); i++)                    {                        WorldGen.TileRunner(                            WorldGen.genRand.Next(100, Main.maxTilesX - 100), // Xcoord of tile                            WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 150), // Ycoord of tile                            WorldGen.genRand.Next(4, 5), // Quantity                            WorldGen.genRand.Next(5, 7),                            rhodiumBar, //Tile to spawn                            false, 0f, 0f, false, true); //last input overrides existing tiles                    }                    for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 2E-05); i++)                    {                        var i8 = WorldGen.genRand.Next(100, Main.maxTilesX - 100);                        var rockLayer = Main.rockLayer;                        var j8 = WorldGen.genRand.Next((int)rockLayer, Main.maxTilesY - 150);                        GenerateHearts(i8, j8, ModContent.TileType<Heartstone>());                    }                }));            }            var underworld = tasks.FindIndex(genpass => genpass.Name == "Underworld");            if (underworld != -1)            {                tasks.Insert(underworld + 1, new PassLegacy("Avalon Underworld", delegate (GenerationProgress progress)                {                    progress.Message = "Generating Hellcastle and Ashen Overgrowth";                    for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0008); i++)                    {                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), (ushort)ModContent.TileType<CaesiumOre>());                    }
                    GenerateHellcastle(Main.maxTilesX / 3 - 210, Main.maxTilesY - 140); // change back later
                    for (int hbx = Main.maxTilesX / 3 - 350; hbx < Main.maxTilesX / 3 + 500; hbx++)
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
                }));            }                        var dungeonSideTask = tasks.FindIndex(genpass => genpass.Name == "Dungeon");            if (dungeonSideTask != -1)            {                tasks.Insert(underworld + 1, new PassLegacy("Avalon Finding Dungeon",                    delegate(GenerationProgress progress)                    {                        dungeonSide = WorldGen.dungeonX < Main.maxTilesX * 0.5 ? -1 : 1;                        ExxoAvalonOrigins.dungeonEx = WorldGen.dungeonX;                    }));            }            var corruptionTask = tasks.FindIndex(genpass => genpass.Name == "Corruption");            if (corruptionTask != -1)            {                corruptionPass = tasks[corruptionTask];                tasks[corruptionTask] =                 new PassLegacy("Corruption", delegate (GenerationProgress progress)                {                    if (contaigon)                    {                        progress.Message = "Making the world gross";                        int num208 = 0;                        while (num208 < Main.maxTilesX * 0.00045)                        {                            float num209 = (float)(num208 / (Main.maxTilesX * 0.00045));                            bool flag12 = false;                            int num210 = 0;                            int num211 = 0;                            int num212 = 0;                            while (!flag12)                            {                                int num213 = 0;                                flag12 = true;                                int num214 = Main.maxTilesX / 2;                                int num215 = 200;                                if (WorldGen.dungeonX < Main.maxTilesX * 0.5)                                {                                    num210 = WorldGen.genRand.Next(600, Main.maxTilesX - 320);                                }                                else                                {                                    num210 = WorldGen.genRand.Next(320, Main.maxTilesX - 600);                                }                                num211 = num210 - WorldGen.genRand.Next(200) - 100;                                num212 = num210 + WorldGen.genRand.Next(200) + 100;                                if (num211 < 285)                                {                                    num211 = 285;                                }                                if (num212 > Main.maxTilesX - 285)                                {                                    num212 = Main.maxTilesX - 285;                                }                                if (dungeonSide < 0 && num211 < 400)                                {                                    num211 = 400;                                }                                else if (dungeonSide > 0 && num211 > Main.maxTilesX - 400)                                {                                    num211 = Main.maxTilesX - 400;                                }                                if (num210 > num214 - num215 && num210 < num214 + num215)                                {                                    flag12 = false;                                }                                if (num211 > num214 - num215 && num211 < num214 + num215)                                {                                    flag12 = false;                                }                                if (num212 > num214 - num215 && num212 < num214 + num215)                                {                                    flag12 = false;                                }                                if (num210 > WorldGen.UndergroundDesertLocation.X && num210 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
                                {
                                    flag12 = false;
                                }
                                if (num211 > WorldGen.UndergroundDesertLocation.X && num211 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
                                {
                                    flag12 = false;
                                }
                                if (num212 > WorldGen.UndergroundDesertLocation.X && num212 < WorldGen.UndergroundDesertLocation.X + WorldGen.UndergroundDesertLocation.Width)
                                {
                                    flag12 = false;
                                }                                for (int num216 = num211; num216 < num212; num216++)                                {                                    for (int num217 = 0; num217 < (int)Main.worldSurface; num217 += 5)                                    {                                        if (Main.tile[num216, num217].active() && Main.tileDungeon[Main.tile[num216, num217].type])                                        {                                            flag12 = false;                                            break;                                        }                                        if (!flag12)                                        {                                            break;                                        }                                    }                                }                                if (num213 < 200 && jungleX > num211 && jungleX < num212)                                {                                    num213++;                                    flag12 = false;                                }                            }                           ContagionRunner(num210, (int)WorldGen.worldSurfaceLow - 10 + (Main.maxTilesY / 8));                            for (int num218 = num211; num218 < num212; num218++)                            {                                int num219 = (int)WorldGen.worldSurfaceLow;                                while (num219 < Main.worldSurface - 1.0)                                {                                    if (Main.tile[num218, num219].active())                                    {                                        int num220 = num219 + WorldGen.genRand.Next(10, 14);                                        for (int num221 = num219; num221 < num220; num221++)                                        {                                            if ((Main.tile[num218, num221].type == TileID.Mud || Main.tile[num218, num221].type == TileID.JungleGrass) && num218 >= num211 + WorldGen.genRand.Next(5) && num218 < num212 - WorldGen.genRand.Next(5))                                            {                                                Main.tile[num218, num221].type = TileID.Dirt;                                            }                                        }                                        break;                                    }                                    num219++;                                }                            }                            double num222 = Main.worldSurface + 40.0;                            for (int num223 = num211; num223 < num212; num223++)                            {                                num222 += WorldGen.genRand.Next(-2, 3);                                if (num222 < Main.worldSurface + 30.0)                                {                                    num222 = Main.worldSurface + 30.0;                                }                                if (num222 > Main.worldSurface + 50.0)                                {                                    num222 = Main.worldSurface + 50.0;                                }                                int num57 = num223;                                bool flag13 = false;                                int num224 = (int)WorldGen.worldSurfaceLow;                                while (num224 < num222)                                {                                    if (Main.tile[num57, num224].active())                                    {                                        if (Main.tile[num57, num224].type == TileID.Sand && num57 >= num211 + WorldGen.genRand.Next(5) && num57 <= num212 - WorldGen.genRand.Next(5))                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<Snotsand>();                                        }                                        if (Main.tile[num57, num224].type == TileID.Dirt && num224 < Main.worldSurface - 1.0 && !flag13)                                        {                                            grassSpread = 0;                                            WorldGen.SpreadGrass(num57, num224, 0, ModContent.TileType<Ickgrass>(), true, 0);                                        }                                        flag13 = true;                                        if (Main.tile[num57, num224].type == TileID.Stone && num57 >= num211 + WorldGen.genRand.Next(5) && num57 <= num212 - WorldGen.genRand.Next(5))                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<Chunkstone>();                                        }                                        if (Main.tile[num57, num224].type == TileID.Grass)                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<Ickgrass>();                                        }                                        if (Main.tile[num57, num224].type == TileID.IceBlock)                                        {                                            Main.tile[num57, num224].type = (ushort) ModContent.TileType<YellowIce>();                                        }                                        if (Main.tile[num57, num224].type == TileID.HardenedSand)                                        {                                            Main.tile[num57, num224].type = (ushort)ModContent.TileType<HardenedSnotsand>();                                        }                                        if (Main.tile[num57, num224].type == TileID.Sandstone)                                        {                                            Main.tile[num57, num224].type = (ushort)ModContent.TileType<Snotsandstone>();                                        }                                    }                                    num224++;                                }                            }                            int num225 = WorldGen.genRand.Next(10, 15);                            for (int num226 = 0; num226 < num225; num226++)                            {                                int num227 = 0;                                bool flag14 = false;                                int num228 = 0;                                while (!flag14)                                {                                    num227++;                                    int num229 = WorldGen.genRand.Next(num211 - num228, num212 + num228);                                    int num230 = WorldGen.genRand.Next((int)(Main.worldSurface - num228 / 2), (int)(Main.worldSurface + 100.0 + num228));                                    if (num227 > 100)                                    {                                        num228++;                                        num227 = 0;                                    }                                    if (!Main.tile[num229, num230].active())                                    {                                        while (!Main.tile[num229, num230].active())                                        {                                            num230++;                                        }                                        num230--;                                    }                                    else                                    {                                        while (Main.tile[num229, num230].active() && num230 > Main.worldSurface)                                        {                                            num230--;                                        }                                    }                                    if (num228 > 10 || (Main.tile[num229, num230 + 1].active() && Main.tile[num229, num230 + 1].type == TileID.Crimstone))                                    {                                        WorldGen.Place3x2(num229, num230, (ushort) ModContent.TileType<IckyAltar>());                                        if (Main.tile[num229, num230].type == (ushort) ModContent.TileType<IckyAltar>())                                        {                                            flag14 = true;                                        }                                    }                                    if (num228 > 100)                                    {                                        flag14 = true;                                    }                                }                            }                            num208++;                        }                    }                    else                    {                        corruptionPass.Apply(progress);                    }                });            }            var gems = tasks.FindIndex(genpass => genpass.Name == "Gems");            if (gems != -1)            {                tasks.Insert(gems + 1, new PassLegacy("Avalon Gems", delegate (GenerationProgress progress)                {                    for (var num284 = 69; num284 < 72; num284++)                    {                        var type8 = 0;                        float num285 = 0;                        if (num284 == 69)                        {                            type8 = ModContent.TileType<Tourmaline>();                            num285 = Main.maxTilesX * 0.2f;                        }                        else if (num284 == 70)                        {                            type8 = ModContent.TileType<Peridot>();                            num285 = Main.maxTilesX * 0.2f;                        }                        else if (num284 == 71)                        {                            type8 = ModContent.TileType<Zircon>();                            num285 = Main.maxTilesX * 0.2f;                        }                        num285 *= 0.2f;                        var num286 = 0;                        while (num286 < num285)                        {                            var num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                            var num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                            while (Main.tile[num287, num288].type != 1)                            {                                num287 = WorldGen.genRand.Next(0, Main.maxTilesX);                                num288 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);                            }                            WorldGen.TileRunner(num287, num288, WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 7), type8, false, 0f, 0f, false, true);                            num286++;                        }                    }                }));            }            var altarsTask = tasks.FindIndex(genpass => genpass.Name == "Altars");            if (altarsTask != -1)            {                altarPass = tasks[altarsTask];                tasks.RemoveAt(altarsTask);                tasks.Insert(altarsTask, new PassLegacy("Altars", delegate(GenerationProgress progress)                {                    if (contaigon)                    {                        progress.Message = Lang.gen[26].Value;                        int num = (int) (Main.maxTilesX * Main.maxTilesY * 1.99999994947575E-05);                        for (int index1 = 0; index1 < num; ++index1)                        {                            progress.Set(index1 / (float) num);                            for (int index2 = 0; index2 < 10000; ++index2)                            {                                int x = WorldGen.genRand.Next(1, Main.maxTilesX - 3);                                int y = (int) (WorldGen.worldSurfaceHigh + 20.0);                                WorldGen.Place3x2(x, y, ModContent.GetInstance<Tiles.IckyAltar>().Type);                                if (Main.tile[x, y].type == ModContent.GetInstance<Tiles.IckyAltar>().Type)                                    break;                            }                        }                    }                    else                    {                        altarPass.Apply(progress);                    }                }));            }            var smoothWorld = tasks.FindIndex(genpass => genpass.Name == "Smooth World");            if (smoothWorld != -1)            {                tasks.Insert(smoothWorld + 1, new PassLegacy("Unsmoothing Hellcastle", delegate (GenerationProgress progress)                {
                    int x = Main.maxTilesX / 3 - 210;
                    int y = Main.maxTilesY - 140;
                    //int x = Main.maxTilesX / 2;
                    //int y = 250;
                    for (int i = x; i <= x + 444; i++)
                    {
                        for (int j = y; j <= y + 99; j++)
                        {
                            if (Main.tile[i, j].type == (ushort)ModContent.TileType<Tiles.ResistantWoodPlatform>())
                            { }
                            else
                            {
                                Main.tile[i, j].slope(0);
                                Main.tile[i, j].halfBrick(false);
                            }
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
                            if (AddManaCrystal(WorldGen.genRand.Next(100, Main.maxTilesX - 100), WorldGen.genRand.Next((int)(WorldGen.worldSurfaceLow + 20.0), Main.maxTilesY - 300)))
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
                    }                }));            }            var iceWalls = tasks.FindIndex(genpass => genpass.Name == "Ice Walls");            if (iceWalls != -1)            {                tasks.Insert(iceWalls + 1, new PassLegacy("Avalon Ice Shrines", delegate (GenerationProgress progress)                {                    for (var num721 = 0; num721 < 3; num721++)                    {                        var x10 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);                        var y6 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);                        while (Main.tile[x10, y6].type == TileID.LihzahrdBrick) x10--;                        IceShrine(x10, y6);                    }                }));            }

            var weeds = tasks.FindIndex(genpass => genpass.Name == "Weeds");            if (weeds != -1)            {                tasks.Insert(weeds + 1, new PassLegacy("Contagion weeds", delegate (GenerationProgress progress)                {                    AddPlants();                }));            }

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
                        }                    }                }));            }            var microBiomes = tasks.FindIndex(genpass => genpass.Name == "Micro Biomes");            if (microBiomes != -1)            {                tasks.RemoveAt(microBiomes);                //tasks.Insert(microBiomes, new PassLegacy("Avalon Contaigon fix 1", delegate (GenerationProgress progress)
                //{
                //    if (contaigon) WorldGen.crimson = true;
                //}));                tasks.Insert(microBiomes + 1, new PassLegacy("Avalon Micro Biomes Fix", delegate (GenerationProgress progress)                {
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
                    if (!WorldGen.crimson && !contaigon)
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
                }));                tasks.Insert(microBiomes + 2, new PassLegacy("Replacing items in chests", delegate (GenerationProgress progress)                {                    foreach (Chest c in Main.chest)
                    {
                        if (c != null)
                        {
                            foreach (Item i in c.item)
                            {
                                if (i != null && i.type == ItemID.EnchantedBoomerang)
                                {
                                    i.SetDefaults(ModContent.ItemType<EnchantedBar>());
                                    i.stack = WorldGen.genRand.Next(35, 49);
                                }
                                if (i != null && i.type == ItemID.StaffofRegrowth && WorldGen.genRand.Next(2) == 0) i.SetDefaults(ModContent.ItemType<FlowerofTheJungle>());
                            }
                        }
                    }                }));            }        }        public static bool GrowHellTree(int i, int y)
        {
            int j;
            for (j = y; TileLoader.IsSapling(Main.tile[i, j].type); j--)
            {
            }
            if ((Main.tile[i - 1, j - 1].liquid != 0 || Main.tile[i, j - 1].liquid != 0 || Main.tile[i + 1, j - 1].liquid != 0) && Main.tile[i, j].type != 60)
            {
                return false;
            }
            if (Main.tile[i, j].nactive() && !Main.tile[i, j].halfBrick() && Main.tile[i, j].slope() == 0 && TileLoader.CanGrowModTree(Main.tile[i - 1, j].type) || TileLoader.CanGrowModTree(Main.tile[i + 1, j].type) || TileLoader.CanGrowModTree(Main.tile[i, j].type))
            {
                int num = 2;
                int maxTreeHeight = 16;
                if (WorldGen.EmptyTileCheck(i - num, i + num, j + maxTreeHeight, j + 1, TileID.Saplings))
                {
                    bool flag = false;
                    bool flag2 = false;
                    int heightOfTree = WorldGen.genRand.Next(5, maxTreeHeight + 1);
                    int num4;
                    for (int k = j + heightOfTree; k > j; k--)
                    {
                        Main.tile[i, k].frameNumber((byte)WorldGen.genRand.Next(3));
                        Main.tile[i, k].active(active: true);
                        Main.tile[i, k].type = 5;
                        num4 = WorldGen.genRand.Next(3);
                        int num5 = WorldGen.genRand.Next(10);
                        if (k == j + 1 || k == j + heightOfTree)
                        {
                            num5 = 0;
                        }
                        while (((num5 == 5 || num5 == 7) && flag) || ((num5 == 6 || num5 == 7) && flag2))
                        {
                            num5 = WorldGen.genRand.Next(10);
                        }
                        flag = false;
                        flag2 = false;
                        if (num5 == 5 || num5 == 7)
                        {
                            flag = true;
                        }
                        if (num5 == 6 || num5 == 7)
                        {
                            flag2 = true;
                        }
                        switch (num5)
                        {
                            case 1:
                                if (num4 == 0)
                                {
                                    Main.tile[i, k].frameX = 0;
                                    Main.tile[i, k].frameY = 176; // changed - 66
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 0;
                                    Main.tile[i, k].frameY = 154; // changed - 88
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 0;
                                    Main.tile[i, k].frameY = 132; // changed - 110
                                }
                                break;
                            case 2:
                                if (num4 == 0)
                                {
                                    Main.tile[i, k].frameX = 22;
                                    Main.tile[i, k].frameY = 242; // changed - 0
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 22;
                                    Main.tile[i, k].frameY = 220; // changed - 22
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 22;
                                    Main.tile[i, k].frameY = 198; // changed - 44
                                }
                                break;
                            case 3:
                                if (num4 == 0)
                                {
                                    Main.tile[i, k].frameX = 44;
                                    Main.tile[i, k].frameY = 176; // changed - 66
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 44;
                                    Main.tile[i, k].frameY = 154; // changed - 88
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 44;
                                    Main.tile[i, k].frameY = 132; // changed - 110
                                }
                                break;
                            case 4:
                                if (num4 == 0) // changed - 66 88 110
                                {
                                    Main.tile[i, k].frameX = 22;
                                    Main.tile[i, k].frameY = 176;
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 22;
                                    Main.tile[i, k].frameY = 154;
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 22;
                                    Main.tile[i, k].frameY = 132;
                                }
                                break;
                            case 5:
                                if (num4 == 0) // changed - 0 22 44
                                {
                                    Main.tile[i, k].frameX = 88;
                                    Main.tile[i, k].frameY = 242;
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 88;
                                    Main.tile[i, k].frameY = 220;
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 88;
                                    Main.tile[i, k].frameY = 198;
                                }
                                break;
                            case 6:
                                if (num4 == 0) // changed - 66 88 110
                                {
                                    Main.tile[i, k].frameX = 66;
                                    Main.tile[i, k].frameY = 176;
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 66;
                                    Main.tile[i, k].frameY = 154;
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 66;
                                    Main.tile[i, k].frameY = 132;
                                }
                                break;
                            case 7:
                                if (num4 == 0) // 66 88 110
                                {
                                    Main.tile[i, k].frameX = 110;
                                    Main.tile[i, k].frameY = 176;
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 110;
                                    Main.tile[i, k].frameY = 154;
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 110;
                                    Main.tile[i, k].frameY = 132;
                                }
                                break;
                            default:
                                if (num4 == 0) // 0 22 44
                                {
                                    Main.tile[i, k].frameX = 0;
                                    Main.tile[i, k].frameY = 242;
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i, k].frameX = 0;
                                    Main.tile[i, k].frameY = 220;
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i, k].frameX = 0;
                                    Main.tile[i, k].frameY = 198;
                                }
                                break;
                        }
                        if (num5 == 5 || num5 == 7)
                        {
                            Main.tile[i - 1, k].active(active: true);
                            Main.tile[i - 1, k].type = 5;
                            num4 = WorldGen.genRand.Next(3);
                            if (WorldGen.genRand.Next(3) < 2)
                            {
                                if (num4 == 0) // 198 220 242
                                {
                                    Main.tile[i - 1, k].frameX = 44;
                                    Main.tile[i - 1, k].frameY = 44;
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i - 1, k].frameX = 44;
                                    Main.tile[i - 1, k].frameY = 22;
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i - 1, k].frameX = 44;
                                    Main.tile[i - 1, k].frameY = 0;
                                }
                            }
                            else
                            {
                                if (num4 == 0) // 0 22 44
                                {
                                    Main.tile[i - 1, k].frameX = 66;
                                    Main.tile[i - 1, k].frameY = 242;
                                }
                                if (num4 == 1)
                                {
                                    Main.tile[i - 1, k].frameX = 66;
                                    Main.tile[i - 1, k].frameY = 220;
                                }
                                if (num4 == 2)
                                {
                                    Main.tile[i - 1, k].frameX = 66;
                                    Main.tile[i - 1, k].frameY = 198;
                                }
                            }
                        }
                        if (num5 != 6 && num5 != 7)
                        {
                            continue;
                        }
                        Main.tile[i + 1, k].active(active: true);
                        Main.tile[i + 1, k].type = 5;
                        num4 = WorldGen.genRand.Next(3);
                        if (WorldGen.genRand.Next(3) < 2)
                        {
                            if (num4 == 0) // 198 220 242
                            {
                                Main.tile[i + 1, k].frameX = 66;
                                Main.tile[i + 1, k].frameY = 44;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i + 1, k].frameX = 66;
                                Main.tile[i + 1, k].frameY = 22;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i + 1, k].frameX = 66;
                                Main.tile[i + 1, k].frameY = 0;
                            }
                        }
                        else
                        {
                            if (num4 == 0) // 66 88 110
                            {
                                Main.tile[i + 1, k].frameX = 88;
                                Main.tile[i + 1, k].frameY = 176;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i + 1, k].frameX = 88;
                                Main.tile[i + 1, k].frameY = 154;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i + 1, k].frameX = 88;
                                Main.tile[i + 1, k].frameY = 132;
                            }
                        }
                    }
                    int num6 = WorldGen.genRand.Next(3);
                    bool flag3 = false;
                    bool flag4 = false;
                    if (Main.tile[i - 1, j].nactive() && !Main.tile[i - 1, j].halfBrick() && Main.tile[i - 1, j].slope() == 0 && (Main.tile[i - 1, j].type == 2 || Main.tile[i - 1, j].type == 23 || Main.tile[i - 1, j].type == 60 || Main.tile[i - 1, j].type == 109 || Main.tile[i - 1, j].type == 147 || Main.tile[i - 1, j].type == 199 || TileLoader.CanGrowModTree(Main.tile[i - 1, j].type)))
                    {
                        flag3 = true;
                    }
                    if (Main.tile[i + 1, j].nactive() && !Main.tile[i + 1, j].halfBrick() && Main.tile[i + 1, j].slope() == 0 && (Main.tile[i + 1, j].type == 2 || Main.tile[i + 1, j].type == 23 || Main.tile[i + 1, j].type == 60 || Main.tile[i + 1, j].type == 109 || Main.tile[i + 1, j].type == 147 || Main.tile[i + 1, j].type == 199 || TileLoader.CanGrowModTree(Main.tile[i + 1, j].type)))
                    {
                        flag4 = true;
                    }
                    if (!flag3)
                    {
                        if (num6 == 0)
                        {
                            num6 = 2;
                        }
                        if (num6 == 1)
                        {
                            num6 = 3;
                        }
                    }
                    if (!flag4)
                    {
                        if (num6 == 0)
                        {
                            num6 = 1;
                        }
                        if (num6 == 2)
                        {
                            num6 = 3;
                        }
                    }
                    if (flag3 && !flag4)
                    {
                        num6 = 2;
                    }
                    if (flag4 && !flag3)
                    {
                        num6 = 1;
                    }
                    if (num6 == 0 || num6 == 1)
                    {
                        Main.tile[i + 1, j - 1].active(active: true);
                        Main.tile[i + 1, j - 1].type = 5;
                        num4 = WorldGen.genRand.Next(3);
                        if (num4 == 0) // 132 154 176
                        {
                            Main.tile[i + 1, j - 1].frameX = 22;
                            Main.tile[i + 1, j - 1].frameY = 110;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i + 1, j - 1].frameX = 22;
                            Main.tile[i + 1, j - 1].frameY = 88;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i + 1, j - 1].frameX = 22;
                            Main.tile[i + 1, j - 1].frameY = 66;
                        }
                    }
                    if (num6 == 0 || num6 == 2)
                    {
                        Main.tile[i - 1, j - 1].active(active: true);
                        Main.tile[i - 1, j - 1].type = 5;
                        num4 = WorldGen.genRand.Next(3);
                        if (num4 == 0) // 132 154 176
                        {
                            Main.tile[i - 1, j - 1].frameX = 44;
                            Main.tile[i - 1, j - 1].frameY = 110;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i - 1, j - 1].frameX = 44;
                            Main.tile[i - 1, j - 1].frameY = 88;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i - 1, j - 1].frameX = 44;
                            Main.tile[i - 1, j - 1].frameY = 66;
                        }
                    }
                    num4 = WorldGen.genRand.Next(3);
                    switch (num6)
                    {
                        case 0:
                            if (num4 == 0) // 132 154 176
                            {
                                Main.tile[i, j - 1].frameX = 88;
                                Main.tile[i, j - 1].frameY = 110;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, j - 1].frameX = 88;
                                Main.tile[i, j - 1].frameY = 88;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, j - 1].frameX = 88;
                                Main.tile[i, j - 1].frameY = 66;
                            }
                            break;
                        case 1:
                            if (num4 == 0) // 132 154 176
                            {
                                Main.tile[i, j - 1].frameX = 0;
                                Main.tile[i, j - 1].frameY = 110;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, j - 1].frameX = 0;
                                Main.tile[i, j - 1].frameY = 88;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, j - 1].frameX = 0;
                                Main.tile[i, j - 1].frameY = 66;
                            }
                            break;
                        case 2:
                            if (num4 == 0) // 132 154 176
                            {
                                Main.tile[i, j - 1].frameX = 66;
                                Main.tile[i, j - 1].frameY = 110;
                            }
                            if (num4 == 1)
                            {
                                Main.tile[i, j - 1].frameX = 66;
                                Main.tile[i, j - 1].frameY = 88;
                            }
                            if (num4 == 2)
                            {
                                Main.tile[i, j - 1].frameX = 66;
                                Main.tile[i, j - 1].frameY = 66;
                            }
                            break;
                    }
                    if (WorldGen.genRand.Next(8) != 0)
                    {
                        num4 = WorldGen.genRand.Next(3);
                        if (num4 == 0) // 198 220 242
                        {
                            Main.tile[i, j - heightOfTree].frameX = 22;
                            Main.tile[i, j - heightOfTree].frameY = 44;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i, j - heightOfTree].frameX = 22;
                            Main.tile[i, j - heightOfTree].frameY = 22;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i, j - heightOfTree].frameX = 22;
                            Main.tile[i, j - heightOfTree].frameY = 0;
                        }
                    }
                    else
                    {
                        num4 = WorldGen.genRand.Next(3);
                        if (num4 == 0) // 198 220 242
                        {
                            Main.tile[i, j - heightOfTree].frameX = 0;
                            Main.tile[i, j - heightOfTree].frameY = 44;
                        }
                        if (num4 == 1)
                        {
                            Main.tile[i, j - heightOfTree].frameX = 0;
                            Main.tile[i, j - heightOfTree].frameY = 22;
                        }
                        if (num4 == 2)
                        {
                            Main.tile[i, j - heightOfTree].frameX = 0;
                            Main.tile[i, j - heightOfTree].frameY = 0;
                        }
                    }
                    WorldGen.RangeFrame(i - 2, j + heightOfTree - 1, i + 2, j + 1);
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendTileSquare(-1, i, (int)((double)j - (double)heightOfTree * 0.5), heightOfTree + 1);
                    }
                    return true;
                }
            }
            return false;
        }        public void DropComet(int tile)        {            var flag = true;            var num = 0;            if (Main.netMode == NetmodeID.MultiplayerClient)            {                return;            }            for (var i = 0; i < 255; i++)            {                if (Main.player[i].active)                {                    flag = false;                    break;                }            }            var num2 = 0;            float num3 = Main.maxTilesX / 4200;            var num4 = (int)(400f * num3);            for (var j = 5; j < Main.maxTilesX - 5; j++)            {                var num5 = 5;                while (num5 < Main.worldSurface)                {                    if (Main.tile[j, num5].active() && Main.tile[j, num5].type == tile)                    {                        num2++;                        if (num2 > num4)                        {                            return;                        }                    }                    num5++;                }            }            while (!flag)            {                var num6 = Main.maxTilesX * 0.08f;                var num7 = Main.rand.Next(50, Main.maxTilesX - 50);                while (num7 > Main.spawnTileX - num6 && num7 < Main.spawnTileX + num6)                {                    num7 = Main.rand.Next(50, Main.maxTilesX - 50);                }                for (var k = Main.rand.Next(100); k < Main.maxTilesY; k++)                {                    if (Main.tile[num7, k].active() && Main.tileSolid[Main.tile[num7, k].type])                    {                        flag = Comet(num7, k, tile);                        break;                    }                }                num++;                if (num >= 100)                {                    return;                }            }        }        public static void GenerateHellcastle_old(int x, int y)
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
                        Main.tile[noHellHousesX, noHellHousesY].type == TileID.Bookcases || Main.tile[noHellHousesX, noHellHousesY].type == 89)
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
        public static void MakeWallRectangle(int x, int y, int width, int height, ushort type)
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
                    int num2 = WorldGen.PlaceChest(i - 1, num - 1, (ushort)ModContent.TileType<Tiles.ResistantWoodChest>(), notNearOtherChests);
                    if (num2 >= 0)
                    {
                        int num3 = 0;
                        while (num3 == 0)
                        {
                            Main.chest[num2].item[0].SetDefaults(contain, false);
                            Main.chest[num2].item[0].Prefix(-1);
                            if (contain == ModContent.ItemType<Items.CaesiumBar>() || contain == ModContent.ItemType<Items.SolariumStar>()) Main.chest[num2].item[0].stack = WorldGen.genRand.Next(20, 31);
                            if (contain == ModContent.ItemType<Items.EarthStone>()) Main.chest[num2].item[0].stack = WorldGen.genRand.Next(2, 6);
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
                                Main.chest[num2].item[4].SetDefaults(ModContent.ItemType<Items.VampireTeeth>(), false);
                                Main.chest[num2].item[4].Prefix(-2);
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
        }        public bool Comet(int i, int j, int tile)        {            if (i < 50 || i > Main.maxTilesX - 50)            {                return false;            }            if (j < 50 || j > Main.maxTilesY - 50)            {                return false;            }            var num = 25;            var rectangle = new Rectangle((i - num) * 16, (j - num) * 16, num * 2 * 16, num * 2 * 16);            for (var k = 0; k < 255; k++)            {                if (Main.player[k].active)                {                    var value = new Rectangle((int)(Main.player[k].position.X + Main.player[k].width / 2 - NPC.sWidth / 2 - NPC.safeRangeX), (int)(Main.player[k].position.Y + Main.player[k].height / 2 - NPC.sHeight / 2 - NPC.safeRangeY), NPC.sWidth + NPC.safeRangeX * 2, NPC.sHeight + NPC.safeRangeY * 2);                    if (rectangle.Intersects(value))                    {                        return false;                    }                }            }            for (var l = 0; l < 200; l++)            {                if (Main.npc[l].active)                {                    var value2 = new Rectangle((int)Main.npc[l].position.X, (int)Main.npc[l].position.Y, Main.npc[l].width, Main.npc[l].height);                    if (rectangle.Intersects(value2))                    {                        return false;                    }                }            }            for (var m = i - num; m < i + num; m++)            {                for (var n = j - num; n < j + num; n++)                {                    if (Main.tile[m, n].active() && Main.tile[m, n].type == 21 || Main.tile[m, n].type == TileID.Containers2)                    {                        return false;                    }                }            }            stopCometDrops = true;            num = 15;            for (var num2 = i - num; num2 < i + num; num2++)            {                for (var num3 = j - num; num3 < j + num; num3++)                {                    if (num3 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num2) + Math.Abs(j - num3) < num * 1.5 + Main.rand.Next(-5, 5))                    {                        if (!Main.tileSolid[Main.tile[num2, num3].type])                        {                            Main.tile[num2, num3].active(false);                        }                        Main.tile[num2, num3].type = (ushort) tile;                    }                }            }            num = 10;            for (var num4 = i - num; num4 < i + num; num4++)            {                for (var num5 = j - num; num5 < j + num; num5++)                {                    if (num5 > j + Main.rand.Next(-2, 3) - 5 && Math.Abs(i - num4) + Math.Abs(j - num5) < num + Main.rand.Next(-3, 4))                    {                        Main.tile[num4, num5].active(false);                    }                }            }            num = 16;            for (var num6 = i - num; num6 < i + num; num6++)            {                for (var num7 = j - num; num7 < j + num; num7++)                {                    if (Main.tile[num6, num7].type == 5 || Main.tile[num6, num7].type == 32)                    {                        WorldGen.KillTile(num6, num7, false, false, false);                    }                    WorldGen.SquareTileFrame(num6, num7, true);                    WorldGen.SquareWallFrame(num6, num7, true);                }            }            num = 23;            for (var num8 = i - num; num8 < i + num; num8++)            {                for (var num9 = j - num; num9 < j + num; num9++)                {                    if (Main.tile[num8, num9].active() && Main.rand.Next(10) == 0 && Math.Abs(i - num8) + Math.Abs(j - num9) < num * 1.3)                    {                        if (Main.tile[num8, num9].type == 5 || Main.tile[num8, num9].type == 32)                        {                            WorldGen.KillTile(num8, num9, false, false, false);                        }                        Main.tile[num8, num9].type = (ushort) tile;                        WorldGen.SquareTileFrame(num8, num9, true);                    }                }            }            stopCometDrops = false;            if (Main.netMode == NetmodeID.SinglePlayer)            {                Main.NewText("A comet has struck ground!", 0, 201, 190, false);            }            else if (Main.netMode == NetmodeID.Server)            {                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("A comet has struck ground!"), new Color(0, 201, 190));            }            if (Main.netMode != NetmodeID.MultiplayerClient)            {                NetMessage.SendTileSquare(-1, i, j, 30);            }            return true;        }        public static void InitiateSuperHardmode()        {            ThreadPool.QueueUserWorkItem(new WaitCallback(shmCallback), 1);        }
        public static void shmCallback(object threadContext)
        {
            if (ExxoAvalonOrigins.superHardmode) return;
            SpawnOblivionOreAndOpals();
            ExxoAvalonOrigins.superHardmode = true;            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("The ancient souls have been disturbed...", 255, 60, 0);
                Main.NewText("The heavens above are rumbling...", 50, 255, 130);
                Main.NewText("Your world has been blessed with the elements!", 0, 255, 0);
            }
            else if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The ancient souls have been disturbed..."), new Color(255, 60, 0));
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The heavens above are rumbling..."), new Color(50, 255, 130));
                NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your world has been blessed with the elements!"), new Color(0, 255, 0));
            }            if (Main.netMode == NetmodeID.Server)
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
        }        public override TagCompound Save()        {            var toSave = new TagCompound            {                { "ExxoAvalonOrigins:LastOpenedVersion", ExxoAvalonOrigins.version.ToString() },                { "ExxoAvalonOrigins:SuperHardMode", ExxoAvalonOrigins.superHardmode },                { "ExxoAvalonOrigins:DownedBacteriumPrime", downedBacteriumPrime },                { "ExxoAvalonOrigins:DownedDesertBeak", downedDesertBeak },                { "ExxoAvalonOrigins:DownedPhantasm", downedPhantasm },                { "ExxoAvalonOrigins:DownedDragonLord", downedDragonLord },                { "ExxoAvalonOrigins:DownedMechasting", downedMechasting },                { "ExxoAvalonOrigins:DownedOblivion", downedOblivion },                { "ExxoAvalonOrigins:LibraryofKnowledge", LoK },                { "ExxoAvalonOrigins:Contagion", contaigon },                { "ExxoAvalonOrigins:DungeonSide", dungeonSide },                { "ExxoAvalonOrigins:DungeonX", ExxoAvalonOrigins.dungeonEx },                { "ExxoAvalonOrigins:SHMOreTier1", shmOreTier1 },                { "ExxoAvalonOrigins:SHMOreTier2", shmOreTier2 },
                { "ExxoAvalonOrigins:HallowAltarCount", hallowAltarCount }            };            return toSave;        }        public override void Load(TagCompound tag)        {            if (tag.ContainsKey("ExxoAvalonOrigins:LastOpenedVersion"))            {                ExxoAvalonOrigins.lastOpenedVersion = new Version(tag["ExxoAvalonOrigins:LastOpenedVersion"].ToString());            }            if (tag.ContainsKey("ExxoAvalonOrigins:SuperHardMode"))            {                ExxoAvalonOrigins.superHardmode = tag.Get<bool>("ExxoAvalonOrigins:SuperHardMode");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DownedBacteriumPrime"))            {                downedBacteriumPrime = tag.Get<bool>("ExxoAvalonOrigins:DownedBacteriumPrime");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DownedDesertBeak"))            {                downedDesertBeak = tag.Get<bool>("ExxoAvalonOrigins:DownedDesertBeak");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DownedPhantasm"))            {                downedPhantasm = tag.Get<bool>("ExxoAvalonOrigins:DownedPhantasm");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DownedDragonLord"))            {                downedDragonLord = tag.Get<bool>("ExxoAvalonOrigins:DownedDragonLord");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DownedMechasting"))            {                downedMechasting = tag.Get<bool>("ExxoAvalonOrigins:DownedMechasting");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DownedOblivion"))            {                downedOblivion = tag.Get<bool>("ExxoAvalonOrigins:DownedOblivion");            }            if (tag.ContainsKey("ExxoAvalonOrigins:LibraryofKnowledge"))            {                LoK = tag.Get<Vector2>("ExxoAvalonOrigins:LibraryofKnowledge");            }            if (tag.ContainsKey("ExxoAvalonOrigins:Contagion"))            {                contaigon = tag.Get<bool>("ExxoAvalonOrigins:Contagion");            }            if (tag.ContainsKey("ExxoAvalonOrigins:DungeonSide"))
            {
                dungeonSide = tag.GetAsInt("ExxoAvalonOrigins:DungeonSide");
            }            else            {
                dungeonSide = -1;
            }            if (tag.ContainsKey("ExxoAvalonOrigins:DungeonX"))            {                ExxoAvalonOrigins.dungeonEx = tag.GetAsInt("ExxoAvalonOrigins:DungeonX");            }            else
            {
                ExxoAvalonOrigins.dungeonEx = dungeonSide == -1 ? Main.maxTilesX / 3 : Main.maxTilesX - Main.maxTilesX / 3;
            }            if (tag.ContainsKey("ExxoAvalonOrigins:SHMOreTier1"))            {                shmOreTier1 = tag.GetAsInt("ExxoAvalonOrigins:SHMOreTier1");            }            if (tag.ContainsKey("ExxoAvalonOrigins:SHMOreTier2"))            {                shmOreTier2 = tag.GetAsInt("ExxoAvalonOrigins:SHMOreTier2");            }            if (tag.ContainsKey("ExxoAvalonOrigins:HallowAltarCount"))            {                hallowAltarCount = tag.GetAsInt("ExxoAvalonOrigins:HallowAltarCount");            }        }        public static void GenerateHearts(int i, int j, int tile)        {            var num = WorldGen.genRand.Next(2);            if (num == 0)            {                num = 1;            }            else if (num == 1)            {                num = 3;            }            if (WorldGen.genRand.Next(20) == 0)            {                num = 5;            }            var num2 = 1;            Main.tile[i, j + 1].active(true);            Main.tile[i, j + 1].type = (ushort) tile;            WorldGen.SquareTileFrame(i, j + 1);            for (var k = j; k >= j - num; k--)            {                for (var l = i - num2; l <= i + num2; l++)                {                    if ((l != i - num2 && l != i + num2) || num2 != num + 1)                    {                        Main.tile[l, k].active(true);                        Main.tile[l, k].type = (ushort) tile;                        WorldGen.SquareTileFrame(l, k);                    }                }                num2++;            }            for (var m = i - num2 + 1; m <= i + num2 - 1; m++)            {                Main.tile[m, j - num - 1].active(true);                Main.tile[m, j - num - 1].type = (ushort) tile;                WorldGen.SquareTileFrame(m, j + num + 1);            }            for (var n = i - num2 + 2; n <= i + num2 - 2; n++)            {                if (n != i)                {                    Main.tile[n, j - num - 2].active(true);                    Main.tile[n, j - num - 2].type = (ushort) tile;                    WorldGen.SquareTileFrame(n, j + num + 2);                }            }            for (var num3 = i - num2 + 3; num3 <= i + num2 - 3; num3++)            {                if (num3 != i && num3 != i + 1 && num3 != i - 1)                {                    Main.tile[num3, j - num - 3].active(true);                    Main.tile[num3, j - num - 3].type = (ushort) tile;                    WorldGen.SquareTileFrame(num3, j + num + 3);                }            }        }        public static void IceShrine(int x, int y)
        {
            int mult = 2;
            int rn = WorldGen.genRand.Next(3);
            int width = 0;
            int mod1 = WorldGen.genRand.Next(9, 13);
            switch (rn)
            {
                case 0: width = 6; break;
                case 1: width = 8; break;
                case 2: width = 10; break;
            }
            #region walls/other
            for (int fX = x - width - mult * 4 + 3; fX <= x + mult * 4 + 1 + width; fX++)
            {
                for (int fY = y + mult + 4; fY <= y + 13 + mod1; fY++)
                {
                    Main.tile[fX, fY].liquid = 0;
                    Main.tile[fX, fY].lava(false);
                    Main.tile[fX, fY].honey(false);
                    Main.tile[fX, fY].active(false);
                    if (fY <= y + 10 + mod1 && fY >= y + 7)
                    {
                        if (fX > x + mult * 4 + 6 - width && fX < x + mult * 4 + 6 ||
                            fX > x - mult * 4 - 1 && fX < x - mult * 4 + width - 2)
                        {
                            Main.tile[fX, fY].type = 0;
                            Main.tile[fX, fY].wall = WallID.IceBrick;
                            WorldGen.SquareWallFrame(fX, fY);
                        }
                        if (fX > x + mult * 4 + 6 - 2 * width + 2 && fX < x + mult * 4 + 6 - width + 2 ||
                            fX > x - mult * 4 + width - 3 && fX < x - mult * 4 + 2 * width - 4)
                        {
                            Main.tile[fX, fY].type = 0;
                            Main.tile[fX, fY].wall = WallID.IceBrick;
                            WorldGen.SquareWallFrame(fX, fY);
                        }
                        if (fX <= x + mult * 4 + 6 - 2 * width + 2 && fX >= x - mult * 4 + 2 * width - 4)
                        {
                            Main.tile[fX, fY].type = 0;
                            Main.tile[fX, fY].wall = WallID.IceBrick;
                            WorldGen.SquareWallFrame(fX, fY);
                        }
                    }
                }
            }
            for (int fX = x - width - mult * 4 + 2; fX <= x + mult * 4 + 1 + width; fX++)
            {
                for (int fY = y + mult + 4; fY <= y + 13 + mod1; fY++)
                {
                    if (Main.tile[fX, fY].type > 0) Main.tile[fX, fY].active(true);
                }
            }
            #endregion
            #region tower1
            for (int tower1X = x - mult * 4; tower1X >= x - width - mult * 4; tower1X--)
            {
                if (tower1X % 2 == 0)
                {
                    Main.tile[tower1X, y].active(true);
                    Main.tile[tower1X, y].type = TileID.IceBrick;
                    SquareTileFrame(tower1X, y, resetSlope: true);
                }
                if (tower1X > x - width - mult * 4 && tower1X < x - mult * 4)
                {
                    Main.tile[tower1X, y + 4].active(true);
                    Main.tile[tower1X, y + 4].type = TileID.IceBrick;
                    SquareTileFrame(tower1X, y + 4, resetSlope: true);
                }
                if (tower1X > x - width - mult * 4 + 1 && tower1X < x - mult * 4)
                {
                    for (int wallTY = y + 9; wallTY <= y + 9 + mod1; wallTY++)
                    {
                        if (tower1X > x - width - mult * 4 && tower1X < x - mult * 4 + 1)
                        {
                            Main.tile[tower1X, wallTY].active(false);
                            Main.tile[tower1X, wallTY].wall = WallID.IceBrick;
                            WorldGen.SquareWallFrame(tower1X, wallTY);
                        }
                    }
                    Main.tile[tower1X, y + 5].active(true);
                    Main.tile[tower1X, y + 5].type = TileID.IceBrick;
                    SquareTileFrame(tower1X, y + 5, resetSlope: true);
                    Main.tile[tower1X, y + 8].active(true);
                    Main.tile[tower1X, y + 8].type = TileID.IceBrick;
                    SquareTileFrame(tower1X, y + 8, resetSlope: true);
                    if (tower1X < x - mult * 4 - 1)
                    {
                        Main.tile[tower1X, y + 9].active(true);
                        Main.tile[tower1X, y + 9].type = TileID.IceBrick;
                        SquareTileFrame(tower1X, y + 9, resetSlope: true);
                    }
                    if (tower1X < x - mult * 4 - 2)
                    {
                        Main.tile[tower1X, y + 10].active(true);
                        Main.tile[tower1X, y + 10].type = TileID.IceBrick;
                        SquareTileFrame(tower1X, y + 10, resetSlope: true);
                    }
                    Main.tile[tower1X, y + 9 + mod1].active(true);
                    Main.tile[tower1X, y + 9 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(tower1X, y + 9 + mod1, resetSlope: true);
                    Main.tile[tower1X, y + 10 + mod1].active(true);
                    Main.tile[tower1X, y + 10 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(tower1X, y + 10 + mod1, resetSlope: true);
                }
                for (int tower1Y = y + 1; tower1Y <= y + 1 + mult; tower1Y++)
                {
                    Main.tile[tower1X, tower1Y].active(true);
                    Main.tile[tower1X, tower1Y].type = TileID.IceBrick;
                    SquareTileFrame(tower1X, tower1Y, resetSlope: true);
                }
            }
            #endregion
            #region tower2
            for (int tower2X = x + mult * 4 + 4; tower2X <= x + width + mult * 4 + 4; tower2X++)
            {
                if (tower2X % 2 == 0)
                {
                    Main.tile[tower2X, y].active(true);
                    Main.tile[tower2X, y].type = TileID.IceBrick;
                    SquareTileFrame(tower2X, y, resetSlope: true);
                }
                if (tower2X < x + width + mult * 4 + 4 && tower2X > x + 4 + mult * 4)
                {
                    Main.tile[tower2X, y + 4].active(true);
                    Main.tile[tower2X, y + 4].type = TileID.IceBrick;
                    SquareTileFrame(tower2X, y + 4, resetSlope: true);
                }
                if (tower2X < x + width + mult * 4 + 3 && tower2X > x + mult * 4 + 4)
                {
                    for (int wallTY = y + 10; wallTY <= y + 10 + mod1 - 1; wallTY++)
                    {
                        if (tower2X < x + width + mult * 4 + 2 && tower2X > x + mult * 4 + 5)
                        {
                            Main.tile[tower2X, wallTY].active(false);
                            Main.tile[tower2X, wallTY].wall = WallID.IceBrick;
                            WorldGen.SquareWallFrame(tower2X, wallTY);
                        }
                    }
                    Main.tile[tower2X, y + 5].active(true);
                    Main.tile[tower2X, y + 5].type = TileID.IceBrick;
                    SquareTileFrame(tower2X, y + 5, resetSlope: true);
                    Main.tile[tower2X, y + 8].active(true);
                    Main.tile[tower2X, y + 8].type = TileID.IceBrick;
                    SquareTileFrame(tower2X, y + 8, resetSlope: true);
                    if (tower2X > x + mult * 4 + 5)
                    {
                        Main.tile[tower2X, y + 9].active(true);
                        Main.tile[tower2X, y + 9].type = TileID.IceBrick;
                        SquareTileFrame(tower2X, y + 9, resetSlope: true);
                    }
                    if (tower2X > x + mult * 4 + 6)
                    {
                        Main.tile[tower2X, y + 10].active(true);
                        Main.tile[tower2X, y + 10].type = TileID.IceBrick;
                        SquareTileFrame(tower2X, y + 10, resetSlope: true);
                    }
                    Main.tile[tower2X, y + 9 + mod1].active(true);
                    Main.tile[tower2X, y + 9 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(tower2X, y + 9 + mod1, resetSlope: true);
                    Main.tile[tower2X, y + 10 + mod1].active(true);
                    Main.tile[tower2X, y + 10 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(tower2X, y + 10 + mod1, resetSlope: true);
                }
                for (int tower2Y = y + 1; tower2Y <= y + 1 + mult; tower2Y++)
                {
                    Main.tile[tower2X, tower2Y].active(true);
                    Main.tile[tower2X, tower2Y].type = TileID.IceBrick;
                    SquareTileFrame(tower2X, tower2Y, resetSlope: true);
                }
            }
            #endregion
            #region pyramid
            int pstep = 1;
            for (int pyY = y; pyY <= y + mult + 4; pyY++)
            {
                for (int pyX = x - pstep + 1; pyX <= x + pstep + 1; pyX++)
                {
                    Main.tile[pyX + 1, pyY].active(true);
                    Main.tile[pyX + 1, pyY].type = TileID.IceBrick;
                    SquareTileFrame(pyX + 1, pyY, resetSlope: true);
                    if (pyY >= y + mult + 4 && pyY <= y + mult + 8 + mod1 && (pyX == x - pstep + 3 || pyX == x + pstep + 1))
                    {
                        Main.tile[pyX, pyY + mod1].active(true);
                        Main.tile[pyX, pyY + mod1].type = TileID.WoodenBeam;
                        SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                        if (pyY == y + mult + 4)
                        {
                            Main.tile[pyX, pyY + mod1].active(true);
                            Main.tile[pyX, pyY + mod1].type = TileID.IceBrick;
                            SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                        }
                    }
                    if (pyY == y + mult + 4 && (pyX == x - pstep + 2))
                    {
                        Main.tile[pyX, pyY + mod1].active(true);
                        Main.tile[pyX, pyY + mod1].type = 4;
                        Main.tile[pyX, pyY + mod1].frameY = 198;
                        SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                    }
                    if (pyY == y + mult + 4 && (pyX >= x - pstep + 4 && pyX <= x + pstep))
                    {
                        Main.tile[pyX, pyY + mod1].active(true);
                        Main.tile[pyX, pyY + mod1].type = 19;
                        Main.tile[pyX, pyY + mod1].frameY = 0;
                        SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                    }
                    if (pyY >= y + 3 && pyY <= y + 4 && (pyX >= x - 1 && pyX <= x + 5))
                    {
                        Main.tile[pyX, pyY].type = TileID.IceBlock;
                        SquareTileFrame(pyX, pyY, resetSlope: true);
                    }
                }
                pstep++;
            }
            Main.tile[x + 9, y + mult + 4 + mod1].active(true);
            Main.tile[x + 9, y + mult + 4 + mod1].type = 4;
            Main.tile[x + 9, y + mult + 4 + mod1].frameY = 198;
            SquareTileFrame(x + 12, y + mult + 4 + mod1, resetSlope: true);
            #endregion
            #region base
            for (int baseX = x - width - mult * 4 + 2; baseX <= x + mult * 4 + 2 + width; baseX++)
            {
                Main.tile[baseX, y + 6].active(true);
                Main.tile[baseX, y + 6].type = TileID.IceBrick;
                SquareTileFrame(baseX, y + 6, resetSlope: true);
                Main.tile[baseX, y + 7].active(true);
                Main.tile[baseX, y + 7].type = TileID.IceBrick;
                SquareTileFrame(baseX, y + 7, resetSlope: true);
                if (baseX > x + mult * 4 + 6 - width && baseX < x + mult * 4 + 6 ||
                    baseX > x - mult * 4 - 2 && baseX < x - mult * 4 + width - 2)
                {
                    Main.tile[baseX, y + 10 + mod1].active(true);
                    Main.tile[baseX, y + 10 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(baseX, y + 10 + mod1, resetSlope: true);
                    Main.tile[baseX, y + 11 + mod1].active(true);
                    Main.tile[baseX, y + 11 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(baseX, y + 11 + mod1, resetSlope: true);
                }
                if (baseX > x + mult * 4 + 6 - 2 * width + 2 && baseX < x + mult * 4 + 6 - width + 2 ||
                    baseX > x - mult * 4 + width - 4 && baseX < x - mult * 4 + 2 * width - 4)
                {
                    Main.tile[baseX, y + 11 + mod1].active(true);
                    Main.tile[baseX, y + 11 + mod1].type = TileID.IceBrick;
                    Main.tile[baseX, y + 11 + mod1].liquid = 0;
                    SquareTileFrame(baseX, y + 11 + mod1, resetSlope: true);
                    Main.tile[baseX, y + 12 + mod1].active(true);
                    Main.tile[baseX, y + 12 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(baseX, y + 12 + mod1, resetSlope: true);
                }
                if (baseX < x + mult * 4 + 8 - 2 * width + 2 && baseX > x - mult * 4 + 2 * width - 6)
                {
                    Main.tile[baseX, y + 12 + mod1].active(true);
                    Main.tile[baseX, y + 12 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(baseX, y + 12 + mod1, resetSlope: true);
                    Main.tile[baseX, y + 13 + mod1].wall = 0;
                    Main.tile[baseX, y + 13 + mod1].active(true);
                    Main.tile[baseX, y + 13 + mod1].type = TileID.IceBrick;
                    SquareTileFrame(baseX, y + 13 + mod1, resetSlope: true);
                }
                if (baseX == x - width - mult * 4 + 2 || baseX == x + mult * 4 + 2 + width)
                {
                    for (int s = 6; s <= 6 + mod1; s++)
                    {
                        Main.tile[baseX, y + mult + s].wall = 0;
                        Main.tile[baseX, y + mult + s].active(true);
                        Main.tile[baseX, y + mult + s].type = TileID.IceBrick;
                        Main.tile[baseX, y + mult + s].halfBrick(false);
                        Main.tile[baseX, y + mult + s].slope(0);
                        WorldGen.SquareTileFrame(baseX, y + mult + s);
                    }
                }
                if (baseX == x - width - mult * 4 + 3 || baseX == x + mult * 4 + 2 + width - 1)
                {
                    for (int s = 6; s <= 6 + mod1 - 3; s++)
                    {
                        Main.tile[baseX, y + mult + s].wall = 0;
                        Main.tile[baseX, y + mult + s].active(true);
                        Main.tile[baseX, y + mult + s].type = TileID.IceBrick;
                        Main.tile[baseX, y + mult + s].halfBrick(false);
                        Main.tile[baseX, y + mult + s].slope(0);
                        WorldGen.SquareTileFrame(baseX, y + mult + s);
                    }
                }
            }
            #endregion
            #region other schtuff
            int paintingType = 242;
            int stylez = Main.rand.Next(5);
            if (stylez == 0) stylez = 4;
            else if (stylez == 1) stylez = 6;
            else if (stylez == 2) stylez = 11;
            else if (stylez == 3) stylez = 15;
            else if (stylez == 4)
            {
                stylez = 8;
                paintingType = ModContent.TileType<Paintings>();
            }
            int stylez2 = Main.rand.Next(5);
            if (stylez2 == 0) stylez2 = 12;
            else if (stylez2 == 1) stylez2 = 10;
            else if (stylez2 == 2) stylez2 = 9;
            else if (stylez2 == 3)
            {
                stylez2 = 0;
                paintingType = ModContent.TileType<Paintings>();
            }
            else if (stylez2 == 4)
            {
                stylez2 = 5;
                paintingType = ModContent.TileType<Paintings>();
            }
            WorldGen.PlaceTile(x - 7, y + 9 + mod1, 89, style: 27);
            WorldGen.PlaceTile(x + 11, y + 9 + mod1, 89, style: 27);
            WorldGen.PlaceTile(x + 1, y + 10 + mod1, 93, style: 5);
            WorldGen.PlaceTile(x + 3, y + 10 + mod1, 93, style: 5);
            AddIceShrineChest(x, y + mult + 4 + mod1 - 2, 0, false, 1);
            AddIceShrineChest(x + 5, y + mult + 4 + mod1 - 2, 0, false, 1);
            WorldGen.PlaceTile(x - 2, y + mult + 4 + mod1 - 3, 105, style: 54);
            WorldGen.PlaceTile(x + 7, y + mult + 4 + mod1 - 3, 105, style: 54);
            WorldGen.Place6x4Wall(x + 8, y + 10, (ushort)paintingType, stylez);
            WorldGen.Place6x4Wall(x - 5, y + 10, (ushort)paintingType, stylez2);
            WorldGen.PlaceDoor(x - width - mult * 4 + 2, y + 6 + mod1 + 1, 10, 30);
            WorldGen.PlaceDoor(x + width + mult * 4 + 2, y + 6 + mod1 + 1, 10, 30);
            #endregion
        }        public static bool AddIceShrineChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)        {            var k = j;            while (k < Main.maxTilesY)            {                if (Main.tile[i, k].active() && Main.tileSolid[Main.tile[i, k].type])                {                    var num = k;                    var num2 = WorldGen.PlaceChest(i - 1, num - 1, 21, notNearOtherChests, 11);                    if (num2 >= 0)                    {                        for (var num3 = 0; num3 == 0; num3++)                        {                            var num4 = WorldGen.genRand.Next(19);                            if (num4 >= 0 && num4 <= 6)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.BlizzardinaBottle, false);                                Main.chest[num2].item[0].Prefix(-1);                            }                            else if (num4 >= 7 && num4 <= 13)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.PoisonedKnife, false);                                Main.chest[num2].item[0].stack = WorldGen.genRand.Next(34, 79);                            }                            else if (num4 >= 14 && num4 <= 17)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.IceBlade, false);                                Main.chest[num2].item[0].Prefix(-1);                            }                            else if (num4 == 18)                            {                                Main.chest[num2].item[0].SetDefaults(ItemID.IceSkates, false);                                Main.chest[num2].item[0].Prefix(-1);                            }                            Main.chest[num2].item[1].SetDefaults(ItemID.GoldCoin, false);                            Main.chest[num2].item[1].stack = WorldGen.genRand.Next(60, 82);                            var num5 = WorldGen.genRand.Next(5);                            if (num5 == 0)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.LesserRestorationPotion, false);                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(3, 7);                            }                            if (num5 == 1)                            {                                Main.chest[num2].item[2].SetDefaults(theBeak, false);                                Main.chest[num2].item[2].stack = 1;                            }                            if (num5 == 2)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.SlushBlock, false);                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(200, 451);                            }                            if (num5 == 3)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.IceBrick, false);                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(30, 73);                            }                            if (num5 == 4)                            {                                Main.chest[num2].item[2].SetDefaults(ItemID.HandWarmer, false);                                Main.chest[num2].item[2].Prefix(-1);                            }                        }                        return true;                    }                    return false;                }                else                {                    k++;                }            }            return false;        }        public static void SquareTileFrame(int i, int j, bool resetFrame = true, bool resetSlope = false, bool largeHerb = false)        {            if (resetSlope)            {                Main.tile[i, j].slope(0);                Main.tile[i, j].halfBrick(false);            }            WorldGen.TileFrame(i - 1, j - 1, false, largeHerb);            WorldGen.TileFrame(i - 1, j, false, largeHerb);            WorldGen.TileFrame(i - 1, j + 1, false, largeHerb);            WorldGen.TileFrame(i, j - 1, false, largeHerb);            WorldGen.TileFrame(i, j, resetFrame, largeHerb);            WorldGen.TileFrame(i, j + 1, false, largeHerb);            WorldGen.TileFrame(i + 1, j - 1, false, largeHerb);            WorldGen.TileFrame(i + 1, j, false, largeHerb);            WorldGen.TileFrame(i + 1, j + 1, false, largeHerb);        }        /// <summary>
        /// A helper method to run WorldGen.SquareTileFrame() over an area.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="r">The radius.</param>
        /// <param name="lh">Whether or not to use Large Herb logic.</param>        public static void SquareTileFrameArea(int x, int y, int r, bool lh = false)        {            for (var i = x - r; i < x + r; i++)            {                for (var j = y - r; j < y + r; j++)                {                    SquareTileFrame(i, j, true, lh);                }            }        }        public static void AvalonSpreadGrass(int i, int j, int dirt = 0, int grass = 2, bool repeat = true, byte color = 0)        {            try            {                if (WorldGen.InWorld(i, j, 1))                {                    if ((int)Main.tile[i, j].type == dirt && Main.tile[i, j].active() && ((double)j < Main.worldSurface || dirt != 0))                    {                        int num = i - 1;                        int num2 = i + 2;                        int num3 = j - 1;                        int num4 = j + 2;                        if (num < 0)                        {                            num = 0;                        }                        if (num2 > Main.maxTilesX)                        {                            num2 = Main.maxTilesX;                        }                        if (num3 < 0)                        {                            num3 = 0;                        }                        if (num4 > Main.maxTilesY)                        {                            num4 = Main.maxTilesY;                        }                        bool flag = true;                        for (int k = num; k < num2; k++)                        {                            for (int l = num3; l < num4; l++)                            {                                if (!Main.tile[k, l].active() || !Main.tileSolid[(int)Main.tile[k, l].type])                                {                                    flag = false;                                }                                if (Main.tile[k, l].lava() && Main.tile[k, l].liquid > 0)                                {                                    flag = true;                                    break;                                }                            }                        }                        if (!flag && TileID.Sets.CanBeClearedDuringGeneration[(int)Main.tile[i, j].type])                        {                            if (grass != 23 || Main.tile[i, j - 1].type != 27)                            {                                if (grass != 199 || Main.tile[i, j - 1].type != 27)                                {                                    Main.tile[i, j].type = (ushort)grass;                                    Main.tile[i, j].color(color);                                    for (int m = num; m < num2; m++)                                    {                                        for (int n = num3; n < num4; n++)                                        {                                            if (Main.tile[m, n].active() && (int)Main.tile[m, n].type == dirt)                                            {                                                try                                                {                                                    if (repeat && grassSpread < 1000)                                                    {                                                        grassSpread++;                                                        AvalonSpreadGrass(m, n, dirt, grass, true, 0);                                                        grassSpread--;                                                    }                                                }                                                catch                                                {                                                }                                            }                                        }                                    }                                }                            }                        }                    }                }            }            catch            {            }        }        /// <summary>
        /// A helper method to find the actual surface of the world.
        /// </summary>
        /// <param name="positionX">The x position.</param>
        /// <returns></returns>        private static int tileCheck(int positionX)        {            for (int i = (int)(WorldGen.worldSurfaceLow - 30); i < Main.maxTilesY; i++)            {                Tile tile = Framing.GetTileSafely(positionX, i);                if ((tile.type == TileID.Dirt || tile.type == TileID.ClayBlock || tile.type == TileID.Stone || tile.type == TileID.Sand || tile.type == ModContent.TileType<Snotsand>() || tile.type == TileID.Mud || tile.type == TileID.SnowBlock || tile.type == TileID.IceBlock) && tile.active())                {                    return i;                }            }            return 0;        }        public void ContagionRunner_old(int i, int j)		{            int j2 = j;            int num = WorldGen.genRand.Next(90, 131);            j = tileCheck(i) + num + 30;			Vector2 vector = new Vector2(i, j);			List<Vector2> list = new List<Vector2>();			List<Vector2> list2 = new List<Vector2>();			List<double> list3 = new List<double>();			new List<Vector2>();			for (int k = i - num; k <= i + num; k++)			{				for (int l = j - num; l <= j + num; l++)				{					float num2 = Vector2.Distance(new Vector2((float)k, (float)l), new Vector2((float)i, (float)j));					if (num2 <= (float)num && num2 >= (float)(num - 29))					{						Main.tile[k, l].active(false);					}					if (((num2 <= num && num2 >= num - 7) || (num2 <= (float)(num - 22) && num2 >= (float)(num - 29))) && Main.tile[k, l].type != TileID.ShadowOrbs)					{						Main.tile[k, l].active(true);						Main.tile[k, l].halfBrick(false);						Main.tile[k, l].slope(0);						Main.tile[k, l].type = (ushort) ModContent.TileType<Chunkstone>();					}					if (num2 <= num - 6 && num2 >= num - 23)					{						Main.tile[k, l].wall = (ushort) ModContent.WallType<Walls.ChunkstoneWall>();					}				}			}			int num3 = num - 20;			for (int m = 0; m < 6; m++)			{				double num4 = (double)(WorldGen.genRand.Next(0, 62831852) / 10000000);				Vector2 item = new Vector2(vector.X + (float)((int)Math.Round((double)num3 * Math.Cos(num4))), vector.Y + (float)((int)Math.Round((double)num3 * Math.Sin(num4))));				Vector2 item2 = vector;				if (item.X > vector.X)				{					if (item.X > vector.X + (float)(num / 2))					{						if (item.Y > vector.Y)						{							if (item.Y > vector.Y + (float)(num / 2))							{								item2 = new Vector2(item.X - 50f, item.Y - 50f);							}							else							{								item2 = new Vector2(item.X - 50f, item.Y - 25f);							}						}						else if (item.Y < vector.Y - (float)(num / 2))						{							item2 = new Vector2(item.X - 50f, item.Y + 50f);						}						else						{							item2 = new Vector2(item.X - 50f, item.Y + 25f);						}					}					else if (item.Y > vector.Y)					{						if (item.Y > vector.Y + (float)(num / 2))						{							item2 = new Vector2(item.X - 25f, item.Y - 50f);						}						else						{							item2 = new Vector2(item.X - 25f, item.Y - 25f);						}					}					else if (item.Y < vector.Y - (float)(num / 2))					{						item2 = new Vector2(item.X - 25f, item.Y + 50f);					}					else					{						item2 = new Vector2(item.X - 25f, item.Y + 25f);					}				}				else if (item.X < vector.X - (float)(num / 2))				{					if (item.Y > vector.Y)					{						if (item.Y > vector.Y + (float)(num / 2))						{							item2 = new Vector2(item.X + 50f, item.Y - 50f);						}						else						{							item2 = new Vector2(item.X + 50f, item.Y - 25f);						}					}					else if (item.Y < vector.Y - (float)(num / 2))					{						item2 = new Vector2(item.X + 50f, item.Y + 50f);					}					else					{						item2 = new Vector2(item.X + 50f, item.Y + 25f);					}				}				else if (item.Y > vector.Y)				{					if (item.Y > vector.Y + (float)(num / 2))					{						item2 = new Vector2(item.X + 25f, item.Y - 50f);					}					else					{						item2 = new Vector2(item.X + 25f, item.Y - 25f);					}				}				else if (item.Y < vector.Y - (float)(num / 2))				{					item2 = new Vector2(item.X + 25f, item.Y + 50f);				}				else				{					item2 = new Vector2(item.X + 25f, item.Y + 25f);				}				list.Add(item);				list2.Add(item2);				list3.Add(num4);			}			for (int n = 0; n < 6; n++)			{			    BoreTunnel2((int)list[n].X, (int)list[n].Y, (int)list2[n].X, (int)list2[n].Y, 9f, (ushort)ModContent.TileType<Chunkstone>());				BoreTunnel2((int)list[n].X, (int)list[n].Y, (int)list2[n].X, (int)list2[n].Y, 4f, 65535);				MakeCircle((int)list2[n].X, (int)list2[n].Y, 11f, (ushort)ModContent.TileType<Chunkstone>());				MakeCircle((int)list2[n].X, (int)list2[n].Y, 6f, 65535);			}			for (int num5 = i - num; num5 <= i + num; num5++)			{				for (int num6 = j - num; num6 <= j + num; num6++)				{					float num7 = Vector2.Distance(new Vector2((float)num5, (float)num6), new Vector2((float)i, (float)j));					if (num7 < (float)(num - 7) && num7 > (float)(num - 22))					{						Main.tile[num5, num6].active(false);					}				}			}			int num8 = num - 7;			for (int num9 = 0; num9 < 20; num9++)			{				double d = (double)(WorldGen.genRand.Next(0, 62831852) / 10000000);				Vector2 vector2 = new Vector2(vector.X + (float)((int)Math.Round((double)num8 * Math.Cos(d))), vector.Y + (float)((int)Math.Round((double)num8 * Math.Sin(d))));				MakeCircle((int)vector2.X, (int)vector2.Y, 4f, (ushort) ModContent.TileType<Chunkstone>());			}			for (int num10 = 0; num10 < 6; num10++)			{				AddSnotOrb((int)list2[num10].X, (int)list2[num10].Y);			}            BoreTunnel2(i, j - num - 30, i, j - num + 7, 10, ushort.MaxValue);            for (int x = i - 17; x < i + 17; x++)            {                for (int y = j - num - 30; y < j - num + 8; y++)                {                    if (x >= i + 12 || x <= i - 12)                    {                        Main.tile[x, y].active(true);                        Main.tile[x, y].halfBrick(false);                        Main.tile[x, y].slope(0);                        Main.tile[x, y].type = (ushort)ModContent.TileType<Chunkstone>();                    }                    if (x <= i + 12 && x >= i - 12)                    {                        Main.tile[x, y].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();                        Main.tile[x, y].active(false);                    }                }            }            for (int x = i - 17; x < i + 17; x++)            {                for (int y = j - num - 30; y < j - num + 8; y++)                {                    if (x == i + 12 || x == i - 12)                    {                        int rn = WorldGen.genRand.Next(13, 17);                        if (y % rn == 0)                        {                            MakeCircle(x, y, 3, (ushort)ModContent.TileType<Chunkstone>());                        }                    }                }            }        }        /// <summary>
        /// Contagion generation method.
        /// </summary>
        /// <param name="i">The x coordinate to start the generation at.</param>
        /// <param name="j">The y coordinate to start the generation at.</param>        public void ContagionRunner(int i, int j)
        {            int j2 = j;            int radius = WorldGen.genRand.Next(50, 61);            int rad2 = WorldGen.genRand.Next(20, 26);            j = tileCheck(i) + radius + 50;
            Vector2 center = new Vector2(i, j);
            List<Vector2> points = new List<Vector2>();
            List<Vector2> pointsToGoTo = new List<Vector2>();
            List<double> angles = new List<double>();
            List<Vector2> outerCircles = new List<Vector2>(); // the circles at the ends of the first tunnels
            List<Vector2> secondaryCircles = new List<Vector2>(); // the circles at the ends of the outer circles
            List<Vector2> secondCircleStartPoints = new List<Vector2>();
            List<Vector2> secondCircleEndpoints = new List<Vector2>();
            List<double> secondCirclePointsAroundCircle = new List<double>();
            List<Vector2> exclusions = new List<Vector2>();
            List<Vector2> excludedPointsForOuterTunnels = new List<Vector2>();
            //new List<Vector2>();
            #region make the main circle
            for (int k = i - radius; k <= i + radius; k++)
            {
                for (int l = j - radius; l <= j + radius; l++)
                {
                    float dist = Vector2.Distance(new Vector2(k, l), new Vector2(i, j));
                    if (dist <= radius && dist >= (radius - 29))
                    {
                        Main.tile[k, l].active(false);
                    }
                    if (((dist <= radius && dist >= radius - 7) || (dist <= (float)(radius - 22) && dist >= (float)(radius - 29))) && Main.tile[k, l].type != (ushort)ModContent.TileType<SnotOrb>())
                    {
                        Main.tile[k, l].active(true);
                        Main.tile[k, l].halfBrick(false);
                        Main.tile[k, l].slope(0);
                        Main.tile[k, l].type = (ushort)ModContent.TileType<Chunkstone>();
                    }
                    if (dist <= radius - 6 && dist >= radius - 23)
                    {
                        Main.tile[k, l].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();
                    }
                }
            }
            #endregion
            int radiusModifier = radius - 7; // makes the tunnels go deeper into the main circle (more subtracted means further in)
            Vector2 posToPlaceAnotherCircle = Vector2.Zero;
            #region find the points for making the tunnels to the outer circles
            for (int m = 0; m < 16; m++)
            {
                double positionAroundCircle = (WorldGen.genRand.Next(0, 62831852) / 10000000);
                Vector2 randPoint = new Vector2(center.X + ((int)Math.Round(radiusModifier * Math.Cos(positionAroundCircle))), center.Y + ((int)Math.Round(radiusModifier * Math.Sin(positionAroundCircle))));
                posToPlaceAnotherCircle = randPoint;
                Vector2 item2 = center;
                if (randPoint.X > center.X)
                {
                    if (randPoint.X > center.X + radius / 2)
                    {
                        if (randPoint.Y > center.Y)
                        {
                            if (randPoint.Y > center.Y + radius / 2)
                            {
                                item2 = new Vector2(randPoint.X + 50f, randPoint.Y + 50f);
                                if (WorldGen.genRand.Next(2) == 0)
                                {
                                    outerCircles.Add(item2);
                                    secondaryCircles.Add(item2);
                                    excludedPointsForOuterTunnels.Add(randPoint);
                                }
                            }
                            else
                            {
                                item2 = new Vector2(randPoint.X + 50f, randPoint.Y + 25f);
                                if (WorldGen.genRand.Next(2) == 0)
                                {
                                    outerCircles.Add(item2);
                                    secondaryCircles.Add(item2);
                                    excludedPointsForOuterTunnels.Add(randPoint);
                                }
                            }
                        }
                        else if (randPoint.Y < center.Y - radius / 2)
                        {
                            item2 = new Vector2(randPoint.X + 50f, randPoint.Y - 50f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                        else
                        {
                            item2 = new Vector2(randPoint.X + 50f, randPoint.Y - 25f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                    }
                    else if (randPoint.Y > center.Y)
                    {
                        if (randPoint.Y > center.Y + radius / 2)
                        {
                            item2 = new Vector2(randPoint.X + 25f, randPoint.Y + 50f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                        else
                        {
                            item2 = new Vector2(randPoint.X + 25f, randPoint.Y + 25f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                    }
                    else if (randPoint.Y < center.Y - radius / 2)
                    {
                        item2 = new Vector2(randPoint.X + 25f, randPoint.Y - 50f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                    else
                    {
                        item2 = new Vector2(randPoint.X + 25f, randPoint.Y - 25f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                }
                else if (randPoint.X < center.X - radius / 2)
                {
                    if (randPoint.Y > center.Y)
                    {
                        if (randPoint.Y > center.Y + radius / 2)
                        {
                            item2 = new Vector2(randPoint.X - 50f, randPoint.Y + 50f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                        else
                        {
                            item2 = new Vector2(randPoint.X - 50f, randPoint.Y + 25f);
                            if (WorldGen.genRand.Next(2) == 0)
                            {
                                outerCircles.Add(item2);
                                secondaryCircles.Add(item2);
                                excludedPointsForOuterTunnels.Add(randPoint);
                            }
                        }
                    }
                    else if (randPoint.Y < center.Y - radius / 2)
                    {
                        item2 = new Vector2(randPoint.X - 50f, randPoint.Y - 50f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                    else
                    {
                        item2 = new Vector2(randPoint.X - 50f, randPoint.Y - 25f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                }
                else if (randPoint.Y > center.Y)
                {
                    if (randPoint.Y > center.Y + radius / 2)
                    {
                        item2 = new Vector2(randPoint.X - 25f, randPoint.Y + 50f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                    else
                    {
                        item2 = new Vector2(randPoint.X - 25f, randPoint.Y + 25f);
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            outerCircles.Add(item2);
                            secondaryCircles.Add(item2);
                            excludedPointsForOuterTunnels.Add(randPoint);
                        }
                    }
                }
                else if (randPoint.Y < center.Y - radius / 2)
                {
                    item2 = new Vector2(randPoint.X - 25f, randPoint.Y - 50f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
                else
                {
                    item2 = new Vector2(randPoint.X - 25f, randPoint.Y - 25f);
                    if (WorldGen.genRand.Next(2) == 0)
                    {
                        outerCircles.Add(item2);
                        secondaryCircles.Add(item2);
                        excludedPointsForOuterTunnels.Add(randPoint);
                    }
                }
                points.Add(randPoint);
                pointsToGoTo.Add(item2);
                angles.Add(positionAroundCircle);
            }
            #endregion

            // make outer circles
            #region outer circles and tunnels
            if (secondaryCircles.Count != 0)
            {
                for (int z = 0; z < secondaryCircles.Count; z++)
                {
                    if (secondaryCircles[z].Y < center.Y - 10) continue;
                    int outerTunnelsRadiusMod = rad2 - 6;
                    double pointsAroundCircle2 = (WorldGen.genRand.Next(0, 62831852) / 10000000);
                    Vector2 randPointAroundCircle = new Vector2(outerCircles[z].X + ((int)Math.Round(outerTunnelsRadiusMod * Math.Cos(pointsAroundCircle2))), outerCircles[z].Y + ((int)Math.Round(outerTunnelsRadiusMod * Math.Sin(pointsAroundCircle2))));
                    for (int m = 0; m < 16; m++)
                    {
                        Vector2 endpoint = secondaryCircles[z];
                        #region endpoint calculation
                        if (randPointAroundCircle.X > outerCircles[z].X)
                        {
                            if (randPointAroundCircle.X > outerCircles[z].X + rad2 / 2)
                            {
                                if (randPointAroundCircle.Y > outerCircles[z].Y)
                                {
                                    if (randPointAroundCircle.Y > outerCircles[z].Y + rad2 / 2)
                                    {
                                        endpoint = new Vector2(randPointAroundCircle.X + 15f, randPointAroundCircle.Y + 15f);
                                    }
                                    else
                                    {
                                        endpoint = new Vector2(randPointAroundCircle.X + 15f, randPointAroundCircle.Y + 7f);
                                    }
                                }
                                else if (randPointAroundCircle.Y < outerCircles[z].Y - rad2 / 2)
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X + 15f, randPointAroundCircle.Y - 15f);
                                }
                                else
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X + 15f, randPointAroundCircle.Y - 7f);
                                }
                            }
                            else if (randPointAroundCircle.Y > outerCircles[z].Y)
                            {
                                if (randPointAroundCircle.Y > outerCircles[z].Y + rad2 / 2)
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y + 15f);
                                }
                                else
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y + 7f);
                                }
                            }
                            else if (randPointAroundCircle.Y < outerCircles[z].Y - rad2 / 2)
                            {
                                endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y - 15f);
                            }
                            else
                            {
                                endpoint = new Vector2(randPointAroundCircle.X + 7f, randPointAroundCircle.Y - 7f);
                            }
                        }
                        else if (randPointAroundCircle.X < outerCircles[z].X - rad2 / 2)
                        {
                            if (randPointAroundCircle.Y > outerCircles[z].Y)
                            {
                                if (randPointAroundCircle.Y > outerCircles[z].Y + rad2 / 2)
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y + 15f);
                                }
                                else
                                {
                                    endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y + 7f);
                                }
                            }
                            else if (randPointAroundCircle.Y < outerCircles[z].Y - rad2 / 2)
                            {
                                endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y - 15f);
                            }
                            else
                            {
                                endpoint = new Vector2(randPointAroundCircle.X - 15f, randPointAroundCircle.Y - 7f);
                            }
                        }
                        else if (randPointAroundCircle.Y > outerCircles[z].Y)
                        {
                            if (randPointAroundCircle.Y > outerCircles[z].Y + rad2 / 2)
                            {
                                endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y + 15f);
                            }
                            else
                            {
                                endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y + 7f);
                            }
                        }
                        else if (randPointAroundCircle.Y < outerCircles[z].Y - rad2 / 2)
                        {
                            endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y - 15f);
                        }
                        else
                        {
                            endpoint = new Vector2(randPointAroundCircle.X - 7f, randPointAroundCircle.Y - 7f);
                        }
                        #endregion
                        secondCircleStartPoints.Add(randPointAroundCircle);
                        secondCircleEndpoints.Add(endpoint);
                        secondCirclePointsAroundCircle.Add(pointsAroundCircle2);
                    }
                }
            }

            #endregion
            // make tunnels going outwards from the main circle
            for (int n = 0; n < points.Count; n++)
            {
                if (points[n].Y < center.Y - 10) continue;
                BoreTunnel2((int)points[n].X, (int)points[n].Y, (int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 10f, (ushort)ModContent.TileType<Chunkstone>());
                BoreTunnel2((int)points[n].X, (int)points[n].Y, (int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 5f, 65535);
                MakeEndingCircle((int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 13f, (ushort)ModContent.TileType<Chunkstone>());
                MakeCircle((int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 8f, 65535);
            }
            if (outerCircles.Count != 0)
            {
                for (int q = 0; q < outerCircles.Count; q++)
                {
                    if (outerCircles[q].Y < center.Y - 10) continue;
                    MakeEndingCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2, (ushort)ModContent.TileType<Chunkstone>());
                    MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 6, 65535);
                    MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 13, (ushort)ModContent.TileType<Chunkstone>());
                    exclusions.Add(outerCircles[q]);
                }
            }
            int num8 = radius - 7;
            for (int num9 = 0; num9 < 20; num9++)
            {
                double d = WorldGen.genRand.Next(0, 62831852) / 10000000;
                Vector2 vector2 = new Vector2(center.X + ((int)Math.Round(num8 * Math.Cos(d))), center.Y + ((int)Math.Round(num8 * Math.Sin(d))));
                if (exclusions.Contains(vector2)) continue;
                MakeCircle((int)vector2.X, (int)vector2.Y, 4f, (ushort)ModContent.TileType<Chunkstone>());
            }
            
            // make tunnels going outwards from the outer circles
            for (int n = 0; n < secondCircleStartPoints.Count; n++)
            {
                if (excludedPointsForOuterTunnels.Count != 0 && n < excludedPointsForOuterTunnels.Count)
                    if (Vector2.Distance(excludedPointsForOuterTunnels[n], secondCircleEndpoints[n]) < 55)
                        continue;
                BoreTunnel2((int)secondCircleStartPoints[n].X, (int)secondCircleStartPoints[n].Y, (int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 7f, (ushort)ModContent.TileType<Chunkstone>());
                BoreTunnel2((int)secondCircleStartPoints[n].X, (int)secondCircleStartPoints[n].Y, (int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 3f, 65535);
                // ending circles
                MakeCircle((int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 3f, 65535); // air
                MakeEndingCircle((int)secondCircleEndpoints[n].X, (int)secondCircleEndpoints[n].Y, 5f, (ushort)ModContent.TileType<Chunkstone>()); // chunkstone
            }
            // fill main tunnels with air
            for (int n = 0; n < points.Count; n++)
            {
                if (points[n].Y < center.Y - 10)
                {
                    exclusions.Add(pointsToGoTo[n]);
                    continue;
                }
                BoreTunnel2((int)points[n].X, (int)points[n].Y, (int)pointsToGoTo[n].X, (int)pointsToGoTo[n].Y, 3f, 65535);
            }
            // make secondary circles inner area filled
            if (outerCircles.Count != 0)
            {
                for (int q = 0; q < outerCircles.Count; q++)
                {
                    if (outerCircles[q].Y < center.Y - 10) continue;
                    MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 6, 65535);
                    MakeCircle((int)outerCircles[q].X, (int)outerCircles[q].Y, rad2 - 13, (ushort)ModContent.TileType<Chunkstone>());
                }
            }
            for (int num5 = i - radius; num5 <= i + radius; num5++)
            {
                for (int num6 = j - radius; num6 <= j + radius; num6++)
                {
                    float num7 = Vector2.Distance(new Vector2(num5, num6), new Vector2(i, j));
                    if (num7 < radius - 7 && num7 > radius - 22)
                    {
                        Main.tile[num5, num6].active(false);
                    }
                }
            }
            for (int num10 = 0; num10 < pointsToGoTo.Count; num10++)
            {
                if (exclusions.Contains(pointsToGoTo[num10])) continue;
                AddSnotOrb((int)pointsToGoTo[num10].X, (int)pointsToGoTo[num10].Y);
            }            for (int num10 = 0; num10 < secondCircleEndpoints.Count; num10++)
            {
                if (exclusions.Contains(secondCircleEndpoints[num10])) continue;
                AddSnotOrb((int)secondCircleEndpoints[num10].X, (int)secondCircleEndpoints[num10].Y);
            }            BoreTunnel2(i, j - radius - 50, i, j - radius + 7, 5, ushort.MaxValue);            for (int x = i - 12; x < i + 12; x++)            {                for (int y = j - radius - 50; y < j - radius + 8; y++)                {                    if (x >= i + 7 || x <= i - 7)                    {                        Main.tile[x, y].active(true);                        Main.tile[x, y].halfBrick(false);                        Main.tile[x, y].slope(0);                        Main.tile[x, y].type = (ushort)ModContent.TileType<Chunkstone>();                    }                    if (x <= i + 7 && x >= i - 7)                    {                        Main.tile[x, y].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();                        Main.tile[x, y].active(false);                    }                }            }            for (int x = i - 12; x < i + 12; x++)            {                for (int y = j - radius - 50; y < j - radius + 8; y++)                {                    if (x == i + 9 || x == i - 9)                    {                        int rn = WorldGen.genRand.Next(13, 17);                        if (y % rn == 0)                        {                            MakeCircle(x, y, 3, (ushort)ModContent.TileType<Chunkstone>());                        }                    }                }            }        }        /// <summary>
        /// A helper method to generate a tunnel using MakeCircle().
        /// </summary>
        /// <param name="x0">Starting x coordinate.</param>
        /// <param name="y0">Starting y coordinate.</param>
        /// <param name="x1">Ending x coordinate.</param>
        /// <param name="y1">Ending y coordinate.</param>
        /// <param name="r">Radius.</param>
        /// <param name="type">Type to generate.</param>        public void BoreTunnel2(int x0, int y0, int x1, int y1, float r, ushort type)        {            bool flag = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);            if (flag)            {                Swap<int>(ref x0, ref y0);                Swap<int>(ref x1, ref y1);            }            if (x0 > x1)            {                Swap<int>(ref x0, ref x1);                Swap<int>(ref y0, ref y1);            }            int num = x1 - x0;            int num2 = Math.Abs(y1 - y0);            int num3 = num / 2;            int num4 = (y0 < y1) ? 1 : -1;            int num5 = y0;            for (int i = x0; i <= x1; i++)            {                if (flag)                {                    MakeCircle(num5, i, r, type);                }                else                {                    MakeCircle(i, num5, r, type);                }                num3 -= num2;                if (num3 < 0)                {                    num5 += num4;                    num3 += num;                }            }        }        /// <summary>
        /// Makes a circle for the Contagion generation. Fills all tiles with Chunkstone Walls.
        /// </summary>
        /// <param name="x">The x coordinate of the center of the circle.</param>
        /// <param name="y">The y coordinate of the center of the circle.</param>
        /// <param name="r">The radius of the circle.</param>
        /// <param name="type">The type to generate - if ushort.MaxValue, will generate air.</param>        public void MakeCircle(int x, int y, float r, ushort type)        {            int num = (int)(x - r);            int num2 = (int)(y - r);            int num3 = (int)(x + r);            int num4 = (int)(y + r);            for (int i = num; i < num3 + 1; i++)            {                for (int j = num2; j < num4 + 1; j++)                {                    if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) <= r && Main.tile[i, j].type != TileID.ShadowOrbs)                    {                        if (type == 65535)                        {                            Main.tile[i, j].active(false);
                            Main.tile[i, j].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();                        }                        else                        {                            Main.tile[i, j].active(true);                            Main.tile[i, j].type = type;                            Main.tile[i, j].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();                            WorldGen.SquareTileFrame(i, j, true);                        }                    }                    //else if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) == r - 1)
                    //{
                    //    Main.tile[i, j].wall = 0;
                    //}                }            }        }        /// <summary>
        /// Makes an ending circle for the Contagion generation.
        /// </summary>
        /// <param name="x">The x coordinate of the center of the circle.</param>
        /// <param name="y">The y coordinate of the center of the circle.</param>
        /// <param name="r">The radius of the circle.</param>
        /// <param name="type">The type to generate - if ushort.MaxValue, will generate air.</param>        public void MakeEndingCircle(int x, int y, float r, ushort type)        {            int num = (int)(x - r);            int num2 = (int)(y - r);            int num3 = (int)(x + r);            int num4 = (int)(y + r);            for (int i = num; i < num3 + 1; i++)            {                for (int j = num2; j < num4 + 1; j++)                {                    if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) <= r && Main.tile[i, j].type != TileID.ShadowOrbs)                    {                        if (type == 65535)                        {                            Main.tile[i, j].active(false);
                            Main.tile[i, j].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();                        }                        else                        {                            Main.tile[i, j].active(true);                            Main.tile[i, j].type = type;                            //Main.tile[i, j].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();                            WorldGen.SquareTileFrame(i, j, true);                        }                    }
                    else if (Vector2.Distance(new Vector2(i, j), new Vector2(x, y)) == r - 1)
                    {
                        Main.tile[i, j].wall = (ushort)ModContent.WallType<Walls.ChunkstoneWall>();
                    }
                }            }        }        /// <summary>
        /// Swaps two values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>        private static void Swap<T>(ref T lhs, ref T rhs)        {            T t = lhs;            lhs = rhs;            rhs = t;        }        /// <summary>
        /// Identical to WorldGen.OreRunner() except only replaces ice and snow.
        /// </summary>
        /// <param name="i">The x coordinate of the tile to start the generation.</param>
        /// <param name="j">The y coordinate of the tile to start the generation.</param>
        /// <param name="strength">Unsure.</param>
        /// <param name="steps">Unsure.</param>
        /// <param name="type">The type of the tile to generate.</param>        public static void IceSnowOreRunner(int i, int j, double strength, int steps, ushort type)
        {
            double num = strength;
            float num2 = (float)steps;
            Vector2 value;
            value.X = (float)i;
            value.Y = (float)j;
            Vector2 value2;
            value2.X = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            value2.Y = (float)WorldGen.genRand.Next(-10, 11) * 0.1f;
            while (num > 0.0 && num2 > 0f)
            {
                if (value.Y < 0f && num2 > 0f && type == 59)
                {
                    num2 = 0f;
                }
                num = strength * (double)(num2 / (float)steps);
                num2 -= 1f;
                int num3 = (int)((double)value.X - num * 0.5);
                int num4 = (int)((double)value.X + num * 0.5);
                int num5 = (int)((double)value.Y - num * 0.5);
                int num6 = (int)((double)value.Y + num * 0.5);
                if (num3 < 0)
                {
                    num3 = 0;
                }
                if (num4 > Main.maxTilesX)
                {
                    num4 = Main.maxTilesX;
                }
                if (num5 < 0)
                {
                    num5 = 0;
                }
                if (num6 > Main.maxTilesY)
                {
                    num6 = Main.maxTilesY;
                }
                for (int k = num3; k < num4; k++)
                {
                    for (int l = num5; l < num6; l++)
                    {
                        if ((double)(Math.Abs((float)k - value.X) + Math.Abs((float)l - value.Y)) < strength * 0.5 * (1.0 + (double)WorldGen.genRand.Next(-10, 11) * 0.015) && Main.tile[k, l].active() && (Main.tile[k, l].type == TileID.SnowBlock || Main.tile[k, l].type == TileID.IceBlock || Main.tile[k, l].type == TileID.FleshIce || Main.tile[k, l].type == TileID.CorruptIce || Main.tile[k, l].type == TileID.HallowedIce || Main.tile[k, l].type == ModContent.TileType<YellowIce>()))
                        {
                            Main.tile[k, l].type = type;
                            WorldGen.SquareTileFrame(k, l, true);
                            if (Main.netMode == 2)
                            {
                                NetMessage.SendTileSquare(-1, k, l, 1);
                            }
                        }
                    }
                }
                value += value2;
                value2.X += (float)WorldGen.genRand.Next(-10, 11) * 0.05f;
                if (value2.X > 1f)
                {
                    value2.X = 1f;
                }
                if (value2.X < -1f)
                {
                    value2.X = -1f;
                }
            }
        }        /// <summary>
        /// Adds a Snot Orb at the given coordinates. For the Contagion.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="style">Unused.</param>        public static void AddSnotOrb(int x, int y, int style = 0)
        {
            if (x < 10 || x > Main.maxTilesX - 10)
            {
                return;
            }
            if (y < 10 || y > Main.maxTilesY - 10)
            {
                return;
            }
            for (int i = x - 1; i < x + 1; i++)
            {
                for (int j = y - 1; j < y + 1; j++)
                {
                    if (Main.tile[i, j].active() && Main.tile[i, j].type == (ushort)ModContent.TileType<Tiles.SnotOrb>())
                    {
                        return;
                    }
                }
            }
            short num = 0;
            Main.tile[x - 1, y - 1].active(true);
            Main.tile[x - 1, y - 1].type = (ushort)ModContent.TileType<Tiles.SnotOrb>();
            Main.tile[x - 1, y - 1].frameX = num;
            Main.tile[x - 1, y - 1].frameY = 0;
            Main.tile[x, y - 1].active(true);
            Main.tile[x, y - 1].type = (ushort)ModContent.TileType<Tiles.SnotOrb>();
            Main.tile[x, y - 1].frameX = (short)(18 + num);
            Main.tile[x, y - 1].frameY = 0;
            Main.tile[x - 1, y].active(true);
            Main.tile[x - 1, y].type = (ushort)ModContent.TileType<Tiles.SnotOrb>();
            Main.tile[x - 1, y].frameX = num;
            Main.tile[x - 1, y].frameY = 18;
            Main.tile[x, y].active(true);
            Main.tile[x, y].type = (ushort)ModContent.TileType<Tiles.SnotOrb>();
            Main.tile[x, y].frameX = (short)(18 + num);
            Main.tile[x, y].frameY = 18;
        }

        /// <summary>
        /// Loads structure as 2D int array from a given manifest path to an embedded resource
        /// </summary>
        /// <param name="path">The embedded file manifest path.
        /// <example>
        /// For example:
        /// <code>"ExxoAvalonOrigins.Structures.HellCastle.txt"
        /// </code>
        /// where the internal path of the file is Structures\HellCastle.txt
        /// </example>
        /// </param>
        public static int[,] GetStructure(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // Loading file into list
            List<int[]> structureList = new();
            using Stream stream = assembly.GetManifestResourceStream(path);
            using StreamReader reader = new(stream);
            while (reader.Peek() >= 0)
            {
                structureList.Add(reader.ReadLine().TrimEnd(',').Trim(new Char[] { '{', '}' }).Split(',').Select(int.Parse).ToArray());
            }

            // Converting list to 2d array
            int[,] structureArray = new int[structureList.Count, structureList[0].Length];
            for (int i = 0; i < structureList.Count; i++)
            {
                for (int j = 0; j < structureList[0].Length; j++)
                {
                    structureArray[i, j] = structureList[i][j];
                }
            }

            return structureArray;
        }    }}