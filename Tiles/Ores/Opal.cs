﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class Opal : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(165, 255, 127), LanguageManager.Instance.GetText("Opal"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			drop = mod.ItemType("Opal");
            Main.tileSpelunker[Type] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 900;
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 210;
            dustType = DustID.Stone;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}