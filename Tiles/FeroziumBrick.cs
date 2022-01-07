using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class FeroziumBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(0, 0, 250));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("FeroziumBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Ultrabright;
        }
	}
}
