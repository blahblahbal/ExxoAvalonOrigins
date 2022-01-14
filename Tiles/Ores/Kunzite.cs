using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class Kunzite : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.HotPink, LanguageManager.Instance.GetText("Kunzite"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 900;
            drop = mod.ItemType("Kunzite");
            soundType = SoundID.Tink;
            minPick = 210;
            soundStyle = 1;
            dustType = DustID.PinkFairy;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
