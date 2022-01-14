using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class SulphurOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(218, 216, 114), LanguageManager.Instance.GetText("Sulphur"));
			Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
			drop = mod.ItemType("Sulphur");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Enchanted_Gold;
        }
	}
}
