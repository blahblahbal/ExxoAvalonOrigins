using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class SkyBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(102, 102, 82));
        Main.tileSolid[Type] = true;
        Main.tileMergeDirt[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileMerge[TileID.Cloud][Type] = true;
        Main.tileMerge[Type][TileID.Cloud] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        drop = Mod.Find<ModItem>("SkyBrick").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 300;
        dustType = DustID.Smoke;
    }
    public override bool Slope(int i, int j)
    {
        return ExxoAvalonOriginsWorld.downedDragonLord;
    }
    public override bool CanExplode(int i, int j)
    {
        return false;
    }
}