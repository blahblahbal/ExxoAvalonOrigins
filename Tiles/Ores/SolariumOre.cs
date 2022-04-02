using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class SolariumOre : ModTile
{
    public override void SetStaticDefaults()
    {
        mineResist = 4f;
        AddMapEntry(new Color(244, 167, 0), LanguageManager.Instance.GetText("Solarium"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileLighted[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileValue[Type] = 730;
        Main.tileShine[Type] = 1150;
        drop = Mod.Find<ModItem>("SolariumOre").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 210;
        dustType = DustID.SolarFlare;
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 1.052549f;
        g = 0.720392168f;
        b = 0f;
    }
}