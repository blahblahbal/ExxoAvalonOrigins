using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Walls;

public class OblivionBrickWall : ModWall
{
    public override void SetStaticDefaults()
    {
        Main.wallHouse[Type] = true;
        drop = Mod.Find<ModItem>("ObsidianLavaTube").Type;
        AddMapEntry(new Color(121, 0, 48));
    }
}