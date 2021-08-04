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
	public class PyroscoricOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(255, 102, 0), LanguageManager.Instance.GetText("Pyroscopic"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            drop = mod.ItemType("PyroscoricOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = 174;
            minPick = 210;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}