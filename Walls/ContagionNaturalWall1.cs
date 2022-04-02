using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class ContagionNaturalWall1 : ModWall
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(57, 55, 12));
        WallID.Sets.Conversion.Sandstone[Type] = true;
    }
}