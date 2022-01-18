using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class IridiumBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("IridiumBrickWall");
            AddMapEntry(new Color(95, 116, 72));
            dustType = ModContent.DustType<Dusts.IridiumDust>();
        }
    }
}