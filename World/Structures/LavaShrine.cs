using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Items.Placeable.Seed;
using ExxoAvalonOrigins.Items.Potions;
using ExxoAvalonOrigins.Items.Weapons.Ranged;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.World.Structures
{
    class LavaShrine
    {
        public static void AddLavaShrine(int x, int y)
        {
            ushort LA = TileID.Hellstone;
            ushort LB = TileID.HellstoneBrick;
            ushort MO = (ushort)ModContent.TileType<Tiles.BrimstoneBlock>();
            ushort backWall = (ushort)ModContent.WallType<Walls.ObsidianLavaTube>();
            Main.tile[x + 2, y].active(true);
            Main.tile[x + 5, y].active(true);
            Main.tile[x + 6, y].active(true);
            Main.tile[x + 9, y].active(true);
            Main.tile[x + 2, y].type = LB;
            Main.tile[x + 5, y].type = LB;
            Main.tile[x + 6, y].type = LB;
            Main.tile[x + 9, y].type = LB;
            for (int xoff = x + 2; xoff <= x + 9; xoff++)
            {
                Main.tile[xoff, y + 1].active(true);
                Main.tile[xoff, y + 1].type = LB;
            }
            Main.tile[x + 3, y + 2].active(true);
            Main.tile[x + 3, y + 3].active(true);
            Main.tile[x + 8, y + 2].active(true);
            Main.tile[x + 8, y + 3].active(true);

            Main.tile[x + 3, y + 2].type = LB;
            Main.tile[x + 3, y + 3].type = LB;
            Main.tile[x + 8, y + 2].type = LB;
            Main.tile[x + 8, y + 3].type = LB;
            for (int xoff = x + 4; xoff <= x + 7; xoff++)
            {
                for (int yoff = y + 2; yoff <= y + 3; yoff++)
                {
                    Main.tile[xoff, yoff].active(true);
                    Main.tile[xoff, yoff].type = LA;
                }
            }
            Main.tile[x + 4, y + 4].active(true);
            Main.tile[x + 5, y + 4].active(true);
            Main.tile[x + 6, y + 4].active(true);
            Main.tile[x + 7, y + 4].active(true);
            Main.tile[x + 5, y + 5].active(true);
            Main.tile[x + 6, y + 5].active(true);
            Main.tile[x + 7, y + 5].active(true);
            Main.tile[x + 5, y + 6].active(true);
            Main.tile[x + 5, y + 7].active(true);
            Main.tile[x + 5, y + 8].active(true);
            Main.tile[x + 4, y + 8].active(true);
            Main.tile[x + 3, y + 8].active(true);
            Main.tile[x + 3, y + 9].active(true);
            Main.tile[x + 3, y + 10].active(true);
            Main.tile[x + 2, y + 10].active(true);
            Main.tile[x + 1, y + 10].active(true);
            Main.tile[x + 1, y + 11].active(true);
            Main.tile[x, y + 11].active(true);
            Main.tile[x, y + 12].active(true);
            Main.tile[x, y + 13].active(true);
            Main.tile[x, y + 14].active(true);
            Main.tile[x + 1, y + 14].active(true);
            Main.tile[x + 1, y + 15].active(true);
            Main.tile[x + 2, y + 15].active(true);
            Main.tile[x + 2, y + 16].active(true);
            Main.tile[x + 3, y + 16].active(true);
            Main.tile[x + 3, y + 17].active(true);
            Main.tile[x + 4, y + 17].active(true);
            Main.tile[x + 5, y + 17].active(true);
            Main.tile[x + 6, y + 17].active(true);
            Main.tile[x + 6, y + 16].active(true);
            Main.tile[x + 7, y + 16].active(true);
            Main.tile[x + 8, y + 16].active(true);
            Main.tile[x + 8, y + 15].active(true);
            Main.tile[x + 9, y + 15].active(true);
            Main.tile[x + 9, y + 14].active(true);
            Main.tile[x + 10, y + 14].active(true);
            Main.tile[x + 10, y + 13].active(true);
            Main.tile[x + 11, y + 13].active(true);
            Main.tile[x + 12, y + 13].active(true);
            Main.tile[x + 13, y + 13].active(true);
            Main.tile[x + 13, y + 14].active(true);
            Main.tile[x + 14, y + 14].active(true);
            Main.tile[x + 14, y + 15].active(true);
            Main.tile[x + 15, y + 15].active(true);
            Main.tile[x + 16, y + 15].active(true);
            Main.tile[x + 16, y + 16].active(true);
            Main.tile[x + 17, y + 16].active(true);
            Main.tile[x + 18, y + 16].active(true);
            Main.tile[x + 19, y + 16].active(true);
            Main.tile[x + 19, y + 17].active(true);
            Main.tile[x + 20, y + 17].active(true);
            Main.tile[x + 20, y + 18].active(true);

            Main.tile[x + 4, y + 4].type = LB;
            Main.tile[x + 5, y + 4].type = LB;
            Main.tile[x + 6, y + 4].type = LB;
            Main.tile[x + 7, y + 4].type = LB;
            Main.tile[x + 5, y + 5].type = LB;
            Main.tile[x + 6, y + 5].type = LB;
            Main.tile[x + 7, y + 5].type = LB;
            Main.tile[x + 5, y + 6].type = LB;
            Main.tile[x + 5, y + 7].type = LB;
            Main.tile[x + 5, y + 8].type = LB;
            Main.tile[x + 4, y + 8].type = LB;
            Main.tile[x + 3, y + 8].type = LB;
            Main.tile[x + 3, y + 9].type = LB;
            Main.tile[x + 3, y + 10].type = LB;
            Main.tile[x + 2, y + 10].type = LB;
            Main.tile[x + 1, y + 10].type = LB;
            Main.tile[x + 1, y + 11].type = LB;
            Main.tile[x, y + 11].type = LB;
            Main.tile[x, y + 12].type = LB;
            Main.tile[x, y + 13].type = LB;
            Main.tile[x, y + 14].type = LB;
            Main.tile[x + 1, y + 14].type = LB;
            Main.tile[x + 1, y + 15].type = LB;
            Main.tile[x + 2, y + 15].type = LB;
            Main.tile[x + 2, y + 16].type = LB;
            Main.tile[x + 3, y + 16].type = LB;
            Main.tile[x + 3, y + 17].type = LB;
            Main.tile[x + 4, y + 17].type = LB;
            Main.tile[x + 5, y + 17].type = LB;
            Main.tile[x + 6, y + 17].type = LB;
            Main.tile[x + 6, y + 16].type = LB;
            Main.tile[x + 7, y + 16].type = LB;
            Main.tile[x + 8, y + 16].type = LB;
            Main.tile[x + 8, y + 15].type = LB;
            Main.tile[x + 9, y + 15].type = LB;
            Main.tile[x + 9, y + 14].type = LB;
            Main.tile[x + 10, y + 14].type = LB;
            Main.tile[x + 10, y + 13].type = LB;
            Main.tile[x + 11, y + 13].type = LB;
            Main.tile[x + 12, y + 13].type = LB;
            Main.tile[x + 13, y + 13].type = LB;
            Main.tile[x + 13, y + 14].type = LB;
            Main.tile[x + 14, y + 14].type = LB;
            Main.tile[x + 14, y + 15].type = LB;
            Main.tile[x + 15, y + 15].type = LB;
            Main.tile[x + 16, y + 15].type = LB;
            Main.tile[x + 16, y + 16].type = LB;
            Main.tile[x + 17, y + 16].type = LB;
            Main.tile[x + 18, y + 16].type = LB;
            Main.tile[x + 19, y + 16].type = LB;
            Main.tile[x + 19, y + 17].type = LB;
            Main.tile[x + 20, y + 17].type = LB;
            Main.tile[x + 20, y + 18].type = LB;

            //------------------------------------------------------------
            for (int xoff = x + 8; xoff <= x + 36; xoff++)
            {
                Main.tile[xoff, y + 5].active(true);
                Main.tile[xoff, y + 5].type = LB;
            }


            Main.tile[x + 11, y + 4].active(true);
            Main.tile[x + 12, y + 4].active(true);
            Main.tile[x + 13, y + 4].active(true);

            Main.tile[x + 14, y + 4].active(true); // LA

            Main.tile[x + 15, y + 4].active(true);
            Main.tile[x + 16, y + 4].active(true);

            Main.tile[x + 17, y + 4].active(true); // LA
            Main.tile[x + 18, y + 4].active(true); // LA

            Main.tile[x + 13, y + 3].active(true);
            Main.tile[x + 14, y + 3].active(true);
            Main.tile[x + 15, y + 3].active(true);

            Main.tile[x + 16, y + 3].active(true); // LA

            Main.tile[x + 17, y + 3].active(true);

            Main.tile[x + 18, y + 3].active(true); // LA

            Main.tile[x + 14, y + 2].active(true);
            Main.tile[x + 15, y + 2].active(true);
            Main.tile[x + 16, y + 2].active(true);
            Main.tile[x + 17, y + 2].active(true);
            Main.tile[x + 18, y + 2].active(true);

            for (int xoff = x + 19; xoff <= x + 25; xoff++)
            {
                for (int yoff = y + 2; yoff <= y + 4; yoff++)
                {
                    Main.tile[xoff, yoff].active(true);
                    Main.tile[xoff, yoff].type = LA;
                }
            }
            for (int xoff = x + 16; xoff <= x + 28; xoff++)
            {
                Main.tile[xoff, y + 1].active(true);
                Main.tile[xoff, y + 1].type = LB;
            }

            Main.tile[x + 26, y + 2].active(true);
            Main.tile[x + 27, y + 2].active(true);
            Main.tile[x + 28, y + 2].active(true);
            Main.tile[x + 29, y + 2].active(true);
            Main.tile[x + 30, y + 2].active(true);

            Main.tile[x + 26, y + 3].active(true); // LA

            Main.tile[x + 27, y + 3].active(true);

            Main.tile[x + 28, y + 3].active(true); // LA

            Main.tile[x + 29, y + 3].active(true);
            Main.tile[x + 30, y + 3].active(true);
            Main.tile[x + 31, y + 3].active(true);

            Main.tile[x + 26, y + 4].active(true); // LA
            Main.tile[x + 27, y + 4].active(true); // LA

            Main.tile[x + 28, y + 4].active(true);
            Main.tile[x + 29, y + 4].active(true);

            Main.tile[x + 30, y + 4].active(true); // LA



            Main.tile[x + 11, y + 4].type = LB;
            Main.tile[x + 12, y + 4].type = LB;
            Main.tile[x + 13, y + 4].type = LB;

            Main.tile[x + 14, y + 4].type = LA; // LA

            Main.tile[x + 15, y + 4].type = LB;
            Main.tile[x + 16, y + 4].type = LB;

            Main.tile[x + 17, y + 4].type = LA; // LA
            Main.tile[x + 18, y + 4].type = LA; // LA

            Main.tile[x + 13, y + 3].type = LB;
            Main.tile[x + 14, y + 3].type = LB;
            Main.tile[x + 15, y + 3].type = LB;

            Main.tile[x + 16, y + 3].type = LA; // LA

            Main.tile[x + 17, y + 3].type = LB;

            Main.tile[x + 18, y + 3].type = LA; // LA

            Main.tile[x + 14, y + 2].type = LB;
            Main.tile[x + 15, y + 2].type = LB;
            Main.tile[x + 16, y + 2].type = LB;
            Main.tile[x + 17, y + 2].type = LB;
            Main.tile[x + 18, y + 2].type = LB;

            Main.tile[x + 26, y + 2].type = LB;
            Main.tile[x + 27, y + 2].type = LB;
            Main.tile[x + 28, y + 2].type = LB;
            Main.tile[x + 29, y + 2].type = LB;
            Main.tile[x + 30, y + 2].type = LB;

            Main.tile[x + 26, y + 3].type = LA; // LA

            Main.tile[x + 27, y + 3].type = LB;

            Main.tile[x + 28, y + 3].type = LA; // LA

            Main.tile[x + 29, y + 3].type = LB;
            Main.tile[x + 30, y + 3].type = LB;
            Main.tile[x + 31, y + 3].type = LB;

            Main.tile[x + 26, y + 4].type = LA; // LA
            Main.tile[x + 27, y + 4].type = LA; // LA

            Main.tile[x + 28, y + 4].type = LB;
            Main.tile[x + 29, y + 4].type = LB;

            Main.tile[x + 30, y + 4].type = LA; // LA

            Main.tile[x + 24, y + 18].active(true);
            Main.tile[x + 24, y + 17].active(true);
            Main.tile[x + 25, y + 17].active(true);
            Main.tile[x + 25, y + 16].active(true);
            Main.tile[x + 26, y + 16].active(true);
            Main.tile[x + 27, y + 16].active(true);
            Main.tile[x + 28, y + 16].active(true);
            Main.tile[x + 28, y + 15].active(true);
            Main.tile[x + 29, y + 15].active(true);
            Main.tile[x + 30, y + 15].active(true);
            Main.tile[x + 30, y + 14].active(true);
            Main.tile[x + 31, y + 14].active(true);
            Main.tile[x + 31, y + 13].active(true);
            Main.tile[x + 32, y + 13].active(true);
            Main.tile[x + 33, y + 13].active(true);
            Main.tile[x + 34, y + 13].active(true);
            Main.tile[x + 34, y + 14].active(true);
            Main.tile[x + 35, y + 14].active(true);
            Main.tile[x + 35, y + 15].active(true);
            Main.tile[x + 36, y + 15].active(true);
            Main.tile[x + 36, y + 16].active(true);
            Main.tile[x + 37, y + 16].active(true);
            Main.tile[x + 38, y + 16].active(true);
            Main.tile[x + 38, y + 17].active(true);
            Main.tile[x + 39, y + 17].active(true);
            Main.tile[x + 40, y + 17].active(true);
            Main.tile[x + 41, y + 17].active(true);
            Main.tile[x + 41, y + 16].active(true);
            Main.tile[x + 42, y + 16].active(true);
            Main.tile[x + 42, y + 15].active(true);
            Main.tile[x + 43, y + 15].active(true);
            Main.tile[x + 43, y + 14].active(true);
            Main.tile[x + 44, y + 14].active(true);
            Main.tile[x + 44, y + 13].active(true);
            Main.tile[x + 44, y + 12].active(true);
            Main.tile[x + 44, y + 11].active(true);
            Main.tile[x + 43, y + 11].active(true);
            Main.tile[x + 43, y + 10].active(true);
            Main.tile[x + 42, y + 10].active(true);
            Main.tile[x + 41, y + 10].active(true);
            Main.tile[x + 41, y + 9].active(true);
            Main.tile[x + 41, y + 8].active(true);
            Main.tile[x + 40, y + 8].active(true);
            Main.tile[x + 39, y + 8].active(true);
            Main.tile[x + 39, y + 7].active(true);
            Main.tile[x + 39, y + 6].active(true);
            Main.tile[x + 39, y + 5].active(true);
            Main.tile[x + 38, y + 5].active(true);
            Main.tile[x + 37, y + 5].active(true);
            Main.tile[x + 37, y + 4].active(true);
            Main.tile[x + 38, y + 4].active(true);
            Main.tile[x + 39, y + 4].active(true);
            Main.tile[x + 40, y + 4].active(true);
            Main.tile[x + 36, y + 3].active(true);
            Main.tile[x + 36, y + 2].active(true);
            Main.tile[x + 41, y + 3].active(true);
            Main.tile[x + 41, y + 2].active(true);
            Main.tile[x + 35, y + 1].active(true);
            Main.tile[x + 36, y + 1].active(true);
            Main.tile[x + 37, y + 1].active(true);
            Main.tile[x + 38, y + 1].active(true);
            Main.tile[x + 39, y + 1].active(true);
            Main.tile[x + 40, y + 1].active(true);
            Main.tile[x + 41, y + 1].active(true);
            Main.tile[x + 42, y + 1].active(true);
            Main.tile[x + 35, y].active(true);
            Main.tile[x + 38, y].active(true);
            Main.tile[x + 39, y].active(true);
            Main.tile[x + 42, y].active(true);
            for (int xoff = x + 37; xoff <= x + 40; xoff++)
            {
                for (int yoff = y + 2; yoff <= y + 3; yoff++)
                {
                    Main.tile[xoff, yoff].active(true);
                    Main.tile[xoff, yoff].type = LA;
                }
            }
            Main.tile[x + 24, y + 18].type = LB;
            Main.tile[x + 24, y + 17].type = LB;
            Main.tile[x + 25, y + 17].type = LB;
            Main.tile[x + 25, y + 16].type = LB;
            Main.tile[x + 26, y + 16].type = LB;
            Main.tile[x + 27, y + 16].type = LB;
            Main.tile[x + 28, y + 16].type = LB;
            Main.tile[x + 28, y + 15].type = LB;
            Main.tile[x + 29, y + 15].type = LB;
            Main.tile[x + 30, y + 15].type = LB;
            Main.tile[x + 30, y + 14].type = LB;
            Main.tile[x + 31, y + 14].type = LB;
            Main.tile[x + 31, y + 13].type = LB;
            Main.tile[x + 32, y + 13].type = LB;
            Main.tile[x + 33, y + 13].type = LB;
            Main.tile[x + 34, y + 13].type = LB;
            Main.tile[x + 34, y + 14].type = LB;
            Main.tile[x + 35, y + 14].type = LB;
            Main.tile[x + 35, y + 15].type = LB;
            Main.tile[x + 36, y + 15].type = LB;
            Main.tile[x + 36, y + 16].type = LB;
            Main.tile[x + 37, y + 16].type = LB;
            Main.tile[x + 38, y + 16].type = LB;
            Main.tile[x + 38, y + 17].type = LB;
            Main.tile[x + 39, y + 17].type = LB;
            Main.tile[x + 40, y + 17].type = LB;
            Main.tile[x + 41, y + 17].type = LB;
            Main.tile[x + 41, y + 16].type = LB;
            Main.tile[x + 42, y + 16].type = LB;
            Main.tile[x + 42, y + 15].type = LB;
            Main.tile[x + 43, y + 15].type = LB;
            Main.tile[x + 43, y + 14].type = LB;
            Main.tile[x + 44, y + 14].type = LB;
            Main.tile[x + 44, y + 13].type = LB;
            Main.tile[x + 44, y + 12].type = LB;
            Main.tile[x + 44, y + 11].type = LB;
            Main.tile[x + 43, y + 11].type = LB;
            Main.tile[x + 43, y + 10].type = LB;
            Main.tile[x + 42, y + 10].type = LB;
            Main.tile[x + 41, y + 10].type = LB;
            Main.tile[x + 41, y + 9].type = LB;
            Main.tile[x + 41, y + 8].type = LB;
            Main.tile[x + 40, y + 8].type = LB;
            Main.tile[x + 39, y + 8].type = LB;
            Main.tile[x + 39, y + 7].type = LB;
            Main.tile[x + 39, y + 6].type = LB;
            Main.tile[x + 39, y + 5].type = LB;
            Main.tile[x + 38, y + 5].type = LB;
            Main.tile[x + 37, y + 5].type = LB;
            Main.tile[x + 37, y + 4].type = LB;
            Main.tile[x + 38, y + 4].type = LB;
            Main.tile[x + 39, y + 4].type = LB;
            Main.tile[x + 40, y + 4].type = LB;
            Main.tile[x + 36, y + 3].type = LB;
            Main.tile[x + 36, y + 2].type = LB;
            Main.tile[x + 41, y + 3].type = LB;
            Main.tile[x + 41, y + 2].type = LB;
            Main.tile[x + 35, y + 1].type = LB;
            Main.tile[x + 36, y + 1].type = LB;
            Main.tile[x + 37, y + 1].type = LB;
            Main.tile[x + 38, y + 1].type = LB;
            Main.tile[x + 39, y + 1].type = LB;
            Main.tile[x + 40, y + 1].type = LB;
            Main.tile[x + 41, y + 1].type = LB;
            Main.tile[x + 42, y + 1].type = LB;
            Main.tile[x + 35, y].type = LB;
            Main.tile[x + 38, y].type = LB;
            Main.tile[x + 39, y].type = LB;
            Main.tile[x + 42, y].type = LB;

            for (int xoff = x + 6; xoff <= x + 38; xoff++)
            {
                for (int yoff = y + 6; yoff <= y + 12; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 17; xoff <= x + 27; xoff++)
            {
                for (int yoff = y + 13; yoff <= y + 15; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 15; xoff <= x + 29; xoff++)
            {
                for (int yoff = y + 13; yoff <= y + 14; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 20; xoff <= x + 24; xoff++)
            {
                Main.tile[xoff, y + 16].active(false);
                Main.tile[xoff, y + 16].wall = backWall;
            }

            Main.tile[x + 14, y + 13].active(true);
            Main.tile[x + 15, y + 14].active(true);
            Main.tile[x + 16, y + 14].active(true);
            Main.tile[x + 17, y + 15].active(true);
            Main.tile[x + 18, y + 15].active(true);
            Main.tile[x + 26, y + 15].active(true);
            Main.tile[x + 27, y + 15].active(true);
            Main.tile[x + 28, y + 14].active(true);
            Main.tile[x + 29, y + 14].active(true);
            Main.tile[x + 30, y + 13].active(true);

            Main.tile[x + 14, y + 13].type = 19;
            Main.tile[x + 15, y + 14].type = 19;
            Main.tile[x + 16, y + 14].type = 19;
            Main.tile[x + 17, y + 15].type = 19;
            Main.tile[x + 18, y + 15].type = 19;
            Main.tile[x + 26, y + 15].type = 19;
            Main.tile[x + 27, y + 15].type = 19;
            Main.tile[x + 28, y + 14].type = 19;
            Main.tile[x + 29, y + 14].type = 19;
            Main.tile[x + 30, y + 13].type = 19;

            Main.tile[x + 14, y + 13].wall = backWall;
            Main.tile[x + 30, y + 13].wall = backWall;

            WorldGen.PlaceTile(x + 12, y + 12, 4, true, true, -1, 2);
            WorldGen.PlaceTile(x + 32, y + 12, 4, true, true, -1, 2);

            for (int xoff = x + 2; xoff <= x + 8; xoff++)
            {
                for (int yoff = y + 11; yoff <= y + 14; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 36; xoff <= x + 42; xoff++)
            {
                for (int yoff = y + 11; yoff <= y + 14; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 3; xoff <= x + 7; xoff++)
            {
                Main.tile[xoff, y + 15].active(false);
                Main.tile[xoff, y + 15].wall = backWall;
            }
            for (int xoff = x + 37; xoff <= x + 41; xoff++)
            {
                Main.tile[xoff, y + 15].active(false);
                Main.tile[xoff, y + 15].wall = backWall;
            }
            Main.tile[x + 4, y + 16].active(false);
            Main.tile[x + 5, y + 16].active(false);
            Main.tile[x + 39, y + 16].active(false);
            Main.tile[x + 40, y + 16].active(false);
            Main.tile[x + 9, y + 13].active(false);
            Main.tile[x + 35, y + 13].active(false);

            Main.tile[x + 4, y + 16].wall = backWall;
            Main.tile[x + 5, y + 16].wall = backWall;
            Main.tile[x + 39, y + 16].wall = backWall;
            Main.tile[x + 40, y + 16].wall = backWall;
            Main.tile[x + 9, y + 13].wall = backWall;
            Main.tile[x + 35, y + 13].wall = backWall;

            for (int xoff = x + 4; xoff <= x + 5; xoff++)
            {
                for (int yoff = y + 9; yoff <= y + 10; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 39; xoff <= x + 40; xoff++)
            {
                for (int yoff = y + 9; yoff <= y + 10; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 6; xoff <= x + 10; xoff++)
            {
                Main.tile[xoff, y + 8].active(true);
                Main.tile[xoff, y + 8].type = MO;
            }
            for (int xoff = x + 34; xoff <= x + 38; xoff++)
            {
                Main.tile[xoff, y + 8].active(true);
                Main.tile[xoff, y + 8].type = MO;
            }
            Main.tile[x + 10, y + 9].active(true);
            Main.tile[x + 34, y + 9].active(true);
            Main.tile[x + 10, y + 9].type = MO;
            Main.tile[x + 34, y + 9].type = MO;

            WorldGen.PlaceTile(x + 6, y + 6, 4, true, true, -1, 2);
            WorldGen.PlaceTile(x + 38, y + 6, 4, true, true, -1, 2);

            for (int xoff = x + 21; xoff <= x + 23; xoff++)
            {
                for (int yoff = y + 18; yoff <= y + 21; yoff++)
                {
                    Main.tile[xoff, yoff].active(false);
                    Main.tile[xoff, yoff].wall = backWall;
                }
            }
            for (int xoff = x + 20; xoff <= x + 24; xoff++)
            {
                Main.tile[xoff, y + 22].active(true);
                Main.tile[xoff, y + 22].type = LB;
            }
            for (int xoff = x + 21; xoff <= x + 23; xoff++)
            {
                Main.tile[xoff, y + 23].active(true);
                Main.tile[xoff, y + 23].type = LB;
            }

            WorldGen.PlaceTile(x + 22, y + 21, 4, true, true, -1, 2);

            WorldGen.PlaceDoor(x + 20, y + 20, 10, 19);
            WorldGen.PlaceDoor(x + 24, y + 20, 10, 19);
            WorldGen.PlaceDoor(x + 10, y + 11, 10, 19);
            WorldGen.PlaceDoor(x + 34, y + 11, 10, 19);
            for (int xoff = x + 21; xoff <= x + 23; xoff++)
            {
                Main.tile[xoff, y + 17].active(true);
                Main.tile[xoff, y + 17].type = 19;
                Main.tile[xoff, y + 17].wall = backWall;
            }
            for (int xoff = x + 31; xoff <= x + 33; xoff++)
            {
                Main.tile[xoff, y + 4].active(true);
                Main.tile[xoff, y + 4].type = LB;
            }
            Main.tile[x + 43, y + 12].active(false);
            Main.tile[x + 43, y + 13].active(false);
            Main.tile[x + 1, y + 12].active(false);
            Main.tile[x + 1, y + 13].active(false);
            Main.tile[x + 43, y + 12].wall = backWall;
            Main.tile[x + 43, y + 13].wall = backWall;
            Main.tile[x + 1, y + 12].wall = backWall;
            Main.tile[x + 1, y + 13].wall = backWall;

            WorldGen.PlaceTile(x + 43, y + 12, 4, true, true, -1, 2);
            WorldGen.PlaceTile(x + 1, y + 12, 4, true, true, -1, 2);
            //WorldGen.SquareTileFrameArea(x, y, 44);
            AddLavaChest(x + 5, y + 15, 0, false, 1);
            AddLavaChest(x + 40, y + 17, 0, false, 1);
        }

        public static bool AddLavaChest(int i, int j, int contain = 0, bool notNearOtherChests = false, int Style = -1)
        {
            //if (WorldGen.genRand == null)
            //    WorldGen.genRand = new Random((int)DateTime.Now.Ticks);
            int k = j;
            while (k < Main.maxTilesY)
            {
                if (Main.tile[i, k].active() && Main.tileSolid[(int)Main.tile[i, k].type])
                {
                    int num = k;
                    int num2 = WorldGen.PlaceChest(i - 1, num - 1, (ushort)ModContent.TileType<Tiles.HellfireChest>(), notNearOtherChests, 0);
                    if (num2 >= 0)
                    {
                        int num3 = 0;
                        while (num3 == 0)
                        {
                            int rN = WorldGen.genRand.Next(42);
                            if (rN >= 0 && rN <= 20)
                            {
                                Main.chest[num2].item[0].SetDefaults(174, false);
                                Main.chest[num2].item[0].stack = WorldGen.genRand.Next(41, 68);
                            }
                            else if (rN >= 21 && rN <= 41)
                            {
                                Main.chest[num2].item[0].SetDefaults(175, false);
                                Main.chest[num2].item[0].stack = WorldGen.genRand.Next(2, 7);
                            }
                            int rand = WorldGen.genRand.Next(51);
                            if (rand >= 0 && rand <= 20)
                            {
                                Main.chest[num2].item[1].SetDefaults(ItemID.Gatligator, false);
                                Main.chest[num2].item[1].Prefix(-2);
                            }
                            else if (rand >= 21 && rand <= 30)
                            {
                                Main.chest[num2].item[1].SetDefaults(ModContent.ItemType<SunlightKunai>(), false);
                                Main.chest[num2].item[1].stack = WorldGen.genRand.Next(77, 125);
                            }
                            else if (rand >= 31 && rand <= 40)
                            {
                                Main.chest[num2].item[1].SetDefaults(ModContent.ItemType<CrimsonPotion>(), false);
                                Main.chest[num2].item[1].stack = WorldGen.genRand.Next(3) + 1;
                            }
                            else if (rand >= 41 && rand <= 50)
                            {
                                Main.chest[num2].item[1].SetDefaults(ModContent.ItemType<ShockwavePotion>(), false);
                                Main.chest[num2].item[1].stack = WorldGen.genRand.Next(3) + 1;
                            }
                            int rand2 = WorldGen.genRand.Next(27);
                            if (rand2 >= 0 && rand2 <= 10)
                            {
                                Main.chest[num2].item[2].SetDefaults(73, false);
                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(20, 31);
                            }
                            else if (rand2 >= 11 && rand2 <= 25)
                            {
                                Main.chest[num2].item[2].SetDefaults(ModContent.ItemType<HellstoneSeed>(), false);
                                Main.chest[num2].item[2].stack = WorldGen.genRand.Next(400, 556);
                            }
                            else if (rand2 == 26)
                            {
                                Main.chest[num2].item[2].SetDefaults(ItemID.LavaWaders, false);
                                Main.chest[num2].item[2].Prefix(-2);
                            }
                            int rand3 = WorldGen.genRand.Next(27);
                            if (rand3 >= 0 && rand2 <= 10)
                            {
                                Main.chest[num2].item[3].SetDefaults(ItemID.LavaCharm, false);
                                Main.chest[num2].item[3].Prefix(-2);
                            }
                            else if (rand3 >= 11 && rand2 <= 25)
                            {
                                Main.chest[num2].item[3].SetDefaults(ModContent.ItemType<BagofFire>(), false);
                            }
                            else if (rand3 == 26)
                            {
                                Main.chest[num2].item[3].SetDefaults(73, false);
                                Main.chest[num2].item[3].stack = WorldGen.genRand.Next(20, 34);
                            }
                            num3++;
                        }
                        return true;
                    }
                    return false;
                }
                else k++;
            }
            return false;
        }
    }
}
