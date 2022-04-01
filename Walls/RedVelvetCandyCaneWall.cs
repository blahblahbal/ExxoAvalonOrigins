using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class RedVelvetCandyCaneWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("RedVelvetCandyCaneWall").Type;
            AddMapEntry(new Color(180, 80, 80));
        }
    }
}