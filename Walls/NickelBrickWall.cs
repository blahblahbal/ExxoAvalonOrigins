using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class NickelBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("NickelBrickWall").Type;
        AddMapEntry(new Color(52, 78, 85));
        dustType = ModContent.DustType<Dusts.NickelDust>();
    }
}