using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class OblivionOre : ModTile
{
    public override void SetStaticDefaults()
    {
        mineResist = 8f;
        AddMapEntry(new Color(127, 0, 110), LanguageManager.Instance.GetText("Oblivion Ore"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileValue[Type] = 900;
        drop = Mod.Find<ModItem>("OblivionOre").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 300;
        dustType = DustID.Adamantine;
    }

    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}