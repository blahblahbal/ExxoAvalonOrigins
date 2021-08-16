﻿using Microsoft.Xna.Framework;
    public class Darksandstone : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(63, 0, 63));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Sandstone][Type] = true;
            Main.tileMerge[Type][TileID.HardenedSand] = true;
            Main.tileMerge[TileID.HardenedSand][Type] = true;
            drop = mod.ItemType("DarksandstoneBlock");
    }