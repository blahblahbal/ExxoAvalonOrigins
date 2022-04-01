﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class ZincBrick : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(168, 155, 168));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1950;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.ZincBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.ZincDust>();
        }
    }
}
