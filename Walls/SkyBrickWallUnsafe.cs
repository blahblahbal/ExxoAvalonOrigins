using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class SkyBrickWallUnsafe : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = false;
            AddMapEntry(new Color(79, 79, 59));
            drop = mod.ItemType("SkyBrickWall");
            dustType = DustID.Smoke;
        }
    }
}
