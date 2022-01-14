using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class DurataniumOre : ModTile
	{
		public override void SetDefaults()
		{
			mineResist = 2f;
			AddMapEntry(Color.Purple, LanguageManager.Instance.GetText("Duratanium"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileValue[Type] = 615;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 925;
            drop = mod.ItemType("DurataniumOre");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 100;
            dustType = ModContent.DustType<Dusts.DurataniumDust>();
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
