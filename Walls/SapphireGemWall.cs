using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class SapphireGemWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("SapphireGemWall").Type;
            AddMapEntry(new Color(50, 82, 125));
            dustType = DustID.Stone;
        }
    }
}