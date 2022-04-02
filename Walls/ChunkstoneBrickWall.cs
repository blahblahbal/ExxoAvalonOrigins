using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class ChunkstoneBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("ChunkstoneBrickWall").Type;
        AddMapEntry(new Color(67, 83, 61));
        dustType = ModContent.DustType<Dusts.ContagionDust>();
    }
}