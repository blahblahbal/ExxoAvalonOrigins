﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class TroxiniumBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Goldenrod);
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        Main.tileBlockLight[Type] = true;
        drop = Mod.Find<ModItem>("TroxiniumBrick").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = ModContent.DustType<Dusts.TroxiniumDust>();
    }
}