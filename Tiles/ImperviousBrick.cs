using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class ImperviousBrick : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(10, 10, 10));
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Ash][Type] = true;
            Main.tileMerge[Type][TileID.Ash] = true;
            Main.tileMerge[Type][TileID.WoodBlock] = true;
            Main.tileMerge[TileID.WoodBlock][Type] = true;
            drop = Mod.Find<ModItem>("ImperviousBrick").Type;
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 300;
            dustType = DustID.Wraith;
        }
        public override bool Slope(int i, int j)
        {
            return ExxoAvalonOriginsWorld.downedPhantasm;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}
