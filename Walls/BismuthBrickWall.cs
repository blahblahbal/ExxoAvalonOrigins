using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class BismuthBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("BismuthBrickWall").Type;
            AddMapEntry(new Color(96, 53, 105));
            dustType = ModContent.DustType<Dusts.BismuthDust>();
        }
    }
}