using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class AncientMythrilBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("AncientMythrilBrickWall");
            AddMapEntry(new Color(60, 91, 58));
            dustType = DustID.Mythril;
        }
    }
}