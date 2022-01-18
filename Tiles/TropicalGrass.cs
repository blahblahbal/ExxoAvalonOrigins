using ExxoAvalonOrigins.Items.Placeable.Tile;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class TropicalGrass : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(56, 215, 29));
            SetModTree(new TropicalTree());
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            drop = ModContent.ItemType<TropicalMudBlock>();
            // do drop
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].type = (ushort)ModContent.TileType<TropicalMud>();
                WorldGen.SquareTileFrame(i, j);
            }
        }
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<TropicalSapling>();
        }
    }
}
