using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class OblivionBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.DarkViolet);
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        drop = Mod.Find<ModItem>("OblivionBrick").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        dustType = DustID.Adamantine;
    }
}