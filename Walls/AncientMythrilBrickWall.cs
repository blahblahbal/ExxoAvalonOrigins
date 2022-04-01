using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class AncientMythrilBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("AncientMythrilBrickWall").Type;
            AddMapEntry(new Color(60, 91, 58));
            dustType = DustID.Mythril;
        }
    }
}