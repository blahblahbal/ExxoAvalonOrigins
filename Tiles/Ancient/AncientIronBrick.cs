using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ancient
{
    public class AncientIronBrick : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(147, 119, 96));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1800;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.Ancient.AncientIronBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Iron;
        }
    }
}
