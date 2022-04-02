using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class FeroziumOre : ModTile
{
    public override void SetStaticDefaults()
    {
        mineResist = 2f;
        AddMapEntry(new Color(0, 0, 250), LanguageManager.Instance.GetText("Ferozium"));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileValue[Type] = 690;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1150;
        drop = Mod.Find<ModItem>("FeroziumOre").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 180;
        dustType = DustID.Ultrabright;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}