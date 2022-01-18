using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class TopazGemWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("TopazGemWall");
            AddMapEntry(new Color(97, 75, 28));
            dustType = DustID.Stone;
        }
    }
}