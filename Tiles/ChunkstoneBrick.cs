﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class ChunkstoneBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(109, 149, 91));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.ChunkstoneBrick>();
        SoundType = SoundID.Tink;
        SoundStyle = 1;
        DustType = ModContent.DustType<Dusts.ContagionDust>();
    }
}
