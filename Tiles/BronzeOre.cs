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
	public class BronzeOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(135, 88, 61), LanguageManager.Instance.GetText("Bronze"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine[Type] = 1150;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
			drop = ModContent.ItemType<Items.BronzeOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = 9;
		}
	}
}