using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class NaquadahBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("NaquadahBrickWall");
            AddMapEntry(new Color(0, 0, 88));
            dustType = ModContent.DustType<Dusts.NaquadahDust>();
        }
    }
}