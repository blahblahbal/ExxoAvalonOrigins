using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class TuhrtlBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            AddMapEntry(new Color(39, 31, 28));
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("TuhrtlBrickWall");
            dustType = DustID.Silt;
        }
    }
}