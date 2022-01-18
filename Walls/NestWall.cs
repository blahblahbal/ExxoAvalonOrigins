using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class NestWall : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(130, 113, 96));
            dustType = DustID.MarblePot;
        }
    }
}