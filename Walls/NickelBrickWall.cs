using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class NickelBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("NickelBrickWall");
            AddMapEntry(new Color(52, 78, 85));
            dustType = ModContent.DustType<Dusts.NickelDust>();
        }
    }
}