using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class BismuthOre : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(187, 89, 192), LanguageManager.Instance.GetText("Bismuth"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1000;
        Main.tileValue[Type] = 275;
        Main.tileSpelunker[Type] = true;
        Main.tileBlockLight[Type] = true;
        drop = ModContent.ItemType<Items.Placeable.Tile.BismuthOre>();
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = ModContent.DustType<Dusts.BismuthDust>();
    }
}