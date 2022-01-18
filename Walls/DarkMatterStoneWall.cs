using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DarkMatterStoneWall : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(51, 4, 88));
            soundType = SoundID.NPCKilled;
            soundStyle = 1;
            dustType = DustID.UnholyWater;
        }
    }
}
