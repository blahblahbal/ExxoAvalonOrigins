using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class VoltBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("VoltBrickWall").Type;
        AddMapEntry(Color.MediumPurple);
        dustType = DustID.PurpleTorch;
    }
}