using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class PyroscoricBrick : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(255, 102, 0));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("PyroscoricBrick");
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.InfernoFork;
        }
    }
}
