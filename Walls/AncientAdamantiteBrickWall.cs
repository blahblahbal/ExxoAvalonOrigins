using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class AncientAdamantiteBrickWall : ModWall
    {
        public override void SetDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = mod.ItemType("AncientAdamantiteBrickWall");
            AddMapEntry(new Color(148, 57, 101));
            dustType = DustID.Adamantine;
        }
    }
}