using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DarkMatterSlimeBlock : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("DarkSlimeBlockWall");
            AddMapEntry(new Color(51, 0, 96));
            dustType = DustID.UnholyWater;
        }
    }
}