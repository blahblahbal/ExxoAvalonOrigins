using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class TropicalGrassWall : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(35, 76, 0));
            soundType = SoundID.Grass;
            soundStyle = 1;
            dustType = DustID.GrassBlades;
        }
    }
}