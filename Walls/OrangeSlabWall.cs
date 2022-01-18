using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class OrangeSlabWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("OrangeSlabWall");
            AddMapEntry(new Color(107, 33, 0));
            dustType = DustID.Coralstone;
        }
    }
}