using System;
using ExxoAvalonOrigins.Players;
using ExxoAvalonOrigins.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Systems;

public class BiomeTileCounts : ModSystem
{
    public int ContagionTiles { get; private set; }
    public int TropicsTiles { get; private set; }
    public int HellCastleTiles { get; private set; }
    public int DarkTiles { get; private set; }
    public int CaesiumTiles { get; private set; }
    public int SkyFortressTiles { get; private set; }
    public int CrystalTiles { get; private set; }

    public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
    {
        // Main.jungleTiles += tileCounts[ModContent.TileType<GreenIce>()];
        // Main.sandTiles += tileCounts[ModContent.TileType<Snotsand>()];

        ContagionTiles = tileCounts[ModContent.TileType<Chunkstone>()] +
                         tileCounts[ModContent.TileType<HardenedSnotsand>()] +
                         tileCounts[ModContent.TileType<Snotsandstone>()] +
                         tileCounts[ModContent.TileType<Ickgrass>()] +
                         tileCounts[ModContent.TileType<Snotsand>()] +
                         tileCounts[ModContent.TileType<YellowIce>()];

        TropicsTiles = tileCounts[ModContent.TileType<TropicalStone>()] +
                       tileCounts[ModContent.TileType<TuhrtlBrick>()] +
                       tileCounts[ModContent.TileType<TropicalMud>()] +
                       tileCounts[ModContent.TileType<TropicalGrass>()];

        HellCastleTiles = tileCounts[ModContent.TileType<ImperviousBrick>()];

        DarkTiles = tileCounts[ModContent.TileType<DarkMatter>()] +
                    tileCounts[ModContent.TileType<DarkMatterSand>()] +
                    tileCounts[ModContent.TileType<BlackIce>()] +
                    tileCounts[ModContent.TileType<DarkMatterSoil>()] +
                    tileCounts[ModContent.TileType<HardenedDarkSand>()] +
                    tileCounts[ModContent.TileType<Darksandstone>()] +
                    tileCounts[ModContent.TileType<DarkMatterGrass>()];

        CaesiumTiles = tileCounts[ModContent.TileType<BlackBlaststone>()];
        SkyFortressTiles = tileCounts[ModContent.TileType<SkyBrick>()];
        CrystalTiles = tileCounts[ModContent.TileType<CrystalStone>()];

        Main.LocalPlayer.GetModPlayer<ExxoBiomePlayer>().UpdateZones(this);
    }
}
