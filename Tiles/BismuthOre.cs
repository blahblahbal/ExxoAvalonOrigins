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
	public class BismuthOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(204, 138, 174), LanguageManager.Instance.GetText("Bismuth"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine[Type] = 1150;
            Main.tileSpelunker[Type] = true;
			drop = ModContent.ItemType<Items.BismuthOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = 52;
		}
	}
}