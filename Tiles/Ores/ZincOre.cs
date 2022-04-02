using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ores;

public class ZincOre : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(168, 155, 168), LanguageManager.Instance.GetText("Zinc"));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileShine2[Type] = true;
        Main.tileShine[Type] = 1025;
        Main.tileValue[Type] = 255;
        Main.tileSpelunker[Type] = true;
        Main.tileBlockLight[Type] = true;
        drop = ModContent.ItemType<Items.Placeable.Tile.ZincOre>();
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = ModContent.DustType<Dusts.ZincDust>();
    }
}