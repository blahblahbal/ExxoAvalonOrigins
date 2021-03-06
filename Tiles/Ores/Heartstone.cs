using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class Heartstone : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(217, 2, 55), LanguageManager.Instance.GetText("Heartstone"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        drop = Mod.Find<ModItem>("Heartstone").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = DustID.Confetti_Pink;
    }
}