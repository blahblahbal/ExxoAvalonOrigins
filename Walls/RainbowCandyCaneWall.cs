using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class RainbowCandyCaneWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("RainbowCandyCaneWall");
            AddMapEntry(new Color(60, 0, 100));
        }
    }
}