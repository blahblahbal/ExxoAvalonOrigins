using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class TuhrtlBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(78, 70, 67));
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        Main.tileBlockLight[Type] = true;
        drop = Mod.Find<ModItem>("TuhrtlBrick").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 210;
        dustType = DustID.Silt;
        ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalMud>());
        ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalGrass>());
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        ExxoAvalonOrigins.MergeWithFrame(i, j, Type, ModContent.TileType<TropicalMud>(), false, false, false, false, resetFrame);
        return false;
    }
}