using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Tiles
{
	public class FallenStarTile : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(Color.LightYellow);
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileFrameImportant[Type] = true;
			drop = ModContent.ItemType<Items.Placeable.Tile.FallenStarBlock>();
            dustType = DustID.TopazBolt;
		}
	}
}
