using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class OblivionBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.DarkViolet);
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("OblivionBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Adamantine;
        }
	}
}
