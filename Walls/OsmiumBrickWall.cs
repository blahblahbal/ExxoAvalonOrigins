using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class OsmiumBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("OsmiumBrickWall").Type;
            AddMapEntry(new Color(24, 97, 149));
            dustType = ModContent.DustType<Dusts.OsmiumDust>();
        }
    }
}