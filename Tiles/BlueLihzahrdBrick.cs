using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class BlueLihzahrdBrick : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(0, 22, 44));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileMerge[Type][TileID.WoodBlock] = true;
        Main.tileMerge[TileID.WoodBlock][Type] = true;
        drop = Mod.Find<ModItem>("BlueLihzahrdBrick").Type;
        soundType = SoundID.Tink;
        soundStyle = 1;
        minPick = 400;
        dustType = DustID.t_Granite;
    }
}