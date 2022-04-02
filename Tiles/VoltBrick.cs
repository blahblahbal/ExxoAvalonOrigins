using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class VoltBrick : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("VoltBrick").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.CorruptGibsPowder;
        }
    }
}
