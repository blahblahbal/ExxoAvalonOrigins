using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class EmeraldGemWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("EmeraldGemWall").Type;
            AddMapEntry(new Color(26, 97, 58));
            dustType = DustID.Stone;
        }
    }
}