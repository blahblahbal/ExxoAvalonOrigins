using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class TropicalMud : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(95, 38, 12));
        Main.tileSolid[Type] = true;
        Main.tileMerge[TileID.Dirt][Type] = true;
        Main.tileMerge[Type][TileID.Dirt] = true;
        Main.tileBrick[Type] = true;
        Main.tileBlockLight[Type] = true;
        drop = Mod.Find<ModItem>("TropicalMudBlock").Type;
        dustType = ModContent.DustType<Dusts.TropicalMudDust>();
    }
}