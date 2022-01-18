using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DarkMatterWoodWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("DarkMatterWoodWall");
            AddMapEntry(new Color(56, 40, 63));
            dustType = ModContent.DustType<Dusts.DarkMatterDust>();
        }
    }
}