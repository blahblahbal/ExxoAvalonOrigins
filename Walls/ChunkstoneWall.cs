using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ChunkstoneWall : ModWall
    {
        public override void SetDefaults()
        {
            WallID.Sets.Conversion.Stone[Type] = true;
            AddMapEntry(new Color(34, 44, 25));
            dustType = ModContent.DustType<Dusts.ContagionDust>();
        }
    }
}
