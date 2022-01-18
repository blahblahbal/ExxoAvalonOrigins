using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class Nest : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(198, 175, 132));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("NestBlock");
            dustType = DustID.MarblePot;
            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalMud>());
            ExxoAvalonOrigins.MergeWith(Type, ModContent.TileType<TropicalGrass>());
        }

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            ExxoAvalonOrigins.MergeWithFrame(i, j, Type, ModContent.TileType<TropicalMud>(), false, false, false, false, resetFrame);
            return false;
        }
    }
}