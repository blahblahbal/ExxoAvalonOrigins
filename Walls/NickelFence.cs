using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class NickelFence : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("NickelFence").Type;
        dustType = ModContent.DustType<Dusts.NickelDust>();
    }
}