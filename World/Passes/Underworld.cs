using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class Underworld
    {
        public static void Method(GenerationProgress progress)
        {
            progress.Message = "Generating Caesium Blastplains";
            //for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0008); i++)
            //{
            //    WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), (ushort)ModContent.TileType<Tiles.CaesiumOre>());
            //}
            for (int q = (Main.maxTilesX - Main.maxTilesX / 5) - 15; q < Main.maxTilesX - Main.maxTilesX / 5; q++)
            {
                for (int z = Main.maxTilesY - 250; z < Main.maxTilesY - 20; z++)
                {
                    if (q > (Main.maxTilesX - Main.maxTilesX / 5) - 10)
                    {
                        if (WorldGen.genRand.Next(10) == 0 && Main.tile[q, z].active() && Main.tile[q, z].type == TileID.Ash)
                        {
                            WorldGen.TileRunner(q, z, WorldGen.genRand.Next(6, 8), WorldGen.genRand.Next(6, 8), ModContent.TileType<Tiles.BlackBlaststone>());
                        }
                    }
                }
            }
            for (int q = Main.maxTilesX - Main.maxTilesX / 5; q < Main.maxTilesX - 20; q++)
            {
                for (int z = Main.maxTilesY - 250; z < Main.maxTilesY - 20; z++)
                {
                    //if (WorldGen.genRand.Next(20) == 0 && z >= Main.maxTilesY - 250 && z <= Main.maxTilesY - 241 && Main.tile[q, z].active()) Main.tile[q, z].type = (ushort)ModContent.TileType<Tiles.BlackBlaststone>();
                    //if (WorldGen.genRand.Next(10) == 0 && z >= Main.maxTilesY - 240 && z <= Main.maxTilesY - 231 && Main.tile[q, z].active()) Main.tile[q, z].type = (ushort)ModContent.TileType<Tiles.BlackBlaststone>();
                    //if (WorldGen.genRand.Next(5) == 0 && z >= Main.maxTilesY - 230 && z <= Main.maxTilesY - 221 && Main.tile[q, z].active()) Main.tile[q, z].type = (ushort)ModContent.TileType<Tiles.BlackBlaststone>();
                    if ((Main.tile[q, z].type == TileID.Ash || Main.tile[q, z].type == TileID.Hellstone) && Main.tile[q, z].active()) Main.tile[q, z].type = (ushort)ModContent.TileType<Tiles.BlackBlaststone>();
                    if (z < Main.maxTilesY - 125 && z > Main.maxTilesY - 165)
                    {
                        if (Main.tile[q, z].active() && !Main.tile[q, z - 1].active() ||
                            Main.tile[q, z].active() && !Main.tile[q, z + 1].active() ||
                            Main.tile[q, z].active() && !Main.tile[q - 1, z].active() ||
                            Main.tile[q, z].active() && !Main.tile[q + 1, z].active())
                        {
                            if (Main.tile[q, z].type != ModContent.TileType<Tiles.CaesiumOre>())
                            {
                                if (q % 20 == 0)
                                {
                                    Structures.CaesiumSpike.CreateSpikeUp(q, z, (ushort)ModContent.TileType<Tiles.CaesiumOre>()); // Structures.CaesiumSpike.CreateSpike(q, z);
                                }
                            }
                        }
                    }
                    if (z < Main.maxTilesY - 170 && z > Main.maxTilesY - 180)
                    {
                        if (Main.tile[q, z].active() && !Main.tile[q, z - 1].active() ||
                            Main.tile[q, z].active() && !Main.tile[q, z + 1].active() ||
                            Main.tile[q, z].active() && !Main.tile[q - 1, z].active() ||
                            Main.tile[q, z].active() && !Main.tile[q + 1, z].active())
                        {
                            if (Main.tile[q, z].type != ModContent.TileType<Tiles.CaesiumOre>())
                            {
                                if (q % 20 == 0)
                                {
                                    Structures.CaesiumSpike.CreateSpikeDown(q, z, (ushort)ModContent.TileType<Tiles.CaesiumOre>()); // Structures.CaesiumSpike.CreateSpike(q, z);
                                }
                            }
                        }
                    }
                    //if (z < Main.maxTilesY - 160 && z > Main.maxTilesY - 190)
                    //{
                    //    if (Main.tile[q, z].active() && !Main.tile[q, z - 1].active() ||
                    //        Main.tile[q, z].active() && !Main.tile[q, z + 1].active() ||
                    //        Main.tile[q, z].active() && !Main.tile[q - 1, z].active() ||
                    //        Main.tile[q, z].active() && !Main.tile[q + 1, z].active())
                    //    {
                    //        if (WorldGen.genRand.Next(40) == 0)
                    //        {
                    //            Structures.CaesiumSpike.CreateSpike(q, z);
                    //        }
                    //    }
                    //}
                }
            }
            progress.Message = "Generating Hellcastle and Ashen Overgrowth";
            World.Structures.HellCastle.Generate(Main.maxTilesX / 3 - 210, Main.maxTilesY - 140); // change back later
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
                            Main.tile[hbx, hby].type = (ushort)ModContent.TileType<Tiles.Impgrass>();
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
        }
    }
}
