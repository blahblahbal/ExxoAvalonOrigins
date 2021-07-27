using ExxoAvalonOrigins.Tiles;
using Terraria;
using Terraria.ModLoader;
using WG = On.Terraria.WorldGen;

namespace ExxoAvalonOrigins.Altair
{
    public class Altair
    {
        public static void AltairHooks()
        {
            WG.SmashAltar += catchSmashAltar;
        }

        public static void catchSmashAltar(WG.orig_SmashAltar orig, int i, int j)
        {
            if (WorldGen.oreTier3 != -1)
            {
                orig(i, j);
                return;
            }
            if (Main.netMode == 1 || !Main.hardMode || (WorldGen.noTileActions || WorldGen.gen))
            {
                orig(i, j);
                return;
            }

            var num1 = WorldGen.altarCount % 3;
            if (WorldGen.genRand.Next(3) == 0)
            {
                switch (num1)
                {
                    case 0:
                        WorldGen.oreTier1 = ModContent.TileType<DurataniumOre>();
                        break;
                    case 1:
                        WorldGen.oreTier2 = ModContent.TileType<NaquadahOre>();
                        break;
                    case 2:
                        WorldGen.oreTier3 = ModContent.TileType<TroxiniumOre>();
                        break;
                }
            }

            orig(i, j);
        }
    }
}