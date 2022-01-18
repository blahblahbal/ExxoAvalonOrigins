using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class AmethystGemWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("AmethystGemWall");
            AddMapEntry(new Color(85, 30, 103));
            dustType = DustID.Stone;
        }
    }
}