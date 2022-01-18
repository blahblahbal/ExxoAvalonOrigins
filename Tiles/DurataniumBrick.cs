﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class DurataniumBrick : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.Purple);
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("DurataniumBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.DurataniumDust>();
        }
    }
}
