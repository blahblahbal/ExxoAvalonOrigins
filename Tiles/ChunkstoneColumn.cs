using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
	public class ChunkstoneColumn : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(73, 51, 36));
			//Main.tileBeam[Type] = true;
			drop = mod.ItemType("ChunkstoneColumn");
		}
	}
}