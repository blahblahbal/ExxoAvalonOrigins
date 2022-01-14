using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class HallowedOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 2f;
			AddMapEntry(new Color(219, 183, 0), LanguageManager.Instance.GetText("Hallowed Ore"));
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 690;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1150;
            drop = mod.ItemType("HallowedOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 185;
            dustType = DustID.Enchanted_Gold;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
