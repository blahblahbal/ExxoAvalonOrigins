using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class MintChocolateCandyCaneWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("MintChocolateCandyCaneWall").Type;
        AddMapEntry(new Color(160, 200, 47));
    }
}