using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class BrimstoneBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(61, 49, 53));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMerge[Type][ModContent.TileType<Impgrass>()] = true;
        Main.tileMerge[Type][TileID.Ash] = true;
        Main.tileMerge[TileID.Ash][Type] = true;
        ItemDrop = ModContent.ItemType<Items.Placeable.Tile.BrimstoneBlock>();
        SoundType = SoundID.Tink;
        SoundStyle = 1;
        DustType = DustID.HeartCrystal;
    }
    public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
    {
        ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.Ash, false, false, false, false, resetFrame);
        return false;
    }
}
