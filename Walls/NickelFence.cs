using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class NickelFence : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("NickelFence");
            dustType = ModContent.DustType<Dusts.NickelDust>();
        }
    }
}