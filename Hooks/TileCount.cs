using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks;

public class TileCount
{
    public static void OnSquareTileFrame(On.Terraria.WorldGen.orig_SquareTileFrame orig, int i, int j, bool resetFrame)
    {
        int type = Main.tile[i, j].TileType;
        if (type == ModContent.TileType<Tiles.DarkMatterSoil>() ||
            type == ModContent.TileType<Tiles.DarkMatter>() ||
            type == ModContent.TileType<Tiles.DarkMatterSand>() ||
            type == ModContent.TileType<Tiles.Darksandstone>() ||
            type == ModContent.TileType<Tiles.HardenedDarkSand>() ||
            type == ModContent.TileType<Tiles.DarkMatterGrass>() ||
            type == ModContent.TileType<Tiles.BlackIce>())
        {
            ExxoAvalonOriginsWorld.WorldDarkMatterTiles++;
        }
        orig(i, j, resetFrame);
    }
}