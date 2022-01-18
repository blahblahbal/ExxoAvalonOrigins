using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class Vertebrae : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("Vertebrae");
            AddMapEntry(Color.LightCoral);
            dustType = DustID.HeartCrystal;
        }
    }
}