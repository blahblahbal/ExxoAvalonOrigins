using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class RainbowCandyCaneWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("RainbowCandyCaneWall").Type;
            AddMapEntry(new Color(60, 0, 100));
        }
    }
}