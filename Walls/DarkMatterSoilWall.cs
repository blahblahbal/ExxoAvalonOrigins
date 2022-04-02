using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class DarkMatterSoilWall : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(103, 48, 84));
        dustType = DustID.UnholyWater;
    }
}