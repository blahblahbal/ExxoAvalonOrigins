using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class CoughwoodWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("CoughwoodWall").Type;
        AddMapEntry(new Color(106, 116, 90));
        dustType = ModContent.DustType<Dusts.ContagionDust>();
    }
}