using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class CrystalStoneWall : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(86, 51, 76));
            dustType = DustID.PinkCrystalShard;
        }
    }
}
