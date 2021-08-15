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
            progress.Message = "Generating Hellcastle and Ashen Overgrowth";
            for (var i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 0.0008); i++)
            {
                WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(Main.maxTilesY - 150, Main.maxTilesY), WorldGen.genRand.Next(2, 6), WorldGen.genRand.Next(3, 5), (ushort)ModContent.TileType<Tiles.CaesiumOre>());
            }
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
