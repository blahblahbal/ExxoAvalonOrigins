using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class ShroomiteOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 5f;
			AddMapEntry(Color.CornflowerBlue, LanguageManager.Instance.GetText("Shroomite"));
			Main.tileSolid[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 705;
            Main.tileBlockLight[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1400;
            drop = mod.ItemType("ShroomiteOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 205;
            dustType = DustID.Clentaminator_Blue;
        }
	}
}
