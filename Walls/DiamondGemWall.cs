using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class DiamondGemWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("DiamondGemWall").Type;
            AddMapEntry(new Color(40, 105, 114));
            dustType = DustID.Stone;
        }
    }
}