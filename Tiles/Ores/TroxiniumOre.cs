using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class TroxiniumOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            mineResist = 4f;
            AddMapEntry(Color.Goldenrod, LanguageManager.Instance.GetText("Troxinium"));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileValue[Type] = 660;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 875;
            drop = Mod.Find<ModItem>("TroxiniumOre").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 150;
            dustType = ModContent.DustType<Dusts.TroxiniumDust>();
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
