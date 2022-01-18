using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class MintChocolateCandyCaneWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("MintChocolateCandyCaneWall");
            AddMapEntry(new Color(160, 200, 47));
        }
    }
}