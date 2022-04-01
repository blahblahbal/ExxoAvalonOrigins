using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class RhodiumBrick : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(Color.Pink);
            Main.tileSolid[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            Main.tileBlockLight[Type] = true;
            drop = Mod.Find<ModItem>("RhodiumBrick").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            dustType = DustID.t_LivingWood;
        }
    }
}
