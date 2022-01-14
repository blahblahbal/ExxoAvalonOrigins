using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class HydrolythOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 8f;
			AddMapEntry(new Color(0, 255, 255), LanguageManager.Instance.GetText("Hydrolyth"));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            drop = mod.ItemType("HydrolythOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 300;
            dustType = DustID.MagicMirror;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
