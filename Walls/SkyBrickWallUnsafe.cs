using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class SkyBrickWallUnsafe : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = false;
        AddMapEntry(new Color(79, 79, 59));
        drop = Mod.Find<ModItem>("SkyBrickWall").Type;
        dustType = DustID.Smoke;
    }
}