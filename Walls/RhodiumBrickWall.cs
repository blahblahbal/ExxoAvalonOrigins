using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class RhodiumBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("RhodiumBrickWall");
            AddMapEntry(new Color(159, 117, 124));
            dustType = DustID.t_LivingWood;
        }
    }
}