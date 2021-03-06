using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class BlackBlaststone : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(20, 20, 20));
        Main.tileSolid[Type] = true;
        Main.tileShine[Type] = 1150;
        Main.tileBlockLight[Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.BlackBlaststone>();
        SoundType = SoundID.Tink;
        SoundStyle = 1;
        DustType = DustID.Wraith;
        ExxoAvalonOrigins.MergeWith(Type, TileID.Ash);
    }

    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.Ash, false, false, false, false, resetFrame);
        return false;
    }
}
