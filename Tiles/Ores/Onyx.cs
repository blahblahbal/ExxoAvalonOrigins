using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class Onyx : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(30, 30, 30), LanguageManager.Instance.GetText("Onyx"));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 900;
            drop = mod.ItemType("Onyx");
            minPick = 210;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Wraith;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
