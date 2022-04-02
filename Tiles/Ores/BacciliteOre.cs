using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class BacciliteOre : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Olive, LanguageManager.Instance.GetText("Baccilite"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1150;
        Main.tileSpelunker[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileValue[Type] = 320;
        Main.tileLighted[Type] = true;
        drop = ModContent.ItemType<Items.Placeable.Tile.BacciliteOre>();
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = DustID.JungleSpore;
        minPick = 55;
    }

    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = 0.18f;
        g = 0.25f;
    }
}