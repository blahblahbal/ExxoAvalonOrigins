using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ImperviousBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            AddMapEntry(new Color(51, 44, 48));
            drop = mod.ItemType("ImperviousBrickWall");
            dustType = DustID.Wraith;
        }
    }
}