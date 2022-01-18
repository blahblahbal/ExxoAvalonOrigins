using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class YellowIce : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(234, 204, 0));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[Type][TileID.IceBlock] = true;
            Main.tileMerge[TileID.IceBlock][Type] = true;
            Main.tileMerge[Type][TileID.CorruptIce] = true;
            Main.tileMerge[TileID.CorruptIce][Type] = true;
            Main.tileMerge[Type][TileID.FleshIce] = true;
            Main.tileMerge[TileID.FleshIce][Type] = true;
            Main.tileShine2[Type] = true;
            TileID.Sets.Conversion.Ice[Type] = true;
            drop = mod.ItemType("YellowIceBlock");
            ExxoAvalonOrigins.MergeWith(Type, TileID.SnowBlock);
            soundType = SoundID.Item;
            soundStyle = 50;
            dustType = ModContent.DustType<Dusts.ContagionSpray>();
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.SnowBlock, forceSameDown: false, forceSameUp: false, forceSameLeft: false, forceSameRight: false, resetFrame);
            return false;
        }
    }
}
