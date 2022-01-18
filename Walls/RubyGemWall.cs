using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class RubyGemWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("RubyGemWall");
            AddMapEntry(new Color(125, 50, 64));
            dustType = DustID.Stone;
        }
    }
}