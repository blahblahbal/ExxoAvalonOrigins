using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles
{
    public class VineRope : ModTile
    {
        public override void SetStaticDefaults()
        {
            AddMapEntry(Color.Lime);
            Main.tileLavaDeath[Type] = true;
            Main.tileRope[Type] = true;
            drop = ItemID.Vine;
            dustType = DustID.Grass;
        }
    }
}