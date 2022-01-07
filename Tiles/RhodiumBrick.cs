using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class RhodiumBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.Pink);
			Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("RhodiumBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.t_LivingWood;
        }
	}
}
