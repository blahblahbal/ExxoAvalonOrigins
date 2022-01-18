using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ChlorophyteBrick : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("ChlorophyteBrickWall");
            AddMapEntry(new Color(10, 200, 20));
            dustType = DustID.Chlorophyte;
        }
    }
}