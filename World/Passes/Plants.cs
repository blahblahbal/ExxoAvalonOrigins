using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ExxoAvalonOrigins.World.Passes
{
    class Plants
    {
        public static void Method(GenerationProgress progress)
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 1; j < Main.maxTilesY; j++)
                {
                    if (Main.tile[i, j].type == (ushort)ModContent.TileType<Tiles.Ickgrass>() && Main.tile[i, j].nactive() && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].halfBrick() && Main.rand.Next(3) == 0)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Main.tile[i, j - 1].type = (ushort)ModContent.TileType<Tiles.ContagionShortGrass>();
                            Main.tile[i, j - 1].frameX = (short)(WorldGen.genRand.Next(0, 11) * 18);
                        }
                    }
                    if (Main.tile[i, j].type == (ushort)ModContent.TileType<Tiles.TropicalGrass>() && Main.tile[i, j].nactive() && Main.tile[i, j].slope() == 0 && !Main.tile[i, j].halfBrick() && Main.rand.Next(3) == 0)
                    {
                        if (!Main.tile[i, j - 1].active())
                        {
                            Main.tile[i, j - 1].type = (ushort)ModContent.TileType<Tiles.TropicalShortGrass>();
                            Main.tile[i, j - 1].frameX = (short)(WorldGen.genRand.Next(0, 8) * 18);
                        }
                    }
                }
            }
        }
    }
}
