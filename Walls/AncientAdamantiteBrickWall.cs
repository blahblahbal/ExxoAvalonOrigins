using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls
{
    public class AncientAdamantiteBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;
            drop = Mod.Find<ModItem>("AncientAdamantiteBrickWall").Type;
            AddMapEntry(new Color(148, 57, 101));
            dustType = DustID.Adamantine;
        }
    }
}