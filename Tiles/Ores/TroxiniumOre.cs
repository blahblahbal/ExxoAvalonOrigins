﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class TroxiniumOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 4f;
			AddMapEntry(Color.Goldenrod, LanguageManager.Instance.GetText("Troxinium"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileValue[Type] = 660;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 875;
            drop = mod.ItemType("TroxiniumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 150;
            dustType = ModContent.DustType<Dusts.TroxiniumDust>();
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}