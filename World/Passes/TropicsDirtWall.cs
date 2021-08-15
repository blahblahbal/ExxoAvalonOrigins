using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Terraria.ID;

namespace ExxoAvalonOrigins.World.Passes
{
    class TropicsDirtWall
    {
        public static void Method(GenerationProgress progress)
        {
            progress.Message = Language.GetTextValue("LegacyWorldGen.3");
            int howFar = 0;
            for (int x = 1; x < Main.maxTilesX - 1; x++)
            {
                byte wall = 2;

                float percentage = (float)x / (float)Main.maxTilesX;
                progress.Set(percentage);

                bool flag46 = false;
                howFar += WorldGen.genRand.Next(-1, 2);
                if (howFar < 0)
                {
                    howFar = 0;
                }
                if (howFar > 10)
                {
                    howFar = 10;
                }
                for (int y = 0; y < Main.worldSurface + 10.0 && !(y > Main.worldSurface + howFar); y++)
                {
                    if (Main.tile[x, y].active())
                    {
                        wall = (byte)((Main.tile[x, y].type == TileID.SnowBlock) ? WallID.SnowWallUnsafe : WallID.DirtUnsafe);
                    }
                    if (flag46 && Main.tile[x, y].wall != (ushort)ModContent.WallType<Walls.TropicalGrassWall>())
                    {
                        Main.tile[x, y].wall = wall;
                    }
                    if (Main.tile[x, y].active() && Main.tile[x - 1, y].active() && Main.tile[x + 1, y].active() && Main.tile[x, y + 1].active() && Main.tile[x - 1, y + 1].active() && Main.tile[x + 1, y + 1].active())
                    {
                        flag46 = true;
                    }
                }
            }
        }
    }
}
