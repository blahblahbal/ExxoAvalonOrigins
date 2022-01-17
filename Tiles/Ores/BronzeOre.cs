﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class BronzeOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(121, 50, 42), LanguageManager.Instance.GetText("Bronze"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1100;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 215;
            Main.tileBlockLight[Type] = true;
			drop = ModContent.ItemType<Items.Placeable.Tile.BronzeOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.BronzeDust>();
		}
	}
}