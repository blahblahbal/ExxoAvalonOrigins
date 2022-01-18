using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class CoughwoodWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("CoughwoodWall");
            AddMapEntry(new Color(106, 116, 90));
            dustType = ModContent.DustType<Dusts.ContagionDust>();
        }
    }
}