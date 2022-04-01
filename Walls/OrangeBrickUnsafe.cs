using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class OrangeBrickUnsafe : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallDungeon[Type] = true;
            drop = Mod.Find<ModItem>("OrangeBrickUnsafe").Type;
            AddMapEntry(new Color(107, 33, 0));
            dustType = DustID.Coralstone;
        }
    }
}