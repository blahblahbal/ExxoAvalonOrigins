using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class RhodiumBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("RhodiumBrickWall").Type;
        AddMapEntry(new Color(159, 117, 124));
        dustType = DustID.t_LivingWood;
    }
}