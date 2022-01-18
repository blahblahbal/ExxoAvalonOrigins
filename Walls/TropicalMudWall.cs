using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class TropicalMudWall : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(67, 32, 20));
            dustType = ModContent.DustType<Dusts.TropicalMudDust>();
        }
    }
}