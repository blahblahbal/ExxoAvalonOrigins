using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class Peridot : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(Color.Lime, LanguageManager.Instance.GetText("Peridot"));
            Main.tileSolid[Type] = true;
            drop = mod.ItemType("Peridot");
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileMerge[Type][TileID.Stone] = true;
            Main.tileMerge[TileID.Stone][Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 900;
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 55;
            dustType = DustID.Grass;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
