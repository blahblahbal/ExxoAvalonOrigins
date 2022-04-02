using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class ZincBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("ZincBrickWall").Type;
        AddMapEntry(new Color(76, 65, 75));
        dustType = ModContent.DustType<Dusts.ZincDust>();
    }
}