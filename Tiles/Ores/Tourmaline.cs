using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class Tourmaline : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Aqua, LanguageManager.Instance.GetText("Tourmaline"));
        Main.tileSolid[Type] = true;
        drop = Mod.Find<ModItem>("Tourmaline").Type;
        Main.tileBlockLight[Type] = true;
        Main.tileSpelunker[Type] = true;
        Main.tileMerge[Type][TileID.Stone] = true;
        Main.tileMerge[TileID.Stone][Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 900;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 55;
        dustType = DustID.Stone;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}