using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class ChocolateCandyCaneBlock : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("ChocolateCandyCaneWall");
            AddMapEntry(Color.SaddleBrown);
        }
    }
}