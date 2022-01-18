using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DurataniumBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("DurataniumBrickWall");
            AddMapEntry(new Color(91, 0, 54));
            dustType = dustType = ModContent.DustType<Dusts.DurataniumDust>();
        }
    }
}