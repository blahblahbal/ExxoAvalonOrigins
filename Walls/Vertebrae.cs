using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class Vertebrae : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("Vertebrae").Type;
            AddMapEntry(Color.LightCoral);
            dustType = DustID.HeartCrystal;
        }
    }
}