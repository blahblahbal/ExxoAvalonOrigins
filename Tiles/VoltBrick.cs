using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class VoltBrick : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("VoltBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.VilePowder;
        }
	}
}
