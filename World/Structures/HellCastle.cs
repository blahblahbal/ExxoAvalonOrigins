﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.World.Structures
{
    class HellCastle
    {
        public static void Generate(int x, int y)
        {
            int[,] _structure = Utils.GetStructure("HellCastle.txt");

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
        }
        public static void RemoveLavaAndHellHousesFromHellcastleArea(int x, int y)
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
        }
        public static void MakeRectangle(int x, int y, int width, int height, int type = -1)
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
                        World.Utils.SquareTileFrame(i, j, resetSlope: true);
                    }
                }
            }
        }
        public static bool AddHellcastleChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
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
        }
    }
}
