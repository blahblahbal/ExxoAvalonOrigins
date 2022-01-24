using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles.Ancient
{
    public class AncientMythrilBrick : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(145, 191, 117));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1800;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = ModContent.ItemType<Items.Placeable.Tile.Ancient.AncientMythrilBrick>();
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Mythril;
        }
    }
}
