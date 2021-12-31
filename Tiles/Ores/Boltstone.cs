using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class Boltstone : ModTile
    {
        private Color starstoneColor = new Color(40, 195, 67);
        public override void SetDefaults()
        {
            AddMapEntry(starstoneColor, LanguageManager.Instance.GetText("Boltstone"));
            Main.tileSolid[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 775;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.Boltstone>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.GreenTorch;
        }
    }
}
