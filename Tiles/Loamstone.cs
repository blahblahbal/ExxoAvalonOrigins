using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class Loamstone : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(95, 38, 12));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileMerge[Type][ModContent.TileType<TropicalMud>()] = true;
        Main.tileMerge[ModContent.TileType<TropicalMud>()][Type] = true;
        drop = Mod.Find<ModItem>("LoamstoneBrick").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = ModContent.DustType<Dusts.TropicalMudDust>();
    }
}