using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class ChocolateCandyCaneBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(Color.Brown);
        Main.tileSolid[Type] = true;
        drop = Mod.Find<ModItem>("ChocolateCandyCaneBlock").Type;
    }
}