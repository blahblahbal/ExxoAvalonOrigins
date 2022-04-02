using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class DarkMatterWoodWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("DarkMatterWoodWall").Type;
        AddMapEntry(new Color(56, 40, 63));
        dustType = ModContent.DustType<Dusts.DarkMatterDust>();
    }
}