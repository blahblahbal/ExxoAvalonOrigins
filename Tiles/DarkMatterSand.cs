using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Tiles;

public class DarkMatterSand : ModTile
{
    public override void SetStaticDefaults()
    {
        AddMapEntry(new Color(126, 71, 107));
        Main.tileSolid[Type] = true;
        Main.tileBlockLight[Type] = true;
        drop = Mod.Find<ModItem>("DarkSandBlock").Type;
        dustType = ModContent.DustType<Dusts.DarkMatterDust>();
    }

    public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
    {
        if (!fail)
        {
            ExxoAvalonOriginsWorld.WorldDarkMatterTiles--;
        }
        base.KillTile(i, j, ref fail, ref effectOnly, ref noItem);
    }
}