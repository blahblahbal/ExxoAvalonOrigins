using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class BronzeBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("BronzeBrickWall");
            AddMapEntry(new Color(61, 29, 26));
            dustType = ModContent.DustType<Dusts.BronzeDust>();
        }
    }
}