using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles
{
	public class BacciliteOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Olive, LanguageManager.Instance.GetText("Baccilite Ore"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine[Type] = 1150;
            Main.tileSpelunker[Type] = true;
			drop = ModContent.ItemType<Items.BacciliteOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 55;
		}
	}
}