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
			AddMapEntry(Color.Olive, LanguageManager.Instance.GetText("Baccilite"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine[Type] = 1150;
            Main.tileSpelunker[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileValue[Type] = 320;
			Main.tileLighted[Type] = true;
			drop = ModContent.ItemType<Items.BacciliteOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.JungleSpore;
            minPick = 55;
		}
		
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.18f;
			g = 0.25f;
		}
	}
}