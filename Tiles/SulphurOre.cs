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
	public class SulphurOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(218, 216, 114), LanguageManager.Instance.GetText("Sulphur"));
			Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
			drop = mod.ItemType("Sulphur");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Enchanted_Gold;
        }
	}
}
