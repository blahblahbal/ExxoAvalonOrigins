﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class SkyBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(102, 102, 82));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBrick[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Cloud][Type] = true;
            Main.tileMerge[Type][TileID.Cloud] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("SkyBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 300;
            dustType = DustID.Smoke;
        }
        public override bool Slope(int i, int j)
        {
            return ExxoAvalonOriginsWorld.downedDragonLord;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
