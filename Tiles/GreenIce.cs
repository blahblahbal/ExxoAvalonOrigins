using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class GreenIce : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(41, 200, 0));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("GreenIceBlock").Type;
            Main.tileMerge[Type][TileID.IceBlock] = true;
            Main.tileMerge[TileID.IceBlock][Type] = true;
            Main.tileShine2[Type] = true;
            soundType = SoundID.Item;
            soundStyle = 50;
            dustType = DustID.TerraBlade;
            TileID.Sets.Conversion.Ice[Type] = true;
            ExxoAvalonOrigins.MergeWith(Type, TileID.SnowBlock);
        }
        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, TileID.SnowBlock, false, false, false, false, resetFrame);
            return false;
        }
    }
}
