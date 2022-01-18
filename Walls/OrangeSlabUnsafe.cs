using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class OrangeSlabUnsafe : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallDungeon[Type] = true;
            drop = mod.ItemType("OrangeSlabUnsafe");
            AddMapEntry(new Color(107, 33, 0));
            dustType = DustID.Coralstone;
        }
    }
}