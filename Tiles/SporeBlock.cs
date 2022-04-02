using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class SporeBlock : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(133, 235, 38));
        Main.tileSolid[Type] = true;
        drop = Mod.Find<ModItem>("SporeBlock").Type;
        dustType = DustID.GreenFairy;
    }
}