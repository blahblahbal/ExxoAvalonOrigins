using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class HeartstoneBrick : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("HeartstoneBrick").Type;
            AddMapEntry(new Color(126, 12, 28));
        }
    }
}