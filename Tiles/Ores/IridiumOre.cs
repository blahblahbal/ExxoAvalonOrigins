using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace ExxoAvalonOrigins.Tiles.Ores
{
	public class IridiumOre : ModTile
	{
		public override void SetDefaults()
		{
			AddMapEntry(new Color(146, 167, 123), LanguageManager.Instance.GetText("Iridium"));
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileShine2[Type] = true;
			Main.tileShine[Type] = 1150;
            Main.tileValue[Type] = 440;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.IridiumOre>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = ModContent.DustType<Dusts.IridiumDust>();
		}
	}
}
