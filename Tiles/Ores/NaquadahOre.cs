using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class NaquadahOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            mineResist = 3f;
            AddMapEntry(Color.Blue, LanguageManager.Instance.GetText("Naquadah"));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileValue[Type] = 635;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 900;
            drop = Mod.Find<ModItem>("NaquadahOre").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 110;
            dustType = ModContent.DustType<Dusts.NaquadahDust>();
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
