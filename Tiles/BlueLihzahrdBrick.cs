using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class BlueLihzahrdBrick : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(0, 22, 44));
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("BlueLihzahrdBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 400;
            dustType = DustID.t_Granite;
        }
    }
}
