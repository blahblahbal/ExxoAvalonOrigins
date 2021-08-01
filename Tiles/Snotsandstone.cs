﻿using Microsoft.Xna.Framework;
    public class Snotsandstone : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(91, 109, 86));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Sandstone][Type] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[TileID.HardenedSand][Type] = true;
            Main.tileMerge[Type][ModContent.TileType<HardenedSnotsand>()] = true;
            Main.tileMerge[ModContent.TileType<HardenedSnotsand>()][Type] = true;
            drop = mod.ItemType("SnotsandstoneBlock");
    }