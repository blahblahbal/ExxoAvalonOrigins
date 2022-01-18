using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ZincBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("ZincBrickWall");
            AddMapEntry(new Color(76, 65, 75));
            dustType = ModContent.DustType<Dusts.ZincDust>();
        }
    }
}