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

        public override bool CanPlace(int i, int j)        {            return ExxoAvalonOrigins.beams.Contains(Main.tile[i - 1, j].type) || ExxoAvalonOrigins.beams.Contains(Main.tile[i + 1, j].type) || ExxoAvalonOrigins.beams.Contains(Main.tile[i, j - 1].type) || ExxoAvalonOrigins.beams.Contains(Main.tile[i, j + 1].type);        }
    }
}