using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class RubyGemWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("RubyGemWall").Type;
            AddMapEntry(new Color(125, 50, 64));
            dustType = DustID.Stone;
        }
    }
}