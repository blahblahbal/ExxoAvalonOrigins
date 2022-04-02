using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class ChocolateCandyCaneBlock : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("ChocolateCandyCaneWall").Type;
        AddMapEntry(Color.SaddleBrown);
    }
}