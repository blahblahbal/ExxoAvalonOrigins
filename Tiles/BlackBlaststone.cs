using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class BlackBlaststone : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(20, 20, 20));
			Main.tileSolid[Type] = true;
			Main.tileShine[Type] = 1150;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.BlackBlaststone>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Wraith;
            ExxoAvalonOrigins.MergeWith(Type, TileID.Ash);
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.Ash, false, false, false, false, resetFrame);
            return false;
        }
    }
}