using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DarkMatterSlimeBlock : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("DarkSlimeBlockWall").Type;
            AddMapEntry(new Color(51, 0, 96));
            dustType = DustID.UnholyWater;
        }
    }
}