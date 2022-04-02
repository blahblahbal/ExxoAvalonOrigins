using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class MintChocCandyCane : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.IndianRed);
        Main.tileSolid[Type] = true;
        drop = Mod.Find<ModItem>("MintChocolateCandyCaneBlock").Type;
    }
}