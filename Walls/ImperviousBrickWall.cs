using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class ImperviousBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        AddMapEntry(new Color(51, 44, 48));
        drop = Mod.Find<ModItem>("ImperviousBrickWall").Type;
        dustType = DustID.Wraith;
    }
}