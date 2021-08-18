using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ExxoAvalonOrigins.World.Passes
{
    class WaspNest
    {
        public static void Method(GenerationProgress progress)
        {
            progress.Message = "Adding nests...";
            int amount = WorldGen.genRand.Next(4, 8);
            bool flag30 = true;
            while (flag30)
            {
                int num406 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 500);
                int num407 = ((ExxoAvalonOriginsWorld.dungeonSide >= 0) ? WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.4)) : WorldGen.genRand.Next((int)(Main.maxTilesX * 0.6), (int)(Main.maxTilesX * 0.85)));
                if (Main.tile[num407, num406].active() && Main.tile[num407, num406].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
                {
                    flag30 = false;
                    Structures.Nest.CreateWaspNest(num407, num406);
                }
            }

            bool flag31 = true;
            while (flag31)
            {
                int num406 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 500);
                int num407 = ((ExxoAvalonOriginsWorld.dungeonSide >= 0) ? WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.4)) : WorldGen.genRand.Next((int)(Main.maxTilesX * 0.6), (int)(Main.maxTilesX * 0.85)));
                if (Main.tile[num407, num406].active() && Main.tile[num407, num406].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
                {
                    flag31 = false;
                    Structures.Nest.CreateWaspNest(num407, num406);
                }
            }

            bool flag32 = true;
            while (flag32)
            {
                int num406 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 500);
                int num407 = ((ExxoAvalonOriginsWorld.dungeonSide >= 0) ? WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.4)) : WorldGen.genRand.Next((int)(Main.maxTilesX * 0.6), (int)(Main.maxTilesX * 0.85)));
                if (Main.tile[num407, num406].active() && Main.tile[num407, num406].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
                {
                    flag32 = false;
                    Structures.Nest.CreateWaspNest(num407, num406);
                }
            }

            if (WorldGen.genRand.Next(3) == 0)
            {
                bool flag33 = true;
                while (flag33)
                {
                    int num406 = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 500);
                    int num407 = ((ExxoAvalonOriginsWorld.dungeonSide >= 0) ? WorldGen.genRand.Next((int)(Main.maxTilesX * 0.15), (int)(Main.maxTilesX * 0.4)) : WorldGen.genRand.Next((int)(Main.maxTilesX * 0.6), (int)(Main.maxTilesX * 0.85)));
                    if (Main.tile[num407, num406].active() && Main.tile[num407, num406].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>())
                    {
                        flag33 = false;
                        Structures.Nest.CreateWaspNest(num407, num406);
                    }
                }
            }
        }
    }
}
