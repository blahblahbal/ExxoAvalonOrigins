using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class TroxiniumBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Goldenrod);
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("TroxiniumBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.TroxiniumDust>();
        }
	}
}
