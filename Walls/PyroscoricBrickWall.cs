using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class PyroscoricBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("PyroscoricBrickWall");
            AddMapEntry(new Color(154, 40, 0));
            dustType = DustID.InfernoFork;
        }
    }
}