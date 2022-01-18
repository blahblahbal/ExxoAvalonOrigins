using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DiamondGemWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("DiamondGemWall");
            AddMapEntry(new Color(40, 105, 114));
            dustType = DustID.Stone;
        }
    }
}