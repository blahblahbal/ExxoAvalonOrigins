using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class LeadBrick : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(62, 82, 114));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = mod.ItemType("LeadBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Lead;
        }
    }
}
