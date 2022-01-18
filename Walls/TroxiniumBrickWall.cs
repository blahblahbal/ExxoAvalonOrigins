using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class TroxiniumBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("TroxiniumBrickWall");
            AddMapEntry(new Color(180, 88, 0));
            dustType = ModContent.DustType<Dusts.TroxiniumDust>();
        }
    }
}
