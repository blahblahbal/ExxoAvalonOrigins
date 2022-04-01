using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DarkMatterGrassWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(new Color(58, 37, 53));
            soundType = SoundID.Grass;
            soundStyle = 1;
            dustType = DustID.UnholyWater;
        }
    }
}
