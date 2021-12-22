using ExxoAvalonOrigins.Items.Consumables;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.World.Structures
{
    class IceShrine
    {
        public static void Generate(int x, int y)
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
                    World.Utils.SquareTileFrame(tower1X, y, resetSlope: true);
                }
                if (tower1X > x - width - mult * 4 && tower1X < x - mult * 4)
                {
                    Main.tile[tower1X, y + 4].active(true);
                    Main.tile[tower1X, y + 4].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower1X, y + 4, resetSlope: true);
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
                    World.Utils.SquareTileFrame(tower1X, y + 5, resetSlope: true);
                    Main.tile[tower1X, y + 8].active(true);
                    Main.tile[tower1X, y + 8].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower1X, y + 8, resetSlope: true);
                    if (tower1X < x - mult * 4 - 1)
                    {
                        Main.tile[tower1X, y + 9].active(true);
                        Main.tile[tower1X, y + 9].type = TileID.IceBrick;
                        World.Utils.SquareTileFrame(tower1X, y + 9, resetSlope: true);
                    }
                    if (tower1X < x - mult * 4 - 2)
                    {
                        Main.tile[tower1X, y + 10].active(true);
                        Main.tile[tower1X, y + 10].type = TileID.IceBrick;
                        World.Utils.SquareTileFrame(tower1X, y + 10, resetSlope: true);
                    }
                    Main.tile[tower1X, y + 9 + mod1].active(true);
                    Main.tile[tower1X, y + 9 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower1X, y + 9 + mod1, resetSlope: true);
                    Main.tile[tower1X, y + 10 + mod1].active(true);
                    Main.tile[tower1X, y + 10 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower1X, y + 10 + mod1, resetSlope: true);
                }
                for (int tower1Y = y + 1; tower1Y <= y + 1 + mult; tower1Y++)
                {
                    Main.tile[tower1X, tower1Y].active(true);
                    Main.tile[tower1X, tower1Y].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower1X, tower1Y, resetSlope: true);
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
                    World.Utils.SquareTileFrame(tower2X, y, resetSlope: true);
                }
                if (tower2X < x + width + mult * 4 + 4 && tower2X > x + 4 + mult * 4)
                {
                    Main.tile[tower2X, y + 4].active(true);
                    Main.tile[tower2X, y + 4].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower2X, y + 4, resetSlope: true);
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
                    World.Utils.SquareTileFrame(tower2X, y + 5, resetSlope: true);
                    Main.tile[tower2X, y + 8].active(true);
                    Main.tile[tower2X, y + 8].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower2X, y + 8, resetSlope: true);
                    if (tower2X > x + mult * 4 + 5)
                    {
                        Main.tile[tower2X, y + 9].active(true);
                        Main.tile[tower2X, y + 9].type = TileID.IceBrick;
                        World.Utils.SquareTileFrame(tower2X, y + 9, resetSlope: true);
                    }
                    if (tower2X > x + mult * 4 + 6)
                    {
                        Main.tile[tower2X, y + 10].active(true);
                        Main.tile[tower2X, y + 10].type = TileID.IceBrick;
                        World.Utils.SquareTileFrame(tower2X, y + 10, resetSlope: true);
                    }
                    Main.tile[tower2X, y + 9 + mod1].active(true);
                    Main.tile[tower2X, y + 9 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower2X, y + 9 + mod1, resetSlope: true);
                    Main.tile[tower2X, y + 10 + mod1].active(true);
                    Main.tile[tower2X, y + 10 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower2X, y + 10 + mod1, resetSlope: true);
                }
                for (int tower2Y = y + 1; tower2Y <= y + 1 + mult; tower2Y++)
                {
                    Main.tile[tower2X, tower2Y].active(true);
                    Main.tile[tower2X, tower2Y].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(tower2X, tower2Y, resetSlope: true);
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
                    World.Utils.SquareTileFrame(pyX + 1, pyY, resetSlope: true);
                    if (pyY >= y + mult + 4 && pyY <= y + mult + 8 + mod1 && (pyX == x - pstep + 3 || pyX == x + pstep + 1))
                    {
                        Main.tile[pyX, pyY + mod1].active(true);
                        Main.tile[pyX, pyY + mod1].type = TileID.WoodenBeam;
                        World.Utils.SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                        if (pyY == y + mult + 4)
                        {
                            Main.tile[pyX, pyY + mod1].active(true);
                            Main.tile[pyX, pyY + mod1].type = TileID.IceBrick;
                            World.Utils.SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                        }
                    }
                    if (pyY == y + mult + 4 && (pyX == x - pstep + 2))
                    {
                        Main.tile[pyX, pyY + mod1].active(true);
                        Main.tile[pyX, pyY + mod1].type = 4;
                        Main.tile[pyX, pyY + mod1].frameY = 198;
                        World.Utils.SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                    }
                    if (pyY == y + mult + 4 && (pyX >= x - pstep + 4 && pyX <= x + pstep))
                    {
                        Main.tile[pyX, pyY + mod1].active(true);
                        Main.tile[pyX, pyY + mod1].type = 19;
                        Main.tile[pyX, pyY + mod1].frameY = 0;
                        World.Utils.SquareTileFrame(pyX, pyY + mod1, resetSlope: true);
                    }
                    if (pyY >= y + 3 && pyY <= y + 4 && (pyX >= x - 1 && pyX <= x + 5))
                    {
                        Main.tile[pyX, pyY].type = TileID.IceBlock;
                        World.Utils.SquareTileFrame(pyX, pyY, resetSlope: true);
                    }
                }
                pstep++;
            }
            Main.tile[x + 9, y + mult + 4 + mod1].active(true);
            Main.tile[x + 9, y + mult + 4 + mod1].type = 4;
            Main.tile[x + 9, y + mult + 4 + mod1].frameY = 198;
            World.Utils.SquareTileFrame(x + 12, y + mult + 4 + mod1, resetSlope: true);
            #endregion
            #region base
            for (int baseX = x - width - mult * 4 + 2; baseX <= x + mult * 4 + 2 + width; baseX++)
            {
                Main.tile[baseX, y + 6].active(true);
                Main.tile[baseX, y + 6].type = TileID.IceBrick;
                World.Utils.SquareTileFrame(baseX, y + 6, resetSlope: true);
                Main.tile[baseX, y + 7].active(true);
                Main.tile[baseX, y + 7].type = TileID.IceBrick;
                World.Utils.SquareTileFrame(baseX, y + 7, resetSlope: true);
                if (baseX > x + mult * 4 + 6 - width && baseX < x + mult * 4 + 6 ||
                    baseX > x - mult * 4 - 2 && baseX < x - mult * 4 + width - 2)
                {
                    Main.tile[baseX, y + 10 + mod1].active(true);
                    Main.tile[baseX, y + 10 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(baseX, y + 10 + mod1, resetSlope: true);
                    Main.tile[baseX, y + 11 + mod1].active(true);
                    Main.tile[baseX, y + 11 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(baseX, y + 11 + mod1, resetSlope: true);
                }
                if (baseX > x + mult * 4 + 6 - 2 * width + 2 && baseX < x + mult * 4 + 6 - width + 2 ||
                    baseX > x - mult * 4 + width - 4 && baseX < x - mult * 4 + 2 * width - 4)
                {
                    Main.tile[baseX, y + 11 + mod1].active(true);
                    Main.tile[baseX, y + 11 + mod1].type = TileID.IceBrick;
                    Main.tile[baseX, y + 11 + mod1].liquid = 0;
                    World.Utils.SquareTileFrame(baseX, y + 11 + mod1, resetSlope: true);
                    Main.tile[baseX, y + 12 + mod1].active(true);
                    Main.tile[baseX, y + 12 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(baseX, y + 12 + mod1, resetSlope: true);
                }
                if (baseX < x + mult * 4 + 8 - 2 * width + 2 && baseX > x - mult * 4 + 2 * width - 6)
                {
                    Main.tile[baseX, y + 12 + mod1].active(true);
                    Main.tile[baseX, y + 12 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(baseX, y + 12 + mod1, resetSlope: true);
                    Main.tile[baseX, y + 13 + mod1].wall = 0;
                    Main.tile[baseX, y + 13 + mod1].active(true);
                    Main.tile[baseX, y + 13 + mod1].type = TileID.IceBrick;
                    World.Utils.SquareTileFrame(baseX, y + 13 + mod1, resetSlope: true);
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
                paintingType = ModContent.TileType<Tiles.Paintings>();
            }
            int stylez2 = Main.rand.Next(5);
            if (stylez2 == 0) stylez2 = 12;
            else if (stylez2 == 1) stylez2 = 10;
            else if (stylez2 == 2) stylez2 = 9;
            else if (stylez2 == 3)
            {
                stylez2 = 0;
                paintingType = ModContent.TileType<Tiles.Paintings>();
            }
            else if (stylez2 == 4)
            {
                stylez2 = 5;
                paintingType = ModContent.TileType<Tiles.Paintings>();
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
        }
        public static bool AddIceShrineChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
        {
            var k = j;
            while (k < Main.maxTilesY)
            {
                if (Main.tile[i, k].active() && Main.tileSolid[Main.tile[i, k].type])
                {
                    var num = k;
                    var num2 = WorldGen.PlaceChest(i - 1, num - 1, 21, notNearOtherChests, 11);
                    if (num2 >= 0)
                    {
                        for (var num3 = 0; num3 == 0; num3++)
                        {
                            var num4 = WorldGen.genRand.Next(19);
                            if (num4 >= 0 && num4 <= 6)
                            {
                                Main.chest[num2].item[0].SetDefaults(ItemID.BlizzardinaBottle, false);
                                Main.chest[num2].item[0].Prefix(-1);
                            }
                            else if (num4 >= 7 && num4 <= 13)
                            {
                                Main.chest[num2].item[0].SetDefaults(ItemID.PoisonedKnife, false);
                                Main.chest[num2].item[0].stack = WorldGen.genRand.Next(34, 79);
                            }
                            else if (num4 >= 14 && num4 <= 17)
                            {
                                Main.chest[num2].item[0].SetDefaults(ItemID.IceBlade, false);
                                Main.chest[num2].item[0].Prefix(-1);
                            }
                            else if (num4 == 18)
                            {
                                Main.chest[num2].item[0].SetDefaults(ItemID.IceSkates, false);
                                Main.chest[num2].item[0].Prefix(-1);
                            }
                            Main.chest[num2].item[1].SetDefaults(ItemID.GoldCoin, false);
                            Main.chest[num2].item[1].stack = WorldGen.genRand.Next(60, 82);
                            var num5 = WorldGen.genRand.Next(5);
                            if (num5 == 0)
                            {
                                Main.chest[num2].item[2].SetDefaults(ItemID.LesserRestorationPotion, false);
                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(3, 7);
                            }
                            if (num5 == 1)
                            {
                                Main.chest[num2].item[2].SetDefaults(ModContent.ItemType<TheBeak>(), false);
                                Main.chest[num2].item[2].stack = 1;
                            }
                            if (num5 == 2)
                            {
                                Main.chest[num2].item[2].SetDefaults(ItemID.SlushBlock, false);
                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(200, 451);
                            }
                            if (num5 == 3)
                            {
                                Main.chest[num2].item[2].SetDefaults(ItemID.IceBrick, false);
                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(30, 73);
                            }
                            if (num5 == 4)
                            {
                                Main.chest[num2].item[2].SetDefaults(ItemID.HandWarmer, false);
                                Main.chest[num2].item[2].Prefix(-1);
                            }
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
