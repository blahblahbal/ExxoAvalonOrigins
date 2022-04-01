using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class NaquadahBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("NaquadahBrickWall").Type;
            AddMapEntry(new Color(0, 0, 88));
            dustType = ModContent.DustType<Dusts.NaquadahDust>();
        }
    }
}