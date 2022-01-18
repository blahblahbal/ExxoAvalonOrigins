using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class RedVelvetCandyCaneWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("RedVelvetCandyCaneWall");
            AddMapEntry(new Color(180, 80, 80));
        }
    }
}