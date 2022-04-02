using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class DurataniumBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("DurataniumBrickWall").Type;
        AddMapEntry(new Color(91, 0, 54));
        dustType = dustType = ModContent.DustType<Dusts.DurataniumDust>();
    }
}