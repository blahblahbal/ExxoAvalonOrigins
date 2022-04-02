using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class TuhrtlBrickWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(39, 31, 28));
        drop = Mod.Find<ModItem>("TuhrtlBrickWall").Type;
        dustType = DustID.Silt;
    }
}