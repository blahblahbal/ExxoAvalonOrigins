using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores
{
    public class OsmiumOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            mineResist = 2f;
            AddMapEntry(new Color(0, 148, 255), LanguageManager.Instance.GetText("Osmium"));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 430;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1150;
            drop = Mod.Find<ModItem>("OsmiumOre").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 60;
            dustType = ModContent.DustType<Dusts.OsmiumDust>();
        }
    }
}
