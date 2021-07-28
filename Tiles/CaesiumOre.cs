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
	public class CaesiumOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 5f;
			AddMapEntry(new Color(86, 190, 74), LanguageManager.Instance.GetText("Caesium Ore"));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileMerge[Type][TileID.Ash] = true;
            drop = mod.ItemType("CaesiumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 200;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}