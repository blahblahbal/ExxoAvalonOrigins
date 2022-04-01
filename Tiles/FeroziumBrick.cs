using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class FeroziumBrick : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(0, 0, 250));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = Mod.Find<ModItem>("FeroziumBrick").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.Ultrabright;
        }
    }
}
