﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class OsmiumOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 2f;
			AddMapEntry(new Color(0, 148, 255), LanguageManager.Instance.GetText("Osmium"));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 430;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1150;
            drop = mod.ItemType("OsmiumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 60;
            dustType = ModContent.DustType<Dusts.OsmiumDust>();
        }
	}
}