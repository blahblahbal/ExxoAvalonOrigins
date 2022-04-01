using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ChlorophyteBrick : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("ChlorophyteBrickWall").Type;
            AddMapEntry(new Color(10, 200, 20));
            dustType = DustID.Chlorophyte;
        }
    }
}