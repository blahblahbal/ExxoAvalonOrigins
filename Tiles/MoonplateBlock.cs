using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class MoonplateBlock : ModTile
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(179, 187, 199));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = mod.ItemType("MoonplateBlock");
            soundType = SoundID.Tink;
            soundStyle = 1;
        }
    }
}
