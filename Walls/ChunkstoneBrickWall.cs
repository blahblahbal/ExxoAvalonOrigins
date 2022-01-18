using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ChunkstoneBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("ChunkstoneBrickWall");
            AddMapEntry(new Color(67, 83, 61));
            dustType = ModContent.DustType<Dusts.ContagionDust>();
        }
    }
}