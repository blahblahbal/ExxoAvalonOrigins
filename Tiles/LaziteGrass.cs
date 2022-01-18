using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class LaziteGrass : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(3, 2, 209));
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileMerge[Type][ModContent.TileType<BlackBlaststone>()] = true;
            Main.tileMerge[ModContent.TileType<BlackBlaststone>()][Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.BlackBlaststone>();
            dustType = DustID.SapphireBolt;
            soundType = SoundID.Tink;
            soundStyle = 1;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (fail && !effectOnly)
            {
                Main.tile[i, j].type = (ushort)ModContent.TileType<BlackBlaststone>();
                WorldGen.SquareTileFrame(i, j);
            }
        }
    }
}
