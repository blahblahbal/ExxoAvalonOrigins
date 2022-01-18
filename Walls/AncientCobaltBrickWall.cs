using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class AncientCobaltBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("AncientCobaltBrickWall");
            AddMapEntry(new Color(22, 53, 80));
            dustType = DustID.Cobalt;
        }
    }
}