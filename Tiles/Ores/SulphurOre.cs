using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class SulphurOre : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(218, 216, 114), LanguageManager.Instance.GetText("Sulphur"));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        drop = Mod.Find<ModItem>("Sulphur").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = DustID.Enchanted_Gold;
    }
}