using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class BismuthBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("BismuthBrickWall");
            AddMapEntry(new Color(96, 53, 105));
            dustType = ModContent.DustType<Dusts.BismuthDust>();
        }
    }
}