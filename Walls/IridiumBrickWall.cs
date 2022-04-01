using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class IridiumBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("IridiumBrickWall").Type;
            AddMapEntry(new Color(95, 116, 72));
            dustType = ModContent.DustType<Dusts.IridiumDust>();
        }
    }
}