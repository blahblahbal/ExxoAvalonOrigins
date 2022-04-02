using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class EctoplasmWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("EctoplasmWall").Type;
        AddMapEntry(new Color(0, 131, 181));
        dustType = DustID.Ultrabright;
    }
}