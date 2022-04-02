using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class FeroziumBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("FeroziumBrickWall").Type;
        AddMapEntry(new Color(0, 123, 200));
    }
}