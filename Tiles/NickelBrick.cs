using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class NickelBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(82, 112, 122));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
			Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 2000;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.NickelBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
			dustType = ModContent.DustType<Dusts.NickelDust>();
		}
	}
}
