using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class ImperviousBrick : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(10, 10, 10));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBrick[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Ash][Type] = true;
            Main.tileMerge[Type][TileID.Ash] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("ImperviousBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 300;
            dustType = DustID.Wraith;
        }
        public override bool Slope(int i, int j)
        {
            return ExxoAvalonOriginsWorld.downedPhantasm;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
