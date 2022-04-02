using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class OrangeBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("OrangeBrickWall").Type;
        AddMapEntry(new Color(107, 33, 0));
        dustType = DustID.Coralstone;
    }
}